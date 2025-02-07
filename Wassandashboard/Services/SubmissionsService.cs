using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Wassandashboard.Data.Models;
using Wassandashboard.Data.Models.Odk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wassandashboard.Data.Services
{
    public class SubmissionsService
    {
        HttpClient odkClient { get; set; }

        IHttpClientFactory HttpClientFactory;
        private Token _cachedToken;
        public SubmissionsService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            odkClient = httpClientFactory.CreateClient("odk");

        }

        public async Task<Token> GetTokenAsync()
        {
            var credentials = new AuthModel
            {
                email = "naveen@adwaithtech.net",
                password = "Shizuka1993*"
            };
            var response = await odkClient.PostAsJsonAsync("/v1/sessions", credentials);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<Token>();
                // If token retrieval is successful, set the cookie headers
                //odkClient.DefaultRequestHeaders.Add("Cookie", $"__Host-session={token.token}; __csrf={token.csrf}");
                //_cachedToken = token; // Cache the token
                //return await response.Content.ReadFromJsonAsync<Token>();
                return token;
            }
            else
            {
                return new Token();
            }
        }

        private async Task EnsureValidTokenAsync()
        {
            // Check if the token is missing and get it if needed
            if (_cachedToken == null)
            {
                _cachedToken = await GetTokenAsync();
            }

            if (_cachedToken != null)
            {

                //odkClient.DefaultRequestHeaders.Add("Cookie", $"__Host-session={_cachedToken.token}; __csrf={_cachedToken.csrf}");
                Console.WriteLine("Token set in headers.");
            }
            else
            {
                Console.WriteLine("Token is null; unable to set in headers.");
            }
        }
    }
}