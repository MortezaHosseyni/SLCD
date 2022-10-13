<%@ Page Title="" Language="C#" MasterPageFile="~/designer/index.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SLCD.designer.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="d-inline-flex row ms-md-5">
        <%while (pData.Read())
            { %>
        <div class="card col-md-2 me-md-1 mb-2" style="width: 18rem;">
            <img src="../resources/pictures/<%=pData["CT_Picture"] %>" class="card-img-top" alt="<%=pData["CT_Name"] %>">
            <div class="card-body text-start">
                <h5 class="card-title"><%=pData["CT_Name"] %></h5>
                <div class="row">
                    <span><%=pData["CT_Formul"] %></span>
                    <span>Inputs: <%=pData["CT_InputCount"] %></span>
                </div>
                <a href="../designer/post.aspx?pid=<%=pData["CT_ID"] %>" class="btn btn-primary">Process</a>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
