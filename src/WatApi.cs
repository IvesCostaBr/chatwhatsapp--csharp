using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace chatbot
{
    public class WatApi
    {
        private string APIUrl = "";
        private string token = "";

        public WatApi(string aPIUrl, string token)
        {
            APIUrl = aPIUrl;
            this.token = token;
        }

        public async Task<string> SendRequest(string method, string data)
        {   
            string url = $"{APIUrl}{method}?token={token}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("", content);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> SendMessage(string chatId, string text)
        {
            var data = new Dictionary<string, string>()
            {
                {"chatId",chatId },
                { "body", text }
            };
            return await SendRequest("sendMessage", JsonConvert.SerializeObject(data));
        }
    }
}