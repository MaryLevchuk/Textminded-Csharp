using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api.Models
{
    public class IngredientTranslation
    {
        public object Id { get; set; }
        public object NameSingular { get; set; }
        public object NamePlural { get; set; }
        public object Tags { get; set; }

        public IngredientTranslation GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content);
            string tr = obj.TranslationIngredient.ToString();
            IngredientTranslation translation = JsonConvert.DeserializeObject<IngredientTranslation>(tr);
            return translation;
        }

    }
    
}

