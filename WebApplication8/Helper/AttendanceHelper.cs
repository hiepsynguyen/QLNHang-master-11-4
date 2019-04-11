using DAL.QLNHangData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.QLNHangData.UtilModel;

namespace WebApplication8.Helper
{
    public class AttendanceHelper
    {
        public QLNhaHangContext _db = new QLNhaHangContext();
        public bool IsWorkShift;
        public ArrayList Ca;
        public ArrayList ATT;
        public string SHI_ID, EMP_ID, ATT_DT, NOT_DR, NOT_D1;
        public double LEA_H1;
        public string LEA_I1;
        public string NOT_DD;
        public double LEA_H2;
        public string LEA_I2;
        public double LEA_H3;
        public double OTR_HR;
        public string LEA_I3;
        public double NIG_TM;
        public string tb;
        public List<Tbldetailsroster> rsca;
        public List<Tbltypeshift> rsTypeShift;
        public Object SetTA;
        public ArrayList Name;
        public ArrayList Data;
        public SqlConnection con;
        public double LAT_MN = 0;
        public int LAT_TM = 0;
        public double EAR_MN = 0;
        public int EAR_TM = 0;

        public double LEA_OUT = 0;
        public double ABS_MN = 0, ASB_MN = 0;	//ABS_MN: số phút trễ/sớm xem như vắng
        public int ABS_TM = 0;

        public double ATT_MAX = 0;
        public double NIG_MAX = 0;

        public string ToDayDT;
        public DateTime ToDayDTTime = DateTime.Now;
        //public Func.RecordSet thaisan;
        public double giothaisan = 0, CON_MAN = 0;
        public Boolean Vacate = false;
        public string err = "";
        //public TextBox err;
        public AttendanceHelper(string EMP_ID, string ATT_DT, SqlConnection con, ArrayList Ca, ArrayList ATT, string SHI_ID, List<Tbldetailsroster> rsca, Object SetTA, List<Tbltypeshift> rsTypeShift) {
            this.EMP_ID = EMP_ID;
            this.ATT_DT = ATT_DT;
            this.con = con;
            this.Ca = Ca;
            this.ATT = ATT;
            this.SHI_ID = SHI_ID;
            this.rsca = rsca;
            this.SetTA = SetTA;
            this.rsTypeShift = rsTypeShift;

            ToDayDT = DateTime.Now.ToString("yyyy/MM/dd");

            IsWorkShift = true;
            if (_db.Tbldetailsroster.Where(x=>x.ShiId == rsca[0].ShiId && new string[] { "ATT_HR", "NIG_HR", "NIG_DB", "NIG_LM" }.Contains(x.TypId)).Count() == 0) {
                IsWorkShift = false;
            }

            NOT_DR = "";
            this.Data = new ArrayList();
            this.Name = new ArrayList();
            double tam = 0;
            for (int i = 0; i < rsTypeShift.Count(); i++)
            {
                Name.Add(rsTypeShift[i].TypId);
                Data.Add(tam);
            }
        }

        public AttendanceHelper() {

        }

