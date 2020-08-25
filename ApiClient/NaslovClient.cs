using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ApiClient;
using Biblioteka.Domain.Dto;
using Newtonsoft.Json;

namespace Biblioteka.ApiClient
{
    public class NaslovClient:ApiClientBase
    {
        public NaslovClient(ApiSettings apiSettings) : base(apiSettings, "api/naslov")
        {
        }//.ctor()

        #region Methods

        public IEnumerable<NaslovDto> GetAll()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<NaslovDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public IEnumerable<JezikDto> GetJezike()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append("api/jezik").GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<JezikDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public IEnumerable<VrstaDto> GetVrste()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append("api/vrsta").GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<VrstaDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void AddAsync(NaslovDto value)
        {

            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/add", content).Result;
        }

        public void UpdateAsync(NaslovDto value)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/update", content).Result;
        }

        public NaslovDto GetById(int id)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).Append("get").Append(id.ToString()).GetUrl()).Result;
            return JsonConvert.DeserializeObject<NaslovDto>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void DeleteAsync(NaslovDto value)
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
