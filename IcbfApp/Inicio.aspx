<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="IcbfApp.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        
        <div>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" FailureText="Usuario o Contraseña incorrecta. intentelo de nuevo"></asp:Login>
        </div>
    </form>
</body>
</html>
