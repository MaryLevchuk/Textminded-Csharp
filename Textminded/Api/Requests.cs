﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace Api
{
    public abstract class Requests
    {
        public IRestClient Client = new RestClient("http://api.testrdb.arla.com");
        public RecipeTranslation Translation = new RecipeTranslation();

        protected Requests()
        {
            var r = GetAllRecipesToTranslate();
            Translation.GetDataFromResponse(r);
        }

        public void SetHeaders(IRestRequest r)
        {
            r.AddHeader("auth-apikey", ConfigurationManager.AppSettings["auth-apikey"]);
            r.AddHeader("Content-Type", "application/json");
        }

        public void SetRequestBody(IRestRequest r)
        {
            Translation.LongName = "updated";
            string jsonString = JsonConvert.SerializeObject(Translation);
            r.AddBody(jsonString);
        }

        public IRestResponse GetAllRecipesToTranslate()
        {
            IRestRequest request = new RestRequest("foodservice-fi/translation/recipe", Method.GET);
            SetHeaders(request);
            var response = Client.Execute<List<string>>(request);
            return response;
        }

       public IRestResponse GetRecipeToTranslateById(string recipeId)
        {
            string url = "foodservice-fi/translation/recipe/" + recipeId;
            IRestRequest request = new RestRequest(url, Method.GET);
            SetHeaders(request);
            var response = Client.Execute(request);
            return response;
        }

        public IRestResponse UpdateRecipe(RecipeTranslation translation, string recipeId)
        {
            string url = "foodservice-fi/translation/recipe/" + recipeId;
            IRestRequest request = new RestRequest(url, Method.POST);
            SetHeaders(request);
            SetRequestBody(request);
            var response = Client.Execute(request);
            return response;
        }

    }
}
