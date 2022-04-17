using Refit;
using System;
using System.Net.Http;

namespace Workers.Services
{
    internal class BaseDataService<T>
    {
        /// <summary>
        /// Интерфейс для работы с сервисами
        /// </summary>
        public static T InstanceInterface
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
