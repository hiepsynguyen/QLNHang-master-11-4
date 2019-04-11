using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication8.Models.CustomerViewModels;
using WebApplication8.Data;
using WebApplication8.Models.UtilEntities;
using WebApplication8.Utils;
using WebApplication8.Models.WebShop;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models.IdentityModels;

namespace WebApplication8.Controllers
{
    public class CustomerController : CommonCotroller
    {
        private readonly WebShopContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private CustomerIdentity CustomerIdentity;
        public CustomerController(WebShopContext _db, IHttpContextAccessor httpContextAccessor, CustomerIdentity _customerIdentity) {
            _httpContextAccessor = httpContextAccessor;
            db = _db;
            CustomerIdentity = _customerIdentity;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, IFormCollection form)
        {
            if (ModelState.IsValid) {
                
                try
                {
                    if (_session.GetObject<CustomerSs>("Customer")!=null) {
                        return Redirect(Url.RouteUrl(new { controller="Home",action="Index" }));
                    }
                    var cus = db.Customers.Where(u => u.Email == model.Email).SingleOrDefault();
                    
                   
                    if (cus==null)
                    {
                        Danger(string.Format("<b>Sai email </b> .", ""), true);
                        return View(model);
                    }
                    else
                    {
                        var descrypt = Security_D_E.DecryptString(cus.Password, Security_D_E.key_e_d);

                        if (descrypt == model.Password)
                        {
                            var cus_ = new CustomerSs()
                            {
                                Id = cus.Id,
                                Fullname = cus.Fullname,
                                Email = cus.Email,
                                Activated = cus.Activated
                            };
                            _session.SetObject("Customer", cus_);
                            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));
                        }
                        else {
                            Danger(string.Format("<b>Sai password </b> .", ""), true);
                            return View(model);
                        }
                        
                    }
                }
                catch(Exception e)
                {
                    Danger(string.Format("<b>Lỗi {0}</b> .", e.Message + e.InnerException), false);
                }


            }
            Danger(string.Format("<b>Lỗi đăng nhập</b> .", ""), false);

            return View(model);
        }
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CustomerRegisterView model)
        {
            try {
                var cus_ = db.Customers.Count(u => u.Email == model.Email.Trim());
                if (cus_ > 0)
                {
                    Danger(string.Format("<b>Email đã tồn tại</b> .", ""), false);
                    return View(model);
                }
                else
                {
                    Customer cus = new Customer()
                    {
                        Id=model.Email,
                        Fullname = model.Fullname,
                        Email = model.Email,
                        Password = Security_D_E.EncryptString(model.Password, Security_D_E.key_e_d),
                        Activated = true,
                        Address=model.Address
                    };
                    db.Customers.Add(cus);
                    db.SaveChanges();

                    var cus__ = new CustomerSs() {

                        Id = cus.Id,
                        Fullname = cus.Fullname,
                        Email = cus.Email,
                        Activated = cus.Activated,
                        Address=cus.Address

                    };
                    _session.SetObject("Customer",cus__);
                }

            }
            catch (Exception e) {
                Danger(string.Format("<b>Lỗi {0}</b> .", e.Message + e.InnerException ), true);
                return View(model);
            }
            
            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));
        }
        public IActionResult Edit(string id) {
           // Customer cus=new Customer();
            try {
                var cus_ = db.Customers.Where(u=>u.Email==id).SingleOrDefault();
                CustomerRegisterView cus = new CustomerRegisterView() {
                    Fullname=cus_.Fullname,
                    Address=cus_.Address,
                    Email=cus_.Email
                };
                return View(cus);
            }
            catch {
                return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));
            }
           
        }
        [HttpPost]
        public IActionResult Edit(CustomerRegisterView cus,IFormCollection form)
        {
            try
            {
                var cus_ = db.Customers.Include(u=>u.Orders).Single(u => u.Email == cus.Email);
                if (form["Password"].ToString().Trim() != "") {
                    if (form["Password"].ToString() == form["ConfirmPassword"].ToString())
                    {
                        cus_.Password = Security_D_E.EncryptString(cus.Password, Security_D_E.key_e_d);
                    }
                    else {
                        Danger(string.Format("<b>Mật khẩu không khớp</b> .", ""), true);
                        return View(cus);
                    }
                    
                }
                cus_.Fullname = cus.Fullname;
                cus_.Address = cus.Address;

                db.SaveChanges();
                setCustomerSession(cus_.Email);
                return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));
            }
            catch (Exception e)
            {
                Danger(string.Format("<b>Lỗi {0}</b> .", e.Message+ e.InnerException), true);
                return View(cus);
            }

        }
        public void setCustomerSession( string email) {
            var cus = db.Customers.Include(u => u.Orders).Single(u => u.Email == email);
            var cus__ = new CustomerSs()
            {

                Id = cus.Id,
                Fullname = cus.Fullname,
                Email = cus.Email,
                Activated = cus.Activated,
                Address = cus.Address

            };
            _session.SetObject("Customer", cus__);
        }
        public IActionResult LogOff() {
            if (CustomerIdentity.Identity) {
                _session.Remove("Customer");
            }
           return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));

        }

    }
}