using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sevco5Beta.Models
{
    public class usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        [Required(ErrorMessage = "Digite el usuario nuevo")]
        public string usuario { get; set; }
       [Required(ErrorMessage = "Debe digitar una clave para el usuario")]
        public string clave { get; set; }
        [Required(ErrorMessage = "Debe seleccionar el tipo de usuario")]
        public bool isAdmin { get; set; }

    }
}