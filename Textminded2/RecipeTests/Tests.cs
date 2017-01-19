using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Api;
using Api.Models;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace RecipeTests
{
    public class Tests
    {
        ClientRequest Request = new ClientRequest();
        public Tests()
        {
            
        }

        [Test]
        public void GetAllTranslations()
        {
            var response = Request.GetAllRecipes();
            var responseCode = (int) response.StatusCode;
            responseCode.Should().Be(200);
        }

        [Test]
        public void GetTranslationById()
        {
            var response = Request.GetTranslationById(Constants.TestRecipeId);
            var responseCode = (int) response.StatusCode;
            responseCode.Should().Be(200);
        }

        [Test]
        public void UpdateTranslationById()
        {
            var response = Request.GetTranslationById(Constants.TestRecipeId);
            var updatedJson = UpdateTranslation(fieldname, value);
            response = Send(updatedJson);
            var responseCode = (int)response.StatusCode;
            responseCode.Should().Be(200);
        }

       
    }
}
