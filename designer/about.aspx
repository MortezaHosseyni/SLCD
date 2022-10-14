<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="SLCD.designer.about" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <title>About Us</title>
</head>
<body class="bg-secondary text-center">
    <div class="d-inline-block container bg-dark mt-5 ms-2 me-2 rounded-3 text-center p-3">
        <div class="row">
            <h2 class="text-white">Simple Logic Circut Designer</h2>
            <span class="text-white text-start">Developer: Morteza Hosseini</span>
            <span class="text-white text-start">Version: 1.0</span>
        </div>
        <div class="row">
            <a href="mailto:morteza_hoseyni81@yahoo.com" target="_blank" class="col mb-1">
                <button type="button" class="btn btn-secondary">Mail</button></a>
            <a href="https://github.com/MrMeeann" target="_blank" class="col mb-1">
                <button type="button" class="btn btn-secondary">GitHub</button></a>
            <a href="../designer/home.aspx" target="_blank" class="col mb-1">
                <button type="button" class="btn btn-secondary">Home</button></a>
        </div>
    </div>
</body>
</html>
