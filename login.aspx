
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="icon" href="favicon.ico" />
    <link href="css/loginstylesheet.css" rel="stylesheet"/>  
</head>
<body style="width: 1308px; height: 501px; margin-top: 19px">
    <form style ="margin-left:auto; margin-right:auto" id="form1" runat="server">
    <div class="logincdivlass">
    
          <asp:Panel ID="Panel1" runat="server" Height="250px" Width="356px" BorderColor="#004080" BorderStyle="Inset" BorderWidth="3px" CssClass="Panel1class" BackColor="#FFFFD9">
               <asp:Login ID="Login1" runat="server" CssClass="Login1class" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#004080" DestinationPageUrl="login.aspx" OnAuthenticate="Login1_Authenticate1">
                  <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                  <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                  <TextBoxStyle Font-Size="0.8em"/>
                  <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
               </asp:Login>
          </asp:Panel>
    
    </div>
    </form>
</body>
</html>
