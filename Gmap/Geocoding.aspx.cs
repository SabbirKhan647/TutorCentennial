using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReverseGeocoding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if(Request.QueryString["ad"].ToString()!="")
        Label1.Text = "2303 Eglinton Ave East, M1K 2N6, ON";//Request.QueryString["ad"].ToString();
      
    }
}