using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestaurantOnline.Models;
using RestaurantOnline.OrdersRepository;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestarantOnlineTest
{
    [TestFixture]
    public abstract class TestBase
    {
        private IServiceScope scope;
        private readonly WebApplicationFactory<Program> _webApplicationFactory;
        protected HttpClient Client { get; private set; }

        protected IServiceProvider ServiceProvider { get; private set; }

        protected readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        protected TestBase(WebApplicationFactory<Program> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        [OneTimeSetUp]
        public void GlobalInit()
        {
            Client = _webApplicationFactory.CreateClient();
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Client?.Dispose();
            _webApplicationFactory?.Dispose();
        }

        [SetUp]
        protected void Init()
        {
            scope = _webApplicationFactory.Services.CreateScope();
            ServiceProvider = scope.ServiceProvider;
        }

        [TearDown]
        protected void Teardown()
        {
            scope?.Dispose();
        }

        protected async Task<List<MenuPosition>> CreateMenuAsync()
        {
            var repository = ServiceProvider.GetService<IOrdersRepository<MenuPosition>>();
            await repository.ClearAsync();
            var items = TestDataHelper.GetFakeMenuPosition();
            items.Reverse();
            foreach (var item in items)
            {
                repository.AddAsync(item);
            }

            await repository.SaveAsync();
            return items;
        }

        protected async Task<Cart> CreateCartAsync()
        {
            var repository = ServiceProvider.GetService<IOrdersRepository<Cart>>();
            var cart = new Cart()
            {
                Id = Guid.NewGuid(),
            };

            repository.AddAsync(cart);
            await repository.SaveAsync();
            return cart;
        }

        public async Task<T> GetObjectFromResponse<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
