using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Models.WebShop;
using WebApplication8.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models.IdentityModels;
using Microsoft.AspNetCore.Http;
using Stripe;
using WebApplication8.Models.EmailService;
using WebApplication8.Models.StripePayment;

namespace WebApplication8.Controllers
{
    public class OrderController : BaseController
    {
       private readonly ShoppingCart shop;
        private CustomerIdentity CustomerIdentity;
        private EmailService _emailservice;
        public OrderController(WebShopContext _db, ShoppingCart _shop, CustomerIdentity _customerIdentity,EmailService email) : base(_db)
        {
           shop=_shop;
            CustomerIdentity = _customerIdentity;
            _emailservice = email;
        }

        public ActionResult Checkout()
        {
            var model = new Order();
            if (ModelState.IsValid)
            {
                if (ShoppingCart.Items.Count < 1)
                {
                    Danger(string.Format("<b>Đơn hàng rỗng</b>", ""), true);
                    return Redirect(Url.RouteUrl(new {controller="Cart",action="Index" }));
                }
                if (CustomerIdentity.Identity) {
                    model.Receiver = CustomerIdentity.Customer.Fullname;
                    model.CustomerId = CustomerIdentity.Customer.Id;
                    model.Address = CustomerIdentity.Customer.Address;
                }
                
                
                if (model.CustomerId==null) { model.CustomerId = "customer"; }
                model.Amount = ShoppingCart.Total;
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken,IFormCollection _form)
        {
            var idorder = _form["orderid"];
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            var order = db.Orders.Where(u => u.Id.ToString() == idorder).SingleOrDefault();
            if (order!=null) {
                order.Status = 2;
                db.Orders.Update(order);
                db.SaveChanges();
                ReduceQuantity(int.Parse(idorder));
                Success(string.Format("<b>Đơn hàng đã thanh toán thành công</b>", ""), true);
                var customer = customers.Create(new StripeCustomerCreateOptions
                {
                    Email = stripeEmail,
                    SourceToken = stripeToken
                });

                var charge = charges.Create(new StripeChargeCreateOptions
                {
                    Amount = (int)(order.Amount),
                    Description = "Đơn hàng "+order.CodeOrder.ToString()+" đã thanh toán",
                    Currency = "vnd",
                    CustomerId = customer.Id
                });
                return RedirectToAction("Detail", new {id=order.Id });
            }
           

            return View();
        }
       

        public ActionResult Purchase(Order model,IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.OrderDate = DateTime.Now;
                    model.Status = 0;
                    model.Amount = Double.Parse(form["Amount"].ToString().Replace(",",""));
                   
                    db.Orders.Add(model);
                  
                    // var cart_=shop.Cart
                    var cart = shop.Cart();
                    if (ShoppingCart.Items.Count<1) {
                        Danger(string.Format("<b>Đơn hàng rỗng</b>", ""), true);
                        return Redirect(Url.RouteUrl(new { controller = "Cart", action = "Index" }));
                    }
                    foreach (var p in ShoppingCart.Items)
                    {
                        var d = new OrderDetail
                        {
                            Order = model,
                            ProductId = p.Id,
                            UnitPrice = p.PriceP,
                            Discount = p.Discount,
                            Quantity = p.Quantity
                        };
                        ViewBag.ProductDetail = ShoppingCart.Items;
                        db.OrderDetails.Add(d);
                    }
                    db.SaveChanges();
                    model.CodeOrder = "DH" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + "" + model.Id.ToString("D10");
                    db.Orders.Update(model);
                    db.SaveChanges();
                    shop.Clear();
                    Success(string.Format("<b><h5>{0}</h4></b>", "đơn hàng tạo thành công.Chưa thanh toán.<br>Vui lòng thanh toán.."), true);
                    return RedirectToAction("Detail", new { id = model.Id });
                }
                catch (Exception ex)
                {
                    Danger(string.Format("<b><h4>Lỗi: {0}</h4></b>", ex.Message), true);
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            return View("Checkout", model);
        }

        public ActionResult Detail(int id)
        {
            var order = db.Orders.Include(u=>u.Customer).Include(u => u.OrderDetails).ThenInclude(a=>a.Product).SingleOrDefault(u=>u.Id==id);
          //  ViewBag.OrderDetails__ = db.OrderDetails.Include(u => u.Product).Include(u => u.Order).SingleOrDefault(u => u.OrderId == id);
            ViewBag.Total = order.Amount;
            return View(order);
        }

        public ActionResult List()
        {
            if (CustomerIdentity.Identity) {
                var orders = db.Orders
                .Where(o => o.CustomerId == CustomerIdentity.Customer.Id);
                return View(orders);
            }
            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));

        }
        public IActionResult SendEmailConfirm(string emailreceived,string idorder) {
            try {
                if (_emailservice.SendMailOrderNotifi(idorder, emailreceived))
                {
                    Success(string.Format("<b><h5>{0}</h4></b>", "Một Email xác nhận đơn hàng đã được gởi tới email:" + emailreceived + "</br>Vui lòng xác nhận để chúng tôi giao hàng nhanh nhất cho bạn..."), true);

                }
                else
                Danger(string.Format("<b>Xin lỗi ,chúng tôi phát hiện có lỗi trong quá trình gởi Email xác nhận...</b>", ""), true);
               

            } catch (Exception ex) {
                Danger(string.Format("<b>Xin lỗi ,chúng tôi phát hiện có lỗi trong quá trình gởi Email xác nhận...</b><br/>{0}", ex.Message), true);
            }
            return RedirectToAction("Detail", new { id = int.Parse(idorder) });

        }
        public JsonResult TestSendMail() {
            if (_emailservice.SendMailOrderNotifi("10", "trunglusa123@gmail.com")) {
                return Json("OK");
            }
            return Json("Fail");
        }
        public IActionResult ConfirmOrder(string idorder) {
            var order = db.Orders.Where(u=>u.Id==int.Parse(idorder)).SingleOrDefault();
            if (order != null) {
                order.Status = 1;
                db.Orders.Update(order);
                db.SaveChanges();
                //ReduceQuantity(int.Parse(idorder));
            }
            Success(string.Format("<b><h5>{0}</h4></b>", "Bạn đã xác nhận đơn hàng thành công.Cảm ơn bạn"), true);

            return RedirectToAction("Detail", new { id = int.Parse(idorder) });
        }
        public bool ReduceQuantity(int idorder) {
            try {
                var order = db.Orders.Where(u => u.Id == idorder).Include(u => u.OrderDetails).ThenInclude(a => a.Product).SingleOrDefault();
                if (order != null)
                {
                    foreach (var d in order.OrderDetails)
                    {
                        var p = d.Product;
                        if (p != null) {
                            p.Quantity = p.Quantity - d.Quantity;
                            db.Products.Update(p);
                            db.SaveChanges();
                        }
                    }
                }
            } catch {
                return false;
            }
            return true;
        }
    }
}