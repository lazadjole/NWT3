using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient
{
    public class UrlBuilder
    {
        private readonly StringBuilder _stringBuilder;
        private string _urlSeparator = "/";

        public UrlBuilder(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        public UrlBuilder(ApiSettings apiSettings)
        {
            _stringBuilder = new StringBuilder();
            _stringBuilder.Append(apiSettings.BaseAddress).Append(_urlSeparator);
        }

        public UrlBuilder Append(string value)
        {
            _stringBuilder.Append(value);
            _stringBuilder.Append(_urlSeparator);
            return  new UrlBuilder(_stringBuilder);
        }
        public string GetUrl()
        {
            return _stringBuilder.ToString();
        }
    }
}
