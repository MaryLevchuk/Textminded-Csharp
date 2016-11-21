using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api
{
    public class OriginalRecipe
    {
        
        public JArray IngredientGroups { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string ShortPreamble { get; set; }
        public JArray Tags { get; set; }
        public JArray InstructionSections { get; set; }
        public string NutritionSpecifiedPer { get; set; }
        public string AmountInformation { get; set; }
        public string RecommendedText { get; set; }
        public JArray Tips { get; set; }
        public string TasteSignature { get; set; }
        public string OriginalLanguage { get; }
        public string TranslationLanguage { get; }
       
    }
}
