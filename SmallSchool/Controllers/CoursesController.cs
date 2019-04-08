using Microsoft.AspNet.Identity;
using SmallSchool.Models;
using SmallSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallSchool.Controllers
{
    public class CoursesController : Controller
    {
        public readonly ApplicationDbContext _dbContext;
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.categories.ToList()
            };
            return View(viewModel);
        }
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryID = viewModel.Category,
                Place = viewModel.Place
            };
                _dbContext.Course.Add(course); 
                _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}