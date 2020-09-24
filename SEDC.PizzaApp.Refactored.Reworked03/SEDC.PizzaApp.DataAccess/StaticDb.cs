using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.DataAccess
{
    public static class StaticDb
    {
        static StaticDb()
        {
            PizzaId = 3;
            OrderId = 2;
            UserId = 2;
            PizzaOrderId = 3;
            FeedbackId = 2;
            Pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Id=1,
                    Name="Kaprichioza",
                    IsOnPromotion = true,
                    PizzaOrders = new List<PizzaOrder>
                    {


                    }
                },
                new Pizza
                {
                    Id =2,
                    Name = "Pepperoni",
                    IsOnPromotion = false,
                    PizzaOrders = new List<PizzaOrder>
                    {

                    }
                },
                new Pizza
                {
                    Id=3,
                    Name="Margarita",
                    IsOnPromotion = false,
                    PizzaOrders = new List<PizzaOrder>
                    {
                    }
                },
            };
            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Tanja",
                    LastName = "Stojanovska",
                    Address = "Address1",
                    Orders = new List<Order>{}

                },
                new User
                {
                    Id = 2,
                    FirstName = "Kristina",
                    LastName = "Spasevska",
                    Address = "Address2",
                    Orders = new List<Order>
                    {

                    }
                }
            };
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    PaymentMethod = PaymentMethod.Card,
                    Delivered = true,
                    PizzaStore = "Store1",
                    PizzaOrders = new List<PizzaOrder>
                    {
                        new PizzaOrder
                        {   Id=1,
                            Pizza = Pizzas[0],
                            PizzaId = Pizzas[0].Id,
                            PizzaSize = PizzaSize.Normal,
                            Price = 300,
                            OrderId = 1
                        },
                        new PizzaOrder
                        {
                            Id=2,
                            Pizza = Pizzas[1],
                            PizzaId = Pizzas[1].Id,
                            PizzaSize = PizzaSize.Family,
                            Price = 400,
                            OrderId = 1
                        }
                    },
                    User = Users[0]
                },
                new Order
                {
                    Id = 2,
                    PaymentMethod = PaymentMethod.Cash,
                    Delivered = false,
                    PizzaStore = "Store2",
                    PizzaOrders = new List<PizzaOrder>
                    {
                        new PizzaOrder
                        {
                            Id=3,
                            Pizza = Pizzas[1],
                            PizzaId = Pizzas[1].Id,
                            PizzaSize = PizzaSize.Normal,
                            OrderId  = 2,
                            Price = 300
                        }
                    },
                    User = Users [1]
                }
            };
            Feedbacks = new List<Feedback>
            {
                new Feedback
                {
                    Id = 1,
                    Name = "Name1",
                    Email = "mail@mail.com",
                    Message = "Message1",

                },
                new Feedback
                {
                    Id = 2,
                    Name = "Name2",
                    Email = "mail2@mail2.com",
                    Message = "Message2",

                }

            };

        }
        public static int PizzaId { get; set; }
        public static int OrderId { get; set; }
        public static int UserId { get; set; }
        public static int PizzaOrderId { get; set; }
        public static int FeedbackId { get; set; }

        public static List<Pizza> Pizzas { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<User> Users { get; set; }
        public static List<Feedback> Feedbacks { get; set; }
    }
}