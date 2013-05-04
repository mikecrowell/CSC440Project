<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DucTestPage.aspx.cs" Inherits="DigitalAssetManagementSep28.DucTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test database</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Upload_OnClick" 
         Text="Upload File" />&nbsp;<br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
     </div>

     <div>    
        <p>
            <asp:Label ID="FullNameLabel" runat="server" Text="FullName"></asp:Label>  &nbsp;
            <asp:TextBox ID="FullNameTextBox" runat="server"></asp:TextBox> </p>
        <p>
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>  &nbsp; &nbsp;
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox> </p>
        <p>
            <asp:Label ID="ExtLabel" runat="server" Text="Ext"></asp:Label>&nbsp; &nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="ExtTextBox" runat="server"></asp:TextBox> </p>
    </div>

    </form>
</body>
</html>
