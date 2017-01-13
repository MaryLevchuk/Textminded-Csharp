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

        //public RecipeTranslationTests()
        //{
        //    Translation = rRequest.Translation;
        //    Console.WriteLine();
        //}

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
        [TestCase("TranslationStatus", 3, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", -1, Result = 200, Category = "neg")]
        [TestCase("TranslationStatus", 10, Result = 200, Category = "neg")]
        [TestCase("ShortName", "Test recipe. Updated", Result = 200, Category = "pos")]
        [TestCase("LongName", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("ShortPreamble", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("Tags", "abracadabra", Result = 200, Category = "pos")]
        [TestCase("LongName", 123, Result = 200)]
        [TestCase("LongName", null, Result = 200)]
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


