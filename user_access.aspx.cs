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

public partial class user_access : System.Web.UI.Page
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
        varview.Value = "";
        if (valid != 1)
        {
            Listedit.Visible = false;
            ListBoxview3.Visible = false;
            lbledit.Visible = false;

            Label2.Visible = true;
            Label3.Visible = true;
            txtuserid.Visible = true;
            Label4.Visible = true;
            txtusername.Visible = true;
            labelpassword.Visible = true;
            Label5.Visible = true;
            cmbaccess.Visible = true;

            txtuserid.Enabled = true;
            txtusername.Enabled = true;
            txtfullname.Enabled = true;
            txtpassword.Enabled = true;
            cmbaccess.Enabled = true;
            txtposition.Enabled = true;

            txtuserid.Text = "";
            txtusername.Text = "";
            txtfullname.Text = "";
            txtpassword.Text = "";
            cmbaccess.Text = "";
            txtposition.Text = "";
            txtuserid2.Text = "";

            autogenerate();

            if (txtuserid.Text != "")
            {
                txtusername.Focus();
            }
            else
            {
                txtuserid.Focus();
            }
        }
        else
        {
            txtuserid.Enabled = true;
            txtusername.Enabled = true;
            txtfullname.Enabled = true;
            txtpassword.Enabled = true;
            cmbaccess.Enabled = true;
            txtposition.Enabled = true;
        }
    }

    protected void form1_Load(object sender, EventArgs e)
    {
        cmd.CommandType = System.Data.CommandType.Text;
        consql.Open();
        cmd.Connection = consql;
        HiddenField1.Value = "false";
    }
    protected void cmbaccess_TextChanged(object sender, EventArgs e)
    {
        {
            //lbltel.Visible = true;
            //txttelno.Focus();
        }
    }
    protected void btnquit_Click(object sender, EventArgs e)
    {
        Response.Redirect("tracking.aspx");
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        varview.Value = "";
        lbltopuserid.Style.Add("display", "inherit");
        lbltopusername.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        Listedit.Style.Add("display", "inherit");

        lbltopuserid.Style.Add("left", "26px");
        lbltopusername.Style.Add("left", "163px");
        lbledit.Style.Add("width", "583");

        edit.Value = "EDIT";
        lblError.Text = "";
        Label2.Visible = true;
        Label3.Visible = true;
        txtuserid.Visible = true;
        Label4.Visible = true;
        txtusername.Visible = true;
        Label5.Visible = true;
        cmbaccess.Visible = true;

        ListBoxview3.Visible = false;

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
        SqlCommand seekrecord = new SqlCommand("select * from accessrights", consql);
        seekrecord.CommandText = "select * from accessrights where ltrim(userid)='" + txtuserid.Text.Trim() + "' ";

        dr = seekrecord.ExecuteReader();
        if (dr.HasRows == true)
        {
            consql.Close();
            Response.Write("This user ID exist, please re-type");
            txtuserid.Focus();
        }
        else
        {
            if (txtuserid.Text.Length != 15)
            {
                Response.Write("Invalid input! user ID must be 15 characters, please re-type");
                txtuserid.Focus();
            }
            else
            {
                valid = 1;
                txtusername.Focus();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Style.Add("display", "inherit");
        Label3.Style.Add("display", "inherit");
        txtuserid.Style.Add("display", "inherit");
        Label4.Style.Add("display", "inherit");
        txtusername.Style.Add("display", "inherit");
        Label5.Style.Add("display", "inherit");
        cmbaccess.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "none");
        ListBoxview3.Style.Add("display", "none");
        lbltopuserid.Style.Add("display", "none");
        lbltopusername.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        Listedit.Style.Add("display", "none");

        if (HiddenField1.Value == "true")
        {
            confrimation = "yes";

            string selected = "";
            string sel1 = "";

            int x = Listedit.Text.Length;
            int y = x - 32;
            sel1 = Listedit.SelectedItem.Value;
            selected = sel1;

            DataTable dtable = new DataTable();
            SqlDataAdapter dadapter = new SqlDataAdapter("select * from accessrights where ltrim(userid)='" + selected + "'  ", consql);
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
                        SqlDataAdapter dadapter2 = new SqlDataAdapter("delete from accessrights where ltrim(userid)='" + selected + "'  ", consql);
                        dadapter2.Fill(dtable2);
                        dadapter2.Update(dtable2);

                        lbledit.Visible = false;
                        Listedit.Visible = false;

                        Textlog.Visible = false;

                        valid = 1;

                        txtuserid.Focus();
                    }
                    else
                    {
                        Listedit.Focus();
                        Textlog.Visible = false;
                    }
                }
                else
                {
                    txtuserid.Enabled = true;
                    txtusername.Enabled = true;
                    txtfullname.Enabled = true;
                    txtpassword.Enabled = true;
                    cmbaccess.Enabled = true;
                    txtposition.Enabled = true;

                    txtuserid.Text = dtable.Rows[0]["userid"].ToString();
                    txtusername.Text = dtable.Rows[0]["username"].ToString();
                    txtfullname.Text = dtable.Rows[0]["fullname"].ToString();
                    txtpassword.Text = dtable.Rows[0]["password"].ToString();
                    cmbaccess.Text = dtable.Rows[0]["useraccess"].ToString();
                    txtposition.Text = dtable.Rows[0]["position"].ToString();

                    txtuserid2.Text = dtable.Rows[0]["userid"].ToString();

                    lbledit.Visible = false;
                    Listedit.Visible = false;
                    valid = 1;
                    txtuserid.Focus();
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
        varview.Value = "";
        lbltopuserid.Style.Add("display", "inherit");
        lbltopusername.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        Listedit.Style.Add("display", "inherit");

        lbltopuserid.Style.Add("left", "26px");
        lbltopusername.Style.Add("left", "163px");
        lbledit.Style.Add("width","583");

        edit.Value = "DELETE";
        lblError.Text = "";
        Label2.Visible = true;
        Label3.Visible = true;
        txtuserid.Visible = true;
        Label4.Visible = true;
        txtusername.Visible = true;
        Label5.Visible = true;
        cmbaccess.Visible = true;

        ListBoxview3.Visible = false;

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

        txtuserid.Text = txtuserid.Text.ToString();
        selected = txtuserid2.Text.Trim();

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("delete from accessrights where ltrim(userid)='" + selected + "'  ", consql);
        dadapter.Fill(dtable);

        if (dtable.Rows.Count > 0)
        {
            dadapter.Update(dtable);
        }
        else
        {
            if (txtusername.Text != "" & txtposition.Text != "")
            {
                cmd.CommandText = "insert into accessrights values('" + txtuserid.Text + "','" + txtusername.Text + "','" + txtfullname.Text + "','" + txtpassword.Text + "','" + cmbaccess.Text.Trim() + "', '" + txtposition.Text.Trim() + "')  ";
                if (cmd.ExecuteNonQuery() == 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "New record saved";
                    txtuserid.Text = "";
                    txtusername.Text = "";
                    txtfullname.Text = "";
                    txtpassword.Text = "";
                    cmbaccess.Text = "";
                    txtposition.Text = "";
                    txtuserid2.Text = "";

                    autogenerate();

                    if (txtuserid.Text != "")
                    {
                        txtusername.Focus();
                    }
                    else
                    {
                        txtuserid.Focus();
                    }
                }
                else
                {
                    lblError.Text = "Failed to insert record";
                }
            }
        }
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        varview.Value = "view";
        Label2.Style.Add("display", "inherit");
        Label3.Style.Add("display", "inherit");
        txtuserid.Style.Add("display", "inherit");
        Label4.Style.Add("display", "inherit");
        txtusername.Style.Add("display", "inherit");
        Label5.Style.Add("display", "inherit");
        cmbaccess.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lbledit.Style.Add("left", "15px");
        lbledit.Style.Add("width", "697px");
        lbledit.Visible = true;
        lbltopuserid.Style.Add("display", "inherit");
        lbltopusername.Style.Add("display", "inherit");

        lbltopuserid.Style.Add("Left", "26px");
        lbltopusername.Style.Add("Left", "163px");

        lblError.Text = "";
       
        Listedit.Visible = false;
        Listedit.Style.Add("display", "inherit");
        Listedit.Visible = true;
        Listedit.Height = 200;
        Listedit.Width = 698;
        

        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int suppcount = 0;
        string varsupp = "";

        int count = 0;

        int suppcount2 = 0;
        string varsupp2 = "";

        int count2 = 0;

        int suppcount3 = 0;
        string varsupp3 = "";

        int count3 = 0;

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select userid,username,fullname,position from accessrights order by userid asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {

                varsupp = row[1].ToString().Trim();
                suppcount = varsupp.Length;

                count = 25 - suppcount;

                varsupp2 = row[2].ToString().Trim();
                suppcount2 = varsupp2.Length;

                count2 = 50 - suppcount2;

                varsupp3 = row[3].ToString().Trim();
                suppcount3 = varsupp3.Length;

                count3 = 50 - suppcount3;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(3) + "";
            }
            Listedit.Items.Add(li);
        }     

        Listedit.Focus();
    }

    public void listbox()
    {
        Listedit.Width = 585;
        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int fullcount = 0;
        string varfull = "";

        int fcount = 0;
        
        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select userid,username,fullname from accessrights order by userid asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                varfull = row[1].ToString().Trim();
                fullcount = varfull.Length;

                fcount = 26 - fullcount;                
           
                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(fcount, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(3) + "";               
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
            SqlDataAdapter dadapter2 = new SqlDataAdapter("select top 1 * FROM accessrights order by userid DESC", consql);
            dadapter2.Fill(dtable2);

            foreach (DataRow row in dtable2.Rows)
            {
                selrecord = row[0].ToString().Remove(0, 2);
                long nautogen2 = Convert.ToInt64(selrecord);
                nautogen2 = nautogen2 + 1;
                txtuserid.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen2.ToString();
            }
        }
        else
        {
            if (Textlog.Visible == false)
            {
                Textlog.Visible = true;
                Log("no existing record");
            }

            nautogen = 100000000000;
            sautogen = "U";
            txtuserid.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen + 1;
        }
    }

    public void Log(string str)
    {
        if (Textlog.Text != " ")
        {
            Textlog.Text += DateTime.Now.ToString() + " : " + str + Environment.NewLine;
        }
    }

    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
    }

    protected void Buttonsuppid_Click(object sender, EventArgs e)
    {
        txtusername.Focus();
    }
    protected void Buttonsuppname_Click(object sender, EventArgs e)
    {
        cmbaccess.Focus();
    }
    protected void Buttonaddress_Click(object sender, EventArgs e)
    {
        //lbltel.Visible = true;
        //txttelno.Focus();
    }
    protected void Buttontelno_Click(object sender, EventArgs e)
    {
        txtposition.Focus();
    }
}