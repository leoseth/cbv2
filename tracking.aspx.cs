using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//using System.Data.Sql;
//using System.Data.SqlTypes;
using System.Web.Services;
using System.Globalization;
     
using System.Text;
//using System.Threading.Tasks;
using System.Net;
using System.IO;
//using System.IO.Compression;
using System.Data;
//using System.Drawing;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.Web.UI.HtmlControls;
  
public partial class tracking : System.Web.UI.Page
{
    public static string vaccessright;
    public static string recordedited;
    public static string vcarrefhidden;
    public static int numspace;
    public static string delete;
    public static string platenumselected;
    public static string rfidselected;
    public static int trnlistcount;

    public static string vmodel;
    public static string vregisnum;
    public static string vrgdate;
    public static string vcolor;
    public static string vchasisnum;
    public static string venginenum;
    public string selected;
    public string varselected;

    public static string platenumselected2;
    public static string rfidselected2;

    public string edit;
    //public static string edit2;   
    public static string varhidden;
    public string cardelconfirmed;

    public static DateTime rundate;
    public ListItem li;
    public DataSet ds;
    public int valid = 0;
    public SqlDataReader dr;
    public string grant;
    public string CompleteString;
    public long nautogen = 100000000000;
    public string sautogen = "CBV";

    public long tnautogen = 100000000000;
    public string tsautogen = "TRN";

    public string varsupp;
    public string confrimation;

    public static int vlength;
    public int SelectionStart { get; set; }
    public string validation;
    public DataTable dtable;

    public string vplatenum2;
    public string vmake2;
    public static string trans_extracted;
    public int birthlen;
    public string no_transact ="";
    public string var_valid ="";
    public string v_validate;

    public string varplate;

    SqlConnection consql = new SqlConnection(@"Server=SAMSUNGLEO\SQLEXPRESS;Database=AUTOPARTS;Integrated Security='true' ");
    SqlCommand cmd = new SqlCommand();
       
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (txtrfid.Enabled == true)
        if (txtrfid2.Enabled == true)
        {
            //txtrfid.Text = "";
            //txtrfid.Focus();
   
            txtrfid2.Text = "";
            txtrfid2.Focus();
            nosearch.Value = "yes";
        }
        else
        {
            nosearch.Value = "yes";
        }