        public void Add(string FName, double hr)
        {
            int i = Name.IndexOf(FName);
            Data[i] = T_String.CongTG(IsN(Data[i] + ""), hr);
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

        private Double maxmax = 0;
        public void Get_ATT_HR()
        {
            double ONN_MN = IsD(SYS_SETTING_ATT.ONN_MN);
            double OFF_MN = IsD(SYS_SETTING_ATT.OFF_MN);
            string ONN_BT = SYS_SETTING_ATT.ONN_BT;
            string OFF_BT = SYS_SETTING_ATT.OFF_BT;

            var phep = (from l in _db.Tblleave
                        join tl in _db.Tbltypeleave on l.LeaId equals tl.LeaId
                        where l.EmpId == EMP_ID && l.StrDt.Value.CompareTo(DateTime.Parse(ATT_DT)) <= 0
                        && l.EndDt.Value.CompareTo(DateTime.Parse(ATT_DT)) >= 0
                        select new ExLeave() {leave = l, leave_name = tl.LeaNm }).ToList();

            Boolean QD = false;
            double c = 0;
            for (int i = 0; i < rsca.Count(); i++)
            {

                double c1 = IsN(rsca[i].OnnTm); // gio vao
                double c2 = IsN(rsca[i].OffTm);	// gio ra					
                double MAX_HR1 = IsD(rsca[i].WrkHr);	// gio cong		


                if (c1 < c)// qua dem
                {
                    QD = true;
                }
                if (c2 < c1) // qua dem
                {
                    c2 = c2 + 2400;
                    QD = true;
                }
                else
                {
                    if (QD)
                    {
                        c2 = c2 + 2400;
                        c1 = c1 + 2400;
                    }
                }
                c = c2;
                if (rsca[i].TypId == "ATT_HR")
                {
                    if (MAX_HR1 > 0 && MAX_HR1 < T_String.TruTG(c2, c1))
                        ATT_MAX = T_String.CongTG(ATT_MAX, MAX_HR1);
                    else
                        ATT_MAX = T_String.CongTG(ATT_MAX, T_String.TruTG(c2, c1));
                }
                if (rsca[i].TypId == "NIG_HR")
                {
                    if (MAX_HR1 > 0 && MAX_HR1 < T_String.TruTG(c2, c1))
                        NIG_MAX = T_String.CongTG(NIG_MAX, MAX_HR1);
                    else
                        NIG_MAX = T_String.CongTG(NIG_MAX, T_String.TruTG(c2, c1));
                }
            }

            if (ATT.Count <= 0)
                return;


            ArrayList AT = new ArrayList();
            int dem = 0;
            for (int i = 0; i < ATT.Count; i++)
            {
                if (IsN(ATT[i] + "") != 0)
                {
                    double st = IsD(ATT[i] + "");
                    if (i >= NIG_TM - 1 && NIG_TM > 0 && QD == true)
                        st = st + 2400;
                    dem++;
                    AT.Add(st);
                    if (st > maxmax)
                        maxmax = st;
                }
            }

            if (dem % 2 == 1)
            {
                if (ATT_DT != ToDayDT)
                    NOT_DR = "Abnormal;";
                return;
            }

            QD = false;
            c = 0;
            for (int i = 0; i < rsca.Count(); i++)
            {
                double c1 = IsN(rsca[i].OnnTm); // gio vao
                double c2 = IsN(rsca[i].OffTm);	// gio ra
                double giothaisanIN = IsN(rsca[i].ManIn);
                double giothaisanOU = IsN(rsca[i].ManOu);
                int j = AT.Count - 1;
                if (c1 < c)// qua dem
                {
                    QD = true;
                }
                if (c2 < c1) // qua dem
                {
                    c2 = c2 + 2400;
                    QD = true;
                }
                else
                {
                    if (QD)
                    {
                        c2 = c2 + 2400;
                        c1 = c1 + 2400;
                    }
                }
                c = c2;
                while (j >= 0)
                {
                    double t2 = IsN(AT[j] + "");
                    j--;
                    double t1 = IsN(AT[j] + "");
                    j--;

                    if (t2 < t1) t2 = t2 + 2400; //NhuY

                    double a1, a2, a;
                    if (t2 > c1)
                    {
                        if (t1 > c1)
                        {
                            //if(ONN_BT=="True" &&  T_String.TruTG(t1,c1)<= ONN_MN )
                            if (ONN_BT == "True" && T_String.TruTG(t1, c1) < ONN_MN && (rsca[i].TypId == "ATT_HR" || rsca[i].TypId == "NIG_HR"))
                            {
                                a1 = c1;
                            }
                            else
                                a1 = t1;
                        }
                        else
                            a1 = c1;

                        if (t2 > c2)
                            a2 = c2;
                        else
                        {
                            //if(OFF_BT=="True" && T_String.TruTG(c2,t2)<= OFF_MN)
                            if (OFF_BT == "True" && T_String.TruTG(c2, t2) < OFF_MN && (rsca[i].TypId == "ATT_HR" || rsca[i].TypId == "NIG_HR"))
                            {
                                a2 = c2;
                            }
                            else
                                a2 = t2;
                        }
                        if (a2 > a1)
                        {
                            a = GetHourAndPhep(a1, a2, phep.Select(x => x.leave).ToList());//T_String.TruTG(a2,a1);
                            //a = 0;
                            double MAX_HR = IsD(rsca[i].WrkHr);	// gio cong
                            double MIN_ST = IsD(rsca[i].MinSt);	// MIN_ST
                            if (MIN_ST == 0 || MIN_ST <= a) // lam tren bao nhieu phut moi tinh
                            {
                                if (MAX_HR < a && MAX_HR > 0)   // thoi gian lam viec toi da
                                    Add(rsca[i].TypId, MAX_HR);
                                else
                                    Add(rsca[i].TypId, a);
                            }
                        }
                    }
                }
            }

        }

        public double GetHourAndPhep(double t3, double t4, List<Tblleave> phep)
        {
            double t1 = t3, t2 = t4;

            //for (int i = 0; i < phep.rows; i++)
            if (phep.Count() > 0)
            {
                double c1 = IsN(phep[0].StrTm); // gio vao
                double c2 = IsN(phep[0].EndTm);	// gio ra
                if (c2 < c1)
                    c2 = T_String.CongTG(c2, 2400.0);
                else
                {
                    if ((t1 >= 2400 || t2 >= 2400) && (t1 > c1 && t1 > c2))
                    {
                        c1 = T_String.CongTG(c1, 2400.0);
                        c2 = T_String.CongTG(c2, 2400.0);
                    }
                }

                //Nằm ngoài phép
                if (t1 > c2 || t2 < c1)
                    return T_String.TruTG(t2, t1);

                //Tr/hợp cả 2 nằm trong phép
                if (t1 >= c1 && t2 <= c2)
                    return 0;

                //Có giao với phép
                double tong = 0;
                if (t1 < c1)
                    tong = T_String.TruTG(c1, t1);

                if (t2 > c2)
                    tong += T_String.TruTG(t2, c2);

                return tong;
            }

            return T_String.TruTG(t2, t1);
        }

        public void GetPhep(List<ExLeave> phep)
        {
            //Nếu ko là ca làm việc thì ko cần xét phép
            if (!IsWorkShift) return;

            for (int i = 0; i < phep.Count(); i++)
            {
                if (LEA_I1 + "" == "")
                {
                    LEA_I1 = phep[i].leave.LeaId;
                    LEA_H1 = T_String.DT_HourConvertToHourMin(IsD(phep[i].leave.HouDy));

                    ////Xử lý cho Primacy, Bowker
                    //if (PublicFunction.CUS_ID == "99" || PublicFunction.CUS_ID == "100")
                    //    NOT_DR += LEA_H1 / 100 + phep.record(i, "LEA_NM") + ";";
                }
                else
                {
                    if (LEA_I2 + "" == "")
                    {
                        LEA_I2 = phep[i].leave.LeaId;
                        LEA_H2 = T_String.DT_HourConvertToHourMin(IsD(phep[i].leave.HouDy));
                        
                    }
                    else
                    {
                        LEA_I3 = phep[i].leave.LeaId;
                        LEA_H3 = T_String.DT_HourConvertToHourMin(IsD(phep[i].leave.HouDy));
                        
                    }
                }
                //if (PublicFunction.CUS_ID != "99" && PublicFunction.CUS_ID != "100")
                    NOT_DR += phep[i].leave_name + ";";
            }
        }

        public void GetNote()
        {
            double cc = IsN(rsca[0].OnnTm);
            if (T_String.IsNullTo00(ToDayDTTime.ToString("yyyyMMddHHmm"))
                < T_String.IsNullTo00(DateTime.Parse(ATT_DT).ToString("yyyyMMdd") + cc.ToString("0000")))
                return;
            double ONN_MN = IsD(SYS_SETTING_ATT.ONN_MN);
            double OFF_MN = IsD(SYS_SETTING_ATT.OFF_MN);
            ASB_MN = IsD(SYS_SETTING_ATT.ABS_MN);
            int index = -1;
            var phep = (from l in _db.Tblleave
                                   join tl in _db.Tbltypeleave on l.LeaId equals tl.LeaId
                                   where l.EmpId == EMP_ID && l.StrDt.Value.CompareTo(DateTime.Parse(ATT_DT)) <= 0
                                   && l.EndDt.Value.CompareTo(DateTime.Parse(ATT_DT)) >= 0
                                   select new ExLeave() { leave = l, leave_name = tl.LeaNm }).ToList();
            var phep_l = phep.Select(x => x.leave).ToList();
            if (phep.Count() > 0 && phep[0].leave.DayBt + "" == "True")
            {
                return;
            }

            LEA_OUT = T_String.CongTG(OTR_HR, LEA_OUT);
            LEA_OUT = T_String.CongTG(OTR_HR, LEA_H1);
            LEA_OUT = T_String.CongTG(OTR_HR, LEA_H2);
            LEA_OUT = T_String.CongTG(OTR_HR, LEA_H3);

            Double tt = T_String.CongTG(ATT_MAX, NIG_MAX);
            if (LEA_OUT >= tt && tt > 0)
                return;

            if (NOT_DR.IndexOf("Abnormal") >= 0)
                return;

            double m = 0, max = 0, min = 0, m1 = 0;//m1 so lan quet the , m= la thoi gian quet the truoc do

            double c = 0;
            Boolean QD = false;
            for (int j = 0; j < ATT.Count; j++)  // thoi gian quet the
            {
                double t1 = IsN(ATT[j] + "");

                if (j > 0 && t1 < IsN(ATT[j - 1]) && IsN(ATT[j]) > 0) t1 = t1 + 2400;

                if (t1 != 0)
                {
                    if (t1 > max)
                    {
                        max = t1;
                    }

                    m = t1;
                    m1 = j;
                    if (min == 0)
                        min = t1;
                }
                c = 0;
                QD = false;
                for (int i = 0; i < rsca.Count(); i++)  // chay theo ca
                {
                    double c01 = -1;
                    if (i >= 1)
                        c01 = IsN(rsca[i - 1].OffTm); // gio vao
                    double c1 = IsN(rsca[i].OnnTm); // gio vao
                    double c2 = IsN(rsca[i].OffTm);	// gio ra
                    double giothaisanIN = IsN(rsca[i].ManIn);
                    double giothaisanOU = IsN(rsca[i].ManOu);
                    if (c1 < c)// qua dem
                    {
                        QD = true;
                    }
                    if (c2 < c1) // qua dem
                    {
                        c2 = c2 + 2400;
                        QD = true;
                    }
                    else
                    {
                        if (QD)
                        {
                            c2 = c2 + 2400;
                            //c1=c2+2400;
                            c1 = c1 + 2400; //NhuY
                        }
                    }
                    c = c2;
                    if (giothaisan > 0)
                    {
                        c1 = (giothaisanIN > 0 ? giothaisanIN : c1);
                        c2 = (giothaisanOU > 0 ? giothaisanOU : c2);
                    }

                    if (rsca[i].LatBt + "" == "True" && (rsca[i].TypId == "ATT_HR" || rsca[i].TypId == "NIG_HR"))
                    {
                        if (j % 2 == 0 && t1 <= c1)// Late
                        {
                            break;
                        }
                        if ((j % 2 == 0 && t1 < c2 && t1 > c1) || (min != 0 && t1 == min)) // Late  | (min!=0 && t1==min) | gio vao dau tien
                        {
                            if ((T_String.CongTG(c1, ASB_MN)) <= t1 && ASB_MN != 0)
                            {
                                if (phep.Count() > 0 /*|| OutTrip.rows > 0*/)
                                {
                                    if (phep.Count() > 0 && phep[i].leave.DayBt + "" == "True")
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        //if (!CheckPhep(t1, phep, j) && !(CheckPhep(c1, phep, j) && (min != 0 && t1 == min)))
                                        if (!CheckPhep(t1, phep_l, j) && (min != 0 && t1 == min))
                                        {
                                            //if (!CheckPhep(t1, OutTrip, j) && !(CheckPhep(c1, OutTrip, j) && (min != 0 && t1 == min)))//Xét công tác: bỏ, vì ko sử dụng chức năng này
                                            {
                                                NOT_DR += "Absent" + ";";
                                                //GetPhep(phep);
                                                NOT_D1 += j.ToString("00");
                                                ABS_TM++;

                                                EAR_TO_ABS();
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    NOT_DR += "Absent" + ";";
                                    //GetPhep(phep);
                                    NOT_D1 += j.ToString("00");
                                    ABS_TM++;

                                    EAR_TO_ABS();
                                    return;
                                }
                            }
                            if (T_String.CongTG(c1, ONN_MN) <= t1)
                            {
                                if (!CheckPhep(t1, phep_l, j) && !(CheckPhep(c1, phep_l, j) && (min != 0 && t1 == min)))
                                {
                                    //if (/*!CheckPhep(t1, OutTrip, j) &&*/ !(/*CheckPhep(c1, OutTrip, j) &&*/ (min != 0 && t1 == min)))
                                    //{
                                        Double LT = GetHourAndPhep(c1, t1, phep_l);
                                        if (t1 > c2)
                                            LT = GetHourAndPhep(c1, c2, phep_l);
                                        else
                                            LT = GetHourAndPhep(c1, t1, phep_l);
                                        Note("Late" + ";");
                                        NOT_D1 += j.ToString("00");
                                        LAT_MN = T_String.CongTG(LT, LAT_MN);
                                        LAT_TM++;
                                    //}
                                }
                            }
                        }
                        if (j % 2 == 1 && t1 > c1 && t1 < c2) // early   cu Tan doi
                        {
                            if (T_String.CongTG(t1, OFF_MN) <= c2)
                            {

                                if (!CheckPhep(t1, phep_l, j))
                                {
                                    //if (!CheckPhep(t1, OutTrip, j))
                                    //{
                                        index = i;
                                        Double EA = GetHourAndPhep(t1, c2, phep_l);
                                        Note("Early" + ";");
                                        NOT_D1 += j.ToString("00");
                                        EAR_MN = T_String.CongTG(EA, EAR_MN);
                                        EAR_TM++;

                                        EAR_TO_ABS();
                                        return;
                                    //}
                                }
                            }
                            break;
                        }
                    }
                }
            }

            if (m == 0) // neu ko quet the gi het
            {
                double t1;
                if (ATT.Count == 0)
                    t1 = 0;
                else
                    t1 = IsN(ATT[0] + "");

                //				//NhuY: Neu la ca cn hoac le thi ko xet absent
                //				if(phep.record(0,"DAY_BT")+""=="True" || T_String.GetDataFromSQL("COUNT(*)", "FILC02B", 
                //					"SHI_ID=N'" + rsca.record(0, "SHI_ID") + "' AND (TYP_ID='ATT_HR' OR TYP_ID='NIG_HR')")=="0")
                //				{
                //					return;
                //				}			
                //NhuY: Neu la ca cn hoac le thi ko xet absent
                if (phep_l[0].DayBt + "" == "True" || !IsWorkShift)
                {
                    return;
                }
                else // ko quet the
                {
                    if (phep.Count() <= 0 /*&& OutTrip.rows <= 0*/)
                    {
                        NOT_DR += "Absent" + ";";
                        //GetPhep(phep);
                        ABS_TM++;
                        return;
                    }
                    Boolean QD1 = false;
                    c = 0;
                    for (int i = 0; i < rsca.Count(); i++)
                    {
                        double c1 = IsN(rsca[i].OnnTm); // gio vao
                        double c2 = IsN(rsca[i].OffTm);	// gio ra
                        double giothaisanIN = IsN(rsca[i].ManIn);
                        double giothaisanOU = IsN(rsca[i].ManOu);
                        if (c1 < c)// qua dem
                        {
                            QD1 = true;
                        }
                        if (c2 < c1) // qua dem
                        {
                            c2 = c2 + 2400;
                            QD1 = true;
                        }
                        else
                        {
                            if (QD1)
                            {
                                c2 = c2 + 2400;
                                c1 = c2 + 2400;
                            }
                        }
                        c = c2;
                        if (giothaisan > 0)
                        {
                            //							c1=T_String.CongTG(c1,giothaisanIN);
                            //							c2=T_String.TruTG(c2,giothaisanOU);
                            //NhuY 2017/03/28
                            c1 = (giothaisanIN > 0 ? giothaisanIN : c1);
                            c2 = (giothaisanOU > 0 ? giothaisanOU : c2);
                        }
                        if (rsca[i].LatBt + "" == "True" || (rsca[i].TypId == "ATT_HR" || rsca[i].TypId == "NIG_HR"))
                        {
                            if (phep.Count() > 0 /*|| OutTrip.rows > 0*/)
                            {
                                if (!CheckPhep(c1, phep_l, 0))
                                {
                                    //if (!CheckPhep(c1, OutTrip, 0))
                                    //{
                                        NOT_DR += "Absent" + ";";
                                        //GetPhep(phep);
                                        ABS_TM++;
                                        NOT_D1 = "00";

                                        EAR_TO_ABS();
                                        return;
                                    //}
                                }
                                if (!CheckPhep(c2, phep_l, 0))
                                {
                                    //if (!CheckPhep(c2, OutTrip, 0))
                                    //{
                                        NOT_DR += "Absent" + ";";
                                        //GetPhep(phep);
                                        ABS_TM++;
                                        NOT_D1 = "00";

                                        EAR_TO_ABS();
                                        return;
                                    //}
                                }
                            }
                        }
                    }

                }
            }
            else // co quet the kiem tra xem co phai chuyen du lieu ngay hien tai ko
            {
                if (ATT_DT != ToDayDT)
                {
                    QD = false;
                    for (int i = rsca.Count() - 1; i >= 0; i--)
                    {
                        if (rsca[i].LatBt + "" == "True" || (rsca[i].TypId == "ATT_HR" || rsca[i].TypId == "NIG_HR"))
                        {
                            double c1 = IsN(rsca[i].OnnTm); // gio vao
                            double c2 = IsN(rsca[i].OffTm);	// gio ra		
                            double giothaisanIN = IsN(rsca[i].ManIn);
                            double giothaisanOU = IsN(rsca[i].ManOu);
                            if (QD)
                            {
                                if (c1 > c2)
                                {
                                    c2 = c2 + 2400;
                                    QD = true;
                                }
                                else
                                {
                                    c2 = c2 + 2400;
                                    c1 = c1 + 2400;
                                }
                            }

                            if (giothaisan > 0)
                            {
                                //								c1=T_String.CongTG(c1,giothaisanIN);
                                //								c2=T_String.TruTG(c2,giothaisanOU);
                                //NhuY 2017/03/28
                                c1 = (giothaisanIN > 0 ? giothaisanIN : c1);
                                c2 = (giothaisanOU > 0 ? giothaisanOU : c2);
                            }

                            //
                            if (max > c1 + 2400 && max > c2 + 2400)
                                max -= 2400;

                            if (index + 1 <= i)
                            {
                                double max11 = 0;
                                if (max < c1)
                                    max11 = c1;
                                else
                                    max11 = max;

                                if (T_String.CongTG(max11, OFF_MN) <= c2) // max la gio quet the sau cung
                                {
                                    if (!CheckPhep(max11, phep_l, 0))
                                    {
                                        //if (!CheckPhep(max11, OutTrip, 0))
                                        //{
                                            Double v1 = 0, v2 = c2;
                                            if (max11 >= c1)
                                            {
                                                v1 = max11;
                                            }
                                            else
                                            {
                                                v1 = c1;
                                            }

                                            Double EA = GetHourAndPhep(v1, v2, phep_l);
                                            //											if(T_String.CongTG(EA,OFF_MN)<0)// thai san
                                            //											{
                                            Note("Early" + ";");
                                            //NOT_D1+=i.ToString("00");
                                            EAR_MN = T_String.CongTG(EA, EAR_MN);
                                            EAR_TM++;
                                            //	}											
                                        //}
                                    }
                                }
                            }
                            else
                            {
                                if (index + 1 > i)
                                    break;
                            }
                        }
                    }
                }
            }

            EAR_TO_ABS();

            //			//NhuY (2017/02/07): xét quy định số phút vắng
            //			if (EAR_MN >= ABS_MN)
            //			{
            //				ABS_TM = 1;
            //				EAR_MN = EAR_TM = 0;
            //
            //				if (NOT_DR.IndexOf("Absent") >= 0)
            //					NOT_DR = NOT_DR.Replace("Early;", "");
            //				else
            //					NOT_DR = NOT_DR.Replace("Early", "Absent");
            //			}


        }

        public Boolean CheckPhep(double t1, List<Tblleave> phep, int j)
        {
            double t = t1;

            for (int i = 0; i < phep.Count(); i++)
            {
                double c1 = IsN(phep[i].StrTm); // gio vao
                double c2 = IsN(phep[i].EndTm);	// gio ra	
                if (c2 < c1)
                    c2 = T_String.CongTG(c2, 2400.0);
                else
                {
                    if ((t1 >= 2400) && (t1 > c1 && t1 > c2))
                    {
                        c1 = T_String.CongTG(c1, 2400.0);
                        c2 = T_String.CongTG(c2, 2400.0);
                    }
                }
                if (c1 <= t && c2 >= t)
                {
                    return true;
                }
            }
            return false;
        }

        public void Note(string st)
        {
            //			if(thaisan.rows<=0)
            //			{
            if (NOT_DR.IndexOf(st) < 0)
                NOT_DR += st;
            //			}
        }

        private void EAR_TO_ABS()
        {
            //NhuY (2017/02/07): xét quy định số phút vắng
            if (ASB_MN > 0 && EAR_MN >= ASB_MN)
            {
                ABS_TM = 1;
                EAR_MN = EAR_TM = 0;

                if (NOT_DR.IndexOf("Absent") >= 0)
                    NOT_DR = NOT_DR.Replace("Early;", "");
                else
                    NOT_DR = NOT_DR.Replace("Early", "Absent");
            }
        }

        public void UpdateSql()
        {
            string sql1 = "";
            string sql = "";
            Get_ATT_HR();
            var phep = (from l in _db.Tblleave
                        join tl in _db.Tbltypeleave on l.LeaId equals tl.LeaId
                        where l.EmpId == EMP_ID && l.StrDt.Value.CompareTo(DateTime.Parse(ATT_DT)) <= 0
                        && l.EndDt.Value.CompareTo(DateTime.Parse(ATT_DT)) >= 0
                        select new ExLeave() { leave = l, leave_name = tl.LeaNm }).ToList();
            GetPhep(phep);
            //Round();
            GetNote();

            var roster = _db.Tblroster.Where(x => x.ShiId == SHI_ID).FirstOrDefault();

            double ADD_H1 = T_String.IsNullTo00(roster.AddH1 + "");
            double ADD_H2 = T_String.IsNullTo00(roster.AddH2 + "");
            double CON_H1 = T_String.IsNullTo00(roster.ConH1 + "");
            double CON_H2 = T_String.IsNullTo00(roster.ConH2 + "");


            if (NOT_DD + "" != "")
                NOT_DR = NOT_DD + "; " + NOT_DR;

            var _tdt = DateTime.Parse(ATT_DT);
            var att = _db.Tbldetailsattendance.Where(x => x.AttDt == _tdt && x.EmpId == EMP_ID).FirstOrDefault();
            if (att == null)
                return;
            sql = "Update [" + tb + "] set ";
            double WRK_HR = 0;
            for (int i = 0; i < Name.Count; i++)
            {
                switch (Name[i] + "")
                {
                    case "ATT_HR":
                        if (ATT_MAX > 0)
                        {
                            if (ADD_H1 > 0 && (Double)Data[i] > CON_H1)
                            {
                                ATT_MAX = T_String.CongTG(ATT_MAX, ADD_H1);
                                if ((Double)Data[i] > 0)
                                    Data[i] = T_String.CongTG(ADD_H1, (Double)Data[i]);
                            }

                            WRK_HR = T_String.CongTG(WRK_HR, (Double)Data[i]);//T_String.IsNullTo00(Data[i]+""));
                            int tam = (int)T_String.CongTG(T_String.IsNullTo0(Data[i] + ""), OTR_HR);
                            if (sql1 != "") sql1 += ",";
                            //var tmpa = T_String.DT_HourMinConvertToHour(tam);
                            //var tmpb = T_String.DT_HourMinConvertToHour((int)ATT_MAX);

                            sql1 += "ATT_DY=" + T_String.DT_HourMinConvertToHour(tam) / T_String.DT_HourMinConvertToHour((int)ATT_MAX);
                            T_String.SetPropValue(att, "AttDy", T_String.DT_HourMinConvertToHour(tam) / T_String.DT_HourMinConvertToHour((int)ATT_MAX));
                        }
                        else
                        {
                            if (sql1 != "") sql1 += ",";
                            sql1 += "ATT_DY=0";
                            T_String.SetPropValue(att, "AttDy", 0);
                        }
                        break;
                    case "NIG_HR":
                        if ((Double)Data[i] > CON_H2)
                        {
                            if (NIG_MAX > 0)
                            {
                                if (ADD_H2 > 0)
                                {
                                    NIG_MAX = T_String.CongTG(NIG_MAX, ADD_H2);
                                    if ((Double)Data[i] > 0)
                                        Data[i] = T_String.CongTG(ADD_H2, (Double)Data[i]);
                                }
                                WRK_HR = T_String.CongTG(WRK_HR, (Double)Data[i]);
                                int tam = (int)T_String.CongTG(T_String.IsNullTo0(Data[i] + ""), OTR_HR);
                                if (sql1 != "") sql1 += ",";
                                sql1 += "NigDy=" + T_String.DT_HourMinConvertToHour(tam) / T_String.DT_HourMinConvertToHour((int)NIG_MAX);
                                T_String.SetPropValue(att, "NigDy", T_String.DT_HourMinConvertToHour(tam) / T_String.DT_HourMinConvertToHour((int)NIG_MAX));
                            }
                            else
                            {
                                if (sql1 != "") sql1 += ",";
                                sql1 += "NIG_DY=0";
                                T_String.SetPropValue(att, "NigDy", 0);
                            }
                        }
                        break;
                    case "OTT_HR":
                    case "OVO_HR":
                        break;
                }
                if (sql1 != "") sql1 += ",";
                sql1 += Name[i] + "=" + Data[i];
                var _name = Regex.Replace((Name[i] + "").ToLower(), @"([a-z0-9]+)_([a-z0-9]+)",
                    m => string.Format("{0}{1}", 
                    Char.ToUpperInvariant(m.Groups[1].Value[0])+ m.Groups[1].Value.Substring(1),
                    Char.ToUpperInvariant(m.Groups[2].Value[0]) + m.Groups[2].Value.Substring(1))); /*(Name[i] + "").ToLower();*/
                T_String.SetPropValue(att, _name + "", Data[i]);
            }
            sql = sql + sql1;
            if (ABS_TM > 0)
            {
                double max = T_String.CongTG(ATT_MAX, NIG_MAX);
                ABS_MN = T_String.TruTG(max, WRK_HR);
                ABS_MN = T_String.TruTG(ABS_MN, LEA_H1);
                ABS_MN = T_String.TruTG(ABS_MN, LEA_H2);
                ABS_MN = T_String.TruTG(ABS_MN, LEA_H3);
                ABS_MN = T_String.TruTG(ABS_MN, OTR_HR);

                if (ABS_MN == 0)
                {
                    ABS_TM = 0;
                    NOT_DR = NOT_DR.Replace("Absent;", "");
                }
            }
            sql += ",NOT_DR=N'" + NOT_DR + "'";
            T_String.SetPropValue(att, "NotDr", NOT_DR);
            sql += ",NOT_D1=N'" + NOT_D1 + "'";
            T_String.SetPropValue(att, "NotD1", NOT_D1);
            sql += ",LAT_MN=N'" + LAT_MN + "'";
            T_String.SetPropValue(att, "LatMn", LAT_MN);
            sql += ",LAT_TM=N'" + LAT_TM + "'";
            T_String.SetPropValue(att, "LatTm", LAT_TM);
            sql += ",EAR_MN=N'" + EAR_MN + "'";
            T_String.SetPropValue(att, "EarMn", EAR_MN);
            sql += ",EAR_TM=N'" + EAR_TM + "'";
            T_String.SetPropValue(att, "EarTm", EAR_TM);
            sql += ",ABS_MN=N'" + ABS_MN + "'";
            T_String.SetPropValue(att, "AbsMn", ABS_MN);
            sql += ",ABS_TM=N'" + ABS_TM + "'";
            T_String.SetPropValue(att, "AbsTm", ABS_TM);

            sql += ",OTR_HR=" + OTR_HR.ToString("#0") + "";
            T_String.SetPropValue(att, "OtrHr", OTR_HR.ToString("#0"));
            sql += ",LEA_H1=" + LEA_H1.ToString("#0") + "";
            T_String.SetPropValue(att, "LeaH1", LEA_H1.ToString("#0"));
            sql += ",LEA_I1=N'" + LEA_I1 + "'";
            T_String.SetPropValue(att, "LeaI1", LEA_I1);
            sql += ",LEA_H2=" + LEA_H2.ToString("#0") + "";
            T_String.SetPropValue(att, "LeaH2", LEA_H2.ToString("#0"));
            sql += ",LEA_I2=N'" + LEA_I2 + "'";
            T_String.SetPropValue(att, "LeaI2", LEA_I2);
            sql += ",LEA_H3=" + LEA_H3.ToString("#0") + "";
            T_String.SetPropValue(att, "LeaH3", LEA_H3.ToString("#0"));
            sql += ",LEA_I3=N'" + LEA_I3 + "'";
            T_String.SetPropValue(att, "LeaI3", LEA_I3);

            _db.SaveChanges();

            sql += " where EMP_ID=N'" + EMP_ID + "' and ATT_DT='" + ATT_DT + "'";



        }

        public static void Attendance_Calc(string EMP_ID, string ATT_DT, SqlConnection con, ArrayList Ca, ArrayList ATT,
            string SHI_ID, List<Tbldetailsroster> rsca, Object SetTA, List<Tbltypeshift> rsTypeShift, string table, string NOT_DR)
        {
            if (SHI_ID == "NoShift") {
                return;
            }
            AttendanceHelper tm = new AttendanceHelper(EMP_ID, ATT_DT, con, Ca, ATT, SHI_ID, rsca, SetTA, rsTypeShift);
            
            tm.tb = table;

            tm.NOT_DD = NOT_DR;
            tm.UpdateSql();

            //ForCal(EMP_ID, ATT_DT, con);
        }
        public static void Attendance_Calc(string EMP_ID, string ATT_DT, SqlConnection con, string table)
        {
            QLNhaHangContext _db = new QLNhaHangContext();
            var _dt = DateTime.Parse(ATT_DT);
            var rs = _db.Tbldetailsattendance.Where(x => x.EmpId == EMP_ID && x.AttDt == _dt).FirstOrDefault();
            if (rs == null || rs.LocB1 == true) { return; }
            var rsca = _db.Tbldetailsroster.Where(x => x.ShiId == rs.ShiId).OrderBy(x => x.SeqNo).ToList();
            var rsTypeShift = _db.Tbltypeshift.ToList();

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
                ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(rs, "Onn" + j.ToString("00")) + ""));
                ATT.Add(T_String.IsNullTo00(T_String.GetPropValue(rs, "Off" + j.ToString("00")) + ""));
            }

            string NOT_DR = rs.NotDr + "";
            int pos = NOT_DR.IndexOf("Sign");
            if (pos >= 0)
            {
                int pos1 = PublicFunction.S_Left(NOT_DR, pos + 4).LastIndexOf(";");

                if (pos1 > 0)
                    NOT_DR = NOT_DR.Substring(pos1 + 1, pos - pos1 + 3);
                else
                    NOT_DR = NOT_DR.Substring(0, pos + 4);
            }
            else
                NOT_DR = "";

            Attendance_Calc(EMP_ID, ATT_DT, con, Ca, ATT, rs.ShiId + "", rsca, null, rsTypeShift, table, NOT_DR);

        }

