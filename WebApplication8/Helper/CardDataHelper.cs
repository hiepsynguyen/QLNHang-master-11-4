using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL.QLNHangData;

namespace WebApplication8.Helper
{
    public class CardDataHelper
    {
        public string table, NoneReader;
        public string err;
        public RecordSet Set, rsTypeShift;
        int CRD_MN = 0;	//Khoảng cách giữa 2 lần quẹt thẻ
        QLNhaHangContext _db = new QLNhaHangContext();

        public CardDataHelper()
        {
            CRD_MN = 15;
        }



        private string GetShift(string EMP_ID, DateTime d1, SqlConnection con)
        {
            string Shift = T_String.GetDataFromSQL("DAY_" + d1.Day.ToString("00"), "TBLMONTHSHIFT", "EMP_ID=N'"
                + EMP_ID + "' and YYY_MM=N'" + d1.ToString("yyyyMM") + "'", con);
            if (Shift + "" == "")
                return null;
            return Shift;
        }

        public void AttStaff(string EMP_ID, DateTime d1, SqlConnection con, string DEP_ID, string EMP_I1)
        {
            string sql = "";
            //NhuY: Khong xoa du lieu trong qua trinh chuyen
            sql = "Select EMP_ID from TBLDETAILSATTENDANCE where EMP_ID=N'" + EMP_ID + "' and ATT_DT='" + d1.ToString("yyyy/MM/dd") + "' AND (LOC_BT=1 OR LOC_B1=1)";
            RecordSet rs = new RecordSet(sql, con);
            if (rs.rows > 0)
                return;
            //NhuY.

            string Shift = GetShift(EMP_ID, d1, con);
            if (Shift == null)
            {
                InsertNoShift(EMP_ID, "NoShift", d1, con, DEP_ID, EMP_I1);
                return;
            }
            sql = "Select b.*, a.NIG_SH from TBLROSTER a LEFT JOIN TBLDETAILSROSTER b ON b.SHI_ID=a.SHI_ID where b.SHI_ID=N'" + Shift + "' ORDER BY b.SEQ_NO";
            RecordSet rsca = new RecordSet(sql, con);
            //var _rsca
            if (Shift == "00" && rsca.rows <= 0)
            {
                InsertNoShift(EMP_ID, "00", d1, con, DEP_ID, EMP_I1);
            }
            else
            {
                AttStaffByShift(EMP_ID, Shift, d1, con, DEP_ID, EMP_I1, rsca);
            }
        }

        private void InsertNoShift(string EMP_ID, string SHI_NM, DateTime d1, SqlConnection con, string DEP_ID, string EMP_I1)
        {
            //			string sql="Select CRD_TM,DAT_TM from FILC01A where EMP_ID=N'"+EMP_ID
            //				+ "' and CRD_DT='"+d1.ToString("yyyy/MM/dd")+"' and (YSD_BT is null or YSD_BT=0)"
            //				+ " and CRD_NO NOT IN (" + NoneReader + ")"
            //				+ " ORDER BY CRD_TM ";
            //			Func.RecordSet rsdata=new Func.RecordSet(sql,con);

            string values = "", Insert = "";
            Insert = "Insert Into [" + table + "](EMP_ID,ATT_DT,DEP_ID,EMP_I1,SHI_ID,NIG_TM,"
                + "ONN_01,OFF_01,ONN_02,OFF_02,ONN_03,OFF_03,ONN_04,OFF_04,ONN_05,OFF_05"
                + ") Values";

            values = "N'" + EMP_ID + "',"
                + "'" + d1.ToString("yyyy/MM/dd") + "',N'" + DEP_ID + "',N'" + EMP_I1 + "',"
                + "N'" + SHI_NM + "',-1";
            for (int i = 1; i <= 5; i++)
            {
                //				if((i*2)-2>=rsdata.rows)					
                //					values+=",0";
                //				else
                //					values+=","+rsdata.record((i*2)-2,"CRD_TM");	
                //				if((i*2)-1>=rsdata.rows)					
                //					values+=",0";
                //				else
                //					values+=","+rsdata.record((i*2)-1,"CRD_TM");
                values += ",0,0";
            }
            string sql = Insert + "(" + values + ")";
            try
            {
                PublicFunction.SQL_Execute(sql, con);
            }
            catch (SqlException ex)
            {
                err += ex.Message + "\r\nInsertNoShift\r\n" + sql;
            }
        }

