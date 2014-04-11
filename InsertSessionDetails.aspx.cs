using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class InsertSessionDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 60; i < 1500; i++)
            {
                DropDownStTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                i = i + 29;
            }
            for (int i = 120; i < 1560; i++)
            {
                DropDownEndTime.Items.Add(DateTime.MinValue.AddMinutes(i).ToString("hh:mm tt"));
                i = i + 29;
            }
            //get previous page data
            int teacherid = Convert.ToInt32(Session["TeacherID"]);
            Label1.Text = teacherid.ToString();
            // int  gid = Convert.ToInt32 (Session["gradeid"]);
            //int sid = Convert.ToInt32 (Session["subid"]);


            SqlConnection cc;
            cc = Connection.connect();
            cc.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT BatchID, BatchName from Batch where TeacherID = " + teacherid.ToString(), cc);
            //2. Define parameter

            DataTable d = new DataTable();
            adapt.Fill(d);

            DropDownListBatch.DataTextField = "BatchName"; DropDownListBatch.DataValueField = "BatchID";
            DropDownListBatch.DataSource = d; DropDownListBatch.DataBind();
            // store BatchID in session
            // Session["BatchID"] = batchID;

            //    Label1.Text = Session["TeacherID"].ToString();
            if (cc != null)
            {
                cc.Close();
            } 
        }
    }
    protected void ButtonInsert_Click(object sender, EventArgs e)
    {
        try
        {
            int batchid = Convert.ToInt32(DropDownListBatch.SelectedValue);//Convert.ToInt32 (Session["BatchID"]);
            string day = DropDownListDay.SelectedItem.Text;

            DateTime sttime = Convert.ToDateTime(DropDownStTime.SelectedItem.Text);
            string sttime1 = Convert.ToString(sttime);
            DateTime endtime = Convert.ToDateTime(DropDownEndTime.SelectedItem.Text);
            string endtime1 = Convert.ToString(endtime);
            TimeSpan duration1 = endtime.Subtract(sttime);

            double p = duration1.TotalMilliseconds;
            float duration = Convert.ToInt32(p / 3600000);
            string checktime = TimeConflict();
            Label2.Text = checktime;
            if (checktime == null)
            {
                Connection.InsertBatchDetails(batchid, day, sttime1, endtime1, duration);
                Label1.Text = "Insert successful";
            }
            else
            {
                Label2.Text = checktime;
                DropDownStTime.Focus();
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                Label1.Text = "You are already registered a session in this Day; The session cannot be more than once in a day";
               // Label2.Text = Connection.StudentID.ToString();
               
            }
        }
    }
    protected string TimeConflict()
    {

        SqlConnection c;
        c = Connection.connect();
        c.Open();
        SqlCommand cmd = new SqlCommand("select Batch.BatchID, DayName, startTime, endTime  from Batch, BatchDay where Batch.teacherId= @tid", c);
        //2. Define parameter
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@tid";
        param.Value = Convert.ToInt32(Session["TeacherID"].ToString());
        cmd.Parameters.Add(param);
        SqlDataReader rdr = null;
        rdr = cmd.ExecuteReader();
        string a = null;
        while (rdr.Read())
        {
            string day1 = rdr[1].ToString();
            string day = DropDownListDay.SelectedItem.Text;
            int result1 = String.Compare(day, day1);
            TimeSpan selectedTime = DateTime.Parse(DropDownStTime.SelectedItem.Text).TimeOfDay;
            TimeSpan stTime = DateTime.Parse(rdr[2].ToString()).TimeOfDay;
            int result = stTime.CompareTo(selectedTime);
            //if both day and start time same
            if ((result == 0) && (result1 == 0))
            {
                a = "Time conflict. Please select a new start time";
                break;

            }
        }
        return a;
    }
}