using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Test.Utility.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<T> GetAndDeserialize<T>(this HttpClient _client, string requestUri, bool ensureSuccessStatusCode = true)
        {
            var response = await _client.GetAsync(requestUri);
            if (ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
        public static async Task<T> SerializeAndPostAndDeserialize<T>(this HttpClient _client, string requestUri, T content, bool ensureSuccessStatusCode = true)
        {
            var jsonString = JsonConvert.SerializeObject(content);
            var response = await _client.PostAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            if (ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
        public static async Task<HttpResponseMessage> SerializeAndPost<T>(this HttpClient _client, string requestUri, T content, bool ensureSuccessStatusCode = true)
        {
            var jsonString = JsonConvert.SerializeObject(content);
            var response = await _client.PostAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            if (ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            if (ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            return response;
        }
        public static async Task<HttpResponseMessage> SerializeAndPut<T>(this HttpClient _client, string requestUri, T content, bool ensureSuccessStatusCode = true)
        {
            var jsonString = JsonConvert.SerializeObject(content);
            var response = await _client.PutAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            if (ensureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
