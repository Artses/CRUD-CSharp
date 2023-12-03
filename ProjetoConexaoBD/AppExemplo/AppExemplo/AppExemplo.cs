using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppExemplo
{
    internal class conexao
    {
        MySqlConnection conn;

        public void conectar()
        {
            try
            {
                string conexao = "Persist security info = false; server = localhost; database = BdExemplo; user = root; pwd=;";
                conn = new MySqlConnection(conexao);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Verifique a conexão com Banco de Dados");
            }

        }
        public void ExecutarComando(string sql)
        {
            conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery(); // instrução que executa o comando no sql
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na insrução SQL");
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ExecutarConsulta(string sql)
        {
            conectar();

            try
            {
                MySqlDataAdapter dt = new MySqlDataAdapter(sql, conn);
                DataTable dados = new DataTable();
                dt.Fill(dados);
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Verifique a instrução do Select fornecida");   
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

