using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public int AgrupacionId { get; set; }
        public int CadenaId { get; set; }
        public int PropietarioId { get; set; }


        [Required]
        public int IdRecepcion { get; set; }

        [Required]
        [MaxLength(25)]
        public string FolioDocumento { get; set; }

        [MaxLength(25)]
        public string OrdenCompra { get; set; }

        public decimal PorcentajeIEPS { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal ImporteIEPS { get; set; }
        public decimal ImporteIVA { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Status { get; set; }

        public int IdTipoPago { get; set; }

        public DateTime FechaVencimiento { get; set; }

        [Required]
        public List<CompraD> ComprasD { get; set; } = new List<CompraD>();

    }

    public class CompraD
    {
        public int Id { get; set; }
        [Required]
        public int IdRecepcion { get; set; }
        [Required]
        public int IdRecepcionD { get; set; }

        [Required]        
        public int ArticuloId { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal ImporteIEPS { get; set; }
        public decimal ImporteIVA { get; set; }        
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Status { get; set; }

        public string Lote { get; set; }

        public DateTime Caducidad { get; set; }

        public int CompraId { get; set; }

    }
}
