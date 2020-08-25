using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiClient
{
    public abstract class ApiClientBase
    {
        #region Fields

        protected ApiSettings ApiSettings;
        protected string ControllerName;

        #endregion

        protected ApiClientBase(ApiSettings apiSettings, string controllerName)
        {
            ApiSettings = apiSettings;
            ControllerName = controllerName;
        }

        #region Methods
        protected HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler()
            {
                UseDefaultCredentials = true
            });

            httpClient.BaseAddress = new Uri(ApiSettings.BaseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApiSettings.ContentType));
            return httpClient;
        }

    #endregion
    }//class
}//class
