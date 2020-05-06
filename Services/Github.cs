using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Services
{
    public class Github : IGithub // IClientService / IProductService / ICampaignService
    {
        public async Task<string> GetAPIInfo() 
        {
            // Creating HTTP Client
            HttpClient githubMS = new HttpClient();

            // Executing an ASYNC HTTP Method could be: Get, Post, Put, Delete
            // In this case is a GET
            HttpResponseMessage response = await githubMS.GetAsync("https://api.github.com/users");

            // Read ASYNC response from HTTPResponse 
            String jsonResponse = await response.Content.ReadAsStringAsync();
            // Deserialize response
            List<GitHubAPIDTO>apiInfo = JsonConvert.DeserializeObject<List<GitHubAPIDTO>>(jsonResponse);
            
            // Modifying the Object (Business Logic)
            apiInfo[0].login = apiInfo[0].login + "modified";
            
            // Serialize the object
            String processedInfo = JsonConvert.SerializeObject(apiInfo);

            return processedInfo;
        }
    }


    /* 
    string id = "BASKET-001";
    // FROM CONFIGURATION         
    string productAPIURL = Congiguration.GetSection("Services").GetSection("Products").GetSection("URL");
    HttpResponseMessage responseClients = await githubMS.GetAsync($"{productAPIURL}/products/{id}");
    */
}
