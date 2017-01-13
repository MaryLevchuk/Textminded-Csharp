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
    public class RecipeTranslation 
    {
        public object Id { get; set; }
        public object TranslationStatus { get; set; }
        public object IngredientGroups { get; set; }
        public object ShortName { get; set; }
        public object LongName { get; set; }
        public object ShortPreamble { get; set; }
        public object Tags { get; set; }
        public object InstructionSections { get; set; }
        public object NutritionSpecifiedPer { get; set; }
        public object AmountInformation { get; set; }
        public object RecommendedText { get; set; }
        public object Tips { get; set; }
        public object TasteSignature { get; set; }


        public RecipeTranslation GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content);
            string tr = obj.TranslationRecipe.ToString();
            RecipeTranslation translation = JsonConvert.DeserializeObject<RecipeTranslation>(tr);
            return translation;
        }

    }
}

