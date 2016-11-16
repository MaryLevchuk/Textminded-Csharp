using System;
using Api;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Textminded
{
    public class Tests : Api.Requests
    {
        public RecipeTranslation Translation = new RecipeTranslation();

        public Tests()
        {
            var response = GetAllRecipesToTranslate();
            RecipeTranslation.GetDataFromResponse(response);
        }



        [Test]
        [Ignore]
        public void Get_AllRecipesToTranslate_ReturnsStatusOK()
        {
            var response = GetAllRecipesToTranslate();
            int code = (int) response.StatusCode;
            code.Should().Be(200);
        }

        [Test]
        [Ignore]
        public void Get_RecipeToTranslateById_ReturnsStatusOK()
        {
            var response = GetRecipeToTranslateById(Translation.Id);
            int code = (int) response.StatusCode;
            code.Should().Be(200);
        }

       
        [Test]
        public void Update_RecipeTranslation()
        {
            UpdateRecipe(Translation.Id)
            ;
        }

    }
}

