using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
//using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.Sql;
using System.Data.SqlClient;
//using System.Data.SqlTypes;
using System.Data;

public partial class Default : System.Web.UI.Page
{
    public static string Vaccessright;
    SqlConnection conaccess = new SqlConnection(@"Server=SAMSUNGLEO\SQLEXPRESS;Database=AUTOPARTS;Integrated Security='true' ");
    SqlCommand commandaccess = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        conaccess.Open();
    }
    protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
    {
        string un = Login1.UserName.Trim();
        string pw = Login1.Password.Trim();

        DataTable dataaccess = new DataTable();
        SqlDataAdapter accessadapter = new SqlDataAdapter("select * from accessrights where ltrim(username)='" + un + "' and ltrim(password)='" + pw + "' ", conaccess);
        accessadapter.Fill(dataaccess);
        if (dataaccess.Rows.Count > 0)
        {
            Vaccessright = dataaccess.Rows[0]["useraccess"].ToString();
            this.Application.Clear();
            this.Application.RemoveAll();
            this.Application.Add(Vaccessright, dataaccess.Rows[0]["useraccess"].ToString());
            Login1.Style.Add("ForeColor", "Blue");
            Login1.FailureText = "Access granted, Successful";
            Response.Redirect("tracking.aspx");

            Response.Close();
        }
        else
        {
            Login1.FailureText = "Your login attempt was not successful. Please try again";
        }
    }
}
