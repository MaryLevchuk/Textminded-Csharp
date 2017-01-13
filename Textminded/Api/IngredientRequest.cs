using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Api.Models;
using Newtonsoft.Json;

namespace Api
{
    public class IngredientRequest : Request<IngredientTranslation>
    {
       public IngredientTranslation Translation;

        public IngredientRequest()
        {
            var response = GetIngredientToTranslateById(Constants.TestIngredientId);
            Translation = GetDataFromResponse(response);
        }

        public IRestResponse GetAllIngredientsToTranslate()
        {
            IRestRequest request = new RestRequest(Constants.IngredientUrl, Method.GET);
            SetHeaders(request);
            var response = Client.Execute<List<string>>(request);
            return response;
        }

        public IRestResponse GetIngredientToTranslateById(object id)
        {
            string url = Constants.IngredientUrl + Constants.TestIngredientId;
            IRestRequest request = new RestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute(request);
            return response;
        }

        public IRestResponse UpdateIngredient(string fieldName, object value)
        {
            string url = Constants.IngredientUrl + Translation.Id;
            IRestRequest request = new RestRequest(url, Method.POST);
            var updatedTranslationJson = UpdateTranslationJson(fieldName, value);
            string strJsonContent = SetRequestBody(updatedTranslationJson);

            //Console.WriteLine("strJsonContent = {0}", strJsonContent);

            SetHeaders(request);
            SetParameters(request, strJsonContent);

            var response = Client.Execute(request);
            return response;
        }

        public IngredientTranslation UpdateTranslationJson(string fieldName, object value)
        {
            Translation.GetType().GetProperty(fieldName).SetValue(Translation, value, null);
            return Translation;
        }
    }
}
