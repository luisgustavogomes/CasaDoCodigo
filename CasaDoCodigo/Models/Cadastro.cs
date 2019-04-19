﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }

        [MinLength(5, ErrorMessage ="Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage ="Nome deve ter no maxímo 50 caracteres")]
        [Required(ErrorMessage ="Nome é obrigatório!")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Endereco é obrigatório!")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Complemento é obrigatório!")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório!")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Município é obrigatório!")]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório!")]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "CEP é obrigatório!")]
        public string CEP { get; set; } = "";

        internal void Update(Cadastro novoCadastro)
        {
            Nome = novoCadastro.Nome;
            Email = novoCadastro.Email;
            Telefone = novoCadastro.Telefone;
            Endereco = novoCadastro.Endereco;
            Complemento = novoCadastro.Complemento;
            Bairro = novoCadastro.Bairro;
            Municipio = novoCadastro.Municipio;
            UF = novoCadastro.UF;
            CEP = novoCadastro.CEP;
        }
    }
}
