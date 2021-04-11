using System;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    class BdHandyMan : IDisposable
    {
        private readonly SqlConnection conexao;

        public BdHandyMan()
        {
            string BdServerName = @"DESKTOP-C46EB5G\SQLEXPRESS";
            string BdName = "Semantix";

            conexao = new SqlConnection(@"data source=" + BdServerName + ";Integrated Security=SSPI;Initial Catalog=" + BdName);
            conexao.Open();
        }

        public int ExecutaComando(String Query)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = Query,
                CommandType = CommandType.Text,
                Connection = conexao
            };


            return Convert.ToInt32(cmdComando.ExecuteScalar());
        }

        public SqlDataReader ExecutaComandoComRetorno(String Query)
        {
            var cmdComando = new SqlCommand(Query, conexao);

            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    
    }
}
