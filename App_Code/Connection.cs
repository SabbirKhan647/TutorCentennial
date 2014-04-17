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
        SqlConnection con = new SqlConnection("Data Source=Home\\SQLSERVER2012;Initial Catalog=TutorCentennial;Integrated Security=True");
        return con;
    }

    public static int StudentID { get; set; }
    public static int TeacherID { get; set; }
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

        public static void StudID()
        {
            int stuID = 0;
            MembershipUser userInfo = Membership.GetUser();
            string userid = userInfo.ProviderUserKey.ToString();
            SqlConnection c; c = Connection.connect();
            c.Open();
            SqlCommand cmdd = new SqlCommand("select StudentID from Student where UserId= @userid", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@userid";
            param.Value = userid;
            cmdd.Parameters.Add(param);

            SqlDataReader rdr = null;
            rdr = cmdd.ExecuteReader();
            while (rdr.Read())
            {
                stuID = rdr.GetInt32(0);
            }
            rdr.Close();
            if (c != null)
                c.Close();
            Connection.StudentID = stuID;
        }
        public static void TeachID()
        {
            int techerID = 0;
            MembershipUser userInfo = Membership.GetUser();
            string userid = userInfo.ProviderUserKey.ToString();

            SqlConnection c; c = Connection.connect();
            c.Open();
            SqlCommand cmdd = new SqlCommand("select TeacherID from Teacher where UserId= @userid", c);
            //2. Define parameter
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@userid";
            param.Value = userid;
            cmdd.Parameters.Add(param);

            SqlDataReader rdr = null;
            rdr = cmdd.ExecuteReader();
            while (rdr.Read())
            {
                techerID = rdr.GetInt32(0);
            }
            rdr.Close();
            if (c != null)
                c.Close();
            Connection.TeacherID = techerID;
        }
        public static DataTable GetSessionDetails()
        {
            SqlConnection c = Connection.connect();
            c.Open();
            SqlCommand cmd = new SqlCommand("SessionDetailsView", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@t", SqlDbType.Int).Value = Connection.TeacherID;
            DataTable d = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            adapt.Fill(d);
            return d;
        }
        public static DataTable GetStudentDetails()
        {
            SqlConnection c = Connection.connect();
            c.Open();
            SqlCommand cmd = new SqlCommand("ViewStudentDetail", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@s", SqlDbType.Int).Value = Connection.StudentID;
            DataTable d = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            adapt.Fill(d);
            return d;
        }
        public static DataTable GetTeacherDetails()
        {
            SqlConnection ct = Connection.connect();
            ct.Open();
            SqlCommand cmdUpdateTutor = new SqlCommand("TeacherDetails", ct);
            cmdUpdateTutor.CommandType = CommandType.StoredProcedure;
            cmdUpdateTutor.Parameters.Add("@t", SqlDbType.Int).Value = Connection.TeacherID;
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmdUpdateTutor; DataTable d = new DataTable();
            adapt.Fill(d);
            return d;
        }
}