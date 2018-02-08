<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Purchasing.aspx.cs" Inherits="Purchasing" %>
<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanelMessage" runat="server">
            <ContentTemplate>
                <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
            </ContentTemplate>
        </asp:UpdatePanel>
    <div class="jumbotron">
    <h1>Purchasing</h1>
        </div>
    <h3> By : - Akshay</h3>
    <img src="../images/akshay.jpg" width="320 "/>
</asp:Content>

