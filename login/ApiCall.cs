using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace login
{
    class ApiCall
    {
        private String _Uri = "https://gorest.co.in/public-api/users";

        //ApiCall(String uri)
        //{
        //	this._Uri = uri;
        //}

        public async System.Threading.Tasks.Task<object> GetRequrestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_Uri),
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
            response.Dispose();
            return JsonConvert.DeserializeObject<object>(body);



        }
    }
}