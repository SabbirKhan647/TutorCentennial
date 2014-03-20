using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string panel = Request.QueryString["pan"];
        if (panel == "t")
            PanelChoose.Visible = true;
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
