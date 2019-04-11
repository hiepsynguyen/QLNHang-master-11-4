using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Admin.Models.CommonViewModel;

namespace WebApplication8.Helper
{
    public class AttMonthAddUpCalHelper
    {
        int sleep;
        private string TBLDETAILSATTENDANCE, TBLMONTHATTENDANCE, TBLEXCOLATTENDANCE;
        public DateTime dt1, dt2, dt3;
        RecordSet LEA;
        public Boolean Stop;
        public CrtConditionViewModel crtCondition1;
        public string cb = "2";
        public string err = "";

        public AttMonthAddUpCalHelper(DateTime dt1, DateTime dt2,DateTime dt3, CrtConditionViewModel crt) {
            TBLDETAILSATTENDANCE = "TBLDETAILSATTENDANCE";
            TBLMONTHATTENDANCE = "TBLMONTHATTENDANCE";
            TBLEXCOLATTENDANCE = "TBLEXCOLATTENDANCE";
            this.dt1 = dt1 == null && dt3 != null ? DateTime.ParseExact(dt3.ToString("yyyy/MM") + "/01", "yyyy/MM/dd", null) : dt1;
            this.dt2 = dt2 == null && dt3 != null ? this.dt1.AddMonths(1).AddDays(-1) : dt2;
            this.dt3 = dt3;
            this.crtCondition1 = crt;
        }


        private void UpdateItem(string Item, string EMP_ID, string SEQ_NO, SqlConnection con, Boolean giophut, RecordSet sal, int round)
        {
            string YYY_MM = dt3.ToString("yyyyMM");
            DateTime d1 = dt1;
            DateTime d2 = dt2;
            string sql = "", sql1 = "";
            sql = "Update " + TBLMONTHATTENDANCE + " set [" + Item + "]=";
            if (giophut)
                sql += "(Select ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2) ";
            else
                sql += "(Select ROUND(SUM([" + Item + "])," + round + ") ";

            sql1 = sql + " from " + TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /* LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID */"
                + " where a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT) */and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                "' and '" + d2.ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                YYY_MM + "' and SEQ_NO=" + SEQ_NO;
            PublicFunction.SQL_Execute(sql1, con, 60, true);
            if (SEQ_NO == "2" && sal.rows > 0)
            {
                sql1 = sql + " from " + TBLDETAILSATTENDANCE + " where EMP_ID=N'" + EMP_ID + "' and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                    "' and '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").AddDays(-1).ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 3;
                PublicFunction.SQL_Execute(sql1, con, 60, true); // truoc thay doi luong 

                sql1 = sql + " from " + TBLDETAILSATTENDANCE + " where EMP_ID=N'" + EMP_ID + "' and ATT_DT between '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").ToString("yyyy/MM/dd") +
                    "' and '" + d2.ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 4;
                PublicFunction.SQL_Execute(sql1, con, 60, true); // sau thay doi luong 
            }
        }

