<%@ Page Title="" Language="C#" MasterPageFile="~/designer/index.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="SLCD.designer.post" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <img class="w-100" id="img_PostImage" runat="server" />
    <h1 id="lbl_PostName" runat="server"></h1>
    <div class="row">
        <span class="col" id="lbl_PostFormul" runat="server">Formul: </span>
        <span class="col" id="lbl_PostInputs" runat="server">Inputs: </span>
    </div>
    <hr />
    <div class="container">
        <div class="row input-group mb-3 mt-3">
            <% for (int i = 0; i < cCount; i++)
                { %>
            <div class="col">
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inputGroupSelect0<%= i+1 %>">Input <%= i+1 %></label>
                </div>
                <select class="form-select" id="inputGroupSelect0<%= i+1 %>">
                    <option value="1">0</option>
                    <option value="2">1</option>
                </select>
            </div>
            <% } %>
        </div>
        <div class="input-group mb-3">
            <button class="btn btn-outline-secondary bg-success text-white" type="button" id="button-addon1">Process</button>
            <input type="text" class="form-control" placeholder="Results..." aria-label="Example text with button addon" aria-describedby="button-addon1">
            <button class="btn btn-outline-secondary bg-success text-white" type="button" id="btn_copy">
                <img width="22" src="img/copy.png" />
            </button>
        </div>
    </div>
</asp:Content>
