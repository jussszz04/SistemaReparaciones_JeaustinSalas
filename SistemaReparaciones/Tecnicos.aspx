<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="SistemaReparaciones.Tecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Mantenimiento de Técnicos</title>

    <style>
        body {
            font-family: Arial;
            background-color: #eef2f5;
            margin: 0;
        }

        .contenedor {
            width: 850px;
            margin: 35px auto;
            background-color: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 0 10px #999;
        }

        h2 {
            text-align: center;
            color: #1f4e79;
        }

        .campo {
            width: 100%;
            padding: 9px;
            margin-top: 5px;
            margin-bottom: 14px;
            box-sizing: border-box;
        }

        .boton {
            padding: 10px 18px;
            border: none;
            border-radius: 5px;
            background-color: #1f4e79;
            color: white;
            cursor: pointer;
            margin-right: 5px;
        }

        .boton:hover {
            background-color: #163a5c;
        }

        .boton-limpiar {
            background-color: #777;
        }

        .mensaje {
            display: block;
            margin-top: 15px;
            font-weight: bold;
        }

        .tabla {
            margin-top: 25px;
            width: 100%;
            border-collapse: collapse;
        }

        .tabla th {
            background-color: #1f4e79;
            color: white;
            padding: 8px;
        }

        .tabla td {
            padding: 8px;
            text-align: center;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="contenedor">

        <h2>Mantenimiento de Técnicos</h2>

        <asp:HiddenField ID="hfTecnicoID" runat="server" />

        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="campo"></asp:TextBox>

        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
        <asp:TextBox ID="txtEspecialidad" runat="server" CssClass="campo"></asp:TextBox>

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar"
            CssClass="boton"
            OnClick="btnGuardar_Click" />

        <asp:Button
            ID="btnModificar"
            runat="server"
            Text="Modificar"
            CssClass="boton"
            OnClick="btnModificar_Click" />

        <asp:Button
            ID="btnLimpiar"
            runat="server"
            Text="Limpiar"
            CssClass="boton boton-limpiar"
            OnClick="btnLimpiar_Click" />

        <asp:Label
            ID="lblMensaje"
            runat="server"
            CssClass="mensaje">
        </asp:Label>

        <asp:GridView
            ID="gvTecnicos"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tabla"
            GridLines="Both"
            OnRowCommand="gvTecnicos_RowCommand">

            <Columns>

                <asp:BoundField
                    DataField="TecnicoID"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="Nombre"
                    HeaderText="Nombre" />

                <asp:BoundField
                    DataField="Especialidad"
                    HeaderText="Especialidad" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>

                        <asp:Button
                            ID="btnSeleccionar"
                            runat="server"
                            Text="Seleccionar"
                            CssClass="boton"
                            CommandName="SeleccionarTecnico"
                            CommandArgument='<%# Eval("TecnicoID") + "|" + Eval("Nombre") + "|" + Eval("Especialidad") %>' />

                        <asp:Button
                            ID="btnEliminar"
                            runat="server"
                            Text="Eliminar"
                            CssClass="boton"
                            CommandName="EliminarTecnico"
                            CommandArgument='<%# Eval("TecnicoID") %>'
                            OnClientClick="return confirm('¿Desea eliminar este técnico?');" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</form>

</body>
</html>