<%@ Page Title="" Language="C#" MasterPageFile="~/designer/userarea/user.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="SLCD.designer.userarea.posts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="panel_content" runat="server">
    <div class="d-inline-flex row mt-2 ms-md-5">
        <%while (pData.Read())
            { %>
        <%if (Convert.ToInt32(pData["CT_Enable"]) == 0)
            {
                lbl_Disable.Visible = true;
            }
        %>
        <div class="card col-md-2 me-md-1 mb-2" style="width: 18rem;">
            <img src="../../resources/pictures/<%=pData["CT_Picture"] %>" class="card-img-top" alt="<%=pData["CT_Name"] %>">
            <div class="card-body text-start">
                <h5 class="card-title"><%=pData["CT_Name"] %></h5>
                <div class="row">
                    <span><%=pData["CT_Formul"] %></span>
                    <span>Inputs: <%=pData["CT_InputCount"] %></span>
                    <span class="m-1 rounded-3 text-white bg-danger" visible="false" id="lbl_Disable" runat="server">Disabled</span>
                </div>
                <a href="../../designer/post.aspx?pid=<%=pData["CT_ID"] %>" target="_blank" class="btn btn-primary">Process</a>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>