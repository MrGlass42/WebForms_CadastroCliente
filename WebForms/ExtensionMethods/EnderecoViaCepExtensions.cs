using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class EnderecoViaCepExtensions
    {
        public static Endereco ToEndereco(this EnderecoViaCep endereco)
        {
            return new Endereco
            {
                Bairro = endereco.bairro,
                CEP = endereco.cep,
                Cidade = endereco.localidade,
                Complemento = endereco.complemento,
                Estado = endereco.uf,
                Rua = endereco.logradouro
            };
        }
    }
}