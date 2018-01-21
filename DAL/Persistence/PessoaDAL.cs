using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Model;

namespace DAL.Persistence
{
    public class PessoaDAL : Conexao
    {
        public void salvar(Pessoa pessoa)
        {
            try
            {
                abrirConexao();

                command = new SqlCommand("insert into Pessoa (Nome, Endereco, Email) values(@v1, @v2, @v3)", conexao);

                command.Parameters.AddWithValue("@v1", pessoa.Nome);
                command.Parameters.AddWithValue("@v2", pessoa.Endereco);
                command.Parameters.AddWithValue("@v3", pessoa.Email);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o Cliente: " + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }

        public void atualizar(Pessoa pessoa)
        {
            try
            {
                abrirConexao();

                command = new SqlCommand("update Pessoa set Nome=@v1, Endereco=@v2, Email=@v3 where Codigo=@v4", conexao);

                command.Parameters.AddWithValue("@v1", pessoa.Nome);
                command.Parameters.AddWithValue("@v2", pessoa.Endereco);
                command.Parameters.AddWithValue("@v3", pessoa.Email);

                command.ExecuteNonQuery();

                command.Parameters.AddWithValue("@v4", pessoa.Codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Cliente: " + ex.Message);
            }

            finally
            {
                fecharConexao();
            }
        }


        public void excluir(int codigo)
        {
            try
            {
                abrirConexao();
                command = new SqlCommand("delete from Pessoa where Codigo=@v1", conexao);

                command.Parameters.AddWithValue("@v1",codigo);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o cliente" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }

        }

        public Pessoa buscarPorCodigo(int codigo)
        {
            try
            {
                abrirConexao();

                command = new SqlCommand("select * from Pessoa where Codigo = @v1", conexao);
                command.Parameters.AddWithValue("@v1", codigo);
                command.ExecuteNonQuery();
                

                Pessoa pessoa = null;

                if (dataReader.Read())
                {
                    pessoa = new Pessoa();

                    pessoa.Codigo = Convert.ToInt32(dataReader["Codigo"]);
                    pessoa.Nome = Convert.ToString(dataReader["Nome"]);
                    pessoa.Endereco = Convert.ToString(dataReader["Endereco"]);
                    pessoa.Email = Convert.ToString(dataReader["Email"]);
                }
                return pessoa;

            }
            catch (Exception ex)
            {

                throw new Exception("Cliente não encontrado" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }

        public List<Pessoa> listarTodos()
        {
            try
            {
                abrirConexao();
                command = new SqlCommand("select * from Pessoa", conexao);

                dataReader = command.ExecuteReader();

                List<Pessoa> listaPessoa = new List<Pessoa>();

                while (dataReader.Read())
                {
                    Pessoa pessoa = new Pessoa();

                    pessoa.Codigo = Convert.ToInt32(dataReader["Codigo"]);
                    pessoa.Nome = Convert.ToString(dataReader["Nome"]);
                    pessoa.Endereco = Convert.ToString(dataReader["Endereco"]);
                    pessoa.Email = Convert.ToString(dataReader["Email"]);

                    listaPessoa.Add(pessoa);
                }
                return listaPessoa;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar cliente" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }

    }
}
