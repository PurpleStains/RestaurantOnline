using Autofac;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline
{
	public class AutofacRestaurantModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<OrdersRepository.OrdersRepository>().As<IOrdersRepository>();
		}
	}
}
