using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class QuartoViewModel
    {

        public int Numero { get; set; }
        public double Preco { get; set; }
        [Display(Name ="Tipo de Quarto")]
        public TipoQuarto TipoQuarto { get; set; }
    }
    public enum TipoQuarto
    {
        Solteiro, Casal, Presidencial
    }
}