using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MENDESHOP.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace MENDESHOP.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: AdminProduct
        private SHOPMENDEEntities db = new SHOPMENDEEntities();
     
        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "CatName");
            return View();
        }
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProId,ProName,ProPrice,ProImage,CatName")] Product product, HttpPostedFileBase ProImage)
        {
            if (ModelState.IsValid)
            {
                if (ProImage != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(ProImage.FileName);
                    //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    //Lưu tên
                    product.ProImage = fileName;
                    //Save vào Images Folder
                    ProImage.SaveAs(path);
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "Id", "CatName", product.Category);
            return View(product);
        }
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Categories, "Id", "CatName", product.Category);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProId,Category,ProName,ProPrice,ProImage,CatName")] Product product, HttpPostedFileBase ProImage)
        {
            if (ModelState.IsValid)
            {
                var productDB = db.Products.FirstOrDefault(p => p.ProId == product.ProId);
                if (productDB != null)
                {
                    productDB.ProName = product.ProName;
                    productDB.ProPrice = product.ProPrice;
                    if (ProImage != null)
                    {
                        //Lấy tên file của hình được up lên
                        var fileName = Path.GetFileName(ProImage.FileName);
                        //Tạo đường dẫn tới file
                        var path = Path.Combine(Server.MapPath("~/images"), fileName);
                        //Lưu tên
                        productDB.ProImage = fileName;
                        //Save vào Images Folder
                        ProImage.SaveAs(path);
                    }
                    productDB.Category = product.Category;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "Id", "CatName", product.Category);
            return View(product);
        }



        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList(int? category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        { // Tạo Products và có tham chiếu đến Category
            var products = db.Products.Include(p => p.Category);
            // Tìm kiếm chuỗi truy vấn theo category
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.ProName);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.Category.Id).Where(x => x.Category.Id == category);
            }
            //Tìm kiếm chuỗi truy vấn theo NamePro, nếu chuỗi truy vấn SearchString khác rỗng, null
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.ProName.Contains(SearchString));
            }


            //Tìm kiếm chuỗi truy vấn theo đơn giá
            if (min >= 0 && max > 0)
            {
                products = db.Products.OrderByDescending(x => x.ProPrice).Where(p =>
               (double)p.ProPrice >= min && (double)p.ProPrice <= max);
            }

            // Khai báo mỗi trang 4 sản phẩm
            int pageSize = 4;
            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            // Nếu page = null thì đặt lại page là 1.
            if (page == null) page = 1;
            // Trả về các product được phân trang theo kích thước và số trang.
            return View(products.ToPagedList(pageNumber, pageSize));

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
