using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Addressbar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelTutor.Text = Request.QueryString["tl"].ToString();
        LabelStudent.Text = Request.QueryString["sl"].ToString();

    }
}