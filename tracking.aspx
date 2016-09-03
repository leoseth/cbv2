<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tracking.aspx.cs" Inherits="tracking"%>

<!DOCTYPE html5>
 
<html5>
<head runat="server" style="z-index:inherit; width:100px">
   <title>CBV Autoparts</title>

   <link rel="icon" href="favicon.ico" /> 

   <script src="js/Global.js"></script>
   <script src="jquery/jquery-1.10.2.js"></script>
   <script src="lib/angular.min.js"></script>  
   
   <link href="css/customer_tracking.css" rel="stylesheet" />
    
   <link href="css/stylesheet_tracking.css" rel="stylesheet" />                                
        
</head>
 
<body>
  <form id="form1" runat="server" onload="form1_Load" style="z-index:inherit;position:fixed">    
     
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" ></asp:ScriptManager>

  <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>

    <div class="div_top_class">     
         <%-----------------------this is the beginning portion of the Customer transaction info--------------------------------------%>
     <asp:panel id="panel1" runat="server" cssclass="panel1class" bordercolor="#400080" borderstyle="solid" Font-Size="xx-Small" BackColor="LightYellow">
            
            <asp:Label ID="lblrfid" runat="server" CssClass="lblrfidclass" Font-Size="15px" Text="RFID_Code "></asp:Label>                        
            <asp:label id="lblcustrequired" runat="server" CssClass="lblcustrequiredclass" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300" Text="All customer fields are required!!!"></asp:label>                                                                                                                                                               
            
            <asp:TextBox ID="txtrfid" runat="server" CssClass="txtrfidclass" Font-Size="12px" MaxLength="10" onkeyup="txtOnKeyPress(this)" TabIndex="1" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);" BackColor="White"></asp:TextBox>      
            <asp:TextBox ID="txtrfid2" runat="server" CssClass="txtrfid2class" MaxLength="10" oninput="rfid2func(this)" onkeydown="return(event.keycode!=13);" BackColor="LightYellow" ForeColor="LightYellow" BorderColor="LightYellow" BorderStyle="None" Font-Size="XX-Small" Text="" onkeypress="Grfid2Code(event)"></asp:TextBox>   

            <asp:Panel ID ="panelrfid" runat="server" DefaultButton ="buttonrfid">
                 <asp:Button ID ="buttonrfid" runat="server" style="display:none" OnClick="buttonrfidcode_Click" />
            </asp:Panel>                                                                                                                                                   

            <asp:Panel ID="panelvalidate" runat="server" DefaultButton="btnvalidate">
                <asp:Button ID="btnvalidate" runat="server" OnClick="btnvalidate_Click" style="display:none"/>
            </asp:Panel>

                <asp:SqlDataSource ID="sqldatasource1" runat="server" ConnectionString="Data Source=SAMSUNGLEO\SQLEXPRESS;Initial Catalog=AUTOPARTS;Integrated Security=true" DataSourceMode="DataReader" ProviderName="System.Data.SqlClient" SelectCommand="SELECT LTRIM(rfid_code) +'.               .'+ LTRIM(custnum) AS combined FROM customer"> </asp:SqlDataSource>                                
                <asp:Label ID="lblcustid" runat="server" CssClass="lblcustidclass" Font-Size="15px" Text="Customer ID"></asp:Label>                
                <asp:TextBox ID="txtcustid" runat="server" CssClass="txtcustidclass" Enabled="False" Font-Size="12px" MaxLength="15" TabIndex="2" AutoPostBack="false" onkeydown = "return (event.KeyCode!=13);"></asp:TextBox>
                
                <asp:Label ID="lblcustomtype" runat="server" CssClass="lblcustomtypeclass" Font-Size="15px" Text="Customer Type "></asp:Label>
                
                <select id="customtype" runat="server" class="customtypeclass" disabled="disabled" name="customtype" onchange="fcustomtype()" onkeydown = "txtOnKeyPress1(this);" tabindex="3" onkeyup = "return (event.KeyCode!=13);">
                    <option value=""></option>
                    <option value="Individual">Individual</option>
                    <option value="Company">Company</option>
                </select>

                <asp:HiddenField ID="HiddenField2" runat="server" />                
                <asp:Label ID="lblcompname" runat="server" CssClass="lblcompnameclass" Font-Size="15px" Text="Company name"></asp:Label>                
                <asp:TextBox ID="txtcompname" runat="server" CssClass="txtcompnameclass" enabled="false" Font-Size="12px" MaxLength="35" onkeyup="txtOnKeyPress2(this);" oninput="covertcompname()"  TabIndex="4" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                       
                
                <asp:Label ID="lbllastname" runat="server" CssClass="lbllastnameclass" Font-Size="15px" Text="Lastname"></asp:Label>                
                <asp:TextBox ID="txtlastname" runat="server" CssClass="txtlastnameclass" Enabled="false" Font-Size="12px" MaxLength="18" onkeyup="txtOnKeyPress3(this);" onkeypress="getkeypressed(event)" oninput="convertlast()" TabIndex="5" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                
                <asp:Label ID="lblfirstname" runat="server" CssClass="lblfirstnameclass" Font-Size="15px" Text="Firstname"></asp:Label>                                         
                <asp:TextBox ID="txtfirstname" runat="server" CssClass="txtfirstnameclass" Enabled="false" Font-Size="12px" MaxLength="18" onkeyup="txtOnKeyPress4(this);" oninput="convertfirst()"  TabIndex="6" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                
                              
                <asp:Label ID="lblmiddlename" runat="server" CssClass="lblmiddlenameclass" Font-Size="15px" Text="Middle Name"></asp:Label>
                <asp:TextBox ID="txtmiddlename" runat="server" CssClass="txtmiddlenameclass" enabled="false" Font-Size="12px" MaxLength="18" onkeyup="txtOnKeyPress5(this);" oninput="convertmiddle()"  TabIndex="7" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
              
                <asp:Label ID="lbladdress" runat="server" CssClass="lbladdressclass" Font-Size="15px" Text="Address"></asp:Label>
                <asp:TextBox ID="txtaddress" runat="server" CssClass="txtaddressclass" Enabled="false" MaxLength="149" oninput="convertaddress()" onkeyup="txtOnKeyPress6(this);" TextMode="MultiLine" TabIndex="8" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                

                <asp:Label ID="lbltelno" runat="server" CssClass="lbltelnoclass" Font-Size="15px" Text="Phone number"></asp:Label>
                <asp:TextBox ID="txttelno" runat="server" CssClass="txttelnoclass" Enabled="false" Font-Size="12px" MaxLength="14" onkeyup="txtOnKeyPress7(this);" onkeypress="GetKeyCode(event)" TabIndex="9" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                               
           
                <asp:Label ID="lbltel" runat="server" CssClass="lbltelclass" Font-Size="Small" Text="Please type the phone number including the areacode" Font-Bold="True" ForeColor="#0080C0"></asp:Label>
                <asp:Label ID="lblmobilenum" runat="server" CssClass="lblmobilenumclass" Font-Size="15px" Text="Mobile number"></asp:Label>
                <asp:TextBox ID="txtmobilenum" runat="server" CssClass="txtmobilenumclass" enabled="false" Font-Size="12px" MaxLength="11" onkeyup="txtOnKeyPress8(this);" onkeypress="GetKeyCode(event)" TabIndex="10" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
               
                <asp:Label ID="lblemailadd" runat="server" CssClass="lblemailaddclass" Font-Size="15px" Text="Email address"></asp:Label>
                <asp:TextBox ID="txtemailadd" runat="server" CssClass="txtemailaddclass" enabled="false" Font-Size="12px" MaxLength="30" onkeyup="txtOnKeyPress9(this);" TabIndex="11" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
               
                <asp:Label ID="lblbirthday" runat="server" CssClass="lblbirthdayclass" Font-Size="15px" Text="Birthday"></asp:Label>
                <asp:TextBox ID="txtbirthday" runat="server" CssClass="txtbirthday2class" enabled="false" Font-Size="12px" onkeyup="txtOnKeyPress10(this);" Type="Date" TabIndex="12" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                
                <asp:TextBox ID="txtbirthday2" runat="server" CssClass="txtbirthday2class" enabled="false" Font-Size="12px" onkeyup="txtOnKeyPress10(this);" Type="text" TabIndex="13" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                
                <asp:Label ID="lblbirthplace" runat="server" CssClass="lblbirthplaceclass" Font-Size="15px" Text="Birth Place"></asp:Label>
                <asp:TextBox ID="txtbirthplace" runat="server" CssClass="txtbirthplaceclass" enabled="false" onkeyup="txtOnKeyPress11(this);" oninput="convertbirthplace()"  TabIndex="14" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
              
                <asp:Label ID="lblnationality" runat="server" CssClass="lblnationalityclass" Font-Size="15px" Text="Nationality"></asp:Label>
                <asp:TextBox ID="txtnationality" runat="server" CssClass="txtnationalityclass" enabled="false" Font-Size="12px" MaxLength="15" onkeyup="txtOnKeyPress12(this);" oninput="convertnational()"  TabIndex="15" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
               
                <asp:Label ID="lblidtype" runat="server" CssClass="lblidtypeclass" Font-Size="15px" Text="ID Type"></asp:Label>
                <select id="sidtype" runat="server" class="sidtypeclass" disabled="disabled" name="sidtype" onchange="fsidtype()" onkeyup="txtOnKeyPress13(this);" tabindex="16" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);">               
                    <option value=""></option>
                    <option value="PASSPORT">PASSPORT</option>
                    <option value="SSS">SSS</option>
                    <option value="TIN">TIN</option>
                    <option value="VOTERS">VOTERS</option>
                    <option value="DRIVER S LICENSE">DRIVER&#39;S LICENSE</option>
                    <option value="SENIOR">SENIOR</option>
                    <option value="GSIS">GSIS</option>
                    <option value="OFW">OFW</option>
                    <option value="SCHOOL">SCHOOL</option>
                    <option value="OTHERS">OTHERS</option>
                </select>
                <asp:Label ID="lblidnumber" runat="server" CssClass="lblidnumberclass" Font-Size="15px" Text="ID number"></asp:Label>
               
                <asp:TextBox ID="txtidnumber" runat="server" CssClass="txtidnumberclass" Enabled="false" Font-Size="13px" MaxLength="29" onkeyup="txtOnKeyPress14(this);" oninput="convertidnumber()" TabIndex="17"></asp:TextBox>               
            
                &nbsp;<asp:TextBox ID="txtcustid2" runat="server" CssClass="txtcustid2class" TabIndex="18" Visible="False"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" BorderStyle="None" CssClass="Label2class" Font-Bold="True" Text="Customer Library" ForeColor="#0080C0" Font-Size="Medium"></asp:Label>

                <asp:Panel ID="Panel2" runat="server" CssClass="Panel2class">
                    <asp:Button ID="btnadd" runat="server" CssClass="btnaddclass" Font-Size="12px" Height="17px" OnClick="Button1_Click" Text="Add customer"/>
                    <asp:Button ID="btnedit" runat="server" CssClass="btneditclass" Font-Size="12px" Height="17px" OnClick="btnedit_Click" Text="Edit"/>
                    <asp:Button ID="btndelete" runat="server" CssClass="btndeleteclass" Font-Size="12px" Height="17px" OnClick="btndelete_Click" Text="Delete" />
                    <asp:Button ID="btnview" runat="server" CssClass="btnviewclass" Font-Size="12px" Height="17px" OnClick="btnview_Click" Text="View" />
                    <asp:Button ID="btnsearch" runat="server" Font-Size="12px" Height="17px" OnClick="btnsearch_Click" Text="Search RFID" CssClass="btnsearchclass"/>
                </asp:Panel>                
                                                                                                                                                                       
                <asp:Panel ID ="panel_txtsearch" runat="server" DefaultButton="btnpaneltxtsearch">                                                  
                      <asp:TextBox ID="txtsearch" runat="server" BorderColor="#8080FF" BorderWidth="1px" CssClass="txtsearchclass" Wrap="false" TabIndex="19" onkeyup="function (evt)" oninput="searchtext(this)" onkeydown="searchtext(this)"></asp:TextBox>                        
                      <asp:Button ID ="btnpaneltxtsearch" runat="server" OnClick="HiddenField2_click" style="display:none"/>    
                </asp:Panel>                                                                                                                                                                                  
                                                                              
                 <asp:ListBox ID="Listedit" runat="server" CssClass="Listeditclass" Font-Names="Microsoft Sans Serif" onkeypress="Submit()" SelectionMode="Multiple" Visible="true"></asp:ListBox>
                 
                 <asp:Label ID="lblcarrefernces" runat="server" Text="Car references : PLATE NUMBER #" CssClass="lblcarreferncesclass" Font-Bold="True" Font-Size="Small" ForeColor="#0080C0" BorderStyle="Inset" BorderWidth="1px"></asp:Label>

                <asp:ListBox ID="ListBoxview" runat="server" CssClass="ListBoxviewclass" Font-Size="Small" onkeypress="Submit()" SelectionMode="Multiple" Visible="true" Font-Names="Tahoma"></asp:ListBox>
                <asp:Label ID="lblError" runat="server" CssClass="lblErrorclass" Font-Size="15px" Text="Label" Visible="False" ForeColor="Red" Font-Bold="true"></asp:Label>
                <select id="customertype" runat="server" class="customertypeclass" name="customertype" onchange="jsFunction(this.value);" onmousedown="this.value='';" style="border: thin inset #0000FF">
                    <option value=""></option>
                    <option value="Individual">Individual</option>
                    <option value="Company">Company</option>
                </select> 

                <asp:Panel ID="panelsearch" runat="server" DefaultButton="sdt">
                    <asp:Button ID="sdt" runat="server" CssClass="sdtclass" OnClick="HiddenField2_click" style="display:none" type="text" />
                </asp:Panel>
                
                <asp:Label ID="lblline1" runat="server" BackColor="#8000FF" BorderStyle="Solid" BorderWidth="1px" CssClass="lblline1class"></asp:Label>

                <asp:ListBox ID="transactionlistbox" runat="server" BackColor="#FFFFCA" CssClass="transactionlistboxclass" Font-Bold="True" Font-Names="Times New Roman" ForeColor="#0000A0" onkeypress="extract()" SelectionMode="Multiple" Visible="true" OnTextChanged="transactionlistbox_SelectedIndexChanged"></asp:ListBox>
                
                <asp:Label ID="lblcomp" runat="server" CssClass="lblcompclass" Font-Size="15px" Text="Company Name"></asp:Label>
                <asp:Label ID="lbltelephone" runat="server" Font-Size="15px" Text="Tephone number" CssClass="lbltelnoclass2"></asp:Label>

                <asp:Panel ID="panecarref" runat="server" DefaultButton="btncaref">
                    <asp:Button ID="btncaref" runat="server" OnClick="btncaref_Click" style="display:none" />
                </asp:Panel> 

                <asp:Panel ID="panecarref2" runat="server" DefaultButton="btncaref2">
                    <asp:Button ID="btncaref2" runat="server" OnClick="btncaref2_Click" style="display:none" />
                </asp:Panel> 
       
                <asp:DropDownList id ="carrefdropdownlist" runat="server" CssClass="carrefdropdownlistclass" ondblclick="SQLconnect()" onchange="SQLconnect()"></asp:DropDownList>
                &nbsp;<asp:HiddenField ID ="carrefhidden" runat="server" Value="none" />&nbsp;
     
                <asp:SqlDataSource ID="SqlDataSource_grid" runat="server" ConnectionString="Data Source=SAMSUNGLEO\SQLEXPRESS;Initial Catalog=AUTOPARTS;Integrated Security=true" 
                                   ProviderName="System.Data.SqlClient" SelectCommand="select * from customer">
                </asp:SqlDataSource>
                                                                                                                                                                                             
             <asp:Label ID="lbledit" runat="server" BorderColor="#8080FF" BorderStyle="Solid" BorderWidth="1px" Visible="False" CssClass="lbleditclass" Font-Bold="False" onclick ="clickseacrh()" ForeColor="Black"></asp:Label>

             <asp:TextBox ID="Textlog2" runat="server" Visible="false" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" CssClass="Textlog2class" ForeColor="#0000A0"></asp:TextBox>             
             <asp:HiddenField ID="HiddenField1" runat="server" /> 
             <asp:HiddenField ID="HiddenField_edit" runat="server" />
             <asp:HiddenField ID="Hiddenfield_car" runat="server" />
             <asp:HiddenField ID="Hiddencar_edit" runat="server" />
             <asp:HiddenField ID="hiddenclick" runat="server" />
             <asp:HiddenField ID="hiddenfieldrfid" runat="server" />
             <asp:HiddenField ID="nosearch" runat="server" />
             <asp:HiddenField ID="confirmed" runat="server" />
             <asp:HiddenField ID ="no_option" runat="server" />
             <asp:HiddenField ID ="transaction_edit" runat="server" />
             <asp:HiddenField ID ="transact_value" runat="server" />
             <asp:HiddenField ID ="edit2" runat="server" />
             <asp:ListBox ID="resultlist" runat="server" CssClass="resultlistclass"></asp:ListBox>
             <img id ="customerimage" src="images/cbv_logo3.jpg" alt="customer_image" class="customerimageclass" />                                                                                

            <asp:HiddenField ID="transactionedit" runat="server" />
            <asp:HiddenField ID="hiddentrnlistcount" runat="server" Value="0" />
            <asp:HiddenField ID="transact_skipload" runat="server" />
                                                
            <div id="confirmdiv" class="confirmdivclass" runat="server">                                             
                  <button id="id_true"  type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small" onclick ="mousesave()" onkeydown="savingrec(this)">SAVE</button>
                  <button id="id_false" type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small;margin-left:20px" onclick="mousecancel()">CANCEL</button>                                    
            </div>>
                                                                                                                                                                           
          </asp:Panel>      

      </div>        

      <asp:Label ID="lbleditcustid" runat="server" Text="Customer ID" CssClass="lblcustid"></asp:Label>
      <asp:Label ID="lblsearch" runat="server" Text="Search by:" CssClass="lblsearchclass" Font-Bold="True" Font-Size="Small"></asp:Label>    
      <asp:Label ID="lblname" runat="server" Text="Lastname" CssClass="lblnameclass"></asp:Label>
      <asp:Label ID="lblfirst" runat="server" Text="Firstname" CssClass="lblfirstclass"></asp:Label>      
    
 <%--</ContentTemplate></asp:UpdatePanel>--%>

      <%-----------------------this is the end portion of the Customer transaction info--------------------------------------%>
         
  <asp:Panel ID ="Panelcartrans" runat="server" Height="10px" Width="1330px">   
      <%-----------------------this is the beginning portion of the Car transaction info-------------------------------------%>
      <asp:Label ID="lblcarlibrary" runat="server" Text="Car Library" CssClass="lblcarlibraryclass" Font-Bold="True" ForeColor="#0080C0"></asp:Label>
      <asp:Label ID="lblcarinfo" runat="server" Text="Car Information" Font-Bold="True" ForeColor="#0080C0" CssClass="lblcarinfoclass"></asp:Label>

      <asp:Label ID="lblplatenumber" runat="server" Text="Plate number" CssClass="lblplatenumberclass"></asp:Label>     
      <asp:TextBox ID="txtplatenumber" runat="server" CssClass="txtplatenumberclass" onkeyup="platenum(this)" TabIndex="22" MaxLength="9" onkeypress="pressplatenum()" oninput="converttouppercase()" Enabled="false" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>          
      <asp:TextBox ID="txtplatenumber2" runat="server" CssClass="txtplatenumberclass" onkeyup="platenum(this)" TabIndex="22" MaxLength="9" Visible="false" AutoPostBack="false"></asp:TextBox>

      <asp:Label ID="lblplatenumval" runat="server" CssClass="lblplatenumvalclass" Font-Bold="True" Font-Size="X-Small" ForeColor="#0000A0" Visible="false"></asp:Label>

      <asp:Label ID="lblmake" runat="server" Text="Make" CssClass="lblmakeclass"></asp:Label>
      <asp:TextBox ID="txtmake" runat="server" CssClass="txtmakeclass" Enabled="false" onkeyup="make(this)" TabIndex="23" MaxLength="25" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);" oninput="makeupper()"></asp:TextBox>
    
      <asp:HiddenField ID ="carfield" runat="server"/>
       
      <asp:Label ID="lblmodel" runat="server" Text="Model" CssClass="lblmodelclass"></asp:Label>
      <asp:TextBox ID="txtmodel" runat="server" CssClass="txtmodelclass" Enabled="false" onkeyup="model(this)" TabIndex="24" onkeypress="Getkeycodemodel()" MaxLength="25" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);" oninput="modelupper()"></asp:TextBox>
      
      <asp:Label ID="lblregistrationnum" runat="server" Text="Registration no." CssClass="lblregistrationnumclass"></asp:Label>      
      <asp:TextBox ID="txtregisnum" runat="server" CssClass="txtregisnumclass" Enabled="false" onkeyup="regisnum(this)" oninput="registoupper()" TabIndex ="25" MaxLength="9" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>      

      <asp:Label ID="lblregisnumval" runat="server" CssClass="lblregisnumvalclass" Font-Bold="True" Font-Size="X-Small" ForeColor="#0000A0"></asp:Label>
                                                                                             
      <asp:Label ID="llbregdate" runat="server" Text="Registration date" CssClass="llbregdateclass"></asp:Label>
      <asp:TextBox ID="txtrgdate" runat="server" CssClass="txtrgdateclass" onkeyup="rgdate(this)" TabIndex="26" type="date" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
      
      <asp:TextBox ID ="txtrgdate2" runat="server" CssClass="txtrgdate2class" Enabled="False" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);" onkeyup="rgdate(this)"></asp:TextBox>

      <asp:Label id="lblcolor" runat="server" Text="Color" CssClass="lblcolorclass"></asp:Label>
      <asp:TextBox ID="txtcolor" runat="server" CssClass="txtcolorclass" MaxLength="11" Enabled="false" onkeyup="color(this)" oninpucardelete_Clickt="colortoupper()" TabIndex="27" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
      
      <asp:Label ID="lblchasisnum" runat="server" Text="Chasis number" CssClass="lblchasisnumclass"></asp:Label>
      <asp:TextBox ID="txtchasisnum" runat="server" CssClass="txtchasisnumclass" Enabled="false" onkeyup="chasisnum(this)" oninput="convertchasisnum()"  TabIndex="28" MaxLength="15" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
      
      <asp:Label ID="lblenginenum" runat="server" Text="Engine number" CssClass="lblenginenumclass"></asp:Label>      
      <asp:TextBox ID="txtenginenum" runat="server" CssClass="txtenginenumclass" Enabled="false" TabIndex="29" MaxLength="15" AutoPostBack="false" oninput="engnumtoupper()" onkeyup="enginenum(this)" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>

      <asp:Label ID="lblline2" runat="server" BackColor="#8000FF" BorderStyle="Solid" BorderWidth="1px" CssClass="lblline2class"></asp:Label>
      <asp:Panel ID="paneloptionbtn" runat="server" CssClass="paneloptionbtnclass">
          <asp:Button ID="caradd" text="Add car" runat="server" CssClass="caraddclass" OnClick="caradd_Click" />
          <asp:Button ID ="caredit" Text="Edit" runat="server" CssClass="careditclass" OnClick="caredit_Click" />
          <asp:Button ID="cardelete" Text="Delete" runat="server" CssClass="cardeleteclass" OnClick="cardelete_Click" />
          <asp:Button ID="carview" Text="View" runat="server" CssClass="carviewclass" OnClick="carview_Click" />                                                                                                                 
      </asp:Panel>
 
      <asp:Label ID="labelplatenum" Text="Plate number" runat="server" CssClass="labelplatenumclass"></asp:Label>
      <asp:Label ID="labelmake" Text="Make" runat="server" CssClass="labelmakeclass"></asp:Label>
      <asp:Label ID="labelmodel" Text="Model" runat="server" CssClass="labelmodelclass"></asp:Label>

      <asp:Label ID="labelregnum" Text="Register number" runat="server" CssClass="labelregnumclass"></asp:Label>
      <asp:Label ID="labelcolor" Text="Color" runat="server" CssClass="labelcolorclass"></asp:Label>
      <asp:Label ID="labelchasisnum" Text="Chasis number" runat="server" CssClass="labelchasisnumclass"></asp:Label>

      <asp:Label ID="lblplatesearch" Text="Plate number" runat="server" CssClass="lblplatesearchclass" Font-Bold="True" Font-Size="Small"></asp:Label>

      <asp:Panel ID="paneltxtsearchplatenum" runat="server" DefaultButton="btntxtsearcheplatenum">
           <asp:TextBox ID="txtsearchplatenum" runat="server" CssClass="txtsearchplatenumclass" onkeydown="seditplatenum(this)"></asp:TextBox>
           <asp:Button ID="btntxtsearcheplatenum" runat="server" OnClick="txtsearchplatenum_TextChanged" style="display:none" />
      </asp:Panel>

      <asp:Label ID="lblsearchviewplatenum" runat="server" CssClass="lblsearchviewplatenumclass" Text="Plate number" Font-Size="Small"></asp:Label>

      <asp:Panel ID ="panelsearchviewplatem" runat="server" DefaultButton="btnsearchviewplatenum">
           <asp:TextBox ID ="txtserchviewplatenum" runat="server" CssClass="txtserchviewplatenumclass" onkeydown="sviewplatenum(this)"></asp:TextBox>
           <asp:Button ID ="btnsearchviewplatenum" runat="server" OnClick="txtserchviewplatenum_TextChanged" style="display:none" />
      </asp:Panel>
      <input type="hidden" id="caredited" runat="server" value="not"/>
       
         <div id="divcar" runat="server" class="divcarclass">                                           
                  <button id="btncarsave" type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small" onkeyup="savingdivcar(this)" onclick="mousecarsave()" onkeydown="return(event.keyCode!=13);">SAVE</button>
                  <button id="btncarcancel" type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small;margin-left:20px" onclick="mousecarcancel()"   onkeydown ="return(event.keyCode!=13);">CANCEL</button>         
                  <asp:HiddenField ID ="HiddenField3" runat="server" />
                  <input type="hidden" id="v_carsave" runat="server" />
         </div>           
          
  </asp:Panel>   
             
      <%-----------------------this is the end portion of the Car transaction info--------------------------------------%>      
      
      <%-----------------------this is the beginning portion of the Transaction info------------------------------------%>
  <asp:Panel ID="paneltransaction" runat="server" Height="10px" Width="1330px">

      <asp:Label ID ="lbltransactionlib" Text="Transaction Library" runat="server" CssClass="lbltransactionlibclass" Font-Bold="True" ForeColor="#0080C0"></asp:Label>

      <asp:Label ID="lblinvoicenum" Text="Invoice number" runat="server" CssClass="lblinvoicenumclass"></asp:Label>
      <asp:TextBox ID="txtinvoicenum" runat="server" CssClass="txtinvoicenumclass" Enabled="false" onkeyup="finvoice(this)" MaxLength="17" onkeypress="InvKeyCode(event)" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>      

      <asp:Label ID="lbltransacnum" Text="Transaction number" runat="server" CssClass="lbltransacnumclass"></asp:Label>

      <asp:TextBox ID ="txttransacnum" runat="server" CssClass="txttransacnumclass" Enabled="false" onkeyup="ftransactnum(this)"  AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>   

      <asp:Label ID="lbltrandate" runat="server" Text="Transaction date" CssClass="lbltrandateclass" Font-Size="Medium"></asp:Label>
      <asp:TextBox ID ="txttrandate" runat="server" Enabled="false" onkeyup="ftrandate(this)" CssClass="txttrandateclass" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>      

      <asp:Label ID ="lblservice" runat="server" Text="Service" CssClass="lblserviceclass"></asp:Label>      
      <asp:DropDownList ID="cmbservice" runat="server" CssClass="cmbserviceclass" Enabled="false" onkeyup="fcmbservice(this)" onchange="typeofserve(this)" Font-Bold="True" Font-Size="X-Small" ForeColor="#0000A0" Font-Names="Arial" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);">
          <asp:ListItem Value=""></asp:ListItem>                  
          <asp:ListItem value="AIRCON CLEANING">AIRCON CLEANING</asp:ListItem>                                                              
          <asp:ListItem value="CHANGE OIL - SYNTHETIC">CHANGE OIL - SYNTHETIC</asp:ListItem>
          <asp:ListItem value="CHANGE OIL - SEMI SYNTHETIC">CHANGE OIL - SEMI SYNTHETIC</asp:ListItem>
          <asp:ListItem value="CHANGE OIL - REGULAR GRADE">CHANGE OIL - REGULAR GRADE</asp:ListItem>
          <asp:ListItem value="GEAR OIL REPLACED REGULAR">GEAR OIL REPLACED REGULAR</asp:ListItem>
          <asp:ListItem value="GEAR OIL REPLACED SYNTHETIC BLEND">GEAR OIL REPLACED SYNTHETIC BLEND</asp:ListItem>
          <asp:ListItem value="CVT FLUID REPLACED">CVT FLUID REPLACED</asp:ListItem>
          <asp:ListItem value="COOLANT REPLACED">COOLANT REPLACED</asp:ListItem>
          <asp:ListItem value="BRAKE FLUID REPLACED">BRAKE FLUID REPLACED</asp:ListItem>
          <asp:ListItem value="SPARK PLUG REGULAR">SPARK PLUG REGULAR</asp:ListItem>
          <asp:ListItem value="SPARK PLUG PLATINUM">SPARK PLUG PLATINUM</asp:ListItem>
          <asp:ListItem value="SPARK PLUG IRIDIUM">SPARK PLUG IRIDIUM</asp:ListItem>
          <asp:ListItem value="BRAKE PAD CLEANING FRONT">BRAKE PAD CLEANING FRONT</asp:ListItem>
          <asp:ListItem value="BRAKE PAD CLEANING REAR">BRAKE PAD CLEANING REAR</asp:ListItem>
          <asp:ListItem value="BRAKE SHOE CLEANING">BRAKE SHOE CLEANING</asp:ListItem>
          <asp:ListItem value="TIRE ROTATION">TIRE ROTATION</asp:ListItem>
          <asp:ListItem value="PANASONIC BATTERY">PANASONIC BATTERY</asp:ListItem>         
          <asp:ListItem value="AMPLIFIER INSTALLATION">AMPLIFIER INSTALLATION</asp:ListItem>
          <asp:ListItem value="SPEAKERS INSTALLATION">SPEAKERS INSTALLATION</asp:ListItem>
          <asp:ListItem value="HEADUNIT SINGLE DIN">HEADUNIT SINGLE DIN</asp:ListItem>
          <asp:ListItem value="HEADUNIT 2 DIN WITH GPS">HEADUNIT 2 DIN WITH GPS</asp:ListItem>
          <asp:ListItem value="HEADUNIT 2 DIN WITHOUT GPS">HEADUNIT 2 DIN WITHOUT GPS</asp:ListItem>
          <asp:ListItem value="HEADREST MONITOR">HEADREST MONITOR</asp:ListItem>
          <asp:ListItem value="ROOF MOUNT MONITOR">ROOF MOUNT MONITOR</asp:ListItem>
          <asp:ListItem value="ALARM">ALARM</asp:ListItem>
          <asp:ListItem value="CENTRAL LOCK">CENTRAL LOCK</asp:ListItem>
          <asp:ListItem value="PANEL REPAINT">PANEL REPAINT</asp:ListItem>
          <asp:ListItem value="WASH OVER">WASH OVER</asp:ListItem>
          <asp:ListItem value="SCRAPE TO METAL">SCRAPE TO METAL</asp:ListItem>
          <asp:ListItem value="3 STEPS DETAILING">3 STEPS DETAILING</asp:ListItem>
          <asp:ListItem value="MACHINE WAX">MACHINE WAX</asp:ListItem>
          <asp:ListItem value="OTHERS">OTHERS</asp:ListItem>
      </asp:DropDownList>

      <asp:Label ID ="lbltypeofserv" runat="server" Text="Type of service" CssClass="lbltypeofservclass"></asp:Label>

      <asp:DropDownList ID ="cmbtypeofserve" runat="server" CssClass="cmbtypeofserveclass" Enabled="false" onkeyup="fcmbtypeofserve(this)" onchange="typeofservice(this)" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#0000A0"  AutoPostBack="false" onkeydown = "return (event.keyCode!=13);">
          <asp:ListItem value=""></asp:ListItem>
          <asp:ListItem Value="MAINTENANCE">MAINTENANCE</asp:ListItem>
          <asp:ListItem value="WARRANTY">WARRANTY</asp:ListItem>
          <asp:ListItem Value="MAINTENANCE / WARRANTY">MAINTENANCE / WARRANTY</asp:ListItem>
      </asp:DropDownList>

      <asp:Label ID ="lblwarstat" runat="server" Text="Warranty status" CssClass="lblwarstatclass"></asp:Label>

      <asp:DropDownList ID="cmbwarstat" runat="server" CssClass="cmbwarstatclass" Enabled="false" onkeyup="fcmbwarstat(this)" onchange="warrantystatus()" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#0000A0" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);">
          <asp:ListItem value=""></asp:ListItem> 
          <asp:ListItem Value="ACTIVE">ACTIVE</asp:ListItem>
          <asp:ListItem value="EXPIRED">EXPIRED</asp:ListItem>
          <asp:ListItem Value="NONE">NONE</asp:ListItem>
      </asp:DropDownList>

      <asp:Label ID ="lblwarexpire" runat="server" Text="Warranty expiration" CssClass="lblwarexpireclass"></asp:Label>
      <asp:TextBox ID="txtwarexpire" runat="server" CssClass="txtwarexpireclass" Enabled="false" onkeyup="fwarexpire(this)" type="Date" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
      <asp:TextBox ID="txtwarexpire2" runat="server" CssClass="txtwarexpireclass" onkeyup="fwarexpire2(this)" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>           

      <asp:Label ID="lblmainsched" runat="server" Text="Maintenance schedule" CssClass="lblmainschedclass"></asp:Label>
           <select id ="mainscheddropdown" runat="server" class="mainscheddropdownclass" onchange="mschedvalue()" disabled="true" onkeyup="ftxtmaineched(this)" onkeydown = "return (event.keyCode!=13);">
                  <option value=""></option>
                  <option value="1 week">1 week</option>
                  <option Value="2 weeks">2 weeks</option>
                  <option Value="3 weeks">3 weeks</option>
                  <option Value="4 weeks">4 weeks</option>
                  <option Value="1 month">1 month</option>
                  <option Value="2 months">2 months</option>           
                  <option Value="3 months">3 months</option> 
                  <option Value="4 months">4 months</option>
                  <option Value="5 months">5 months</option>
                  <option Value="6 months">6 months</option>
                  <option Value="7 months">7 months</option>
                  <option Value="8 months">8 months</option>
                  <option Value="9 months">9 months</option>
                  <option Value="10 months">10 months</option>
                  <option Value="11 months">11 months</option>
                  <option Value="1 year">1 year</option>
           </select> 

      <asp:Label ID ="lblmaindue" runat="server" Text="Maintenance due date" CssClass="lblmaindueclass"></asp:Label>
      <asp:TextBox ID ="txtmaindue" runat="server" CssClass="txtmaindueclass" Enabled="false" onkeyup="fmaindue(this)" Type="text" Font-Bold="True" Font-Names="Arial" ForeColor="#004080" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>      

      <asp:Label ID="lblsmsmess" runat="server" Text="SMS message" CssClass="lblsmsmessclass"></asp:Label>
      <asp:TextBox ID="txtsmsmess" runat="server" Enabled="false" onkeyup="fsmsmess(this)" TextMode="MultiLine" CssClass="txtsmsmessclass" AutoPostBack="false"></asp:TextBox>

      <asp:Label ID="lblservde" runat="server" Text="Service details" CssClass="lblservdeclass"></asp:Label>      
                    
      <asp:TextBox ID ="txtservde" runat="server" Enabled="false" onkeyup="fservde(this)" CssClass="txtservdeclass" TextMode="MultiLine" AutoPostBack="false" MaxLength="249" onkeydown = "return (event.keyCode !=13);"></asp:TextBox>
      <asp:Label ID="lblline3" runat="server" BackColor="#8000FF" BorderStyle="Solid" BorderWidth="1px" CssClass="lblline3class"></asp:Label>
    
      <asp:Panel ID="Panel4" runat="server" CssClass="Panel4class" Font-Size="Small">              
          <asp:Button ID="transadd" text="Add transaction" runat="server" OnClick="transadd_Click" CssClass="transaddclass" />
          <asp:Button ID ="transedit" Text="Edit " runat="server" OnClick="btncaredit_Click" CssClass="transeditclass"/>
          <asp:Button ID="transdelete" Text="Delete " runat="server" OnClick="transdelete_Click" CssClass="transdeleteclass" />
          <asp:Button ID="addtransact" Text="Add New Transaction" runat="server" CssClass="addtransactclass" OnClick="addtransact_Click" /> 
      </asp:Panel>

      <asp:Label   ID="labelranslist" runat="server" CssClass="labelranslistclass"></asp:Label>
      <asp:Label   ID="labeltransactdate" runat="server" Text="Transaction date" CssClass="labeltransactdateclass" Font-Size="Small"></asp:Label>
      <asp:Label   ID="labeltransactnum" runat="server" Text="Transaction number" CssClass="labeltransactnumclass" Font-Size="Small"></asp:Label>
      <asp:Label   ID="labelinvoicenum" runat="server" Text="Invoice number" CssClass="labelinvoicenumclass" Font-Size="Small"></asp:Label>    
      <asp:label   id="labelservice" runat="server" Text="Service" CssClass="labelserviceclass" Font-Size="Small"></asp:label>
      <asp:label   id="labelservtype" runat="server" Text="Service type" CssClass="labelservtypeclass" Font-Size="Small"></asp:label>
      <asp:Label   ID="labelwarstatus" runat="server" Text="Warranty status" CssClass="labelwarstatusclass" Font-Size="Small"></asp:Label>
      <asp:Label   ID="labelmainschedule" runat="server" Text="Maintenance schedule" Font-Size="Small" CssClass="labelmainscheduleclass"></asp:Label>
      <asp:label   id="labelmainduedate" runat="server" Text="Maintenance due date" CssClass="labelmainduedateclass" Font-Size="Small"></asp:label>
      <asp:Label   ID="labelsearchtransactnum1" runat="server" Text="Search by" Font-Bold="true" Font-Size="X-Small" CssClass="labelsearchtransactnum1class"></asp:Label>
      <asp:Label   ID="labelsearchtransactnum2" runat="server" Text="Transact no." Font-Bold="true" Font-Size="X-Small" CssClass="labelsearchtransactnum2class"></asp:Label>

      <asp:Button ID="checkaccess" runat="server" CssClass="checkaccessclass" Text="Add user access" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#004080" Height="20px" BackColor="Silver" AutoPostBack="true" OnClick="checkaccess_Click"/>

      <asp:Button ID="checksms" runat="server" Text="Add SMS" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="#004080" Height="20px" BackColor="Silver" AutoPostBack="true" OnClick="checksms_Click" CssClass="checksmsclass" />

      <asp:HiddenField ID ="dataextract" runat="server"/> 
      <asp:HiddenField ID ="variaextract" runat="server" />
      <asp:HiddenField ID ="skipload" runat="server" />
      <asp:HiddenField ID ="translistboxselindex" runat="server" />
      <input type="hidden" id ="deloption" runat="server" />
      <input type="hidden" id ="vtrans_add" runat="server" />
  
      <asp:Panel ID ="panelsms" runat="server" DefaultButton="buttonsms">
           <asp:Button ID ="buttonsms" runat="server" style="display:none" OnClick="buttonsms_Click" /> 
      </asp:Panel>

      <asp:Panel ID="paninvnum" runat="server" DefaultButton="binvnum">
            <asp:Button ID="binvnum" runat="server" style="display:none" OnClick="binvnum_Click" />
      </asp:Panel>  

         <div id="divtransact" runat="server" class="transaction_save">                                           
              <button id="btntrans_save"   type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small" onkeyup="savingtrans(this)" onclick="mousetransave()" onkeydown="return(event.keyCode!=13);">SAVE</button>
              <button id="btntrans_cancel" type="button" style="width:80px;background-color:lightgray;height:16px;border-color:blue; border-width:thin;font-size:x-small;margin-left:20px" onclick="mousetrancancel()" onkeydown ="return(event.keyCode!=13);">CANCEL</button>         
              <input type="hidden" id="transact_save" runat="server" />
         </div>       
 <%-----------------------this is the end portion of the Transaction info------------------------------------------%>
                                                                                                                                                                                                     
      </asp:Panel>      

 </ContentTemplate></asp:UpdatePanel>         

      <asp:Panel ID="Panel3" runat="server" DefaultButton="Button2">                                                                   
           <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="display: none" />                                                     
      </asp:Panel>

      <asp:Panel ID="panel5" runat="server" DefaultButton="btnenginenum">         
          <asp:Button ID="btnenginenum" runat="server" OnClick="btnenginenum_Click" style="display:none" />
      </asp:Panel>

      <asp:Panel ID="panelservede" runat="server" DefaultButton="btnservede">                 
                 <asp:Button ID="btnservede" runat="server" OnClick="btnservede_Click" style="display:none" />
      </asp:Panel>                 
                          
     <asp:Button ID="checkbox_close" runat="server" Text="Exit" CssClass="checkbox_closeclass" Font-Bold="true" Font-Names="Arial" Font-Size="Small" ForeColor="#004080" BackColor="Silver"  AutoPostBack="true" OnClick="checkbox_close_Click" />
       
        <script src="js/confirmation.js"></script>
        <script src="js/customer_keypressr.js"></script>
        <script src="js/car_keypress.js"></script>
        <script src="js/escape.js"></script>
        <script src="js/transaction_keypress.js"></script>
  </form>
</body>                   
</html5>
