﻿using FluentResults;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Controllers.RequestModel;
using RestaurantOnline.DatabaseContext;
using RestaurantOnline.Models;

namespace RestaurantOnline.OrdersRepository
{
    public class OrdersRepository<TEntity> : IOrdersRepository<TEntity> where TEntity : class
	{
		private readonly RestaurantDbContext _context;
        private readonly DbSet<TEntity> dbSet;

        public OrdersRepository(RestaurantDbContext context)
        {
			_context = context;
            dbSet = context.Set<TEntity>();
        }

        public Result<Cart> AddToCart(Guid cartId, Guid menuItem)
        {
            var cart = _context.Cart
                .Include(c => c.ToOrder)
                .First(c => c.Id == cartId);

            if (cart is null)
            {
                return Result.Fail<Cart>($"Couldn't find cart with id {cartId} in database ");
            }

            var item = _context.MenuPosition.Find(menuItem);

            if (cart.ToOrder is null) { cart.ToOrder = new List<MenuPosition>(); };
            cart.ToOrder.Add(item);

            _context.SaveChanges();
            return Result.Ok(cart);
        }

        public Result<Cart> CreateCart()
        {
            var cart = new Cart();
            cart.Id = Guid.NewGuid();

            _context.Cart.Add(cart);

            _context.SaveChanges();

            return Result.Ok(cart);
        }

        public List<MenuPosition> GetMenu()
		{
            var query = _context.MenuPosition;
            return query.ToList();
        }

        public Result<CustomerOrder> PlaceOrder(CustomerOrderRequest request)
        {
            var cart = _context.Cart
                .Include(c => c.ToOrder)
                .First(c => c.Id == request.CartId);

            if (cart is null || cart.ToOrder is null)
            {
                return Result.Fail<CustomerOrder>($"Couldn't find cart for client {request.ClientName} order");
            }

            var newOrder = new CustomerOrder()
            {
                Id = Guid.NewGuid(),
                ClientName = request.ClientName,
                City = request.City,
                Street = request.Street,
                Phone = request.Phone,
                Cart = cart
            };

            _context.CustomerOrder.Add(newOrder);
            _context.SaveChanges();

            return Result.Ok(newOrder);
        }

        public Result<CustomerOrder> GetOrder(Guid orderId)
        {
            var result =_context.CustomerOrder
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.ToOrder)
                .First(o => o.Id == orderId);

            return result is null ? Result.Fail($"Order with id: {orderId} doesn't exist") : Result.Ok(result);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken) > -1;

        public async Task<bool> ClearAsync()
        {
            foreach (var entity in dbSet)
                dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > -1;
        }
    }
}
