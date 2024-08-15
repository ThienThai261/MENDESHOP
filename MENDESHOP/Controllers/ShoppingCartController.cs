using MENDESHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MENDESHOP.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public List<CartItem> GetCart()
        {
            List<CartItem> myCart = Session["GioHang"] as
           List<CartItem>;
            //Nếu giỏ hàng chưa tồn tại thì tạo mới và đưa vào Session
            if (myCart == null)
            {
                myCart = new List<CartItem>();
                Session["GioHang"] = myCart;
            }
            return myCart;
        }
      
        public ActionResult AddToCart1(int id)
        {
            //Lấy giỏ hàng hiện tại
            List<CartItem> myCart = GetCart();
            CartItem currentProduct = myCart.FirstOrDefault(p => p.ProductID == id);
            if (currentProduct == null)
            {
                currentProduct = new CartItem(id);
                myCart.Add(currentProduct);
            }
            else
            {
                currentProduct.Number++; //Sản phẩm đã có trong giỏ thì tăng số lượng lên 1
            }
            return RedirectToAction("Details", "Products", new
            {
                id = id
            });
        }
        private int GetTotalNumber()
        {
            int totalNumber = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalNumber = myCart.Sum(sp => sp.Number);
            return totalNumber;
        }
        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalPrice = myCart.Sum(sp => sp.FinalPrice());
            return totalPrice;
        }
        public ActionResult GetCartInfo()
        {
            List<CartItem> myCart = GetCart();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("Index", "Products");
            }
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart); //Trả về View hiển thị thông tin giỏ hàng
        }
        public ActionResult CartPartial()
        {
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            List<CartItem> myCart = GetCart();
            CartItem product = myCart.FirstOrDefault(p => p.ProductID == id);

            if (product != null)
            {
                product.Number = quantity;
            }

            int totalNumber = GetTotalNumber();
            decimal totalPrice = GetTotalPrice();

            return Json(new { totalNumber = totalNumber, totalPrice = totalPrice });
        }

        [HttpPost]
        public JsonResult UpdateCartTotals()

        {
            int totalNumber = GetTotalNumber();
            decimal totalPrice = GetTotalPrice();

            return Json(new { totalNumber = totalNumber, totalPrice = totalPrice });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(int id)
        {
            // Lấy giỏ hàng hiện tại
            List<CartItem> myCart = GetCart();
            CartItem product = myCart.FirstOrDefault(p => p.ProductID == id);

            if (product != null)
            {
                myCart.Remove(product);
            }

            // Cập nhật giỏ hàng trong Session
            Session["GioHang"] = myCart;

            // Trả về trang giỏ hàng
            return RedirectToAction("GetCartInfo");
        }
    }

}