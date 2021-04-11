using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Validadores
{
    public class TelefoneValidador
    {
        public static void Validar(Telefone telefone)
        {
            if (string.IsNullOrEmpty(telefone.Numero))
                throw new Exception("Número do Telefone está inconsistente !");
        }
    }
}