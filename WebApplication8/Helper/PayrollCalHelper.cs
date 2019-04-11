using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Admin.Models.CommonViewModel;

namespace WebApplication8.Helper
{
    public class PayrollCalHelper
    {
        int sleep;
        private string TBLMONTHATTENDANCE;
        private RecordSet rs_LCB;
        private SqlConnection con1;
        public DateTime dt1, dt2, dt3;
        public string err = "";
        public CrtConditionViewModel crtCondition1;
        public bool ckVac = false;
        public bool r1 = false, r2 = true;


        public PayrollCalHelper(DateTime dt1,DateTime dt2,DateTime dt3, CrtConditionViewModel crt) {
            TBLMONTHATTENDANCE = "TBLMONTHATTENDANCE";
            this.dt1 = dt1;
            this.dt2 = dt2;
            this.dt3 = dt3;
            crtCondition1 = crt;
        }

        public void CalFinalSalary() {
            Transfer();
            Transfer1();
        }

        public void LCB(string EMP_ID, string YYY_MM, int SEQ_NO, SqlConnection con1)
        {
            string sql = "";
            RecordSet rs;
            sql = "Select * from TBLSALARY where  (DON_AP=0 OR DON_AP is null) and EMP_ID=N'" + EMP_ID + "' "
                + " and (CHA_DT>'" + dt1.ToString("yyyy/MM/dd") + "' and CHA_DT<='"
                + dt2.ToString("yyyy/MM/dd") + "')";
            if (SEQ_NO == 4 || SEQ_NO == 3) // luong thay doi trong thang
            {
                if (SEQ_NO == 4)
                {
                    sql += " ORDER BY CHA_DT desc";
                    rs = new RecordSet(sql, con1);
                }
                else
                {
                    sql = "Select * from TBLSALARY where  (DON_AP=0 OR DON_AP is null) and EMP_ID=N'" + EMP_ID + "' "
                        + " and   CHA_DT<='"
                        + dt2.ToString("yyyy/MM/dd") + "'";
                    sql += " ORDER BY CHA_DT desc";
                    rs = new RecordSet(sql, con1);
                }
                if (rs.rows < 0)
                {
                    sql = "Select * from TBLSALARY where  (DON_AP=0 OR DON_AP is null) and EMP_ID=N'" + EMP_ID + "' ORDER BY CHA_DT desc";
                    rs = new RecordSet(sql, con1);
                }
            }
            else
            {
                sql = "Select * from TBLSALARY where  (DON_AP=0 OR DON_AP is null) and CHA_DT<='"
                    + dt2.ToString("yyyy/MM/dd") + "' and EMP_ID=N'" + EMP_ID + "' ORDER BY CHA_DT desc";
                rs = new RecordSet(sql, con1);
            }

            sql = "Select * from TBLPAYROLL where  EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" + YYY_MM + "' and SEQ_NO=" + SEQ_NO;
            RecordSet rs1 = new RecordSet(sql, con1);
            sql = "";
            if (rs.rows <= 0)
                return;
            for (int i = 0; i < rs_LCB.rows; i++)
            {
                if (T_String.IsNullTo00(rs1.record(0, rs_LCB.record(i, "COL_NM")) + "") <= 0)
                {
                    if (sql != "") sql += ",";
                    if (SEQ_NO == 3 && rs.rows > 1)
                        sql += "" + rs_LCB.record(i, "COL_NM") + "=" + (rs.record(1, rs_LCB.record(i, "COL_NM")) + "" == "True"
                            ? 1 : T_String.IsNullTo00(rs.record(1, rs_LCB.record(i, "COL_NM")) + ""));
                    else
                        sql += "" + rs_LCB.record(i, "COL_NM") + "=" + (rs.record(0, rs_LCB.record(i, "COL_NM")) + "" == "True"
                            ? 1 : T_String.IsNullTo00(rs.record(0, rs_LCB.record(i, "COL_NM")) + ""));
                }
            }
            if (sql != "")
            {
                sql = "update TBLPAYROLL  set " + sql + " where EMP_ID=N'" + EMP_ID + "' and SEQ_NO=" + SEQ_NO
                    + " and YYY_MM=N'" + YYY_MM + "' AND ISNULL(LCK_BT,0)=0";
                PublicFunction.SQL_Execute(sql, con1);
            }
        }

