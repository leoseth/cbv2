<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_access.aspx.cs" Inherits="user_access"%>

<!DOCTYPE html>

<html lang="en">
<head id="Head1" runat="server" style="z-index:inherit; width:100px">
    <title>User_access</title>

    <link href="css/loginstylesheet.css" rel="stylesheet" />
    <script src="jquery/jquery-1.10.2.js"></script>
    <link href="css/user_access.css" rel="stylesheet" />    

</head>
<body>
  <form id="form1" runat="server" onload="form1_Load"> 
    <div class="useraccessclass">
   
        <asp:Panel ID="Panel1" runat="server" CssClass="Panel1class" BorderColor="#400080" BorderStyle="Solid" BackColor="#FFFFD2">

             <asp:SqlDataSource id="sqldatasource1" runat="server" DataSourceMode="DataReader" 
                        ConnectionString="<%$ ConnectionStrings:AUTOPARTSConnectionString %>"
                        SelectCommand="SELECT LTRIM(userid) + '.               .' + LTRIM(username) AS combined  FROM accessrights"
                        UpdateCommand="update accessrights set userid=@userid,username=@username,position=@position,useraccess=@useraccess">
                 <UpdateParameters>
                     <asp:Parameter Name="userid" />
                     <asp:Parameter Name="username" />
                     <asp:Parameter Name="useraccess" />
                 </UpdateParameters>
             </asp:SqlDataSource>

            &nbsp;<asp:TextBox ID="txtuserid2" runat="server" Visible="False" CssClass="txtuserid2class"></asp:TextBox>

             <asp:Label ID="Label2" runat="server" Text=" User Library" CssClass="Label2class" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
             <asp:Panel ID="Panel2" runat="server" CssClass="Panel2class">
                           <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btnaddclass" OnClick="Button1_Click"/>
                           <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="btneditclass" OnClick="btnedit_Click"/>
                           <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btndeleteclass" OnClick="btndelete_Click"/>
                           <asp:Button ID="btnview" runat="server" Text="View" CssClass="btnviewclass" OnClick="btnview_Click"/>
                           <asp:Button ID="btnquit" runat="server" Text="Quit" CssClass="btnquitclass" OnClick="btnquit_Click"/>
             </asp:Panel>

             <asp:Label ID="Label3" runat="server" Text="User ID" CssClass="Label3class"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text="User Name" CssClass="Label4class"></asp:Label>
             <asp:Label ID="labelpassword" runat="server" Text="Password" CssClass="labelpasswordclass"></asp:Label>
             <asp:Label ID="Label7" runat="server" Text="Position" CssClass="Label7class"></asp:Label>

             <asp:TextBox ID="txtuserid"   runat ="server" CssClass="txtuseridclass" Enabled="False" MaxLength="15" onkeydown="txtOnKeyPress5(this)"></asp:TextBox>            
             <asp:TextBox ID="txtusername" runat="server" CssClass="txtusernameclass" Enabled="false" MaxLength="25" onkeydown="txtOnKeyPress4(this);"></asp:TextBox>
             <asp:Label ID="labelfullname" runat="server" Text="Fullname" CssClass="labelfullnameclass"></asp:Label>
             <asp:TextBox ID="txtfullname" runat="server" MaxLength="49" onkeydown="txtkeyfull(this);" CssClass="txtfullnameclass" Enabled="False"></asp:TextBox>
             <asp:TextBox ID="txtpassword" runat="server" Enabled="false" onkeydown="txtonkeypresspass(this)" CssClass="txtpasswordclass" MaxLength="20"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Access right" CssClass="Label5class"></asp:Label>            
                 <asp:DropDownList ID="cmbaccess" runat="server" CssClass="cmbaccessclass" Enabled="false" MaxLength="100" onkeydown="txtOnKeyPress3(this);" onchange ="rightsaccess(this)">
                     <asp:ListItem Value =""></asp:ListItem>
                     <asp:ListItem value ="Unlimited">Unlimited</asp:ListItem>
                     <asp:ListItem value ="Limited">Limited</asp:ListItem>
                 </asp:DropDownList>
                     
             <asp:Panel ID="Panel3" runat="server" DefaultButton="Button2">
                 <asp:TextBox ID="txtposition" runat="server" CssClass="txtpositionclass" Enabled="false" MaxLength="50" onkeyup="txtOnKeyPress(this);"></asp:TextBox>
                 <asp:Button ID="Button2" runat="server" OnClick="btnposition_Click" Style="display: none" />
             </asp:Panel>
             <asp:Label ID="lblError" runat="server" Text="Label" CssClass="lblErrorclass" Visible="False"></asp:Label>
             
             <asp:SqlDataSource ID="SqlDataSource_grid" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOPARTSConnectionString %>" SelectCommand="SELECT [userid], [username], [useraccess] FROM [accessrights]"></asp:SqlDataSource>
                                                                                                                                                                                             
                       <asp:ListBox ID="ListBoxview3" runat="server" Visible="False" SelectionMode="Multiple" Font-Size="Smaller" CssClass="ListBoxview3class" Font-Names="Tahoma"></asp:ListBox>
                                                                         
                        <asp:ListBox ID="Listedit" runat="server" CssClass="Listeditclass" Visible="False" AutoPostBack="false"
                                     SelectionMode="Multiple" Font-Names="Microsoft Sans Serif" 
                                     onkeypress = "Submit()">
                        </asp:ListBox>   
                                       
             </asp:Panel>               
         
             <asp:Label ID="lbledit" runat="server" BorderColor="#8080FF" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnUnload="lbledit_Unload" CssClass="lbleditclass"></asp:Label>
             <asp:Label ID="lbltopuserid" runat="server" Text="User ID" CssClass="lbltopuseridclass"></asp:Label>
             <asp:Label ID="lbltopusername" runat="server" Text="User Name" CssClass="lbltopusernameclass"></asp:Label>

             <asp:TextBox ID="Textlog" runat="server" Visible="false" 
                          Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" CssClass="Textlogclass">
             </asp:TextBox>
             
             <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField id="varview" runat="server"/>
             <asp:HiddenField ID="edit" runat="server" />                               
      </div>

      <script src="js/useraccess_keypress.js"></script>

    </form>
</body>
</html>