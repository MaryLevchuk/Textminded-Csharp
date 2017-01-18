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
using RestSharp.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;


namespace Api
{
    public class RecipeRequest : Request<RecipeTranslationObject>
    {
       public RecipeTranslation Translation;
       
        public RecipeRequest()
        {
       
            var response = GetRecipeToTranslateById(Constants.TestRecipeId);
            Translation = GetDataFromResponse(response)?.TranslationRecipe;
        }

        public IRestRequest CreateRestRequest(string url, Method method)
        {
            return new RestRequest(url, method)
            {
                JsonSerializer = new NewtonsoftJsonSerializer()
            };
        }

        public IRestResponse GetAllRecipesToTranslate()
        {
            string url = "foodservice-fi/translation/recipe";
            IRestRequest request = CreateRestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute<List<string>>(request);
            return response;
        }

        public IRestResponse GetRecipeToTranslateById(object id)
        {
            string url = "foodservice-fi/translation/recipe/" + id.ToString();
            IRestRequest request = CreateRestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute(request);
            return response;
        }

        public IRestResponse UpdateRecipe(string fieldName, object value)
        {
            string url = "foodservice-fi/translation/recipe/" + Translation.Id;
            IRestRequest request = CreateRestRequest(url, Method.POST);
            var updatedTranslationJson = UpdateTranslationJson(fieldName, value);
            string strJsonContent = SetRequestBody(updatedTranslationJson);

            SetHeaders(request);
            SetParameters(request, strJsonContent);

            var response = Client.Execute(request);
            return response;
        }

        public RecipeTranslationObject UpdateTranslationJson(string fieldName, object value)
        {
            Translation.GetType().GetProperty(fieldName).SetValue(Translation, value, null);
            return new RecipeTranslationObject
            {
                TranslationRecipe = Translation
            };
        }
    }
}
