<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="IcbfApp.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">Bienvenido</asp:Label>
            
        </div>

        <div>
            <asp:button runat="server" text="Niños" OnClick="Unnamed1_Click" />
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Asistencia" Value="mAsistencia"></asp:MenuItem>
                    <asp:MenuItem Text="Avance Academico" Value="mAvanceAcademico"></asp:MenuItem>
                    <asp:MenuItem Text="Usuarios" Value="mUsuarios">
                        <asp:MenuItem Text="Consultar Madre" Value="consultarMadre"></asp:MenuItem>
                        <asp:MenuItem Text="Consultar Acudiente" Value="consultarAcudiente"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/ConsultarNinos.aspx" Text="Consultar Niños" Value="consultarNinos"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>

            </asp:Menu>
        </div>
            
    </form>
</body>
</html>

