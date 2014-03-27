using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Modify
/// </summary>
public static class Modify
{
    public static bool SaveFile(string subId,int gradeID, string name, int lod, string contentType,
            int size, byte[] data, int sessID)
    {
        bool y = false;
        SqlConnection c = Connection.connect();
        c.Open();

        string commandText = "INSERT INTO Worksheet(SubjectID, GradeID,WorksheetName,LevelOfDifficulty,dateUploaded,worksheetData,sizeA,worksheetType,BatchID)";
        commandText +="VALUES(@subID,@gradeID,@Name,@lod,@d,@Data,@size,@ContentType,@sess)";

        SqlCommand cmd = new SqlCommand(commandText, c);

        cmd.Parameters.Add("@subID", SqlDbType.Int).Value = Convert.ToInt32(subId);
        cmd.Parameters.Add("@gradeID", SqlDbType.Int).Value = gradeID;
        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
        cmd.Parameters.Add("@lod", SqlDbType.Int).Value = lod;
        cmd.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Today.Date;
        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType;
        cmd.Parameters.Add("@size", SqlDbType.Int).Value = size;
        cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = data;
        cmd.Parameters.Add("@sess", SqlDbType.Int).Value = sessID;
        //cmd.Parameters.AddWithValue("@Data", data);
        if (cmd.ExecuteNonQuery() == 1)
            y = true;

        c.Close();
        return y;
    }

    public static DataTable GetFileList()
    {
        DataTable fileList = new DataTable();
        SqlConnection c = Connection.connect();
        c.Open();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT WorksheetID, SubjectID, GradeID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData FROM Worksheet", c);

        adapter.Fill(fileList);
        c.Close();

        return fileList;
    }

    public static DataTable GetAFile(int id)
    {
        DataTable file = new DataTable();
        SqlConnection c = Connection.connect();
        c.Open();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT WorksheetID, SubjectID, GradeID, WorksheetName, LevelOfDifficulty, sizeA, worksheetData, worksheetType FROM Worksheet WHERE WorksheetID=" + id, c);

        adapter.Fill(file);

        c.Close();

        return file;
    }
}