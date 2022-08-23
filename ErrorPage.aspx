<%@ Page Language="C#" MasterPageFile="~/Pops.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Public.ErrorPage" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content3" ContentPlaceHolderID="M_Content" Runat="Server">

    <p style="color:Red;width: 100%;">
An error occured while processing your request. This error has been sent to your system administrator to be resolved.
<a href="default.aspx" target="_top">Return to Home Page</a>
</p>
</asp:Content>

