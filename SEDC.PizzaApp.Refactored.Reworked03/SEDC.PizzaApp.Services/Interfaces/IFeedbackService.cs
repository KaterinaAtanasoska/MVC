using SEDC.PizzaApp.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IFeedbackService
    {
        List<FeedbackViewModel> GetAllFeedbacks();
        FeedbackViewModel GetFeedbackById(int id);
        void CreateFeedback(FeedbackViewModel feedbackViewModel);
        FeedbackViewModel GetFeedbackForEditing(int id);
        void EditFeedback(FeedbackViewModel feedbackViewModel);
        void DeleteFeedback(int id);
    }
}
