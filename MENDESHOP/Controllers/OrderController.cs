using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using MENDESHOP.Models;

namespace MENDESHOP.Controllers
{
    public class OrderController : Controller
    {
        public static void Main(string[] args)
        {
            var order = new Order
            {
                OrderName = "John Doe",
                CustomerPhone = "123-456-7890",
                CustomerAddress = "123 Main St, Anytown USA",
                OrderDate = DateTime.Now,
                Status = "Pending",
                PaymentType = "PayPal",
                CustomerEmail = "johndoe@example.com",
            };
            
            var controller = new OrderController();
            controller.ThanhToan(order);
        } 
        
        [HttpPost]
        public ActionResult ThanhToan(Order order)
        {
            // Log all form values to check if they are received correctly
            foreach (var key in Request.Form.AllKeys)
            {
                Debug.WriteLine($"{key}: {Request.Form[key]}");
            }

            // Check if the model binding was successful and if the model is valid
            if (ModelState.IsValid)
            {
                // Log to confirm if the order is null or valid
                if (order == null)
                {
                    Debug.WriteLine("Order object is null.");
                    return View((Order)null); // Return the view if the order is null (should not happen)
                }

                // Log order details to confirm that data was received
                Debug.WriteLine($"Order received: {order.CustomerName}, {order.CustomerPhone}");

                // Combine the customer address with additional address data from the form
                order.CustomerAddress = $"{order.CustomerAddress}, " +
                                        $"{Request.Form["customer_shipping_ward"]}, " +
                                        $"{Request.Form["customer_shipping_district"]}, " +
                                        $"{Request.Form["customer_shipping_province"]}";

                // Save the order to the database
                try
                {
                    using (var db = new SHOPMENDEEntities())
                    {
                        db.Order.Add(order);
                        db.SaveChanges(); // Save the changes to the database
                    }

                    // Redirect to the Thank action after a successful order save
                    return RedirectToAction("Thank", "Products");
                }
                catch (Exception ex)
                {
                    // Log any exceptions that occur during the database save process
                    Debug.WriteLine("Error saving order: " + ex.Message);
                    ModelState.AddModelError("", "An error occurred while saving the order. Please try again.");
                    return View(order); // Return the view if there is an error
                }
            }

            // Log any model validation errors for debugging
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Debug.WriteLine("Validation error: " + error.ErrorMessage);
            }

            // Return the view if the model state is invalid
            return View(order);
        }
    }
    
}
