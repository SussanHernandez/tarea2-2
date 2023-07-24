using AppEje2_2.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEje2_2.Models
{
    public class WebService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        public async Task<List<Post>> GetAllPostsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseUrl}/posts");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Post>>(content);
                }
            }
            return null;
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseUrl}/posts/{postId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Post>(content);
                }
            }
            return null;
        }
    }
}
