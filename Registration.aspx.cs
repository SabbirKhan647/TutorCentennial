using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    //    int techerID = 0;
    //    MembershipUser userInfo = Membership.GetUser();
    //    string userid = userInfo.ProviderUserKey.ToString();

    //    SqlConnection c;
    //    c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
    //    c.Open();
    //    SqlCommand cmd = new SqlCommand("select TeacherID from Teacher where UserId= @userid", c);
    //    //2. Define parameter
    //    SqlParameter param = new SqlParameter();
    //    param.ParameterName = "@userid";
    //    param.Value = userid;
    //    cmd.Parameters.Add(param);

    //    SqlDataReader rdr = null;
    //    rdr = cmd.ExecuteReader();
    //    while (rdr.Read())
    //    {
    //        techerID = rdr.GetInt32(0);
    //    }

    //    Session["TeacherID"] = techerID;

    //    string teacherid = Session["TeacherID"].ToString();

    //    string maxStu = DropDownNoOfStu.SelectedItem.Text;
    //    string clientsidedate = HiddenField1.Value;
    //    string dateCreated = DateTime.Parse(clientsidedate).ToShortDateString();
    //    //     string dateCreated= DateTime.Now.ToShortDateString();
    //    string timeCreated = DateTime.Now.ToShortTimeString();

    //    string stDate = Calendar1.SelectedDate.ToShortDateString();


    //    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TutorConnectionString"].ConnectionString);
    //    SqlCommand cmd = new SqlCommand("createBatchSP", c);
    //    cmd.CommandType = CommandType.StoredProcedure;

    //    SqlParameter parm = new SqlParameter("@tid", SqlDbType.Int);
    //    parm.Value = Convert.ToInt32(teacherid);
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@d", SqlDbType.Date);
    //    parm.Value = DateTime.Parse(dateCreated).Date;
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@t", SqlDbType.Time);
    //    parm.Value = DateTime.Parse(timeCreated).TimeOfDay;
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@sid", SqlDbType.Int);
    //    parm.Value = DropDownListSubject.SelectedValue;
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@gid", SqlDbType.Int);
    //    parm.Value = DropDownListGrade.SelectedValue;
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@ms", SqlDbType.Int);
    //    parm.Value = Convert.ToDouble(maxStu);
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    parm = new SqlParameter("@sd", SqlDbType.Date);
    //    parm.Value = DateTime.Parse(stDate).Date;
    //    parm.Direction = ParameterDirection.Input;
    //    cmd.Parameters.Add(parm);

    //    cmd.Parameters.Add("@BName", SqlDbType.VarChar, 50);
    //    cmd.Parameters["@BName"].Direction = ParameterDirection.Output;
    //    c.Open();
    //    cmd.ExecuteNonQuery();

    //    Label2.Text = "Batch has been created successfully.";
    //    Label11.Text = "The Batch Name is: " + cmd.Parameters["@BName"].Value.ToString();
    //    Label2.Visible = true;
    //    Label11.Visible = true;
    //    c.Close();
    }
}
