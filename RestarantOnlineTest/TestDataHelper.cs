using RestaurantOnline.Models;

namespace RestarantOnlineTest
{
    internal class TestDataHelper
    {
        public static List<MenuPosition> GetFakeMenuPosition()
        {
            return new List<MenuPosition>() {
                new MenuPosition
                {
                    Id = new Guid("2D2C5455-B7C1-4E86-A115-A8D23130CF60"),
                    Name = "Cesar Salat",
                    Description = "Most popular salat on the world",
                    Price = 25
                },
                new MenuPosition
                {
                    Id = new Guid("948CBBCC-2ED3-411C-A058-56F5F8F162D8"),
                    Name = "Spaghetti",
                    Description = "Most popular pasta on the world",
                    Price = 31
                },
                new MenuPosition
                {
                    Id = new Guid("93441007-5F80-4417-B612-C51E6D88B4B7"),
                    Name = "Carbonara",
                    Description = "Simple pasta with eggs, bacon and parmeggiano",
                    Price = 28
                },
                new MenuPosition
                {
                    Id = new Guid("7FDC8B20-53D5-444A-9072-3E490AF0CBEA"),
                    Name = "Coca-cola",
                    Description = "Soft drink",
                    Price = 5
                },
                new MenuPosition
                {
                    Id = new Guid("6CABC319-CB50-4795-A96E-362F635C898D"),
                    Name = "Johannes",
                    Description = "Beer",
                    Price = 7
                }
            };
        }
    }
}
