using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Feedback;

namespace SEDC.PizzaApp.Refactored.Controllers
{   
    public class FeedbackController : Controller
    {
        private IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public IActionResult Index()
        {
            List<FeedbackViewModel> feedbackViewModels = _feedbackService.GetAllFeedbacks();
            return View(feedbackViewModels);
        }

        public IActionResult CreateFeedback()
        {
            FeedbackViewModel feedbackViewModel = new FeedbackViewModel();
            
            return View(feedbackViewModel);
        }

        [HttpPost]
        public IActionResult CreateFeedbackPost(FeedbackViewModel feedbackViewModel)
        {
            try
            {
                _feedbackService.CreateFeedback(feedbackViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }

        }
        public IActionResult EditFeedback(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                FeedbackViewModel feedbackViewModel = _feedbackService.GetFeedbackForEditing(id.Value);
                
                return View(feedbackViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }

        }

        [HttpPost]
        public IActionResult EditFeedbackPost(FeedbackViewModel feedbackViewModel)
        {
            try
            {
                _feedbackService.EditFeedback(feedbackViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }

        }

        public IActionResult DeleteFeedback(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                FeedbackViewModel feedbackViewModel = _feedbackService.GetFeedbackById(id.Value);
                return View(feedbackViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }
        }

        [HttpPost]
        public IActionResult DeleteFeedbackPost(FeedbackViewModel feedbackViewModel)
        {
            try
            {
                _feedbackService.DeleteFeedback(feedbackViewModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }
        }
    }
}
