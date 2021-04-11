using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class TelefoneExtensions
    {
        public static string NumeroSemMascara(this Telefone telefone)
        {
            return telefone.Numero
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "");
        }
    }
}