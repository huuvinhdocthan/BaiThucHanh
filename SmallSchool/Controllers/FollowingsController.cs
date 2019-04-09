using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallSchool.Controllers
{
    public class FollowingsController : Controller
    {
        // GET: Followings
        public ActionResult Index()
        {
            return View();
        }
    }
}