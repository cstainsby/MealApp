using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.dll;

namespace APIClientManager.EdamamRecipeAPI
{
    public class RecipeProcessor : ProcessorInterface
    {
        public async Task GetByIdAsync(int Id = 0)
        {
            URI websiteIdentifier;

            if(Id > 0)
            {
                websiteIdentifier = new URI($"https://api.edamam.com/api/recipes/v2/{ Id }");
            }
            else
            {
                websiteIdentifier = null;
            }

            // prevent requests if URI is invalid
            if (websiteIdentifier != null)
            {
                // generate a response from the API given the url 
                // the url will be used to make a URI (Uniform resource identifier)
                using (HttpResponseMessage response = await APIHelper.APIClient.SendAsync(websiteIdentifier))
                {
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
        }
    }
}
