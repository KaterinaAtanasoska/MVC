using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.EFImplementations;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;

namespace SEDC.PizzaApp.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            //static db
            // services.AddTransient<IRepository<Order>, OrderRepository>();
            //// services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            // services.AddTransient<IPizzaRepository, PizzaRepository>();
            // services.AddTransient<IRepository<User>, UserRepository>();

            services.AddTransient<IRepository<Order>, OrderEFRepository>();
            services.AddTransient<IPizzaRepository, PizzaEFRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();
            services.AddTransient<IRepository<Feedback>, FeedbackRepository>();

        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-0UETR71\\SQLEXPRESS01;Database=PizzaAppDb;Trusted_Connection=True");
            });
        }
    }
}
