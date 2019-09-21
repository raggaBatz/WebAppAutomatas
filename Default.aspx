<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppCompi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>PROYECTO COMPI</h1>
        <p class="lead">Erick Ricardo Batz Cuscul</p>
    </div>

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-2">
                <h2>Path</h2>
            </div>
            <div class="col-md-4">
               <asp:FileUpload ID="fuArchivo" runat="server" />
            </div>
            <div class="col-md-4">
                <asp:LinkButton ID="btnCargar" CssClass="btn btn-default btn-primary" OnClick="btnCargar_Click" runat="server" Text="Cargar"></asp:LinkButton>   
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            <h2>TXT</h2>
            <p>
                <asp:TextBox id="tbTXT" TextMode="multiline" runat="server" Enabled="false" Rows="15" />
            </p>
        </div>
        <div class="col-md-2">
            <h2>Q</h2>
            <p>
                <asp:TextBox id="tbQ" TextMode="multiline" runat="server" Enabled="false" Rows="15"/>
            </p>
        </div>
        <div class="col-md-2">
            <h2>F</h2>
            <p>
                <asp:TextBox id="tbF" TextMode="multiline" runat="server" Enabled="false" Rows="15"/>
            </p>
        </div>
        <div class="col-md-2">
            <h2>A</h2>
            <p>
                <asp:TextBox id="tbA" TextMode="multiline" runat="server" Enabled="false" Rows="15"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>MATRIZ AFN</h2>
            <p>
                <asp:GridView ID="gvAFN" runat="server" AutoGenerateColumns="true" CssClass="table table-responsive table-striped table-hover">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </p>
        </div>
    </div>

</asp:Content>
