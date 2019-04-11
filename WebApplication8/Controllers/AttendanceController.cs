using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication8.Helper;
using DAL.QLNHangData;

namespace WebApplication8.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DailyAttendanceList()
        {
            return View();
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
                foreach (var x in _obj) {
                    var datt = _db.Tbldetailsattendance.Where(z=>z.EmpId == x.Value<string>("EmpId") && z.AttDt == x.Value<DateTime>("AttDt")).FirstOrDefault();
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

    }
}