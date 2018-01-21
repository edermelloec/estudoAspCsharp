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
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDados.Visible = false;
        }

        protected void btnPesquisaCliente(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);

                PessoaDAL pDal = new PessoaDAL();
                Pessoa p = pDal.buscarPorCodigo(codigo);

                if(p != null)
                {
                    pnlDados.Visible = true;
                    txtNome.Text = p.Nome;
                    txtEndereco.Text = p.Endereco;
                    txtEmail.Text = p.Email;
                }else
                {
                    lblMensagem.Text = "Cliente não Encontrado";
                    txtCodigo.Text = string.Empty;
                }

                

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnExcluirCliente(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);

                Pessoa p = new Pessoa();
                PessoaDAL pDal = new PessoaDAL();

                pDal.excluir(p.Codigo);

                lblMensagem.Text = "Cliente Excluido com sucesso";

                txtCodigo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtEmail.Text = string.Empty;
                
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnAtualizarCliente(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();

                pessoa.Codigo = Convert.ToInt32(txtCodigo.Text);
                pessoa.Nome = Convert.ToString(txtNome.Text);
                pessoa.Endereco = Convert.ToString(txtEndereco.Text);
                pessoa.Email = Convert.ToString(txtEmail.Text);

                PessoaDAL pDAL = new PessoaDAL();
                pDAL.atualizar(pessoa);

                lblMensagem.Text = "Cliente Atualizado com Sucesso!!";

                txtCodigo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}