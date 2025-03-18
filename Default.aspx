<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegistrationForm.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registration Form</h2>
    <div class="form-container">
        <label>M.No:</label> <asp:TextBox ID="txtMNo" runat="server"></asp:TextBox>
        <br />
        <label>Name:</label> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <label>DOB:</label> <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <label>Address:</label> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <label>PAN:</label> <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <label>Aadhar:</label> <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <div class="button-container">
            <asp:Button ID="Button1" runat="server" Text="Add"/>
            <asp:Button ID="Button2" runat="server" Text="Save"/>
            <asp:Button ID="Button3" runat="server" Text="Edit"/>
            <asp:Button ID="Button4" runat="server" Text="Delete"/>
        </div>
    </div>
</asp:Content>
