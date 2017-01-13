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
        public IngredientTranslation ITranslation;

        public IngredientRequest()
        {
            var response = GetAllIngredientsToTranslate();
            ITranslation = GetDataFromResponse(response);
        }

        //public string SetRequestBody(IRestRequest r)
        //{
        //    Translation.LongName = "updated";
        //    string jsonString = JsonConvert.SerializeObject(Translation);
        //    return jsonString;
        //}

        public IRestResponse GetAllIngredientsToTranslate()
        {
            IRestRequest request = new RestRequest("foodservice-fi/translation/ingredient", Method.GET);
            SetHeaders(request);
            var response = Client.Execute<List<string>>(request);
            return response;
        }

        public IRestResponse GetIngredientToTranslateById()
        {
            string url = "foodservice-fi/translation/ingredient/" + ITranslation.Id;
            //Console.WriteLine(url);
            IRestRequest request = new RestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute(request);
            return response;
        }

        public string SetRequestBody(IRestRequest r)
        {
            ITranslation.NamePlural = "updated";
            string jsonString = JsonConvert.SerializeObject(ITranslation);
            return jsonString;
        }

        public IRestResponse UpdateIngredient()
        {
            string url = "foodservice-fi/translation/ingredient/" + ITranslation.Id;
            IRestRequest request = new RestRequest(url, Method.POST);

            string strJsonContent = SetRequestBody(request);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("auth-apikey", ConfigurationManager.AppSettings["auth-apikey"]);

            request.Parameters.Clear();
            request.AddParameter("application/json", strJsonContent, ParameterType.RequestBody);

            var response = Client.Execute(request);
            return response;
        }
    }
}
