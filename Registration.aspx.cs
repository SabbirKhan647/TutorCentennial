using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Context.User.IsInRole("Admin"))
        {
            PanelStudent.Visible = true;
            PanelTeacher.Visible = true;
        }
        string value = Request.QueryString["val"];
        if (value == "tute")
        {
            PanelStudent.Visible = false;
            PanelTeacher.Visible = true;
            LabelRole.Text = "Tutor Profile";
        }
        else if (value == "stu")
        {
            PanelTeacher.Visible = false;
            PanelStudent.Visible = true;
            LabelRole.Text = "Student Profile";
        }
        SqlConnection c;
        Page.Header.DataBind();
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", "currentdate();", true);
        if (Context.User.IsInRole("Tutor"))
        {
            
            SqlConnection ct = Connection.connect();
            ct.Open();
            SqlCommand cmdUpdateTutor = new SqlCommand("TeacherDetails", ct);
            cmdUpdateTutor.CommandType = CommandType.StoredProcedure;
            cmdUpdateTutor.Parameters.Add("@t", SqlDbType.Int).Value = Session["TeacherID"];
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmdUpdateTutor; DataTable d = new DataTable();
            adapt.Fill(d);
            GridViewUpdateTutor.DataSource = d; GridViewUpdateTutor.DataBind();
            ct.Close();
        }
        
        

        for (int i = 1; i <= 30; i++)
        {
            string j = Convert.ToString(i);
            DropDownNoOfStu.Items.Add(j);
        }



        if (!IsPostBack)
        {
            c = Connection.connect();
            SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            DropDownListSubject.DataSource = d; DropDownListSubject.DataTextField = "SubName"; DropDownListSubject.DataValueField = "SubjectID";
            DropDownListSubject.DataBind();

            Adapter = new SqlDataAdapter("select GradeID, GradeName from Grade", c);
            d = new DataTable(); Adapter.Fill(d);
            DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeName"; DropDownListGrade.DataValueField = "GradeID";
            DropDownListGrade.DataBind();
            if (c != null)
            {
                c.Close();
            }
        }

    }
    protected void ButtonTeacher_Click(object sender, EventArgs e)
    {
        PanelStudent.Visible = false;
        PanelTeacher.Visible = true;     
    }
    protected void ButtonStudent_Click(object sender, EventArgs e)
    {
        PanelTeacher.Visible = false;
        PanelStudent.Visible = true;
    }
    protected void DropDownListNumberOfBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ButtonBatch_Click(object sender, EventArgs e)
    {
       // int techerID = 0;
        //MembershipUser userInfo = Membership.GetUser();
        //string userid = userInfo.ProviderUserKey.ToString();

        //SqlConnection c; c = Connection.connect();
        //c.Open();
        //SqlCommand cmdd = new SqlCommand("select TeacherID from Teacher where UserId= @userid", c);
        ////2. Define parameter
        //SqlParameter param = new SqlParameter();
        //param.ParameterName = "@userid";
        //param.Value = userid;
        //cmdd.Parameters.Add(param);

        //SqlDataReader rdr = null;
        //rdr = cmdd.ExecuteReader();
        //while (rdr.Read())
        //{
        //    techerID = rdr.GetInt32(0);
        //}

        //Session["TeacherID"] = techerID;

        string teacherid = Session["TeacherID"].ToString();

        string maxStu = DropDownNoOfStu.SelectedItem.Text;
       
       string dateCreated = DateTime.Today.ToString();//DateTime.Parse(clientsidedate).ToShortDateString();
        //     string dateCreated= DateTime.Now.ToShortDateString();
        string timeCreated = DateTime.Now.ToShortTimeString();

        string stDate = Calendar1.SelectedDate.ToShortDateString();
        //if(c!= null)
        //{
        //    c.Close();
        //}

        SqlConnection cc = Connection.connect(); cc.Open();
        SqlCommand cmd = new SqlCommand("createBatchSP", cc);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
        parm.Value = Convert.ToInt32(teacherid);
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@d", SqlDbType.Date);
        parm.Value = DateTime.Parse(dateCreated).Date;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@t", SqlDbType.Time);
        parm.Value = DateTime.Parse(timeCreated).TimeOfDay;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@sid", SqlDbType.Int);
        parm.Value = DropDownListSubject.SelectedValue;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@gid", SqlDbType.Int);
        parm.Value = DropDownListGrade.SelectedValue;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@ms", SqlDbType.Int);
        parm.Value = Convert.ToDouble(maxStu);
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        parm = new SqlParameter("@sd", SqlDbType.Date);
        parm.Value = DateTime.Parse(stDate).Date;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);

        cmd.Parameters.Add("@BName", SqlDbType.VarChar, 50);
        cmd.Parameters["@BName"].Direction = ParameterDirection.Output;
        
        cmd.ExecuteNonQuery();

        Label2.Text = "Session has been created successfully.";
        Label11.Text = "The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
        Label2.Visible = true;
        Label11.Visible = true;
        if (cc != null)
        { cc.Close(); }
        Response.Redirect("InsertSessionDetails.aspx");
    }
    protected void ButtonProfile_Click(object sender, EventArgs e)
    {
        try
        {
            Session["username"] = Membership.GetUser().UserName;
            SqlConnection con = Connection.connect(); con.Open();
            SqlCommand cmdd = new SqlCommand("select UserId from aspnet_Users where UserName = '" + Session["username"] + "'", con);
            SqlDataReader rr = cmdd.ExecuteReader();
            string s = "";
            if (rr.Read())
                s = rr[0].ToString();
            rr.Close();
            con.Close();
            SqlConnection c = Connection.connect();
            c.Open();
            SqlCommand cmd = new SqlCommand("createTeacherProfile", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = TextBoxFName.Text;
            cmd.Parameters.Add("@l", SqlDbType.VarChar).Value = TextBoxLName.Text;
            cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = TextBoxPC.Text;
            cmd.Parameters.Add("@p", SqlDbType.VarChar).Value = TextBoxPhone.Text;
            cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = TextBoxAddress.Text;
            // cmd.Parameters.Add("@dis", SqlDbType.VarChar).Value = District.SelectedItem.ToString();
            // cmd.Parameters.Add("@div", SqlDbType.VarChar).Value = Division.SelectedItem.ToString();
            cmd.Parameters.Add("@div", SqlDbType.VarChar).Value = DropDownProvince.SelectedItem.ToString();
            cmd.Parameters.Add("@g", SqlDbType.Char).Value = DropDownGender.SelectedItem.ToString();
            cmd.Parameters.Add("@Ins", SqlDbType.VarChar).Value = TextBoxInstitute.Text;
            cmd.Parameters.Add("@deg", SqlDbType.VarChar).Value = TextBoxQualification.Text;
            // cmd.Parameters.Add("@pro", SqlDbType.Text).Value = TextBoxOthers.Text;
            //  Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            cmd.Parameters.Add("@u", SqlDbType.VarChar).Value = s;
            Label2.Text = s;
            if (cmd.ExecuteNonQuery() == 1)
            {
                LabelRole.Text = "Insert successful";

            }
            // LabelRole.Text = s;
            if (c != null)
                c.Close();
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
                LabelRole.Text = "The profile aleary Created";
        }
    }
    protected void ButtonSession_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertSessionDetails.aspx");
    }
    protected void ButtonStudentProfile_Click(object sender, EventArgs e)
    {
        Session["username"] = Membership.GetUser().UserName;
        SqlConnection con = Connection.connect(); con.Open();
        SqlCommand cmdd = new SqlCommand("select UserId from aspnet_Users where UserName = '" + Session["username"] + "'", con);
        SqlDataReader rr = cmdd.ExecuteReader();
        string s = "";
        if (rr.Read())
            s = rr[0].ToString();
        rr.Close();
        con.Close();
        SqlConnection c = Connection.connect();
        c.Open();
        SqlCommand cmd = new SqlCommand("createStudentProfile", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = TextBoxFName0.Text;
        cmd.Parameters.Add("@l", SqlDbType.VarChar).Value = TextBoxLName0.Text;
        cmd.Parameters.Add("@pc", SqlDbType.VarChar).Value = TextBoxPCStu.Text;
        cmd.Parameters.Add("@p", SqlDbType.VarChar).Value = TextBoxPhone0.Text;
        cmd.Parameters.Add("@pro", SqlDbType.VarChar).Value = DropDownProvince0.SelectedItem.ToString();
        cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = TextBoxAddress0.Text;
        cmd.Parameters.Add("@u", SqlDbType.VarChar).Value = s;
       
        Label2.Text = s;
        if (cmd.ExecuteNonQuery() == 1)
        {
            LabelStudent.Text = "Insert successful";

        }
    }
    protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {
        if (IsValidd(TextBoxPC.Text))
        {
            LabelRole.Text = "Hellooo";//"\u221A";
            LabelRole.ForeColor = Color.Green;
        }
        
    }
    public bool IsValidd(string value)
    {
        return Regex.IsMatch(value, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b");
    }
    
    protected void GridViewUpdateTutor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewUpdateTutor.EditIndex = e.NewEditIndex;
        GridBind();
       
    }

    private void GridBind()
    {
        SqlConnection c = Connection.connect(); c.Open();
        SqlCommand cmd = new SqlCommand("TeacherDetails", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@t", SqlDbType.Int).Value = Session["TeacherID"];
        SqlDataAdapter adapt = new SqlDataAdapter();
        adapt.SelectCommand = cmd;
        DataTable d = new DataTable();
        adapt.Fill(d);
        GridViewUpdateTutor.Visible = true;
        GridViewUpdateTutor.DataSource = d;
        GridViewUpdateTutor.DataBind();
        c.Close();
        
    }
    protected void GridViewUpdateTutor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // LabelRole.Text = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string pt = GridViewUpdateTutor.DataKeys[e.RowIndex].Value.ToString();
        //string pt = ((Label)GridViewPtDemo.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string fn = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string ln = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string ph = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string ad = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        string pro = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
       // string dt = ((TextBox)GridViewUpdateTutor.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
        // string description = ((TextBox)GridViewPtDemo.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
        // Execute the update command
      //  DateTime d = DateTime.Parse(dt);
        SqlConnection c = Connection.connect(); c.Open();
        SqlCommand cmd = new SqlCommand("UpdateTutor", c);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@t", SqlDbType.Int).Value = pt;
        cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fn;
        cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = ln;
        cmd.Parameters.Add("@ph", SqlDbType.VarChar).Value = ph;
        cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = ad;
        cmd.Parameters.Add("@pro", SqlDbType.Char).Value = pro;
       // cmd.Parameters.Add("@dob", SqlDbType.Date).Value = d;

        if (cmd.ExecuteNonQuery() == 1)
            LabelRole.Text = "Update Successfull";
        if (c != null)
            c.Close();
        GridViewUpdateTutor.EditIndex = -1;
        GridBind();

    }
    protected void GridViewUpdateTutor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewUpdateTutor.EditIndex = -1;
        GridBind();
    }
}
