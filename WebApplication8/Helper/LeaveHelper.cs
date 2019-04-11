using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Admin.Models.LeaveViewModel;
using DAL.QLNHangData;

namespace WebApplication8.Helper
{
    public class LeaveHelper
    {
        public string dateFormat { set; get; }
        public int LEA_SEQ;
        public string EMP_ID = "", INH_DT = "", TYP_ID = "";
        public string USER_ID = "";
        public DateTime STR_DT, END_DT;    //Dùng cho trường hợp cập nhật phép
        public string[] arrAL= new string[] { };
        public bool ck;
        public DateTime dt1,dt2,dt3,dt4;

        public string txt_h, txt_day,txt_hr, txt_h1, txt_note, txt_ht;
        public string cb1, cb;
        public string err { set; get; }

        public LeaveHelper(LeaveOpViewModel model) {
            cb1 = model.ucLeave.SHI_ID;
            ck = model.ucLeave.FULL_DT_BT;
            dt1 = model.ucLeave.STR_DT;
            dt2 = model.ucLeave.END_DT;
            dt3 = model.ucLeave.STR_TM != null ?  DateTime.ParseExact(model.ucLeave.STR_TM, "HH:mm", CultureInfo.InvariantCulture): DateTime.Now;
            dt4 = model.ucLeave.END_TM != null ? DateTime.ParseExact(model.ucLeave.END_TM, "HH:mm", CultureInfo.InvariantCulture) : DateTime.Now;
            txt_hr = model.ucLeave.TOTAL_HOURS;
            txt_day = model.ucLeave.TOTAL_DAYS;
            txt_h1 = model.ucLeave.HOU_DY == null ? "0": model.ucLeave.HOU_DY;
            txt_h = model.ucLeave.HOU_DY == null ? "0" : model.ucLeave.HOU_DY;
            EMP_ID = model.EmpId;
            TYP_ID = model.ucLeave.TYP_LEA;
            INH_DT = model.InhDt;
            USER_ID = model.UserLogin;
            txt_note = model.ucLeave.NOT;
            cb = model.ucLeave.TYP_LEA;
            LEA_SEQ = model.SeqNo;
            STR_DT = model.ucLeave.STR_DT_O;
            END_DT = model.ucLeave.END_DT_O;
        }

        public LeaveHelper() {

        }
        private void cal()
        {
            try
            {
                //if (vs1 != null && vs1.Row > 0)
                //    EMP_ID = vs1.Rows[vs1.Row]["EMP_ID"] + "";

                //if (dt1.Value.Year != dt2.Value.Year)
                //{
                //    dt4.Focus();
                //    MessageBox.Show(PublicFunction.L_Get_Msg("msg", 198));
                //}

                //if (dt1.Value > dt2.Value)
                //{
                //    dt4.Focus();
                //    MessageBox.Show(PublicFunction.L_Get_Msg("msg", 17));
                //}

                if (ck)//tinh theo ngay
                    ByDay();
                else
                    ByHour();
            }
            catch (Exception) { };
        }
        private void ByDay()
        {
            try
            {
                double day;

                if (EMP_ID != "")
                {
                    day = T_String.DT_GetDays(dt1, dt2, EMP_ID);
                    //txt_h.Text = T_String.Shift_WorkHour(EMP_ID, dt1.Value) + "";

                    if (day >= 1 && txt_h == "0")
                        txt_h = "8";
                }
                else
                    day = T_String.DT_GetDays(dt1, dt2, EMP_ID);

                txt_day = day + "";

                //NhuY: 2015/11/27
                //txt_hr.Text = T_String.IsNullTo00(day*T_String.IsNullTo00(txt_h.Text)+"").ToString("#,##0.##");
                txt_hr = txt_hr = T_String.IsNullTo00(day * 8.0 + "") + "";
                //				if (T_String.IsNullTo00(txt_h.Text) > T_String.IsNullTo00(txt_hr.Text))
                //					txt_h.Text = txt_hr.Text;
            }
            catch (Exception ex) { };
        }