        private void UpdateItemCount(string Item, string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal)
        {
            string YYY_MM = dt3.ToString("yyyyMM");
            DateTime d1 = dt1;
            DateTime d2 = dt2;
            string sql = "", sql1 = "";
            sql = "Update " + TBLMONTHATTENDANCE + " set [" + Item + "]=(SELECT COUNT(Case When [" + Item + "]=1 Then 1 End)";

            sql1 = sql + " from " + TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/"
                + " where a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                "' and '" + d2.ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                YYY_MM + "' and SEQ_NO=" + SEQ_NO;
            PublicFunction.SQL_Execute(sql1, con, 60, true);
            if (SEQ_NO == "2" && sal.rows > 0)
            {
                sql1 = sql + " from " + TBLDETAILSATTENDANCE + " where EMP_ID=N'" + EMP_ID + "' and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                    "' and '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").AddDays(-1).ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 3;
                PublicFunction.SQL_Execute(sql1, con, 60, true); // truoc thay doi luong 

                sql1 = sql + " from " + TBLDETAILSATTENDANCE + " where EMP_ID=N'" + EMP_ID + "' and ATT_DT between '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").ToString("yyyy/MM/dd") +
                    "' and '" + d2.ToString("yyyy/MM/dd") + "') where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 4;
                PublicFunction.SQL_Execute(sql1, con, 60, true); // sau thay doi luong 
            }
        }

        private void UpdateItem(string Item, string EMP_ID, string SEQ_NO, SqlConnection con, Boolean giophut, RecordSet sal)
        {
            UpdateItem(Item, EMP_ID, SEQ_NO, con, giophut, sal, 2);
        }
        private void CalShift(RecordSet rs, string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal) // tinh gio cong
        {
            for (int i = 0; i < rs.rows; i++)  // Tung Nhan Vien
            {
                string Item = rs.record(i, "TYP_ID");
                UpdateItem(Item, EMP_ID, SEQ_NO, con, true, sal);
            }
        }

        public void Cal()
        {
            string sql;

            //cmd_stop.Visible = true;
            //panel2.Enabled = false;
            SqlConnection con1 = new SqlConnection(PublicFunction.connectionString);
            if (con1.State == ConnectionState.Closed)
                con1.Open();

            string YYY_MM = dt3.ToString("yyyyMM");
            string dt = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

            DateTime d1 = dt1;
            DateTime d2 = dt2;

            ArrayList a = new ArrayList();

            while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) <= T_String.IsNullTo0(d2.ToString("yyyyMMdd")))// tung Ngay
            {
                string data = T_String.GetDataFromSQL("h" + d1.Day, "TBLHOLIDAY", "YYY_YY=" + d1.Year + " and MMM_MM=" + d1.Month);
                if (data + "" == "True")
                {
                    a.Add(d1.ToString("yyyyMMdd"));
                }
                d1 = d1.AddDays(1);
            }

            d1 = dt1;
            d2 = dt2;

            RecordSet sal;
            sql = "Select TYP_ID from TBLTYPESHIFT";
            RecordSet rsshift = new RecordSet(sql, con1);
            //sql="Select * from " + FILC07A + " where MON_BT=1";
            //Func.RecordSet ATTFOR = new Func.RecordSet(sql,PublicFunction.C_con);

            sql = "SELECT COL_NM, GIO_BT,"
                + " (SELECT t.name FROM sys.columns c INNER JOIN sys.types t ON c.system_type_id=t.system_type_id"
                + " WHERE OBJECT_NAME(object_id)='" + TBLDETAILSATTENDANCE + "' AND t.name<>'sysname' AND c.name=COL_NM) DATA_TP"
                + " FROM " + TBLEXCOLATTENDANCE + " WHERE MON_BT=1";
            RecordSet ATTFOR = new RecordSet(sql, con1);

            sql = "Select a.EMP_ID,EMP_NM,null VAC_DT,a.EMP_I1,a.DEP_ID,CONVERT(nvarchar(10),INH_DT,111) INH_DT from TBLEMPLOYEE  a /*Left JOIN FILB01AC b on a.EMP_ID=b.EMP_ID*/ where  "
                + crtCondition1.GetWhere("a", false) + " /*and (VAC_DT>'" + d1.ToString("yyyy/MM/dd") + "' or VAC_DT is null or a.VAC_BT=0 or a.VAC_BT is null)*/"
                + " and INH_DT<='" + d2.ToString("yyyy/MM/dd") + "'";

            RecordSet rs = new RecordSet(sql, con1);
            string sql1 = "";
            for (int i = 0; i < rs.rows; i++)  // Tung Nhan Vien
            {
                if (Stop)
                {
                    return;
                }
                //c1.Text = rs.record(i, "EMP_ID") + " - " + rs.record(i, "EMP_NM");

                //Ktra lock thang
                if (T_String.GetDataFromSQL("ISNULL(LOC_B1,0) LOC_B1", TBLMONTHATTENDANCE, "EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and YYY_MM=N'" + YYY_MM + "' AND SEQ_NO="
                    + (cb + "" == "1" ? "1" : "2"), con1) != "True")
                {
                    sql = "Delete from " + TBLMONTHATTENDANCE + " where EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and YYY_MM=N'" + YYY_MM + "'";
                    if (cb + "" == "1")
                        sql += " and SEQ_NO=1"; // nua thang
                    else
                        sql += " and SEQ_NO in(2,3,4)";// 2 nguyen thang, 3 truoc khi doi luong, 4 sau khi doi luong 
                    PublicFunction.SQL_Execute(sql, con1, 30, true);
                    // doi bo phan
                    //sql = "SELECT * FROM FILB03A WHERE  (SEQ_DT>'" + d2.ToString("yyyy/MM/dd")
                    //    + "' and EMP_ID=N'" + rs.record(i, "EMP_ID") + "') ORDER BY SEQ_DT ASC"; // doi bo phan
                    sql = "SELECT '' DEP_I1, '' EMP_I3 where 1=0";
                    RecordSet rs1 = new RecordSet(sql, con1);
                    string DEP_I1, EMP_DW;
                    if (rs1.rows > 0)
                    {
                        DEP_I1 = rs1.record(0, "DEP_I1");// thay doi bo phan
                        EMP_DW = rs1.record(0, "EMP_I3");
                    }
                    else
                    {
                        DEP_I1 = rs.record(i, "DEP_ID");
                        EMP_DW = rs.record(i, "EMP_I1");
                    }
                    //
                    sql = "Insert into " + TBLMONTHATTENDANCE + "(EMP_ID,YYY_MM,DEP_I1,EMP_DW,BLT_NM,BLT_DT,NOT_DR,SEQ_NO) values(";
                    sql += "N'" + rs.record(i, "EMP_ID") + "',N'" + YYY_MM + "',";
                    sql += "N'" + DEP_I1 + "',N'" + EMP_DW + "',";
                    sql += "N'" + "{User Login}" + "','" + dt + "',";
                    sql += "N'" + d1.ToString("yyyy/MM/dd") + "~" + d2.ToString("yyyy/MM/dd") + "',";

                    string sql11 = "Select EMP_ID,CHA_DT from TBLSALARY where EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and CHA_DT>'" +
                        d1.ToString("yyyy/MM/dd") + "' and CHA_DT<='" + d2.ToString("yyyy/MM/dd") + "' AND ISNULL(DON_AP,0)=0" +
                        " AND CHA_DT<>'" + rs.record(i, "INH_DT") + "'";
                    sal = new RecordSet(sql11, con1);

                    if (cb + "" == "1")
                    {
                        sql1 = sql + "1)";
                        PublicFunction.SQL_Execute(sql1, con1, 60, true);
                    }
                    else
                    {
                        sql1 = sql + "2)";
                        PublicFunction.SQL_Execute(sql1, con1, 60, true);
                        if (sal.rows > 0)
                        {
                            sql = "Insert into " + TBLMONTHATTENDANCE + "(EMP_ID,YYY_MM,BLT_NM,BLT_DT,NOT_DR,SEQ_NO) values(";
                            sql += "N'" + rs.record(i, "EMP_ID") + "',N'" + YYY_MM + "',";
                            sql += "N'" + "{User Login}" + "','" + dt + "',";
                            sql += "N'" + d1.ToString("yyyy/MM/dd") + "~" + DateTime.Parse(sal.record(0, "CHA_DT")).AddDays(-1).ToString("yyyy/MM/dd") + "',";
                            sal = new RecordSet("Select EMP_ID,CHA_DT from TBLSALARY where EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and CHA_DT>'" +
                                d1.ToString("yyyy/MM/dd") + "' and CHA_DT<='" + d2.ToString("yyyy/MM/dd") + "' and ISNULL(DON_AP,0)=0", con1);
                            sql1 = sql + "3)";
                            PublicFunction.SQL_Execute(sql1, con1, 60, true);

                            sql = "Insert into " + TBLMONTHATTENDANCE + "(EMP_ID,YYY_MM,BLT_NM,BLT_DT,NOT_DR,SEQ_NO) values(";
                            sql += "N'" + rs.record(i, "EMP_ID") + "',N'" + YYY_MM + "',";
                            sql += "N'" + "{User login}" + "','" + dt + "',";
                            sql += "N'" + DateTime.Parse(sal.record(0, "CHA_DT")).ToString("yyyy/MM/dd") + "~" + d2.ToString("yyyy/MM/dd") + "',";
                            sal = new RecordSet("Select EMP_ID,CHA_DT from TBLSALARY where EMP_ID=N'" + rs.record(i, "EMP_ID") + "' and CHA_DT>'" +
                                d1.ToString("yyyy/MM/dd") + "' and CHA_DT<='" + d2.ToString("yyyy/MM/dd") + "' and ISNULL(DON_AP,0)=0", con1);
                            sql1 = sql + "4)";
                            PublicFunction.SQL_Execute(sql1, con1, 60, true);
                        }
                    }

                    CalShift(rsshift, rs.record(i, "EMP_ID"), cb + "", con1, sal);
                    CalATTFOR(ATTFOR, rs.record(i, "EMP_ID"), cb + "", con1, sal);
                    Normal(rs.record(i, "EMP_ID"), cb + "", con1, sal);
                    LEAVE(rs.record(i, "EMP_ID"), cb + "", con1, sal);
                    //BonusFined(rs.record(i, "EMP_ID"), cb + "", con1, sal);
                    CalHoliday(rs.record(i, "EMP_ID"), rs.record(i, "INH_DT"), rs.record(i, "VAC_DT"), a, cb + "", con1, sal);
                }

                //pro1.Value = 100;
                //pro2.Value = (int)(i + 1) * 100 / rs.rows;

                //if (sleep > 0)
                //    Thread.Sleep(sleep);
            }
            //pro2.Value = 100;
            //c1.Text = PublicFunction.L_Get_Msg("Staff", 1);
            //panel2.Enabled = true;
            //cmd_stop.Visible = false;
        }
        public void cmd_mon_cal()
        {
            try {
                DateTime d1 = dt1;
                DateTime d2 = dt2;
                DateTime d3 = dt3;

                if (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) > T_String.IsNullTo0(d2.ToString("yyyyMMdd")))
                {
                    //MessageBox.Show(PublicFunction.L_Get_Msg("msg", 216));
                    err += "Sai định dạng ngày chọn";
                    return;
                }

                Stop = false;
                Cal();
            } catch (Exception ex) {
                err += " \n Lỗi" + ex.Message + " - " + ex.StackTrace; 
            }
        }

            private void Normal(string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal)
        {
            UpdateItem("LAT_MN", EMP_ID, SEQ_NO, con, true, sal);
            UpdateItem("LAT_TM", EMP_ID, SEQ_NO, con, false, sal);
            UpdateItem("EAR_MN", EMP_ID, SEQ_NO, con, true, sal);
            UpdateItem("EAR_TM", EMP_ID, SEQ_NO, con, false, sal);
            UpdateItem("ABS_MN", EMP_ID, SEQ_NO, con, true, sal);
            UpdateItem("ABS_TM", EMP_ID, SEQ_NO, con, false, sal);
            UpdateItem("OTR_HR", EMP_ID, SEQ_NO, con, true, sal);
            UpdateItem("ATT_DY", EMP_ID, SEQ_NO, con, false, sal, 4);
            UpdateItem("NIG_DY", EMP_ID, SEQ_NO, con, false, sal, 4);
        }

        private void CalATTFOR(RecordSet rs, string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal)
        {
            for (int i = 0; i < rs.rows; i++)
            {
                if (rs.record(i, "DATA_TP") == "bit")
                {
                    UpdateItemCount(rs.record(i, "COL_NM"), EMP_ID, SEQ_NO, con, sal);
                }
                else
                {
                    if (rs.record(i, "GIO_BT") == "True")
                        UpdateItem(rs.record(i, "COL_NM"), EMP_ID, SEQ_NO, con, true, sal);
                    else
                        UpdateItem(rs.record(i, "COL_NM"), EMP_ID, SEQ_NO, con, false, sal);
                }
            }
        }

        private void LEAVE(string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal)
        {
            string sql = "", sql1;
            if (LEA == null) return;
            for (int i = 0; i < LEA.rows; i++)
            {
                UpdateItemLeave(LEA.record(i, "LEA_ID"), EMP_ID, SEQ_NO, con, sal);
                if (sql != "") sql += "+";
                sql += "[LEA_" + LEA.record(i, "LEA_ID") + "]";
            }
            if (sql != "")
            {
                sql1 = "update " + TBLMONTHATTENDANCE + " set LEA_QT=" + sql + " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'"
                    + dt3.ToString("yyyyMM") + "' and SEQ_NO=" + SEQ_NO;
                PublicFunction.SQL_Execute(sql1, con, 60, true);
                if (SEQ_NO == "2" && sal.rows > 0)
                {
                    sql1 = "update " + TBLMONTHATTENDANCE + " set LEA_QT=" + sql + " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'"
                        + dt3.ToString("yyyyMM") + "' and SEQ_NO=3";
                    PublicFunction.SQL_Execute(sql1, con, 60, true);
                    sql1 = "update " + TBLMONTHATTENDANCE + " set LEA_QT=" + sql + " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'"
                        + dt3.ToString("yyyyMM") + "' and SEQ_NO=4";
                    PublicFunction.SQL_Execute(sql1, con, 60, true);
                }
            }
        }

        private void UpdateItemLeave(string LEA_ID, string EMP_ID, string SEQ_NO, SqlConnection con, RecordSet sal)
        {
            string YYY_MM = dt3.ToString("yyyyMM");
            DateTime d1 = dt1;
            DateTime d2 = dt2;
            string sql = "", sql1, Item;
            Double t1, t2, t3;
            Item = "LEA_H1";
            sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
            //			sql1="EMP_ID=N'"+EMP_ID+"' and ATT_DT between '"+d1.ToString("yyyy/MM/dd")+
            //				"' and '"+d2.ToString("yyyy/MM/dd")+"' and LEA_I1=N'"+LEA_ID+"'";
            //			t1=T_String.IsNullTo00(T_String.GetDataFromSQL(sql, FILC06A, sql1));
            sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I1=N'" + LEA_ID + "'";
            t1 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

            Item = "LEA_H2";
            sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
            //			sql1="EMP_ID=N'"+EMP_ID+"' and ATT_DT between '"+d1.ToString("yyyy/MM/dd")+
            //				"' and '"+d2.ToString("yyyy/MM/dd")+"' and LEA_I2=N'"+LEA_ID+"'";
            //			t2=T_String.IsNullTo00(T_String.GetDataFromSQL(sql, FILC06A, sql1));
            sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT AND (VAC_DT IS NULL OR ATT_DT<VAC_DT) and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I2=N'" + LEA_ID + "'";
            t2 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

            Item = "LEA_H3";
            sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
            //			sql1="EMP_ID=N'"+EMP_ID+"' and ATT_DT between '"+d1.ToString("yyyy/MM/dd")+
            //				"' and '"+d2.ToString("yyyy/MM/dd")+"' and LEA_I3=N'"+LEA_ID+"'";
            //			t3=T_String.IsNullTo00(T_String.GetDataFromSQL(sql, FILC06A, sql1));
            sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I3=N'" + LEA_ID + "'";
            t3 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

            t1 = t1 + t2 + t3;

            sql = "Update " + TBLMONTHATTENDANCE + " set [" + "LEA_" + LEA_ID + "]=" + t1.ToString("##0.##");
            sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                YYY_MM + "' and SEQ_NO=" + SEQ_NO;
            PublicFunction.SQL_Execute(sql, con, 60, true);
            if (SEQ_NO == "2" && sal.rows > 0)
            {
                Item = "LEA_H1";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                    "' and '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").AddDays(-1).ToString("yyyy/MM/dd") + "' and LEA_I1=N'" + LEA_ID + "'";
                t1 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                Item = "LEA_H2";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                    "' and '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").AddDays(-1).ToString("yyyy/MM/dd") + "' and LEA_I2=N'" + LEA_ID + "'";
                t2 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                Item = "LEA_H3";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + d1.ToString("yyyy/MM/dd") +
                    "' and '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").AddDays(-1).ToString("yyyy/MM/dd") + "' and LEA_I3=N'" + LEA_ID + "'";
                t3 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                t1 = t1 + t2 + t3;

                sql = "Update " + TBLMONTHATTENDANCE + " set [" + "LEA_" + LEA_ID + "]=" + t1.ToString("##0.##");
                sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 3;
                PublicFunction.SQL_Execute(sql, con, 60, true); //truoc khi thay doi luong

                Item = "LEA_H1";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";
                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").ToString("yyyy/MM/dd") +
                    "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I1=N'" + LEA_ID + "'";
                t1 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                Item = "LEA_H2";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";

                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").ToString("yyyy/MM/dd") +
                    "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I2=N'" + LEA_ID + "'";
                t2 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                Item = "LEA_H3";
                sql = "ROUND(SUM((FLOOR([" + Item + "]/100)+([" + Item + "]/100-FLOOR([" + Item + "]/100))/0.6)),2)";

                sql1 = "a.EMP_ID=N'" + EMP_ID + "' AND ATT_DT>=INH_DT /*AND (VAC_DT IS NULL OR ATT_DT<VAC_DT)*/ and ATT_DT between '" + DateTime.Parse(sal.record(0, "CHA_DT") + "").ToString("yyyy/MM/dd") +
                    "' and '" + d2.ToString("yyyy/MM/dd") + "' and LEA_I3=N'" + LEA_ID + "'";
                t3 = T_String.IsNullTo00(T_String.GetDataFromSQL(sql, TBLDETAILSATTENDANCE + " a INNER JOIN TBLEMPLOYEE e ON e.EMP_ID=a.EMP_ID /*LEFT JOIN FILB01AC v ON v.EMP_ID=a.EMP_ID*/", sql1));

                t1 = t1 + t2 + t3;

                sql = "Update " + TBLMONTHATTENDANCE + " set [" + "LEA_" + LEA_ID + "]=" + t1.ToString("##0.##");
                sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=" + 4;
                PublicFunction.SQL_Execute(sql, con, 60, true); // sau khi thay doi luong
            }
        }

        private void CalHoliday(string EMP_ID, string INH_DT, string dt, ArrayList a, string SEQ_NO, SqlConnection con, RecordSet sal)// cong gio cong ngay nghi le
        {
            if (a.Count == 0)
                return;
            int m = 0, m1 = 0, m2 = 0;

            Double dt1 = 0;
            Double INH = 0;
            if (INH_DT + "" != "")
                INH = T_String.IsNullTo00(DateTime.Parse(INH_DT).ToString("yyyyMMdd"));
            else
                INH = 9999999999;

            if (dt + "" != "")
                dt1 = T_String.IsNullTo00(DateTime.Parse(dt).ToString("yyyyMMdd"));
            else
                dt1 = 9999999999;
            Double dt4 = 0;

            if (sal.rows > 0)
                dt4 = T_String.IsNullTo00(DateTime.Parse(sal.record(0, "CHA_DT")).ToString("yyyyMMdd"));
            RecordSet rsATT;
            string sql;

            for (int i = 0; i < a.Count; i++)
            {
                if (dt1 <= T_String.IsNullTo00(a[i] + ""))
                    break;
                string s = a[i] + "";
                sql = "select * from TBLLEAVE where EMP_ID='" + EMP_ID + "' AND '" + a[i] + "' BETWEEN STR_DT AND END_DT and LEA_ID IN (SELECT  LEA_ID FROM TBLTYPELEAVE WHERE HOL_BT=1)";
                rsATT = new RecordSet(sql, con);
                if (rsATT.rows <= 0)
                {
                    if (INH <= T_String.IsNullTo00(a[i] + ""))
                    {
                        if (SEQ_NO == "2")
                        {
                            if (sal.rows > 0 && sal.rows > 0)
                            {
                                if (dt4 <= T_String.IsNullTo00(a[i] + ""))// sau khi doi luong
                                    m1++;
                                else // truoc khi doi luong
                                    m2++;
                            }
                        }
                        m++;
                    }
                }
            }
            if (m <= 0)
                return;
            m = m * 8;
            m1 = m1 * 8;
            m2 = m2 * 8;

            string YYY_MM = dt3.ToString("yyyyMM");
            sql = "Update " + TBLMONTHATTENDANCE + " set [HOL_TT]=" + m;
            sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                YYY_MM + "' and SEQ_NO=" + SEQ_NO;
            PublicFunction.SQL_Execute(sql, con, 60, true);
            if (SEQ_NO == "2" && sal.rows > 0)
            {
                sql = "Update " + TBLMONTHATTENDANCE + " set [HOL_TT]=" + m2;
                sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=3";
                PublicFunction.SQL_Execute(sql, con, 60, true);
                sql = "Update " + TBLMONTHATTENDANCE + " set [HOL_TT]=" + m1;
                sql += " where EMP_ID=N'" + EMP_ID + "' and YYY_MM=N'" +
                    YYY_MM + "' and SEQ_NO=4";
                PublicFunction.SQL_Execute(sql, con, 60, true);
            }
        }

    }
}
