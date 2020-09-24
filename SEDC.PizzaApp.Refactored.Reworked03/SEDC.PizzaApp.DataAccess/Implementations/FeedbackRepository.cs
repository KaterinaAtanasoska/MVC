using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        public void DeleteById(int id)
        {
            Feedback feedback = StaticDb.Feedbacks.FirstOrDefault(x => x.Id == id);
            if (feedback == null)
            {
                throw new Exception($"Feedback with id {id} was not found");
            }
            int index = StaticDb.Feedbacks.IndexOf(feedback);
            StaticDb.Feedbacks.RemoveAt(index);
        }

        public List<Feedback> GetAll()
        {
            return StaticDb.Feedbacks;
        }

        public Feedback GetById(int id)
        {
            return StaticDb.Feedbacks.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Feedback entity)
        {
            StaticDb.FeedbackId++;
            entity.Id = StaticDb.OrderId;
            StaticDb.Feedbacks.Add(entity);
            return entity.Id;
        }

        public void Update(Feedback entity)
        {
            Feedback feedback = StaticDb.Feedbacks.FirstOrDefault(x => x.Id == entity.Id);
            if (feedback == null)
            {
                throw new Exception($"Feedback with id {entity.Id} does not exist!");
            }
            int index = StaticDb.Feedbacks.IndexOf(feedback);
            StaticDb.Feedbacks[index] = entity;
        }
    }
}