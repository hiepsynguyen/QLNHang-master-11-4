using DAL.QLNHangData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.OrderItems
{
    public class FoodTypeDAO
    {
        public static List<Tblfoodcategory> GetAllFoodType() {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tblfoodcategory.ToList();
        }
    }
}
