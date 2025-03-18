<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="RegistrationForm.Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Report Page</h2>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500px" ProcessingMode="Local">
    </rsweb:ReportViewer>

</asp:Content>
