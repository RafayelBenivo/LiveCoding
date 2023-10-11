using OpenQA.Selenium;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace LiveCoding.Services
{
    public class BaseApiService : IDisposable
    {
        protected HttpClient Client;

        public BaseApiService()
        {
            Client = new HttpClient();
        }

        public BaseApiService(IWebDriver driver)
        {
            HttpClientHandler httpClientHandler = AddCookiesToHTTPClientHandler(driver);

            Client = new HttpClient(httpClientHandler);
        }

        #region Post Methods

        protected TResponseModel PostAsJson<TRequestModel, TResponseModel>(Uri requestUrl, TRequestModel requestModel)
        {
            HttpResponseMessage httpResponseMessage = Client.PostAsJsonAsync(requestUrl, requestModel).Result;

            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new AggregateException("Response status code does not indicate success: 401 (Unauthorized).");
            }
            TResponseModel responseModel = httpResponseMessage.Content.ReadFromJsonAsync<TResponseModel>().Result;
            return responseModel;
        }

        protected TResponseModel PostAsJson<TRequestModel, TResponseModel>(Uri requestUrl, TRequestModel requestModel, Dictionary<string, string> headers)
        {
            AddHeaders(headers);

            HttpResponseMessage httpResponseMessage = Client.PostAsJsonAsync(requestUrl, requestModel).Result;

            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new AggregateException("Response status code does not indicate success: 401 (Unauthorized).");
            }

            TResponseModel responseModel = httpResponseMessage.Content.ReadFromJsonAsync<TResponseModel>().Result;
            return responseModel;
        }

        protected HttpResponseMessage PostAsJson(Uri requestUrl, Dictionary<string, string> headers)
        {
            AddHeaders(headers);

            return Client.PostAsJsonAsync(requestUrl, new { }).Result;
        }

        protected HttpResponseMessage PostAsJson<TRequestModel>(Uri requestUrl, TRequestModel requestModel, Dictionary<string, string> headers)
        {
            AddHeaders(headers);

            HttpResponseMessage httpResponseMessage = Client.PostAsJsonAsync(requestUrl, requestModel).Result;
            return httpResponseMessage;
        }

        #endregion Post Methods

        #region Get Methods

        protected TResponseModel GetFromJson<TResponseModel>(Uri requestUrl, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            TResponseModel responseModel = Client.GetFromJsonAsync<TResponseModel>(requestUrl).Result;
            return responseModel;
        }

        protected TResponseModel GetFromJson<TResponseModel>(Uri requestUrl, JsonSerializerOptions options, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            TResponseModel responseModel = Client.GetFromJsonAsync<TResponseModel>(requestUrl, options).Result;
            return responseModel;
        }

        #endregion Get Methods

        #region Delete Methods

        protected TResponseModel DeleteFromJson<TResponseModel>(Uri requestUrl, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            TResponseModel responseModel = Client.DeleteFromJsonAsync<TResponseModel>(requestUrl).Result;
            return responseModel;
        }

        #endregion Delete Methods

        private void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                if (Client.DefaultRequestHeaders.Contains(header.Key))
                {
                    Client.DefaultRequestHeaders.Remove(header.Key);
                }

                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        private HttpClientHandler AddCookiesToHTTPClientHandler(IWebDriver driver)
        {
            // Retrieve the generated cookies
            var cookies = driver.Manage().Cookies.AllCookies;

            // Set up HttpClient and attach cookies
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            foreach (var cookie in cookies)
            {
                httpClientHandler.CookieContainer.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }

            return httpClientHandler;
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
