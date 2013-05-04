<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseTestPage.aspx.cs" Inherits="DigitalAssetManagementSep28.DatabaseTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TEST</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Testing Database</h1>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>File Full Path
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>Short Desc:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
        <p>Long Desc:
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </p>
        <p>Category:
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Image ID="Image1" runat="server" Visible="False" />
        </p>
        <p>
            file name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            extension id:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            short description:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            long desc:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            tag id:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            tag 2 id:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                PostBackUrl="~/DatabaseTestPage.aspx" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>

    </div>
    </form>
</body>
</html>

