using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string SqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (var connection = new SqlConnection(SqlConn()))
            {
                var query = "SELECT * FROM PAGINAS";
                var comand = new SqlCommand(query, connection);
                comand.Connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = comand;

                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Save(int id, string nome, string conteudo, DateTime data)
        {
            using (var connection = new SqlConnection(SqlConn()))
            {
                var query = string.Empty;
                if (id == 0)
                    query = $@"INSERT INTO PAGINAS (NOME, CONTEUDO, DATA) VALUES ('{nome}', '{conteudo}', {data.ToString("yyyy-MM-dd")})";
                else
                    query = $"UPDATE PAGINAS SET NOME = '{nome}' , CONTEUDO = '{conteudo}' , DATA = {data.ToString("yyyy-MM-dd")} WHERE ID = {id}";

                var comand = new SqlCommand(query, connection);
                comand.Connection.Open();
                comand.ExecuteNonQuery();

            }
        }

        public DataTable BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(SqlConn()))
            {
                var query = $"SELECT * FROM PAGINAS WHERE = {id}";
                var comand = new SqlCommand(query, connection);
                comand.Connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = comand;

                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
