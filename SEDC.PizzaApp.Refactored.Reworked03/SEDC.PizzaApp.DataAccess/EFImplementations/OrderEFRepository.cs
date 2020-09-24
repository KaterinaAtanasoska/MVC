using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext)//DI
        {
            _pizzaAppDbContext = pizzaAppDbContext;
            //var query = _pizzaAppDbContext.Orders
            //    .Include(x => x.PizzaOrders)
            //    .ThenInclude(x => x.Pizza)
            //    .Include(x => x.User);
            //query.ToList();//db call
        }
        public List<Order> GetAll()
        {
            //SELECT*
            //    FROM[PizzaAppDb].[dbo].[Orders] o
            //    inner join dbo.PizzaOrder po
            //on o.Id = po.OrderId
            //inner join dbo.Pizzas p
            //on p.Id = po.PizzaId
            //inner join dbo.Users u
            //on o.UserId = u.Id

            return _pizzaAppDbContext.Orders // access to table Orders
                .Include(x => x.PizzaOrders)//join with pizza orders
                .ThenInclude(x => x.Pizza)//join with Pizzas 
                .Include(x => x.User)//join with User
                .ToList();
        }  

        public Order GetById(int id)
        {
            return _pizzaAppDbContext.Orders
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);//where clause
        }

        public int Insert(Order entity)
        {
            _pizzaAppDbContext.Orders.Add(entity); //no db call
            //_pizzaAppDbContext.Orders.Add(entity2); //no db call
            return _pizzaAppDbContext.SaveChanges(); //call to db
        }

        public void Update(Order entity)
        {
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {entity.Id} was not found!");
            }

            _pizzaAppDbContext.Orders.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
