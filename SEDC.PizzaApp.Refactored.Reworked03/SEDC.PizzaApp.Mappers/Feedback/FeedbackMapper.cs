using SEDC.PizzaApp.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Mappers.Feedback
{
    public static class FeedbackMapper
    {

        public static List<FeedbackViewModel> ToFeedbackViewModel(this List<Domain.Models.Feedback> feedbacks)
        {
            List<FeedbackViewModel> viewModels = new List<FeedbackViewModel>();
            foreach (Domain.Models.Feedback feedback in feedbacks)
            {
                viewModels.Add(feedback.ToFeedbackViewModel());
            }

            return viewModels;
        }
        public static Domain.Models.Feedback ToFeedback(this FeedbackViewModel feedbackViewModel)
        {
            return new Domain.Models.Feedback
            {
                Id = feedbackViewModel.Id,
                Name = feedbackViewModel.Name,
                Email = feedbackViewModel.Email,
                Message = feedbackViewModel.Message
            };
        }

        public static FeedbackViewModel ToFeedbackViewModel(this Domain.Models.Feedback feedback)
        {
            return new FeedbackViewModel
            {
                Id = feedback.Id,
                Name = feedback.Name,
                Email = feedback.Email,
                Message = feedback.Message
            };
        }
    }
}