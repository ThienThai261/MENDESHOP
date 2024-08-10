using MENDESHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MENDESHOP.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
        [HttpPost]
        public ActionResult KQTimKiem(string sTuKhoa)
        {
            //Tìm kiếm theo tên sản phẩm
            var lstSP = dBContext.Products.Where(n => n.ProName.Contains(sTuKhoa));
            return View(lstSP.OrderBy(n => n.ProName));
        }
        public ActionResult Index()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }
        public ActionResult Shirt()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }
        public ActionResult Jacket()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }
        public ActionResult Tee()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }

        public ActionResult Bag()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }

        public ActionResult Pants()
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            List<Product> Listproduct = dBContext.Products.ToList();
            return View(Listproduct);
        }
        public ActionResult Details(int id)
        {
            SHOPMENDEEntities dBContext = new SHOPMENDEEntities();
            Product product = dBContext.Products.FirstOrDefault(x => x.ProId == id);
            return View(product);
        }
    }
}