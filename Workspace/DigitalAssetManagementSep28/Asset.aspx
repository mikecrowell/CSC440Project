<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Asset.aspx.cs" Inherits="DigitalAssetManagementSep28.Asset" %>

<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
    <div id="sidebar" align="left">
        <asp:CheckBox ID="chkImages" runat="server" Text=" Images" 
            Font-Bold="True"/>
            <asp:CheckBoxList ID="chkListImages" runat="server">
                <asp:ListItem>.jpg</asp:ListItem>
                <asp:ListItem>.gif</asp:ListItem>
                <asp:ListItem>.tiff</asp:ListItem>
                <asp:ListItem>.bmp</asp:ListItem>
                <asp:ListItem>.png</asp:ListItem>
                <asp:ListItem>.psd</asp:ListItem>
                <asp:ListItem>.ai</asp:ListItem>
                <asp:ListItem>.eps</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkVideos" runat="server" Text=" Videos" Font-Bold="True" />
            <asp:CheckBoxList ID="chkListVideos" runat="server" >
                <asp:ListItem>.mov</asp:ListItem>
                <asp:ListItem>.wmv</asp:ListItem>
                <asp:ListItem>.mp4</asp:ListItem>
                <asp:ListItem>.swf</asp:ListItem>
                <asp:ListItem>.fla</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkAudio" runat="server" Text=" Audio" Font-Bold="True"/>
            <asp:CheckBoxList ID="chkListAudio" AutoPostBack="true" runat="server">
                <asp:ListItem>.wav</asp:ListItem>
                <asp:ListItem>.mp3</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkDocs" runat="server" Text=" Documents" Font-Bold="True"/>
            <asp:CheckBoxList ID="chkListDocs" runat="server">
                <asp:ListItem>.pdf</asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <br />
    <center>
    <asp:TextBox ID="txtSearch" runat="server" BorderColor="#1E2667" 
        BorderWidth="2px" Font-Size="Large" Height="30px" Width="60%">Search Terms Here...</asp:TextBox>
    &nbsp&nbsp<asp:Button ID="btnSearch" runat="server" Text="Search" 
        Font-Size="Medium" ForeColor="#1E2667" Height="30px" 
            onclick="btnSearch_Click" /></center>
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Panel ID="pnlImages" runat="server"></asp:Panel>

    <!-- Temporary Text box for testing display-->
    <asp:TextBox ID="TextBox2" runat="server" Font-Size="small" Height="600px" Width="70%" TextMode="MultiLine"></asp:TextBox>
</asp:Content>

