using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Admin.Models.CommonViewModel;

namespace WebApplication8.Helper
{
    public class CardDataSwitchHelper
    {
        public string NONE_READER = "";
        private float MAX_OT_WEEK, MAX_OT_YEAR; //Dung cho han che tang ca trong GPS
        public int numTransfered = 0;
        private RecordSet Set, rsTypeShift, rsType;
        private Boolean Stop;
        #region Transfer
        int vat = 0;
        int s = 0;
        int p = 0;
        int h = 0;
        RecordSet rs;
        public string table,err;
        public DateTime dt1, dt2;
        public CrtConditionViewModel crtCondition1;
        public void Transfer()
        {
            //vat = T_String.GetMax("MAX(SEQ_NO)", "FILC10A");
            Stop = false;
            table = "TBLDETAILSATTENDANCE_" + "UserLoginTemp";
            //--Neu chuyen tiep -->
            string sql;
            if (numTransfered == 0)
            {
                sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name=N'" + table + "' AND type='U') Drop Table [" + table + "]";
                PublicFunction.SQL_Execute(sql, PublicFunction.C_con, 180);
                PublicFunction.Copy_Table("TBLDETAILSATTENDANCE", table, PublicFunction.C_con);
            }
            //<--

            Set = new RecordSet("Select * from TBLATTSYSSETTING", PublicFunction.C_con);
            rsType = new RecordSet("Select TYP_ID,ROU_DR from TBLTYPESHIFT", PublicFunction.C_con);
            CheckFieldName();

            DateTime d1 = dt1;
            DateTime d2 = dt2;
            //sql = "Select a.EMP_ID,a.EMP_I1,EMP_NM,DEP_ID,CONVERT(NVARCHAR(10),VAC_DT,111) VAC_DT,"
            //    + "CONVERT(NVARCHAR(10),INH_DT,111) INH_DT,CRD_NO from FILB01A  a Left JOIN  FILB01AC b on a.EMP_ID=b.EMP_ID where "
            //    + crtCondition1.GetWhere("a", false) + " and ATT_BT=1 and (VAC_DT is null or VAC_DT>='" + d1.ToString("yyyy/MM/dd") + "') and INH_DT is not null";
            sql = "Select a.EMP_ID,a.EMP_I1,EMP_NM,DEP_ID, null VAC_DT,"
                + "CONVERT(NVARCHAR(10),INH_DT,111) INH_DT,CRD_NO from TBLEMPLOYEE  a"
                + " where "+ crtCondition1.GetWhere("a", false) + " and INH_DT is not null";

            rs = new RecordSet(sql, PublicFunction.C_con);

            //tm.Text = "00:00:00";
            s = 0;
            p = 0;
            h = 0;

            //timer1.Enabled = true;
            //timer1.Start();

            process();
        }
        private void CheckFieldName()
        {
            rsTypeShift = new RecordSet("Select * from TBLTYPESHIFT", PublicFunction.C_con);
        }

