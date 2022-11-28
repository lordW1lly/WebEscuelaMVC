using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebEscuelaMVC.Validations;


namespace WebEscuelaMVC.Models
{
    public class Aula
    {
        public int Id { get; set; }
        ///
        [Required]
        [CheckValidNumero]
        
        public int Numero { get; set; }
        //
        [Required]
        public string Estado { get; set; }

    }
}