using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using Subgurim.Controles;
using System.Drawing;

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
            rdr.Close();
            if (c != null)
                c.Close();
            
            Session["username"] = Membership.GetUser().UserName;
            SqlConnection con = Connection.connect(); con.Open();
            SqlCommand cm = new SqlCommand("select UserId from aspnet_Users where UserName = '" + Session["username"] + "'", con);
            SqlDataReader rr = cm.ExecuteReader();
            string s = "";
            if (rr.Read())
                s = rr[0].ToString();
            rr.Close();
            con.Close();
            
            SqlConnection gmap = Connection.connect();
            gmap.Open();
            SqlCommand cmdgmap = new SqlCommand("FullAddress", gmap);
            cmdgmap.CommandType = CommandType.StoredProcedure;
            cmdgmap.Parameters.Add("@u", SqlDbType.VarChar).Value = s;
            SqlDataReader rGmap = cmdgmap.ExecuteReader();
            if (rGmap.Read())
            {

            }
           
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