        private void ByHour()
        {
            try
            {
                DateTime d1 = dt1;
                DateTime d2 = dt2;

                string SHI_ID = cb1 + "";
                if (SHI_ID == "")
                    SHI_ID = T_String.GetDataFromSQL("DAY_" + d1.Day.ToString("00"), "TBLMONTHSHIFT", "EMP_ID=N'" + EMP_ID + "'"
                        + " AND YYY_MM='" + d1.ToString("yyyyMM") + "'");

                double hour = 0;
                int tmstart = int.Parse(dt3.ToString("HHmm") + "");
                int tmend = int.Parse(dt4.ToString("HHmm") + "");

                int[] arr = GetShiftTimeArray(SHI_ID);

                for (int i = 0; i < arr.Length; i += 2)
                {
                    if (tmend < arr[i]) break;

                    if (tmstart <= arr[i])
                    {
                        tmstart = arr[i];
                    }

                    else if (tmstart >= arr[i + 1])
                        continue;

                    if (tmend > arr[i] && tmend <= arr[i + 1])
                        hour += TmHourSubToFloat(tmstart, tmend);
                    else if (tmend > arr[i + 1])
                    {
                        //arH.Add(arr[i + 1]);
                        hour += TmHourSubToFloat(tmstart, arr[i + 1]);
                        tmstart = arr[i + 1];
                    }
                }

                txt_h1 = hour + "";
                txt_hr = hour + "";

                if (T_String.IsNullTo00(txt_h1) == 0.0)
                    txt_day = "0";

                //NhuY 2015/11/27: Sửa cho Regina, mặc định giờ công 1 ngày 8 tiếng
                txt_day = T_String.IsNullTo00((1 * (T_String.IsNullTo00(txt_h1) / 8.0)).ToString("N", new CultureInfo("en-US")) + "").ToString("#,##0.##");
            }
            catch (Exception) { };
        }

        public int[] GetShiftTimeArray(string SHI_ID)
        {
            RecordSet rsS = new RecordSet("SELECT *FROM TBLDETAILSROSTER WHERE SHI_ID='" + SHI_ID
                + "' AND (TYP_ID='ATT_HR' OR TYP_ID='NIG_HR') ORDER BY SEQ_NO", PublicFunction.C_con);

            int[] arr = new int[rsS.rows * 2];
            for (int i = 0; i < rsS.rows; i++)
            {
                int timeIn = int.Parse(rsS.record(i, "ONN_TM") + "");
                int timeOut = int.Parse(rsS.record(i, "OFF_TM") + "");
                int preOut = (i > 0 ? arr[i * 2 - 1] : 0);

                arr[i * 2] = (timeIn >= preOut ? timeIn : timeIn + 2400);
                arr[i * 2 + 1] = (timeOut >= arr[i * 2] ? timeOut : timeOut + 2400);
            }

            return arr;
        }

        public double TmHourSubToFloat(int hour1, int hour2)
        {
            if (hour1 > hour2)
                hour2 += 2400;

            return TmHourToFloat(hour2) - TmHourToFloat(hour1);
        }

        public double TmHourToFloat(int hour)
        {
            return hour / 100 + (hour % 100) / 60.0;
        }

