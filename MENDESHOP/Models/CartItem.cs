using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MENDESHOP.Models;

namespace MENDESHOP.Models
{
    public class CartItem
    {
        SHOPMENDEEntities db = new SHOPMENDEEntities();
        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string ImagePro { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        //Tính FinalPrice = Price * Number
        public decimal FinalPrice()
        {
            return Number * Price;
        }
        public CartItem(int ProductID)
        {
            this.ProductID = ProductID;

            var productDB = db.Products.Single(s => s.ProId == this.ProductID);
            this.NamePro = productDB.ProName;
            this.ImagePro = productDB.ProImage;
            this.Price = (decimal)productDB.ProPrice;
            this.Number = 1;
        }
    }
}