using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ButtonHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void ButtonProfile_Click(object sender, EventArgs e)
    {

        if (Context.User.IsInRole("Tutor"))
            Response.Redirect("Registration.aspx?val=tute");
        else if (Context.User.IsInRole("Student"))
            Response.Redirect("Registration.aspx?val=stu");
        else
            Response.Redirect("Registration.aspx");
    }
    protected void Worksheet_Click(object sender, EventArgs e)
    {
        Response.Redirect("Worksheet.aspx");
    }
    protected void ButtonBatch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Build.aspx");
    }
    protected void ButtonActivities_Click(object sender, EventArgs e)
    {
        PanelActivities.Visible = true;
    }
    protected void ButtonQuiz_Click(object sender, EventArgs e)
    {

    }
}
