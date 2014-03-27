using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

/// <summary>
/// Summary description for Connection
/// </summary>
public static class Connection
{
    public static SqlConnection connect()
    {
        SqlConnection con = new SqlConnection("Data Source=SABBIR\\SQLSERVER2012;Initial Catalog=TutorCentennial;Integrated Security=True");
        return con;
    }

    public static int StudentID { get; set; }
    public static string RoleName { get; set; }
        public static string SecondTry { get; set; }  
    //Yes    
        public static void InsertBatchDetails(int batchid, string day, string sttime1, string endtime1, float duration)
        {
            SqlConnection c = connect();
            c.Open();
            String insertString = "batchDaySP";

            SqlCommand cmd1 = new SqlCommand(insertString, c);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@bid", SqlDbType.Int).Value = batchid;
            cmd1.Parameters.Add("@dn", SqlDbType.VarChar).Value = day;
            cmd1.Parameters.Add("@st", SqlDbType.Time).Value = DateTime.Parse(sttime1).TimeOfDay;
            cmd1.Parameters.Add("@et", SqlDbType.Time).Value = DateTime.Parse(endtime1).TimeOfDay;
            cmd1.Parameters.Add("@du", SqlDbType.Float).Value = duration;
            //3. Call ExecuteNonQuery to send the command
            cmd1.ExecuteNonQuery();
            //5. Close the connection
            if (c != null)
            {
                c.Close();
            }

        }
}