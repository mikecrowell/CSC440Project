<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" MasterPageFile="~/Site.master" Inherits="DigitalAssetManagementSep28.Admin" %>


<asp:Content ID="UploadContent" ContentPlaceHolderID="mainContent" runat="server"  >    
    <div>
        <script type="text/javascript" src="Scripts/Confirm.js"></script>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" OnClick="Upload_OnClick" 
         Text="Upload File" Height="23px" Width="93px" /><br />
        <br />
        Description:
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <br />
        <br />
        Tag:
        <asp:DropDownList ID="ddListTags" runat="server">
        </asp:DropDownList>
        <asp:TextBox ID="tagTextBox" runat="server" BackColor="#FFFF99" BorderColor="#FFFF99" Height="18px" Width="123px"></asp:TextBox>
        <asp:Button ID="addTagButton" runat="server" OnClick="addTagButton_Click" Text="Add this tag" />
        <br />
        <asp:ListBox ID="TagListBox" runat="server" Width="113px"></asp:ListBox>
        <asp:Button ID="deleteTagButton" runat="server" OnClick="deleteTagButton_Click" Text="Delete this tag" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" BackColor="#FFCC00" Text="FOR TESTING ONLY"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:TextBox ID="checkExistTextBox" runat="server" BackColor="#6699FF"></asp:TextBox>
        <asp:Button ID="tagExistButton" runat="server" OnClick="tagExistButton_Click" Text="Does this tag exist?" />
        <asp:Label ID="checkExistLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="numOfTagButton" runat="server" OnClick="numOfTagButton_Click" Text="Num of Tag" />
        <asp:Label ID="numOfTag" runat="server" Text="Label"></asp:Label>
        <br />
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
    
</asp:Content>
   

