<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SistemaReparaciones.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Menú principal</title>

    <style>
        body {
            font-family: Arial;
            background-color: #eef2f5;
            margin: 0;
        }

        .contenedor {
            width: 700px;
            margin: 80px auto;
            background-color: white;
            padding: 35px;
            border-radius: 12px;
            box-shadow: 0 0 12px #999;
            text-align: center;
        }

        h1 {
            color: #1f4e79;
        }

        .bienvenida {
            font-size: 18px;
            margin-bottom: 30px;
        }

        .boton-menu {
            display: inline-block;
            width: 180px;
            padding: 15px;
            margin: 10px;
            background-color: #1f4e79;
            color: white;
            text-decoration: none;
            border-radius: 6px;
        }

        .boton-menu:hover {
            background-color: #163a5c;
        }

        .cerrar {
            background-color: #b33a3a;
        }

        .cerrar:hover {
            background-color: #862d2d;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="contenedor">

        <h1>Sistema de Reparaciones</h1>

        <asp:Label
            ID="lblBienvenida"
            runat="server"
            CssClass="bienvenida">
        </asp:Label>

        <br />

        <a href="Usuarios.aspx" class="boton-menu">
            Usuarios
        </a>

        <a href="Equipos.aspx" class="boton-menu">
            Equipos
        </a>

        <a href="Tecnicos.aspx" class="boton-menu">
            Técnicos
        </a>

        <br />

        <asp:Button
            ID="btnCerrarSesion"
            runat="server"
            Text="Cerrar sesión"
            CssClass="boton-menu cerrar"
            OnClick="btnCerrarSesion_Click" />

    </div>

</form>

</body>
</html>