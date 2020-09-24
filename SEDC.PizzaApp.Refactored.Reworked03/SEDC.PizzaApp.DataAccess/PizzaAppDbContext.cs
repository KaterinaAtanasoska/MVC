using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.DataAccess
{
    public  class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions options):base(options)
        {
            
        }

        //define main entities - tables
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //define relations
            modelBuilder.Entity<Order>()// main table
                .HasMany(x => x.PizzaOrders) // 1 - m relation (m side)
                .WithOne(x => x.Order) // define 1 side from (1 -m)
                .HasForeignKey(x => x.OrderId);// foreign key for the 1- m relation

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders) // many records in the PizzaOrder table
                .WithOne(x => x.Pizza) // one record from Pizza table
                .HasForeignKey(x => x.PizzaId); //foreign key in the m table (PizzaOrder)

            //modelBuilder.Entity<Order>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.Orders) //WithOne for 1-1 relation
            //    .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

    


            //seeding (only real columns in DB)
            modelBuilder.Entity<Pizza>()
                .HasData(new Pizza
                    {
                        Id = 1,
                        Name = "Kaprichioza",
                        IsOnPromotion = true
                    },
                    new Pizza
                    {
                        Id = 2,
                        Name = "Pepperoni",
                        IsOnPromotion = false
                    },
                    new Pizza
                    {
                        Id = 3,
                        Name = "Margarita",
                        IsOnPromotion = false
                    });
            modelBuilder.Entity<User>()
                .HasData(new User
                    {
                        Id = 1,
                        FirstName = "Tanja",
                        LastName = "Stojanovska",
                        Address = "Address1",
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Kristina",
                        LastName = "Spasevska",
                        Address = "Address2",
                    });
            modelBuilder.Entity<Order>()// we are sending data just for the columns, the relations are defined above
                .HasData(new Order
                    {
                        Id = 1,
                        PaymentMethod = PaymentMethod.Card,
                        Delivered = true,
                        PizzaStore = "Store1",
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 2,
                        PaymentMethod = PaymentMethod.Cash,
                        Delivered = false,
                        PizzaStore = "Store2",
                        UserId = 2
                    });
            modelBuilder.Entity<PizzaOrder>()
                .HasData(new PizzaOrder
                    {
                        Id = 1,
                        OrderId = 1,
                        PizzaId = 1,
                        Price = 300,
                        PizzaSize = PizzaSize.Normal
                    },
                    new PizzaOrder
                    {
                        Id = 2,
                        OrderId = 1,
                        PizzaId = 2,
                        Price = 350,
                        PizzaSize = PizzaSize.Normal
                    },
                    new PizzaOrder
                    {
                        Id = 3,
                        OrderId = 2,
                        PizzaId = 3,
                        Price = 400,
                        PizzaSize = PizzaSize.Family
                    });

            modelBuilder.Entity<Feedback>()
                .HasData(new Feedback
                {
                    Id = 1,
                    Name = "Name1",
                    Email = "mail@mail.com",
                    Message = "Message1"
                },
                new Feedback
                {
                    Id = 2,
                    Name = "Name2",
                    Email = "mail2@mail.com",
                    Message = "Message2"
                });
        }
    }
}
