using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public PizzaEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public List<Pizza> GetAll()
        {
            return _pizzaAppDbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Add(entity);
            return _pizzaAppDbContext.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            Pizza pizzaDb = _pizzaAppDbContext.Pizzas.First(x => x.Id == entity.Id);
            if (pizzaDb == null)
            {
                throw new Exception($"Pizza with id {entity.Id} does not exist!");
            }

            _pizzaAppDbContext.Pizzas.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Pizza pizzaDb = _pizzaAppDbContext.Pizzas.First(x => x.Id == id);
            if (pizzaDb == null)
            {
                throw new Exception($"Pizza with id {id} does not exist!");
            }

            _pizzaAppDbContext.Pizzas.Remove(pizzaDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public Pizza GetPizzaOnPromotion()
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.IsOnPromotion);
        }
    }
}
