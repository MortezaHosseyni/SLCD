<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SLCD.designer.userarea.login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <title>SLCD | Login</title>
</head>
<body class="bg-secondary text-center">
    <div class="d-inline-block mt-5 p-5 ms-3 rounded-3 w-75 align-content-center bg-dark ">
        <h2 class="text-white">Login</h2>

        <div id="mbox_Empty" runat="server" class="bg-warning text-start rounded-3" visible="false">
            <p class="p-3">📃 Please check empty fields...</p>
        </div>
        <div id="mbox_Error" runat="server" class="bg-danger pt-2 text-start text-white rounded-3" visible="false">
            <p class="p-3">❌ Username or password is not correct!</p>
        </div>
        <div id="mbox_Success" runat="server" class="bg-success text-start text-white rounded-3" visible="false">
            <p class="p-3">✅ Login successfully!</p>
        </div>

        <form runat="server" method="post">
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">@</span>
                <input runat="server" id="txt_Username" type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" />
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon2">*</span>
                <input runat="server" id="txt_Password" type="password" class="form-control" placeholder="Password" aria-label="Username" aria-describedby="basic-addon2" />
            </div>
            <asp:Button Text="Login" CssClass="w-100 btn btn-secondary" ID="btn_Login" runat="server" OnClick="btn_Login_Click" />
        </form>
        <div class="text-start">
            <a class="d-inline-flex text-white mt-5" href="../../designer/home.aspx">Home</a>
        </div>
    </div>
</body>
</html>
