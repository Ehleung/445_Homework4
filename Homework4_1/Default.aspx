<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework4_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Homework 4 Part 1</h1>
        <p class="lead">Ellery Leung</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>XML Reader</h2>
            <p>
                Input XML URL here:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            </p>
        </div>
        <br />
        Output:<br />
        <span style="font-weight: normal">
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </span>
    </div>

</asp:Content>
