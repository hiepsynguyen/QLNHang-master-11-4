using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Helper
{
    public class TransferFDeviceHelper
    {
        private Double d1, d2; // so dong them vao cua 1 va 2
        private string dt;// ngay hien tai
        private string TYP_NM1, TYP_NM2;//TYP_NM1 loai may cho duong dan 1, 2 duong dan 2
        private SqlConnection con11, con21;
        private int CRD_MN;// so phut the lap lai
        public  ArrayList EMP_ID, CRD_NO;
        private string BT, err;
        public TransferFDeviceHelper() {
            Get_Staff();
            dt = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        }
        public void AddRawDataToDB(string st1, string filename, SqlConnection con, string SEQ_NO)
        {
            string st = st1;
            string REA_NO = PublicFunction.S_Left(st, 3);
            st = PublicFunction.S_Right(st, st.Length - 3);
            string CRD_NO = PublicFunction.S_Left(st, 10);
            st = PublicFunction.S_Right(st, st.Length - 10);
            string CRD_DT = PublicFunction.S_Left(st, 8);
            st = PublicFunction.S_Right(st, st.Length - 8);
            string CRD_TM = PublicFunction.S_Left(st, 4);
            Double TM = T_String.IsNullTo00(PublicFunction.S_Left(st, 4));

            DateTime dt1 = GetDateTime(CRD_DT, CRD_TM).AddMinutes(-CRD_MN);
            DateTime dt2 = GetDateTime(CRD_DT, CRD_TM).AddMinutes(CRD_MN);


            string sql = "", EMP_ID;
            //Kiem tra neu ma co roi thi ko them nua
            sql = "Select EMP_ID from TBLCARDDATA where DAT_TM=N'" + CRD_DT + CRD_TM + "' and CRD_NO=N'" + CRD_NO + "'";
            RecordSet rs = new RecordSet(sql, PublicFunction.C_con);
            if (rs.rows <= 0)
            {
                //					sql="Delete from FILC01A where DAT_TM=N'"+CRD_DT+CRD_TM+"' and CRD_NO=N'"+CRD_NO+"'";
                //					PublicFunction.SQL_Execute(sql,con);
                if (TM == 0000)
                {
                    CRD_TM = "2400";
                    TM = 2400;
                    CRD_DT = GetDate(CRD_DT).AddDays(-1).ToString("yyyyMMdd");

                }
                sql = "(DAT_TM>" + dt1.ToString("yyyyMMddHHmm") + " and DAT_TM<" + dt2.ToString("yyyyMMddHHmm")
                    + ") and CRD_NO=N'" + CRD_NO + "'";
                if (T_String.IsNullTo0(T_String.GetDataFromSQL("COUNT(DAT_TM)", "TBLCARDDATA", sql, con)) <= 0)// thoi cho phep duoc lap lai the
                {
                    int index = this.CRD_NO.IndexOf(CRD_NO);
                    if (index >= 0)
                        EMP_ID = this.EMP_ID[index] + "";
                    else
                        EMP_ID = "";
                    sql = "Insert into TBLCARDDATA(DAT_TM,EMP_ID,SWI_DT,USR_NM,CRD_DT,CRD_TM,CRD_NO,REA_NO,FIL_NM) values(";
                    sql += "N'" + CRD_DT + CRD_TM + "',N'" + EMP_ID + "','" + dt + "',N'" + "{UserID}" + "',";
                    sql += "'" + CRD_DT + "'," + TM + ",";
                    sql += "N'" + CRD_NO + "',N'" + REA_NO + "',";
                    sql += "N'" + filename + "')";

                    try
                    {
                        PublicFunction.SQL_Execute(sql, con);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number != 2627)
                        {
                            //MessageBox.Show(ex.Message + "");
                            err += ex.Message + "";
                        }
                    }
                }
                //PublicFunction.SQL_Execute(sql,con);
                if (SEQ_NO == "0")
                {
                    //lb2.Items.Add(CRD_NO + "  " + CRD_DT + "  " + CRD_TM);
                    d1++;
                    //c1.Text = d1 + "";
                }
                else
                {
                    //lb4.Items.Add(CRD_NO + "  " + CRD_DT + "  " + CRD_TM);
                    d2++;
                    //c2.Text = d2 + "";
                }
            }
        }

        private void Get_Staff()
        {
            RecordSet rs = new RecordSet("Select EMP_ID,CRD_NO from TBLEMPLOYEE where VAC_BT is null OR VAC_BT=0", PublicFunction.C_con);
            EMP_ID = new ArrayList();
            CRD_NO = new ArrayList();
            for (int i = 0; i < rs.rows; i++)
            {
                EMP_ID.Add(rs.record(i, "EMP_ID"));
                CRD_NO.Add(rs.record(i, "CRD_NO"));
            }
        }

        private DateTime GetDate(string st)
        {
            try
            {

                string st1 = st;
                int y = T_String.IsNullTo0(PublicFunction.S_Left(st1, 4));
                st1 = PublicFunction.S_Right(st1, st1.Length - 4);
                int MM = T_String.IsNullTo0(PublicFunction.S_Left(st1, 2));
                st1 = PublicFunction.S_Right(st1, st1.Length - 2);
                int d = T_String.IsNullTo0(PublicFunction.S_Left(st1, 2));
                DateTime dt = new DateTime(y, MM, d);
                return dt;
            }
            catch (Exception)
            {
                return new DateTime(1, 1, 1);
            }
        }
        private DateTime GetDateTime(string st, string time)
        {
            try
            {

                string st1 = st;
                int y = T_String.IsNullTo0(PublicFunction.S_Left(st1, 4));
                st1 = PublicFunction.S_Right(st1, st1.Length - 4);
                int MM = T_String.IsNullTo0(PublicFunction.S_Left(st1, 2));
                st1 = PublicFunction.S_Right(st1, st1.Length - 2);
                int d = T_String.IsNullTo0(PublicFunction.S_Left(st1, 2));
                int HH = T_String.IsNullTo0(PublicFunction.S_Left(time, 2));
                int mm = T_String.IsNullTo0(PublicFunction.S_Right(time, 2));
                DateTime dt = new DateTime(y, MM, d, HH, mm, 0, 0);
                return dt;
            }
            catch (Exception)
            {
                return new DateTime(1, 1, 1);
            }
        }
    }
}
