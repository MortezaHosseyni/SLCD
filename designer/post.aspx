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
    <form runat="server" method="post" id="process_table" class="container">
        <div class="row input-group mb-3 mt-3">
            <div class="col" id="inp_x" runat="server">
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inp_1">Input X</label>
                </div>
                <select class="form-select sel" id="inp_1" runat="server">
                    <option value="2">0</option>
                    <option value="3">1</option>
                </select>
            </div>

            <div class="col" id="inp_y" runat="server">
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inp_2">Input Y</label>
                </div>
                <select class="form-select sel" id="inp_2" runat="server">
                    <option value="2">0</option>
                    <option value="3">1</option>
                </select>
            </div>

            <div class="col" id="inp_z" runat="server">
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inp_3">Input Z</label>
                </div>
                <select class="form-select sel" id="inp_3" runat="server">
                    <option value="2">0</option>
                    <option value="3">1</option>
                </select>
            </div>

            <div class="col" id="inp_w" runat="server">
                <div class="input-group-prepend">
                    <label class="input-group-text" for="inp_4">Input W</label>
                </div>
                <select class="form-select sel" id="inp_4" runat="server">
                    <option value="2">0</option>
                    <option value="3">1</option>
                </select>
            </div>
        </div>
        <div class="input-group mb-3">
            <asp:Button CssClass="btn btn-outline-secondary bg-success text-white" ID="btn_Process" OnClick="btn_Process_Click" Text="Process" runat="server" />
            <input type="text" class="form-control" placeholder="Results..." aria-label="Example text with button addon" aria-describedby="btn_Process" id="txt_results" runat="server">
            <button class="btn btn-outline-secondary bg-success text-white" type="button" id="btn_copy">
                <img width="22" src="img/copy.png" />
            </button>
        </div>
    </form>
</asp:Content>
