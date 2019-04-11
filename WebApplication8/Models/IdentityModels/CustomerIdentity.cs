using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models.CustomerViewModels;
using WebApplication8.Models.UtilEntities;

namespace WebApplication8.Models.IdentityModels
{
    public class CustomerIdentity 
    {
        private readonly WebShopContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public CustomerIdentity(WebShopContext _db, IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
            db = _db;
        }
        public bool Identity {
            get {
                var cus_ = _session.GetObject<CustomerSs>("Customer");
                if (cus_==null) {
                    return false;
                }
                return true;
            }
        }
        public CustomerSs Customer
        {
            get
            {
                var cus_ = _session.GetObject<CustomerSs>("Customer");
                return cus_;
            }
        }
       
       
    }
}
