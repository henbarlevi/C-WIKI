using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class HttpService
    {
        private static  HttpClient client;
        public static HttpClient Http
        {
            get {
                if(HttpService.client == null)
                {
                    HttpService.client = new HttpClient();
                }
                return client;
            }
        }


    }
}
