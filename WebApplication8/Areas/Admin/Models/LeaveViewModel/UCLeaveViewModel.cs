using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Models.LeaveViewModel
{
    public class UCLeaveViewModel
    {
        [DataType(DataType.Date)]
        [DisplayName("Từ ngày")]
        public DateTime STR_DT { set; get; }
        [DisplayName("đến ngày")]
        [DataType(DataType.Date)]
        public DateTime END_DT { set; get; }

        public DateTime STR_DT_O { set; get; }
        public DateTime END_DT_O { set; get; }

        public string TYP_LEA { set; get; }
        public bool FULL_DT_BT { set; get; }
        public string SHI_ID { set; get; }
        [DisplayName("Bắt đầu")]
        public string STR_TM { set; get; }
        [DisplayName("Kết thúc")]
        public string END_TM { set; get; }
        public string TOTAL_HOURS { set; get; }
        public string TOTAL_DAYS { set; get; }

        public string HR_P_SHI { set; get; }
        public string HOU_DY { set; get; }
        public string NOT { set; get; }

        public UCLeaveViewModel() { }

        public UCLeaveViewModel(Tblleave model) {
            STR_DT = model.StrDt.Value;
            END_DT = model.EndDt.Value;
            STR_TM = model.StrTm == null ? "": model.StrTm.Value + "";
            END_TM = model.EndTm == null ? "": model.EndTm.Value + "";
            TYP_LEA = model.LeaId;
            FULL_DT_BT = model.DayBt.Value;
            SHI_ID = "";
            TOTAL_HOURS = model.HouTt.Value + "";
            TOTAL_DAYS = model.DayTt.Value + "";
            STR_DT_O = model.StrDt.Value;
            END_DT_O = model.EndDt.Value;
            NOT = model.NotDr;
        }
    }
}
