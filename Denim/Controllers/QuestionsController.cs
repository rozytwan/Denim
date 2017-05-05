using Denim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Denim.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index(int? page)
        {
            var questions = new[] {
                new Question { QuestionId = 1, QuestionName = "Question 1" },
                new Question { QuestionId = 1, QuestionName = "Question 2" },
                new Question { QuestionId = 1, QuestionName = "Question 3" },
                new Question { QuestionId = 1, QuestionName = "Question 4" }
            };

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, pageSize));
        }
    }
}