using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class SqlDataReaderExtensions
    {
        public static List<Cliente> ReaderToListaCliente(this SqlDataReader reader)
        {
            var Clientes = new List<Cliente>();

            while (reader.Read())
            {
                var cliente = new Cliente()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    RG = reader["RG"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    Telefone = new Telefone { Numero = reader["Telefone"].ToString() },
                    Email = reader["Email"].ToString(),
                };

                Clientes.Add(cliente);
            }

            return Clientes;
        }

        public static Endereco ReaderToEndereco(this SqlDataReader reader)
        {
            Endereco endereco = null;
            while (reader.Read())
            {
                endereco = new Endereco
                {
                    Rua = reader["Rua"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    Estado = reader["Estado"].ToString(),
                    CEP = reader["CEP"].ToString(),
                    Complemento = reader["Complemento"].ToString(),
                };
            }

            return endereco;
        }

        public static Telefone ReaderToTelefone(this SqlDataReader reader)
        {
            Telefone telefone = null;
            while (reader.Read())
            {
                telefone = new Telefone
                {
                    Numero = reader["Numero"].ToString()
                };
            }

            return telefone;
        }

        public static Cliente ReaderToCliente(this SqlDataReader reader)
        {
            Cliente Cliente = null;
            while (reader.Read())
            {
                Cliente = new Cliente
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    RG = reader["RG"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }

            return Cliente;
        }
    }
}