using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Build : System.Web.UI.Page
{
    SqlConnection c; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            c = Connection.connect();

            c.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            DropDownSub.DataSource = d; DropDownSub.DataTextField = "SubName"; DropDownSub.DataValueField = "SubjectID";
            DropDownSub.DataBind();

            Adapter = new SqlDataAdapter("select GradeID from Grade", c);
            d = new DataTable(); Adapter.Fill(d);
            DropDownGrade.DataSource = d; DropDownGrade.DataTextField = "GradeID"; DropDownGrade.DataValueField = "GradeID";
            DropDownGrade.DataBind();
            if (c != null)
            {
                c.Close();
            }

        }
    }
    protected void ButtonShow_Click(object sender, EventArgs e)
    {
        PanelTeacher.Visible = true;
        c = Connection.connect();
        c.Open();
        SqlCommand cmd = new SqlCommand("ViewBatch", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@subid", SqlDbType.Int).Value = Convert.ToInt32(DropDownSub.SelectedValue);
        cmd.Parameters.Add("@grd", SqlDbType.Int).Value = Convert.ToInt32(DropDownGrade.SelectedValue);
        SqlDataReader r = cmd.ExecuteReader();
        DataTable d = new DataTable();
        d.Load(r);
        GridViewBatch.DataSource = d; GridViewBatch.DataBind();
        if (c != null)
        {
            c.Close();
        }
    }
    protected void GridViewBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c = Connection.connect();
            c.Open();
            int id = Convert.ToInt32(GridViewBatch.DataKeys[GridViewBatch.SelectedIndex].Value);
            SqlCommand cmd = new SqlCommand("BatchStu", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@s", SqlDbType.Int).Value = Convert.ToInt32(Connection.StudentID);
            if (cmd.ExecuteNonQuery() == 1)
            {
                LabelConfirm.Text = "Batch Registration Confirmed";
            }
            if (c != null)
            {
                c.Close();
            }
        }

        catch (SqlException ex)
        {
           if(ex.Number == 2627)
            LabelConfirm.Text = "You are already registered in this Batch";
           
        }
    }
}