<%@ Page Title="Home Page" Language="C#"     MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DigitalAssetManagementSep28._Default" %>
 <%--   <asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
        <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    </asp:Content>
    <asp:Content ContentPlaceHolderID="LoginContent" runat="server">
        User Name:&nbsp; <asp:TextBox ID="txtLogin" runat="server" ></asp:TextBox> &nbsp;
        Password:&nbsp; <asp:TextBox ID="txtPass" runat="server" ></asp:TextBox> &nbsp;
        <asp:Button ID="btnLogin"  Text="Login" runat="server" />&nbsp;
    </asp:Content>
    <asp:Content ContentPlaceHolderID="MainContent" runat="server">
       
    </asp:Content>--%>
    <asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server" ><p align="center">
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                You are not logged in.  Please sign in below.
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in. Welcome,&nbsp; <asp:LoginName ID="LoginName2" runat="server" />
            </LoggedInTemplate>
        </asp:LoginView>
        </p>
        <div style="text-align: center;">
            <div style="width:550px; margin-left: auto; margin-right:auto;">
                <asp:Login ID="Login1" runat="server" BackColor="#E05206" BorderColor="#1e2667" 
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="Medium" ForeColor="Black" Height="290px" Width="522px" OnLoggedIn="Login1_LoggedIn">
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LayoutTemplate>
                        <table cellpadding="4" cellspacing="0" style="border-collapse:collapse; margin:auto;">
                            <tr>
                                <td>
                                    <table cellpadding="0" style="height:290px;width:522px;">
                                        <tr>
                                            <td align="center" bgcolor="#1e2667" colspan="2" 
                                                style="color:White;background-color:#1e2667;font-size:0.9em;font-weight:bold;">
                                                Log In</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" style="color:White;">User Name:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                    ToolTip="User Name is required." ValidationGroup="Login1" style="color:White;">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" style="color:White;">Password:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                                    ToolTip="Password is required." ValidationGroup="Login1" style="color:White;">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." style="color:White;"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:White;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                                    ValidationGroup="Login1" CssClass="buttonTab"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                     <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    <TextBoxStyle Font-Size="0.8em" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1"/>
             </div>
        </div>      



</asp:Content>

    

