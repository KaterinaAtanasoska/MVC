using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Feedback;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private IRepository<Feedback> _feedbackRepository;

        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void CreateFeedback(FeedbackViewModel feedbackViewModel)
        {
            Feedback feedback = feedbackViewModel.ToFeedback();            

            int newFeedbackId = _feedbackRepository.Insert(feedback);
            if (newFeedbackId <= 0)
            {
                throw new Exception("Something went wrong while saving the new feedback");
            }
        }

        public void DeleteFeedback()
        {
            throw new NotImplementedException();
        }

        public void EditFeedback(FeedbackViewModel feedbackViewModel)
        {
            Feedback feedbackDb = _feedbackRepository.GetById(feedbackViewModel.Id);
            if (feedbackDb == null)
            {
                throw new Exception($"The feedback with id {feedbackViewModel.Id} was not found!");
            }                    
            
            Feedback editedFeedback = feedbackViewModel.ToFeedback();            
            _feedbackRepository.Update(editedFeedback);
        }

        public List<FeedbackViewModel> GetAllFeedbacks()
        {

            List<Feedback> feedbacks = _feedbackRepository.GetAll();
            List<FeedbackViewModel> viewModels = new List<FeedbackViewModel>();
            foreach (Feedback feedback in feedbacks)
            {
                viewModels.Add(feedback.ToFeedbackViewModel());
            }

            return viewModels;
        }

        public FeedbackViewModel GetFeedbackById(int id)
        {
            Feedback feedback = _feedbackRepository.GetById(id);
            if (feedback == null)
            {
                throw new Exception($"Feedback with id {id} does not exist!");
            }
            return feedback.ToFeedbackViewModel();
        }
    
         public FeedbackViewModel GetFeedbackForEditing(int id)
        {
            Feedback feedbackDb = _feedbackRepository.GetById(id);
            if (feedbackDb == null)
            {                
                throw new Exception($"The feedback with id {id} was not found!");
            }

            return feedbackDb.ToFeedbackViewModel();
        }

        public void DeleteFeedback(int id)
        {
            try
            {
                _feedbackRepository.DeleteById(id);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }      

        
    }
}
