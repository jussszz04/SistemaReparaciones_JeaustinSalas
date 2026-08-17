<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SistemaReparaciones.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Menú Principal</title>

    <style>
        body {
            margin: 0;
            font-family: Arial;
            background-color: #eef2f5;
        }

        .contenedor {
            width: 760px;
            margin: 70px auto;
            background-color: white;
            padding: 35px;
            border-radius: 12px;
            box-shadow: 0 0 12px #999;
            text-align: center;
        }

        h1 {
            color: #1f4e79;
            margin-bottom: 10px;
        }

        .bienvenida {
            display: block;
            margin-bottom: 30px;
            font-size: 18px;
        }

        .menu {
            display: flex;
            justify-content: center;
            gap: 20px;
            flex-wrap: wrap;
        }

        .opcion {
            width: 180px;
            padding: 18px;
            text-decoration: none;
            background-color: #1f4e79;
            color: white;
            border-radius: 8px;
            transition: 0.2s;
        }

        .opcion:hover {
            background-color: #163a5c;
            transform: translateY(-2px);
        }

        .cerrar {
            margin-top: 25px;
            padding: 12px 25px;
            background-color: #b33a3a;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
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

        <div class="menu">

            <a href="Usuarios.aspx" class="opcion">
                Usuarios
            </a>

            <a href="Equipos.aspx" class="opcion">
                Equipos
            </a>

            <a href="Tecnicos.aspx" class="opcion">
                Técnicos
            </a>

        </div>

        <asp:Button
            ID="btnCerrarSesion"
            runat="server"
            Text="Cerrar sesión"
            CssClass="cerrar"
            OnClick="btnCerrarSesion_Click" />

    </div>

</form>

</body>
</html>