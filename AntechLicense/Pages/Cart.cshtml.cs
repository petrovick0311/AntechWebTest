using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AntechLicense.Infraestructure;
using AntechLicense.Models;
using System.Linq;

namespace AntechLicense.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int licenciaId, string returnUrl)
        {
            Licencia licencia = repository.Licencias
            .FirstOrDefault(p => p.LicenciaID == licenciaId);            
            Cart.AddItem(licencia, 1);            
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int licenciaId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Licencia.LicenciaID == licenciaId).Licencia);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
