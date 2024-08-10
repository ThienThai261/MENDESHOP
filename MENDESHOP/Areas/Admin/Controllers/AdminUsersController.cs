using MENDESHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MENDESHOP.Areas.Admin.Controllers
{
    public class AdminUsersController : Controller
    {
        // GET: Admin/AdminUsers
        public ActionResult Index()
        {
            return View();
        }
   
    

        public ActionResult Setting()
        {
            return View();
        }
    }
}
