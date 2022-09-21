using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.GenericRepositoryP;
using AntechLicense.Models;
using AntechLicense.DBFactory;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AntechLicense.ManagementDomain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AntechLicense.NonGenericRepositoryP
{
    public class CocktailRepositoryP<T> : GenericRepositoryP<T>, ICocktailRepositoryP<T> where T : class
    {        
        private DbSet<E_drink> _dbSetDrink;
        private DbSet<E_FavouritesDrink> _dbSetFavouriteDrink;

        protected DbSet<E_drink> DbSetDrink
        {
            get => _dbSetDrink ?? (_dbSetDrink = dbFactoryContext.DbContext.Set<E_drink>());
        }
        protected DbSet<E_FavouritesDrink> DbSetFavouriteDrink
        {
            get => _dbSetFavouriteDrink ?? (_dbSetFavouriteDrink = dbFactoryContext.DbContext.Set<E_FavouritesDrink>());
        }
        public CocktailRepositoryP(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {     
        }       
        public async Task<T> GetDrink(int Id)
        {
            T ObjdrinkDBs;
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + Id.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                                                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                                                        );
                ObjdrinkDBs = (await DeserializeCocktail(client, "")).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjdrinkDBs;
        }
        public async Task<List<T>> GetDrinks()
        {
            List<T> ldrinkDBs = new List<T>();
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                                                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                                                        );
                ldrinkDBs = await DeserializeCocktail(client, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ldrinkDBs;
        }

        public async Task<List<T>> GetDrinks(string TipoBusqueda, string ValorBusqueda)
        {
            List<T> ldrinkDBs = new List<T>();
            if (TipoBusqueda != null)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    string sUri = "";

                    if (ValorBusqueda == null)
                        ValorBusqueda = "";
                    //ValorBusqueda = ValorBusqueda.Trim().Length <= 0 ? "" : ValorBusqueda;

                    switch (TipoBusqueda.Trim())
                    {
                        case "Ingrediente":
                            sUri = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ValorBusqueda.Trim();
                            break;

                        case "NombreCocktail":
                            sUri = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=" + ValorBusqueda.Trim();
                            break;
                    }

                    client.BaseAddress = new Uri(sUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                                                                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                                                            );
                    ldrinkDBs = await DeserializeCocktail(client, "");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ldrinkDBs;
        }

        private async Task<List<T>> DeserializeCocktail(HttpClient client, string path)
        {
            List<T> ldrinkDBs = new List<T>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string strCocktailResponse = await response.Content.ReadAsStringAsync();

                    if (strCocktailResponse.Trim().Length > 0)
                    {
                        Newtonsoft.Json.Linq.JObject jsonCocktailResponse = Newtonsoft.Json.Linq.JObject.Parse(strCocktailResponse);
                        JArray JDrinksArray = jsonCocktailResponse["drinks"].Value<Newtonsoft.Json.Linq.JArray>();
                        if(JDrinksArray != null)
                            ldrinkDBs = JDrinksArray.ToObject<List<T>>();
                    }                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return ldrinkDBs;
        }
        private async Task<T> DeserializeCocktailObj(HttpClient client, string path)
        {
            object ObjdrinkDBs = new object();
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string strCocktailResponse = await response.Content.ReadAsStringAsync();

                    if (strCocktailResponse.Trim().Length > 0)
                    {
                        Newtonsoft.Json.Linq.JObject jsonCocktailResponse = Newtonsoft.Json.Linq.JObject.Parse(strCocktailResponse);
                        JArray JDrinksArray = jsonCocktailResponse["drinks"].Value<Newtonsoft.Json.Linq.JArray>();
                        if (JDrinksArray != null)
                            ObjdrinkDBs = JDrinksArray.ToObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (T)ObjdrinkDBs;
        }
        public bool AddDrink(E_drink drink)
        {
            bool bValueReturn = false;
            try
            {                
                E_drink ObjDrink = DbSetDrink.Where(f=> f.IdDrink == drink.IdDrink).FirstOrDefault();
                if (ObjDrink == null)
                {                    
                    this.Add((T)Convert.ChangeType(drink, typeof(T)));
                    bValueReturn = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return bValueReturn;
        }
        public bool AddFavouriteDrink(E_FavouritesDrink FavouriteDrink)
        {
            bool bValueReturn = false;
            try
            {
                E_FavouritesDrink ObjFDrink = DbSetFavouriteDrink
                                            .Where(f => f.F_IdDrink == FavouriteDrink.F_IdDrink &&
                                                        f.NameUsuario == FavouriteDrink.NameUsuario).FirstOrDefault();
                if (ObjFDrink == null)
                {
                    this.Add((T)Convert.ChangeType(FavouriteDrink, typeof(T)));
                    bValueReturn = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return bValueReturn;
        }
        public List<E_drink> GetFavouritesDrinks(string NameUsuario)
        {
            List<E_drink> lDrinks = new List<E_drink>();
            try
            {
                List<E_FavouritesDrink> lFDrinks = DbSetFavouriteDrink.Where(f=> f.NameUsuario == NameUsuario).ToList();
                lDrinks = DbSetDrink.Where(f=> lFDrinks.Select(s=> s.F_IdDrink).Contains(f.IdDrink)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lDrinks;
        }

        public bool DeleteFavouriteDrink(int Id)
        {
            bool bValueReturn = false;
            try
            {
                DbSetFavouriteDrink.Remove(DbSetFavouriteDrink
                                            .Where(f => f.F_IdDrink == Id && f.NameUsuario == "Guess").FirstOrDefault());
                
                bValueReturn = true;
            }
            catch (Exception)
            {

                throw;
            }
            return bValueReturn;
        }
    }
}
