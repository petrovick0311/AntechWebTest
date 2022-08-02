using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntechLicense.Models
{
    public class Licencia
    {
        public int LicenciaID { get; set; }

        [Required(ErrorMessage = "Please enter a Número de licencia")]
        public string NumeroLicencia { get; set; }

        
        public string eMail { get; set; }

        
        public string NombrePropietario { get; set; }

        [Required(ErrorMessage = "Please enter a Nombre Sucursal")]
        public string NombreSucursal { get; set; }
        public string MacAddress { get; set; }
        public string Ubicacion { get; set; }

        public string TipoLicencia { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Precio { get; set; }
    }
}
