﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MENDESHOP.Models;
using System.Net;
using PagedList;

namespace MENDESHOP.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
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

        public ActionResult Thank()
        {
            using (var dBContext = new SHOPMENDEEntities())
            {
                var listProduct = dBContext.Products.ToList();

                // Debugging: Log the number of products retrieved
                System.Diagnostics.Debug.WriteLine($"Products Count: {listProduct.Count}");

                return View(listProduct);
            }
        }
    }
}