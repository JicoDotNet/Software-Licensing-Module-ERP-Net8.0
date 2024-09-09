namespace System.Data
{
    using Reflection;
    using Collections.Generic;
    using Linq;
    public static class Extension
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < Props.Count(); i++)
            {
                dataTable.Columns.Add(Props[i].Name);
                dataTable.Columns[i].DataType = Props[i].PropertyType;
            }
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  

            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            if (dt == null)
                return data;

            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        Type colType = dr[column.ColumnName].GetType();
                        if (colType == typeof(System.DBNull))
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            // this line should be truncate
                            if(column.DataType.ToString()== "System.UInt64")
                            {
                                pro.SetValue(obj, Convert.ToBoolean(dr[column.ColumnName]), null);
                            }
                            else
                                pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}

namespace System.Collections.Generic
{
    using Reflection;
    using System.Data;
    using System.Linq;
    public static class Extension
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < Props.Count(); i++)
            {
                dataTable.Columns.Add(Props[i].Name);
                dataTable.Columns[i].DataType = Props[i].PropertyType;
            }
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  

            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}

namespace System
{
    using System.Text;
    public static class Extension
    {
        /// <summary>
        /// It will return the string or null if the string is null or Empty ("") or contain with white space (" ")
        /// </summary>
        /// <param name="str">this string object</param>
        /// <returns>null or string</returns>
        public static string ToNullOrValue(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            return str;
        }

        public static string ToNullOrTrim(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            return str.Trim();
        }

        /// <summary>
        /// First char will be Upper
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUpperFirstChar(this string str)
        {
            str = str.ToLower();
            bool IsNewSentense = true;
            var result = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(str[i]))
                {
                    result.Append(char.ToUpper(str[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(str[i]);

                if (str[i] == '!' || str[i] == '?' || str[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            return result.ToString();
        }

        public static long TimeStamp(this DateTime DTobj)
        {
            try
            {
                return ((DTobj.Ticks - 621355968000000000) / 10000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ToDisplayDateString(this DateTime DTobj)
        {
            try
            {
                return DTobj.ToString(GenericLogic.DisplayDateFormat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ShortDuration(this TimeSpan timeSpan)
        {
            int val = 0;
            string txt = "";

            if (timeSpan.TotalSeconds < 60)
            {
                val = (int)timeSpan.TotalMinutes;
                txt = "secs";
            }
            else if (timeSpan.TotalMinutes < 60)
            {
                val = (int)timeSpan.TotalMinutes;
                txt = "mins";
            }
            else if (timeSpan.TotalMinutes > 60 && timeSpan.TotalHours < 24)
            {
                val = (int)timeSpan.TotalHours;
                txt = "hrs";
            }
            else if (timeSpan.TotalHours > 24)
            {
                val = (int)timeSpan.TotalDays;
                txt = "days";
            }
            return val + " " + txt;
        }
        public static string LongDuration(this TimeSpan timeSpan)
        {
            string txt = "";
            if(timeSpan.Days < 1)
            {
                txt = timeSpan.Hours + " hrs, "
                + timeSpan.Minutes + " mins, " + timeSpan.Seconds + " secs";
            }
            else
            {
                txt = timeSpan.Days + " days, " + timeSpan.Hours + " hrs, "
                + timeSpan.Minutes + " mins, " + timeSpan.Seconds + " secs";
            }
            return txt;
        }
    }
}

namespace System.Xml.Linq
{
    using System.Data;
    using System.Linq;
    public static class Extension
    {
        public static DataTable ToDataTable(this XElement x)
        {
            DataTable dtable = new DataTable();

            XElement setup = (from p in x.Descendants() select p).First();
            // build your DataTable
            foreach (XElement xe in setup.Descendants())
                dtable.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt

            var all = from p in x.Descendants(setup.Name.ToString()) select p;
            foreach (XElement xe in all)
            {
                DataRow dr = dtable.NewRow();
                foreach (XElement xe2 in xe.Descendants())
                    dr[xe2.Name.ToString()] = xe2.Value; //add in the values
                dtable.Rows.Add(dr);
            }
            return dtable;
        }
    }
}