using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models.UtilEntities;
using WebApplication8.Models.WebShop;

namespace WebApplication8.Models.ShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly WebShopContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public ShoppingCart(WebShopContext webcontext, IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
            db = webcontext;
        }
        
        public static List<Product> Items = new List<Product>();
        public void TestSet()
        {
           
           // HttpContext.Sessions
           _session.SetString("a","Hello");
        }
        public string TestGetString() {
            return _session.GetString("a");
        }

        public void Add(int id, int soluong)
        {
            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                Items = GetListProdudtFromCartItem(Cart_());
                var item = Items.Single(i => i.Id == id);
                item.Quantity = item.Quantity + soluong;
               
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
               // var db = new WebshopContext();
                var item = db.Products.SingleOrDefault(u=>u.Id==id);
                item.Quantity = 1;


                Items.Add(item);



            }
            SetListCartItemFromLProduct(Items);
        }

        public void Clear()
        {
            Items.Clear();
            SetListCartItemFromLProduct(Items);
        }

        public int getQuantity(int id)
        {
            Items = GetListProdudtFromCartItem(Cart_());
            var item = Items.Single(i => i.Id == id);
            return item.Quantity;
        }

        public void Remove(int id)
        {
            Items = GetListProdudtFromCartItem(Cart_());
            var item = Items.Single(i => i.Id == id);
            Items.Remove(item);
            SetListCartItemFromLProduct(Items);
        }

        public void Update(int id, int newQuantity)
        {
            Items = GetListProdudtFromCartItem(Cart_());
            var item = Items.Single(i => i.Id == id);
            item.Quantity = newQuantity;
            SetListCartItemFromLProduct(Items);
        }

       

        public ShoppingCart Cart()
        {
            
            var cart = new ShoppingCart(db, _httpContextAccessor);
            return cart;
            
        }
        public List<CartItem> Cart_() {

            var cart = _session.GetObject<List<CartItem>>("Cart");
            if (cart == null)
            {

                cart = new List<CartItem>();
                // _session.SetString("Cart",_session.SetObject());
                _session.SetObject("Cart", cart);
            }

            return cart;

        }

        public List<Product> GetListProdudtFromCartItem(List<CartItem> list_ci) {
            var list_p = new List<Product>();
            foreach (var ci in list_ci) {
                var pr = db.Products.Include(u => u.Category).Include(u => u.Supplier).SingleOrDefault(u=>u.Id.ToString()==ci.IDPRODUCT);
                pr.Quantity = ci.QUANTITY;
                if (pr!=null) {
                    list_p.Add(pr);
                }
            }
            return list_p;

        }
        public void SetListCartItemFromLProduct(List<Product> list_pr) {
            var list_ci = new List<CartItem>();
            foreach (var p in list_pr) {
                var ci = new CartItem() {IDPRODUCT=p.Id.ToString(),QUANTITY=p.Quantity };
                list_ci.Add(ci);
            }
            _session.SetObject("Cart",list_ci);

        }
        public static int Count
        {
            get
            {
                var a = Items.Count;
                return Items.Count;
            }
        }
        public static double Total
        {
            get
            {
                
                return Items.Sum(p =>
                    p.PriceP * p.Quantity * (1 - p.Discount));
            }
        }
        

    }
    public class CartItem {

        public string IDPRODUCT;
        public int QUANTITY;
       
        
    }
}
