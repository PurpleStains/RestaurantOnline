using Microsoft.AspNetCore.Mvc.Testing;

namespace RestarantOnlineTest
{
    internal class OrderTest : TestBase
    {
        public OrderTest() : base(new WebApplicationFactory<Program>())
        {
        }
    }
}
