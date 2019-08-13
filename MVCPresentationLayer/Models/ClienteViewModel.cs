using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email{ get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}