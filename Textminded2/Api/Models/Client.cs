using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Api.Models
{
    public class ClientRequest<TData>
    {
        public IRestClient Client = new RestClient(Constants.Domain);
        public IRestRequest Request = new RestRequest();
        public TData TranslationData;

        public ClientRequest()
        {
            Request.AddHeader("auth-apikey", Constants.AuthApikey);
            Request.AddHeader("Accept", "application/json");
        }

        public IRestRequest Get(string url)
        {
            Request.Resource = url;
            Request.Method = Method.GET;
            return Request;
        }

        public Request Post(string url, string body)
        {
            var request = new Request(url, Method.POST);
            SetParameters(body);
            return request;
        }

        public void SetParameters(string content)
        {
            Request.Parameters.Clear();
            Request.AddParameter("application/json", content, ParameterType.RequestBody);
        }

        public IRestResponse GetAllRecipes()
        {
            var request = Get(Constants.RecipeUrl);
            IRestResponse response = Client.Execute(request);
            
            return response;
        }

        public IRestResponse GetTranslationById(string id)
        {
            string url = Constants.RecipeUrl + id;
            var request = Get(url);
            IRestResponse response = Client.Execute(request);
            TranslationData = ConvertResponseToTranslationModel(response);
            return response;
        }

        public IRestResponse UpdateTranslation(string fieldname, object value)
        {
            TranslationData.GetType().GetProperty(fieldname).SetValue(TranslationData, value, null);
            string tdata = TranslationData.GetType().ToString();
            switch (tdata)
            {
                case "RecipeTranslation":
                {
                        return new RecipeTranslationObject
                        {
                            RecipeTranslation.TranslationRecipe = TranslationData
                        };
                    break;
                }
            }
            
        }

        private TData ConvertResponseToTranslationModel(IRestResponse response)
        {
            var model = JsonConvert.DeserializeObject<TData>(response.Content);
            return model;
        }
       
        private IRestResponse Send(object updatedJson)
        {
            throw new NotImplementedException();
        }
    }
}
