using Refit;
using System;
using System.Net.Http;

namespace Workers.Services
{
    internal class BaseDataService<T>
    {
        public T InstanceInterface
        {
            get
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(AppSettings.BaseURI)
                };
                return RestService.For<T>(client);
            }
        }

    }
}
