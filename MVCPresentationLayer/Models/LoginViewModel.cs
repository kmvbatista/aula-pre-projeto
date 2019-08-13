using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}