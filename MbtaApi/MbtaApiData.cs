using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using MbtaApi.Model;
using Newtonsoft.Json;

namespace MbtaApi
{
    public class MbtaApiData
    {
        private const string RoutesUrl = "https://api-v3.mbta.com/routes";

        private const string StopsUrl = "https://api-v3.mbta.com/stops";

        private const string LinesUrl = "https://api-v3.mbta.com/lines?include=routes";

        public ApiResult<MbtaRoutes> GetMbtaRoutesData(string url = RoutesUrl)
        {
            Task<ApiResult<MbtaRoutes>> apiResponse = GetApiResponse<MbtaRoutes>(url, "Routes API");
            
            ApiResult<MbtaRoutes> result = apiResponse.GetAwaiter().GetResult();

            return result;
        }

        public ApiResult<MbtaLines> GetMbtaLinesData(string url = LinesUrl)
        {
            Task<ApiResult<MbtaLines>> apiResponse = GetApiResponse<MbtaLines>(url, "Lines API");

            ApiResult<MbtaLines> result = apiResponse.GetAwaiter().GetResult();

            return result;
        }
        
        public ApiResult<MbtaStops> GetMbtaStopsData(string url = StopsUrl)
        {
            Task<ApiResult<MbtaStops>> apiResponse = GetApiResponse<MbtaStops>(url, "Stops API");
            
            ApiResult<MbtaStops> result = apiResponse.GetAwaiter().GetResult();

            return result;
        }

        public IList<string> GetMbtaLineStops(string lineName)
        {
            // https://api-v3.mbta.com/routes?include=stop
            // https://api-v3.mbta.com/routes/?include=stop&id=CR-Worcester
            // Does not include stop data.
            throw new NotImplementedException();
        }

        public string GetMbtaLineLongName(string mbtaStop1, string mbtaStop2)
        {
            throw new NotImplementedException();
        }
        
        private async Task<ApiResult<T>> GetApiResponse<T>(string url, string apiName)
        {
            ApiResult<T> apiResult = new ApiResult<T>();

            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    apiResult.Message = string.Format("Failure response code is received from [{1}] [{0}].", response.StatusCode, apiName);

                    return apiResult;
                }

                string responseData = await response.Content.ReadAsStringAsync();


                if (string.IsNullOrEmpty(responseData))
                {
                    apiResult.Message = string.Format("No response data is received from [{0}].", apiName);

                    return apiResult;
                }

                apiResult.Result = JsonConvert.DeserializeObject<T>(responseData);

                apiResult.Success = true;

                apiResult.Message = "Success";
            }
            catch (Exception ex)
            {
                apiResult.Success = false;

                apiResult.Message = ex.Message;

                //TODO: add logging.
            }

            return apiResult;
        }
    }
}
