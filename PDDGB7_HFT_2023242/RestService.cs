using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242
{
    class RestService
    {
        HttpClient client;

        public RestService(string baseurl, string pingableEndpoint = "swagger")
        {
            bool isOk = false;
            do
            {
                isOk = Ping(baseurl + pingableEndpoint);
            } while (isOk == false);
            Init(baseurl);
        }

        private bool Ping(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadData(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Init(string baseurl)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));
            try
            {
                client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Endpoint is not available!");
            }

        }

        public List<T> Get<T>(string endpoint)
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return items;
        }


        public T GetSingle<T>(string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public T Get<T>(int id, string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = client.GetAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }


        public string GetMostPlayedGame()
        {
            string item = default(string);
            HttpResponseMessage response = client.GetAsync("RentLog/MostPlayedGame/").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;

        }

        public string GetFavouriteDeveloper(string refCode)
        {
            string item = default(string);
            HttpResponseMessage response = client.GetAsync("User/GetMostLikedDeveloper/" + refCode).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }
        public double GetAllUsersAverageNumberOfRents()
        {
            double avg = default(double);
            HttpResponseMessage response = client.GetAsync("User/GetAllUsersAverageNumberOfRents/").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                avg = response.Content.ReadAsAsync<double>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return avg;
        }
        public string NumberOfGamesByDeveloper(string name)
        {
            string item = default(string);
            HttpResponseMessage response = client.GetAsync("Game/NumberOfGamesByDeveloper/" + name).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;

        }
        public string GetTheBusiestYearsMostPlayedGame()
        {
            string item = default(string);
            HttpResponseMessage response = client.GetAsync("RentLog/TheBusiestYearsMostPlayedGame/").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }
        public string NumberOfDevelopersGamesRentedAtDate(string developerName, string date)
        {
            string item = default(string);
            HttpResponseMessage response = client.GetAsync($"RentLog/NumberOfDevelopersGamesRentedAtDate/{developerName}/{date}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            return item;

        }
        public void Post<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {

                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }
            response.EnsureSuccessStatusCode();
        }

        public void Delete(int id, string endpoint)
        {
            HttpResponseMessage response =
                client.DeleteAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

        public void Put<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                client.PutAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

    }
    public class RestExceptionInfo
    {
        public RestExceptionInfo()
        {

        }
        public string Msg { get; set; }
    }
}
