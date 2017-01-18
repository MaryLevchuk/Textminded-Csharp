using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Api.Models
{
    public class Request
    {
        public IRestRequest RestRequest = new RestRequest();
        public string Url { get; set; }
        public Method Meth { get; set; }

        public Request(string url, Method method)
        {

            RestRequest.JsonSerializer = new NewtonsoftJsonSerializer();
            
        }

       

        //public string SetRequestBody(TData t)
        //{
        //    //    string jsonString = JsonConvert.SerializeObject(t);
        //    //    return jsonString;
        //}

    }
}
