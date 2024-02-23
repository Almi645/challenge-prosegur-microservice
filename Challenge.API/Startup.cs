using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Challenge.Repository.Context;
using Challenge.Repository.Entities;
using Challenge.Repository.Base;
using Challenge.Application.Base;
using Challenge.API.Infrastructure.Filters;
using System.Collections.Generic;
using Challenge.API.Infrastructure.Extensions;

namespace Challenge.AI
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddHttpClient();
            services.AddMvc(options => { options.Filters.Add<RequestExceptionFilter>(); });
            services.AddSwaggerGen();
            services.AddCustomCors("CorsPolicy");

            services.ResolveApplication(configuration);
            services.ResolveRepository(configuration);


        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.MapControllers();

            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            InitializeData(context);
        }

        public void InitializeData(DatabaseContext dbContext)
        {
            dbContext.Add(new Product { name = "Expreso Tradicional", price = 12.90M, stock = 0 });
            dbContext.Add(new Product { name = "Expreso Flat White", price = 13.00M, stock = 1 });
            dbContext.Add(new Product { name = "Expreso Macchiato", price = 12.50M, stock = 40 });
            dbContext.Add(new Product { name = "Expreso Panna", price = 10.00M, stock = 60 });
            dbContext.Add(new Product { name = "Expreso Latte", price = 13.00M, stock = 12 });
            dbContext.Add(new Product { name = "Expreso Latte Macchiato", price = 15.50M, stock = 18 });
            dbContext.Add(new Product { name = "Expreso Latte Capuccino", price = 16.90M, stock = 23 });
            dbContext.Add(new Product { name = "Cookie choco chip horneada", price = 15.00M, stock = 50 });
            dbContext.Add(new Product { name = "Cookie choco blanco con nueces horneada", price = 11.00M, stock = 45 });
            dbContext.Add(new Product { name = "Cookie doble chocolate horneada", price = 12.00M, stock = 52 });
            dbContext.Add(new Product { name = "Muffin Chocolate", price = 8.90M, stock = 44 });
            dbContext.Add(new Product { name = "Muffin Vainilla", price = 8.00M, stock = 35 });
            dbContext.Add(new Product { name = "Muffin Arándanos", price = 12.50M, stock = 22 });

            dbContext.Add(new Province { name = "Lima", tax = 7.00M });
            dbContext.Add(new Province { name = "Callao", tax = 5.10M });
            dbContext.Add(new Province { name = "Barranca", tax = 6.00M });
            dbContext.Add(new Province { name = "Cajatambo", tax = 5.00M });
            dbContext.Add(new Province { name = "Canta", tax = 6.10M });
            dbContext.Add(new Province { name = "Cañete", tax = 6.70M });
            dbContext.Add(new Province { name = "Huaral", tax = 4.00M });
            dbContext.Add(new Province { name = "Huarochiri", tax = 3.10M });

            dbContext.Add(new Customer { name = "Miguel", lastName = "Mamani Arotoma", address = "Lima, Perú" });
            dbContext.Add(new Customer { name = "Jose", lastName = "Abelardo Quiñones", address = "Lima, Perú" });
            dbContext.Add(new Customer { name = "María", lastName = "Caceres Valdiviezo", address = "Lima, Perú" });

            var menu01 = new Menu();
            menu01.id = 1;
            menu01.name = "Ordenes";
            menu01.url = "/order";
            menu01.actions = new List<Action>();

            var action01 = new Action();
            action01.id = 1;
            action01.name = "Crear Orden";
            action01.menuId = 1;

            var action02 = new Action();
            action02.id = 2;
            action02.name = "Ver Detalle de Orden";
            action02.menuId = 1;

            menu01.actions.Add(action01);
            menu01.actions.Add(action02);

            var menu02 = new Menu();
            menu02.id = 2;
            menu02.name = "Facturas";
            menu02.url = "/invoice";
            menu02.actions = new List<Action>();

            var action03 = new Action();
            action03.id = 3;
            action03.name = "Generar Factura";
            action03.menuId = 2;

            var action04 = new Action();
            action04.id = 4;
            action04.name = "Ver Detalle de Factura";
            action04.menuId = 2;

            menu02.actions.Add(action03);
            menu02.actions.Add(action04);

            dbContext.Add(menu01);
            dbContext.Add(menu02);

            var profile01 = new Profile { name = "Administrador" };
            profile01.id = 1;
            profile01.profileActions = new List<ProfileAction>
            {
                new ProfileAction { profileId = 1, actionId = 1 },
                new ProfileAction { profileId = 1, actionId = 2 },
                new ProfileAction { profileId = 1, actionId = 3 },
                new ProfileAction { profileId = 1, actionId = 4 }
            };

            dbContext.Add(profile01);

            var profile02 = new Profile { name = "Supervisor" };
            profile02.id = 2;
            profile02.profileActions = new List<ProfileAction>
            {
                new ProfileAction { profileId = 2, actionId = 2 },
                new ProfileAction { profileId = 2, actionId = 3 },
                new ProfileAction { profileId = 2, actionId = 4 }
            };

            dbContext.Add(profile02);

            var profile03 = new Profile { name = "Employee" };
            profile03.id = 3;
            profile03.profileActions = new List<ProfileAction>
            {
                new ProfileAction { profileId = 3, actionId = 1 },
                new ProfileAction { profileId = 3, actionId = 2 }
            };

            dbContext.Add(profile03);

            dbContext.Add(new User { username = "administrator@gmail.com", password = "123@", profileId = 1 });
            dbContext.Add(new User { username = "supervisor@gmail.com", password = "123@", profileId = 2 });
            dbContext.Add(new User { username = "employee@gmail.com", password = "123@", profileId = 3 });

            dbContext.SaveChanges();
        }
    }
}