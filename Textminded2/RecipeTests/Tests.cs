using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using FluentAssertions;
using NUnit.Framework;

namespace RecipeTests
{
    public class Tests
    {
        ClientRequest Request = new ClientRequest();
        public Tests()
        {
            
        }

        [Test]
        public void GetAllRecipeTranslations()
        {
            var response = Request.GetAllRecipes();
            var responseCode = (int) response.StatusCode;
            responseCode.Should().Be(200);
        }
    }
}
