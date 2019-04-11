using DAL.QLNHangData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.OrderItems
{
    public class CommentDAO
    {
        public static List<Tblcomment> GetListByFoodId(int foodId) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tblcomment.Where(x => x.FodId == foodId).ToList();
        }

        public static bool AddComment(Tblcomment model) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            try {
                _db.Add(model);
                _db.SaveChanges();
            } catch (Exception ex) {
                return false;
            }
            return true;
        }
    }
}