            public void Round()
        {
            //NhuY (2011/10/25): Neu thiet lap "ko lam tron gio lam" -> chi ko lam tron gio lam, con tang ca thi lam tron
            for (int i = 0; i < Data.Count; i++)
            {
                if (SYS_SETTING_ATT.ROU_NO != "True" || Name[i] + "" != "ATT_HR" && Name[i] + "" != "NIG_HR")
                {
                    int SEQ = IsN(PublicFunction.S_Left(rsTypeShift[i].RouDr, 2));
                    int ROU = IsN(PublicFunction.S_Right(rsTypeShift[i].RouDr, 2));
                    if (SEQ != 0)
                        Data[i] = Round(IsD(Data[i] + ""), SEQ, ROU);
                }
            }
            //
            //if (thaisan.rows > 0)// thai san
            //{
            //    int index = Name.IndexOf("ATT_HR");
            //    Double hr = T_String.IsNullTo00(Data[index] + "");
            //    Double hr1 = T_String.IsNullTo00(thaisan.record(0, "WRK_OT") + "");
            //    Double gp = 0;

            //    gp = T_String.CongTG(gp, OTR_HR);
            //    if (hr > 0)
            //    {
            //        if (CON_MAN == 0 || T_String.CongTG(hr, gp) >= CON_MAN)
            //        {
            //            hr = hr + 100;
            //            hr1 = T_String.IsNullTo00(thaisan.record(0, "WRK_OT") + "");
            //            hr1 = T_String.TruTG(hr1, gp);
            //            if (hr > hr1 && hr1 > 0)
            //            {
            //                Data[index] = hr1;
            //                hr = hr - hr1;
            //                index = Name.IndexOf("OTT_HR");
            //                Data[index] = T_String.IsNullTo00(Data[index] + "") + hr;
            //            }
            //            else
            //            {
            //                Data[index] = hr;
            //            }
            //        }
            //        else
            //            giothaisan = 0;
            //    }
            //    else
            //    {
            //        index = Name.IndexOf("NIG_HR");
            //        hr = T_String.IsNullTo00(Data[index] + "");
            //        if (CON_MAN == 0 || T_String.CongTG(hr, gp) >= CON_MAN)
            //        {
            //            if (hr > 0)
            //            {
            //                hr = hr + 100;
            //                hr1 = T_String.IsNullTo00(thaisan.record(0, "WRK_OT") + "");
            //                hr1 = T_String.TruTG(hr1, gp);
            //                if (hr > hr1 && hr1 > 0)
            //                {
            //                    Data[index] = hr1;
            //                    hr = hr - hr1;
            //                    //index=Name.IndexOf("NIG_OT");
            //                    index = Name.IndexOf("OVO_HR");
            //                    Data[index] = T_String.IsNullTo00(Data[index] + "") + hr;
            //                }
            //                else
            //                {
            //                    Data[index] = hr;
            //                }
            //            }
            //        }
            //        else
            //            giothaisan = 0;
            //    }

            //    if (thaisan.record(0, "OTT_BT") + "" != "True")
            //    {
            //        for (int i = 0; i < Data.Count; i++)
            //        {
            //            if (Name[i] + "" != "ATT_HR" && Name[i] + "" != "NIG_HR")
            //                Data[i] = 0;
            //            else
            //            {
            //                if (Name[i] + "" == "ATT_HR")
            //                {
            //                    if (IsD(Data[i]) > ATT_MAX)
            //                        Data[i] = ATT_MAX;
            //                }
            //                else
            //                    if (IsD(Data[i]) > NIG_MAX)
            //                    Data[i] = NIG_MAX;
            //            }
            //        }
            //    }
            //}
        }
        public double Round(double data, int SEQ, int ROU)
        {

            double gio = IsD(PublicFunction.S_Left(PublicFunction.S_Right("00" + data + "", 4), 2));
            double phut = IsD(PublicFunction.S_Right("00" + data + "", 2));
            if (phut == 0)
                return data;
            int tm1 = 0, tm = 0;
            for (int i = 1; i <= SEQ; i++)
            {
                tm = (int)((60 / SEQ) * i);
                tm1 = (int)tm - ROU;
                if (phut <= tm && phut >= tm1)
                {
                    if (tm == 60)
                    {
                        tm = 0;
                        gio++;
                    }
                    return IsD(gio + "" + tm.ToString("00"));
                }
                tm = (int)((60 / SEQ) * (i - 1));
                if (phut < tm1 && phut > tm)
                {
                    if (tm == 60)
                    {
                        tm = 0;
                        gio++;
                    }
                    return IsD(gio + "" + tm.ToString("00"));
                }
            }
            return data;
        }

        public void AddDetailsAttendanceByHand(string EMP_ID, DateTime ATT_DT, int STR_TM, int END_TM) {
            TransferFDeviceHelper _tfD = new TransferFDeviceHelper();
            var _txt_input_card1 = GenStringRawCardData(EMP_ID, ATT_DT, STR_TM);
            var _txt_input_card2 = GenStringRawCardData(EMP_ID, ATT_DT, END_TM);
            _tfD.AddRawDataToDB(_txt_input_card1, "no file", PublicFunction.C_con, null);
            _tfD.AddRawDataToDB(_txt_input_card2, "no file", PublicFunction.C_con, null);
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
        }

        public  string GenStringRawCardData(string EMP_ID, DateTime ATT_DT, int CRD_TM) {
            var _rs = "";
            var _emp = _db.Tblemployee.Where(x => x.EmpId == EMP_ID).FirstOrDefault();
            _rs = "002" + int.Parse(_emp.CrdNo).ToString("0000000000") + ATT_DT.ToString("yyyyMMdd") + CRD_TM.ToString("000000");
            return _rs;
        }

        //int vat = 0;
        //int s = 0;
        //int p = 0;
        //int h = 0;
        //RecordSet rs;
        //string table;
    }
}
