using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ApiClient;
using Biblioteka.Domain.Dto;
using Newtonsoft.Json;

namespace Biblioteka.ApiClient
{
    public class ClanClient:ApiClientBase
    {
        public ClanClient(ApiSettings apiSettings) : base(apiSettings, "api/clan")
        {
        }//.ctor()

        #region Methods

        public IEnumerable<ClanDto> GetAll()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<ClanDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void AddAsync(ClanDto value)
        {

            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/add", content).Result;
        }

        public void UpdateAsync(ClanDto value)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/update", content).Result;
        }

        public ClanDto GetById(int id)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).Append("get").Append(id.ToString()).GetUrl()).Result;
            return JsonConvert.DeserializeObject<ClanDto>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void DeleteAsync(ClanDto value)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/delete", content).Result;
        }
        #endregion
    }//class
}//namespace
