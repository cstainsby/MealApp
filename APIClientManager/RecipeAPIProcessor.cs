using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIClientManager.Models;

namespace APIClientManager
{
    public static class RecipeAPIProcessor 
    {
        public static async Task<RecipeAPIModel> GetByIdAsync(int Id = 0)
        {
            HttpRequestMessage websiteIdentifier;

            if(Id > 0)
            {
                websiteIdentifier = new HttpRequestMessage(HttpMethod.Get, $"https://api.edamam.com/api/recipes/v2/{ Id }");
            }
            else
            {
                websiteIdentifier = null;
            }

            // generate a response from the API given the url 
            // the url will be used to make a URI (Uniform resource identifier)
            using (HttpResponseMessage response = await APIHelper.APIClient.SendAsync(websiteIdentifier))
            {
                if (response.IsSuccessStatusCode)
                {
                    // if response is successful - fetch the model from the API database
                    RecipeAPIModel recipe = await response.Content.ReadAsAsync<RecipeAPIModel>();

                    return recipe;
                }
                else
                {
                    // if not successful - throw exception
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<IEnumerable<RecipeAPIModel>> GetListAsync()
        {
            APIHelper.InitAPIClient();
            APIHelper.APIClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");

            String applicationIdentity = "4bc9018d";
            String applicationKey = "05205eac3264d0e8a934e6ca921dac7c";
            String query = "pizza";

            String urlParams = "?app_id=" + applicationIdentity + "&app_key=" + applicationKey + "&q=" + query;

            // generate a response from the API given the url 
            // the url will be used to make a URI (Uniform resource identifier)
            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(urlParams))
            {
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    // if response is successful - fetch the model from the API database
                    IEnumerable<RecipeAPIModel> recipe = await response.Content.ReadAsAsync<IEnumerable<RecipeAPIModel>>();

                    return recipe;
                }
                else
                {
                    // if not successful - throw exception
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
