<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" MasterPageFile="~/Site.master" Inherits="DigitalAssetManagementSep28.AdminPages.Users" %>




<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">

    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

    <script type = "text/javascript">
        function ShowAdd(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel1.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel2.ClientID%>").style.display = "none";
                document.getElementById("<%=Panel3.ClientID%>").style.display = "none";
            }
        }
        function ShowUpdate(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel2.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel1.ClientID%>").style.display = "none";
                document.getElementById("<%=Panel3.ClientID%>").style.display = "none";
            }
        }
        function ShowDelete(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel3.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel1.ClientID%>").style.display = "none";
                document.getElementById("<%=Panel2.ClientID%>").style.display = "none";
            }
        }

    </script> 

    <div id="sidebar" align="left">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName = "group1"  Text = "Add User" onclick = "ShowAdd(this)" Checked="True" /> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName = "group1" Text = "Update User" onclick = "ShowUpdate(this)"/> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName = "group1" Text = "Activate/Inactivate User" onclick = "ShowDelete(this)"/>
    </div>
    <br />
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <div style="padding-left:10em;"> 
        <h2>User Management</h2>
        <h3>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </h3>
        <asp:Panel ID="Panel1" runat="server" style="display:block;">
            <p style="font-weight:bold;">Add User</p>
            <br />
            <table>
                <tr>
                  <td><asp:Label ID="Label1" runat="server" Text="Label">First Name: </asp:Label></td>
                  <td><asp:TextBox ID="txtFirstName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label2" runat="server" Text="Label">Last Name: </asp:Label></td>
                  <td><asp:TextBox ID="txtLastName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label3" runat="server" Text="Label">Login ID: </asp:Label><br /></td>
                  <td><asp:TextBox ID="txtLogin" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label4" runat="server" Text="Label">Password: </asp:Label></td>
                  <td><asp:TextBox ID="txtPassword" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label5" runat="server" Text="Label">Is Admin? </asp:Label></td>
                  <td><asp:CheckBox ID="chkIsAdmin" runat="server" /></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" style="display:none;">
            <p style="font-weight:bold;">Modify Users</p>
            <br />
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">    
                   <ContentTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <table>
                            <tr>
                              <td><asp:Label ID="Label6" runat="server" Text="Label">First Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtModFirstName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label7" runat="server" Text="Label">Last Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtModLastName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label8" runat="server" Text="Label">Login ID: </asp:Label></td>
                              <td><asp:TextBox ID="txtModLogin" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label9" runat="server" Text="Label">Password: </asp:Label></td>
                              <td><asp:TextBox ID="txtModPassword" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label10" runat="server" Text="Label">Is Admin? </asp:Label></td>
                              <td><asp:CheckBox ID="chkModIsAdmin" runat="server" /></td>
                            </tr>
                        </table>
                   </ContentTemplate> 
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" style="display:none;">
            <p style="font-weight:bold;">Activate/Inactivate Users</p>
            <br />
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                   <ContentTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName = "group2"  Text = "Active"/> 
                        &nbsp&nbsp
                        <asp:RadioButton ID="RadioButton5" runat="server"  GroupName = "group2" Text = "Inactive"/>        
                        <br /> 
                        <br />
                        <table>
                            <tr>
                              <td><asp:Label ID="Label11" runat="server" Text="Label">First Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtActiveFirstName" runat="server" BorderStyle="Inset" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label12" runat="server" Text="Label">Last Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtActiveLastName" runat="server" BorderStyle="Inset" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label13" runat="server" Text="Label">Login ID: </asp:Label></td>
                              <td><asp:TextBox ID="txtActiveLogin" runat="server" BorderStyle="Inset" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label14" runat="server" Text="Label">Password: </asp:Label></td>
                              <td><asp:TextBox ID="txtActivePassword" runat="server" BorderStyle="Inset" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label15" runat="server" Text="Label">Is Admin? </asp:Label></td>
                              <td><asp:CheckBox ID="chkActiveIsAdmin" runat="server" Enabled="False"/></td>
                            </tr>
                        </table>
                   </ContentTemplate> 
            </asp:UpdatePanel>
        </asp:Panel>

        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" UseSubmitBehavior="False" />
    </div> 
    

</asp:Content>
