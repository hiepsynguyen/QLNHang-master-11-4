using DAL.QLNHangData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.OrderItems
{
    public class TableTypeDAO
    {
        public static List<Tbltablecategory> GetAllFoodType()
        {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tbltablecategory.ToList();
        }
    }
}
