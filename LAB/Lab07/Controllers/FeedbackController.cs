using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab07.Models;

namespace Lab07.Controllers
{
    public class FeedbackController : Controller
    {
        // Temporary feedback list
        private static List<Feedback> feedbacks = new List<Feedback>
        {
            new Feedback
            {
                Id = 1,
                Name = "Manish",
                Email = "manish@gmail.com",
                Message = "Very good service.",
                Rating = 5
            }
        };

        // GET: Feedback
        public ActionResult Index()
        {
            return View(feedbacks);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbacks.Count + 1;

                feedbacks.Add(feedback);

                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int id)
        {
            Feedback feedback = feedbacks.FirstOrDefault(x => x.Id == id);

            if (feedback == null)
            {
                return HttpNotFound();
            }

            return View(feedback);
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int id)
        {
            Feedback feedback = feedbacks.FirstOrDefault(x => x.Id == id);

            if (feedback != null)
            {
                feedbacks.Remove(feedback);
            }

            return RedirectToAction("Index");
        }
    }
}