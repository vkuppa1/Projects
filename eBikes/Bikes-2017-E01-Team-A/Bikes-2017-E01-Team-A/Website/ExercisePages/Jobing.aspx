<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Jobing.aspx.cs" Inherits="Jobing" %>
<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanelMessage" runat="server">
            <ContentTemplate>
                <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
            </ContentTemplate>
        </asp:UpdatePanel>
    <div class="jumbotron">
    <h1>Jobing</h1>
        </div>
    <h3> By : Vivek Singh</h3>
    <img src="../images/pp.jpg" / width="320">
</asp:Content>