        private bool Duplicate()
        {
            string sql = "";

            if (ck)
            {
                //				sql = "((STR_DT<='" + dt1.Value.ToString("yyyy/MM/dd") + "' and "
                //					+ " END_DT>='" + dt1.Value.ToString("yyyy/MM/dd") + "')";
                //				sql += " or (STR_DT<='" + dt2.Value.ToString("yyyy/MM/dd") + "' and "
                //					+ " END_DT>='" + dt2.Value.ToString("yyyy/MM/dd") + "'))";
                sql = "(STR_DT BETWEEN '" + dt1.ToString("yyyy/MM/dd") + "' AND '" + dt2.ToString("yyyy/MM/dd") + "'"
                    + " OR END_DT BETWEEN '" + dt1.ToString("yyyy/MM/dd") + "' AND '" + dt2.ToString("yyyy/MM/dd") + "'"
                    + " OR '" + dt1.ToString("yyyy/MM/dd") + "' BETWEEN STR_DT AND END_DT"
                    + " OR '" + dt2.ToString("yyyy/MM/dd") + "' BETWEEN STR_DT AND END_DT)"
                    + " AND EMP_ID=N'" + EMP_ID + "'";

                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                if (T_String.SqlExists(PublicFunction.C_con, "TBLLEAVE", sql))
                    return true;
            }
            else
            {
                sql += "EMP_ID=N'" + EMP_ID + "' AND '@DT' BETWEEN STR_DT AND END_DT AND"
                    + " (DAY_BT=1 OR @STR_TM >= STR_TM AND @STR_TM < END_TM"
                    + " OR @END_TM > STR_TM AND @END_TM <= END_TM"
                    + " OR STR_TM >= @STR_TM AND STR_TM < @END_TM"
                    + " OR END_TM > @STR_TM AND END_TM <= @END_TM)";

                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                sql = sql.Replace("@DT", dt1.ToString("yyyy/MM/dd")).Replace("@STR_TM", dt3.ToString("HHmm")).Replace("@END_TM", dt4.ToString("HHmm"));

                if (T_String.SqlExists(PublicFunction.C_con, "TBLLEAVE", sql))
                    return true;
            }

            return false;
        }

        private Boolean CheckPhep(string EMP_ID, string LEA_ID, Double xinnghi)
        {
            string sql = "";
            sql = "Select * from TBLTYPELEAVE where LEA_ID=N'" + LEA_ID + "'";
            RecordSet rs = new RecordSet(sql, PublicFunction.C_con);
            if (rs.rows <= 0)
                return false;
            double tm = T_String.IsNullTo00(rs.record(0, "DAY_TM")); // Max Times
            if (tm > 0)
            {
                sql = "EMP_ID=N'" + EMP_ID + "' and LEA_ID=N'" + LEA_ID + "'";
                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                double day = T_String.IsNullTo00(T_String.GetDataFromSQL("Count(*)", "TBLLEAVE", sql));
                if (day + 1 > tm)
                {
                    //MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 100)
                    //    + tm + ". ");
                    return false;
                }
            }
            tm = T_String.IsNullTo00(rs.record(0, "DAY_QT")); // Max days
            if (tm > 0)
            {
                sql = "EMP_ID=N'" + EMP_ID + "' and LEA_ID=N'" + LEA_ID + "'";
                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                double day = T_String.IsNullTo00(T_String.GetDataFromSQL("SUM(DAY_TT)", "TBLLEAVE", sql));
                if (day + xinnghi > tm)
                {
                    //MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 56)
                    //    + tm + ". ");
                    return false;
                }
            }

            tm = T_String.IsNullTo00(rs.record(0, "DAY_MM")); // Max month
            if (tm > 0)
            {
                DateTime d1 = new DateTime(dt1.Year, dt1.Month, 1);
                DateTime d2 = new DateTime(dt1.Year, dt1.Month, DateTime.DaysInMonth(dt1.Year, dt1.Month));

                sql = "EMP_ID=N'" + EMP_ID + "' and LEA_ID=N'" + LEA_ID + "' and (STR_DT Between '" +
                    d1.ToString("yyyy/MM/dd") + " 00:00' and '" + d2.ToString("yyyy/MM/dd") + " 23:59')";
                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                double day = T_String.IsNullTo00(T_String.GetDataFromSQL("SUM(DAY_TT)", "TBLLEAVE", sql));
                if (day + xinnghi > tm)
                {
                    //MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 57)
                    //    + tm + ". ");
                    return false;
                }
            }

            tm = T_String.IsNullTo00(rs.record(0, "DAY_YY")); // Max Years
            if (tm > 0)
            {
                DateTime d1 = new DateTime(dt1.Year, 1, 1);
                DateTime d2 = new DateTime(dt1.Year, 12, DateTime.DaysInMonth(dt1.Year, 12));
                sql = "EMP_ID=N'" + EMP_ID + "' and LEA_ID=N'" + LEA_ID + "' and (STR_DT Between '" +
                    d1.ToString("yyyy/MM/dd") + " 00:00' and '" + d2.ToString("yyyy/MM/dd") + " 23:59')";
                if (LEA_SEQ > 0) sql += " AND SEQ_NO<>" + LEA_SEQ;

                double day = T_String.IsNullTo00(T_String.GetDataFromSQL("SUM(DAY_TT)", "TBLLEAVE", sql));
                if (day + xinnghi > tm)
                {
                    //MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 58)
                    //    + tm + ". ");
                    return false;
                }
            }

            return true;
        }

