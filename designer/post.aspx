<%@ Page Title="" Language="C#" MasterPageFile="~/designer/index.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="SLCD.designer.post" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <img class="w-100" id="img_PostImage" runat="server"/>
    <h1 id="lbl_PostName" runat="server"></h1>
    <div class="row">
        <span class="col" id="lbl_PostFormul" runat="server">Formul: </span>
        <span class="col" id="lbl_PostInputs" runat="server">Inputs: </span>
    </div>
    
</asp:Content>
