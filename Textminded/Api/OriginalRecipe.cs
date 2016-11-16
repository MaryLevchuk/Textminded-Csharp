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

        public OriginalRecipe(IRestResponse or)
        {
            dynamic obj = JsonConvert.DeserializeObject(or.Content) as JArray;
            var firstRecipe = obj.First;
            this.IngredientGroups = firstRecipe.OriginalRecipe.IngredientGroups;
            this.ShortName = firstRecipe.OriginalRecipe.ShortName;
            this.LongName = firstRecipe.OriginalRecipe.LongName;
            this.ShortPreamble = firstRecipe.OriginalRecipe.ShortPreamble;
            this.Tags = firstRecipe.OriginalRecipe.Tags;
            this.InstructionSections = firstRecipe.OriginalRecipe.InstructionSections;
            this.NutritionSpecifiedPer = firstRecipe.OriginalRecipe.NutritionSpecifiedPer;
            this.AmountInformation = firstRecipe.OriginalRecipe.AmountInformation;
            this.RecommendedText = firstRecipe.OriginalRecipe.RecommendedText;
            this.Tips = firstRecipe.OriginalRecipe.Tips;
            this.TasteSignature = firstRecipe.OriginalRecipe.TasteSignature;
            this.OriginalLanguage = firstRecipe.OriginalLanguage;
            this.TranslationLanguage = firstRecipe.TranslationLanguage;
        }
    }
}
