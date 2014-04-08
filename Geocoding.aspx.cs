using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReverseGeocoding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if(Request.QueryString["ad"].ToString()!="")
         Label1.Text = "2303 Eglinton Ave East, M1K 2N6, ON";//Request.QueryString["ad"].ToString();
      
    }
    string s = "";
    protected void ButtonDirection_Click(object sender, EventArgs e)
    {
        SqlConnection c = Connection.connect();
        c.Open();
        SqlCommand cmd = new SqlCommand("StudentFullAddress", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@s", SqlDbType.Int).Value = Connection.StudentID;
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
            s = r["FullAddress"].ToString();
        r.Close();
        if(c!=null)
          c.Close();
        Response.Redirect("Addressbar.aspx?tl="+Label1.Text+"&sl="+s);
    }
}