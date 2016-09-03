<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sms.aspx.cs" Inherits="sms"%>

<!DOCTYPE html>

<html lang="en">
<head runat="server" style="z-index:inherit; width:100px">
    <title>SMS Message</title>

    <script src="lib/jquery.min.js"></script>
    <link href="css/loginstylesheet.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    
    <link href="css/sms.css" rel="stylesheet" />    

</head>
<body>
  <form id="form1" runat="server" onload="form1_Load"> 
    <div class="divsmsclass">
   
        <asp:Panel ID="Panel1" runat="server" CssClass="Panel1class" BorderColor="#400080" BorderStyle="Solid" BackColor="#FFFFD2">

            &nbsp;<asp:TextBox ID="txtuserid2" runat="server" Visible="false" CssClass="txtuserid2class"></asp:TextBox>

             <asp:SqlDataSource ID="sqldatasource1" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOPARTSConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT LTRIM(service) + '.               .' + LTRIM(smsmess) AS combined  FROM sms" UpdateCommand="update sms set service=@service,smsmess=@smsmess">
                 <UpdateParameters>
                     <asp:Parameter Name="userid" />
                     <asp:Parameter Name="username" />
                     <asp:Parameter Name="useraccess" />
                 </UpdateParameters>
             </asp:SqlDataSource>

             <asp:Label ID="Label2" runat="server" Text=" SMS Library" CssClass="Label2class" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
             <asp:Panel ID="Panel2" runat="server" CssClass="Panel2class">
                           <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btnaddclass" OnClick="Button1_Click"/>
                           <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="btneditclass" OnClick="btnedit_Click"/>
                           <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btndeleteclass" OnClick="btndelete_Click"/>
                           <asp:Button ID="btnview" runat="server" Text="View" CssClass="btnviewclass" OnClick="btnview_Click"/>
                           <asp:Button ID="btnquit" runat="server" Text="Quit" CssClass="btnquitclass " OnClick="btnquit_Click"/>
             </asp:Panel>

             <asp:Label ID="lblsms" runat="server" Text="SMS Message" CssClass="lblsmsclass"></asp:Label>
           
            <asp:Label ID="lblservice" runat="server" Text="Service" CssClass="lblserviceclass"></asp:Label>            
                 <asp:DropDownList ID="cmbservice" runat="server" CssClass="cmbserviceclass" Enabled="false" onkeydown="txtOnKeyPress3(this);" onchange ="rightsaccess(this)">
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
                 </asp:DropDownList>   
                     
             <asp:Panel ID="Panelrightaccess" runat="server" DefaultButton ="btnrightaccess">
                        <asp:Button ID ="btnrightaccess" runat="server" OnClick="btnrightaccess_Click" Style="display:none"/>
             </asp:Panel>

             <asp:TextBox ID="txtsms" runat="server" CssClass="txtsmsclass" Enabled="false" MaxLength="300" onkeyup="txtOnKeyPress(this);" TextMode="MultiLine" AutoPostBack="false" onkeydown = "return (event.keyCode=40);"></asp:TextBox>        

             <asp:Panel ID="Panel3" runat="server" DefaultButton="Button2">                 
                 <asp:Button ID="Button2" runat="server" OnClick="btnposition_Click" Style="display: none" />
             </asp:Panel>

             <asp:Label ID="lblError" runat="server" Text="Label" CssClass="lblErrorclass" Visible="False" Font-Bold="True" Font-Overline="False" Font-Size="Small"></asp:Label>            
             <asp:SqlDataSource ID="SqlDataSource_grid" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOPARTSConnectionString %>" SelectCommand="SELECT [service], [smsmess] FROM [sms]"></asp:SqlDataSource>
                                                                                                                                                                                             
                  <asp:ListBox ID="ListBoxview" runat="server" Visible="False" SelectionMode="Multiple" ViewStateMode="Enabled" Font-Size="Smaller" CssClass="ListBoxviewclass">
                  </asp:ListBox>
                                                                         
                  <asp:ListBox ID="Listedit" runat="server" CssClass="Listeditclass" Visible="False" AutoPostBack="false" SelectionMode="Multiple" Font-Names="Microsoft Sans Serif" onkeypress = "Submit()"></asp:ListBox>   
                                       
        </asp:Panel>   
         
             <asp:Label ID="lbledit" runat="server" BorderColor="#8080FF" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnUnload="lbledit_Unload" CssClass="lbleditclass"></asp:Label>
             <asp:Label ID="lbltopuserid" runat="server" Text="Services" CssClass="lbltopuseridclass"></asp:Label>

             <asp:TextBox ID="Textlog" runat="server" Visible="false" 
                          Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" CssClass="Textlogclass">
             </asp:TextBox>
             
             <asp:HiddenField ID="HiddenField1" runat="server"/>                    
             <asp:HiddenField ID="hiddenservice" runat="server" Value="none"/>
             <asp:HiddenField ID="edit" runat="server"/>             
      </div>
             <script src="js/sms_keypress.js"></script>
    </form>
</body>
</html>