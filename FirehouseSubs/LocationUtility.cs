using FirehouseSubs.Models;
using Newtonsoft.Json;
using System.Net;

namespace FirehouseSubs
{
    public static class LocationUtility
    {
        private readonly static string _url = "https://www.firehousesubs.com/umbraco/api/geolocationapi/get";

        public static async Task<List<UmbracoLocation>> GetLocationInformationFromInputAsync(object input)
        {
            string queryParam = QueryUtility.FormatQueryParam("?address", input.ToString());
            return await MakeAPICall<List<UmbracoLocation>>(_url + queryParam);
        }

        private static async Task<T> MakeAPICall<T>(string url)
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

            throw new HttpRequestException($"{message.StatusCode} code - Request to get location information was not successful");
        }

        private static T DeserializeResponse<T>(string contents)
        {
            return JsonConvert.DeserializeObject<T>(contents);
        }

        internal static Dictionary<string, string> StateNamesToCodes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"Alabama", "AL"},
            { "Alaska", "AK"},
            {"Arizona" , "AZ"},
            {"Arkansas" , "AR"},
            {"California" , "CA"},
            {"Colorado" , "CO"},
            {"Connecticut" , "CT"},
            {"Delaware" , "DE"},
            {"District Of Columbia" , "DC"},
            {"Florida" , "FL"},
            {"Georgia" , "GA"},
            {"Hawaii" , "HI"},
            {"Idaho" , "ID"},
            {"Illinois" , "IL"},
            {"Indiana" , "IN"},
            {"Iowa" , "IA"},
            {"Kansas" , "KS"},
            {"Kentucky" , "KY"},
            {"Louisiana" , "LA"},
            {"Maine" , "ME"},
            {"Maryland" , "MD"},
            {"Massachusetts" , "MA"},
            {"Michigan" , "MI"},
            {"Minnesota" , "MN"},
            {"Mississippi" , "MS"},
            {"Missouri" , "MO"},
            {"Montana" , "MT"},
            {"Nebraska" , "NE"},
            {"Nevada" , "NV"},
            {"New Hampshire" , "NH"},
            {"New Jersey" , "NJ"},
            {"New Mexico" , "NM"},
            {"New York" , "NY"},
            {"North Carolina" , "NC"},
            {"North Dakota" , "ND"},
            {"Ohio" , "OH"},
            {"Oklahoma" , "OK"},
            {"Oregon" , "OR"},
            {"Pennsylvania" , "PA"},
            {"Rhode Island" , "RI"},
            {"South Carolina" , "SC"},
            {"South Dakota" , "SD"},
            {"Tennessee" , "TN"},
            {"Texas" , "TX"},
            {"Utah" , "UT"},
            {"Vermont" , "VT"},
            {"Virginia" , "VA"},
            {"Washington" , "WA"},
            {"West Virginia" , "WV"},
            {"Wisconsin" , "WI"},
            {"Wyoming" , "WY"},
        };
    }
}