        public void Leave_Insert()
        {
            DateTime dt = DateTime.Now;
            if (cb + "" == "")
            {
                //MessageBox.Show(PublicFunction.L_Get_Msg("msg", 19));
                return;
            }
            if (!ck && (dt4.ToString("HHmm") + "" == "" || dt3.ToString("HHmm") + "" == ""))
            {
                //MessageBox.Show(PublicFunction.L_Get_Msg("msg", 191));
                return;
            }
            string sql1 = "";
            var _con = new SqlConnection(PublicFunction.connectionString);
            _con.Open();
            SqlTransaction tran = _con.BeginTransaction();
            try
            {
                string sql = "";
                //vs1.Row = i;
                EMP_ID = /*vs1.Rows[i]["EMP_ID"]*/ EMP_ID + "";
                INH_DT = (DateTime.ParseExact(INH_DT,"MM/dd/yyyy", CultureInfo.InvariantCulture)).ToString("yyyy/MM/dd");
                TYP_ID = TYP_ID + "";

                if (!Duplicate())   //Kiểm tra trùng ngày nghỉ phép
                {
                    string SEQ_NO = T_String.GetMax("MAX(SEQ_NO)", "TBLLEAVE") + "";

                    int c = 0;
                    if (ck)
                        c = 1;

                    cal();

                    DateTime dtt = dt2;
                    //NhuY: xet nam tinh fep nam
                    string YYY = dtt.Year + "";
                    int iCloseDay = /*T_String.IsNullTo0(PublicFunction.GetOption("DAYCLOSE"))*/ 1;
                    if (iCloseDay <= 0) iCloseDay = 1;
                    if (iCloseDay > 15 && dtt.Day >= iCloseDay && dtt.Month == 12)
                        YYY = (dtt.Year + 1) + "";
                    //NhuY

                    if (!Overflow(INH_DT, dtt, YYY))
                    {
                        sql = "Insert Into TBLLEAVE(SEQ_NO,EMP_ID,STR_DT,END_DT,STR_TM,END_TM,HOU_DY,HOU_TT,LEA_ID,"
                            + "DAY_TT,DAY_BT,NOT_DR,BLT_NM,BLT_DT) values("
                            + SEQ_NO + ","
                            + "N'" + EMP_ID + "',"
                            + "'" + dt1.ToString("yyyy/MM/dd") + "',"
                            + "'" + dt2.ToString("yyyy/MM/dd") + "',";

                        if (ck)
                        {
                            sql += "Default,"
                                + "Default,";
                            sql += "'" + txt_h + "',";
                        }
                        else
                        {
                            sql += "'" + dt3.ToString("HHmm") + "',"
                                + "'" + dt4.ToString("HHmm") + "',";
                            sql += "'" + txt_h1 + "',";
                        }

                        sql += "'" + T_String.IsNullTo00(txt_hr) + "',"
                            + "N'" + cb + "',"
                            + "'" + T_String.IsNullTo00(txt_day) + "',"
                            + "'" + c + "',"
                            + "N'" + txt_note + "',N'" + USER_ID + "','" + dt.ToString("yyyy/MM/dd HH:mm") + "')";
                        SqlCommand cmd = new SqlCommand(sql, _con, tran);
                        cmd.ExecuteNonQuery();

                        //if (IsAnnualLeave(cb.SelectedValue + "")) //update ngay phep nam
                        //{
                        //    if (T_String.IsNullTo0(T_String.GetDataFromSQL("Count(*)", "FILC04B", "EMP_ID=N'" + EMP_ID + "' and YYY_YY=N'" + ((DateTime)dt1.Value).ToString("yyyy") + "'")) <= 0)
                        //    {
                        //        sql = "Insert Into FILC04B(YYY_YY,EMP_ID,BLT_NM,BLT_DT) values (N'"
                        //            + ((DateTime)dt1.Value).ToString("yyyy") + "',N'" + EMP_ID + "',N'" + PublicFunction.A_UserID + "','" + dt.ToString("yyyy/MM/dd HH:mm") + "')";
                        //        cmd = new SqlCommand(sql, con, tran);
                        //        cmd.ExecuteNonQuery();
                        //    }

                        //    //NhuY: sua tr/hop ngay ket ko la ngay 1
                        //    if (PublicFunction.dayClose <= 15)
                        //    {
                        //        sql = "EMP_ID=N'" + EMP_ID + "' and "
                        //            + "YEAR(STR_DT)='" + YYY + "' and "
                        //            + "YEAR(END_DT)='" + YYY + "'";
                        //    }
                        //    else
                        //    {
                        //        sql = "EMP_ID=N'" + EMP_ID + "' AND STR_DT>='" + (int.Parse(YYY) - 1) + "/12/" + PublicFunction.dayClose
                        //            + "' AND END_DT<'" + YYY + "/12/" + PublicFunction.dayClose + "'";
                        //    }

                        //    sql = "Update FILC04B set DID_QT=(Select SUM(DAY_TT) from FILC04A where " + sql
                        //        + ") where EMP_ID=N'" + EMP_ID + "' and YYY_YY=N'" + YYY + "'";

                        //    cmd = new SqlCommand(sql, con, tran);
                        //    cmd.ExecuteNonQuery();
                        //    //cmd = new SqlCommand(CalStaffDaNghi(EMP_ID, dtt, INH_DT), con, tran);
                        //    //cmd.ExecuteNonQuery();
                        //}

                        if (sql1 != "") sql1 += ",";
                        sql1 += "N'" + EMP_ID + "'";
                        //vs1.RemoveItem(i);
                        tran.Commit();

                        //Tiến hành chuyển dữ liệu chấm công
                        Leave_Attendance_Cal(EMP_ID, dt1, dt2, null);
                    }
                    else
                    {
                        //							if(IsAnnualLeave(cb.SelectedValue+"") && PublicFunction.CUS_ID != "100")
                        //								MessageBox.Show(EMP_ID+" "+ PublicFunction.L_Get_Msg("msg",55)
                        //									+GetNgayPhepNam(EMP_ID,((DateTime)dt1.Value).ToString("yyyy"))+". ");
                        tran.Rollback();
                    }
                }
                else
                {
                    //MessageBox.Show(vs1.Rows[i]["EMP_ID"] + " " + PublicFunction.L_Get_Msg("msg", 20));
                    err += " Lỗi thêm cho nhân viên " + EMP_ID;
                    tran.Rollback();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch { }
                err = err + " " + ex.Message + " - " + ex.StackTrace;
                //MessageBox.Show(ex.Message);
            }

            _con.Close();
        }

        public void Leave_Update()
        {
            string sql = "";
            DateTime dt = DateTime.Now;

            if (cb + "" == "")
            {
                //MessageBox.Show(PublicFunction.L_Get_Msg("msg", 19));
                err += "Trống lý do";
                return;
            }

            if (!ck && (dt4 + "" == "" || dt3 + "" == ""))
            {
                //MessageBox.Show(PublicFunction.L_Get_Msg("msg", 191));
                err += "Chưa chọn giờ bắt đầu kết thúc";
                return;
            }

            var con = new SqlConnection(PublicFunction.connectionString);
            con.Open();

            if (!Duplicate())   //Kiểm tra trùng ngày nghỉ phép
            {
                cal();
                DateTime dtt = dt2;

                string YYY = dtt.Year + "";
                int iCloseDay = /*T_String.IsNullTo0(PublicFunction.GetOption("DAYCLOSE"));*/ 1;
                if (iCloseDay <= 0) iCloseDay = 1;
                if (iCloseDay > 15 && dtt.Day >= iCloseDay && dtt.Month == 12)
                    YYY = (dtt.Year + 1) + "";

                if (!Overflow(INH_DT, dtt, YYY))
                {
                    sql = "UPDATE TBLLEAVE SET STR_DT='" + dt1.ToString("yyyy/MM/dd") + "',"
                        + " END_DT='" + dt2.ToString("yyyy/MM/dd") + "',"
                        + " HOU_TT=" + T_String.IsNullTo00(txt_hr) + ", LEA_ID='" + cb + "',"
                        + " DAY_TT=" + T_String.IsNullTo00(txt_day) + ", DAY_BT='" + ck + "',"
                        + " NOT_DR=N'" + txt_note + "', LST_NM=N'" + USER_ID + "',"
                        + " LST_DT='" + dt.ToString("yyyy/MM/dd HH:mm:ss") + "',";

                    if (ck)
                        sql += " STR_TM=null, END_TM=null, HOU_DY='" + txt_h + "'";
                    else
                        sql += " STR_TM=" + dt3.ToString("HHmm") + ", END_TM=" + dt4 + ", HOU_DY='" + txt_h1 + "'";

                    sql += " WHERE SEQ_NO=" + LEA_SEQ;

                    new SqlCommand(sql, con).ExecuteNonQuery();

                    //Tính lại chấm công (Tạm thời không tính lại phép năm)
                    Leave_Attendance_Cal(EMP_ID, STR_DT, END_DT, dt1, dt2, null);

                    con.Close();
                    con.Dispose();

                    //parent.DialogResult = DialogResult.OK;
                }
                else
                {
                    //if (IsAnnualLeave(cb.SelectedValue + ""))
                    //    MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 55)
                    //        + GetNgayPhepNam(EMP_ID, dt1.Value.ToString("yyyy")) + ". ");
                }
            }
            else
                //MessageBox.Show(EMP_ID + " " + PublicFunction.L_Get_Msg("msg", 20));
                err += "Lỗi cập nhật nghỉ phép cho nhân viên " + EMP_ID;

            con.Close();
            con.Dispose();
        }
        public void Leave_Attendance_Cal(string EMP_ID, DateTime date1, DateTime date2, SqlConnection con)
        {
            //Tạm thời chỉ tính cho Primacy, Bowker
            //if (PublicFunction.CUS_ID == "99" || PublicFunction.CUS_ID == "100")
            {
                DateTime date = date1;

                while (date <= date2 && date <= DateTime.Today)
                {
                    AttendanceHelper.Attendance_Calc(EMP_ID, date.ToString("yyyy/MM/dd"), con, "TBLDETAILSATTENDANCE");
                    date = date.AddDays(1);
                }
            }
        }

        public void Leave_Attendance_Cal(string EMP_ID, DateTime dtO1, DateTime dtO2, DateTime dtN1, DateTime dtN2, SqlConnection con)
        {
            DateTime dtMin = dtO1, dtMax = dtO1;
            if (dtMin > dtO2) dtMin = dtO2;
            if (dtMin > dtN1) dtMin = dtN1;
            if (dtMin > dtN2) dtMin = dtN2;

            if (dtMax < dtO2) dtMax = dtO2;
            if (dtMax < dtN1) dtMax = dtN1;
            if (dtMax < dtN2) dtMax = dtN2;

            DateTime date = dtMin;
            while (date <= dtMax && date <= DateTime.Today)
            {
                if (date >= dtO1 && date <= dtO2 || date >= dtN1 && date <= dtN2)
                    AttendanceHelper.Attendance_Calc(EMP_ID, date.ToString("yyyy/MM/dd"), con, "TBLDETAILSATTENDANCE");

                date = date.AddDays(1);
            }
        }

        private bool Overflow(string INH_DT, DateTime dtt, string YYY)
        {
            //if (IsAnnualLeave(cb.SelectedValue + "")) //Tính lại phép năm
            //{
            //    //Trường hợp này xin < ngày hiện tại
            //    PublicFunction.SQL_Execute("EXEC SP_AnnualLeaveCal N'" + EMP_ID + "', '" + dtt.ToString("yyyy/MM/dd") + "'", PublicFunction.C_con);

            //    if (!CheckPhepNam(EMP_ID, YYY, T_String.IsNullTo00(txt_day.Text)))
            //    {
            //        return true;
            //    }
            //}

            if (!CheckPhep(EMP_ID, cb + "", T_String.IsNullTo00(txt_day))) // phep thuong
                return true;

            return false;
        }

        public void dt1_ValueChanged()
        {
            //if (dt1.Value > dt2.Value || (cb1.SelectedValue+"" != "" && !ck.Checked))
            if (dt1 > dt2 || !ck)
                dt2 = dt1;
            cal();
        }

        public void LeaveDelete(Tblleave model) {
            try {
                string EMP_ID = model.EmpId;
                DateTime ddt1 = model.StrDt.Value;
                DateTime ddt2 = model.EndDt.Value;

                using (SqlConnection con = new SqlConnection(PublicFunction.connectionString))
                {
                    con.Open();
                    string sql = "delete from TBLLEAVE where EMP_ID = '" + model.EmpId + "' and SEQ_NO = '" + model.SeqNo + "'";
                    PublicFunction.SQL_Execute(sql, con);
                }
                Leave_Attendance_Cal(EMP_ID, ddt1, ddt2, null);
            } catch (Exception ex) {
                err = err + " " + ex.Message + " - " + ex.StackTrace;
            }
            
        }

        public void cb1_SelectedValueChanged()
        {
            Double h = 0;
            string sql = "Select * from TBLDETAILSROSTER where SHI_ID=N'" + cb1 + "'";
            RecordSet rs = new RecordSet(sql, PublicFunction.C_con);
            for (int i = 0; i < rs.rows; i++)
            {
                double on = T_String.IsNullTo00(rs.record(i, "ONN_TM"));
                double off = T_String.IsNullTo00(rs.record(i, "OFF_TM"));
                if (on > off)
                {
                    off = off + 2400;
                }
                if (rs.record(i, "TYP_ID") + "" == "ATT_HR" || rs.record(i, "TYP_ID") + "" == "NIG_HR")
                    h = T_String.CongTG(T_String.TruTG(off, on), h);
            }
            if (h <= 0)
                h = 8;
            else
                txt_h = T_String.DT_HourMinConvertToHour((int)h).ToString("#,##0.##");
            cal();
        }

        public void dt3_ValueChanged()
        {
            if (dt3.ToString("HH:mm") != "" && dt4.ToString("HH:mm") != "")
            {
                double tam = T_String.TruTG(T_String.IsNullTo00(dt4.ToString("HH:mm").Replace(":","")), T_String.IsNullTo00(dt3.ToString("HH:mm").Replace(":","")));
                txt_h1 = T_String.IsNullTo00((((int)tam / 100) + ((tam % 100) / 60)).ToString("N", new CultureInfo("en-US")) + "").ToString("#,##0.##");
            }
            cal();
        }

    }
}