        if (skipload.Value != "skip_load")
        {
            carfield.Value = "";

            Label2.Style.Add("display","inherit");

            lblcarinfo.Style.Add("display", "none");
            labelplatenum.Style.Add("display", "none");
            labelmake.Style.Add("display", "none");
            labelmodel.Style.Add("display", "none");
            lblplatesearch.Style.Add("display", "none");
            txtsearchplatenum.Style.Add("display", "none");
            lblsearch.Style.Add("display", "none");

            transactionlistbox.Style.Add("display", "none");
            execute_trans_module();

            hiddenfieldrfid.Value = "executed";

            lblregisnumval.Style.Add("display", "none");
            Textlog2.Style.Add("display", "none");

            if (valid != 1)
            {
                edit = "";
                edit2.Value = "";                                

                lbleditcustid.Style.Add("display", "none");
                lblname.Style.Add("display", "none");
                lbledit.Style.Add("display", "none");
                lblfirst.Style.Add("display", "none");
                lblsearch.Style.Add("display", "none");
                customertype.Style.Add("display", "none");
                txtsearch.Style.Add("display", "none");

                Listedit.Visible = false;
                ListBoxview.Visible = false;
                lbledit.Visible = false;
                txtbirthday2.Visible = false;

                Label2.Visible = true;
                lblcustid.Visible = true;
                txtcustid.Visible = true;
                txtlastname.Visible = true;
                txtlastname.Visible = true;
                lblfirstname.Visible = true;
                txtfirstname.Visible = true;
                txtbirthday.Visible = true;

                txtrfid.Enabled = false;
                txtrfid2.Enabled = true;

                txtcustid.Enabled = false;
                customtype.Disabled = false;
                txtcompname.Enabled = true;
                txtlastname.Enabled = true;
                txtfirstname.Enabled = true;
                txtmiddlename.Enabled = true;
                txtaddress.Enabled = true;
                txttelno.Enabled = true;
                txtmobilenum.Enabled = true;
                txtemailadd.Enabled = true;
                txtbirthday.Enabled = true;
                txtbirthplace.Enabled = true;
                txtnationality.Enabled = true;
                sidtype.Disabled = false;
                txtidnumber.Enabled = true;

                txtrfid.Text = "";
                txtrfid2.Text = "";
                txtcustid.Text = "";
                customtype.Value = "";
                txtcompname.Text = "";
                txtlastname.Text = "";
                txtfirstname.Text = "";
                txtmiddlename.Text = "";
                txtaddress.Text = "";
                txttelno.Text = "";
                txtmobilenum.Text = "";
                txtemailadd.Text = "";
                txtbirthday.Text = "";
                txtbirthplace.Text = "";
                txtnationality.Text = "";
                sidtype.Value = "";
                txtidnumber.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "carrefdropdown()", true); 

                txtcustid2.Text = "";

                txtplatenumber.Text = "";
                txtmake.Text = "";
                txtmodel.Text = "";
                txtregisnum.Text = "";
                txtrgdate.Text = "Date";
                txtcolor.Text = "";
                txtchasisnum.Text = "";
                txtenginenum.Text = "";

                txtplatenumber.Enabled = false;
                txtmake.Enabled = false;
                txtmodel.Enabled = false;
                txtregisnum.Enabled = false;

                txtrgdate.Enabled = false;
                txtrgdate2.Enabled = false;

                txtcolor.Enabled = false;
                txtchasisnum.Enabled = false;
                txtenginenum.Enabled = false;

                no_transact = "yes";

                if (txtrfid.Text != ""){
                    autogenerate();
                }                    

                //Regwx1.Visible = true;

                if (txtcustid.Text != "")
                {
                   //txtrfid.Focus();
                   txtrfid2.Focus();
                }
                else
                {
                    //txtrfid.Focus();
                    txtrfid2.Focus();
                }
            }
            else
            {
                txtrfid.Enabled = false;
                //txtrfid2.Enabled = false;
                txtrfid2.Enabled = true;

                txtcustid.Enabled = true;
                customtype.Disabled = false;
                txtcompname.Enabled = true;
                txtlastname.Enabled = true;
                txtfirstname.Enabled = true;
                txtmiddlename.Enabled = true;
                txtaddress.Enabled = true;
                txttelno.Enabled = true;
                txtmobilenum.Enabled = true;
                txtemailadd.Enabled = true;
                txtbirthday.Enabled = true;
                txtbirthplace.Enabled = true;
                txtnationality.Enabled = true;
                sidtype.Disabled = false;
                txtidnumber.Enabled = true;                
            }
        }
        else
        {
                carfield.Value = "";
  
                edit = "";
                edit2.Value = "";

                lbleditcustid.Style.Add("display", "none");
                lblname.Style.Add("display", "none");
                lbledit.Style.Add("display", "none");
                lblfirst.Style.Add("display", "none");
                lblsearch.Style.Add("display", "none");
                customertype.Style.Add("display", "none");
                txtsearch.Style.Add("display", "none");

                Listedit.Visible = false;
                ListBoxview.Visible = false;
                lbledit.Visible = false;
                txtbirthday2.Visible = false;

                Label2.Visible = true;
                lblcustid.Visible = true;
                txtcustid.Visible = true;
                txtlastname.Visible = true;
                txtlastname.Visible = true;
                lblfirstname.Visible = true;
                txtfirstname.Visible = true;
                txtbirthday.Visible = true;

                txtrfid.Enabled = false;
                txtrfid2.Enabled = true;

                txtcustid.Enabled = false;
                customtype.Disabled = false;
                txtcompname.Enabled = true;
                txtlastname.Enabled = true;
                txtfirstname.Enabled = true;
                txtmiddlename.Enabled = true;
                txtaddress.Enabled = true;
                txttelno.Enabled = true;
                txtmobilenum.Enabled = true;
                txtemailadd.Enabled = true;
                txtbirthday.Enabled = true;
                txtbirthplace.Enabled = true;
                txtnationality.Enabled = true;
                sidtype.Disabled = false;
                txtidnumber.Enabled = true;

                txtrfid.Text = "";
                txtcustid.Text = "";
                customtype.Value = "";
                txtcompname.Text = "";
                txtlastname.Text = "";
                txtfirstname.Text = "";
                txtmiddlename.Text = "";
                txtaddress.Text = "";
                txttelno.Text = "";
                txtmobilenum.Text = "";
                txtemailadd.Text = "";
                txtbirthday.Text = "";
                txtbirthplace.Text = "";
                txtnationality.Text = "";
                sidtype.Value = "";
                txtidnumber.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "carrefdropdown()", true); 

                txtcustid2.Text = "";

                txtplatenumber.Text = "";
                txtmake.Text = "";
                txtmodel.Text = "";
                txtregisnum.Text = "";
                //txtrgdate.Text = "Date";
                txtrgdate2.Text = "";
                txtcolor.Text = "";
                txtchasisnum.Text = "";
                txtenginenum.Text = "";

                txtplatenumber.Enabled = false;
                txtmake.Enabled = false;
                txtmodel.Enabled = false;
                txtregisnum.Enabled = false;
                txtrgdate.Enabled = false;
                txtrgdate2.Enabled = false;
                txtcolor.Enabled = false;
                txtchasisnum.Enabled = false;
                txtenginenum.Enabled = false;

                if (txtrfid.Text != ""){
                    autogenerate();
                }

                //Regwx1.Visible = true;

                if (txtcustid.Text != "")
                {
                    //txtrfid.Focus();
                    txtrfid2.Focus();
                }
                else
                {
                    //txtrfid.Focus();
                    txtrfid2.Focus();
                }           
        }
        lblcustrequired.Style.Add("display", "inherit");
        confirmdiv.Style.Add("display","none");
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        nosearch.Value = "no";
        confirmdiv.Style.Add("display", "none");
        hiddenfieldrfid.Value = "";

        lblcustrequired.Style.Add("display", "none");
        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        lblregisnumval.Style.Add("display", "none");
        Textlog2.Style.Add("display", "none");

        if (valid != 1)
        {
            edit = "";
            edit2.Value = "";

            lbleditcustid.Style.Add("display", "none");
            lblname.Style.Add("display", "none");
            lbledit.Style.Add("display", "none");
            lblfirst.Style.Add("display", "none");
            lblsearch.Style.Add("display", "none");
            customertype.Style.Add("display", "none");
            txtsearch.Style.Add("display", "none");

            Listedit.Visible = false;
            ListBoxview.Visible = false;
            lbledit.Visible = false;
            txtbirthday2.Visible = false;

            Label2.Visible = true;
            lblcustid.Visible = true;
            txtcustid.Visible = true;
            txtlastname.Visible = true;
            txtlastname.Visible = true;
            lblfirstname.Visible = true;
            txtfirstname.Visible = true;
            txtbirthday.Visible = true;

            txtrfid.Text = "";
            txtcustid.Text = "";
            customtype.Value = "";
            txtcompname.Text = "";
            txtlastname.Text = "";
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtaddress.Text = "";
            txttelno.Text = "";
            txtmobilenum.Text = "";
            txtemailadd.Text = "";
            txtbirthday.Text = "";
            txtbirthplace.Text = "";
            txtnationality.Text = "";
            sidtype.Value = "";
            txtidnumber.Text = "";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "carrefdropdown()", true);             
                
            txtcustid2.Text = "";

            txtrfid.Enabled = false;
            txtrfid2.Enabled = true;

            txtcustid.Enabled = false;
            customtype.Disabled = true;
            txtcompname.Enabled = false;
            txtlastname.Enabled = false;
            txtfirstname.Enabled = false;
            txtmiddlename.Enabled = false;
            txtaddress.Enabled = false;
            txttelno.Enabled = false;
            txtmobilenum.Enabled = false;
            txtemailadd.Enabled = false;
            txtbirthday.Enabled = false;
            txtbirthplace.Enabled = false;
            txtnationality.Enabled = false;
            sidtype.Disabled = true;
            txtidnumber.Enabled = false;            

            txtplatenumber.Text = "";
            txtmake.Text = "";
            txtmodel.Text = "";
            txtregisnum.Text = "";
            //txtrgdate.Text = "Date";
            txtrgdate2.Text = "";
            txtcolor.Text = "";
            txtchasisnum.Text = "";
            txtenginenum.Text = "";

            txtplatenumber.Enabled = false;
            txtmake.Enabled = false;
            txtmodel.Enabled = false;
            txtregisnum.Enabled = false;

            txtrgdate.Enabled = false;
            txtrgdate2.Enabled = false;

            txtcolor.Enabled = false;
            txtchasisnum.Enabled = false;
            txtenginenum.Enabled = false;

            if (txtrfid.Text != ""){
                autogenerate();
            }

            //Regwx1.Visible = true;

            if (txtcustid.Text != "")
            {
                //txtrfid.Focus();
                txtrfid2.Focus();
            }
            else
            {
                //txtrfid.Focus();
                txtrfid2.Focus();
            }
        }
        else
        {
            txtrfid.Enabled = false;
            txtrfid2.Enabled = true;

            txtcustid.Enabled = true;
            customtype.Disabled = false;
            txtcompname.Enabled = true;
            txtlastname.Enabled = true;
            txtfirstname.Enabled = true;
            txtmiddlename.Enabled = true;
            txtaddress.Enabled = true;
            txttelno.Enabled = true;
            txtmobilenum.Enabled = true;
            txtemailadd.Enabled = true;
            txtbirthday.Enabled = true;
            txtbirthplace.Enabled = true;
            txtnationality.Enabled = true;
            sidtype.Disabled = false;
            txtidnumber.Enabled = true;
        }
    }

    protected void form1_Load(object sender, EventArgs e)
    {
        if (skipload.Value != "skip_load")
        {
            validation = "";
            cmd.CommandType = System.Data.CommandType.Text;
            consql.Open();
            cmd.Connection = consql;
            HiddenField1.Value = "false";
        }
        
    }
    protected void txtfirstname_TextChanged(object sender, EventArgs e)
    {
        {
            txtmiddlename.Focus();
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        dataextract.Value = "false";
        confirmdiv.Style.Add("display", "none");
        transactionlistbox.Style.Add("display","none");
        execute_trans_module();
        hiddenfieldrfid.Value = "executed";

        varhidden = "";
        Hiddenfield_car.Value = "";

        lblcustrequired.Style.Add("display","none");
        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");

        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");

        lbledit.Style.Add("left", "132px");
        lblname.Style.Add("left", "301px");
        lblname.Text = "Lastname";
        lblfirst.Style.Add("left", "447px");

        lblcomp.Style.Add("left", "585px");
        lblcomp.Style.Add("font-size","12px");
        lblcomp.Style.Add("top", "11px");

        lblsearch.Style.Add("left", "690px");
        customertype.Style.Add("left", "755px");
        txtsearch.Style.Add("left", "852px");
        txtsearch.Style.Add("right", "276px");
        lbledit.Style.Add("width", "621px");

        if (txtbirthday2.Text == string.Empty)
        {
            txtbirthday2.Visible = false;
            txtbirthday.Visible = true;
        }

        edit = "EDIT";
        edit2.Value = "EDIT";
        lblError.Text = "";
        HiddenField_edit.Value = "EDIT";

        lbleditcustid.Style.Add("display", "inherit");
        lbleditcustid.Style.Add("left", "150px");

        lblname.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        lblfirst.Style.Add("display", "inherit");
        lblcomp.Style.Add("display", "inherit");
        lblsearch.Style.Add("display", "inherit");
        customertype.Style.Add("display", "inherit");
        txtsearch.Style.Add("display", "inherit");
        Label2.Style.Add("display", "inherit");

        Label2.Visible = true;
        txtcustid.Visible = true;
        txtlastname.Visible = true;
        txtlastname.Visible = true;
        lblfirstname.Visible = true;
        txtfirstname.Visible = true;

        ListBoxview.Visible = false;

        delete = "";
        lbledit.Visible = true;
        Listedit.Visible = true;

        txtplatenumber.Text = "";
        txtmake.Text = "";
        txtmodel.Text = "";
        txtregisnum.Text = "";
        txtrgdate.Text = "Date";
        txtrgdate2.Text = "";
        txtcolor.Text = "";
        txtchasisnum.Text = "";
        txtenginenum.Text = "";

        txtplatenumber.Enabled = false;
        txtmake.Enabled = false;
        txtmodel.Enabled = false;
        txtregisnum.Enabled = false;
        txtrgdate.Enabled = false;
        txtcolor.Enabled = false;
        txtchasisnum.Enabled = false;
        txtenginenum.Enabled = false;
        
        Listedit.Items.Clear();

        listbox();

        Listedit.Attributes.Add("ForeColor", "Black");
        Listedit.DataBind();
        Listedit.Focus();
    }     

    protected void Page_Load(object sender, EventArgs e)                                                           
    {
        if (txtrfid.Text == "" && txtplatenumber.Enabled == false && txtinvoicenum.Enabled == false)
        {
            //txtrfid.Focus();
            txtrfid2.Focus();
        }
        else
        {
            if(txtrfid.Text=="" && txtplatenumber.Text =="" && txtinvoicenum.Text =="")
            {
                //txtrfid.Focus();
                txtrfid2.Focus();
            }
        }

        if (skipload.Value != "skip_load")
        {
            if (no_option.Value == "")
            {
                confirmdiv.Style.Add("display", "none");
            }
            if (v_carsave.Value == "")
            {
                divcar.Style.Add("display", "none");
            }

            divtransact.Style.Add("display","none");

            lblcustrequired.Style.Add("display", "none");
            lbleditcustid.Style.Add("display", "none");
            lblname.Style.Add("display", "none");
            lbledit.Style.Add("display", "none");
            lblfirst.Style.Add("display", "none");
            lblsearch.Style.Add("display", "none");
            customertype.Style.Add("display", "none");
            txtsearch.Style.Add("display", "none");

            rfidselected = txtrfid.Text;
            //platenumselected = carrefdropdownlist.Text.Trim();

            lblregisnumval.Style.Add("display", "none");
            lbltel.Style.Add("display", "none");
            Textlog2.Style.Add("display", "none");                                                                                
            
            lblcarinfo.Style.Add("display", "none");
            labelplatenum.Style.Add("display", "none");
            labelmake.Style.Add("display", "none");
            labelmodel.Style.Add("display", "none");
            lblplatesearch.Style.Add("display", "none");
            txtsearchplatenum.Style.Add("display", "none");
            lblsearch.Style.Add("display","none");

            lblsearchviewplatenum.Style.Add("display", "none");
            txtserchviewplatenum.Style.Add("display", "none");

            labelregnum.Style.Add("display", "none");
            labelcolor.Style.Add("display", "none");
            labelchasisnum.Style.Add("display", "none");

            Listedit.Style.Add("display", "none");
            ListBoxview.Style.Add("display", "none");
            transactionlistbox.Style.Add("display", "none");

            labelranslist.Style.Add("display", "none");
            labeltransactdate.Style.Add("display", "none");
            labeltransactnum.Style.Add("display", "none");
            labelinvoicenum.Style.Add("display", "none");
            labelservice.Style.Add("display", "none");
            labelservtype.Style.Add("display", "none");
            labelwarstatus.Style.Add("display", "none");
            labelmainschedule.Style.Add("display", "none");
            labelmainduedate.Style.Add("display", "none");
            labelsearchtransactnum1.Style.Add("display", "none");
            labelsearchtransactnum2.Style.Add("display", "none");
            resultlist.Style.Add("display","none");
            lblcomp.Style.Add("display","none");
            lbltelephone.Style.Add("display","none");

            lbltransactionlib.Style.Add("display", "inherit");
            lblinvoicenum.Style.Add("display", "inherit");
            txtinvoicenum.Style.Add("display", "inherit");
            lbltransacnum.Style.Add("display", "inherit");
            txttransacnum.Style.Add("display", "inherit");
            lbltrandate.Style.Add("display", "inherit");
            txttrandate.Style.Add("display", "inherit");
            lblservice.Style.Add("display", "inherit");
            cmbservice.Style.Add("display", "inherit");
            lbltypeofserv.Style.Add("display", "inherit");
            cmbtypeofserve.Style.Add("display", "inherit");
            lblwarstat.Style.Add("display", "inherit");
            cmbwarstat.Style.Add("display", "inherit");
            lblwarexpire.Style.Add("display", "inherit");
            txtwarexpire.Style.Add("display", "inherit");

            txtwarexpire2.Style.Add("display", "none");

            lblmainsched.Style.Add("display", "inherit");
            mainscheddropdown.Style.Add("display", "inherit");
            lblmaindue.Style.Add("display", "inherit");
            txtmaindue.Style.Add("display", "inherit");
            lblsmsmess.Style.Add("display", "inherit");
            txtsmsmess.Style.Add("display", "inherit");
            lblservde.Style.Add("display", "inherit");
            txtservde.Style.Add("display", "inherit");
            transadd.Style.Add("display", "inherit");
            transedit.Style.Add("display", "inherit");
            transdelete.Style.Add("display", "inherit");

            if (this.Application[0].ToString() == "Unlimited")
            {
                checkaccess.Enabled = true;
            }
            else
            {
                checkaccess.Enabled = false;
            }

            if (txtplatenumber.Enabled == true)
            {
                lblplatenumval.Visible = true;
            }
            else
            {
                lblplatenumval.Visible = false;
            }

            if (ListBoxview.Visible == false)
            {
                lbleditcustid.Style.Add("display", "none");
                lblname.Style.Add("display", "none");
                lbledit.Style.Add("display", "none");
                lblfirst.Style.Add("display", "none");
                lblsearch.Style.Add("display", "none");
                customertype.Style.Add("display", "none");
                txtsearch.Style.Add("display", "none");
            }           

            validation = "";

            if (HiddenField1.Value == "true")
            {
                confrimation = "yes";

                //string selected = "";
                selected = "";
                string sel1 = "";

                int x = Listedit.Text.Length;
                int y = x - 32;

                if (edit2.Value == "POPULATE")
                {                    
                    sel1 = ListBoxview.SelectedValue.Trim();
                }
                else
                {
                    if (x == 17)
                    {                     
                        sel1 = Listedit.SelectedValue.Trim();
                    }
                }

                selected = sel1;

                DataTable dtable = new DataTable();
                SqlDataAdapter dadapter = new SqlDataAdapter("select * from customer where ltrim(custnum)='" + selected + "' and delrec is null", consql);
                dadapter.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    if (delete == "deleted")
                    {
                        Textlog2.Style.Add("display", "inherit");
                        Log("Delete customer");

                        //if (MessageBox.Show(varmessage.ToString(), varconfirm.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        if (confrimation == "yes")
                        {
                            DataTable dtable2 = new DataTable();
                            //SqlDataAdapter dadapter2 = new SqlDataAdapter("delete from customer where ltrim(custnum)='" + selected + "'  ", consql);
                            SqlDataAdapter dadapter2 = new SqlDataAdapter("update customer set delrec='" + "deleted" + "' where ltrim(custnum)='" + selected + "'  ", consql);
                            dadapter2.Fill(dtable2);
                            dadapter2.Update(dtable2);

                            lbledit.Visible = false;
                            //Listedit.Visible = false;
                            Listedit.Style.Add("display", "none");

                            lblcarrefernces.Style.Add("display", "inherit");
                            carrefdropdownlist.Style.Add("display", "inherit");

                            Textlog2.Style.Add("display", "none");

                            valid = 1;

                            //txtcustid.Focus();
                            txtcustid2.Focus();
                        }
                        else
                        {
                            Listedit.Focus();
                            Textlog2.Style.Add("disply", "none");
                        }
                    }
                    else
                    {
                        skipload.Value = "skip_load";
                        hiddenclick.Value = "txtrfid";

                        txtrfid.Enabled = false;
                        txtrfid2.Enabled = false;                        

                        txtcustid.Enabled = false;
                        customtype.Disabled = true;

                        txtcompname.Enabled = true;
                        txtlastname.Enabled = true;
                        txtfirstname.Enabled = true;
                        txtmiddlename.Enabled = true;
                        txtaddress.Enabled = true;
                        txttelno.Enabled = true;
                        txtmobilenum.Enabled = true;
                        txtemailadd.Enabled = true;
                        txtbirthday.Enabled = true;
                        txtbirthplace.Enabled = true;
                        txtnationality.Enabled = true;
                        sidtype.Disabled = false;
                        txtidnumber.Enabled = true;

                        txtrfid.Text = dtable.Rows[0]["rfid_code"].ToString();
                        txtcustid.Text = dtable.Rows[0]["custnum"].ToString();
                        customtype.Value = dtable.Rows[0]["custtype"].ToString();
                        txtcompname.Text = dtable.Rows[0]["compname"].ToString();
                        txtlastname.Text = dtable.Rows[0]["lastname"].ToString();
                        txtfirstname.Text = dtable.Rows[0]["firstname"].ToString();
                        txtmiddlename.Text = dtable.Rows[0]["middlename"].ToString();
                        txtaddress.Text = dtable.Rows[0]["address"].ToString();
                        txttelno.Text = dtable.Rows[0]["phone_num"].ToString();
                        txtmobilenum.Text = dtable.Rows[0]["mobile_num"].ToString();
                        txtemailadd.Text = dtable.Rows[0]["email_add"].ToString();
                        recordedited = "edited";

                        confirmdiv.Style.Add("display", "none");
                        confirmdiv.Style.Add("display", "inherit");

                        txtbirthday.Visible = false;
                        txtbirthday2.Visible = true;
                        txtbirthday2.Enabled = true;

                        birthlen = dtable.Rows[0]["birthday"].ToString().Length;

                        if (birthlen==20){
                           txtbirthday2.Text = dtable.Rows[0]["birthday"].ToString().Substring(0, 9);                        
                        }

                        if (birthlen == 21){
                            txtbirthday2.Text = dtable.Rows[0]["birthday"].ToString().Substring(0, 10);
                        }

                        if (birthlen == 22){
                            txtbirthday2.Text = dtable.Rows[0]["birthday"].ToString().Substring(0, 11);;
                        }                           

                        txtbirthplace.Text = dtable.Rows[0]["birthplace"].ToString();
                        txtnationality.Text = dtable.Rows[0]["nationality"].ToString();
                        sidtype.Value = dtable.Rows[0]["idtype"].ToString();
                        txtidnumber.Text = dtable.Rows[0]["idnum"].ToString();

                        if (txtcompname.Text == "")
                        {
                            txtcompname.Enabled = false;
                        }

                        txtcustid2.Text = dtable.Rows[0]["custnum"].ToString();

                        lbleditcustid.Style.Add("display", "none");
                        lblname.Style.Add("display", "none");
                        lbledit.Style.Add("display", "none");
                        lblfirst.Style.Add("display", "none");
                        lblsearch.Style.Add("display", "none");
                        customertype.Style.Add("display", "none");
                        txtsearch.Style.Add("display", "none");

                        lbledit.Visible = false;

                        ListBoxview.Visible = false;

                        //Listedit.Visible = false;
                        Listedit.Style.Add("display", "none");

                        lblcarrefernces.Style.Add("display", "inherit");
                        carrefdropdownlist.Style.Add("display", "inherit");

                        ////// to filter data by car platenumber  ////
                        DataTable platenumdtable = new DataTable();
                        SqlDataAdapter platenumdadapter = new SqlDataAdapter("select platenum from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null", consql);
                        platenumdadapter.Fill(platenumdtable);

                        if (platenumdtable.Rows.Count > 0)
                        {
                            carrefdropdownlist.SelectedIndex = -1;
                            carrefdropdownlist.DataSource = platenumdtable;
                            carrefdropdownlist.DataValueField = "platenum";
                            carrefdropdownlist.DataTextField = "platenum";
                            carrefdropdownlist.DataBind();
                        }
                        ////// to filter data by car platenumber  ////

                        valid = 1;
                        //txtrfid.Focus();
                        //txtrfid2.Focus();
                        txtlastname.Focus();                        
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

            if (carfield.Value == "true")
            {
                Label2.Style.Add("display", "inherit");

                lbleditcustid.Style.Add("display", "none");
                lblname.Style.Add("display", "none");
                lbledit.Style.Add("display", "none");
                lblfirst.Style.Add("display", "none");
                lblsearch.Style.Add("display", "none");
                customertype.Style.Add("display", "none");
                txtsearch.Style.Add("display", "none");

                labelplatenum.Style.Add("display", "none");
                labelmake.Style.Add("display", "none");
                labelmodel.Style.Add("display", "none");

                lblplatesearch.Style.Add("display", "none");
                txtsearchplatenum.Style.Add("display", "none");

                //Listedit.Style.Add("display","none");

                string selected = "";
                string sel1 = "";
                string vrfid = "";
                int l = 0;

                if (edit2.Value == "POPULATE")
                {
                    if (ListBoxview.Text != "")
                    {                        
                        sel1 = ListBoxview.SelectedValue.Trim();
                    }
                    else
                    {
                        sel1 = "";
                    }
                }
                else
                {
                    if (Listedit.Text != "")
                    {                        
                        sel1 = Listedit.SelectedValue.Trim();
                    }
                    else
                    {
                        sel1 = "";
                    }
                }

                selected = sel1;

                DataTable dtable = new DataTable();
                SqlDataAdapter dadapter = new SqlDataAdapter("select * from car where ltrim(platenum)='" + selected + "' and delrec is null", consql);
                dadapter.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    if (delete == "deleted")
                    {
                        skipload.Value = "skip_load";
                        Textlog2.Visible = true;
                        Textlog2.Style.Add("display", "inherit");
                        Textlog2.Text = "";
                        Log("New record deleted");

                        DataTable cardeletetable = new DataTable();
                        //SqlDataAdapter dadapter2 = new SqlDataAdapter("delete from car where ltrim(platenum)='" + selected + "'  ", consql);
                        SqlDataAdapter dadapter2 = new SqlDataAdapter("update car set delrec='" + "deleted" + "' where ltrim(platenum)='" + selected + "'  ", consql);
                        dadapter2.Fill(cardeletetable);
                        dadapter2.Update(cardeletetable);
                        delete = "";

                        Listedit.Style.Add("display", "none");

                        lblcarrefernces.Style.Add("display", "inherit");
                        carrefdropdownlist.Style.Add("display", "inherit");

                        txtplatenumber.Focus();
                    }
                    else
                    {
                        skipload.Value = "skip_load";
                        txtplatenumber.Enabled = true;
                        txtmake.Enabled = true;
                        txtmodel.Enabled = true;
                        txtregisnum.Enabled = true;

                        //txtrgdate.Enabled = true;
                        txtrgdate.Visible = false;
                        txtrgdate2.Visible = true;

                        txtrgdate2.Enabled = true;

                        txtcolor.Enabled = true;
                        txtchasisnum.Enabled = true;
                        txtenginenum.Enabled = true;

                        caredited.Value = "edited";
                       
                        txtplatenumber.Text = dtable.Rows[0]["platenum"].ToString();
                        txtplatenumber2.Text = txtplatenumber.Text.Trim();

                        txtmake.Text = dtable.Rows[0]["make"].ToString();
                        txtmodel.Text = dtable.Rows[0]["model"].ToString();
                        txtregisnum.Text = dtable.Rows[0]["regnum"].ToString();

                        //if (dtable.Rows[0]["regdate"].ToString() == null || dtable.Rows[0]["regdate"].ToString() == String.Empty || dtable.Rows[0]["regdate"].ToString().Trim().Length == 0)
                        if (dtable.Rows[0]["regdate"].ToString() == null || dtable.Rows[0]["regdate"].ToString() == String.Empty)
                        {
                            l = 0;
                        }
                        else
                        {
                            l = dtable.Rows[0]["regdate"].ToString().Length;
                        }
                        if (l == 22)
                        {
                            txtrgdate2.Text = dtable.Rows[0]["regdate"].ToString().Substring(0, 11);
                        }
                        if (l == 21)
                        {
                            txtrgdate2.Text = dtable.Rows[0]["regdate"].ToString().Substring(0, 10);
                        }
                        if (l == 20)
                        {
                            //txtrgdate2.Text = Convert.ToString(DateTime.Now);
                            txtrgdate2.Text = dtable.Rows[0]["regdate"].ToString().Substring(0, 9);                              
                        }

                        txtcolor.Text = dtable.Rows[0]["color"].ToString();
                        txtchasisnum.Text = dtable.Rows[0]["chasisnum"].ToString();
                        txtenginenum.Text = dtable.Rows[0]["enginenum"].ToString();

                        vrfid = dtable.Rows[0]["rfid_code"].ToString().Trim();
                        divcar.Style.Add("display","inherit");

                        DataTable custtable = new DataTable();
                        SqlDataAdapter custdadapter = new SqlDataAdapter("select * from customer where ltrim(rfid_code)='" + vrfid + "' and delrec is null", consql);
                        custdadapter.Fill(custtable);

                        if (custtable.Rows.Count > 0)
                        {
                            txtrfid.Enabled = false;
                            txtrfid2.Enabled = false;                            

                            txtcustid.Enabled = false;
                            customtype.Disabled = true;                           

                            txtcompname.Enabled = true;
                            txtlastname.Enabled = true;
                            txtfirstname.Enabled = true;
                            txtmiddlename.Enabled = true;       
                            txtaddress.Enabled = true;
                            txttelno.Enabled = true;
                            txtmobilenum.Enabled = true;
                            txtemailadd.Enabled = true;
                            txtbirthday.Enabled = true;
                            txtbirthplace.Enabled = true;
                            txtnationality.Enabled = true;
                            sidtype.Disabled = false;
                            txtidnumber.Enabled = true;

                            txtrfid.Text = custtable.Rows[0]["rfid_code"].ToString();
                            txtcustid.Text = custtable.Rows[0]["custnum"].ToString();
                            customtype.Value = custtable.Rows[0]["custtype"].ToString();
                            txtcompname.Text = custtable.Rows[0]["compname"].ToString();
                            txtlastname.Text = custtable.Rows[0]["lastname"].ToString();
                            txtfirstname.Text = custtable.Rows[0]["firstname"].ToString();
                            txtmiddlename.Text = custtable.Rows[0]["middlename"].ToString();
                            txtaddress.Text = custtable.Rows[0]["address"].ToString();
                            txttelno.Text = custtable.Rows[0]["phone_num"].ToString();
                            txtmobilenum.Text = custtable.Rows[0]["mobile_num"].ToString();
                            txtemailadd.Text = custtable.Rows[0]["email_add"].ToString();

                            txtbirthday.Visible = false;
                            txtbirthday2.Visible = true;
                            txtbirthday2.Enabled = true;                           

                            birthlen = custtable.Rows[0]["birthday"].ToString().Length;

                            if (birthlen==20){
                                  txtbirthday2.Text = custtable.Rows[0]["birthday"].ToString().Substring(0, 9);
                            }

                            if (birthlen == 21){
                                  txtbirthday2.Text = custtable.Rows[0]["birthday"].ToString().Substring(0, 10);
                            }

                            if (birthlen == 22){
                                  txtbirthday2.Text = custtable.Rows[0]["birthday"].ToString().Substring(0, 11);
                            }   

                            txtbirthplace.Text = custtable.Rows[0]["birthplace"].ToString();
                            txtnationality.Text = custtable.Rows[0]["nationality"].ToString();
                            sidtype.Value = custtable.Rows[0]["idtype"].ToString();
                            txtidnumber.Text = custtable.Rows[0]["idnum"].ToString();

                            if (edit2.Value == "POPULATE")
                            {
                                ListBoxview.Style.Add("display", "none");

                                lblcarrefernces.Style.Add("display", "inherit");
                                carrefdropdownlist.Style.Add("display", "inherit");

                                if (carrefdropdownlist.SelectedValue != string.Empty)
                                {
                                    carrefdropdownlist.SelectedValue = selected;
                                    carrefdropdownlist.Text = carrefdropdownlist.SelectedValue;
                                }
                                else
                                {
                                    carrefdropdownlist.DataValueField = selected;
                                    varselected = "empty";
                                }                              
                            }
                            else
                            {
                                Listedit.Style.Add("display", "none");
                                lblcarrefernces.Style.Add("display", "inherit");
                                carrefdropdownlist.Style.Add("display", "inherit");

                                if (carrefdropdownlist.SelectedValue != string.Empty)
                                {
                                    carrefdropdownlist.SelectedValue = selected;
                                    carrefdropdownlist.Text = carrefdropdownlist.SelectedValue;
                                }
                                else
                                {
                                    carrefdropdownlist.DataValueField = selected;
                                    varselected = "empty";
                                }
                            }
                        }
                        else
                        {
                        }
                        txtplatenumber.Focus();
                    }
                }
                else
                {
                    Listedit.Focus();
                }
            }
            else
            {
                if (Listedit.Visible == true)
                {
                    if (varhidden == "car")
                    {
                        lblcarinfo.Style.Add("display", "inherit");

                        lbleditcustid.Style.Add("display", "none");
                        lblname.Style.Add("display", "none");
                        lbledit.Style.Add("display", "none");
                        lblfirst.Style.Add("display", "none");
                        lblsearch.Style.Add("display", "none");
                        customertype.Style.Add("display", "none");
                        txtsearch.Style.Add("display", "none");

                        labelplatenum.Style.Add("display", "inherit");
                        labelmake.Style.Add("display", "inherit");
                        labelmodel.Style.Add("display", "inherit");
                        lblplatesearch.Style.Add("display", "inherit");
                        txtsearchplatenum.Style.Add("display", "inherit");

                        //varhidden = "";
                    }
                }
            }
            if (txtrfid.Text != "")
            {
                ////// to filter data by car platenumber  ////               
                    DataTable platenumdtable3 = new DataTable();
                    SqlDataAdapter platenumdadapter3 = new SqlDataAdapter("select platenum from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null order by platenum asc", consql);
                    platenumdadapter3.Fill(platenumdtable3);               
               
                if (platenumdtable3.Rows.Count > 0)
                {                   
                        carrefdropdownlist.SelectedIndex = -1;
                        carrefdropdownlist.DataSource = platenumdtable3;
                        carrefdropdownlist.DataTextField = "platenum";
                        carrefdropdownlist.DataValueField = "platenum";
                        carrefdropdownlist.DataBind();

                        if (varselected == "empty")
                        {
                            varselected = "";
                            carrefdropdownlist.Text = txtplatenumber.Text;
                        }
                        platenumselected = carrefdropdownlist.Text.Trim();                        
                }
                else
                {                   
                        carrefdropdownlist.SelectedIndex = -1;
                        carrefdropdownlist.DataSource = platenumdtable3;
                        carrefdropdownlist.DataTextField = "platenum";
                        carrefdropdownlist.DataValueField = "platenum";
                        carrefdropdownlist.DataBind();

                        if (varselected=="empty")
                        {
                            varselected="";
                            carrefdropdownlist.Text = txtplatenumber.Text;
                        }
                        platenumselected = carrefdropdownlist.Text.Trim();
                }
                ////// to filter data by car platenumber  ////
            }

            ////// This is for Transaction in the Load form ///////

            if (dataextract.Value == "true")
            {
                if (transactionlistbox.Text == "")
                {
                    //string vtransnum = "";
                    //vtransnum ="";
                }
                else
                {
                    //txtinvoicenum.Enabled = true;
                    //txttransacnum.Enabled = true;

                    txtinvoicenum.Enabled = false;
                    txttransacnum.Enabled = false;

                    cmbservice.Enabled = true;
                    cmbtypeofserve.Enabled = true;
                    cmbwarstat.Enabled = true;
                    txtwarexpire.Enabled = true;
                    mainscheddropdown.Disabled = false;
                    txtsmsmess.Enabled = true;
                    txtservde.Enabled = true;

                    if (variaextract.Value == "")
                    {
                        variaextract.Value = "0";
                    }

                    int varextract2 = Convert.ToInt32(variaextract.Value);
                    int vextract = varextract2 - 1;
                    //int vextract = Int32.Parse(variaextract.Value)-1;
                    int tdcount = 0;
                    if (vextract >= 0)
                    {
                        transactionlistbox.SelectedIndex = vextract;
                    }
                    else
                    {
                        if (transactionlistbox.SelectedIndex <= 0)
                        {
                            transactionlistbox.SelectedIndex = 0;
                        }
                        else
                        {
                            transactionlistbox.SelectedIndex = 1;
                        }
                    }
                    string vtransnum = "";
                    //vtransnum = transactionlistbox.SelectedItem.Text.Substring(numspace, 20).Trim();
                    vtransnum = transact_value.Value;
                    DataTable transtable = new DataTable();
                    SqlDataAdapter transdataadapter = new SqlDataAdapter("select invoice_num,transact_num,transact_date, service, type_of_service, warstatus,warexpiration, main_schedule, main_duedate,smsmess,service_details from transactions where ltrim(transact_num)='" + vtransnum.Trim() + "' and delrec is null order by transact_num", consql);
                    transdataadapter.Fill(transtable);

                    if (transtable.Rows.Count > 0 && vtrans_add.Value != "ADD")
                    {
                        txtinvoicenum.Text = transtable.Rows[0]["invoice_num"].ToString();
                        txttransacnum.Text = transtable.Rows[0]["transact_num"].ToString();
                        tdcount = transtable.Rows[0]["transact_date"].ToString().Length;
                        if (tdcount == 22)
                        {
                            txttrandate.Text = transtable.Rows[0]["transact_date"].ToString().Substring(0, 11);
                        }

                        if (tdcount == 21)
                        {
                            txttrandate.Text = transtable.Rows[0]["transact_date"].ToString().Substring(0, 10);
                        }
                        if (tdcount == 20)
                        {
                            txttrandate.Text = transtable.Rows[0]["transact_date"].ToString().Substring(0, 9);
                        }

                        cmbtypeofserve.Text = transtable.Rows[0]["type_of_service"].ToString();
                        cmbservice.Text = transtable.Rows[0]["service"].ToString();
                        cmbwarstat.Text = transtable.Rows[0]["warstatus"].ToString();                        

                        int l = 0;
                        if (transtable.Rows[0]["warexpiration"].ToString() == null || transtable.Rows[0]["warexpiration"].ToString() == String.Empty || transtable.Rows[0]["warexpiration"].ToString().Trim().Length == 0)
                        {
                            l = 0;
                        }
                        else
                        {
                            l = transtable.Rows[0]["warexpiration"].ToString().Length;
                        }

                        if (l == 22)
                        {
                            txtwarexpire.Style.Add("display", "none");
                            txtwarexpire2.Style.Add("display", "inherit");
                            txtwarexpire2.Text = transtable.Rows[0]["warexpiration"].ToString().Substring(0, 11).Trim();
                            if (txtwarexpire2.Text == "1/1/1900")
                            {
                                txtwarexpire2.Text="";
                            }
                        }

                        if (l == 21)
                        {
                            txtwarexpire.Style.Add("display", "none");
                            txtwarexpire2.Style.Add("display", "inherit");
                            txtwarexpire2.Text = transtable.Rows[0]["warexpiration"].ToString().Substring(0, 10).Trim();
                            if (txtwarexpire2.Text == "1/1/1900")
                            {
                                txtwarexpire2.Text="";
                            }
                        }
                        if (l == 20)
                        {
                            txtwarexpire.Style.Add("display", "none");
                            txtwarexpire2.Style.Add("display", "inherit");
                            txtwarexpire2.Text = transtable.Rows[0]["warexpiration"].ToString().Substring(0, 9).Trim();
                            if (txtwarexpire2.Text == "1/1/1900")
                            {
                                txtwarexpire2.Text="";
                            }
                        }

                        mainscheddropdown.Value = transtable.Rows[0]["main_schedule"].ToString();
                        tdcount = 0;
                        tdcount = transtable.Rows[0]["main_duedate"].ToString().Length;
                        if (tdcount == 22)
                        {
                            txtmaindue.Text = transtable.Rows[0]["main_duedate"].ToString().Substring(0, 11);
                        }

                        if (tdcount == 21)
                        {
                            txtmaindue.Text = transtable.Rows[0]["main_duedate"].ToString().Substring(0, 10);
                        }
                        if (tdcount == 20)
                        {
                            txtmaindue.Text = transtable.Rows[0]["main_duedate"].ToString().Substring(0, 9);
                        }

                        if (cmbtypeofserve.SelectedItem.Text.Trim() == "MAINTENANCE" || cmbtypeofserve.SelectedItem.Text.Trim() == "MAINTENANCE / WARRANTY'")
                        {
                            //cmbwarstat.Enabled          = false;
                            //txtwarexpire.Enabled        = false;
                            //txtwarexpire2.Enabled       = false;

                            //mainscheddropdown.Disabled  = true;
                            //txtmaindue.Enabled          = true;
                            //txtsmsmess.Enabled          = true;

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mainwar()", true);   
                        }

                        if (cmbtypeofserve.SelectedItem.Text.Trim() == "WARRANTY")
                        {
                            //cmbwarstat.Enabled          = true;
                            //txtwarexpire.Enabled        = true;
                            //txtwarexpire2.Enabled       = true;

                            //mainscheddropdown.Disabled  = true;
                            //txtmaindue.Text             = "";
                            //txtmaindue.Enabled          = false;
                            //txtsmsmess.Enabled          = false;

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "war()", true); 
                        }

                        txtsmsmess.Text = transtable.Rows[0]["smsmess"].ToString();
                        txtservde.Text = transtable.Rows[0]["service_details"].ToString();
                        transactionedit.Value = "EDITED";
                        trans_extracted = "populated";

                        txtservde.Focus();
                        divtransact.Style.Add("display","inherit");

                        if (vcarrefhidden != "" && transactionlistbox.SelectedIndex == 0)
                        {
                            //vcarrefhidden = carrefhidden.Value.Trim();
                            transactionlistbox.SelectedIndex = transactionlistbox.SelectedIndex;
                            //carrefdropdownlist.Text = vcarrefhidden;
                        }
                        else
                        {
                            //carrefdropdownlist.Text = "";
                            carrefdropdownlist.SelectedItem.Value = vcarrefhidden;
                        }

                        if (transactionlistbox.SelectedIndex == 0)
                        {
                            transactionlistbox.SelectedIndex = 0;
                        }
                        else
                        {
                            transactionlistbox.SelectedIndex = 1;
                        }
                    }
                }
            }
            ////// This is for Transaction in the Load form ///////
        }
        else
        {
                       trans_extracted = "";
                       if (txtbirthday2.Text != null && txtidnumber.Text != String.Empty && recordedited == "edited")
                       {
                           //var_valid = "executed";
                           //txtbirthplace.Focus();
                       }
        }
        txtrfid.Enabled = false;

        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");
        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");        

        // Sendsms();    I have disabled this for sending of SMS features, but this will be enable in the future
    }

    public void Sendsms()
    {       
        string n = "no";
        DateTime currdate = DateTime.Now.AddDays(7);
        //String currdate = DateTime.Now.AddDays(7).Date.ToShortDateString();

        DataTable smsdata = new DataTable();
        SqlDataAdapter smsadapter = new SqlDataAdapter("select transact_num, mobile_num, smsmess, idnum, lastname, firstname, address from transactions where main_duedate='" + currdate + "' and mssgsent='" + n + "' and delrec is null order by transact_num  ", consql);
        smsadapter.Fill(smsdata);

        if(smsdata.Rows.Count>0)
        {
            resultlist.Style.Add("display", "inherit");
            resultlist.Items.Clear();
            resultlist.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
            resultlist.Items.Add(("").PadLeft(1, '\u00A0') + "We have send SMS Message for these customer");
            resultlist.Items.Add("               ");
            resultlist.Items.Add("               ");
            resultlist.Items.Add(("").PadLeft(1, '\u00A0') + "Transaction no." + ("").PadLeft(4, '\u00A0') + "Mobile no." + ("").PadLeft(4, '\u00A0') + "Id no." + ("").PadLeft(10, '\u00A0') + "Lastname" + ("").PadLeft(9, '\u00A0') + "Firstname" + ("").PadLeft(8, '\u00A0') + "Address");
            resultlist.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (DataRow row in smsdata.Rows)
            {
              string y = "yes";
              String vtransact_num = row[0].ToString();
              String message = HttpUtility.UrlEncode("Hello world!");
              String vmobileno = "63" + row[1].ToString().Substring(1,10);
              String vmssg = row[2].ToString();

              String vidnum = row[3].ToString();
              String vlastname = row[4].ToString();
              String vfirstname = row[5].ToString();
              String vaddress = row[6].ToString();
              
                DataTable updatesms = new DataTable();
                SqlDataAdapter updateadapter = new SqlDataAdapter("update transactions set mssgsent='" + y + "' where transact_num ='" + vtransact_num + "' ",consql);                
                updateadapter.Fill(updatesms);
                updateadapter.Update(updatesms);               

                //// this is to populate the result listbox ///                     

                     int suppcount = 0;
                     string varcust = "";

                     int scompcount = 0;
                     string varcompcount ="";
                 
                     int count = 0;
                     int compcount = 0;

                     int vlastcount = 0;
                     int lastcount = 0;

                     int vfirstcount = 0;
                     int firstcount = 0;
                     
                          li = new ListItem();
                          li.Value = row[0].ToString();

                          if (li.Value != "")
                          {
                              varcust = row[1].ToString().Trim();
                              suppcount = varcust.Length;
                              count = 13 - suppcount;

                              varcompcount = row[3].ToString().Trim();
                              scompcount = varcompcount.Length;
                              compcount = 17 - scompcount;

                              vlastcount = vlastname.Length;
                              lastcount = 17 - vlastcount;

                              vfirstcount = vfirstname.Length;
                              firstcount = 17 - vfirstcount;

                              li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(compcount, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(lastcount, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(firstcount, '\u00A0') + row[6].ToString();
                          }            
                              resultlist.Items.Add(li);

                //// this is to populate the result listbox ///

                ///  I have disabled this for sending of SMS features, but this will be enable in the future  ///
               
                //SendSMSToURL("http://www.isms.com.my/isms_send.php?un=voicecontact&pwd=Seth2016&dstno='" + vmobileno + "'&msg='" + vmssg + "'&type=1&sendid=nards");

                ///  I have disabled this for sending of SMS features, but this will be enable in the future  ///
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text","sendSMStone()",true );
            resultlist.Focus();              
        }
    }

    private string SendSMSToURL(string getUri)
    {
        string SentResult = String.Empty;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getUri);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader responseReader = new StreamReader(response.GetResponseStream());

        String resultmsg = responseReader.ReadToEnd();
        responseReader.Close();

        int StartIndex = 0;
        int LastIndex = resultmsg.Length;

        if (LastIndex > 0)
            SentResult = resultmsg.Substring(StartIndex, LastIndex);

        responseReader.Dispose();

        return SentResult;
    }
    
    protected void btndelete_Click(object sender, EventArgs e)
    {
        confirmdiv.Style.Add("display", "none");
        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();
    
        txtplatenumber.Text = "";
        txtmake.Text = "";
        txtmodel.Text = "";
        txtregisnum.Text = "";
        txtrgdate.Text = "Date";
        txtrgdate2.Text = "";
        txtcolor.Text = "";
        txtchasisnum.Text = "";
        txtenginenum.Text = "";

        txtplatenumber.Enabled = false;
        txtmake.Enabled = false;
        txtmodel.Enabled = false;
        txtregisnum.Enabled = false;
        txtrgdate.Enabled = false;
        txtcolor.Enabled = false;
        txtchasisnum.Enabled = false;
        txtenginenum.Enabled = false;        
        
        
        hiddenfieldrfid.Value = "executed";

        varhidden = "";
        Hiddenfield_car.Value = "";

        lblcustrequired.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");

        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");

        lbledit.Style.Add("left", "132px");
        lblname.Style.Add("left", "301px");
        lblname.Text = "Lastname";
        lblfirst.Style.Add("left", "443px");

        lblcomp.Style.Add("left", "585px");
        lblcomp.Style.Add("font-size", "12px");
        lblcomp.Style.Add("top", "11px");

        lblsearch.Style.Add("left", "690px");
        customertype.Style.Add("left", "755px");
        txtsearch.Style.Add("left", "852px");
        txtsearch.Style.Add("right", "276px");
        lbledit.Style.Add("width", "621px");

        lbleditcustid.Style.Add("display", "inherit");
        lbleditcustid.Style.Add("left", "150px");

        lblname.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        lblfirst.Style.Add("display", "inherit");
        lblcomp.Style.Add("display","inherit");
        lblsearch.Style.Add("display", "inherit");
        customertype.Style.Add("display", "inherit");
        txtsearch.Style.Add("display", "inherit");

        Label2.Style.Add("display","inherit");

        if (txtbirthday2.Text == string.Empty)
        {
            txtbirthday2.Visible = false;
            txtbirthday.Visible = true;
        }        

        edit = "DELETE";
        edit2.Value = "DELETE";
        HiddenField_edit.Value = "DELETE";

        lblError.Text = "";
        //Label2.Visible = true;      
        lblcustid.Visible = true;
        txtcustid.Visible = true;
        txtlastname.Visible = true;
        txtlastname.Visible = true;
        lblfirstname.Visible = true;
        txtfirstname.Visible = true;

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

    protected void Button2_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("Do you want to save this new record?", "Saving new record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question); 
    if (no_option.Value != "selected")
       {
        consql.Close();

        cmd.CommandType = System.Data.CommandType.Text;
        consql.Open();
        
        Textlog2.Style.Add("display", "none");
        Listedit.Visible = false;
        string selected = "";
        string varbirthday = "";

        if (txtbirthday2.Visible == true)
        {
            varbirthday = txtbirthday2.Text;
            txtbirthday2.Visible = false;
            txtbirthday.Visible = true;
        }
        else
        {
            varbirthday = txtbirthday.Text;
        }

        txtcustid.Text = txtcustid.Text.ToString();
        selected = txtcustid2.Text.Trim();

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("delete from customer where ltrim(custnum)='" + selected + "'  ", consql);
        //SqlDataAdapter dadapter = new SqlDataAdapter("update customer set delrec='" + "deleted" + "' where ltrim(custnum)='" + selected + "'  ", consql);
        dadapter.Fill(dtable);

        if (dtable.Rows.Count > 0)
        {
            dadapter.Update(dtable);
            lbltel.Style.Add("display", "none");
        }
        else
        {            
            cmd.Connection = consql;
            if (confirmed.Value == "yes")
            {                          
                cmd.CommandText = "insert into customer values('" + txtrfid.Text + "','" + txtcustid.Text + "','" + customtype.Value + "','" + txtcompname.Text + "','" + txtlastname.Text + "','" + txtfirstname.Text + "','" + txtmiddlename.Text + "', '" + txtaddress.Text + "', '" + txttelno.Text + "','" + txtmobilenum.Text + "', '" + txtemailadd.Text + "', '" + varbirthday + "','" + txtbirthplace.Text + "','" + txtnationality.Text + "','" + sidtype.Value + "','" + txtidnumber.Text + "',null)";                                
                if (cmd.ExecuteNonQuery() == 1)
                {
                    confirmed.Value = "";
                    lblError.Visible = true;
                    lblError.Text = "New record saved";

                    edit2.Value = "";
                    edit = "";

                    lbltel.Style.Add("display", "none");
                    txtrfid.Text = "";
                    txtcustid.Text = "";
                    customtype.Value = "";
                    txtcompname.Text = "";
                    txtlastname.Text = "";
                    txtfirstname.Text = "";
                    txtmiddlename.Text = "";
                    txtaddress.Text = "";
                    txttelno.Text = "";
                    txtmobilenum.Text = "";
                    txtemailadd.Text = "";
                    txtbirthday.Text = "";
                    txtbirthplace.Text = "";
                    txtnationality.Text = "";
                    sidtype.Value = "";
                    txtidnumber.Text = "";

                    txtcustid2.Text = "";

                    carrefdropdownlist.SelectedIndex = -1;
                    hiddenfieldrfid.Value = "";

                    if (txtcustid.Text != "")
                    {
                        txtrfid2.Focus();
                    }
                    else
                    {
                        txtrfid2.Focus();
                    }
                    confirmdiv.Style.Add("display", "none");
                }
                else
                {
                    lblError.Text = "Failed to insert record";
                }               
            }
        }
    }
       else
       {        
        no_option.Value = "cancelled";       
        txtlastname.Focus();
        confirmdiv.Style.Add("display", "none");
        confirmdiv.Style.Add("display", "inherit");
        return;
       }
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        dataextract.Value = "false";
        confirmdiv.Style.Add("display", "none");
        lblcustrequired.Style.Add("display", "none");
        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        hiddenfieldrfid.Value = "executed";

        varhidden = "";
        Hiddenfield_car.Value = "";

        delete = "";
        
        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");

        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");
        //lblcomp.Visible = false;
        Listedit.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");       

        edit = "POPULATE";
        edit2.Value = "POPULATE";
        HiddenField_edit.Value = "POPULATE";

        lbleditcustid.Style.Add("display", "inherit");
        lbleditcustid.Style.Add("left", "137px");

        lblname.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");

        lblfirst.Style.Add("display", "inherit");
        lblcomp.Style.Add("display","inherit");
        lbltelephone.Style.Add("display", "inherit");

        lblsearch.Style.Add("display", "inherit");
        customertype.Style.Add("display", "inherit");
        txtsearch.Style.Add("display", "inherit");

        Label2.Style.Add("display","inherit");
        Label2.Style.Add("left","2px");

        lbledit.Style.Add("left", "126px");
        lblname.Style.Add("left", "279px");
        lblname.Text = "Lastname";
        lblfirst.Style.Add("left", "424px");

        lblcomp.Style.Add("left", "560px");
        lblcomp.Style.Add("font-size", "15px");
        lblcomp.Style.Add("top", "5px");

        lblsearch.Style.Add("left", "934px");
        customertype.Style.Add("left", "1000px");
        txtsearch.Style.Add("left", "1096px");

        lbledit.Style.Add("width", "871px");

        if (txtbirthday2.Text == string.Empty)
        {
            txtbirthday2.Visible = false;
            txtbirthday.Visible = true;
        }

        lblError.Text = "";

        txtplatenumber.Text = "";
        txtmake.Text = "";
        txtmodel.Text = "";
        txtregisnum.Text = "";
        txtrgdate.Text = "Date";
        txtrgdate2.Text = "";
        txtcolor.Text = "";
        txtchasisnum.Text = "";
        txtenginenum.Text = "";

        txtplatenumber.Enabled = false;
        txtmake.Enabled = false;
        txtmodel.Enabled = false;
        txtregisnum.Enabled = false;
        txtrgdate.Enabled = false;
        txtcolor.Enabled = false;
        txtchasisnum.Enabled = false;
        txtenginenum.Enabled = false;

        ListBoxview.Visible = false;
        ListBoxview.Visible = true;
        ListBoxview.Height = 200;

        ListBoxview.Items.Clear();
        ListBoxview.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int suppcount = 0;
        string varcust = "";

        int suppcount2 = 0;
        string varcust2 = "";

        int suppcount3 = 0;
        string varcust3 = "";

        int suppcount4 = 0;
        string varcust4 = "";

        int suppcount5 = 0;
        string varcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,lastname,firstname,compname,phone_num,mobile_num,email_add from customer where delrec is null order by custnum asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {

                varcust = row[0].ToString().Trim();
                suppcount = varcust.Length;
                count = 18 - suppcount;

                varcust2 = row[1].ToString().Trim();
                suppcount2 = varcust2.Length;
                count2 = 18 - suppcount2;

                varcust3 = row[2].ToString().Trim();
                suppcount3 = varcust3.Length;
                count3 = 18 - suppcount3;

                varcust4 = row[3].ToString().Trim();
                suppcount4 = varcust4.Length;
                count4 = 28 - suppcount4;

                varcust5 = row[4].ToString().Trim();
                suppcount5 = varcust5.Length;
                count5 = 17 - suppcount5;

                varcust6 = row[5].ToString().Trim();
                suppcount6 = varcust6.Length;
                count6 = 14 - suppcount6;
                
                li.Text = ("").PadRight('\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim();
            }           
            ListBoxview.Items.Add(li);
        }
        ListBoxview.Focus();
    }

    public void listbox()
    {
        Listedit.Visible = false;
        Listedit.Visible = true;
        Listedit.Height = 200;

        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int suppcount = 0;
        string varcust = "";

        int scompcount = 0;
        string varcompcount ="";

        int count = 0;
        int compcount = 0;

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,lastname,firstname,ltrim(compname) from customer where delrec is null order by custnum asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                varcust = row[1].ToString().Trim();
                suppcount = varcust.Length;
                count = 18 - suppcount;

                varcompcount = row[2].ToString().Trim();
                scompcount = varcompcount.Length;
                compcount = 18 - scompcount;
                                    
                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(compcount, '\u00A0') + row[3].ToString().Trim();
                //li.Selected = true;
            }            
            Listedit.Items.Add(li);
        }
        Listedit.Focus();
    }

    public void autogenerate()
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select * FROM customer where delrec is null", consql);
        dadapter.Fill(dtable);

        if (dtable.Rows.Count > 0)
        {
            string selrecord = "";
            DataTable dtable2 = new DataTable();
            SqlDataAdapter dadapter2 = new SqlDataAdapter("select top 1 * FROM customer where delrec is null order by custnum DESC", consql);
            dadapter2.Fill(dtable2);

            foreach (DataRow row in dtable2.Rows)
            {               
                selrecord = row[1].ToString().Remove(0, 4);
                //selrecord = row[1].ToString();
                long nautogen2 = Convert.ToInt64(selrecord);
                nautogen2 = nautogen2 + 1;
                txtcustid.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen2.ToString();
            }
        }
        else
        {
            if (Textlog2.Visible == false)
            {
                Textlog2.Style.Add("display", "inherit");
                Log("no existing record");
            }

            nautogen = 100000000000;
            sautogen = "CBV";
            txtcustid.Text = sautogen.Trim() + '-'.ToString().Trim() + nautogen + 1;
        }
    }

    public void Log(string str)
    {
        if (Textlog2.Text != " ")
        {
            //Textlog2.Text += DateTime.Now.ToString() + " : " + str + Environment.NewLine;
            Textlog2.Text += str + Environment.NewLine;
        }
    }

    protected void txtlastname_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
    }    
    
    protected void Buttonrfid_click(object sender, EventArgs e)
    {
        if (valid == 1)
        {
            valid = 0;
            //txtrfid.Focus();
            txtrfid2.Focus();
        }
        else
        {
            if (edit2.Value == "POPULATE")
            {
                if (ListBoxview.Visible == true)
                {
                    ListBoxview.Focus();
                }
                else
                {
                    customtype.Focus();
                }
            }
            else
            {
                if (Listedit.Visible == true)
                {
                    Listedit.Focus();
                }
                else
                {
                    customtype.Focus();
                }
            }

        }
    }

    protected void Buttoncompname_Click(object sender, EventArgs e)
    {
        if(recordedited != "edited")
        {
           txtlastname.Focus();         
        }
        else
        {
            recordedited = "";
        }
    }         

    protected void HiddenField2_click(object sender, EventArgs e)
    {
        if (edit2.Value != "POPULATE")
        {
            string d = txtsearch.Text.ToString().Trim();
           
            edit = edit2.Value;
          
            int counter = 0;
            string searchlength = "";
            searchlength = txtsearch.Text.Trim();
            counter = searchlength.Length;

            consql.Close();
            consql.Open();

            if (Listedit.Visible == false)
            {
                lbleditcustid.Style.Add("display", "inherit");
                lblname.Style.Add("display", "inherit");
                lbledit.Style.Add("display", "inherit");
                lblfirst.Style.Add("display", "inherit");
                lblsearch.Style.Add("display", "inherit");
                customertype.Style.Add("display", "inherit");
                txtsearch.Style.Add("display", "inherit");

                Listedit.Visible = false;
                Listedit.Visible = true;
                Listedit.Style.Add("display", "inherit");
                Listedit.Items.Clear();
            }
            else
            {
                //Listedit.Style.Add("display", "inherit");
                Listedit.Items.Clear();
            }

            int suppcount = 0;
            string varcust = "";

            int scompcount = 0;
            string varcompcount = "";

            int count = 0;
            int compcount = 0;

            if (customertype.Value == "Company")
            {
                lblname.Text = "Company Name";
                lblfirst.Style.Add("left", "517px");
                lblcomp.Style.Add("display","none");
                DataTable dtable = new DataTable();
                SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,compname,firstname from customer where substring(compname,1," + counter + ") ='" + searchlength + "' and delrec is null order by compname asc", consql);
                dadapter.Fill(dtable);

                foreach (DataRow row in dtable.Rows)
                {
                    li = new ListItem();
                    li.Value = row[0].ToString();

                    if (li.Value != "")
                    {
                        varcust = row[1].ToString().Trim();
                        suppcount = varcust.Length;
                        count = 27 - suppcount;

                        li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim();
                    }
                    Listedit.Items.Add(li);
                }
            }
            else
            {
                lblname.Text = "Lastname";
                lblfirst.Style.Add("left", "450px");
                DataTable dtable = new DataTable();
                SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,lastname,firstname from customer where substring(lastname,1," + counter + ") ='" + searchlength + "' and delrec is null order by custnum asc", consql);
                dadapter.Fill(dtable);

                foreach (DataRow row in dtable.Rows)
                {
                    li = new ListItem();
                    li.Value = row[0].ToString();

                    if (li.Value != "")
                    {
                        varcust = row[1].ToString().Trim();
                        suppcount = varcust.Length;
                        count = 18 - suppcount;

                        li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim();

                        //varcust = row[1].ToString().Trim();
                        //suppcount = varcust.Length;
                        //count = 18 - suppcount;

                        //varcompcount = row[2].ToString().Trim();
                        //scompcount = varcompcount.Length;
                        //compcount = 18 - scompcount;

                        //li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(2, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(compcount, '\u00A0') + row[3].ToString().Trim();
                    }
                    Listedit.Items.Add(li);
                }
            }

            skipload.Value = "";

            //Listedit.DataBind();
            //Listedit.Focus();                
            txtsearch.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func2()", true);
        }
        else
        {
            viewing();
        }        
    }

    public void viewing()
    {        
        lbleditcustid.Style.Add("display", "inherit");
        lblname.Style.Add("display", "inherit");
        lbledit.Style.Add("display", "inherit");
        lblfirst.Style.Add("display", "inherit");
        lblsearch.Style.Add("display", "inherit");
        customertype.Style.Add("display", "inherit");
        txtsearch.Style.Add("display", "inherit");

        lbledit.Style.Add("left", "131px");
        lblname.Style.Add("left", "278px");
        lblfirst.Style.Add("left", "430px");
        lblsearch.Style.Add("left", "934px");
        customertype.Style.Add("left", "1000px");
        txtsearch.Style.Add("left", "1096px");

        lbledit.Style.Add("width", "871px");

        edit = edit2.Value;
        HiddenField_edit.Value = edit;

        int counter = 0;
        string searchlength = "";
        searchlength = txtsearch.Text.Trim();
        counter = searchlength.Length;

        consql.Close();
        consql.Open();

        ListBoxview.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "inherit");

        ListBoxview.Height = 200;

        ListBoxview.Items.Clear();
        ListBoxview.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int suppcount = 0;
        string varcust = "";

        int suppcount2 = 0;
        string varcust2 = "";

        int suppcount3 = 0;
        string varcust3 = "";

        int suppcount4 = 0;
        string varcust4 = "";

        int suppcount5 = 0;
        string varcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;

        if (customertype.Value == "Company")
        {
            edit = edit2.Value;
            HiddenField_edit.Value = edit;
            lblcomp.Style.Add("left", "560px");
            DataTable dtable = new DataTable();
            SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,lastname,firstname,compname,phone_num,mobile_num,email_add from customer where substring(compname,1," + counter + ") ='" + searchlength + "' and delrec is null order by compname asc", consql);
            dadapter.Fill(dtable);

            foreach (DataRow row in dtable.Rows)
            {
                li = new ListItem();
                li.Value = row[0].ToString();

                if (li.Value != "")
                {
                    varcust = row[0].ToString().Trim();
                    suppcount = varcust.Length;
                    count = 18 - suppcount;

                    varcust2 = row[1].ToString().Trim();
                    suppcount2 = varcust2.Length;
                    count2 = 19 - suppcount2;

                    varcust3 = row[2].ToString().Trim();
                    suppcount3 = varcust3.Length;
                    count3 = 17 - suppcount3;

                    varcust4 = row[3].ToString().Trim();
                    suppcount4 = varcust4.Length;
                    count4 = 28 - suppcount4;

                    varcust5 = row[4].ToString().Trim();
                    suppcount5 = varcust5.Length;
                    count5 = 16 - suppcount5;

                    varcust6 = row[5].ToString().Trim();
                    suppcount6 = varcust6.Length;
                    count6 = 14 - suppcount6;

                    li.Text = ("").PadRight('\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim();
                }
                ListBoxview.Items.Add(li);
            }
        }
        else
        {
            edit = edit2.Value;
            HiddenField_edit.Value = edit;
            lblcomp.Style.Add("left", "580px");
            DataTable dtable = new DataTable();
            SqlDataAdapter dadapter = new SqlDataAdapter("select custnum,lastname,firstname,compname,phone_num,mobile_num,email_add from customer where substring(lastname,1," + counter + ") ='" + searchlength + "' and delrec is null order by lastname asc", consql);
            dadapter.Fill(dtable);

            foreach (DataRow row in dtable.Rows)
            {
                li = new ListItem();
                li.Value = row[0].ToString();

                if (li.Value != "")
                {                    

                    varcust = row[0].ToString().Trim();
                    suppcount = varcust.Length;
                    count = 18 - suppcount;

                    varcust2 = row[1].ToString().Trim();
                    suppcount2 = varcust2.Length;
                    count2 = 19 - suppcount2;

                    varcust3 = row[2].ToString().Trim();
                    suppcount3 = varcust3.Length;
                    count3 = 19 - suppcount3;

                    varcust4 = row[3].ToString().Trim();
                    suppcount4 = varcust4.Length;
                    count4 = 26 - suppcount4;

                    varcust5 = row[4].ToString().Trim();
                    suppcount5 = varcust5.Length;
                    count5 = 17 - suppcount5;

                    varcust6 = row[5].ToString().Trim();
                    suppcount6 = varcust6.Length;
                    count6 = 14 - suppcount6;

                    li.Text = ("").PadRight('\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim();

                }
                ListBoxview.Items.Add(li);
            }
        }
        ListBoxview.Attributes.Add("ForeColor", "Black");
        ListBoxview.DataBind();

        skipload.Value = "";
                        
        txtsearch.Focus();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func2()", true);        
    }

    protected void buttonrfidcode_Click(object sender, EventArgs e)
    {
        edit2.Value = "";
        if (edit2.Value == "" && hiddenfieldrfid.Value != "executed" && trans_extracted != "populated" && var_valid != "executed")
        {
            hiddenfieldrfid.Value = "";           

            String varrfid = txtrfid.Text.Trim();
            DataTable vsdatatable = new DataTable();
            SqlDataAdapter vsdataadapter = new SqlDataAdapter("select * from customer where ltrim(rfid_code)='" + varrfid + "' and delrec is null", consql);
            vsdataadapter.Fill(vsdatatable);

            if (vsdatatable.Rows.Count > 0)
            {
                skipload.Value = "skip_load";
                hiddenclick.Value = "txtrfid";

                txtrfid.Enabled = false;
                txtrfid2.Enabled = false;

                txtcustid.Enabled = true;
                customtype.Disabled = false;
                txtcompname.Enabled = true;
                txtlastname.Enabled = true;
                txtfirstname.Enabled = true;
                txtmiddlename.Enabled = true;
                txtaddress.Enabled = true;
                txttelno.Enabled = true;
                txtmobilenum.Enabled = true;
                txtemailadd.Enabled = true;
                txtbirthday.Enabled = true;
                txtbirthplace.Enabled = true;
                txtnationality.Enabled = true;
                sidtype.Disabled = false;
                txtidnumber.Enabled = true;

                txtrfid.Text = vsdatatable.Rows[0]["rfid_code"].ToString();
                txtcustid.Text = vsdatatable.Rows[0]["custnum"].ToString();
                customtype.Value = vsdatatable.Rows[0]["custtype"].ToString();
                txtcompname.Text = vsdatatable.Rows[0]["compname"].ToString();
                txtlastname.Text = vsdatatable.Rows[0]["lastname"].ToString();
                txtfirstname.Text = vsdatatable.Rows[0]["firstname"].ToString();
                txtmiddlename.Text = vsdatatable.Rows[0]["middlename"].ToString();
                txtaddress.Text = vsdatatable.Rows[0]["address"].ToString();
                txttelno.Text = vsdatatable.Rows[0]["phone_num"].ToString();
                txtmobilenum.Text = vsdatatable.Rows[0]["mobile_num"].ToString();
                txtemailadd.Text = vsdatatable.Rows[0]["email_add"].ToString();

                txtbirthday.Visible = false;
                txtbirthday2.Visible = true;
                txtbirthday2.Enabled = true;

                birthlen = vsdatatable.Rows[0]["birthday"].ToString().Length;

                if (birthlen == 20)
                {
                    txtbirthday2.Text = vsdatatable.Rows[0]["birthday"].ToString().Substring(0, 9);
                }

                if (birthlen == 21)
                {
                    txtbirthday2.Text = vsdatatable.Rows[0]["birthday"].ToString().Substring(0, 10);
                }

                if (birthlen == 22)
                {
                    txtbirthday2.Text = vsdatatable.Rows[0]["birthday"].ToString().Substring(0, 11);
                }   

                txtbirthplace.Text = vsdatatable.Rows[0]["birthplace"].ToString();
                txtnationality.Text = vsdatatable.Rows[0]["nationality"].ToString();
                sidtype.Value = vsdatatable.Rows[0]["idtype"].ToString();
                txtidnumber.Text = vsdatatable.Rows[0]["idnum"].ToString();

                if (txtcompname.Text == "")
                {
                    txtcompname.Enabled = false;
                }

                txtcustid2.Text = vsdatatable.Rows[0]["custnum"].ToString();

                lbleditcustid.Style.Add("display", "none");
                lblname.Style.Add("display", "none");
                lbledit.Style.Add("display", "none");
                lblfirst.Style.Add("display", "none");
                lblsearch.Style.Add("display", "none");
                customertype.Style.Add("display", "none");
                txtsearch.Style.Add("display", "none");

                Listedit.Style.Add("display", "none");

                lblcarrefernces.Style.Add("display", "inherit");
                carrefdropdownlist.Style.Add("display", "inherit");

                ////// to filter data by car platenumber  ////
                DataTable platenumdtable = new DataTable();
                SqlDataAdapter platenumdadapter = new SqlDataAdapter("select * from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null order by rfid_code", consql);
                platenumdadapter.Fill(platenumdtable);

                if (platenumdtable.Rows.Count > 0)
                {
                    carrefdropdownlist.SelectedIndex = -1;
                    carrefdropdownlist.DataSource = platenumdtable;
                    carrefdropdownlist.DataValueField = "platenum";
                    carrefdropdownlist.DataTextField = "platenum";
                    carrefdropdownlist.DataBind();

                    int l = 0;
                    txtplatenumber.Enabled = true;
                    txtmake.Enabled = true;
                    txtmodel.Enabled = true;
                    txtregisnum.Enabled = true;

                    txtrgdate.Visible = false;
                    txtrgdate2.Visible = true;

                    txtcolor.Enabled = true;
                    txtchasisnum.Enabled = true;
                    txtenginenum.Enabled = true;

                    txtrgdate2.Enabled = true;
                    caredited.Value = "edited";

                    txtplatenumber.Text = platenumdtable.Rows[0]["platenum"].ToString();
                    txtmake.Text = platenumdtable.Rows[0]["make"].ToString();
                    txtmodel.Text = platenumdtable.Rows[0]["model"].ToString();
                    txtregisnum.Text = platenumdtable.Rows[0]["regnum"].ToString();

                    if (platenumdtable.Rows[0]["regdate"].ToString() == null || platenumdtable.Rows[0]["regdate"].ToString() == String.Empty)
                    {
                        l = 0;
                    }
                    else
                    {
                        l = platenumdtable.Rows[0]["regdate"].ToString().Length;
                    }
                    if (l == 22)
                    {
                        txtrgdate2.Text = platenumdtable.Rows[0]["regdate"].ToString().Substring(0, 11);
                    }
                    if (l == 21)
                    {
                        txtrgdate2.Text = platenumdtable.Rows[0]["regdate"].ToString().Substring(0, 10);
                    }
                    if (l == 20)
                    {
                        txtrgdate2.Text = platenumdtable.Rows[0]["regdate"].ToString().Substring(0, 9);
                    }

                    txtcolor.Text = platenumdtable.Rows[0]["color"].ToString();
                    txtchasisnum.Text = platenumdtable.Rows[0]["chasisnum"].ToString();
                    txtenginenum.Text = platenumdtable.Rows[0]["enginenum"].ToString();

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "notify()", true);
                }
                ////// to filter data by car platenumber  ////

                valid = 1;
                //txtrfid.Focus();
                txtrfid2.Focus();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "msgfunc()", true);

                lblcustrequired.Style.Add("display", "inherit");
                lblError.Visible = false;

                lblregisnumval.Style.Add("display", "none");
                Textlog2.Style.Add("display", "none");

                if (valid != 1)
                {
                    edit = "";
                    edit2.Value = "";

                    transactionlistbox.Style.Add("display", "none");

                    txtbirthday2.Visible = false;

                    txtcustid.Enabled = false;
                    customtype.Disabled = false;
                    txtcompname.Enabled = true;
                    txtlastname.Enabled = true;
                    txtfirstname.Enabled = true;
                    txtmiddlename.Enabled = true;
                    txtaddress.Enabled = true;
                    txttelno.Enabled = true;
                    txtmobilenum.Enabled = true;
                    txtemailadd.Enabled = true;
                    txtbirthday.Enabled = true;                    

                    txtbirthplace.Enabled = true;
                    txtnationality.Enabled = true;
                    sidtype.Disabled = false;
                    txtidnumber.Enabled = true;

                    txtcustid.Text = "";
                    customtype.Value = "";
                    txtcompname.Text = "";
                    txtlastname.Text = "";
                    txtfirstname.Text = "";
                    txtmiddlename.Text = "";
                    txtaddress.Text = "";
                    txttelno.Text = "";
                    txtmobilenum.Text = "";
                    txtemailadd.Text = "";
                    txtbirthday.Text = "";
                    txtbirthplace.Text = "";
                    txtnationality.Text = "";
                    sidtype.Value = "";
                    txtidnumber.Text = "";

                    txtcustid2.Text = "";

                    txtplatenumber.Text = "";
                    txtmake.Text = "";
                    txtmodel.Text = "";
                    txtregisnum.Text = "";
                    //txtrgdate.Text = "Date";
                    txtrgdate2.Text = "";
                    txtcolor.Text = "";
                    txtchasisnum.Text = "";
                    txtenginenum.Text = "";

                    txtplatenumber.Enabled = false;
                    txtmake.Enabled = false;
                    txtmodel.Enabled = false;
                    txtregisnum.Enabled = false;
                    txtrgdate.Enabled = false;
                    txtcolor.Enabled = false;
                    txtchasisnum.Enabled = false;
                    txtenginenum.Enabled = false;

                    labelranslist.Style.Add("display", "none");
                    labeltransactdate.Style.Add("display", "none");
                    labeltransactnum.Style.Add("display", "none");
                    labelinvoicenum.Style.Add("display", "none");
                    labelservice.Style.Add("display", "none");
                    labelservtype.Style.Add("display", "none");
                    labelwarstatus.Style.Add("display", "none");
                    labelmainschedule.Style.Add("display", "none");
                    labelmainduedate.Style.Add("display", "none");
                    labelsearchtransactnum1.Style.Add("display", "none");
                    labelsearchtransactnum2.Style.Add("display", "none");

                    lbltransactionlib.Style.Add("display", "inherit");
                    lblinvoicenum.Style.Add("display", "inherit");
                    txtinvoicenum.Style.Add("display", "inherit");
                    lbltransacnum.Style.Add("display", "inherit");
                    txttransacnum.Style.Add("display", "inherit");
                    lbltrandate.Style.Add("display", "inherit");
                    txttrandate.Style.Add("display", "inherit");
                    lblservice.Style.Add("display", "inherit");
                    cmbservice.Style.Add("display", "inherit");
                    lbltypeofserv.Style.Add("display", "inherit");
                    cmbtypeofserve.Style.Add("display", "inherit");
                    lblwarstat.Style.Add("display", "inherit");
                    cmbwarstat.Style.Add("display", "inherit");
                    lblwarexpire.Style.Add("display", "inherit");
                    txtwarexpire.Style.Add("display", "inherit");
                    lblmainsched.Style.Add("display", "inherit");
                    mainscheddropdown.Style.Add("display", "inherit");
                    lblmaindue.Style.Add("display", "inherit");
                    txtmaindue.Style.Add("display", "inherit");
                    lblsmsmess.Style.Add("display", "inherit");
                    txtsmsmess.Style.Add("display", "inherit");
                    lblservde.Style.Add("display", "inherit");
                    txtservde.Style.Add("display", "inherit");
                    transadd.Style.Add("display", "inherit");
                    transedit.Style.Add("display", "inherit");
                    transdelete.Style.Add("display", "inherit");

                    txtinvoicenum.Text = "";
                    txttransacnum.Text = "";
                    txttrandate.Text = "";
                    cmbservice.Text = "";
                    cmbtypeofserve.Text = "";
                    cmbwarstat.Text = "";
                    txtwarexpire.Text = "";
                    mainscheddropdown.Value = "";
                    txtmaindue.Text = "";
                    txtsmsmess.Text = "";
                    txtservde.Text = "";

                    transactionedit.Value = "";

                    txtinvoicenum.Enabled = false;
                    txttransacnum.Enabled = false;
                    txttrandate.Enabled = false;
                    cmbservice.Enabled = false;
                    cmbtypeofserve.Enabled = false;
                    cmbwarstat.Enabled = false;
                    txtwarexpire.Enabled = false;
                    mainscheddropdown.Disabled = false;
                    txtmaindue.Enabled = false;
                    txtsmsmess.Enabled = false;
                    txtservde.Enabled = false;                                  
                }
                else
                {
                    txtbirthday2.Visible = false;

                    txtcustid.Enabled = true;
                    customtype.Disabled = false;
                    txtcompname.Enabled = true;
                    txtlastname.Enabled = true;
                    txtfirstname.Enabled = true;
                    txtmiddlename.Enabled = true;
                    txtaddress.Enabled = true;
                    txttelno.Enabled = true;
                    txtmobilenum.Enabled = true;
                    txtemailadd.Enabled = true;
                    txtbirthday.Enabled = true;                    

                    txtbirthplace.Enabled = true;
                    txtnationality.Enabled = true;
                    sidtype.Disabled = false;
                    txtidnumber.Enabled = true;
                }
                autogenerate();
            }            
        }
        else
        {
            transactionedit.Value ="";
            hiddenfieldrfid.Value = "";
            var_valid ="";
        }
    }
 
    protected void btnvalidate_Click(object sender, EventArgs e)
    {
        consql.Close();

        consql.Open();
        SqlCommand seekrecord = new SqlCommand("select * from customer", consql);
        seekrecord.CommandText = "select * from customer where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null";

        dr = seekrecord.ExecuteReader();
        if (dr.HasRows == true)
        {
            consql.Close();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mssgrfid()", true);
            lblcustrequired.Style.Add("display","inherit");
            lblError.Visible = false;
            //txtrfid.Focus();
            txtrfid.Enabled = false;
            txtrfid2.Focus();
        }
        else
        {
            consql.Close();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "carrefdrop()", true);
            lblcustrequired.Style.Add("display","inherit");
            autogenerate();
            lblError.Visible = false;
            txtrfid.Enabled = false;
            customtype.Focus();

            confirmdiv.Style.Add("display", "none");
            confirmdiv.Style.Add("display","inherit");
        }
    }

    /// this is the beginning protion of the Car transaction info ///

    protected void caradd_Click(object sender, EventArgs e)
    {
        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        hiddenfieldrfid.Value = "executed";             
      
        labelplatenum.Style.Add("display","none");         
        labelmake.Style.Add("display","none");               
        labelmodel.Style.Add("display","none");              

        lblplatesearch.Style.Add("display","none");
        txtsearchplatenum.Style.Add("display","none");
        lblsearch.Style.Add("display","none");                   
      
        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        Label2.Style.Add("display", "inherit");

        //lblcarrefernces.Style.Add("display", "inherit");
        //carrefdropdownlist.Style.Add("display", "inheret");

        txtrgdate.Visible = true;
        txtrgdate2.Visible = false;

        if (txtrfid.Text != "")
        {            
            lblcarrefernces.Style.Add("display", "inherit");
            carrefdropdownlist.Style.Add("display", "inheret");

            Textlog2.Visible = false;
            Textlog2.Style.Add("display", "none");
            lblplatenumval.Visible = true;

            txtplatenumber.Enabled = true;
            txtmake.Enabled = true;
            txtmodel.Enabled = true;
            txtregisnum.Enabled = true;
            txtrgdate.Enabled = true;
            txtcolor.Enabled = true;
            txtchasisnum.Enabled = true;
            txtenginenum.Enabled = true;

            txtplatenumber.Text = "";
            txtmake.Text = "";
            txtmodel.Text = "";
            txtregisnum.Text = "";
            txtrgdate.Text = "Date";
            txtcolor.Text = "";
            txtchasisnum.Text = "";
            txtenginenum.Text = "";

            txtplatenumber.Focus();

            caredited.Value = "";
            confirmdiv.Style.Add("display","none");
            divtransact.Style.Add("display","none");

            divcar.Style.Add("display","inherit");
        }
        else
        {
            if (Textlog2.Visible == true)
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Textlog2.Text = "";
                Log("You are not allow to add new car if the RFID code is empty");
            }
            else
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Log("You are not allow to add new car if the RFID code is empty");
            }
        }
    }        

    protected void btnenginenum_Click(object sender, EventArgs e)
    {
        if (v_carsave.Value == "yes")
        {
            consql.Close();
            consql.Open();

            if (txtplatenumber2.Text != String.Empty) 
            {
                varplate = txtplatenumber2.Text.ToString().Trim();
                txtplatenumber2.Text = "";                  
            }
            else
            {
                varplate = txtplatenumber.Text.ToString().Trim();                 
            }

                DataTable tablecar = new DataTable();
                SqlDataAdapter cardataadapter = new SqlDataAdapter("select * from car where ltrim(platenum)= '" + varplate + "' and delrec is null", consql);
                cardataadapter.Fill(tablecar);         

            if (tablecar.Rows.Count > 0)
            {
                DataTable tablecar2 = new DataTable();
                SqlDataAdapter cardataadapter2 = new SqlDataAdapter("delete from car where ltrim(platenum)='" + varplate + "' ", consql);
                cardataadapter2.Fill(tablecar2);
                cardataadapter2.Update(tablecar2);

                if (txtrgdate.Text == string.Empty && txtrgdate2.Text != string.Empty)
                {
                    txtrgdate.Text = txtrgdate2.Text;
                }
                else
                {
                    if (txtrgdate.Text == "Date")
                    {
                        txtrgdate.Text = txtrgdate2.Text;
                    }
                }
                
                cmd.Connection = consql;
                cmd.CommandText = "insert into car values('" + txtrfid.Text + "','" + txtcustid.Text + "','" + txtplatenumber.Text + "','" + txtmake.Text + "','" + txtmodel.Text + "','" + txtregisnum.Text + "','" + txtrgdate.Text + "','" + txtcolor.Text + "','" + txtchasisnum.Text + "','" + txtenginenum.Text + "',null )";
                if (cmd.ExecuteNonQuery() == 1)
                {
                    lblregisnumval.Style.Add("display", "none");

                    txtplatenumber.Text = "";
                    txtmake.Text = "";
                    txtmodel.Text = "";
                    txtregisnum.Text = "";
                    txtrgdate.Text = "";
                    txtrgdate2.Text = "";

                    txtrgdate2.Visible = false;
                    txtrgdate.Visible = true;
                    txtrgdate.Enabled = true;

                    txtcolor.Text = "";
                    txtchasisnum.Text = "";
                    txtenginenum.Text = "";
                    caredited.Value = "";

                    Textlog2.Visible = true;
                    Textlog2.Style.Add("display", "inherit");
                    Textlog2.Text = "";
                    Log("one record inserted for car transaction");

                    divcar.Style.Add("display", "none");
                    divcar.Style.Add("display", "inherit");
                    txtplatenumber.Focus();

                    consql.Close();
                }
            }
            else
            {
                cmd.Connection = consql;
                cmd.CommandText = "insert into car values('" + txtrfid.Text + "','" + txtcustid.Text + "','" + txtplatenumber.Text + "','" + txtmake.Text + "','" + txtmodel.Text + "','" + txtregisnum.Text + "','" + txtrgdate.Text + "','" + txtcolor.Text + "','" + txtchasisnum.Text + "','" + txtenginenum.Text + "',null)";
                if (cmd.ExecuteNonQuery() == 1)
                {
                    lblregisnumval.Style.Add("display", "none");

                    txtplatenumber.Text = "";
                    txtmake.Text = "";
                    txtmodel.Text = "";
                    txtregisnum.Text = "";
                    txtrgdate.Text = "";
                    txtcolor.Text = "";
                    txtchasisnum.Text = "";
                    txtenginenum.Text = "";

                    Textlog2.Visible = true;
                    Textlog2.Style.Add("display", "inherit");
                    Textlog2.Text = "";
                    Log("one record inserted for car transaction");
                    txtplatenumber.Focus();
                    consql.Close();
                    divcar.Style.Add("display", "none");
                    divcar.Style.Add("display", "inherit");
                }
            }
        }
        else
        { 
            txtplatenumber.Focus(); 
            v_carsave.Value = "";
            divcar.Style.Add("display","none");
            divcar.Style.Add("display","inherit");
        }
    }

    protected void caredit_Click(object sender, EventArgs e)
    {
        dataextract.Value = "false";

        confirmdiv.Style.Add("display", "none");
        divcar.Style.Add("display","none");

        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        hiddenfieldrfid.Value = "executed";

        varhidden = "car";
        Hiddenfield_car.Value = "car";

        edit = "EDIT";
        edit2.Value = "EDIT";
        HiddenField_edit.Value = "EDIT";

        delete = "";

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        labelmake.Style.Add("left", "270");
        //labelmake.Style.Add("left", "481");

        Listedit.Visible = true;

        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
        Listedit.Style.Add("height", "220px");
        Listedit.Style.Add("width", "935px");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");
        Label2.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lblsearch.Style.Add("display", "inherit");
        lbledit.Style.Add("left","133px");
        lbledit.Style.Add("width","715px");

        labelplatenum.Style.Add("display", "inherit");
        labelmake.Style.Add("display", "inherit");

        labelmodel.Style.Add("display", "inherit");
        labelmodel.Style.Add("left", "487px");

        lblplatesearch.Style.Add("display", "inherit");
        txtsearchplatenum.Style.Add("display", "inherit");

        int varcount = 0;
        string varcar = "";
        int count = 0;

        int varcount2 = 0;
        string varcar2 = "";
        int count2 = 0;

        DataTable dtable = new DataTable();
        if (txtrfid.Text != string.Empty)
        {
            SqlDataAdapter dadapter = new SqlDataAdapter("select platenum,make,model from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null order by platenum asc", consql);
            dadapter.Fill(dtable);              
        }
        else
        {
            SqlDataAdapter dadapter = new SqlDataAdapter("select platenum,make,model from car where delrec is null order by platenum asc", consql);
            dadapter.Fill(dtable);
        }
        
        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                varcar = row[0].ToString().Trim();
                varcount = varcar.Length;
                count = 15 - varcount;

                varcar2 = row[1].ToString().Trim();
                varcount2 = varcar2.Length;
                count2 = 27 - varcount2;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim();
            }            
            Listedit.Items.Add(li);
        }
        Listedit.DataBind();
        Listedit.Focus();
    }

    protected void cardelete_Click(object sender, EventArgs e)
    {
        confirmdiv.Style.Add("display", "none");
        divcar.Style.Add("display", "none");

        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        hiddenfieldrfid.Value = "executed";

        edit = "DELETE";
        edit2.Value = "DELETE";
        HiddenField_edit.Value = "DELETE";        

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");

        Listedit.Visible = true;

        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
        Listedit.Style.Add("height", "220px");
        Listedit.Style.Add("width", "935px");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");
        Label2.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lblsearch.Style.Add("display", "inherit");
        lbledit.Style.Add("left", "133px");
        lbledit.Style.Add("width", "715px");

        labelplatenum.Style.Add("display", "inherit");
        labelmake.Style.Add("display", "inherit");

        labelmodel.Style.Add("display", "inherit");
        labelmodel.Style.Add("left", "487px");

        lblplatesearch.Style.Add("display", "inherit");
        txtsearchplatenum.Style.Add("display", "inherit");

        labelmake.Style.Add("left", "270");
        //labelmake.Style.Add("left", "481");

        int varcount = 0;
        string varcar = "";
        int count = 0;

        int varcount2 = 0;
        string varcar2 = "";
        int count2 = 0;

        DataTable dtable = new DataTable();

        if (txtrfid.Text != string.Empty)
        {
            SqlDataAdapter dadapter = new SqlDataAdapter("select platenum,make,model from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null order by platenum asc", consql);
            dadapter.Fill(dtable);
        }
        else
        {
            SqlDataAdapter dadapter = new SqlDataAdapter("select platenum,make,model from car where delrec is null order by platenum asc", consql);
            dadapter.Fill(dtable);
        }

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                varcar = row[0].ToString().Trim();
                varcount = varcar.Length;
                count = 15 - varcount;

                varcar2 = row[1].ToString().Trim();
                varcount2 = varcar2.Length;
                count2 = 27 - varcount2;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim();
            }            
            Listedit.Items.Add(li);
        }
        Listedit.DataBind();
        Listedit.Focus();

        varhidden = "car";
        Hiddenfield_car.Value = "car";

        delete = "deleted";
    }

    protected void carview_Click(object sender, EventArgs e)
    {
        dataextract.Value = "false";
        confirmdiv.Style.Add("display", "none");
        divcar.Style.Add("display","none");

        transactionlistbox.Style.Add("display", "none");
        execute_trans_module();

        hiddenfieldrfid.Value = "executed";

        varhidden = "car";
        Hiddenfield_car.Value = "car";

        delete = "";

        edit = "POPULATE";
        edit2.Value = "POPULATE";
        HiddenField_edit.Value = "POPULATE";

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");

        Label2.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lbledit.Style.Add("left","127px");
        lbledit.Style.Add("width","958px");

        lblsearch.Style.Add("display", "inherit");
        lblsearch.Style.Add("left","950px");

        labelplatenum.Style.Add("display", "inherit");
        labelmake.Style.Add("display", "inherit");
        labelmake.Style.Add("left", "247px");

        labelmodel.Style.Add("display", "inherit");
        labelmodel.Style.Add("left", "360px");

        labelregnum.Style.Add("display", "inherit");

        labelcolor.Style.Add("display", "inherit");
        labelcolor.Style.Add("left", "695px");

        labelchasisnum.Style.Add("display", "inherit");
        labelchasisnum.Style.Add("left", "808px");
        labelchasisnum.Style.Add("width", "200px");

        lblplatesearch.Style.Add("display", "none");

        txtsearchplatenum.Style.Add("display", "none");

        lblsearchviewplatenum.Style.Add("display", "inherit");
        txtserchviewplatenum.Style.Add("display", "inherit");

        ListBoxview.Visible = true;
        ListBoxview.Style.Add("display", "inherit");
        ListBoxview.Height = 180;
        ListBoxview.Items.Clear();
        ListBoxview.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int carcount = 0;
        string carcust = "";

        int carcount2 = 0;
        string carcust2 = "";

        int carcount3 = 0;
        string carcust3 = "";

        int carcount4 = 0;
        string carcust4 = "";

        int carcount5 = 0;
        string carcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;

        DataTable cardatatable = new DataTable();

        if (txtrfid.Text != string.Empty)
        {
            SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,color,chasisnum,enginenum from car where ltrim(rfid_code)='" + txtrfid.Text.Trim() + "' and delrec is null order by platenum asc", consql);
            cardataadapter.Fill(cardatatable);
        }
        else
        {
            SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,color,chasisnum,enginenum from car where delrec is null order by platenum asc", consql);
            cardataadapter.Fill(cardatatable);
        }

        foreach (DataRow row in cardatatable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                carcust = row[0].ToString().Trim();
                carcount = carcust.Length;
                //count = 17 - carcount;
                count = 13 - carcount;

                carcust2 = row[1].ToString().Trim();
                carcount2 = carcust2.Length;
                //count2 = 19 - carcount2;
                count2 = 14 - carcount2;

                carcust3 = row[2].ToString().Trim();
                carcount3 = carcust3.Length;
                count3 = 26 - carcount3;

                carcust4 = row[3].ToString().Trim();
                carcount4 = carcust4.Length;
                count4 = 16 - carcount4;

                carcust5 = row[4].ToString().Trim();
                carcount5 = carcust5.Length;
                count5 = 14 - carcount5;

                varcust6 = row[5].ToString().Trim();
                suppcount6 = varcust6.Length;
                count6 = 18 - suppcount6;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim();
            }
            ListBoxview.Items.Add(li);
        }
        ListBoxview.DataBind();
        ListBoxview.Focus();

    }

    protected void txtsearchplatenum_TextChanged(object sender, EventArgs e)
    {
        edit = "EDIT";
        edit2.Value = "EDIT";
        HiddenField_edit.Value = "EDIT";        

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        labelmake.Style.Add("left", "270");
        //labelmake.Style.Add("left", "481");

        Listedit.Visible = true;

        Listedit.Items.Clear();
        Listedit.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
        Listedit.Style.Add("height", "220px");
        Listedit.Style.Add("width", "935px");

        lblcarrefernces.Style.Add("display", "none");
        carrefdropdownlist.Style.Add("display", "none");
        Label2.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lblsearch.Style.Add("display", "inherit");
        lbledit.Style.Add("left", "133px");
        lbledit.Style.Add("width", "715px");

        labelplatenum.Style.Add("display", "inherit");
        labelmake.Style.Add("display", "inherit");

        labelmodel.Style.Add("display", "inherit");
        labelmodel.Style.Add("left", "487px");

        lblplatesearch.Style.Add("display", "inherit");
        txtsearchplatenum.Style.Add("display", "inherit");

        int varcount = 0;
        string varcar = "";
        int count = 0;

        int varcount2 = 0;
        string varcar2 = "";
        int count2 = 0;

        int subscount = 0;

        string plnselected = "";
        plnselected = txtsearchplatenum.Text.Trim();
        subscount = plnselected.Length;

        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select platenum,make,model from car where substring(platenum,1," + subscount + ")='" + plnselected + "' and delrec is null order by platenum asc", consql);
        dadapter.Fill(dtable);

        foreach (DataRow row in dtable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                varcar = row[0].ToString().Trim();
                varcount = varcar.Length;
                count = 15 - varcount;

                varcar2 = row[1].ToString().Trim();
                varcount2 = varcar2.Length;
                count2 = 27 - varcount2;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim();
            }
            Listedit.Items.Add(li);            
        }
        //Listedit.Focus();

        skipload.Value = "";

        Listedit.DataBind();
        txtsearchplatenum.Focus();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func3()", true);
    }

    protected void txtserchviewplatenum_TextChanged(object sender, EventArgs e)
    {
        edit = "POPULATE";
        edit2.Value = "POPULATE";
        HiddenField_edit.Value = "POPULATE";               

        string selected = txtserchviewplatenum.Text.Trim();
        int cntselected = selected.Length;        

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");

        Label2.Style.Add("display", "none");
        lblcarinfo.Style.Add("display", "inherit");

        lbledit.Style.Add("display", "inherit");
        lbledit.Style.Add("left", "127px");
        lbledit.Style.Add("width", "958px");

        lblsearch.Style.Add("display", "inherit");
        lblsearch.Style.Add("left", "950px");

        labelplatenum.Style.Add("display", "inherit");
        labelmake.Style.Add("display", "inherit");
        labelmake.Style.Add("left", "247px");

        labelmodel.Style.Add("display", "inherit");
        labelmodel.Style.Add("left", "360px");

        labelregnum.Style.Add("display", "inherit");

        labelcolor.Style.Add("display", "inherit");
        labelcolor.Style.Add("left", "695px");

        labelchasisnum.Style.Add("display", "inherit");
        labelchasisnum.Style.Add("left", "808px");
        labelchasisnum.Style.Add("width", "200px");

        lblplatesearch.Style.Add("display", "none");

        txtsearchplatenum.Style.Add("display", "none");

        lblsearchviewplatenum.Style.Add("display", "inherit");
        txtserchviewplatenum.Style.Add("display", "inherit");

        ListBoxview.Visible = true;
        ListBoxview.Style.Add("display", "inherit");
        ListBoxview.Height = 180;
        ListBoxview.Items.Clear();
        ListBoxview.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

        int carcount = 0;
        string carcust = "";

        int carcount2 = 0;
        string carcust2 = "";

        int carcount3 = 0;
        string carcust3 = "";

        int carcount4 = 0;
        string carcust4 = "";

        int carcount5 = 0;
        string carcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,color,chasisnum,enginenum from car where substring(platenum,1," + cntselected + ") = '" + selected + "' and delrec is null order by platenum asc", consql);
        cardataadapter.Fill(cardatatable);

        foreach (DataRow row in cardatatable.Rows)
        {
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {               
                carcust = row[0].ToString().Trim();
                carcount = carcust.Length;
                //count = 17 - carcount;
                count = 13 - carcount;

                carcust2 = row[1].ToString().Trim();
                carcount2 = carcust2.Length;
                //count2 = 19 - carcount2;
                count2 = 14 - carcount2;

                carcust3 = row[2].ToString().Trim();
                carcount3 = carcust3.Length;
                count3 = 26 - carcount3;

                carcust4 = row[3].ToString().Trim();
                carcount4 = carcust4.Length;
                count4 = 16 - carcount4;

                carcust5 = row[4].ToString().Trim();
                carcount5 = carcust5.Length;
                count5 = 14 - carcount5;

                varcust6 = row[5].ToString().Trim();
                suppcount6 = varcust6.Length;
                count6 = 18 - suppcount6;

                li.Text = ("").PadRight(1, '\u00A0') + row[0].ToString() + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim();
            }
            ListBoxview.Items.Add(li);
        }
        ListBoxview.DataBind();
        //ListBoxview.Focus();

        txtserchviewplatenum.Focus();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func4()", true);
    }

    protected void btncaref_Click(object sender, EventArgs e)
    {    
        int l = 0;
        vtrans_add.Value = "";

        Label2.Style.Add("display", "inherit");

        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");
        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");

        txtwarexpire2.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = "";        

        if (carrefhidden.Value != "none")
        {
            platenumselection = carrefhidden.Value.Trim();
            carrefdropdownlist.Text = carrefhidden.Value.Trim();
        }
        if (carrefdropdownlist.Text !="")
        {           
             platenumselection = carrefdropdownlist.Text;
             carrefdropdownlist.Text = carrefdropdownlist.Text;           
        }

        txtrgdate.Visible = false;

        txtplatenumber.Enabled=true;
        txtmake.Enabled = true;
        txtmodel.Enabled = true;
        txtregisnum.Enabled = true;
        txtrgdate2.Visible = true;
        txtcolor.Enabled = true;
        txtchasisnum.Enabled = true;
        txtenginenum.Enabled = true;       

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,regdate,color,chasisnum,enginenum from car where ltrim(rfid_code)='" + rfidselection.Trim() + "' and ltrim(platenum) = '" + platenumselection.Trim() + "' and delrec is null order by platenum asc", consql);
        cardataadapter.Fill(cardatatable);

        if (cardatatable.Rows.Count > 0)
        {
            txtplatenumber.Text = cardatatable.Rows[0]["platenum"].ToString();
            txtmake.Text = cardatatable.Rows[0]["make"].ToString();
            txtmodel.Text = cardatatable.Rows[0]["model"].ToString();
            txtregisnum.Text = cardatatable.Rows[0]["regnum"].ToString();

            if (cardatatable.Rows[0]["regdate"].ToString() == null || cardatatable.Rows[0]["regdate"].ToString() == String.Empty || cardatatable.Rows[0]["regdate"].ToString().Trim().Length == 0)
            {
                l = 0;
            }
            else
            {
                l = cardatatable.Rows[0]["regdate"].ToString().Length;
            }

            if (l == 22)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 11);
            }

            if (l == 21)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 10);
            }
            if (l == 20)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 9);
            }

            txtcolor.Text = cardatatable.Rows[0]["color"].ToString();
            txtchasisnum.Text = cardatatable.Rows[0]["chasisnum"].ToString();
            txtenginenum.Text = cardatatable.Rows[0]["enginenum"].ToString();

            if (carrefhidden.Value != "none")
            {            
                carrefdropdownlist.Text = carrefhidden.Value.Trim();
            }

            hiddenfieldrfid.Value = "executed";
            vcarrefhidden = carrefhidden.Value.Trim();
            Transaclisboxcomp();
        }        
     }

    protected void btncaredit_Click(object sender, EventArgs e)
    {
        int l = 0;
        vtrans_add.Value = "";

        Label2.Style.Add("display", "inherit");       

        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");
        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");

        txtwarexpire2.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = "";       

        if (carrefhidden.Value != "none")
        {
            platenumselection = carrefhidden.Value.Trim();
            carrefdropdownlist.Text = carrefhidden.Value.Trim();
        }
             if (carrefdropdownlist.Text != "")
             {

               platenumselection = carrefdropdownlist.Text;
               carrefdropdownlist.Text = carrefdropdownlist.Text;
             }

              txtrgdate.Visible = false;

              txtplatenumber.Enabled = true;
              txtmake.Enabled = true;
              txtmodel.Enabled = true;
              txtregisnum.Enabled = true;
              txtrgdate2.Visible = true;
              txtcolor.Enabled = true;
              txtchasisnum.Enabled = true;
              txtenginenum.Enabled = true;         

               if (carrefhidden.Value != "none")
               {
                   carrefdropdownlist.Text = carrefhidden.Value.Trim();
               }
                 transaction_edit.Value = "click_edit";      
                 hiddenfieldrfid.Value = "executed";
                 vcarrefhidden = carrefhidden.Value.Trim();
                 Transaclisboxcomp();       
    }

    protected void btncaref2_Click(object sender, EventArgs e)
    {
        int l = 0;

        txtwarexpire2.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = "";

        if (carrefhidden.Value != "none")
        {
            platenumselection = carrefhidden.Value.Trim();
            carrefdropdownlist.Text = carrefhidden.Value.Trim();
        }
        if (carrefdropdownlist.Text != "")
        {          
                platenumselection = carrefdropdownlist.Text;
                carrefdropdownlist.Text = carrefdropdownlist.Text;  
        }

        txtrgdate.Visible = false;

        txtplatenumber.Enabled = true;
        txtmake.Enabled = true;
        txtmodel.Enabled = true;
        txtregisnum.Enabled = true;
        txtrgdate2.Visible = true;
        txtcolor.Enabled = true;
        txtchasisnum.Enabled = true;
        txtenginenum.Enabled = true;

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,regdate,color,chasisnum,enginenum from car where ltrim(rfid_code)='" + rfidselection.Trim() + "' and ltrim(platenum) = '" + platenumselection.Trim() + "' and delrec is null order by platenum asc", consql);
        cardataadapter.Fill(cardatatable);

        if (cardatatable.Rows.Count > 0)
        {
            txtplatenumber.Text = cardatatable.Rows[0]["platenum"].ToString();
            txtmake.Text = cardatatable.Rows[0]["make"].ToString();
            txtmodel.Text = cardatatable.Rows[0]["model"].ToString();
            txtregisnum.Text = cardatatable.Rows[0]["regnum"].ToString();

            if (cardatatable.Rows[0]["regdate"].ToString() == null || cardatatable.Rows[0]["regdate"].ToString() == String.Empty || cardatatable.Rows[0]["regdate"].ToString().Trim().Length == 0)
            {
                l = 0;
            }
            else
            {
                l = cardatatable.Rows[0]["regdate"].ToString().Length;
            }

            if (l == 22)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 11);
            }

            if (l == 21)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 10);
            }
            if (l == 20)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 9);
            }

            txtcolor.Text = cardatatable.Rows[0]["color"].ToString();
            txtchasisnum.Text = cardatatable.Rows[0]["chasisnum"].ToString();
            txtenginenum.Text = cardatatable.Rows[0]["enginenum"].ToString();

            if (carrefhidden.Value != "none")
            {
                carrefdropdownlist.Text = carrefhidden.Value.Trim();
            }

            hiddenfieldrfid.Value = "";
            vcarrefhidden = carrefhidden.Value.Trim();
            Transaclisboxcomp();
        }
            
    }

    public void Transaclisboxcomp()
    {
        varhidden = "EXTRACT";
        Hiddenfield_car.Value = "EXTRACT";
        Hiddencar_edit.Value = "EXTRACT";

        HiddenField_edit.Value = "EXTRACT";

        edit = "EDIT";
        edit2.Value = "EDIT";

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        //lbltransactionlib.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = carrefhidden.Value.Trim();

        if (txtplatenumber.Text.Trim() != string.Empty)
        {
            rfidselection = txtrfid.Text.Trim();
            platenumselection = txtplatenumber.Text;
        }
        else
        {
            rfidselection = txtrfid.Text.Trim();
            platenumselection = carrefhidden.Value.Trim();
        }

        transactionlistbox.Height = 177;
        //transactionlistbox.Style.Add("display", "inherit");
        transactionlistbox.Items.Clear();
        //transactionlistbox.Attributes.Add("Style", "font-Bold: 'True'");
        //transactionlistbox.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
        transactionlistbox.SelectedIndex = transactionlistbox.SelectedIndex;

        trnlistcount = 0;
        
        int carcount = 0;
        string carcust = "";

        int carcount2 = 0;
        string carcust2 = "";

        int carcount3 = 0;
        string carcust3 = "";

        int carcount4 = 0;
        string carcust4 = "";

        int carcount5 = 0;
        string carcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int suppcount7 = 0;
        string varcust7 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;
        int count7 = 0; 

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select transact_date, transact_num, invoice_num, service, type_of_service, warstatus, main_schedule, main_duedate from transactions where ltrim(rfid_code)='" + rfidselection + "' and ltrim(platenum)='" + platenumselection + "' and delrec is null order by transact_num asc", consql);
        cardataadapter.Fill(cardatatable);
        platenumselection = "";

        foreach (DataRow row in cardatatable.Rows)
        {
            int dlength = 0;
            string transactdata = "";
            int dlength2 = 0;
            string mainduedate = "";
            li = new ListItem();
            li.Value = row[0].ToString();
            li.Selected = true; 
            if (li.Value != "")
            {
                dlength = row[0].ToString().Length;
                if (dlength == 22)
                {
                    transactdata = row[0].ToString().Substring(0, 10);
                    carcust = transactdata;
                }
                if (dlength == 21)
                {
                    transactdata = row[0].ToString().Substring(0, 10);
                    carcust = transactdata;
                }
                if (dlength == 20)
                {
                    transactdata = row[0].ToString().Substring(0, 9);
                    carcust = transactdata;
                }
                carcount = carcust.Length;
                count = 13 - carcount;
                numspace = carcust.Length + count; 

                carcust2 = row[1].ToString().Trim();
                carcount2 = carcust2.Length;
                count2 = 20 - carcount2;

                carcust3 = row[2].ToString().Trim();
                carcount3 = carcust3.Length;
                count3 = 18 - carcount3;

                carcust4 = row[3].ToString().Trim();
                carcount4 = carcust4.Length;                
                count4 = 35 - carcount4;

                carcust5 = row[4].ToString().Trim();
                carcount5 = carcust5.Length;                
                count5 = 27 - carcount5;

                varcust6 = row[5].ToString().Trim();
                suppcount6 = varcust6.Length;
                count6 = 14 - suppcount6;

                varcust7 = row[6].ToString().Trim();
                suppcount7 = varcust7.Length;
                count7 = 15 - suppcount7;   

                dlength2 = row[7].ToString().Length;
                if (dlength2 == 22)
                {
                    mainduedate = row[7].ToString().Substring(0, 10);
                }
                if (dlength2 == 21)
                {
                    mainduedate = row[7].ToString().Substring(0, 10);
                }
                if (dlength2 == 20)
                {
                    mainduedate = row[7].ToString().Substring(0, 9);
                }

                li.Text = ("").PadRight(1, '\u00A0') + transactdata + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim() + ("").PadRight(count7, '\u00A0') + mainduedate;
               
            }          
                transactionlistbox.Items.Add(li);
                trnlistcount = trnlistcount + 1;
                hiddentrnlistcount.Value = trnlistcount.ToString();           
        }

        if (count == 0)
        {
                divtransact.Style.Add("display","none");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "transeditmssg()", true);
        }
        else
        {
          
            lbltransactionlib.Style.Add("display", "none");
            transactionlistbox.Style.Add("display", "inherit");
            transactionlistbox.Attributes.Add("Style", "font-Bold: 'True'");
            transactionlistbox.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

            transactionlistbox.SelectedIndex = transactionlistbox.SelectedIndex;

            transactionlistbox.DataBind();
            transactionlistbox.Focus();

            if (transaction_edit.Value == "click_edit")
            {
                divtransact.Style.Add("display", "none");
                transaction_edit.Value = "";
            }
            else{
                  divtransact.Style.Add("display", "inherit");
                }

            labelranslist.Style.Add("display", "inherit");
            labeltransactdate.Style.Add("display", "inherit");
            labeltransactnum.Style.Add("display", "inherit");
            labelinvoicenum.Style.Add("display", "inherit");
            labelservice.Style.Add("display", "inherit");
            labelservtype.Style.Add("display", "inherit");
            labelwarstatus.Style.Add("display", "inherit");
            labelmainschedule.Style.Add("display", "inherit");
            labelmainduedate.Style.Add("display", "inherit");
            labelsearchtransactnum1.Style.Add("display", "inherit");
            labelsearchtransactnum2.Style.Add("display", "inherit");

            //this is for transactions textboxes and labels//

            lblinvoicenum.Style.Add("display", "none");
            txtinvoicenum.Style.Add("display", "none");
            lbltransacnum.Style.Add("display", "none");
            txttransacnum.Style.Add("display", "none");
            lbltrandate.Style.Add("display", "none");
            txttrandate.Style.Add("display", "none");
            lblservice.Style.Add("display", "none");
            cmbservice.Style.Add("display", "none");
            lbltypeofserv.Style.Add("display", "none");
            cmbtypeofserve.Style.Add("display", "none");
            lblwarstat.Style.Add("display", "none");
            cmbwarstat.Style.Add("display", "none");
            lblwarexpire.Style.Add("display", "none");
            txtwarexpire.Style.Add("display", "none");
            lblmainsched.Style.Add("display", "none");
            mainscheddropdown.Style.Add("display", "none");
            lblmaindue.Style.Add("display", "none");
            txtmaindue.Style.Add("display", "none");
            lblsmsmess.Style.Add("display", "none");
            txtsmsmess.Style.Add("display", "none");
            lblservde.Style.Add("display", "none");
            txtservde.Style.Add("display", "none");
            transadd.Style.Add("display", "none");
            transedit.Style.Add("display", "none");
            transdelete.Style.Add("display", "none");
        }        
        //this is for transactions textboxes and labels//
 
    }
    /// this is the end protion of the Car transaction info ///


    /// this is the beginning protion of the TRANSACTION info ///

    protected void transadd_Click(object sender, EventArgs e)
    {
        Label2.Style.Add("display","inherit");

        vtrans_add.Value = "ADD";

        divtransact.Style.Add("display","none");

        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");
        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");

        transactionlistbox.Style.Add("display", "none");

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        lblwarexpire.Style.Add("display", "inherit");

        lbltransactionlib.Style.Add("display", "inherit");

        labelranslist.Style.Add("display", "none");
        labeltransactdate.Style.Add("display", "none");
        labeltransactnum.Style.Add("display", "none");
        labelinvoicenum.Style.Add("display", "none");
        labelservice.Style.Add("display", "none");
        labelservtype.Style.Add("display", "none");
        labelwarstatus.Style.Add("display", "none");
        labelmainschedule.Style.Add("display", "none");
        labelmainduedate.Style.Add("display", "none");
        labelsearchtransactnum1.Style.Add("display", "none");
        labelsearchtransactnum2.Style.Add("display", "none");

        if (txtrfid.Text != "" && txtplatenumber.Text != "")
        {
            //String now = DateTime.Now.ToShortDateString();

            Textlog2.Style.Add("display", "none");

            lblinvoicenum.Style.Add("display", "inherit");
            txtinvoicenum.Style.Add("display", "inherit");
            lbltransacnum.Style.Add("display", "inherit");
            txttransacnum.Style.Add("display", "inherit");
            lbltrandate.Style.Add("display", "inherit");
            txttrandate.Style.Add("display", "inherit");
            lblservice.Style.Add("display", "inherit");
            cmbservice.Style.Add("display", "inherit");
            lbltypeofserv.Style.Add("display", "inherit");
            cmbtypeofserve.Style.Add("display", "inherit");
            lblwarstat.Style.Add("display", "inherit");
            cmbwarstat.Style.Add("display", "inherit");
            lblwarexpire.Style.Add("display", "inherit");
            txtwarexpire.Style.Add("display", "inherit");
            lblmainsched.Style.Add("display", "inherit");
            mainscheddropdown.Style.Add("display", "inherit");
            lblmaindue.Style.Add("display", "inherit");
            txtmaindue.Style.Add("display", "inherit");
            lblsmsmess.Style.Add("display", "inherit");
            txtsmsmess.Style.Add("display", "inherit");
            lblservde.Style.Add("display", "inherit");
            txtservde.Style.Add("display", "inherit");
            transadd.Style.Add("display", "inherit");
            transedit.Style.Add("display", "inherit");
            transdelete.Style.Add("display", "inherit");

            txtwarexpire2.Style.Add("display", "none");
            txtwarexpire.Style.Add("display", "inherit");
            txtinvoicenum.Enabled = true;
            txttransacnum.Enabled = false;
            txttrandate.Enabled = false;
            cmbservice.Enabled = true;
            cmbtypeofserve.Enabled = true;
            cmbwarstat.Enabled = true;
            txtwarexpire.Enabled = true;
            mainscheddropdown.Disabled = false;
            txtmaindue.Enabled = true;
            txtsmsmess.Enabled = true;
            txtservde.Enabled = true;

            txttransacnum.Text = "";
            txttrandate.Text = "";
            cmbservice.Text = "";
            cmbtypeofserve.Text = "";
            cmbwarstat.Text = "";
            txtwarexpire.Text = "";
            mainscheddropdown.Value = "";
            txtmaindue.Text = "";
            txtsmsmess.Text = "";
            txtservde.Text = "";

            transactionedit.Value = "";

            txtinvoicenum.Text = "INV-";
            //txttrandate.Text = now;

            if (carrefdropdownlist.SelectedIndex == 0) {
                //carrefdropdownlist.SelectedIndex = 1;
                carrefdropdownlist.SelectedIndex = - 1;
            }
            //carrefdropdownlist.Text = txtplatenumber.Text;
            carrefdropdownlist.SelectedValue = txtplatenumber.Text;

            txtinvoicenum.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
        }
        else
        {
            if (Textlog2.Visible == true)
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Textlog2.Text = "";
                Log("You are not allow to add new invoice no. if the RFID code and plate no. is empty");
            }
            else
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Textlog2.Text = "";
                Log("You are not allow to add new invoice no. if the RFID code and plate no. is empty");
            }
        }
                transactionlistbox.Style.Add("display", "none");
    }

    protected void transedit_Click(object sender, EventArgs e)
    {
        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");
    }
   
    protected void transdelete_Click(object sender, EventArgs e)
    {
        vtrans_add.Value = "";
        Label2.Style.Add("display", "inherit");

        lblcarinfo.Style.Add("display", "none");
        labelplatenum.Style.Add("display", "none");
        labelmake.Style.Add("display", "none");
        labelmodel.Style.Add("display", "none");
        lblplatesearch.Style.Add("display", "none");
        txtsearchplatenum.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");

        deletrans();        
  }
     
    public void deletrans()
    {
        int l = 0;

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = "";

        if (carrefhidden.Value != "none")
        {
            platenumselection = carrefhidden.Value.Trim();
            carrefdropdownlist.Text = carrefhidden.Value.Trim();
        }
        if (carrefdropdownlist.Text != "")
        {
            platenumselection = carrefdropdownlist.Text;
            carrefdropdownlist.Text = carrefdropdownlist.Text;
        }

        txtrgdate.Visible = false;

        txtplatenumber.Enabled = true;
        txtmake.Enabled = true;
        txtmodel.Enabled = true;
        txtregisnum.Enabled = true;
        txtrgdate2.Visible = true;
        txtcolor.Enabled = true;
        txtchasisnum.Enabled = true;
        txtenginenum.Enabled = true;

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,regdate,color,chasisnum,enginenum from car where ltrim(rfid_code)='" + rfidselection.Trim() + "' and ltrim(platenum) = '" + platenumselection.Trim() + "' and delrec is null order by platenum asc", consql);
        cardataadapter.Fill(cardatatable);

        if (cardatatable.Rows.Count > 0)
        {
            txtplatenumber.Text = cardatatable.Rows[0]["platenum"].ToString();
            txtmake.Text = cardatatable.Rows[0]["make"].ToString();
            txtmodel.Text = cardatatable.Rows[0]["model"].ToString();
            txtregisnum.Text = cardatatable.Rows[0]["regnum"].ToString();

            if (cardatatable.Rows[0]["regdate"].ToString() == null || cardatatable.Rows[0]["regdate"].ToString() == String.Empty || cardatatable.Rows[0]["regdate"].ToString().Trim().Length == 0)
            {
                l = 0;
            }
            else
            {
                l = cardatatable.Rows[0]["regdate"].ToString().Length;
            }

            if (l == 22)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 11);
            }

            if (l == 21)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 10);
            }
            if (l == 20)
            {
                txtrgdate2.Text = cardatatable.Rows[0]["regdate"].ToString().Substring(0, 9);
            }

            txtcolor.Text = cardatatable.Rows[0]["color"].ToString();
            txtchasisnum.Text = cardatatable.Rows[0]["chasisnum"].ToString();
            txtenginenum.Text = cardatatable.Rows[0]["enginenum"].ToString();

            if (carrefhidden.Value != "none")
            {
                carrefdropdownlist.Text = carrefhidden.Value.Trim();
                vcarrefhidden = carrefhidden.Value.Trim();
            }
            else
            {
                carrefdropdownlist.Text = carrefdropdownlist.Text.Trim();
                vcarrefhidden = carrefdropdownlist.Text.Trim();
            }
                Transaclisboxdel();
        }        
    }

    public void Transaclisboxdel()
    {
        varhidden = "DELETE";
        Hiddenfield_car.Value = "DELETE";
        Hiddencar_edit.Value = "DELETE";

        HiddenField_edit.Value = "DELETE";

        edit        = "DELETE";
        edit2.Value = "DELETE";

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");       

        //lbltransactionlib.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inherit");

        string rfidselection = txtrfid.Text.Trim();
        string platenumselection = carrefdropdownlist.SelectedItem.Text;
        //string platenumselection = carrefhidden.Value.Trim();

        //transactionlistbox.Style.Add("display", "inherit");
        transactionlistbox.Items.Clear();
        //transactionlistbox.Attributes.Add("Style", "font-Bold: 'True'");
        //transactionlistbox.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");
        transactionlistbox.SelectedIndex = transactionlistbox.SelectedIndex;

        trnlistcount = 0;
        
        int carcount = 0;
        string carcust = "";

        int carcount2 = 0;
        string carcust2 = "";

        int carcount3 = 0;
        string carcust3 = "";

        int carcount4 = 0;
        string carcust4 = "";

        int carcount5 = 0;
        string carcust5 = "";

        int suppcount6 = 0;
        string varcust6 = "";

        int count = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select transact_date, transact_num, invoice_num, service, type_of_service, warstatus, main_schedule, main_duedate from transactions where ltrim(rfid_code)='" + rfidselection + "' and ltrim(platenum)='" + platenumselection + "' and delrec is null order by transact_num asc", consql);
        cardataadapter.Fill(cardatatable);

        foreach (DataRow row in cardatatable.Rows)
        {
            int dlength = 0;
            string transactdata = "";
            int dlength2 = 0;
            string mainduedate = "";
            li = new ListItem();
            li.Value = row[0].ToString();

            if (li.Value != "")
            {
                dlength = row[0].ToString().Length;
                if (dlength == 22)
                {
                    transactdata = row[0].ToString().Substring(0, 10);
                    carcust = transactdata;
                }
                if (dlength == 21)
                {
                    transactdata = row[0].ToString().Substring(0, 10);
                    carcust = transactdata;
                }
                if (dlength == 20)
                {
                    transactdata = row[0].ToString().Substring(0, 9);
                    carcust = transactdata;
                }
                carcount = carcust.Length;
                count = 13 - carcount;
                numspace = carcust.Length + count; 

                carcust2 = row[1].ToString().Trim();
                carcount2 = carcust2.Length;
                count2 = 20 - carcount2;

                carcust3 = row[2].ToString().Trim();
                carcount3 = carcust3.Length;
                count3 = 18 - carcount3;

                carcust4 = row[3].ToString().Trim();
                carcount4 = carcust4.Length;
                count4 = 35 - carcount4;
                //count4 = 31 - carcount4;

                carcust5 = row[4].ToString().Trim();
                carcount5 = carcust5.Length;
                count5 = 27 - carcount5;
                //count5 = 22 - carcount5;

                varcust6 = row[5].ToString().Trim();
                suppcount6 = varcust6.Length;
                count6 = 14 - suppcount6;
                //count6 = 9 - suppcount6;

                dlength2 = row[7].ToString().Length;
                if (dlength2 == 22)
                {
                    mainduedate = row[7].ToString().Substring(0, 10);
                }
                if (dlength2 == 21)
                {
                    mainduedate = row[7].ToString().Substring(0, 10);
                }
                if (dlength2 == 20)
                {
                    mainduedate = row[7].ToString().Substring(0, 9);
                }

                li.Text = ("").PadRight(1, '\u00A0') + transactdata + ("").PadRight(count, '\u00A0') + row[1].ToString().Trim() + ("").PadRight(count2, '\u00A0') + row[2].ToString().Trim() + ("").PadRight(count3, '\u00A0') + row[3].ToString().Trim() + ("").PadRight(count4, '\u00A0') + row[4].ToString().Trim() + ("").PadRight(count5, '\u00A0') + row[5].ToString().Trim() + ("").PadRight(count6, '\u00A0') + row[6].ToString().Trim() + ("").PadRight(9, '\u00A0') + mainduedate;
            }                       

            transactionlistbox.Items.Add(li);
            trnlistcount = trnlistcount + 1;
            hiddentrnlistcount.Value = trnlistcount.ToString();
        }

        if (count == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "transdeletemssg()", true);
        }
        else
        {
            lbltransactionlib.Style.Add("display", "none");
            transactionlistbox.Style.Add("display", "inherit");
            transactionlistbox.Attributes.Add("Style", "font-Bold: 'True'");
            transactionlistbox.Attributes.Add("Style", "font-family: 'Courier New', Courier, monospace");

            transactionlistbox.SelectedIndex = transactionlistbox.SelectedIndex;

            transactionlistbox.DataBind();
            transactionlistbox.Focus();

            labelranslist.Style.Add("display", "inherit");
            labeltransactdate.Style.Add("display", "inherit");
            labeltransactnum.Style.Add("display", "inherit");
            labelinvoicenum.Style.Add("display", "inherit");
            labelservice.Style.Add("display", "inherit");
            labelservtype.Style.Add("display", "inherit");
            labelwarstatus.Style.Add("display", "inherit");
            labelmainschedule.Style.Add("display", "inherit");
            labelmainduedate.Style.Add("display", "inherit");
            labelsearchtransactnum1.Style.Add("display", "inherit");
            labelsearchtransactnum2.Style.Add("display", "inherit");

            //this is for transactions textboxes and labels//

            lblinvoicenum.Style.Add("display", "none");
            txtinvoicenum.Style.Add("display", "none");
            lbltransacnum.Style.Add("display", "none");
            txttransacnum.Style.Add("display", "none");
            lbltrandate.Style.Add("display", "none");
            txttrandate.Style.Add("display", "none");
            lblservice.Style.Add("display", "none");
            cmbservice.Style.Add("display", "none");
            lbltypeofserv.Style.Add("display", "none");
            cmbtypeofserve.Style.Add("display", "none");
            lblwarstat.Style.Add("display", "none");
            cmbwarstat.Style.Add("display", "none");
            lblwarexpire.Style.Add("display", "none");
            txtwarexpire.Style.Add("display", "none");

            txtwarexpire2.Style.Add("display", "none");

            lblmainsched.Style.Add("display", "none");
            mainscheddropdown.Style.Add("display", "none");
            lblmaindue.Style.Add("display", "none");
            txtmaindue.Style.Add("display", "none");
            lblsmsmess.Style.Add("display", "none");
            txtsmsmess.Style.Add("display", "none");
            lblservde.Style.Add("display", "none");
            txtservde.Style.Add("display", "none");
            transadd.Style.Add("display", "none");
            transedit.Style.Add("display", "none");
            transdelete.Style.Add("display", "none");
        }       
            //this is for transactions textboxes and labels//        
    }

    protected void transview_Click(object sender, EventArgs e)
    {
        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");
    }

    protected void btninvoicenum_Click(object sender, EventArgs e)
    {
        cmbservice.Focus();
    }
    protected void btntransactnum_Click(object sender, EventArgs e)
    {
        txttrandate.Focus();
    }
    protected void btntrandate_Click(object sender, EventArgs e)
    {
        cmbservice.Focus();
    }
    protected void btnwarexpire_Click(object sender, EventArgs e)
    {
        mainscheddropdown.Focus();
    }

    protected void btnmaineched_Click(object sender, EventArgs e)
    {
        txtmaindue.Focus();
    }

    protected void btnmaindue_Click(object sender, EventArgs e)
    {
        txtsmsmess.Focus();
    }

    protected void btnservede_Click(object sender, EventArgs e)
    {
        if (transact_save.Value == "yes")
        {
            consql.Close();
            consql.Open();

            string vsmssend = "no";
            string varinvoicenum = txtinvoicenum.Text.ToString().Trim();
            string vartransactnum = txttransacnum.Text.ToString().Trim();

            DateTime vtrandate = new DateTime();          
            if (txttrandate.Text != string.Empty)
            {
                vtrandate = Convert.ToDateTime(txttrandate.Text);
            }           

            DataTable trndatatable = new DataTable();
            SqlDataAdapter trndataadapter = new SqlDataAdapter("select * from transactions where invoice_num = '" + varinvoicenum + "' and ltrim(transact_num)='" + vartransactnum + "' and delrec is null", consql);
            trndataadapter.Fill(trndatatable);

            if (txtwarexpire.Text == "")
            {
                txtwarexpire.Text = txtwarexpire2.Text;
            }

            if (trndatatable.Rows.Count > 0)
            {
                DataTable trndatatable2 = new DataTable();
                SqlDataAdapter trndataadapter2 = new SqlDataAdapter("delete from transactions where invoice_num = '" + varinvoicenum + "' ", consql);
                trndataadapter2.Fill(trndatatable2);
                trndataadapter2.Update(trndatatable2);
                        
                     cmd.Connection = consql;
                     cmd.CommandText = "insert into transactions values('" + txtrfid.Text + "','" + txtcustid.Text + "','" + txtplatenumber.Text + "','" + txtinvoicenum.Text + "','" + txttransacnum.Text + "','" + vtrandate + "','" + cmbservice.Text + "','" + cmbtypeofserve.Text + "','" + cmbwarstat.Text + "','" + txtwarexpire.Text + "','" + mainscheddropdown.Value + "','" + txtmaindue.Text + "','" + txtsmsmess.Text + "', '" + txtservde.Text + "','" + txtmobilenum.Text + "','" + vsmssend + "', '" + txtidnumber.Text + "', '" + txtlastname.Text + "', '" + txtfirstname.Text + "', '" + txtaddress.Text + "',null)";
                     if (cmd.ExecuteNonQuery() == 1)
                     {
                         Textlog2.Style.Add("display", "inherit");
                         Textlog2.Text = "";
                         Textlog2.Text = "One record for transaction was inserted";

                         txtinvoicenum.Enabled = true;

                         txtinvoicenum.Text = "";
                         txttransacnum.Text = "";
                         txttrandate.Text = "";

                         cmbservice.Text = "";
                         cmbtypeofserve.Text = "";
                         cmbwarstat.Text = "";
                         txtwarexpire.Text = "";
                         txtwarexpire2.Text = "";
                         mainscheddropdown.Value = "";
                         txtmaindue.Text = "";
                         txtsmsmess.Text = "";
                         txtservde.Text = "";

                         hiddenfieldrfid.Value = "";
                         trans_extracted = "";

                         txtwarexpire2.Style.Add("display", "none");
                         txtwarexpire.Style.Add("display", "inherit");

                         divtransact.Style.Add("display","inherit");

                         txtinvoicenum.Text = "INV-";
                         txtinvoicenum.Focus();
                         ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setCursorPositionToEnd('txtinvoicenum');", true);
                     }
            }
            else
            {
                cmd.Connection = consql;
                cmd.CommandText = "insert into transactions values('" + txtrfid.Text + "','" + txtcustid.Text + "','" + txtplatenumber.Text + "','" + txtinvoicenum.Text + "','" + txttransacnum.Text + "','" + vtrandate + "','" + cmbservice.Text + "','" + cmbtypeofserve.Text + "','" + cmbwarstat.Text + "','" + txtwarexpire.Text + "','" + mainscheddropdown.Value + "','" + txtmaindue.Text + "','" + txtsmsmess.Text + "', '" + txtservde.Text + "','" + txtmobilenum.Text + "','" + vsmssend + "', '" + txtidnumber.Text + "', '" + txtlastname.Text + "', '" + txtfirstname.Text + "', '" + txtaddress.Text + "',null)";
                if (cmd.ExecuteNonQuery() == 1)
                {                    
                    Textlog2.Style.Add("display", "inherit");
                    Textlog2.Text = "";
                    Textlog2.Text = "One record for transaction was inserted";

                    txtinvoicenum.Text = "";
                    txttransacnum.Text = "";
                    txttrandate.Text = "";                    
                
                    cmbservice.Text = "";
                    cmbtypeofserve.Text = "";
                    cmbwarstat.Text = "";
                    txtwarexpire.Text = "";
                    txtwarexpire2.Text = "";
                    mainscheddropdown.Value = "";
                    txtmaindue.Text = "";
                    txtsmsmess.Text = "";
                    txtservde.Text = "";

                    hiddenfieldrfid.Value = "";
                    trans_extracted = "";

                    txtwarexpire2.Style.Add("display", "none");
                    txtwarexpire.Style.Add("display", "inherit");

                    txtinvoicenum.Text = "INV-";
                    txtinvoicenum.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setCursorPositionToEnd('txtinvoicenum');", true);                    
                }
            }
        }
        else
        {
            transact_save.Value = "";
            cmbservice.Focus();
        }
    }

    public void servedetails()
    {
        validation = "";
        cmd.CommandType = System.Data.CommandType.Text;
        consql.Open();
        cmd.Connection = consql;
        HiddenField1.Value = "false";        
    }

    protected void binvnum_Click(object sender, EventArgs e)
    {
        autotran();
        cmbservice.Focus();
        String now = DateTime.Now.ToShortDateString();
        txttrandate.Text = now;

        return;
    }

    public void autotran()
    {
        DataTable dtable = new DataTable();
        SqlDataAdapter dadapter = new SqlDataAdapter("select * FROM transactions where delrec is null", consql);
        dadapter.Fill(dtable);

        if (dtable.Rows.Count > 0)
        {
            string selrecord = "";
            DataTable dtable2 = new DataTable();
            SqlDataAdapter dadapter2 = new SqlDataAdapter("select top 1 * FROM transactions where delrec is null order by transact_num DESC", consql);
            dadapter2.Fill(dtable2);

            foreach (DataRow row in dtable2.Rows)
            {
                selrecord = row[4].ToString().Remove(0, 4);
                long tnautogen2 = Convert.ToInt64(selrecord);
                tnautogen2 = tnautogen2 + 1;
                txttransacnum.Text = tsautogen.Trim() + '-'.ToString().Trim() + tnautogen2.ToString();

                divtransact.Style.Add("display","inherit");
            }
        }
        else
        {
            if (Textlog2.Visible == false)
            {
                Textlog2.Style.Add("disply", "inherit");
                Textlog2.Text = "";
                Log("no existing record");
            }

            tnautogen = 100000000000;
            tsautogen = "TRN";
            txttransacnum.Text = tsautogen.Trim() + '-'.ToString().Trim() + tnautogen + 1;
        }
    }

    protected void addtransact_Click(object sender, EventArgs e)
    {
        hiddenfieldrfid.Value = "executed";

        divtransact.Style.Add("display","none");
        vtrans_add.Value = "ADD";

        transactionlistbox.Style.Add("display","none");

        Listedit.Style.Add("display", "none");
        lbleditcustid.Style.Add("display", "none");
        lblname.Style.Add("display", "none");
        lbledit.Style.Add("display", "none");
        lblfirst.Style.Add("display", "none");
        lblsearch.Style.Add("display", "none");
        customertype.Style.Add("display", "none");
        txtsearch.Style.Add("display", "none");
        ListBoxview.Style.Add("display", "none");

        lblcarrefernces.Style.Add("display", "inherit");
        carrefdropdownlist.Style.Add("display", "inheret");

        lbltransactionlib.Style.Add("display","inherit");

        labelranslist.Style.Add("display", "none");
        labeltransactdate.Style.Add("display", "none");
        labeltransactnum.Style.Add("display", "none");
        labelinvoicenum.Style.Add("display", "none");
        labelservice.Style.Add("display", "none");
        labelservtype.Style.Add("display", "none");
        labelwarstatus.Style.Add("display", "none");
        labelmainschedule.Style.Add("display", "none");
        labelmainduedate.Style.Add("display", "none");
        labelsearchtransactnum1.Style.Add("display", "none");
        labelsearchtransactnum2.Style.Add("display", "none");

        if (txtrfid.Text != "" && txtplatenumber.Text != "")
        {
            Textlog2.Style.Add("display", "none");

            txtwarexpire2.Style.Add("display", "none");

            lblinvoicenum.Style.Add("display", "inherit");
            txtinvoicenum.Style.Add("display", "inherit");
            lbltransacnum.Style.Add("display", "inherit");
            txttransacnum.Style.Add("display", "inherit");
            lbltrandate.Style.Add("display", "inherit");
            txttrandate.Style.Add("display", "inherit");
            lblservice.Style.Add("display", "inherit");
            cmbservice.Style.Add("display", "inherit");
            lbltypeofserv.Style.Add("display", "inherit");
            cmbtypeofserve.Style.Add("display", "inherit");
            lblwarstat.Style.Add("display", "inherit");
            cmbwarstat.Style.Add("display", "inherit");
            lblwarexpire.Style.Add("display", "inherit");
            txtwarexpire.Style.Add("display", "inherit");
            lblmainsched.Style.Add("display", "inherit");
            mainscheddropdown.Style.Add("display", "inherit");
            lblmaindue.Style.Add("display", "inherit");
            txtmaindue.Style.Add("display", "inherit");
            lblsmsmess.Style.Add("display", "inherit");
            txtsmsmess.Style.Add("display", "inherit");
            lblservde.Style.Add("display", "inherit");
            txtservde.Style.Add("display", "inherit");
            transadd.Style.Add("display", "inherit");
            transedit.Style.Add("display", "inherit");
            transdelete.Style.Add("display", "inherit");

            txtinvoicenum.Enabled = true;
            txttransacnum.Enabled = false;
            txttrandate.Enabled = false;
            cmbservice.Enabled = true;
            cmbtypeofserve.Enabled = true;
            cmbwarstat.Enabled = true;
            txtwarexpire.Enabled = true;
            mainscheddropdown.Disabled = false;
            txtmaindue.Enabled = true;
            txtsmsmess.Enabled = true;
            txtservde.Enabled = true;

            txttransacnum.Text = "";
            txttrandate.Text = "";
            cmbservice.Text = "";
            cmbtypeofserve.Text = "";
            cmbwarstat.Text = "";
            txtwarexpire.Text = "";
            mainscheddropdown.Value = "";
            txtmaindue.Text = "";
            txtsmsmess.Text = "";
            txtservde.Text = "";

            transactionedit.Value = "";

            txtinvoicenum.Text = "INV-";
            //txttrandate.Text = now;

            carrefdropdownlist.SelectedIndex = carrefdropdownlist.SelectedIndex;
            carrefdropdownlist.Text = txtplatenumber.Text;

            confirmdiv.Style.Add("display","none");
            divcar.Style.Add("display","none");

            txtinvoicenum.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
        }
        else
        {
            if (Textlog2.Visible == true)
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Textlog2.Text = "";
                Log("You are not allow to add new invoice number if the RFID code and plate number is empty");
            }
            else
            {
                Textlog2.Visible = true;
                Textlog2.Style.Add("display", "inherit");
                Textlog2.Text = "";
                Log("You are not allow to add new invoice number if the RFID code and plate number is empty");
            }
        }

    }

    /// this is the end protion of the TRANSACTION info // txtwarexpire.Text /// 
    [WebMethod]
    public static string ProcessIT(string vplatenum, string vmake, string variaplatenum, string variacarref)
    {
        rfidselected2 = variaplatenum;
        platenumselected2 = variacarref;

        SqlConnection consql = new SqlConnection(@"Server=SAMSUNGLEO\SQLEXPRESS;Database=AUTOPARTS;Integrated Security='true' ");

        DataTable cardatatable = new DataTable();
        SqlDataAdapter cardataadapter = new SqlDataAdapter("select platenum,make,model,regnum,regdate,color,chasisnum,enginenum from car where ltrim(rfid_code)='" + rfidselected2.Trim() + "' and ltrim(platenum) = '" + platenumselected2.Trim() + "' and delrec is null order by platenum asc", consql);
        cardataadapter.Fill(cardatatable);

        if (cardatatable.Rows.Count > 0)
        {
            vplatenum = cardatatable.Rows[0]["platenum"].ToString();
            vmake = cardatatable.Rows[0]["make"].ToString();
            vmodel = cardatatable.Rows[0]["model"].ToString();
            vregisnum = cardatatable.Rows[0]["regnum"].ToString();
            vrgdate = cardatatable.Rows[0]["regdate"].ToString();
            vcolor = cardatatable.Rows[0]["color"].ToString();
            vchasisnum = cardatatable.Rows[0]["chasisnum"].ToString();
            venginenum = cardatatable.Rows[0]["enginenum"].ToString();
        }
        var smake = "".PadRight(25 - vmake.Length);
        var smodel = "".PadRight(25 - vmodel.Length);
        var scolor = "".PadRight(50 - vcolor.Length);
        var schasis = "".PadRight(20 - vchasisnum.Length);
        var sengine = "".PadRight(20 - venginenum.Length);
       
        string result = vplatenum;       
        return result + " " + vmake + smake + vmodel + smodel + vregisnum + " " + vrgdate + " " + vcolor + scolor + vchasisnum + schasis + venginenum + " ";
    }
    protected void checkaccess_Click(object sender, EventArgs e)
    {       
            Response.Redirect("user_access.aspx");      
    }

    protected void checkbox_close_Click(object sender, EventArgs e)
    {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.open('http://www.google.com', '_self', null);", true);
    }
    protected void checksms_Click(object sender, EventArgs e)
    {     
            Response.Redirect("sms.aspx");    
    }
    
    protected void buttonsms_Click(object sender, EventArgs e)
    {
        hiddenfieldrfid.Value = "executed";
        string vservice = cmbservice.Text.Trim();
        DataTable servdatatable = new DataTable();
        SqlDataAdapter servdataadapter = new SqlDataAdapter("select * from sms where ltrim(service)='" + vservice + "'", consql);
        servdataadapter.Fill(servdatatable);

        if (servdatatable.Rows.Count > 0)
        {
            txtsmsmess.Text = servdatatable.Rows[0]["smsmess"].ToString();

            divtransact.Style.Add("display", "none");
            divtransact.Style.Add("display", "inherit");
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "servicetype2()", true);
    }

    protected void transactionlistbox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (deloption.Value == "")
      {
            edit2.Value = "";
      }

      if(edit2.Value=="DELETE")
      {
             //translistboxselindex.Value = translistboxselindex.Value;
             //int i = Convert.ToInt32(translistboxselindex.Value);
             //transactionlistbox.SelectedIndex = i-1;
                                      
             string vartransactnum = "";
             vartransactnum = transact_value.Value;            
             //vartransactnum = transactionlistbox.SelectedItem.Text.Substring(14, 17);
             if (vartransactnum != "")
             {
                 DateTime vtrandate = new DateTime();
                 if (txttrandate.Text != "")
                 {
                     vtrandate = Convert.ToDateTime(txttrandate.Text);
                 }

                 DataTable trndatatable = new DataTable();
                 SqlDataAdapter trndataadapter = new SqlDataAdapter("update transactions set delrec='" + "deleted" + "' where ltrim(transact_num) = '" + vartransactnum.Trim() + "' ", consql);
                 trndataadapter.Fill(trndatatable);
                 trndataadapter.Update(trndatatable);

                 Textlog2.Style.Add("display", "inherit");
                 Textlog2.Text = "";
                 Textlog2.Text = "One record for transaction was Deleted";

                 txtinvoicenum.Text = "";
                 txttransacnum.Text = "";
                 txttrandate.Text = DateTime.Now.ToShortDateString();
                 cmbservice.Text = "";
                 cmbtypeofserve.Text = "";
                 cmbwarstat.Text = "";
                 txtwarexpire.Text = "";
                 mainscheddropdown.Value = "";
                 txtmaindue.Text = "";
                 txtsmsmess.Text = "";
                 txtservde.Text = "";

                 autotran();

                 txtinvoicenum.Text = "INV-";
                 txtinvoicenum.Focus();
                 ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
             }
        }      
    }

    public void execute_trans_module()
    {
        labelranslist.Style.Add("display", "none");
        labeltransactdate.Style.Add("display", "none");
        labeltransactnum.Style.Add("display", "none");
        labelinvoicenum.Style.Add("display", "none");
        labelservice.Style.Add("display", "none");
        labelservtype.Style.Add("display", "none");
        labelwarstatus.Style.Add("display", "none");
        labelmainschedule.Style.Add("display", "none");
        labelmainduedate.Style.Add("display", "none");
        labelsearchtransactnum1.Style.Add("display", "none");
        labelsearchtransactnum2.Style.Add("display", "none");

        lbltransactionlib.Style.Add("display", "inherit");
        lblinvoicenum.Style.Add("display", "inherit");
        txtinvoicenum.Style.Add("display", "inherit");
        lbltransacnum.Style.Add("display", "inherit");
        txttransacnum.Style.Add("display", "inherit");
        lbltrandate.Style.Add("display", "inherit");
        txttrandate.Style.Add("display", "inherit");
        lblservice.Style.Add("display", "inherit");
        cmbservice.Style.Add("display", "inherit");
        lbltypeofserv.Style.Add("display", "inherit");
        cmbtypeofserve.Style.Add("display", "inherit");
        lblwarstat.Style.Add("display", "inherit");
        cmbwarstat.Style.Add("display", "inherit");
        lblwarexpire.Style.Add("display", "inherit");
        txtwarexpire.Style.Add("display", "inherit");
        lblmainsched.Style.Add("display", "inherit");
        mainscheddropdown.Style.Add("display", "inherit");
        lblmaindue.Style.Add("display", "inherit");
        txtmaindue.Style.Add("display", "inherit");
        lblsmsmess.Style.Add("display", "inherit");
        txtsmsmess.Style.Add("display", "inherit");
        lblservde.Style.Add("display", "inherit");
        txtservde.Style.Add("display", "inherit");
        transadd.Style.Add("display", "inherit");
        transedit.Style.Add("display", "inherit");
        transdelete.Style.Add("display", "inherit");

        txtinvoicenum.Text = "";
        txttransacnum.Text = "";
        txttrandate.Text = "";
        cmbservice.Text = "";
        cmbtypeofserve.Text = "";
        cmbwarstat.Text = "";
        txtwarexpire.Text = "";
        txtwarexpire2.Text = "";
        mainscheddropdown.Value = "";
        txtmaindue.Text = "";
        txtsmsmess.Text = "";
        txtservde.Text = "";

        transactionedit.Value = "";

        txtinvoicenum.Enabled = false;
        txttransacnum.Enabled = false;
        txttrandate.Enabled = false;
        cmbservice.Enabled = false;
        cmbtypeofserve.Enabled = false;
        cmbwarstat.Enabled = false;
        txtwarexpire.Enabled = false;
        txtwarexpire2.Enabled = false;
        mainscheddropdown.Disabled = false;
        txtmaindue.Enabled = false;
        txtsmsmess.Enabled = false;
        txtservde.Enabled = false;                    
    }    
}