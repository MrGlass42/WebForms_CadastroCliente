using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class EnderecoExtensions
    {
        public static string CEPSemMascara(this Endereco endereco)
        {
            return endereco.CEP
                .Replace("-", "");
        }
    }
}