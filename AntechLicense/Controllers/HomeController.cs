using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AntechLicense.Models;
using AntechLicense.Models.ViewModels;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net;
using AntechLicense.Infraestructure;



namespace AntechLicense.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 2;
        public HttpClient client = new HttpClient();
        //public System.IO.Stream strRecompensas;
        public string strRecompensas;
        //public List<RecompensasResponse> plRecompensasResponse = null;
        private RecompensasResponse? recompensasResponse;        

        public HomeController(IStoreRepository repo)
        {
            repository = repo;                       

            client.BaseAddress = new Uri("https://api.reworth.app/dev/directory");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        //public ViewResult Index(string tipoLicencia, int LicensePage = 1)
        //=> View(new LicenseListViewModel
        //{
        //    Licencias = repository.Licencias
        //    .Where(l => tipoLicencia == null || l.TipoLicencia == tipoLicencia)
        //    .OrderBy(l => l.LicenciaID)
        //    .Skip((LicensePage - 1) * PageSize)
        //    .Take(PageSize),
        //    PagingInfo = new PagingInfo
        //    {
        //        CurrentPage = LicensePage,
        //        ItemsPerPage = PageSize,
        //        TotalItems = tipoLicencia == null ?
        //            repository.Licencias.Count() :
        //            repository.Licencias.Where(e => e.TipoLicencia == tipoLicencia).Count()
        //    },
        //    CurrentTipoLicencia = tipoLicencia
        //});

        public RedirectToActionResult Index()
        {
            return RedirectToAction("Inicio");
        }

        public ViewResult Inicio()
        {   
            return View();
        }

        public ViewResult Location(string Name)
        {
            RecompensasData ObjData = (HttpContext.Session.GetJson<RecompensasResponse>("RecompensasResponse")).data.FirstOrDefault(f=> f.name == Name);
            return View(ObjData);
        }

        public ViewResult Mas(string Name)
        {
            RecompensasResponse ObjResponse = HttpContext.Session.GetJson<RecompensasResponse>("RecompensasResponse");            
            RecompensasData ObjData = ObjResponse.data.First(f => f.name == Name);
            return View(ObjData);
        }

        //Es valido pero me gusto la otra version
        //public async Task<IActionResult> Recompensas()
        //{
        //    RecompensasListViewModel rlvm = new RecompensasListViewModel();
        //    rlvm.lRecompensas = await GetRecompensas(client, "");
        //    return View(rlvm);
        //}

        //public async Task<IActionResult> Recompensas()
        //=> View(new RecompensasListViewModel
        //{
        //    lRecompensas = await GetRecompensas(client, "")
        //});

        public async Task<IActionResult> Recompensas()
        {
            await DeserializeRecompensas(client, "");
            HttpContext.Session.SetJson("RecompensasResponse", recompensasResponse);
            return View(recompensasResponse);
        }

        public ViewResult RecompensasR(string sFilter)
        {
            recompensasResponse = HttpContext.Session.GetJson<RecompensasResponse>("RecompensasResponse");
            string[] sSplit = sFilter.Split('=');
            switch (sSplit[0])
            {
                case "cashback_decimal":
                    recompensasResponse.data = recompensasResponse.data.OrderByDescending(ob => ob.cashback_decimal).ToArray();
                    //Array.Sort(recompensasResponse.data, (x, y) => x.cashback_decimal.CompareTo(y.cashback_decimal));
                    break;

                case "rating":
                    recompensasResponse.data = recompensasResponse.data.OrderByDescending(ob => ob.rating).ToArray();
                    break;

                case "created":
                    recompensasResponse.data = recompensasResponse.data.OrderByDescending(ob => ob.created).ToArray();
                    break;
            }
            return View(recompensasResponse);
        }

        public async Task<IActionResult> RecompensasDos()
        {
            await DeserializeRecompensas(client, "");
            HttpContext.Session.SetJson("RecompensasResponse", recompensasResponse);
            return View(recompensasResponse);
        }

        private async Task<System.IO.Stream> GetRecompensas_(HttpClient client, string path)
        {
            System.IO.Stream rc = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                rc = await response.Content.ReadAsStreamAsync();
            }
            return rc;
        }

        private async Task GetRecompensa(HttpClient client, string path)
        {            
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                strRecompensas = await response.Content.ReadAsStringAsync();
                ViewBag.strRecompensas = strRecompensas;
            }
        }

        private async Task<List<RecompensasResponse>> GetRecompensas(HttpClient client, string path)
        {
            List<RecompensasResponse> lRecompensasResponse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                lRecompensasResponse = await response.Content.ReadAsAsync<List<RecompensasResponse>>();
            }

            return lRecompensasResponse;
        }

        private async Task DeserializeRecompensas(HttpClient client, string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string strRecompensasResponse = await response.Content.ReadAsStringAsync();
                recompensasResponse = JsonSerializer.Deserialize<RecompensasResponse>(strRecompensasResponse);
            }            
        }
    }
}

