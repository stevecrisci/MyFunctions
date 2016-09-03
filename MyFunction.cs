using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;


/// <summary>
/// Summary description for translate
/// </summary>
namespace MyFunctions
{

    public class utilities
    {
        public static bool IsValidImage(string filename)
        {
            try
            {
                WebRequest Request1 = WebRequest.Create(filename);

                WebResponse Responce1 = Request1.GetResponse();
                
                Image img1 = Image.FromStream(Responce1.GetResponseStream());



            }
            catch
            {
                // Image.FromFile will throw this if file is invalid.
                // Don't ask me why.
                return false;
            }
            return true;
        }

        public static decimal getDecimalValue(string SQLString, string connection)
        {
            decimal retVal = 0;
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = SQLString;
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                    retVal = Convert.ToDecimal(reader["retVal"]);
                else
                    retVal = 0;
            } //end SQL while loop
            reader.Close();
            conn.Close();
            return retVal;
        }
        public static int getIntValue(string SQLString, string connection)
        {
            int retVal = 0;
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = SQLString;
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                    retVal = Convert.ToInt32(reader["retVal"]);
                else
                    retVal = 0;
            } //end SQL while loop
            reader.Close();
            conn.Close();
            return retVal;
        }
        public static string getStringValue(string SQLString, string connection)
        {
            string retValue = "";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = SQLString;
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retValue = Convert.ToString(reader["retVal"]);
            } //end SQL while loop
            reader.Close();
            conn.Close();
            return retValue;
        }
        public static DateTime getDateTime(string SQLString, string connection)
        {
            DateTime retValue = DateTime.Today;
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = SQLString;
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retValue = Convert.ToDateTime(reader["retVal"]);
            } //end SQL while loop
            reader.Close();
            conn.Close();
            return retValue;
        }
        public static string[] getArray(string SelectStatement, string connection)
        {
            List<string> suggestions = new List<string>();
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = SelectStatement;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        suggestions.Add(reader[0].ToString());
                    }
                }
                else
                {
                    suggestions.Add("NOT FOUND");
                }
                reader.Close();
                conn.Close();
            }
            catch
            {
                suggestions.Add("Error reading data");
            }
            return suggestions.ToArray();
        }

        public static string getMonth(string MonthNumber)
        {
            string Month = "";
            switch (MonthNumber)
            {
                case "01":
                    Month = "JANUARY";
                    break;
                case "02":
                    Month = "FEBRUARY";
                    break;
                case "03":
                    Month = "MARCH";
                    break;
                case "04":
                    Month = "APRIL";
                    break;
                case "05":
                    Month = "MAY";
                    break;
                case "06":
                    Month = "JUNE";
                    break;
                case "07":
                    Month = "JULY";
                    break;
                case "08":
                    Month = "AUGUST";
                    break;
                case "09":
                    Month = "SEPTEMBER";
                    break;
                case "10":
                    Month = "OCTOBER";
                    break;
                case "11":
                    Month = "NOVEMBER";
                    break;
                case "12":
                    Month = "DECEMBER";
                    break;
            }
            return Month;
        }
        public static int getLocale(string locale)
        {

            return 0;
        }
        public static void Select(string SelectStatement, string connection)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = SelectStatement;
                SqlDataReader reader = command.ExecuteReader();

                reader.Close();
                conn.Close();
            }
            catch
            {
            }
        }

    }
}
