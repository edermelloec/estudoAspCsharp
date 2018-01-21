using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Persistence
{
    public class Conexao
    {
        protected SqlConnection conexao;
        protected SqlCommand command;
        protected SqlDataReader dataReader;

        protected void abrirConexao()
        {
            try
            {
                conexao = new SqlConnection("Data Source=EDER\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=123");
                conexao.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void fecharConexao()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
