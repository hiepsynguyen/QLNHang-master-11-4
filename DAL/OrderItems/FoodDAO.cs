using DAL.QLNHangData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.OrderItems
{
    public class FoodDAO
    {
        public static Tblfood FindById(int id) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tblfood.FirstOrDefault(x => x.FodId == id && x.Del == false);
        }

        public static List<Tblfood> GetListByTypeId(int typeId) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tblfood.Where(x => x.FodcaId == typeId && x.Del == false).ToList();
        }

        public static List<Tblfood> GetOrderedNameListByTypeId(int typeId, bool isAsc) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
             
            if (isAsc) {
                return _db.Tblfood.Where(x => x.FodcaId == typeId 
                && x.Del == false).OrderBy(x => x.FodName).ToList();
            }
            else
            {
                return _db.Tblfood.Where(x => x.FodcaId == typeId 
                && x.Del == false).OrderByDescending(x => x.FodName).ToList();
            }
        }

        public static List<Tblfood> GetOrderedPriceListByTypeId(int typeId, bool isAsc)
        {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();

            if (isAsc)
            {
                return _db.Tblfood.Where(x => x.FodcaId == typeId 
                && x.Del == false).OrderBy(x => x.Price).ToList();
            }
            else
            {
                return _db.Tblfood.Where(x => x.FodcaId == typeId 
                && x.Del == false).OrderByDescending(x => x.Price).ToList();
            }
        }

        public static List<Tblfood> GetListByName(string name) {
            QLNHangData.QLNhaHangContext _db = new QLNHangData.QLNhaHangContext();
            return _db.Tblfood.Where(x => x.FodName.Contains(name) && x.Del == false).ToList();
        }



    }
}
