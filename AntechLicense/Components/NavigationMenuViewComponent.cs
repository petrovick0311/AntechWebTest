using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.Models;

namespace AntechLicense.Components
{
    public class NavigationMenuViewComponent
    : ViewComponent
    {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTipoLicencia = RouteData?.Values["TipoLicencia"];
            return View(repository.Licencias
            .Select(x => x.TipoLicencia)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
