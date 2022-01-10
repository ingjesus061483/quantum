using Factory;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace PruebaQuantum
{
    public abstract  class Utilities
    {
        public static string App_Name = "Tienda virtual";
        public static string url;
        public static async Task<List<T>> GetListDataAPIAsync<T>()
        {
            try
            {
                var list = new List<T>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(30);
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<T>>(apiResponse);


                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       public static  string Encriptar(string cadenaAencriptar)
        {
            string result = String.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        public static async Task<T> GetDataAPIAsync<T>()
        {
            try
            {
                T data;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (typeof(T) == typeof(string))
                        {
                            return (T)(object)apiResponse;
                        }
                        data = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> PostDataAPIAsync<T>( T data)
        {
            try
            {
                var apiResponse = string.Empty;
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> PUTDataAPIAsync<T>( T data)
        {
            var apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(url, content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return apiResponse;

        }

        public static async Task<string> PUTDataAPIAsync()
        {
            try
            {
                var apiResponse = string.Empty;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsync(url, null))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
