using System;
using System.Configuration;
using System.Net;
using Api;
using Api.Models;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Textminded
{
    public class RecipeTranslationTests
    {
        RecipeRequest rRequest = new RecipeRequest();
        public RecipeTranslation Translation;
        
        [Test]
        public void GetAllRecipesToTranslate_ReturnsStatusOK()
        {
            var response = rRequest.GetAllRecipesToTranslate();
            int code = (int) response.StatusCode;
            code.Should().Be(200);
        }

        [TestCase(163866383, Result = 200, Category = "neg")]
        [TestCase(16386638330, Result = 200, Category = "neg")]
        [TestCase("abc", Result = 200, Category = "neg")]
        public int GetRecipeTranslationById_ReturnsStatusOK(object id)
        {
            var response = rRequest.GetRecipeToTranslateById(id);
            int code = (int)response.StatusCode;
            return code;
        }

        [TestCase("TranslationStatus", 0, Result = 200, Category = "pos")]
        [TestCase("TranslationStatus", null, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", 3, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", -1, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", 10, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", "øæå", Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", "", Result = 200, Category = "neg")]

        [TestCase("ShortName", "Test recipe. Updated", Result = 200, Category = "pos")]
        [TestCase("ShortName", "", Result = 200, Category = "pos")]
        [TestCase("ShortName", 1000, Result = 200, Category = "neg")]
        [TestCase("ShortName", null, Result = 200, Category = "neg")]

        [TestCase("LongName", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("LongName", "", Result = 200, Category = "pos")]
        [TestCase("LongName", 10000000, Result = 200, Category = "neg")]
        [TestCase("LongName", null, Result = 200, Category = "neg")]

        [TestCase("ShortPreamble", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("ShortPreamble", "", Result = 200, Category = "pos")]
        [TestCase("ShortPreamble", 100, Result = 200, Category = "neg")]
        [TestCase("ShortPreamble", null, Result = 200, Category = "neg")]

        [TestCase("Tags", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("Tags", "", Result = 200, Category = "neg")]
        [TestCase("Tags", null, Result = 200, Category = "neg")]

        [TestCase("IngredientGroups", "Group1", Result = 200, Category = "pos")]
        [TestCase("IngredientGroups", "", Result = 200, Category = "pos")]
        [TestCase("IngredientGroups", 10000000, Result = 200, Category = "neg")]
        [TestCase("IngredientGroups", null, Result = 200, Category = "neg")]

        [TestCase("InstructionSections", "InstructionSection1", Result = 200, Category = "pos")]
        [TestCase("InstructionSections", "", Result = 200, Category = "pos")]
        [TestCase("InstructionSections", 10000000, Result = 200, Category = "neg")]
        [TestCase("InstructionSections", null, Result = 200, Category = "neg")]

        [TestCase("NutritionSpecifiedPer", 100, Result = 200, Category = "pos")]
        [TestCase("NutritionSpecifiedPer", "NutritionSpecifiedPer 100g", Result = 200, Category = "neg")]
        [TestCase("NutritionSpecifiedPer", "", Result = 200, Category = "pos")]
        [TestCase("NutritionSpecifiedPer", null, Result = 200, Category = "neg")]

        [TestCase("AmountInformation", 1000, Result = 200, Category = "pos")]
        [TestCase("AmountInformation", "Amount Info", Result = 200, Category = "neg")]
        [TestCase("AmountInformation", "", Result = 200, Category = "neg")]
        [TestCase("AmountInformation", null, Result = 200, Category = "neg")]

        [TestCase("RecommendedText", "Lorem ipsum dolor sit amet, ea qui libris animal tamquam. Cu nostrud propriae nec. Explicari vulputate te vix. Pro in aliquip denique complectitur, ad eum causae philosophia.", Result = 200, Category = "pos")]
        [TestCase("RecommendedText", "", Result = 200, Category = "pos")]
        [TestCase("RecommendedText", 10000000, Result = 200, Category = "neg")]
        [TestCase("RecommendedText", null, Result = 200, Category = "neg")]

        [TestCase("Tips", "Tip 1", Result = 200, Category = "pos")]
        [TestCase("Tips", "", Result = 200, Category = "pos")]
        [TestCase("Tips", 10000000, Result = 200, Category = "neg")]
        [TestCase("Tips", null, Result = 200, Category = "neg")]

        [TestCase("TasteSignature", "Sweet", Result = 200, Category = "pos")]
        [TestCase("TasteSignature", "", Result = 200, Category = "pos")]
        [TestCase("TasteSignature", 10000000, Result = 200, Category = "neg")]
        [TestCase("TasteSignature", null, Result = 200, Category = "neg")]

        public int Update_RecipeTranslation_ReturnsStatusOK(string fieldName, object value)
        {
            var response = rRequest.UpdateRecipe(fieldName, value);
            int code = (int)response.StatusCode;
            return code;
        }



        //    [Test]
        //        public void Update_RecipeTranslation_WithNullInLongName_ReturnsStatusOK()
        //        {
        ////             Action<RecipeRequest> lambdaSample = r => { r.Translation.LongName = null; };

        //            //var response = rRequest.UpdateRecipe("LongName", (string) null);
        //            //int code = (int)response.StatusCode;
        //            //code.Should().Be(200);
        //        }
        //    }

        //public class LessonTests
        //{
        //    [TestCase("1638663833")]
        //    public void GetRecipeById_Works(string id)
        //    {
        //        var client = new RecipeApiClient();
        //        //var response = client.Get<JArray>($"foodservice-fi/translation/recipe/{id}");
        //        var response = client.Get<JArray>("foodservice-fi/translation/recipe");
        //        response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    }

        //    [Test]
        //    public void Get_RecipeToTranslateById_WithCorrectId_ReturnsRecipe()
        //    {
        //        var client = new RecipeApiClient("http://api.testrdb.arla.com");
        //        var result = client.GetRecipeToTranslateById("1638663833");
        //        result.Should().NotBeNullOrWhiteSpace();
        //    }
        //}
    }
}


