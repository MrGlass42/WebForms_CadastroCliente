using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class ClienteExtensions
    {
        public static string RGSemMascara(this Cliente cliente)
        {
            return cliente.RG
                .Replace(".", "")
                .Replace("-", "");
        }

        public static string CPFSemMascara(this Cliente cliente)
        {
            return cliente.CPF
                .Replace(".", "")
                .Replace("-", "");
        }
    }
}