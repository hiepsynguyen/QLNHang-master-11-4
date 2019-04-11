using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.QLNHangData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication8.Areas.Admin.Models.AttendanceViewModels;
using WebApplication8.Helper;

namespace WebApplication8.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        QLNhaHangContext _db;
        public AttendanceController(QLNhaHangContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DailyAttendanceList(DailyAttendanceSearchModel modelSearch)
        {

            if (modelSearch.DateRange == null)
            {
                modelSearch.DateRange = new Areas.Admin.Models.DateRangeViewModel() {
                    StrDate = DateTime.Now.AddDays(-7),
                    EndDate = DateTime.Now };

            }
            modelSearch.EmpId = modelSearch.EmpId == null ? "" : modelSearch.EmpId;
            var list = (from datt in _db.Tbldetailsattendance
                        join e in _db.Tblemployee
             on datt.EmpId equals e.EmpId
                        join d in _db.Tbldeparment
 on datt.DepId equals d.DepId
                        where datt.AttDt.CompareTo(modelSearch.DateRange.StrDate) >= 0 && datt.AttDt.CompareTo(modelSearch.DateRange.EndDate) <= 0
                        && e.EmpId.Contains(modelSearch.EmpId)
                        select new DailyAttendanceListView() { detailsatt = datt, dep_nm = d.DepNm, name_emp = e.EmpNm }).ToList();
            ViewData["list_details"] = list;
            return View(modelSearch);
        }


        [HttpPost]
        public IActionResult CalDailyAttendancePost()
        {
            //var r = Request;
            QLNhaHangContext _db = new QLNhaHangContext();
            List<Tbldetailsattendance> l = new List<Tbldetailsattendance>();
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                var _obj = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(body);
                foreach (var x in _obj)
                {
                    var datt = _db.Tbldetailsattendance.Where(z => z.EmpId == x.Value<string>("EmpId") && z.AttDt == x.Value<DateTime>("AttDt")).FirstOrDefault();
                    string st = x.Value<string>("NotDr") + "";
                    if (st.IndexOf("Sign") < 0)
                        datt.NotOr = x.Value<string>("NotDr");
                    datt.NotDr = "{UserLogin}" + " Sign";
                    datt.NotD1 = "";
                    //datt.EmpId = x.Value<string>("EmpId");
                    //datt.AttDt = x.Value<DateTime>("AttDt");
                    for (int j = 1; j <= 5; j++)
                    {
                        T_String.SetPropValue(datt, "Onn" + j.ToString("00"), x.Value<int>("Onn" + j.ToString("00")));
                        T_String.SetPropValue(datt, "Off" + j.ToString("00"), x.Value<int>("Off" + j.ToString("00")));
                    }
                    _db.SaveChanges();
                    l.Add(datt);
                }
                // Do something
            }

            ArrayList a = new ArrayList();

            var rsTypeShift = _db.Tbltypeshift.ToList();

            int dem = 0/*, i = 0;*/;
            for (int i = 0; i < l.Count; i++)
            {
                string EMP_ID = l[i].EmpId + "";
                DateTime d1 = DateTime.Parse(l[i].AttDt + "");
                string SHI_ID = l[i].ShiId + "";
                var rsca = _db.Tbldetailsroster.Where(x => x.ShiId == SHI_ID).OrderBy(x => x.SeqNo).ToList();
                ArrayList Ca = new ArrayList();
                ArrayList ATT = new ArrayList();
                for (int j = 0; j < rsca.Count(); j++)
                {
                    Ca.Add(rsca[j].OnnTm);
                    Ca.Add(rsca[j].OffTm);
                }

                Ca.Add(0);
                Ca.Add(0);
                Ca.Add(0);
                Ca.Add(0);
                for (int j = 1; j <= 5; j++)
                {
                    ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(l[i], "Onn" + j.ToString("00")) + ""));
                    ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(l[i], "Off" + j.ToString("00")) + ""));
                }
                AttendanceHelper.Attendance_Calc(EMP_ID, d1.ToString("yyyy/MM/dd"), null, Ca, ATT, SHI_ID, rsca, null, rsTypeShift, "TBLDETAILSATTENDANCE", l[i].NotDr + "");
                dem++;
            }
            return View();
        }

        [HttpPost]
        public IActionResult CalDailyAttendance(DailyAttendanceEditViewModel model)
        {
            //var r = Request;
            var err = "";
            try {
                QLNhaHangContext _db = new QLNhaHangContext();
                List<Tbldetailsattendance> l = new List<Tbldetailsattendance>();
                //using (var reader = new StreamReader(Request.Body))
                //{
                //var body = reader.ReadToEnd();
                //var _obj = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(body);
                //foreach (var x in _obj)
                //{
                var datt = _db.Tbldetailsattendance.Where(z => z.EmpId == model.EMP_ID && z.AttDt == model.ATT_DT).FirstOrDefault();
                string st = model.NOT_DR + "";
                if (st.IndexOf("Sign") < 0)
                    datt.NotOr = model.NOT_DR;
                datt.NotDr = "{UserLogin}" + " Sign";
                datt.NotD1 = "";
                //datt.EmpId = x.Value<string>("EmpId");
                //datt.AttDt = x.Value<DateTime>("AttDt");
                for (int j = 1; j <= 5; j++)
                {
                    var _onn = (T_String.GetPropValue(model, "ONN_" + j.ToString("00")) + "").Replace(":", "");
                    var _off = (T_String.GetPropValue(model, "OFF_" + j.ToString("00")) + "").Replace(":", "");
                    T_String.SetPropValue(datt, "Onn" + j.ToString("00"), _onn == "" ? "0" : _onn);
                    T_String.SetPropValue(datt, "Off" + j.ToString("00"), _off == "" ? "0" : _off);
                }
                _db.SaveChanges();
                l.Add(datt);
                //}
                // Do something
                //}

                ArrayList a = new ArrayList();

                var rsTypeShift = _db.Tbltypeshift.ToList();

                int dem = 0/*, i = 0;*/;
                for (int i = 0; i < l.Count; i++)
                {
                    string EMP_ID = l[i].EmpId + "";
                    DateTime d1 = DateTime.Parse(l[i].AttDt + "");
                    string SHI_ID = l[i].ShiId + "";
                    var rsca = _db.Tbldetailsroster.Where(x => x.ShiId == SHI_ID).OrderBy(x => x.SeqNo).ToList();
                    ArrayList Ca = new ArrayList();
                    ArrayList ATT = new ArrayList();
                    for (int j = 0; j < rsca.Count(); j++)
                    {
                        Ca.Add(rsca[j].OnnTm);
                        Ca.Add(rsca[j].OffTm);
                    }

                    Ca.Add(0);
                    Ca.Add(0);
                    Ca.Add(0);
                    Ca.Add(0);
                    for (int j = 1; j <= 5; j++)
                    {
                        ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(l[i], "Onn" + j.ToString("00")) + ""));
                        ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(l[i], "Off" + j.ToString("00")) + ""));
                    }
                    AttendanceHelper.Attendance_Calc(EMP_ID, d1.ToString("yyyy/MM/dd"), null, Ca, ATT, SHI_ID, rsca, null, rsTypeShift, "TBLDETAILSATTENDANCE", l[i].NotDr + "");
                    dem++;
                }
            } catch (Exception ex) {
                err += ex.Message + " - " + ex.StackTrace;
            }

            return Json(err);
        }

        [HttpPost]
        public IActionResult AddDailyAttendance(DailyAttendanceAddViewModel model)
        {
            var err = "";
            try {
                AttendanceHelper attHelper = new AttendanceHelper();
                attHelper.AddDetailsAttendanceByHand(model.EMP_ID, model.ATT_DT, int.Parse(model.ONN_01.Replace(":", "") + T_String.GetMilisecondRandom()), int.Parse(model.OFF_01.Replace(":", "") + T_String.GetMilisecondRandom()));
                err += attHelper.err;
                return Json(err);
            } catch (Exception ex) {
                err += ex.Message + " - " + ex.StackTrace;
            }
            return Json(err);
        }

        [HttpPost]
        public IActionResult TransferDailyAttendanceFromCardData(DateTime ATT_DT,string EMP_ID)
        {
            //var err = "";
            //try
            //{
            //    AttendanceHelper attHelper = new AttendanceHelper();
            //    attHelper.AddDetailsAttendanceByHand(model.EMP_ID, model.ATT_DT, int.Parse(model.ONN_01.Replace(":", "") + T_String.GetMilisecondRandom()), int.Parse(model.OFF_01.Replace(":", "") + T_String.GetMilisecondRandom()));
            //    err += attHelper.err;
            //    return Json(err);
            //}
            //catch (Exception ex)
            //{
            //    err += ex.Message + " - " + ex.StackTrace;
            //}
            //return Json(err);
            string err = "";
            CardDataSwitchHelper cSwHelper = new CardDataSwitchHelper()
            {
                dt1 = ATT_DT,
                dt2 = ATT_DT,
                crtCondition1 = new Areas.Admin.Models
                .CommonViewModel
                .CrtConditionViewModel()
                { R_WID = true, Text_Fr = EMP_ID, Text_To = EMP_ID, R_Par = true }
            };
            cSwHelper.Transfer();
            err = cSwHelper.err;
            return Json(err);
        }

    }
}