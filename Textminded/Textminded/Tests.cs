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
        [Test]
        
        public void Get_AllRecipesToTranslate_ReturnsStatusOK()
        {
            var response = GetAllRecipesToTranslate();
            int code = (int) response.StatusCode;
            code.Should().Be(200);
        }

        [Test]
        
        public void Get_RecipeToTranslateById_ReturnsStatusOK()
        {
            var response = GetRecipeToTranslateById();
            int code = (int) response.StatusCode;
            code.Should().Be(200);
        }

        [Test]
        public void Update_RecipeTranslation()
        {
            var response = UpdateRecipe();
            Console.WriteLine("response = {0}", response.Content);
            int code = (int)response.StatusCode;
            code.Should().BeGreaterOrEqualTo(200);
        }

    }
}

