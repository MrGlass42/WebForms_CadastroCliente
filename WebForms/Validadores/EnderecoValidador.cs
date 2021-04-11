using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Validadores
{
    public class EnderecoValidador
    {
        public static void Validar(Endereco endereco)
        {
            if (string.IsNullOrEmpty(endereco.Rua))
                throw new Exception("Rua do Endereço está inconsistente !");

            if (string.IsNullOrEmpty(endereco.Bairro))
                throw new Exception("Bairro do Endereço está inconsistente !");

            if (string.IsNullOrEmpty(endereco.CEP))
                throw new Exception("CEP do Endereço está inconsistente !");

            if (string.IsNullOrEmpty(endereco.Cidade))
                throw new Exception("Cidade do Endereço está inconsistente !");

            if (string.IsNullOrEmpty(endereco.Estado))
                throw new Exception("Estado do Endereço está inconsistente !");

            if (string.IsNullOrEmpty(endereco.Numero))
                throw new Exception("Numero do Endereço está inconsistente !");
        }
    }
}