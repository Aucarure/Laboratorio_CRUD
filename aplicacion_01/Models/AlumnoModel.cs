using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aplicacion_01.Models
{
    public class AlumnoModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Range(1, 120, ErrorMessage = "La edad debe ser un número positivo")]
        public int Edad { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo válido (ej. nombre@correo.com)")]
        public string Correo { get; set; }
    }
}