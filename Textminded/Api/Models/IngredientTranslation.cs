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
        public string Id { get; set; }
        public string NameSingular { get; set; }
        public string NamePlural { get; set; }
        public JArray Tags { get; set; }

        public IngredientTranslation GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content) as JArray;
            string firstRecipe = obj.First.TranslationIngredient.ToString();
            IngredientTranslation translation = JsonConvert.DeserializeObject<IngredientTranslation>(firstRecipe);
            return translation;
        }

    }
    
}

