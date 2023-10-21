using Autofac;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline.DatabaseContext;

namespace RestaurantOnline
{
    internal class AutofacRestaurantModule : Module
	{
        private readonly string _databaseConnectionString;
        internal AutofacRestaurantModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        } 

		protected override void Load(ContainerBuilder builder)
		{
            builder.Register(c =>
            {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);


                return new RestaurantDbContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

            //var infrastructureAssembly = typeof(RestaurantDbContext).Assembly;

            //builder.RegisterAssemblyTypes(infrastructureAssembly)
            //    .Where(type => type.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope()
            //    .FindConstructorsWith(new AllConstructorFinder());
        }
	}
}
