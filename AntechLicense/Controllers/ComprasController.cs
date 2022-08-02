using AntechLicense.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Controllers
{
    [Route("api/[controller]")]
    public class ComprasController: ControllerBase
    {
        private DataContext dataContex;

        public ComprasController(DataContext ctx)
        {
            dataContex = ctx;
        }

        [HttpGet]
        public IAsyncEnumerable<Compra> GetCompras()
        {
            return dataContex.Compras;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCompras([FromBody]List<Compra> Compras)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Compras = Compras.OrderBy(ob => ob.Id).ToList();

                    List<Compra> lCompras = dataContex.Compras
                                .Where(f => f.Id >= Compras.FirstOrDefault().Id && f.Id <= Compras.LastOrDefault().Id).ToList();
                    foreach (Compra ObjCompra in Compras)
                    {
                        if (lCompras.Find(f => f.Id == ObjCompra.Id) == null)
                        {
                            // To prevent over binding and for no use a class for binding target
                            Compra NewCompra = new Compra();

                            NewCompra.PaisId = ObjCompra.PaisId;          //Mexico
                            NewCompra.AgrupacionId = ObjCompra.AgrupacionId;    //Unefarm
                            NewCompra.CadenaId = ObjCompra.CadenaId;        //Farma y Mas
                            NewCompra.PropietarioId = ObjCompra.PropietarioId;   //Agustin 

                            NewCompra.IdRecepcion = ObjCompra.IdRecepcion;
                            NewCompra.FolioDocumento = ObjCompra.FolioDocumento;
                            NewCompra.OrdenCompra = ObjCompra.OrdenCompra;
                            NewCompra.PorcentajeIEPS = ObjCompra.PorcentajeIEPS;
                            NewCompra.ImporteIEPS = ObjCompra.ImporteIEPS;
                            NewCompra.ImporteIVA = ObjCompra.ImporteIVA;
                            NewCompra.PorcentajeIVA = ObjCompra.PorcentajeIVA;
                            NewCompra.Subtotal = ObjCompra.Subtotal;
                            NewCompra.Total = ObjCompra.Total;
                            NewCompra.IdUsuario = ObjCompra.IdUsuario;
                            NewCompra.Fecha = ObjCompra.Fecha;
                            NewCompra.Status = ObjCompra.Status;
                            NewCompra.IdTipoPago = ObjCompra.IdTipoPago;
                            NewCompra.FechaVencimiento = ObjCompra.FechaVencimiento;
                            NewCompra.ComprasD = ObjCompra.ComprasD;

                            await dataContex.Compras.AddAsync(NewCompra);
                            await dataContex.SaveChangesAsync();
                        }
                    }
                    return Ok(Compras);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveCompra([FromBody] Compra ObjCompra)
        {
            try
            {
                if (ModelState.IsValid)
                {   
                    Compra Compra = dataContex.Compras
                                .Where(f => f.Id >= ObjCompra.Id && f.Id <= ObjCompra.Id).FirstOrDefault();
                    if (Compra == null)
                    {
                        // To prevent over binding and for no use a class for binding target
                        Compra NewCompra = new Compra();

                        NewCompra.PaisId = ObjCompra.PaisId;          //Mexico
                        NewCompra.AgrupacionId = ObjCompra.AgrupacionId;    //Unefarm
                        NewCompra.CadenaId = ObjCompra.CadenaId;        //Farma y Mas
                        NewCompra.PropietarioId = ObjCompra.PropietarioId;   //Agustin 

                        NewCompra.IdRecepcion = ObjCompra.IdRecepcion;
                        NewCompra.FolioDocumento = ObjCompra.FolioDocumento;
                        NewCompra.OrdenCompra = ObjCompra.OrdenCompra;
                        NewCompra.PorcentajeIEPS = ObjCompra.PorcentajeIEPS;
                        NewCompra.ImporteIEPS = ObjCompra.ImporteIEPS;
                        NewCompra.ImporteIVA = ObjCompra.ImporteIVA;
                        NewCompra.PorcentajeIVA = ObjCompra.PorcentajeIVA;
                        NewCompra.Subtotal = ObjCompra.Subtotal;
                        NewCompra.Total = ObjCompra.Total;
                        NewCompra.IdUsuario = ObjCompra.IdUsuario;
                        NewCompra.Fecha = ObjCompra.Fecha;
                        NewCompra.Status = ObjCompra.Status;
                        NewCompra.IdTipoPago = ObjCompra.IdTipoPago;
                        NewCompra.FechaVencimiento = ObjCompra.FechaVencimiento;
                        NewCompra.ComprasD = ObjCompra.ComprasD;

                        await dataContex.Compras.AddAsync(NewCompra);
                        await dataContex.SaveChangesAsync();
                    }
                    return Ok(ObjCompra);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