        private void TinhTong(string where, string YYY_MM, string ITEM)
        {
            //Thêm phần nếu check SUM thì tính tổng cho SEQ_NO=2 (3+4)
            //string ITEM = rs2.record(i, "ITE_NM");
            string sql = "UPDATE TBLPAYROLL SET " + ITEM + "="
                + " (SELECT SUM(" + ITEM + ") FROM TBLPAYROLL s WHERE s.EMP_ID=TBLPAYROLL.EMP_ID AND s.YYY_MM=TBLPAYROLL.YYY_MM AND s.SEQ_NO IN (3, 4))"
                + " FROM TBLEMPLOYEE INNER JOIN TBLPAYROLL ON TBLPAYROLL.EMP_ID=TBLEMPLOYEE.EMP_ID"
                + " WHERE SEQ_NO=2 AND YYY_MM=" + YYY_MM + where
                + " AND EXISTS (SELECT 1 FROM TBLPAYROLL s WHERE s.EMP_ID=TBLPAYROLL.EMP_ID AND s.YYY_MM=TBLPAYROLL.YYY_MM AND s.SEQ_NO>2)";
            PublicFunction.SQL_Execute(sql, con1);
        }

        private string FunSql(string sql, string YYY_MM, SqlConnection con)
        {
            if (sql.IndexOf("[DayOfMonth()]") > 0)
                sql = sql.Replace("[DayOfMonth()]", DayOfMonth() + "");
            if (sql.IndexOf("[SundayOfMonth()]") > 0)
                sql = sql.Replace("[SundayOfMonth()]", SundayOfMonth() + "");
            if (sql.IndexOf("[SaturdayOfMonth()]") > 0)
                sql = sql.Replace("[SaturdayOfMonth()]", SaturdayOfMonth() + "");
            if (sql.IndexOf("[HolidayOfMonth()]") > 0)
                sql = sql.Replace("[HolidayOfMonth()]", HolidayOfMonth(con) + "");

            sql = sql.Replace("[CalDate_From()]", "Cast(" + CalDate_From() + " as datetime)");
            sql = sql.Replace("[CalDate_To()]", "Cast(" + CalDate_To() + " as datetime)");
            sql = sql.Replace("[CalDate_Month()]", CalDate_Month() + "");

            return sql;
        }

        private string CalDate_From()
        {
            //return "'"+DateTime.Parse(dt1.Value+"").ToString("yyyy/MM/dd")+"'";
            return "'" + Convert.ToDateTime(dt1).ToString("yyyy/MM/dd") + "'";
        }

        private string CalDate_To()
        {
            //return "'"+DateTime.Parse(dt2.Value+"").ToString("yyyy/MM/dd")+"'";
            return "'" + Convert.ToDateTime(dt2).ToString("yyyy/MM/dd") + "'";
        }

        private string CalDate_Month()
        {
            //return "'"+DateTime.Parse(dt3.Value+"").ToString("yyyyMM")+"'";
            return "'" + Convert.ToDateTime(dt3).ToString("yyyyMM") + "'";
        }

        private int DayOfMonth()
        {
            return DayOfMonth(dt1.ToString("yyyy/MM/dd"));
        }

        private int DayOfMonth(string startDate)
        {
            int dem = 0;
            DateTime ngaybatdau = DateTime.Parse(startDate);
            DateTime ngayketthuc = dt2;
            while (T_String.IsNullTo0(ngaybatdau.ToString("yyyyMMdd")) <= T_String.IsNullTo0(ngayketthuc.ToString("yyyyMMdd")))// tung Ngay
            {
                dem++;
                ngaybatdau = ngaybatdau.AddDays(1);
            }
            return dem;
        }

        private int SundayOfMonth()
        {
            return SundayOfMonth(dt1.ToString("yyyy/MM/dd"));
        }

