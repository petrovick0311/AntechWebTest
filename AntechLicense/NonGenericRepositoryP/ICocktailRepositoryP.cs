using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.GenericRepositoryP;
using AntechLicense.Models;
using AntechLicense.DBFactory;

namespace AntechLicense.NonGenericRepositoryP
{
    public interface ICocktailRepositoryP<T> : IGenericRepositoryP<T> where T : class
    {        
        Task<T> GetDrink(int Id);
        Task<List<T>> GetDrinks();
        Task<List<T>> GetDrinks(string TipoBusqueda, string ValorBusqueda);
        bool AddDrink(E_drink drinks);
        bool AddFavouriteDrink(E_FavouritesDrink FavouriteDrink);
        List<E_drink> GetFavouritesDrinks(string NameUsuario);
        bool DeleteFavouriteDrink(int Id);
    }
}
