using MENDESHOP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MENDESHOP.Controllers
{
    public class UserController : Controller
    {
        SHOPMENDEEntities database = new SHOPMENDEEntities();
        // GET: User
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(user.UserName)) ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(user.UserPassword)) ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(user.Email)) ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(user.Sdt)) ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa

                var khachhang = database.Users.FirstOrDefault(k => k.UserName == user.UserName);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    database.Users.Add(user);
                    database.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)

            {

                if (string.IsNullOrEmpty(user.UserName))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống ");
                if (string.IsNullOrEmpty(user.UserPassword))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {

                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khachhang = database.Users.FirstOrDefault(k => k.UserName == user.UserName && k.UserPassword == user.UserPassword);

                    if (khachhang != null)

                    {
                        ViewBag.ThongBao = "Chúc mừng đăng nhập thành công"; //Lưu vào session

                        Session["User"] = khachhang;
                        return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập và mật khẩu không chính xác, xin mời nhập lại";

                    }
                    var admin = database.Administrators.FirstOrDefault(k => k.RollName == user.UserName && k.Passadd == user.UserPassword);
                    if (admin != null)
                    {
                        Session["admin"] = admin;
                        return RedirectToAction("AdminUsers", "Admin");
                    }
                }

            }
            return View();


        }
        public ActionResult Logout()
        {
            // Xóa session hoặc cookie lưu trữ thông tin đăng nhập
            Session["User"] = null;
            // Chuyển hướng người dùng đến trang logout
            return RedirectToAction("Login", "User");
        }
    }
}