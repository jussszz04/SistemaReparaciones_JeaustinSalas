<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaReparaciones.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Iniciar sesión</title>

    <style>
        body {
            font-family: Arial;
            background-color: #eef2f5;
            margin: 0;
        }

        .login {
            width: 380px;
            margin: 100px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px #999;
        }

        h2 {
            text-align: center;
            color: #1f4e79;
        }

        .campo {
            width: 100%;
            padding: 10px;
            margin-top: 6px;
            margin-bottom: 16px;
            box-sizing: border-box;
        }

        .boton {
            width: 100%;
            padding: 11px;
            border: none;
            border-radius: 5px;
            background-color: #1f4e79;
            color: white;
            cursor: pointer;
        }

        .boton:hover {
            background-color: #163a5c;
        }

        .mensaje {
            display: block;
            margin-top: 15px;
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="login">

        <h2>Iniciar sesión</h2>

        <asp:Label
            ID="lblCorreo"
            runat="server"
            Text="Correo electrónico">
        </asp:Label>

        <asp:TextBox
            ID="txtCorreo"
            runat="server"
            CssClass="campo">
        </asp:TextBox>

        <asp:Label
            ID="lblClave"
            runat="server"
            Text="Contraseña">
        </asp:Label>

        <asp:TextBox
            ID="txtClave"
            runat="server"
            TextMode="Password"
            CssClass="campo">
        </asp:TextBox>

        <asp:Button
            ID="btnIngresar"
            runat="server"
            Text="Ingresar"
            CssClass="boton"
            OnClick="btnIngresar_Click" />

        <asp:Label
            ID="lblMensaje"
            runat="server"
            CssClass="mensaje">
        </asp:Label>

    </div>

</form>

</body>
</html>