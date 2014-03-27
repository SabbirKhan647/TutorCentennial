﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string panel = Request.QueryString["pan"];
        if (panel == "t")
            PanelChoose.Visible = true;
        if (Context.User.IsInRole("Student"))
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

            Session["StudentID"] = stuID;
            Connection.StudentID = stuID;
        }
        if (Context.User.IsInRole("Tutor"))
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

            Session["TeacherID"] = techerID;
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "Tutor")
        {
            Roles.AddUserToRole(HttpContext.Current.User.Identity.Name, "Tutor");
            Response.Redirect("Registration.aspx?val=tute");
        }
        if (DropDownList1.SelectedValue == "Student")
        { 
            Roles.AddUserToRole(HttpContext.Current.User.Identity.Name, "Student");
            Response.Redirect("Registration.aspx?val=stu");
        }
    }
}
