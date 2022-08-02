using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();       
        public virtual void AddItem(Licencia licencia, int quantity)
        {
            CartLine line = Lines
            .Where(p => p.Licencia.LicenciaID == licencia.LicenciaID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Licencia = licencia,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Licencia licencia) =>
            Lines.RemoveAll(l => l.Licencia.LicenciaID == licencia.LicenciaID);
        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Licencia.Precio * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Licencia Licencia { get; set; }
        public int Quantity { get; set; }
    }
}
