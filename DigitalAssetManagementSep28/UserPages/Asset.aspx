<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Asset.aspx.cs" Inherits="DigitalAssetManagementSep28.Asset" %>

<%@ Register Assembly="ImagePreviewExtender" Namespace="ImagePreviewExtender" TagPrefix="cc1" %>

<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">
      <div id="sidebar" align="left">
        <asp:CheckBox ID="chkImages" runat="server" Text=" Images"
            Font-Bold="True" Checked="True"/>
            <asp:CheckBoxList ID="chkListImages" runat="server">
                <asp:ListItem Selected="True">.jpg</asp:ListItem>
                <asp:ListItem Selected="True">.gif</asp:ListItem>
                <asp:ListItem Selected="True">.tiff</asp:ListItem>
                <asp:ListItem Selected="True">.bmp</asp:ListItem>
                <asp:ListItem Selected="True">.png</asp:ListItem>
                <asp:ListItem Selected="True">.psd</asp:ListItem>
                <asp:ListItem Selected="True">.ai</asp:ListItem>
                <asp:ListItem Selected="True">.eps</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkVideos" runat="server" Text=" Videos" Font-Bold="True" 
            Checked="True" />
            <asp:CheckBoxList ID="chkListVideos" runat="server" >
                <asp:ListItem Selected="True">.mov</asp:ListItem>
                <asp:ListItem Selected="True">.wmv</asp:ListItem>
                <asp:ListItem Selected="True">.mp4</asp:ListItem>
                <asp:ListItem Selected="True">.swf</asp:ListItem>
                <asp:ListItem Selected="True">.fla</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkAudio" runat="server" Text=" Audio" Font-Bold="True" 
            Checked="True"/>
            <asp:CheckBoxList ID="chkListAudio" runat="server">
                <asp:ListItem Selected="True">.wav</asp:ListItem>
                <asp:ListItem Selected="True">.mp3</asp:ListItem>
            </asp:CheckBoxList>
        <br />
        <asp:CheckBox ID="chkDocs" runat="server" Text=" Documents" Font-Bold="True" 
            Checked="True"/>
            <asp:CheckBoxList ID="chkListDocs" runat="server">
                <asp:ListItem Selected="True">.pdf</asp:ListItem>
        </asp:CheckBoxList>
    </div>
  
    <br />
    <center>
    <asp:Button ID="downloadButton" runat="server" onclick="downloadButton_Click" 
        Text="Download Selected"  OnClientClick = "return true" Font-Size="Medium" 
            ForeColor="#1E2667" Height="30px" />&nbsp&nbsp
    <asp:TextBox ID="txtSearch" runat="server" BorderColor="#1E2667" 
        BorderWidth="2px" Font-Size="Large" Height="30px" Width="55%">Search Terms Here...</asp:TextBox>
    &nbsp&nbsp<asp:Button ID="btnSearch" runat="server" Text="Search" 
        Font-Size="Medium" ForeColor="#1E2667" Height="30px" 
             />
        <asp:RadioButton ID="rbAND" runat="server" GroupName="SearchType" Text="AND" />
        <asp:RadioButton ID="rbOR" runat="server" Checked="True" GroupName="SearchType" 
            Text="OR" />
    </center>
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Panel ID="pnlImages" runat="server" CssClass="Panel" >
    </asp:Panel>
    <asp:ScriptManager ID="manScript" runat="server" ScriptMode="Release" />
                <cc1:ImagePreviewControl ID="ImagePreviewControl1" ThumbnailCssClass="ThumbnailCss"
                TargetControlID="pnlImages" runat="server" />
    <!-- Temporary Text box for testing display-->
   <!-- <asp:TextBox ID="txtResultsTest" runat="server" Font-Size="small" Height="600px" Width="70%" TextMode="MultiLine"></asp:TextBox> -->
    </asp:Content>

