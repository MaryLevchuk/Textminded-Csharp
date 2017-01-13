using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Api.Models
{
    public class Request<TData>
    {
        public IRestClient Client = new RestClient("http://api.testrdb.arla.com");

        public void SetHeaders(IRestRequest r)
        {
            r.AddHeader("auth-apikey", ConfigurationManager.AppSettings["auth-apikey"]);
            r.AddHeader("Accept", "application/json");
        }

        public void SetParameters(IRestRequest r, string content)
        {
            r.Parameters.Clear();
            r.AddParameter("application/json", content, ParameterType.RequestBody);
        }

        public TData GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content);
            string tr = obj.TranslationRecipe.ToString();
            TData translation = JsonConvert.DeserializeObject<TData>(tr);
            return translation;
        }

        public string SetRequestBody(RecipeTranslation t)
        {
            string jsonString = JsonConvert.SerializeObject(t);
            return jsonString;
        }
    }

    //public class RecipeApiClient
    //{
    //    protected RecipeApiConfiguration Config { get; }

    //    public RecipeApiClient()
    //        : this(new RecipeApiConfiguration())
    //    {}

    //    public RecipeApiClient(RecipeApiConfiguration config)
    //    {
    //        Config = config;
    //    }

    //    public RecipeApiClient(string baseApiUrl)
    //        : this(new RecipeApiConfiguration { BaseUrl = baseApiUrl })
    //    {}

        //public IRestResponse<T> Get<T>(string resource) where T : new()
        //{
        //    var client = new RestClient(Config.BaseUrl);
        //    var request = CreateRequest(resource);
        //    var response = client.Get<T>(request);
        //    return response;
        //}

    //    private static RestRequest CreateRequest(string resource)
    //    {
    //        var request = new RestRequest(resource);
    //        request.AddHeader("auth-apikey", ConfigurationManager.AppSettings["auth-apikey"]);
    //        request.AddHeader("Accept", "application/json");
    //        return request;
    //    }

    //    public string GetRecipeToTranslateById(string id)
    //    {
    //        var client = new RestClient(Config.BaseUrl);
    //        var request = CreateRequest($"foodservice-fi/translation/recipe/{id}");
    //        var response = client.Get(request);
    //        return response.Content;
    //    }
    //}

    //public class RecipeApiConfiguration
    //{
    //    public string BaseUrl { get; set; } = "http://api.testrdb.arla.com";
    //    public string ApiKey { get; set; } = ConfigurationManager.AppSettings["auth-apikey"];
    //}
}
