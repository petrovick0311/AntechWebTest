using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public class RecompensasListViewModel
    {
        public List<RecompensasResponse> lRecompensas { get; set; }
    }
    public class RecompensasResponse
    {
        public Boolean success { get; set; }
        public string message { get; set; }
        public RecompensasData[] data { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public Boolean hasPrevPage { get; set; }
        public Boolean hasNextPage { get; set; }
    }

    public class RecompensasData
    {
        public long created { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public Lugares[]? venues { get; set; }
        public string quickType { get; set; }
        public decimal cashback_decimal { get; set; }
        public string dv_name { get; set; }
        public string expires { get; set; }
        public string dv_cashback { get; set; }
        public string media { get; set; }
        public string dv_category { get; set; }
        public string raw_category { get; set; }
        public string dv_address { get; set; }
        public double[]? dv_latlng { get; set; }
        public int price_level { get; set; }
        public decimal rating { get; set; }
        public int popularity { get; set; }
    }

    public class Lugares
    {
        public string _id { get; set; }        
        public Direcciones address { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        
    }
    public class Direcciones
    {
        public string _id { get; set; }
        public string zipcode { get; set; }
        public Localizacion location { get; set; }
        public string street_address { get; set; }                
    }
    public class Localizacion
    {
        public string type { get; set; }        
        public decimal[]? coordinates { get; set; }
    }
    public class Coordenadas
    {
        public long Latitud { get; set; }
        public long Longitud { get; set; }
    }
}
