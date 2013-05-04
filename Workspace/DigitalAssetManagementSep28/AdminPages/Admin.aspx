<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" MasterPageFile="~/Site.master" Inherits="DigitalAssetManagementSep28.Admin" %>


<asp:Content ID="UploadContent" ContentPlaceHolderID="mainContent" runat="server"  >    
    <div>

        <br />
        <center>
        <table> 
            <tr>
                <td style="border:1px solid black;">Select File To Upload:</td>
                <td style="border:1px solid black;" class="style2"><script type="text/javascript" src="Scripts/Confirm.js"></script>
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                <td style="border:1px solid black;"><asp:Label ID="Label3" runat="server"></asp:Label></td>       
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="border:1px solid black;">File  Description:</td>
                <td colspan="2" style="border:1px solid black;"><asp:TextBox ID="txtDescription" runat="server" BorderColor="#FFFF99" Height="18px" Width="293px"></asp:TextBox></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="border:1px solid black;">Select Pre-Existing Tag&nbsp;</td>
                <td style="border:1px solid black;" class="style2" colspan="2">&nbsp;<asp:DropDownList 
                        ID="ddListTags" runat="server" Height="20px" Width="100px" AutoPostBack="True" 
                        onselectedindexchanged="ddListTags_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="border:1px solid black;">Enter New Tag:</td>
                <td style="border:1px solid black;"><asp:TextBox ID="tagTextBox" runat="server" BorderColor="#FFFF99" Height="16px" Width="108px"></asp:TextBox></td>    
                <td style="border:1px solid black;"><asp:Button ID="addTagButton" runat="server" OnClick="addTagButton_Click" Text="Add this tag" Height="20px" Width="95px" /></td>
            </tr>
           </table>
        </center>
        <center> 
        <p>
            <br /> 
                Finalize Tags
            <br />
                <asp:ListBox ID="TagListBox" runat="server" Width="100px" Height="80px" 
                SelectionMode="Multiple"></asp:ListBox>
                <asp:Button ID="deleteTagButton" runat="server" OnClick="deleteTagButton_Click" Text="Delete this tag" Height="20px" Width="100px" />
        </p>
        <br />
            <asp:Button ID="Upload" runat="server" Text="Upload File"  Height="24px" 
                Width="205px" onclick="Upload_Click1" />
            <asp:Label ID="UploadLabel" runat="server"></asp:Label>  
              
        </center>
        <!-- 
        <asp:Label ID="Label2" runat="server" BackColor="#FFCC00" Text="FOR TESTING ONLY"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="checkExistTextBox" runat="server" BackColor="#6699FF"></asp:TextBox>
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
    -->
</asp:Content>
   

<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 209px;
        }
    </style>
</asp:Content>

   

