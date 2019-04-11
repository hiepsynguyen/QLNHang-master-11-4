using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication8.Helper
{
    public class T_String
    {
        public static double CongTG(double t1, double t2)
        {
            int g1 = Math.Abs(IsNullTo0(PublicFunction.S_Left(t1 + "", ((string)(t1 + "")).Length - 2)));
            int g2 = Math.Abs(IsNullTo0(PublicFunction.S_Left(t2 + "", ((string)(t2 + "")).Length - 2)));
            int f1 = Math.Abs(IsNullTo0(PublicFunction.S_Right("00" + t1 + "", 2)));
            int f2 = Math.Abs(IsNullTo0(PublicFunction.S_Right("00" + t2 + "", 2)));

            TimeSpan tm1 = new TimeSpan(g1, f1, 0);
            TimeSpan tm2 = new TimeSpan(g2, f2, 0);
            if (t1 < 0)
                tm1 = tm1.Negate();
            if (t2 < 0)
                tm2 = tm2.Negate();
            tm1 = tm1.Add(tm2);

            string st = (((Math.Abs(tm1.Days) * 24) + Math.Abs(tm1.Hours)).ToString("00")) + "" + Math.Abs(tm1.Minutes).ToString("00");
            if (tm1.TotalMilliseconds < 0)
                return IsNullTo00("-" + st);
            return IsNullTo00(st);
        }

        public static double TruTG(double t1, double t2)
        {
            return CongTG(t1, t2 * (-1));
        }

        public static int IsNullTo0(string st)
        {
            try
            {
                if (st == null || st == "")
                    return 0;
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                return Int32.Parse(st = st.Replace(",", ""), nfi);
            }
            catch (Exception) { return 0; }
        }

        public static Double IsNullTo00(string st)
        {
            try
            {
                if (st == null || st == "")
                    return 0;
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                //return  Double.Parse(st = st.Replace(",", ""));
                return double.Parse(st = st.Replace(",", ""), nfi);

            }
            catch (Exception ex) { return 0; }
        }

        public static string Left(string st, string find)
        {
            return st.Remove(st.IndexOf(find, 0, st.Length), st.Length - st.IndexOf(find, 0, st.Length));
        }

        public static string MaxLenght(int n)
        {
            string st = "";
            for (int i = 0; i < n; i++)
            {
                st += "&";
            }
            return st;
        }

        public static string GetMilisecondRandom() {
            return new Random().Next(0, 59).ToString("00");
        }
        public static Double DT_HourMinConvertToHour(int tam)
        {
            if (tam == 0)
                return 0;
            //return T_String.IsNullTo00((tam/100)+"."+(((double)tam-((tam/100)*100))/60));
            var _h = (tam / 100) + (((double)tam - ((tam / 100) * 100)) / 60);
            var _sh = _h.ToString("N", new CultureInfo("en-US"));
            //return T_String.IsNullTo00((tam / 100) + (((double)tam - ((tam / 100) * 100)) / 60) + "");
            return T_String.IsNullTo00(_sh);
        }
        public static int DT_HourConvertToHourMin(Double tam)
        {
            int gio = (int)(tam);
            int phut = (int)((tam - gio) * 60);
            return (gio * 100) + phut;

        }

        public static object GetPropValue(object src, string propName)
        {
            try
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
            catch
            {
                return null;
            }

        }

        public static void SetPropValue(object src, string propName, object value)
        {
            PropertyInfo propertyInfo = src.GetType().GetProperty(propName);
            if (propertyInfo != null)
            {
                Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

                propertyInfo.SetValue(src, safeValue, null);
            }
        }

        public static int DT_GetDays(DateTime dt1, DateTime dt2, string EMP_ID)
        {
            int tam = 0;
            DateTime d1 = dt1;
            //DateTime d2=dt2;
            //while (T_String.IsNullTo0(d1.ToString("yyyyMMdd"))<=T_String.IsNullTo0(d2.ToString("yyyyMMdd")))
            while (d1 <= dt2)
            {
                //				string sql="EMP_ID=N'"+EMP_ID+"' and YYY_MM=N'"+d1.ToString("yyyyMM")+"'";
                //				if(GetDataFromSQL("DAY_"+d1.ToString("dd"),"FILC03A",sql)!="00")
                //					tam++;
                //				d1=d1.AddDays(1);
                //NhuY (2013/01/08): Tru phep dua vao ca
                string sql = "SELECT 1 FROM TBLMONTHSHIFT WHERE EMP_ID=N'" + EMP_ID + "' AND YYY_MM='"
                    + d1.ToString("yyyyMM") + "' AND DAY_" + d1.ToString("dd") + " !='00'"
                    + " AND EXISTS (SELECT 1 FROM TBLDETAILSROSTER WHERE TBLDETAILSROSTER.SHI_ID=TBLMONTHSHIFT.DAY_"
                    + d1.ToString("dd") + " AND (TYP_ID='ATT_HR' OR TYP_ID='NIG_HR'))";

                RecordSet rs = new RecordSet(sql, PublicFunction.C_con);

                if (rs.rows > 0)
                    tam++;
                else
                {
                    //Nếu ko tồn tại thì tính ko dựa vào ca (trừ ra ngày chủ nhật)
                    if (!T_String.SqlExists(PublicFunction.C_con, "TBLMONTHSHIFT", "EMP_ID=N'" + EMP_ID + "' AND YYY_MM='" + d1.ToString("yyyyMM") + "'")
                        && d1.DayOfWeek != DayOfWeek.Sunday)
                        tam++;
                }

                d1 = d1.AddDays(1);
            }
            return tam;
        }

        public static bool SqlExists(SqlConnection sqlCon, string table, string where)
        {
            string sql = "IF EXISTS (SELECT 1 FROM " + table + (where == "" ? "" : " WHERE " + where) + ") SELECT 1 ELSE SELECT 0";
            RecordSet rs = new RecordSet(sql, sqlCon);

            if (rs.record(0, 0) == "1")
                return true;

            return false;
        }
        public static double Shift_WorkHour(string EMP_ID, DateTime dt)
        {
            string sql = "SELECT ISNULL(SUM(dbo.fnHourToFloat(WRK_HR)), 0)"
                + " FROM TBLDETAILSROSTER s"
                + " WHERE s.TYP_ID IN ('ATT_HR', 'NIG_HR') AND EXISTS"
                + " (SELECT 1 FROM TBLMONTHSHIFT d WHERE d.EMP_ID=N'" + EMP_ID + "' AND YYY_MM='" + dt.ToString("yyyyMM") + "'"
                + " AND s.SHI_ID=DAY_" + dt.Day.ToString("00") + ")";

            RecordSet rstmp = new RecordSet(sql, PublicFunction.C_con);

            return T_String.IsNullTo00(rstmp.record(0, 0));
        }
        public static string GetDataFromSQL(string FieldName, string from, string where)
        {
            return GetDataFromSQL(FieldName, from, where, PublicFunction.C_con);
        }

        public static string GetDataFromSQL(string FieldName, string from)
        {
            return GetDataFromSQL(FieldName, from, "", PublicFunction.C_con);
        }

        public static string GetDataFromSQL(string FieldName, string from, string where, System.Data.SqlClient.SqlConnection con)
        {
            string sql = "";
            sql = "select " + FieldName + " from " + from;
            if (where != "")
            {
                sql = sql + " where " + where;
            }
            RecordSet rs = new RecordSet(sql, con);
            if (rs.rows > 0)
                return rs.record(0, 0);
            else
                return null;
        }

        public static int GetMax(string FieldName, string from)
        {
            return T_String.IsNullTo0(GetDataFromSQL(FieldName, from)) + 1;
        }

    }
    public class PublicFunction
    {

        public static SqlConnection C_con;
        public static string connectionString = "";
        public PublicFunction(string connectionString)
        {
            //C_con = connect("");
        }

        public static string S_Right(string st, int count)
        {
            if (st + "" == "" || count > st.Length || count < 0)
                return "";
            return st.Remove(0, st.Length - count);
        }

        public static string S_Left(string st, int count)
        {
            if (st + "" == "" || count > st.Length || count < 0)
                return "";
            return st.Remove(count, st.Length - count);
        }

        public static SqlConnection connect(string connectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = connectionString;
                PublicFunction.connectionString = connectionString;
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can't connect to Server" + servername + " " + ex.Message);
                return null;
            }
        }

        public static void SQL_Execute(string sql, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void SQL_Execute(string sql, SqlConnection con, int timeout)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = 20000;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(sql + " \n Execute Sql Error . Number:" + ex.Number + ". Description Error:" + ex.Message);

            }
        }

        public static void SQL_Execute(string sql, SqlConnection con, int timeOut, Boolean mess)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = timeOut;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //if (mess)
                    //MessageBox.Show(sql + " \n Execute Sql Error . Number:" + ex.Number + ". Description Error:" + ex.Message);
            }
        }

        public static void SQL_Execute(string sql, SqlConnection con, Boolean mess)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandTimeout = 20000;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(sql + " \n Execute Sql Error . Number:" + ex.Number + ". Description Error:" + ex.Message);

            }
        }

        public static void Copy_Table(string FromTable, string NewTable, SqlConnection con1)
        {
            string sql, st = "", key = "";
            string IDTable = T_String.GetDataFromSQL("ID", "sysobjects", "name='" + FromTable + "'");
            sql = "SELECT c.colid,c.name,ty.name AS datatype,c.length,c.isnullable,c.cdefault,c.prec,c.id" +
                " FROM syscolumns c INNER JOIN systypes ty ON c.xtype = ty.xtype WHERE (ty.name <> N'sysname')" +
                " AND c.id = N'" + IDTable + "' order by colid ";
            RecordSet rs = new RecordSet(sql, con1);
            for (int i = 0; i < rs.rows; i++)
            {
                if (i != 0) st += ",";
                st += "[" + rs.record(i, "name") + "] "; // ten bang
                st += rs.record(i, "datatype");
                if (S_Right(rs.record(i, "datatype"), 4) == "char" || S_Right(rs.record(i, "datatype"), 6) == "binary")
                {
                    st += "(" + rs.record(i, "length") + ") "; // chieu dai
                }
                if (rs.record(i, "cdefault") + "" != "0") // default
                {
                    string tam = T_String.GetDataFromSQL("text", "syscomments", "id=" + rs.record(i, "cdefault"), con1);
                    if (tam != "")
                    {
                        st += " Default " + tam;
                    }
                }
                if (rs.record(i, "isnullable") + "" == "0") // allow null
                    st += " not null";
                int count = T_String.IsNullTo0(T_String.GetDataFromSQL("Count(*)", "sysindexkeys", "indid=1 and id=" + IDTable + " and colid=" + rs.record(i, "colid"), con1) + "");
                if (count > 0)
                {
                    if (key != "") key += ",";
                    key += "[" + rs.record(i, "name") + "] ";
                }
            }
            st = "Create Table [" + NewTable + "](" + st;
            if (key != "")
            {
                int count = T_String.IsNullTo0(T_String.GetDataFromSQL("Count(*)", "sysobjects", "name='" + NewTable + "'", con1));
                if (count <= 0)
                    st += " , CONSTRAINT PK_" + NewTable + " PRIMARY KEY (" + key + "))";
                else
                    st += " , CONSTRAINT PK1_" + NewTable + " PRIMARY KEY (" + key + "))";

            }
            else
                st += ")";
            SQL_Execute(st, con1, true);
        }
    }


    public class RecordSet
    {
        // Fields
        public int Bookmarks;
        public int cols;
        public DataSet ds;
        public int rows;


        //Method
        public string Field(int col)
        {
            try
            {
                return this.ds.Tables[0].Columns[col].ColumnName;
            }
            catch (Exception exception)
            {
                //MessageBox.Show(this.ds.Tables[0].TableName + " . Description Error:" + exception.Message);
                return "";
            }
        }

        public RecordSet(string sql, SqlConnection con)
        {
            this.ds = new DataSet();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.SelectCommand.CommandTimeout = 600;
                adapter.Fill(this.ds);
                this.rows = this.ds.Tables[0].Rows.Count;
                this.cols = this.ds.Tables[0].Columns.Count;
            }
            catch (SqlException exception)
            {
                //MessageBox.Show(exception.Message + "..SQL Error. Sql: " + sql);
            }
        }

        public string record(int row, int col)
        {
            try
            {
                if (this.ds.Tables[0].Rows[row][col].ToString() == "")
                {
                    return null;
                }
                return this.ds.Tables[0].Rows[row][col].ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string record(int row, string col)
        {
            try
            {
                if (this.ds.Tables[0].Rows[row][col].ToString() == "")
                {
                    return null;
                }
                return this.ds.Tables[0].Rows[row][col].ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }













    }
}