        private int SundayOfMonth(string startDate)
        {
            int dem = 0;
            DateTime ngaybatdau = DateTime.Parse(startDate);
            DateTime ngayketthuc = dt2;
            while (T_String.IsNullTo0(ngaybatdau.ToString("yyyyMMdd")) <= T_String.IsNullTo0(ngayketthuc.ToString("yyyyMMdd")))// tung Ngay
            {
                if (ngaybatdau.DayOfWeek == System.DayOfWeek.Sunday)
                    dem++;
                ngaybatdau = ngaybatdau.AddDays(1);
            }
            return dem;
        }

        private int SaturdayOfMonth()
        {
            int dem = 0;
            DateTime ngaybatdau = dt1;
            DateTime ngayketthuc = dt2;
            while (T_String.IsNullTo0(ngaybatdau.ToString("yyyyMMdd")) <= T_String.IsNullTo0(ngayketthuc.ToString("yyyyMMdd")))// tung Ngay
            {
                if (ngaybatdau.DayOfWeek == System.DayOfWeek.Saturday)
                    dem++;
                ngaybatdau = ngaybatdau.AddDays(1);
            }
            return dem;
        }
        private int HolidayOfMonth(SqlConnection con)
        {
            return HolidayOfMonth(dt1.ToString("yyyy/MM/dd"), con);
        }
        private int HolidayOfMonth(string startDate, SqlConnection con)
        {
            int dem = 0;
            DateTime ngaybatdau = DateTime.Parse(startDate);
            DateTime ngayketthuc = dt2;
            while (T_String.IsNullTo0(ngaybatdau.ToString("yyyyMMdd")) <= T_String.IsNullTo0(ngayketthuc.ToString("yyyyMMdd")))// tung Ngay
            {
                RecordSet rs = new RecordSet("Select h" + ngaybatdau.Day + " from TBLHOLIDAY where YYY_YY=N'"
                    + ngaybatdau.Year + "' and MMM_MM=" + ngaybatdau.Month, con);
                if (rs.rows <= 0)
                    return 0;
                if (rs.record(0, "h" + ngaybatdau.Day) == "True")
                    dem++;
                ngaybatdau = ngaybatdau.AddDays(1);
            }
            return dem;
        }

