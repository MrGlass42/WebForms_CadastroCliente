using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Modelos;
using ExtensionMethods;

namespace Database
{
    public class ClienteDAO
    {
        private static BdHandyMan _handyMan { get; set; }

        public static Cliente BuscarClientePorId(int Id)
        {
            string Query = $"SELECT * FROM Clientes WHERE Id = {Id};";

            Cliente cliente = null;
            using (_handyMan = new BdHandyMan())
            {
                var retorno = _handyMan.ExecutaComandoComRetorno(Query);
                cliente = retorno.ReaderToCliente();
            }

            Query = $"SELECT * FROM Telefones WHERE ClienteId = {Id};";

            Telefone telefone = null;
            using (_handyMan = new BdHandyMan())
            {
                var retorno = _handyMan.ExecutaComandoComRetorno(Query);
                telefone = retorno.ReaderToTelefone();
            }

            Query = $"SELECT * FROM Enderecos WHERE ClienteId = {Id};";

            Endereco endereco = null;
            using (_handyMan = new BdHandyMan())
            {
                var retorno = _handyMan.ExecutaComandoComRetorno(Query);
                endereco = retorno.ReaderToEndereco();
            }

            cliente.Telefone = telefone;
            cliente.Endereco = endereco;

            return cliente;
        }

        public static void Excluir(int Id)
        {
            string Query = $"DELETE FROM Telefones WHERE ClienteId = {Id}";
            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

            Query = $"DELETE FROM Enderecos WHERE ClienteId = {Id}";
            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

            Query = $"DELETE FROM Clientes WHERE Id = {Id}";
            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }
        }

        public static List<Cliente> BuscarClientes()
        {
            string Query = "SELECT Cli.Id as Id, Tel.Numero as Telefone, RG, CPF, Email, Nome" +
                " FROM Clientes Cli JOIN Telefones Tel ON Tel.ClienteId = Cli.Id;";

            using (_handyMan = new BdHandyMan())
            {
                var retorno = _handyMan.ExecutaComandoComRetorno(Query);

                return retorno.ReaderToListaCliente();
            }
        }

        private static void Inserir(Cliente cliente)
        {
            // Insere Cliente
            string Query = "";
            Query += "INSERT INTO Clientes (Nome, Email, RG , CPF)";
            Query += string.Format("VALUES ('{0}','{1}','{2}','{3}');SELECT SCOPE_IDENTITY();", cliente.Nome, cliente.Email, cliente.RGSemMascara(), cliente.CPFSemMascara());

            int IdCliente = 0;
            using (_handyMan = new BdHandyMan()) { IdCliente = _handyMan.ExecutaComando(Query); }

            // Insere Telefone
            Query = "";
            Query += "INSERT INTO Telefones (Numero, ClienteId)";
            Query += string.Format("VALUES ('{0}',{1});", cliente.Telefone.NumeroSemMascara(), IdCliente);

            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

            // Insere Endereco
            Query = "";
            Query += "INSERT INTO Enderecos (Rua, Bairro, Numero, Cidade, Estado, Complemento, CEP, ClienteId)";
            Query += string.Format("VALUES ('{0}','{1}','{2}','{3}','{4}','{5}', '{6}', '{7}');", cliente.Endereco.Rua, cliente.Endereco.Bairro, cliente.Endereco.Numero, cliente.Endereco.Cidade,
                cliente.Endereco.Estado, cliente.Endereco.Complemento, cliente.Endereco.CEPSemMascara(), IdCliente);

            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

        }

        private static void Atualizar(Cliente cliente)
        {
            string Query = "";

            Query += "UPDATE Clientes SET ";
            Query += string.Format(" Nome = '{0}', ", cliente.Nome);
            Query += string.Format(" Email = '{0}', ", cliente.Email);
            Query += string.Format(" RG = '{0}', ", cliente.RGSemMascara());
            Query += string.Format(" CPF = '{0}' ", cliente.CPFSemMascara());
            Query += string.Format(" WHERE Id = '{0}';", cliente.Id);

            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

            Query = "";
            Query += "UPDATE Enderecos SET ";
            Query += string.Format("Rua = '{0}', ", cliente.Endereco.Rua);
            Query += string.Format(" Bairro = '{0}', ", cliente.Endereco.Bairro);
            Query += string.Format(" Numero = '{0}', ", cliente.Endereco.Numero);
            Query += string.Format(" Cidade = '{0}', ", cliente.Endereco.Cidade);
            Query += string.Format(" Estado = '{0}', ", cliente.Endereco.Estado);
            Query += string.Format(" CEP = '{0}', ", cliente.Endereco.CEPSemMascara());
            Query += string.Format(" Complemento = '{0}' ", cliente.Endereco.Complemento);
            Query += string.Format(" WHERE ClienteId = '{0}'; ", cliente.Id);

            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

            Query = "";
            Query += "UPDATE Telefones SET ";
            Query += string.Format(" Numero = '{0}' ", cliente.Telefone.NumeroSemMascara());
            Query += string.Format(" WHERE ClienteId = '{0}'; ", cliente.Id);

            using (_handyMan = new BdHandyMan()) { _handyMan.ExecutaComando(Query); }

        }

        public static void Salvar(Cliente cliente)
        {
            if (cliente.Id > 0)
                Atualizar(cliente);
            else
                Inserir(cliente);
        }
    }
}
