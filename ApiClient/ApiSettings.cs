using System;

namespace ApiClient
{
    public class ApiSettings
    {
        #region Fields

        private readonly string _baseAddress;
        private readonly string _contentType;

        #endregion

        #region Properties

        public string BaseAddress => _baseAddress;

        public string ContentType => _contentType;

        #endregion

        #region Constructors

        public ApiSettings(string baseAddress, string contentType)
        {
            _baseAddress = baseAddress;
            _contentType = contentType;
        }

        #endregion

    }//class
}//namespace
