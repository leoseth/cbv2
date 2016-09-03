using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Web.Services;

using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

public partial class sms: System.Web.UI.Page
{

    public static string delete;

    public static DateTime rundate;
    public ListItem li;
    public DataSet ds;
    public int valid = 0;
    public SqlDataReader dr;
    public string grant;
    public string CompleteString;
    public long nautogen = 100000000000;
    public string sautogen = "U";
    public string varsupp;
    public string confrimation;


    SqlConnection consql = new SqlConnection(@"Server=SAMSUNGLEO\SQLEXPRESS;Database=AUTOPARTS;Integrated Security='true' ");
    SqlCommand cmd = new SqlCommand();
               
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (valid != 1)
        {           
            Listedit.Visible = false;
            ListBoxview.Visible = false;
            lbledit.Visible = false;
            
            lblservice.Visible = true;
            lblsms.Visible = true;
            cmbservice.Visible = true;
            txtsms.Visible = true;

            cmbservice.Enabled = true;
            txtsms.Enabled = true;

            cmbservice.Text = "";
            txtsms.Text ="";           
                
                   if (cmbservice.Text !="")
                   {
                       cmbservice.Focus();
                   }
                   else
                   {
                       cmbservice.Focus();
                   }                       
        }
        else
        {           
            cmbservice.Enabled = true;
            txtsms.Enabled = true;
        }
    }

    protected void form1_Load(object sender, EventArgs e)
    {
        cmd.CommandType = System.Data.CommandType.Text;
        consql.Open();
        cmd.Connection = consql;
        HiddenField1.Value = "false";
    }
    
    protected void btnquit_Click(object sender, EventArgs e)
    {
        Response.Redirect("tracking.aspx");
    }  

    protected void btnedit_Click(object sender, EventArgs e)
    {
        lbltopuserid.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        lbledit.Style.Add("left","69px");
        lbledit.Style.Add("width","584px");
        Listedit.Style.Add("display", "inherit");

        lbltopuserid.Style.Add("left", "76px");


        edit.Value = "EDIT";
        lblError.Text = "";
        Label2.Visible = true;       
        lblsms.Visible = true;
        txtsms.Visible = true;
        lblservice.Visible = true;
        cmbservice.Visible = true;

        ListBoxview.Visible = false;

        delete = "";
        lbledit.Visible = true;
        Listedit.Visible = true;

        Listedit.Items.Clear();

        listbox();

        Listedit.Attributes.Add("ForeColor", "Black");
        Listedit.DataBind(); 
        Listedit.Focus();
    }

    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        consql.Close();

        consql.Open();
        SqlCommand seekrecord = new SqlCommand("select * from sms", consql);
        seekrecord.CommandText = "select * from sms where ltrim(service)='" + cmbservice.Text.Trim() + "' ";
  
        dr = seekrecord.ExecuteReader();
        if (dr.HasRows == true)
        {
            consql.Close();
            Response.Write("This service exist, please re-type");
            cmbservice.Focus();
        }
        else
        {
            if (cmbservice.Text.Length > 0)
            {               
                cmbservice.Focus();
            }
            else
            {
                valid = 1;
                cmbservice.Focus();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Style.Add("display","inherit");         
        lblservice.Style.Add("display","inherit");
        txtsms.Style.Add("display", "inherit");
        lblservice.Style.Add("display","inherit");
        cmbservice.Style.Add("display","inherit");

        lbledit.Style.Add("display","none");
        ListBoxview.Style.Add("display","none");
        lbltopuserid.Style.Add("display","none");   
        lbledit.Style.Add("display","none");
        Listedit.Style.Add("display","none");
        lblError.Style.Add("display","none");

        if (HiddenField1.Value == "true")
        {
            confrimation = "yes";

            string selected = "";
            string sel1 = "";

            int x = Listedit.Text.Length;
            int y = x - 32;
            //sel1 = Listedit.Text.Substring(0, 15).Trim();
            sel1 = Listedit.Text.Trim();
            selected = sel1;

            DataTable dtable = new DataTable();
            SqlDataAdapter dadapter = new SqlDataAdapter("select * from sms where ltrim(service)='" + selected + "'  ", consql);
            dadapter.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {
                if (delete == "deleted")
                {
                    Textlog.Visible = true;
                    Log("Delete customer");

                    if (confrimation == "yes")
                    {
                        DataTable dtable2 = new DataTable();
                        SqlDataAdapter dadapter2 = new SqlDataAdapter("delete from sms where ltrim(service)='" + selected + "'  ", consql);
                        dadapter2.Fill(dtable2);
                        dadapter2.Update(dtable2);

                        lblError.Visible = true;
                        lblError.Text = "new record deleted";

                        lbledit.Visible = false;
                        Listedit.Visible = false;

                        Textlog.Visible = false;

                        valid = 1;

                        cmbservice.Focus();
                    }
                    else
                    {
                        Listedit.Focus();
                        Textlog.Visible = false;
                    }
                }
                else
                {                    
                    cmbservice.Enabled = true;
                    txtsms.Enabled = true;
                   
                    cmbservice.Text = dtable.Rows[0]["service"].ToString();
                    txtsms.Text = dtable.Rows[0]["smsmess"].ToString();

                    txtuserid2.Text = dtable.Rows[0]["service"].ToString();

                    lbledit.Visible = false;
                    Listedit.Visible = false;
                    valid = 1;
                    cmbservice.Focus();
                }
            }
            else
            {
                Response.Write("record not exist");
            }
            HiddenField1.Value = "false";
        }
        else
        {
            confrimation = "no";
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
     {
           lbltopuserid.Style.Add("display", "inherit");
           lbledit.Style.Add("display", "inherit");
           lbledit.Style.Add("left", "69px");
           lbledit.Style.Add("width", "584px");
           Listedit.Style.Add("display", "inherit");

           lbltopuserid.Style.Add("left","76px");

           edit.Value = "DELETE";
           lblError.Text = "";
           Label2.Visible = true;           
           lblsms.Visible = true;
           txtsms.Visible = true;
           lblservice.Visible = true;
           cmbservice.Visible = true;

           ListBoxview.Visible = false;

           delete = "deleted";

           lbledit.Visible = true;
           Listedit.Visible = true;

           Listedit.Items.Clear();

           listbox();

           Listedit.Attributes.Add("ForeColor", "Black");
           Listedit.DataBind();
           Listedit.Focus();
     }

    protected void btnposition_Click(object sender, EventArgs e)
    {
           Textlog.Visible = false;
           Listedit.Visible = false;
           string selected = "";

           cmbservice.Text = cmbservice.Text.ToString();
           selected = txtuserid2.Text.Trim();

           DataTable dtable = new DataTable();
           SqlDataAdapter dadapter = new SqlDataAdapter("select * from sms where ltrim(service)='" + selected + "'  ", consql);
           dadapter.Fill(dtable);

           if (dtable.Rows.Count > 0)
           {
                    DataTable dtable2 = new DataTable();
                    SqlDataAdapter dataadapter2 = new SqlDataAdapter("delete from sms where ltrim(service)='" + selected + "' ", consql);
                    dataadapter2.Fill(dtable2);
                    dataadapter2.Update(dtable2);

                    cmd.CommandText = "insert into sms values('" + cmbservice.Text + "','" + txtsms.Text + "')  ";
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        lblError.Style.Add("display", "inherit");
                        lblError.Visible = true;
                        lblError.Text = "New record edited";
                        cmbservice.Text = "";
                        txtsms.Text = "";
                        txtuserid2.Text = "";

                        if (cmbservice.Text != "")
                        {
                            cmbservice.Focus();
                        }
                        else
                        {
                            cmbservice.Focus();
                        }
                    }
                    else
                    {
                        lblError.Text = "Failed to insert record";
                    }
           }
           else
           {
               if (cmbservice.Text !="" & txtsms.Text !="")
               {
                   cmd.CommandText = "insert into sms values('" + cmbservice.Text + "','" + txtsms.Text + "')  ";             
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        lblError.Style.Add("display","inherit");
                        lblError.Visible = true;
                        lblError.Text = "New record saved";                       
                        cmbservice.Text = "";
                        txtsms.Text = "";
                        txtuserid2.Text = "";

                        if (cmbservice.Text != "")
                        {
                            cmbservice.Focus();
                        }
                        else
                        {
                            cmbservice.Focus();
                        }        
                    }
                    else
                    {
                        lblError.Text = "Failed to insert record";
                    }
               }
           }
    }

    protected void btnrightaccess_Click(object sender, EventArgs e)
    {
        string vsearch = cmbservice.Text.Trim();

        DataTable vdatatable = new DataTable();
        SqlDataAdapter vdataadapter = new SqlDataAdapter("select * from sms where ltrim(service)='" + vsearch + "'order by service asc",consql);
        vdataadapter.Fill(vdatatable);

        if (vdatatable.Rows.Count > 0)
        {
            txtsms.Text = vdatatable.Rows[0]["smsmess"].ToString();
            hiddenservice.Value = "exist";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Functest()", true);
        }
        else
        {
            txtsms.Text = "";
            hiddenservice.Value = "not exist";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Functest()", true);
        }                
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        Label2.Style.Add("display", "inherit");        
        lblsms.Style.Add("display", "inherit");
        txtsms.Style.Add("display", "inherit");
        lblservice.Style.Add("display", "inherit");
        cmbservice.Style.Add("display", "inherit");

        lbledit.Style.Add("display","inherit");
        lbledit.Style.Add("left","15px");
        lbledit.Style.Add("width","697px");
        lbledit.Visible = true;
        lbltopuserid.Style.Add("display", "inherit");

        lbltopuserid.Style.Add("Left","26px");

        lblError.Text = "";

        Listedit.Visible = false;

        ListBoxview.Visible = false;
        ListBoxview.Style.Add("display", "inherit");
        ListBoxview.Visible = true;
        ListBoxview.Height = 200;

        ListBoxview.Items.Clear();
        ListBoxview.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
 
        int suppcount = 0;
        string varsupp = "";
       
        int count = 0;        

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select service,smsmess from sms order by service asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value!="")
            {
              
                varsupp = row[1].ToString().Trim();
                suppcount = varsupp.Length;

                count = 250 - suppcount;
                count = count - 120;

                //varsupp2 = row[2].ToString().Trim();
                //suppcount2 = varsupp2.Length;

                //count2 = 10 - suppcount2;

                //varsupp3 = row[3].ToString().Trim();
                //suppcount3 = varsupp3.Length;

                //count3 = 50 - suppcount3;

                //li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(3) + "";

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() +("").PadRight(count,'\u00A0') + row[1].ToString();
            }           
            ListBoxview.Items.Add(li); 
        }      

        ListBoxview.Focus();
    }

    public void listbox()
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select * from sms order by service asc", consql);
        dadapter.Fill(dtable);
        
        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString();
                //li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(8, '\u00A0') + row[1].ToString().Trim();
            }           
            Listedit.Items.Add(li);
        }
        Listedit.Focus();
    }

    protected void lbledit_Unload(object sender, EventArgs e)
    {
        lbledit.Visible = false;
    }

    public void autogenerate()
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select * FROM accessrights", consql);
        dadapter.Fill(dtable);

        if (dtable.Rows.Count > 0)
        {
            string selrecord = "";
            DataTable dtable2 = new DataTable();
            SqlDataAdapter dadapter2 = new SqlDataAdapter("select top 1 * FROM sms order by service DESC", consql);
            dadapter2.Fill(dtable2);

            foreach (DataRow row in dtable2.Rows)
            {
                selrecord = row[0].ToString().Remove(0,2);
                long nautogen2 = Convert.ToInt64(selrecord);
                nautogen2 = nautogen2 + 1;
                cmbservice.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen2.ToString();
            }
        }
        else
        {
            if (Textlog.Visible==false)
            {
                Textlog.Visible = true;
                Log("no existing record");
            }            

            nautogen = 100000000000;
            sautogen = "U";
            cmbservice.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen + 1;
        }
    }

    public void Log(string str)
    {
        if (Textlog.Text != " ")
        {
            Textlog.Text += DateTime.Now.ToString() + " : " + str + Environment.NewLine;
        }
    }    
}