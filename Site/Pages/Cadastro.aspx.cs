using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistence;
namespace Site.Pages
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarCliente(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();

                pessoa.Nome = txtNome.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Email = txtEmail.Text;

                PessoaDAL pessoaDal = new PessoaDAL();

                pessoaDal.salvar(pessoa);

                lblMensagem.Text = "Cliente " + pessoa.Nome + " Cadastrada com Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Cliente" +ex.Message);
            }

        }
    }
}