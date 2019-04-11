using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.ShoppingCart
{
    public interface IShoppingCart
    {
        void Add(int id,int soluong);
        void Remove(int id);
        void Update(int id,int newQuantity);
        int getQuantity(int id);
        void Clear();
        string TestGetString();
        void TestSet();
        ShoppingCart Cart();
    }
}
