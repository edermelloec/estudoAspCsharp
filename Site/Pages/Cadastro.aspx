<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Site.Pages.Cadastro" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro</title>
<link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />

</head>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="span10 offset1">
            <div class="row">
                <h3 class="well">Cadastro de Cliente</h3>
                <br />

                Nome do Cliente: <br />
                
                <asp:TextBox ID="txtNome" runat="server"  Width="45%" CssClass="form-control"/>
                <asp:RequiredFieldValidator ID="requiredNome" runat="server" ControlToValidate="txtNome" 
                        ErrorMessage="Por favor, digite seu nome" ForeColor="Red" />
                <br /><br />

                Endereço do Cliente:<br />
                <asp:TextBox ID="txtEndereco" runat="server"  Width="50%" CssClass="form-control"/>
                <asp:RequiredFieldValidator ID="requiredEndereco" runat="server" ControlToValidate="txtEndereco" 
                        ErrorMessage="Por favor, digite seu endereco" ForeColor="Red" />
                <br /><br />

                Email do Cliente:<br />
                <asp:TextBox ID="txtEmail" runat="server"  Width="25%" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="txtEmail" 
                        ErrorMessage="Por favor, digite seu email" ForeColor="Red" />
                <br /><br />

                <p>
                    <asp:Label ID="lblMensagem" runat="server" />
                </p>
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success btn-lg" OnClick="btnCadastrarCliente"/>
                <a href="/Default.aspx" class="btn btn-default btn-lg">Voltar</a>

            </div>
        </div>
    </div>
    </form>
</body>
</html>