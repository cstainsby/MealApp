using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIClientManager
{
    public class APIHelper
    {
        // we can make this static because for this program we will only ever need one client
        public static HttpClient APIClient { get; set; }

        public static void InitAPIClient()
        {
            APIClient = new HttpClient();
            
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void DisposeAPIClient()
        {
            APIClient.Dispose();
        }
    }
}
