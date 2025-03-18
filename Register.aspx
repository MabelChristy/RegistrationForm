<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegistrationForm.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registration Form</h2>
    <div>
        <label>M.No:</label> 
        <asp:TextBox ID="txtMNo" runat="server" AutoPostBack="true" OnTextChanged="txtMNo_TextChanged"></asp:TextBox>
        <br />

        <label>Name:</label> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <label>DOB:</label> <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <label>Address:</label> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <label>PAN:</label> <asp:TextBox ID="TextBox5" runat="server" MaxLength="10"></asp:TextBox>
        <br />
        <label>Aadhar:</label> <asp:TextBox ID="TextBox6" runat="server" MaxLength="12"></asp:TextBox>
        <br />

        <div>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click"/>
            <asp:Button ID="Button3" runat="server" Text="Edit" OnClick="Button3_Click"/>
            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click"/>
        </div>
        <div>
            <asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" />
        </div>
    </div>
</asp:Content>
