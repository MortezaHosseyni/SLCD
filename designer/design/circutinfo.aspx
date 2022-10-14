<%@ Page Title="Design Circut" Language="C#" MasterPageFile="~/designer/index.Master" AutoEventWireup="true" CodeBehind="circutinfo.aspx.cs" Inherits="SLCD.designer.design.circutinfo" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h2>Coming Soon...</h2>
    <div class="d-none">
        <h2>Design Circut</h2>
        <div id="mbox_Empty" runat="server" class="bg-warning text-start rounded-3" visible="false">
            <p class="p-3">📃 Please check empty fields...</p>
        </div>
        <div id="mbox_Error" runat="server" class="bg-danger pt-2 text-start text-white rounded-3" visible="false">
            <p class="p-3">❌ Username or password is not correct!</p>
        </div>
        <div id="mbox_Success" runat="server" class="bg-success text-start text-white rounded-3" visible="false">
            <p class="p-3">✅ Login successfully!</p>
        </div>
        <form method="post" runat="server">
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">Circut Name</span>
                <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" id="txt_CtName" runat="server">
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon2">Formula</span>
                <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon2" id="txt_CtFormul" runat="server">
            </div>
            <div class="input-group mb-3">
                <label class="input-group-text" for="fle_CtPic">Circut Picture</label>
                <input type="file" class="form-control" id="fle_CtPic" runat="server">
            </div>

            <div class="input-group mb-3">
                <label class="input-group-text" for="slc_Inputs">Inputs</label>
                <select class="form-select" id="slc_Inputs" runat="server">
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                </select>
            </div>
            <asp:Button CssClass="btn btn-primary" Text="Design" ID="btn_Design" runat="server" OnClick="btn_Design_Click"></asp:Button>
        </form>
    </div>
</asp:Content>
