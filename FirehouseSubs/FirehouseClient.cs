using FirehouseSubs.Models;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.Emit;

namespace FirehouseSubs
{
    public class FirehouseClient
    {
        private readonly string _url = "https://www.firehousesubs.com/FindLocations/";

        public async Task<List<FirehouseSubsStore>> GetStoreByZipCodeAsync(uint zipCode, uint maxRecords = 50)
        {
            if (maxRecords > 50)
            {
                maxRecords = 50;
            }

            List<UmbracoLocation> locations = await GetLocations(zipCode);
            string queryParams =
                QueryUtility.FormatQueryParam("?latitude", locations[0].Latitude) +
                QueryUtility.FormatQueryParam("&longitude", locations[0].Longitude) +
                QueryUtility.FormatQueryParam("&maxRecords", maxRecords);
            return await MakeAPICall<List<FirehouseSubsStore>>(_url + "/GetNearbyLocations/" + queryParams);
        }

        public async Task<List<FirehouseSubsStore>> GetStoreByCityAsync(string cityName, uint maxRecords = 50)
        {
            if (maxRecords > 50)
            {
                maxRecords = 50;
            }

            List<UmbracoLocation> locations = await GetLocations(cityName);
            string queryParams =
                QueryUtility.FormatQueryParam("?latitude", locations[0].Latitude) +
                QueryUtility.FormatQueryParam("&longitude", locations[0].Longitude) +
                QueryUtility.FormatQueryParam("&maxRecords", maxRecords);
            return await MakeAPICall<List<FirehouseSubsStore>>(_url + "/GetNearbyLocations/" + queryParams);
        }

        public async Task<List<FirehouseSubsStore>> GetStoreByStateAsync(string stateName)
        {
            if (LocationUtility.StateNamesToCodes.ContainsKey(stateName))
            {
                string queryParams = QueryUtility.FormatQueryParam("?state", LocationUtility.StateNamesToCodes[stateName]);
                return await MakeAPICall<List<FirehouseSubsStore>>(_url + "/GetLocationsByState/" + queryParams);
            }

            throw new HttpRequestException($"Entered state does not exist");
        }

        private async Task<T> MakeAPICall<T>(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "FirehouseSubs-NET/1.0");

            HttpResponseMessage message = await client.GetAsync(url);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string contents = await message.Content.ReadAsStringAsync();
                return DeserializeResponse<T>(contents);
            }

            throw new HttpRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private T DeserializeResponse<T>(string contents)
        {
            return JsonConvert.DeserializeObject<T>(contents);
        }

        private async Task<List<UmbracoLocation>> GetLocations(object input)
        {
            List<UmbracoLocation> locations = await LocationUtility.GetLocationInformationFromInputAsync(input);
            if (locations != null)
            {
                return locations;
            }

            throw new HttpRequestException("No stores found with the entered information");
        }
    }
}