            private void process()
        {
            string sql = "";
            SqlConnection con1 = new SqlConnection(PublicFunction.connectionString + ";TimeOut=100");
            if (con1.State == ConnectionState.Closed)
                con1.Open();

            DateTime d1 = dt1;
            DateTime d2 = dt2;
            int ngay = 0;

            while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) <= T_String.IsNullTo0(d2.ToString("yyyyMMdd")))// tung Ngay
            {
                ngay++;
                d1 = d1.AddDays(1);
            }
            // sua theo ngay nghi
            d1 = dt1;
            d2 = dt2;

            int row = rs.rows;
            CardDataHelper ta = new CardDataHelper();
            ta.table = this.table;
            ta.NoneReader = NONE_READER;
            ta.err = err;
            ta.Set = Set;
            ta.rsTypeShift = rsTypeShift;

            int i = numTransfered;
            try
            {
                //cmd_Stop.Enabled = true;
                sql = "DELETE FROM [" + table + "] WHERE EMP_ID='" + rs.record(i, "EMP_ID") + "'";
                PublicFunction.SQL_Execute(sql, con1);

                for (i = numTransfered; i < row; i++)  // Tung Nhan Vien
                {
                    //if (Stop)
                    //{
                    //    control1.Enabled = dt1.Enabled = dt2.Enabled = true;
                    //    SaveCondition(i);
                    //    numTransfered = i;
                    //    cmd_Stop.Enabled = cmd_att.Enabled = cmd_close.Enabled = true;
                    //    return;
                    //}
                    DateTime INH_DT = DateTime.Parse(rs.record(i, "INH_DT") + "");
                    d1 = dt1;
                    d2 = dt2;
                    if (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) <= T_String.IsNullTo0(INH_DT.ToString("yyyyMMdd")))
                        d1 = INH_DT;
                    int dem = 1;

                    //sql = "SELECT SEQ_NO, CONVERT(NVARCHAR(10),SEQ_DT,111) SEQ_DT, EMP_ID, EMP_I3, EMP_I4, DEP_I1, DEP_I2"
                    //    + " FROM FILB03A WHERE  (SEQ_DT>'" + d1.ToString("yyyy/MM/dd")
                    //    + "' and EMP_ID=N'" + rs.record(i, "EMP_ID") + "') ORDER BY SEQ_DT ASC"; // doi bo phan
                    sql = "SELECT '0' SEQ_NO, null SEQ_DT, null EMP_ID, null EMP_I3, null EMP_I4, null DEP_I1, null DEP_I2 where 1=0";
                    RecordSet rs1 = new RecordSet(sql, con1);
                    int mm = 0;
                    // sua theo ngay nghi
                    int VAC = 0;
                    if (rs.record(i, "VAC_DT") + "" != "")
                        VAC = T_String.IsNullTo0(DateTime.Parse(rs.record(i, "VAC_DT") + "").ToString("yyyyMMdd"));

                    //NhuY: sua xoa nghi viec
                    if (VAC != 0 && VAC <= T_String.IsNullTo0(d2.ToString("yyyyMMdd")))
                    {
                        d2 = DateTime.Parse(rs.record(i, "VAC_DT") + "").AddDays(-1);
                        sql = "Delete from TBLDETAILSATTENDANCE where ATT_DT>='" + rs.record(i, "VAC_DT") + "' and EMP_ID=N'" + rs.record(i, "EMP_ID") + "'";
                        try
                        {
                            PublicFunction.SQL_Execute(sql, con1);
                        }
                        catch (SqlException ex)
                        {
                            err += ex.Message;
                        }
                    }

                    //NhuY.
                    while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) <= T_String.IsNullTo0(d2.ToString("yyyyMMdd")))// tung Ngay
                    {
                        //c1.Text = rs.record(i, "EMP_ID") + " - " + rs.record(i, "EMP_NM") + " - " + d1.ToString("yyyy/MM/dd");

                        int m;
                        for (m = mm; m < rs1.rows; m++)
                        {
                            if (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) < T_String.IsNullTo0(DateTime.Parse(rs1.record(m, "SEQ_DT")).ToString("yyyyMMdd")))
                            {
                                break;
                            }
                        }
                        mm = m;
                        //NhuY bỏ
                        //						sql="Update FILC01A set YSD_BT=0 where EMP_ID=N'"+rs.record(i,"EMP_ID")+"' and CRD_DT='"+d1.AddDays(1).ToString("yyyy/MM/dd")+"'";
                        //					
                        //						try
                        //						{
                        //							PublicFunction.SQL_Execute(sql,con1,60,true);
                        //							sql = "";
                        //						}
                        //						catch(SqlException ex)
                        //						{
                        //							err.Text+= ex.Message;
                        //						}

                        if (m >= rs1.rows)
                            ta.AttStaff(rs.record(i, "EMP_ID"), d1, con1, rs.record(i, "DEP_ID"), rs.record(i, "EMP_I1")); // ko thay doi bo phan
                        else
                            ta.AttStaff(rs.record(i, "EMP_ID"), d1, con1, rs1.record(mm, "DEP_I1"), rs1.record(mm, "EMP_I3")); // thay doi bo phan					
                        d1 = d1.AddDays(1);
                        //pro1.Value = (int)dem * 100 / ngay;
                        dem++;
                    }

                    d1 = dt1;
                    d2 = dt2;
                    dem = 1;
                    //absent to vacate
                    //while (T_String.IsNullTo0(d1.ToString("yyyyMMdd")) <= T_String.IsNullTo0(d2.ToString("yyyyMMdd")))// tung Ngay
                    //{
                    //    c1.Text = rs.record(i, "EMP_ID") + " - " + rs.record(i, "EMP_NM") + " - " + d1.ToString("yyyy/MM/dd");
                    //    TaAttendance.AbsentToVacate(rs.record(i, "EMP_ID"), d1.ToString("yyyy/MM/dd"), con1, table);
                    //    d1 = d1.AddDays(1);
                    //    dem++;
                    //}
                    //pro1.Value = 100;
                    //pro2.Value = (int)(i + 1) * 100 / row;
                    //c3.Text = (i + 1) + "/" + row + " - " + pro2.Value + "%";
                }

                //pro2.Value = 100;
                //Formula(con1);

                //c1.Text = PublicFunction.L_GetLabel(this.Name, 9);

                sql = "SET ROWCOUNT 1000 \r\n"
                    + "WHILE 1=1 \r\n"
                    + "BEGIN \r\n"
                    + "DELETE FROM TBLDETAILSATTENDANCE WHERE EXISTS (SELECT 1 FROM [" + table + "] WHERE EMP_ID=TBLDETAILSATTENDANCE.EMP_ID)"
                    + " AND ATT_DT BETWEEN '" + dt1.ToString("yyyy/MM/dd")
                    + "' AND '" + dt2.ToString("yyyy/MM/dd") + "' AND ISNULL(LOC_BT,0)=0 AND ISNULL(LOC_B1,0)=0 \r\n"
                    + " IF @@ROWCOUNT=0 BREAK \r\n"
                    + "END \r\n"
                    + "SET ROWCOUNT 0";
                PublicFunction.SQL_Execute(sql, con1, 200);

                //c1.Text = PublicFunction.L_GetLabel(this.Name, 10);
                sql = "Insert into TBLDETAILSATTENDANCE select * from [" + table + "] a"
                    + " WHERE NOT EXISTS (SELECT 1 FROM TBLDETAILSATTENDANCE b WHERE b.EMP_ID=a.EMP_ID AND b.ATT_DT=a.ATT_DT)";
                PublicFunction.SQL_Execute(sql, con1);
                File.Delete("att.txt");
                PublicFunction.SQL_Execute("DROP TABLE [" + table + "]", con1);

                ////K-TIME
                //if (PublicFunction.IsKTime("AD"))
                //{
                //    PublicFunction.SQL_Execute("DELETE FROM FILC06A WHERE ATT_DT>= '"
                //        + PublicFunction.LockDate.ToString("yyyy/MM/dd") + "'", con1);
                //}
                //--
            }

            catch (Exception ex)
            {
                err += ex.Message + "\r\nprocess\r\n";
            }

            ////control1.Enabled = dt1.Enabled = dt2.Enabled = true;
            //if (err.Text != "")
            //{
            //    SaveCondition(i);
            //    cmd_Stop.Text = PublicFunction.L_GetLabel(this.Name, 8);
            //    cmd_Stop.Tag = "";
            //    c1.Text = PublicFunction.L_GetLabel(this.Name, 13);
            //}
            //else
            //{
            //    cmd_Stop.Enabled = false;
            //    c1.Text = PublicFunction.L_Get_Msg("Staff", 1, con1);
            //}

            //cmd_att.Enabled = true;
            //cmd_close.Enabled = true;

            //timer1.Stop();
            //timer1.Enabled = false;
            con1.Close();

            //if (T_String.GetMax("MAX(SEQ_NO)", "FILC10A") > vat)
            //{
            //    frmTaAbsentVacate dlg = new frmTaAbsentVacate();
            //    dlg.Tag = this.Tag;
            //    dlg.ShowDialog();
            //}
        }
        #endregion
    }
}
