﻿using Newtonsoft.Json;
using System.Text;

namespace DataTable.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory =clientFactory; 
        }

        public  async Task<bool> CreateAsync(string url, T objToCreate)
        {
        var req=new HttpRequestMessage(HttpMethod.Post, url);    
            if(objToCreate!=null)
            {
                req.Content=new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");

            }
        else
            {
                return false;
            }
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(req);
            if(response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, url+Id);
          var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(req);
            if(response.StatusCode!=System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(req);
            if (response.StatusCode!=System.Net.HttpStatusCode.OK)
            {
              var jsonString= await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString)!;
            }
            return null!;

        }

        public async Task<T> GetAsync(string url, int Id)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url+Id);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(req);
            if (response.StatusCode!=System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString)!;
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, url);
            if (objToUpdate!=null)
            {
                req.Content=new StringContent(JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");

            }
            else
            {
                return false;
            }
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(req);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}