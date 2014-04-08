using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Activities : System.Web.UI.Page
{ 
    SqlConnection c; SqlCommand cmd; SqlDataAdapter adapt; DataTable d;
    protected void Page_Load(object sender, EventArgs e)
    {
        //jfhsjdkh
    }
    protected void ButtonTeacher_Click(object sender, EventArgs e)
    {
        TeacherView();
    }
    protected void GridViewTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        SessionGridView();
    }
    
    
    
    protected void SessionGridView()
    {
        c = Connection.connect();
        c.Open();
        int id = Convert.ToInt32(GridViewTeacher.DataKeys[GridViewTeacher.SelectedIndex].Value);
        //Session["BatchID"] = id;
        SqlCommand cmd = new SqlCommand("ViewSession", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@t", SqlDbType.Int).Value = id;
        //  cmd.Parameters.Add("@s", SqlDbType.Int).Value = Convert.ToInt32(Connection.StudentID);
        SqlDataAdapter adapt = new SqlDataAdapter();
        adapt.SelectCommand = cmd;
        DataTable d = new DataTable();
        adapt.Fill(d);
        GridViewSession.DataSource = d; GridViewSession.DataBind();
        if (c != null)
        {
            c.Close();
        }
    }
    protected void TeacherView()
    {
        c = Connection.connect(); c.Open();
        cmd = new SqlCommand("ViewTeacher", c);
        cmd.CommandType = CommandType.StoredProcedure;
        adapt = new SqlDataAdapter();
        adapt.SelectCommand = cmd;
        d = new DataTable();
        adapt.Fill(d);
        GridViewTeacher.DataSource = d; GridViewTeacher.DataBind();
        if (c != null)
            c.Close();
    }
    protected void GridViewTeacher_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        // The ID of the product being deleted
        int bid = (int)GridViewTeacher.DataKeys[rowIndex].Value;
        c = Connection.connect();
        c.Open();
        cmd = new SqlCommand("DeleteTeacher", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@t", SqlDbType.Int).Value = bid;
        if (cmd.ExecuteNonQuery() == 1)
            LabelStatus.Text = "Delete successful";
        if (c != null)
        {
            c.Close();
        }
        TeacherView();
    }
    protected void GridViewSession_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        // The ID of the product being deleted
        int bid = (int)GridViewSession.DataKeys[rowIndex].Value;
        c = Connection.connect();
        c.Open();
        cmd = new SqlCommand("DeleteBatch", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@b", SqlDbType.Int).Value = bid;
        if (cmd.ExecuteNonQuery() == 1)
            LabelStatus.Text = "Delete successful";
        if (c != null)
        {
            c.Close();
        }
        SessionGridView();
    }
    protected void ButtonUserAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account/Register.aspx");
    }
    protected void ButtonStuList_Click(object sender, EventArgs e)
    {
        StudentView();
    }
    protected void StudentView()
    {
        c = Connection.connect(); c.Open();
        cmd = new SqlCommand("ViewStudent", c);
        cmd.CommandType = CommandType.StoredProcedure;
        adapt = new SqlDataAdapter();
        adapt.SelectCommand = cmd;
        d = new DataTable();
        adapt.Fill(d);
        GridViewStudent.DataSource = d; GridViewStudent.DataBind();
        if (c != null)
            c.Close();
    }
    protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        // The ID of the product being deleted
        int bid = (int)GridViewStudent.DataKeys[rowIndex].Value;
        c = Connection.connect();
        c.Open();
        cmd = new SqlCommand("DeleteStudent", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@s", SqlDbType.Int).Value = bid;
        if (cmd.ExecuteNonQuery() == 1)
            LabelStatus.Text = "Delete successful";
        if (c != null)
        {
            c.Close();
        }
        StudentView();
    }
}