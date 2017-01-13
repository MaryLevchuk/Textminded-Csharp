using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;
using FluentAssertions;
using NUnit.Framework;

namespace Textminded
{
    class IngredientTranslationTests
    {
        IngredientRequest rRequest = new IngredientRequest();

        [Test]
        public void GetAllIngredientsToTranslate_ReturnStatusOK()
        {
            var response = rRequest.GetAllIngredientsToTranslate();
            int code = (int)response.StatusCode;
            code.Should().Be(200);
        }

        [TestCase(304997926, Result = 200, Category = "neg")]
        [TestCase(30499792660, Result = 200, Category = "neg")]
        [TestCase("abc", Result = 200, Category = "neg")]
        public int GetIngredientToTranslateById(object id)
        {
            var response = rRequest.GetIngredientToTranslateById(id);
            int code = (int)response.StatusCode;
            return code;
        }
    }
}
