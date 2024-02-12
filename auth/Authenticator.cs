using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace EOXAdvisor
{
    static public class Authenticator
    {
        //
        // CONFIDENTIAL INFORMATION
        //
        // created/revoked at https://apiconsole.cisco.com
        //
        static private readonly string clientID = "<redacted>";
        static private readonly string clientSecret = "<redacted>";
        //
        //
        //

        public static async Task<string> Authenticate()
        {
            var accessToken = await GetAccessToken<Token>(clientID, clientSecret);
            return accessToken.AccessToken;
        }

        public static async Task<Token> GetAccessToken<Token>(string clientID, string clientSecret)
        {
            HttpClient client = new HttpClient();

            string URL = "https://cloudsso.cisco.com/as/token.oauth2";

            Dictionary<string,string> credentialsRequest = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", clientID},
                {"client_secret", clientSecret},
            };

            var httpResponse = await client.PostAsync(URL, new FormUrlEncodedContent(credentialsRequest));
            var jsonResponse = await httpResponse.Content.ReadAsStreamAsync();

            Token accessToken = await JsonSerializer.DeserializeAsync<Token>(jsonResponse);

            //client.Dispose();

            return accessToken;
        }

    }
}
