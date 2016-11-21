using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Api
{
    public class Request
    {
        public IRestClient Client = new RestClient("http://api.testrdb.arla.com");

        public void SetHeaders(IRestRequest r)
        {
            r.AddHeader("auth-apikey", ConfigurationManager.AppSettings["auth-apikey"]);
            r.AddHeader("Content-Type", "application/json");
        }

        public dynamic GetDataFromResponse(IRestResponse r)
        {
            dynamic obj = JsonConvert.DeserializeObject(r.Content) as JArray;
            //string firstRecipe = obj.First.TranslationRecipe.ToString();
            //RecipeTranslation translation = JsonConvert.DeserializeObject<RecipeTranslation>(firstRecipe);
            return obj;
        }
    }
}