        public void Formula(string where, string YYY_MM, int SEQ_NO, SqlConnection con1)
        {
            //pro1.Value = 0;
            string sql = "Select * from TBLSALARYFORMULA where ";
            if (SEQ_NO == 1)
            {
                sql += "FST_BT=1";
                where += " AND TBLSALARY.SEQ_NO=1";
            }
            else
            {
                if (SEQ_NO == 2)
                {
                    sql += "(LST_BT=1 OR BEF_BT=1 OR AFT_BT=1 OR SUM_BT=1)";
                    //where += " AND FILD02A.SEQ_NO>1";
                }
            }

            //			if (seq > 0 && SEQ_NO==2) sql += " and isnull(SUM_BT,0)=0";

            RecordSet rs2 = new RecordSet(sql + " ORDER BY SEQ_N1", con1);
            for (int n = 0; n < rs2.rows; n++)
            {
                try
                {
                    //c1.Text = "Formula: " + (n + 1);

                    sql = rs2.record(n, "SQL_DR") + " AND TBLPAYROLL.YYY_MM=N'" + YYY_MM + "'"
                        + " AND TBLPAYROLL.YYY_MM=TBLMONTHATTENDANCE.YYY_MM AND TBLPAYROLL.SEQ_NO=TBLMONTHATTENDANCE.SEQ_NO AND ISNULL(TBLPAYROLL.LCK_BT,0)=0";

                    string whereSEQ = " AND TBLPAYROLL.SEQ_NO IN (''";

                    if (rs2.record(n, "LST_BT") + "" == "True")
                        whereSEQ += ", 2";

                    if (rs2.record(n, "BEF_BT") + "" == "True")
                        whereSEQ += ", 3";

                    if (rs2.record(n, "AFT_BT") + "" == "True")
                        whereSEQ += ", 4";

                    whereSEQ += ")";

                    sql += whereSEQ;

                    if ((sql.IndexOf("[DayOfMonth()]") > 0) || (sql.IndexOf("[SundayOfMonth()]") > 0) || (sql.IndexOf("[SaturdayOfMonth()]") > 0)
                        || (sql.IndexOf("[HolidayOfMonth()]") > 0) || (sql.IndexOf("[CalDate_From()]") > 0) || (sql.IndexOf("[CalDate_To()]") > 0)
                        || (sql.IndexOf("[CalDate_Month()]") > 0))
                    {
                        sql = FunSql(sql, YYY_MM, con1);
                    }

                    if ((sql.IndexOf("[DayOfMonth_INH()]") > 0) || (sql.IndexOf("[SundayOfMonth_INH()]") > 0)
                        || (sql.IndexOf("[HolidayOfMonth_INH()]") > 0) || (sql.IndexOf("[AnnLeaveToSalary()]") > 0)
                        || (sql.IndexOf("[VacateDaysNoSUN()]") > 0))
                    {
                        //Tinh tung nguoi
                        string ss = "Select Distinct a.EMP_ID,EMP_NM,CONVERT(NVARCHAR(10),INH_DT,111) INH_DT from "
                            + "TBLEMPLOYEE a where " + crtCondition1.GetWhere("a", false);
                        RecordSet rsEmp = new RecordSet(ss, con1);
                        for (int i = 0; i < rsEmp.rows; i++)
                        {
                            ss = sql;
                            ss = FunSqlINH(rsEmp.record(i, "EMP_ID"), rsEmp.record(i, "INH_DT"), ss, YYY_MM, con1);

                            //if (PublicFunction.GPS) ss = ss.Replace("FILC06AA", "FILC06AAS");
                            sql = sql.Replace("FILF01A", "TBLEMPLOYEE");
                            sql = sql.Replace("FILD02A", "TBLPAYROLL");
                            sql = sql.Replace("FILC06AA", "TBLMONTHATTENDANCE");
                            PublicFunction.SQL_Execute(ss + " AND TBLEMPLOYEE.EMP_ID=N'" + rsEmp.record(i, "EMP_ID") + "'", con1);
                        }
                    }
                    else
                    {
                        sql += where;
                        //if (PublicFunction.GPS) sql = sql.Replace("FILC06AA", "FILC06AAS");
                        sql = sql.Replace("FILF01A", "TBLEMPLOYEE");
                        sql = sql.Replace("FILD02A", "TBLPAYROLL");
                        sql = sql.Replace("FILC06AA", "TBLMONTHATTENDANCE");

                        PublicFunction.SQL_Execute(sql, con1);
                    }

                    if (SEQ_NO == 2 && rs2.record(n, "SUM_BT") == "True")
                        TinhTong(where, YYY_MM, rs2.record(n, "ITE_NM"));

                    //pro1.Value = (int)(n + 1) * 100 / rs2.rows;
                }
                catch (Exception ex)
                {
                    err += ex.Message + " - " + ex.StackTrace;
                    //MessageBox.Show(ex.Message + " " + sql);

                }
            }
        }

