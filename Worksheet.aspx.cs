using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;

public partial class Worksheet : System.Web.UI.Page
{
    SqlConnection c;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.IsInRole("Admin"))
        {
            PanelUpDownload.Visible = true;
            PanelWorksheetStudent.Visible = true;
        }
        if (Context.User.IsInRole("Tutor"))
        {
            PanelUpDownload.Visible = true;
            PanelWorksheetStudent.Visible = false;
        }
        if (!IsPostBack)
       {
            c = Connection.connect();

            c.Open();
            //SqlDataAdapter Adapter = new SqlDataAdapter("select SubjectID,SubName from Subject", c);
            //DataTable d = new DataTable(); Adapter.Fill(d);
            //DropDownListSub.DataSource = d; DropDownListSub.DataTextField = "SubName"; DropDownListSub.DataValueField = "SubjectID";
            //DropDownListSub.DataBind();

            //Adapter = new SqlDataAdapter("select GradeID from Grade", c);
            //d = new DataTable(); Adapter.Fill(d);
            //DropDownListGrade.DataSource = d; DropDownListGrade.DataTextField = "GradeID"; DropDownListGrade.DataValueField = "GradeID";
            //DropDownListGrade.DataBind();
        
            SqlDataAdapter Adapter = new SqlDataAdapter("select BatchID,BatchName from Batch where TeacherID = "+ Connection.TeacherID, c);
            DataTable d = new DataTable(); Adapter.Fill(d);
            DropDownListSession.DataSource = d; DropDownListSession.DataTextField = "BatchName"; DropDownListSession.DataValueField = "BatchID";
            DropDownListSession.DataBind();
            if (c != null)
            {
                c.Close();
            }
            
           
       }
        if (Context.User.IsInRole("Student"))
        {
            if (!IsPostBack)
            {
                PanelUpDownload.Visible = false;
                PanelWorksheetStudent.Visible = true;

                c = Connection.connect();

                c.Open();
                SqlCommand cmdstu = new SqlCommand("StuBatchList", c);
                cmdstu.CommandType = CommandType.StoredProcedure;
                cmdstu.Parameters.Add("@b", SqlDbType.Int).Value = Connection.StudentID;
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = cmdstu;
                DataTable d = new DataTable(); Adapter.Fill(d);
                DropDownListSessionStu.DataSource = d; DropDownListSessionStu.DataTextField = "BatchName"; DropDownListSessionStu.DataValueField = "BatchID";
                DropDownListSessionStu.DataBind(); 
            }

            

        }
    }
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {


        try
        {
            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            int size = FileUpload1.PostedFile.ContentLength;
            int sessionID = 0;
            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            if (contenttype != String.Empty)
            {
                //FileStream fs = (FileStream)FileUpload1.PostedFile.InputStream;
                Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                MemoryStream ms = new MemoryStream();
                fs.CopyTo(ms);
                byte[] result = ms.GetBuffer();
                byte[] justdata = new byte[ms.Length];
                Array.Copy(result, justdata, ms.Length);

                // string subID = DropDownListSub.SelectedValue;
                // int gradeID = Convert.ToInt32(DropDownListGrade.SelectedValue);
                int lod = Convert.ToInt32(DropDownListLOD.SelectedValue);
                sessionID = Convert.ToInt32(DropDownListSession.SelectedValue);
                if (Modify.SaveFile(filename, lod, contenttype, size, justdata, sessionID) == true)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "File Uploaded Successfully";
                }

            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised." +
                  " Upload Image/Word/PDF/Excel formats";
            }

            c = Connection.connect();
            c.Open();
            string cmdText = "SELECT WorksheetID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData, worksheetType FROM Worksheet where BatchID = " + sessionID.ToString();

            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            GridViewWorksheet.DataSource = dd;
            GridViewWorksheet.DataBind();
            GridViewWorksheet.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }
        catch (Exception)
        {
                lblMessage.Text = "Please create session first, hit the profile button if session not visible create profile first ";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Welcome to upload file";
        ButtonShow.Visible = false;
        FileUpload1.Visible = true;
        ButtonUpload.Visible = true;
       // GridViewWorksheet.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Welcome to download file";
        ButtonUpload.Visible = false;
        FileUpload1.Visible = false;
        ButtonShow.Visible = true;
    }
    protected void ButtonShow_Click(object sender, EventArgs e)
    {

        c = Connection.connect();
        c.Open();
        string cmdText = "SELECT WorksheetID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData, worksheetType FROM Worksheet where BatchID = "+ DropDownListSession.SelectedValue;
       
        SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
        DataTable dd = new DataTable();
        adapt.Fill(dd);
        GridViewWorksheet.DataSource = dd;
        GridViewWorksheet.DataBind();
        GridViewWorksheet.Visible = true;
        if (c != null)
        {
            c.Close();
        }

    }
    protected void GridViewWorksheet_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridViewWorksheet.DataKeys[GridViewWorksheet.SelectedIndex].Value);
        DataTable file = Modify.GetAFile(id);
        DataRow row = file.Rows[0];

        string name = (string)row["WorksheetName"];
        string contentType = (string)row["worksheetType"];
        Byte[] data = (Byte[])row["worksheetData"];

        // Send the file to the browser
        Response.AddHeader("Content-type", contentType);
        Response.AddHeader("Content-Disposition", "inline; filename=" + name);
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
    
    
    protected void ButtonShowStudent_Click(object sender, EventArgs e)
    {
        try
        {
            c = Connection.connect();
            c.Open();
            string cmdText = "SELECT WorksheetID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData, worksheetType FROM Worksheet where BatchID = " + DropDownListSessionStu.SelectedValue;
            SqlDataAdapter adapt = new SqlDataAdapter(cmdText, c);
            DataTable dd = new DataTable();
            adapt.Fill(dd);
            GridViewStuDown.DataSource = dd;
            GridViewStuDown.DataBind();
            GridViewStuDown.Visible = true;
            if (c != null)
            {
                c.Close();
            }
        }
        catch (Exception )
        {

            Label1.Text = "Select your session first";
        }

    }

    protected void DropDownListSessionStu_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewStuDown.Visible = false;
    }
}