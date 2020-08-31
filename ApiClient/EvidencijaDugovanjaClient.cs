using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Biblioteka.Domain.Dto;
using Newtonsoft.Json;

namespace ApiClient
{
    public class EvidencijaDugovanjaClient:ApiClientBase
    {
        public EvidencijaDugovanjaClient(ApiSettings apiSettings) : base(apiSettings, "api/evidencijadugovanja")
        {
        }//.ctor()

        #region Methods

        public IEnumerable<EvidencijaDugovanjaDto> GetAll()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<EvidencijaDugovanjaDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public IEnumerable<EvidencijaDugovanjaDto> GetTrenutnoZaduzeno()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).Append("gettrenutnozaduzeno").GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<EvidencijaDugovanjaDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public IEnumerable<NaslovDto> GetNaslove()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append("api/naslov").GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<NaslovDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public NaslovDto GetNaslovById(int id)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append("api/naslov/get").Append(id.ToString()).GetUrl()).Result;
            return JsonConvert.DeserializeObject<NaslovDto>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public IEnumerable<ClanDto> GetClanove()
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append("api/clan").GetUrl()).Result;
            return JsonConvert.DeserializeObject<List<ClanDto>>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void AddAsync(EvidencijaDugovanjaDto value)
        {

            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName+"/add", content).Result;
        }

        public void UpdateAsync(EvidencijaDugovanjaDto value)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage =
                httpClient.PostAsync(ControllerName + "/update", content).Result;
        }

        public EvidencijaDugovanjaDto GetById(int id)
        {
            HttpClient httpClient = GetHttpClient();
            UrlBuilder urlBuilder = new UrlBuilder(this.ApiSettings);
            HttpResponseMessage httpResponseMessage =
                httpClient.GetAsync(urlBuilder.Append(ControllerName).Append("get").Append(id.ToString()).GetUrl()).Result;
            return JsonConvert.DeserializeObject<EvidencijaDugovanjaDto>(httpResponseMessage.Content
                .ReadAsStringAsync().Result);
        }

        public void DeleteAsync(EvidencijaDugovanjaDto value)
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
