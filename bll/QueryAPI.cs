using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

namespace EOXAdvisor
{
    public static class QueryAPI
    {
        public async static Task<APIResponseObjects.PID.EOXByRecord> GetEOXDetailsByPID<EOXByRecord>(string accessToken, string PIDS)
        {
            HttpClient client = new HttpClient();

            string URL = "https://api.cisco.com/supporttools/eox/rest/5/EOXByProductID/";
            string ENCODING = "?responseencoding=json";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var httpResponse = await client.GetAsync(URL + PIDS + ENCODING);

            if (httpResponse.IsSuccessStatusCode)
            {
                var jsonResponse = await httpResponse.Content.ReadAsStreamAsync();

                APIResponseObjects.PID.EOXByRecord EOXRecords = await JsonSerializer.DeserializeAsync<APIResponseObjects.PID.EOXByRecord>(jsonResponse);

                if (EOXRecords.EOXRecord != null)
                {
                    return EOXRecords;
                } 
                else
                {
                    return null;
                }
            } 
            else
            {
                return null;
            }
        }
    }
}
