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
    public class ClientRequest
    {
        public IRestClient Client = new RestClient(Constants.Domain);
        public IRestRequest Request = new RestRequest();

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

        //public Request Post(string url, string body)
        //{
        //    var request = new Request(url, Method.POST);
        //    request.SetParameters(body);
        //    return request;
        //}

        //public void SetHeaders()
        //{
        //    Request.AddHeader("auth-apikey", Constants.AuthApikey);
        //    Request.AddHeader("Accept", "application/json");
        //}

        public void SetParameters(string content)
        {
            Request.Parameters.Clear();
            Request.AddParameter("application/json", content, ParameterType.RequestBody);
        }

        public IRestResponse GetAllRecipes()
        {
            var request = Get(Constants.RecipeUrl);
            IRestResponse response = Client.Execute(request);
            
            //IRestResponse response = Client.Execute(Get(Constants.RecipeUrl));
            return response;
        }
    }
}
