using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Reflection;


namespace Api
{
    public class RecipeRequest : Request<RecipeTranslation>
    {
        public RecipeTranslation Translation;

        public RecipeRequest()
        {
            var response = GetRecipeToTranslateById(Constants.TestRecipeId);
            Translation = GetDataFromResponse(response);
        }

        public IRestResponse GetAllRecipesToTranslate()
        {
            IRestRequest request = new RestRequest("foodservice-fi/translation/recipe", Method.GET);
            SetHeaders(request);
            var response = Client.Execute<List<string>>(request);
            return response;
        }

        public IRestResponse GetRecipeToTranslateById(object id)
        {
            string url = "foodservice-fi/translation/recipe/" + id.ToString();
            IRestRequest request = new RestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute(request);
            return response;
        }

        public IRestResponse UpdateRecipe(string fieldName, object value)
        {
            string url = "foodservice-fi/translation/recipe/" + Translation.Id;
            IRestRequest request = new RestRequest(url, Method.POST);
            var updatedTranslationJson = UpdateTranslationJson(fieldName, value);
            string strJsonContent = SetRequestBody(updatedTranslationJson);

            Console.WriteLine("strJsonContent = {0}", strJsonContent);

            SetHeaders(request);
            SetParameters(request, strJsonContent);

            var response = Client.Execute(request);
            return response;
        }

        public RecipeTranslation UpdateTranslationJson(string fieldName, object value)
        {
            Translation.GetType().GetProperty(fieldName).SetValue(Translation, value, null);
            return Translation;
        }
    }
}
