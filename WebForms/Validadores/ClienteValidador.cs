using Modelos;
using System;
using ExtensionMethods;

namespace Validadores
{
    public class ClienteValidador
    {
        public static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                throw new Exception("Nome do Cliente está inconsistente !");

            if (string.IsNullOrEmpty(cliente.RG))
                throw new Exception("RG do Cliente está inconsistente !");

            if (string.IsNullOrEmpty(cliente.CPF))
                throw new Exception("CPF do Cliente está inconsistente !");

            if(string.IsNullOrEmpty(cliente.Email))
                throw new Exception("Email do Cliente está inconsistente !");

            TelefoneValidador.Validar(cliente.Telefone);
            EnderecoValidador.Validar(cliente.Endereco);
        }
    }
}