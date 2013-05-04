<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" MasterPageFile="~/Site.master" Inherits="DigitalAssetManagementSep28.AdminPages.Tags" %>




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
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName = "group1"  Text = "Tag" onclick = "ShowAdd(this)" Checked="True" /> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName = "group1" Text = "Update Tag" onclick = "ShowUpdate(this)"/> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName = "group1" Text = "Activate/Inactivate Tag" onclick = "ShowDelete(this)"/>
    </div>
    <br />
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <div style="padding-left:10em;"> 
        <h2>Tag Management</h2>
        <h3>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </h3>
        <asp:Panel ID="Panel1" runat="server" style="display:block;">
            <p style="font-weight:bold;">Add Tag</p>
            <br />
            <table>
                <tr>
                  <td><asp:Label ID="Label1" runat="server" Text="Label">Tag Name: </asp:Label></td>
                  <td><asp:TextBox ID="txtTagName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>                
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" style="display:none;">
            <p style="font-weight:bold;">Modify Tags</p>
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
                              <td><asp:Label ID="Label6" runat="server" Text="Label">Tag Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtModTagName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                        </table>
                   </ContentTemplate> 
            </asp:UpdatePanel>
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" style="display:none;">
            <p style="font-weight:bold;">Activate/Inactivate Tags</p>
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
                              <td><asp:Label ID="Label11" runat="server" Text="Label">Tag Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtActiveTagName" runat="server" BorderStyle="Inset" ReadOnly="True"></asp:TextBox></td>
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
