using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Api.Models
{
    public class Response : RestResponse
    {
        public string Body { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Body = "";
            Code = 0;
            Message = "";
        }
    }
}
