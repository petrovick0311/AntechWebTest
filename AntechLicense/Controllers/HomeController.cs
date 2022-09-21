using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AntechLicense.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net;
using AntechLicense.Infraestructure;
using Newtonsoft.Json.Linq;
using AntechLicense.UnitOfWork;
using AntechLicense.NonGenericRepositoryP;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace AntechLicense.Controllers
{
    public class HomeController : Controller
    {   
        private Func<DataContext> instanceDataContext;
        private UnitOfWork.UnitOfWork unitOfWork;
        private GenericRepositoryP.GenericRepositoryP<E_drink> genericRepositoryDrink;

        private ICocktailRepositoryP<E_drink> dCocktailRepositoryP;
        private ICocktailRepositoryP<E_FavouritesDrink> fCocktailRepositoryP;

        public CocktailDB cocktailDB = new CocktailDB();        

        public HomeController(DataContext dataContext)
        {
            instanceDataContext = delegate ()
            {
                return new DataContext();
            };
            //unitOfWork = new UnitOfWork.UnitOfWork(instanceDataContext);

            unitOfWork = new UnitOfWork.UnitOfWork(dataContext);
            dCocktailRepositoryP = new CocktailRepositoryP<E_drink>(unitOfWork);
            fCocktailRepositoryP = new CocktailRepositoryP<E_FavouritesDrink>(unitOfWork);
        }

        public RedirectToActionResult Index() 
        {
            return RedirectToAction("Cocktail");
        }

        public ViewResult Inicio()
        {   
            return View();
        }
        
        public async Task<IActionResult> Cocktail()
        {
            ViewBag.ShowAlert = "";
            cocktailDB.ldrinks = await dCocktailRepositoryP.GetDrinks();
            HttpContext.Session.SetJson("CocktailResponse", cocktailDB.ldrinks);
            return View(cocktailDB);
        }

        public async Task<IActionResult> CocktailDetail(int Id)
        {
            cocktailDB.ldrinks = new List<E_drink>();
            if (Id > 0)
            {
                cocktailDB.ldrinks.Add(await dCocktailRepositoryP.GetDrink(Id));
                cocktailDB.lIngredientsdrink = new List<IngredientDrink>();
                E_drink ObjDrink = cocktailDB.ldrinks.Find(f => f.IdDrink == Id);
                PropertyInfo[] info = typeof(E_drink).GetProperties();

                if (ObjDrink != null)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        IngredientDrink IDObj = new IngredientDrink();

                        IDObj.IdDrink = Convert.ToInt32(info.First(f => f.Name.Trim() == "IdDrink").GetValue(ObjDrink));

                        string sIngrediente = (info.First(f => f.Name.Trim() == ("strIngredient" + (i + 1).ToString())
                                        ).GetValue(ObjDrink))?.ToString() ?? "";
                        if (sIngrediente.Trim().Length > 0)
                            IDObj.strIngrediente = sIngrediente;
                        else
                            IDObj.strIngrediente = "";

                        string sMedida = info.First(f => f.Name.Trim() == ("strMeasure" + (i + 1).ToString())
                                        ).GetValue(ObjDrink)?.ToString() ?? "";
                        if (sMedida.Trim().Length > 0)
                            IDObj.strMedida = sMedida;
                        else
                            IDObj.strMedida = "";

                        if (IDObj.strIngrediente.Trim().Length > 0)
                        {
                            IDObj.strURLImage = "https://www.thecocktaildb.com/images/ingredients/" + IDObj.strIngrediente + "-Small.png";

                            cocktailDB.lIngredientsdrink.Add(IDObj);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return View("CocktailDetail", cocktailDB);
        }
                
        public async Task<IActionResult> AddFavourite(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    unitOfWork.CreateTransaction();

                    if (ModelState.IsValid)
                    {
                        cocktailDB.ldrinks = new List<E_drink>();
                        cocktailDB.ldrinks.Add(await dCocktailRepositoryP.GetDrink(Id));
                        E_drink ObjDrink = cocktailDB.ldrinks.Find(f => f.IdDrink == Id);
                        if (ObjDrink != null)
                        {

                            // Campos de auditoria
                            ObjDrink.CreatedBy = "Guess";
                            ObjDrink.CreatedDate = DateTime.Now;

                            // Alta bebida, para ir generando catalogo de bebidas en BD solo de favoritos
                            dCocktailRepositoryP.AddDrink(ObjDrink);
                            unitOfWork.SaveTransaction();

                            #region Favoritos
                            E_FavouritesDrink ObjFavouriteDrink = new E_FavouritesDrink();
                            // Campos de auditoria
                            ObjFavouriteDrink.CreatedBy = ObjDrink.CreatedBy;
                            ObjFavouriteDrink.CreatedDate = ObjDrink.CreatedDate;
                            ObjFavouriteDrink.NameUsuario = ObjFavouriteDrink.CreatedBy;
                            ObjFavouriteDrink.F_IdDrink = ObjDrink.IdDrink;

                            // Alta de favoritos
                            fCocktailRepositoryP.AddFavouriteDrink(ObjFavouriteDrink);
                            unitOfWork.SaveTransaction();
                            #endregion
                            
                            unitOfWork.CommitTransaction();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                unitOfWork.RollBackTransaction();
            }

            ViewBag.ShowAlert = "";
            cocktailDB.ldrinks = await dCocktailRepositoryP.GetDrinks();
            HttpContext.Session.SetJson("CocktailResponse", cocktailDB.ldrinks);            
            return View("Cocktail", cocktailDB);
        }

        public ViewResult Favourites()
        {
            try
            {
                cocktailDB.ldrinks =  dCocktailRepositoryP.GetFavouritesDrinks("Guess");                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return View("Favourites", cocktailDB);
        }

        public ViewResult DeleteFavourite(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    unitOfWork.CreateTransaction();

                    dCocktailRepositoryP.DeleteFavouriteDrink(Id);

                    unitOfWork.SaveTransaction();
                    unitOfWork.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                unitOfWork.RollBackTransaction();
            }

            cocktailDB.ldrinks = dCocktailRepositoryP.GetFavouritesDrinks("Guess");
            return View("Favourites", cocktailDB);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string Buscar, string TipoBusqueda)
        {
            ViewBag.ShowAlert = Buscar + "-" + TipoBusqueda;
            cocktailDB.ldrinks = new List<E_drink>();
            cocktailDB.ldrinks = await dCocktailRepositoryP.GetDrinks(TipoBusqueda, Buscar);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("CocktailResponse");
            HttpContext.Session.SetJson("CocktailResponse", cocktailDB.ldrinks);
            return View("Cocktail", cocktailDB);
        }
    }
}

