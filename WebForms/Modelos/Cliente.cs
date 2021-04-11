﻿using System;

namespace Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Email { get; set; }
        public Telefone Telefone { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}