        private void Transfer()
        {
            //if (PublicFunction.IsKTime("PF"))
            //    return;

            //p1.Enabled = false;
            con1 = new SqlConnection(PublicFunction.connectionString);
            if (con1.State == ConnectionState.Closed)
                con1.Open();
            string sql = "", dt = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            //DateTime d2=DateTime.Parse(dt2.Value+"");
            DateTime d2 = Convert.ToDateTime(dt2);

            string YYY_MM = dt3.ToString("yyyyMM");

            rs_LCB = new RecordSet("Select * from TBLSALARYITEM where BAS_BT=1", con1);
            //sql = "Delete TBLPAYROLL FROM FILB01AC C WHERE TBLPAYROLL.EMP_ID=C.EMP_ID AND VAC_DT<='" + dt1.ToString("yyyy/MM/dd") + "' and YYY_MM=N'" + YYY_MM + "'";
            //sql = "Delete TBLPAYROLL WHERE YYY_MM=N'" + YYY_MM + "'";

            //PublicFunction.SQL_Execute(sql, con1);
            sql = "Select EMP_ID,EMP_NM,DEP_ID DEP_I1,EMP_I1 EMP_DW  from TBLEMPLOYEE"
                + " where " + crtCondition1.GetWhere("", false);
            RecordSet rs = new RecordSet(sql, con1);
            try
            {
                for (int i = 0; i < rs.rows; i++)
                {
                    string EMP_ID = rs.record(i, "EMP_ID");
                    string DEP_ID = rs.record(i, "DEP_I1"), EMP_DW = rs.record(i, "EMP_DW");
                    //c1.Text = rs.record(i, "EMP_ID") + " - " + rs.record(i, "EMP_NM") + " | " + ((i + 1) + "/" + rs.rows);
                    string wh;
                    sql = "Select LCK_BT from TBLPAYROLL ";
                    wh = " where EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and "
                        + "YYY_MM=N'" + dt3.ToString("yyyyMM") + "' and SEQ_NO=";
                    if (r1)
                        wh += "1";
                    else
                        wh += "2";
                    RecordSet rs1 = new RecordSet(sql + wh, con1);
                    if (rs1.rows <= 0 || (rs1.rows > 0 && rs1.record(0, "LCK_BT") != "True"))
                    {
                        sql = "Insert Into TBLPAYROLL(EMP_ID,DEP_ID,EMP_DW,YYY_MM,SEQ_NO,BLT_NM,BLT_DT) values(";
                        sql += "N'" + EMP_ID + "',N'" + DEP_ID + "',N'" + EMP_DW + "',N'" + YYY_MM + "',";
                        if (r1)
                            sql += "1";
                        else
                            sql += "2";
                        sql += ",N'" + "{UserLogin}" + "','" + dt + "')";
                        try
                        {
                            PublicFunction.SQL_Execute(sql, con1);
                        }
                        catch (SqlException ex) { if (ex.Number != 2627) err+=ex.Message; }
                        if (!r1)
                        {
                            int seq = T_String.IsNullTo0(T_String.GetDataFromSQL("Count(*)", TBLMONTHATTENDANCE, "EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" + YYY_MM + "' and SEQ_NO=3"));
                            if (seq > 0)
                            {
                                sql = "Insert Into TBLPAYROLL(EMP_ID,DEP_ID,YYY_MM,SEQ_NO,BLT_NM,BLT_DT) values(";
                                sql += "N'" + rs.record(i, "EMP_ID") + "',N'" + DEP_ID + "',N'" + dt3.ToString("yyyyMM") + "',3";
                                sql += ",N'" + "{UserLogin}" + "','" + dt + "')";
                                try
                                {
                                    PublicFunction.SQL_Execute(sql, con1);
                                }
                                catch (SqlException ex) { if (ex.Number != 2627) err += ex.Message; }

                                sql = "Insert Into TBLPAYROLL(EMP_ID,DEP_ID,YYY_MM,SEQ_NO,BLT_NM,BLT_DT) values(";
                                sql += "N'" + rs.record(i, "EMP_ID") + "',N'" + DEP_ID + "',N'" + dt3.ToString("yyyyMM") + "',4";
                                sql += ",N'" + "{UserLogin}" + "','" + dt + "')";
                                try
                                {
                                    PublicFunction.SQL_Execute(sql, con1);
                                }
                                catch (SqlException ex) { if (ex.Number != 2627) err+= ex.Message; }
                                LCB(EMP_ID, YYY_MM, 3, con1);
                                LCB(EMP_ID, YYY_MM, 4, con1);
                            }
                            LCB(EMP_ID, YYY_MM, 2, con1);
                        }
                        else
                        {
                            LCB(EMP_ID, YYY_MM, 1, con1);
                        }
                    }
                    //pro1.Value = (int)(i + 1) * 100 / rs.rows;

                    //if (sleep > 0)
                    //    Thread.Sleep(sleep);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                err += ex.Message;
                //p1.Enabled = true;
            }
            //pro1.Value = 100;
            con1.Close();
            //p1.Enabled = true;
        }

        private string FunSqlINH(string EMP_ID, string INH_DT, string sql, string YYY_MM, SqlConnection con)
        {
            if (sql.IndexOf("[DayOfMonth_INH()]") > 0)
                sql = sql.Replace("[DayOfMonth_INH()]", DayOfMonth(INH_DT) + "");
            if (sql.IndexOf("[SundayOfMonth_INH()]") > 0)
                sql = sql.Replace("[SundayOfMonth_INH()]", SundayOfMonth(INH_DT) + "");
            if (sql.IndexOf("[HolidayOfMonth_INH()]") > 0)
                sql = sql.Replace("[HolidayOfMonth_INH()]", HolidayOfMonth(INH_DT, con) + "");
            if (sql.IndexOf("AnnLeaveToSalary") > 0)
                sql = sql.Replace("[AnnLeaveToSalary()]", AnnLeaveToSalary(EMP_ID, YYY_MM) + "");
            if (sql.IndexOf("[VacateDaysNoSUN()]") > 0)
            {
                DateTime dt = new DateTime(T_String.IsNullTo0(PublicFunction.S_Left(YYY_MM, 4)),
                    T_String.IsNullTo0(PublicFunction.S_Right(YYY_MM, 2)), 1);

                sql = sql.Replace("[VacateDaysNoSUN()]", VacateDaysNoSUN(EMP_ID, con, dt) + "");
            }

            return sql;
        }

        private double AnnLeaveToSalary(string EMP_ID, string YYY_MM)
        {
            return 0;
            //int month = int.Parse(YYY_MM.Substring(4, 2));
            //RecordSet rs = new RecordSet("SELECT * WHERE 1=0", PublicFunction.C_con);

            //if (rs.rows <= 0 || rs.record(0, 1 + month) + "" == "") return 0;

            //return double.Parse(rs.record(0, 1 + month) + "");
        }

        private int VacateDaysNoSUN(string EMP_ID, SqlConnection con, DateTime dt)
        {
            return 0;
            //RecordSet rs = new RecordSet("Select '' VAC_DT  where 1=0", con);

            //RecordSet rs1 = new RecordSet("Select INH_DT from TBLEMPLOYEE where EMP_ID=N'" +
            //    EMP_ID + "'", con);
            //if (rs.rows <= 0 && rs1.rows <= 0)
            //    return 0;
            //try
            //{
            //    int count = 0;
            //    if (rs.rows > 0)
            //    {
            //        DateTime d1 = DateTime.Parse(rs.record(0, 0));
            //        //DateTime d2= DateTime.Parse(dt2.Value+"");						
            //        DateTime d2 = Convert.ToDateTime(dt2);
            //        while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) < T_String.IsNullTo0(d2.ToString("yyyyMMdd")))
            //        {
            //            if (d1.DayOfWeek != DayOfWeek.Sunday)
            //                count++;
            //            d1 = d1.AddDays(1);
            //        }
            //    }
            //    if (rs1.rows > 0)
            //    {
            //        //DateTime d1=DateTime.Parse(dt1.Value+"");
            //        DateTime d1 = Convert.ToDateTime(dt1);
            //        DateTime d2 = DateTime.Parse(rs1.record(0, 0));
            //        while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) < T_String.IsNullTo0(d2.ToString("yyyyMMdd")))
            //        {
            //            if (d1.DayOfWeek != DayOfWeek.Sunday)
            //                count++;
            //            d1 = d1.AddDays(1);
            //        }
            //    }
            //    return count;
            //}
            //catch { return 0; }
        }

        private void Transfer1()
        {
            //p1.Enabled = false;
            con1 = new SqlConnection(PublicFunction.connectionString);

            if (con1.State == ConnectionState.Closed)
                con1.Open();
            string dt = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            string YYY_MM = dt3.ToString("yyyyMM");
            string where, where1 = "";
            where = " AND " + crtCondition1.GetWhere("TBLEMPLOYEE", false);
            //if (ckVac)
            //    where1 = " AND FILB01AC.VAC_DT>='" + dt1.ToString("yyyy/MM/dd") + "' AND FILB01AC.VAC_DT<='"
            //        + dt2.AddDays(1).ToString("yyyy/MM/dd") + "'";

            try
            {
                if (!r1)
                    Formula(where + where1, YYY_MM, 2, con1);   //Cuối kỳ
                else
                    Formula(where, YYY_MM, 1, con1);        //Tạm ứng
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                err += ex.Message + " ";
                //p1.Enabled = true;
            }

            //pro1.Value = 100;
            con1.Close();
            //p1.Enabled = true;
        }

    }
}
