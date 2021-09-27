using System;

namespace Recruitment.Client
{
    public class ApiConfiguration : IApiClientConfiguration
    {
        private string baseUrl;

        public string BaseUrl
        {
            get { return baseUrl; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value can not be null or empty", nameof(BaseUrl));
                }

                baseUrl = value;
            }
        }
    }
}
