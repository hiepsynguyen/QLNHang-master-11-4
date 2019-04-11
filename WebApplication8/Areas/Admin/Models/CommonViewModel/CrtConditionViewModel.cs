using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.CommonViewModel
{
    public class CrtConditionViewModel
    {
        public string EMP_ID { set; get; }
        public bool R_ALL { set; get; }
        public bool R_Par { set; get; }
        public bool ck { set; get; }
        public string Text_Fr { set; get; }
        public string Text_To { set; get; }
        public bool R_WID { set; get; }
        public string CB_DEP { set; get; }
        public bool R_DEP { set; get; }

        public string GetWhere(string table, Boolean vacate)
        {
            string wh = "", tb = table;
            if (tb != "")
                tb = tb + ".";
            if (R_ALL)
            {
                wh = "(1=1)";
            }
            else
            {
                if (R_DEP)
                {
                    wh = tb + "DEP_ID=N'" + CB_DEP + "'";

                }
                if (R_WID)
                {
                    if (ck)
                    {
                        wh = "(" + tb + "EMP_I1 Between N'" + Text_Fr + "' and N'" + Text_To + "')";
                    }
                    else
                    {
                        wh = "(" + tb + "EMP_ID Between N'" + Text_Fr + "' and N'" + Text_To + "')";
                        //							if(System.Windows.Forms==frmTaCalAnnualLeave)
                        //								wh.Replace("EMP_ID", "a.EMP_ID");//
                    }
                }
            }
            //wh += " and (DEL_BT is null Or DEL_BT=0)";
            ////if (vacate)
            ////    wh += " and (VAC_BT is null Or VAC_BT=0) ";
            ////wh += " and " + tb + "DEP_ID in (Select DEP_ID  from SYS_SECURITY_DEP" +
            ////        " where MNU_ID=" + this.Tag + " and ALL_BT=1 and USER_ID=N'"
            ////    + PublicFunction.A_UserID + "') and " + PublicFunction.Get_TYP(this.Tag, "");
            return wh;
        }
    }
}