        private void AttStaffByShift(string EMP_ID, string SHI_ID, DateTime d1, SqlConnection con, string DEP_ID, string EMP_I1, RecordSet rsca)
        {
            double MIN = T_String.IsNullTo0(T_String.GetDataFromSQL("MIN_HR", "TBLROSTER", "SHI_ID=N'" + SHI_ID + "'", con));
            double MAX = T_String.IsNullTo0(T_String.GetDataFromSQL("MAX_HR", "TBLROSTER", "SHI_ID=N'" + SHI_ID + "'", con));

            string sql = "Select CRD_TM"
                + " from TBLCARDDATA a"
                + " where EMP_ID=N'" + EMP_ID + "' and (CRD_DT='" + d1.ToString("yyyy/MM/dd") + "'"
                + " AND CRD_TM>=" + MIN;

            if (MAX >= MIN && MAX <= 2400)
                sql += " and CRD_TM <" + MAX + ")";
            else
            {
                sql += " OR CRD_DT='" + d1.AddDays(1).ToString("yyyy/MM/dd") + "' AND CRD_TM<"
                    + (MAX > 2400 ? MAX - 2400 : MAX) + ")";
            }

            sql += " AND REA_NO NOT IN ('" + NoneReader + "')"

                //NhuY 2017-08-05: xét khoảng cách giữa 2 lần quẹt thẻ
                + " AND NOT EXISTS"
                + " (SELECT 1 FROM TBLCARDDATA aa WHERE aa.CRD_DT=a.CRD_DT AND aa.CRD_NO=a.CRD_NO AND aa.CRD_TM<>a.CRD_TM"
                + " AND DATEDIFF(Minute, (DATEADD(Minute, CAST(aa.CRD_TM AS INT) / 100 *60 + CAST(aa.CRD_TM AS INT) % 100, aa.CRD_DT)),"
                + " DATEADD(Minute, CAST(a.CRD_TM AS INT) / 100 *60 + CAST(a.CRD_TM AS INT) % 100, a.CRD_DT))"
                + " BETWEEN 0 AND " + CRD_MN + " AND REA_NO NOT IN ('" + NoneReader + "'))"

                + " ORDER BY CRD_DT, (Case When CRD_TM=2400 Then 0 Else CRD_TM End)";

            RecordSet rsdata = new RecordSet(sql, con);
            if (rsca.rows <= 0)
                return;
            ArrayList Ca = new ArrayList();
            ArrayList ATT = new ArrayList();
            double maxca = 0;
            int cadem = 0;
            for (int i = 0; i < rsca.rows; i++)
            {
                Ca.Add(rsca.record(i, "ONN_TM"));
                Ca.Add(rsca.record(i, "OFF_TM"));
                double c1 = IsN(rsca.record(i, "ONN_TM"));
                double c2 = IsN(rsca.record(i, "ONN_TM"));
                if (cadem == 0 && (rsca.record(i, "TYP_ID") == "ATT_HR" || rsca.record(i, "TYP_ID") == "NIG_HR"))
                {
                    if (c1 > maxca)
                        maxca = c1;
                    else
                        cadem = 1;
                    if (c2 > maxca)
                        maxca = c2;
                    else
                        cadem = 1;
                }
            }
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            Ca.Add(0);
            int dem = 0;// vi tri quet
            int tg = 0;
            int count = 0; //so lan quet the
            int tcqd = 0;
            double NIG_TM = 0;
            double OVOT = T_String.IsNullTo0(T_String.GetDataFromSQL("MAX_HR", "FILC02A", "SHI_ID=N'" + SHI_ID + "'", con));

            while ((dem < Ca.Count || tg < rsdata.rows) && tg < rsdata.rows)
            {
                if (tg == rsdata.rows && rsca.record(0, "NIG_SH") + "" != "True")
                    break;

                int t1 = IsN(rsdata.record(tg, "CRD_TM"));
                //				string DAT_TM=rsdata.record(tg,"DAT_TM");
                string DAT_TM = "0";
                int t2 = IsN(rsdata.record(tg + 1, "CRD_TM"));
                int c1 = IsN(Ca[dem] + "");
                int c2;
                if (OVOT != 0 && tcqd > 0 && OVOT < t1)
                    break;
                if (dem + 1 < Ca.Count)
                    c2 = IsN(Ca[dem + 1] + "");
                else
                    c2 = IsN(Ca[dem] + "");
                if (t1 == c1 || (dem + 1) == Ca.Count || c1 == 0)  // dung thoi gian
                {
                    //if(rsdata.rows<=tg+1 && (dem%2)==0 && (count%2)==1  && count!=0 && ( t2>c1 || t2==0) )
                    if ((ATT.Count % 2) != (count % 2))
                    {
                        ATT.Add(0);
                        dem++;
                    }
                    ATT.Add(t1);
                    NIG_TM = TangQuaDem(EMP_ID, DAT_TM, tcqd, con, t1, NIG_TM, ATT);
                    count++;
                    dem++;
                    tg++;
                    //					tg += CardData_MoveNext(rsdata, tg);
                }
                else
                {
                    if (t1 < c1) // < kiem tra thoi gian crd ke tiep [di som]
                    {
                        if ((ATT.Count % 2) != (count % 2))
                        {
                            ATT.Add(0);
                            dem++;
                        }
                        //ATT.Add(t1);
                        ATT.Add((t1 == 0 ? 2400 : t1));	//NhuY
                        NIG_TM = TangQuaDem(EMP_ID, DAT_TM, tcqd, con, t1, NIG_TM, ATT);
                        count++;
                        dem++;
                        tg++;
                        //						tg += CardData_MoveNext(rsdata, tg);
                    }
                    else
                    {
                        if (Math.Abs(t1 - c1) < Math.Abs(t1 - c2)) // dung thoi gian
                        {
                            if (rsdata.rows <= tg + 1) // lan quet the cuoi trong ngay
                            {
                                if ((ATT.Count % 2) != (count % 2))
                                {
                                    ATT.Add(0);
                                    dem++;
                                }
                                ATT.Add(t1);
                                NIG_TM = TangQuaDem(EMP_ID, DAT_TM, tcqd, con, t1, NIG_TM, ATT);
                                count++;
                                dem++;
                                tg++;
                                //								tg += CardData_MoveNext(rsdata, tg);
                            }
                            else
                            {
                                if ((ATT.Count % 2) != (count % 2))
                                {
                                    ATT.Add(0);
                                    dem++;
                                }
                                ATT.Add(t1);
                                NIG_TM = TangQuaDem(EMP_ID, DAT_TM, tcqd, con, t1, NIG_TM, ATT);
                                count++;
                                dem++;
                                tg++;
                                //								tg += CardData_MoveNext(rsdata, tg);
                            }
                        }
                        else // kiem tra  tg ca ke tiep
                        {
                            if (dem < rsca.rows)
                            {
                                int k = ((int)(dem / 2));
                                string h = "ONN_BT";
                                if (dem % 2 != 0)
                                    h = "OFF_BT";
                                if (rsca.record(k, h) == "True")
                                    ATT.Add(0);
                            }
                            dem++;
                        }
                    }
                }

                if (rsdata.rows <= tg && tcqd == 0) // tinh qua dem
                {
                    if ((count % 2) == 1 || cadem == 1) // qua dem
                    {
                        int d = 0, dd = dem;
                        while (d < Ca.Count)
                        {
                            int m1 = IsN(Ca[d] + "");
                            int m2;
                            if (d + 1 < Ca.Count)
                                m2 = IsN(Ca[d + 1] + "");
                            else
                                m2 = IsN(Ca[d] + "");
                            if (m2 != 0 && m2 < m1)
                            {
                                d++;
                                dd = d;
                                break;
                            }
                            d++;
                        }
                    }
                }
            }

            string values = "", Insert = "";
            Insert = "Insert Into [" + table + "](EMP_ID,ATT_DT,DEP_ID,EMP_I1,SHI_ID,NIG_TM,"
                + "ONN_01,OFF_01,ONN_02,OFF_02,ONN_03,OFF_03,ONN_04,OFF_04,ONN_05,OFF_05"
                + ") Values";

            values = "N'" + EMP_ID + "',"
                + "'" + d1.ToString("yyyy/MM/dd") + "',N'" + DEP_ID + "',N'" + EMP_I1 + "',"
                + "N'" + SHI_ID + "','" + NIG_TM + "'";
            for (int i = 1; i <= 5; i++)
            {
                if ((i * 2) - 2 >= ATT.Count)
                    values += ",0";
                else
                    values += "," + ATT[(i * 2) - 2];
                if ((i * 2) - 1 >= ATT.Count)
                    values += ",0";
                else
                    values += "," + ATT[(i * 2) - 1];
            }
            sql = Insert + "(" + values + ")";

            try
            {
                PublicFunction.SQL_Execute(sql, con);
            }
            catch (SqlException ex)
            {
                err += ex.Message + "\r\nAttStaffByShift\r\n";
            }

            //var _rsca = _db.Tbldetailsroster.Where(x => x.ShiId == SHI_ID).ToList();
            //var _rsTypeShift = _db.Tbltypeshift.ToList();
            AttendanceHelperO tm = new AttendanceHelperO(EMP_ID, d1.ToString("yyyy/MM/dd"), con, Ca, ATT, SHI_ID, rsca, Set, rsTypeShift);
            tm.tb = table;
            tm.NIG_TM = NIG_TM;
            //tm.rsType=rsType;
            tm.UpdateSql();
        }


        



        private double TangQuaDem(string EMP_ID, string DAT_TM, int tcqd, SqlConnection con, double t1, double NIG_TM, ArrayList att)
        {
            if (tcqd > 0)
            {
                //				string sql="Update FILC01A set YSD_BT=1 where EMP_ID=N'"+EMP_ID+"' and DAT_TM=N'"+DAT_TM+"'";
                //				PublicFunction.SQL_Execute(sql,con);

                if (NIG_TM == 0)
                    return att.Count;
                else
                    return 0;
            }
            return 0;
        }

        public int IsN(Object st1)
        {
            try
            {
                string st = st1 + "";
                if (st + "" == "")
                    return 0;
                return Int32.Parse(st = st.Replace(",", ""));
            }
            catch (Exception) { return 0; }
        }

        public Double IsD(Object st1)
        {
            try
            {
                string st = st1 + "";
                if (st + "" == "")
                    return 0;
                return Double.Parse(st = st.Replace(",", ""));
            }
            catch (Exception) { return 0; }
        }
    }
}
