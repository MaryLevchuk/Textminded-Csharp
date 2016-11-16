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
    public class RecipeTranslation
    {
        public string Id { get; set; }
        public string TranslationStatus { get; set; }
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


        public void GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content) as JArray;
            var firstRecipe = obj.First;
            this.Id = (string)firstRecipe.TranslationRecipe.Id;
            this.TranslationStatus = firstRecipe.TranslationRecipe.TranslationStatus;
            this.IngredientGroups = firstRecipe.TranslationRecipe.IngredientGroups;
            this.ShortName = firstRecipe.TranslationRecipe.ShortName;
            this.LongName = firstRecipe.TranslationRecipe.LongName;
            this.ShortPreamble = firstRecipe.TranslationRecipe.ShortPreamble;
            this.Tags = firstRecipe.TranslationRecipe.Tags;
            this.InstructionSections = firstRecipe.TranslationRecipe.InstructionSections;
            this.NutritionSpecifiedPer = firstRecipe.TranslationRecipe.NutritionSpecifiedPer;
            this.AmountInformation = firstRecipe.TranslationRecipe.AmountInformation;
            this.RecommendedText = firstRecipe.TranslationRecipe.RecommendedText;
            this.Tips = firstRecipe.TranslationRecipe.Tips;
            this.TasteSignature = firstRecipe.TranslationRecipe.TasteSignature;
            
        }

        //public RecipeTranslation(IRestResponse tr)
        //{
        //    dynamic obj = JsonConvert.DeserializeObject(tr.Content) as JArray;
        //    var firstRecipe = obj.First;
        //    this.Id = (string)firstRecipe.TranslationRecipe.Id;
        //    this.TranslationStatus = firstRecipe.TranslationRecipe.TranslationStatus;
        //    this.IngredientGroups = firstRecipe.TranslationRecipe.IngredientGroups;
        //    this.ShortName = firstRecipe.TranslationRecipe.ShortName;
        //    this.LongName = firstRecipe.TranslationRecipe.LongName;
        //    this.ShortPreamble = firstRecipe.TranslationRecipe.ShortPreamble;
        //    this.Tags = firstRecipe.TranslationRecipe.Tags;
        //    this.InstructionSections = firstRecipe.TranslationRecipe.InstructionSections;
        //    this.NutritionSpecifiedPer = firstRecipe.TranslationRecipe.NutritionSpecifiedPer;
        //    this.AmountInformation = firstRecipe.TranslationRecipe.AmountInformation;
        //    this.RecommendedText = firstRecipe.TranslationRecipe.RecommendedText;
        //    this.Tips = firstRecipe.TranslationRecipe.Tips;
        //    this.TasteSignature = firstRecipe.TranslationRecipe.TasteSignature;
        //}

        //public void UpdateField(string translationField, string value)
        //{
        //    translationField = value;
        //}

    }
}
