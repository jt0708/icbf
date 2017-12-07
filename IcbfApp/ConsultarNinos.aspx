<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarNinos.aspx.cs" Inherits="IcbfApp.ConsultarNinos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">Codigo</asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Label">Nombres</asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Label">Apellidos</asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Label">Documento</asp:Label>
            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Label">Fecha Nacimiento</asp:Label>
            <asp:Calendar ID="dtFecha" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" SelectedDate="12/06/2017 17:31:37" Width="350px" OnSelectionChanged="dtFecha_SelectionChanged">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label12" runat="server" Text="Label">Ciudad Nacimiento</asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label13" runat="server" Text="Label">Dirección </asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label14" runat="server" Text="Label">Telefono</asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label6" runat="server" Text="Label">Peso</asp:Label>
            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="Label">Talla</asp:Label>
            <asp:TextBox ID="txtTalla" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label8" runat="server" Text="Label">Tipo sangre</asp:Label>
            <asp:DropDownList ID="DDLTipoSangre" runat="server">
                <asp:ListItem>A+</asp:ListItem>
                <asp:ListItem>A-</asp:ListItem>
                <asp:ListItem>AB+</asp:ListItem>
                <asp:ListItem>AB-</asp:ListItem>
                <asp:ListItem>B+</asp:ListItem>
                <asp:ListItem>B-</asp:ListItem>
                <asp:ListItem>O+</asp:ListItem>
                <asp:ListItem>O-</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label9" runat="server" Text="Label">EPS</asp:Label>
            <asp:DropDownList ID="DDLEps" runat="server">
                <asp:ListItem>Famisanar</asp:ListItem>
                <asp:ListItem>Medimas</asp:ListItem>
                <asp:ListItem>Colsanitas</asp:ListItem>
                <asp:ListItem>Salud Total</asp:ListItem>
                <asp:ListItem>Nueva Eps</asp:ListItem>
                <asp:ListItem>Compensar</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label10" runat="server" Text="Label">Acudiente</asp:Label>
            <asp:DropDownList ID="DDLAcudiente" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label11" runat="server" Text="Label">Jardin</asp:Label>
            <asp:DropDownList ID="DDLJardin" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="Button1_Click" Width="86px" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="Button2_Click" />
             <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="Button3_Click" Width="82px" />
        </div>

        
        
        <br />

        <div>
            <asp:GridView ID="gvNinos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvNinos_RowCommand">

                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="Documento" HeaderText="Numero Documento" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />                    
                    <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" />
                    <asp:BoundField DataField="ciudadNacimiento" HeaderText="Ciudad Nacimiento" />
                    <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="peso" HeaderText="Peso" />
                    <asp:BoundField DataField="talla" HeaderText="Talla" />
                    <asp:BoundField DataField="tipoSangre" HeaderText="Tipo Sangre" />
                    <asp:BoundField DataField="eps" HeaderText="EPS" />
                    <asp:BoundField DataField="Acudiente" HeaderText="Acudiente" />
                    <asp:BoundField DataField="Jardin" HeaderText="Jardin" />
                    <asp:ButtonField CommandName="eliminar" HeaderText="Eliminar" ShowHeader="true" Text="Eliminar" />
                    <asp:ButtonField CommandName="editar" HeaderText="Editar" ShowHeader="true" Text="Editar" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

            </asp:GridView>
        </div>

    </form>
</body>
</html>
