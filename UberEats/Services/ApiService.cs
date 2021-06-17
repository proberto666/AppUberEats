using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UberEats.Models;

namespace UberEats.Services
{
    class ApiService
    {
        public string ApiURL = "http://192.168.0.200";

        public async Task<ApiResponse> GetDataAsync<T>(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiURL)
                };
                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                var data = JsonConvert.DeserializeObject<List<T>>(result);
                return new ApiResponse
                {
                    IsSucces = true,
                    Message = "Los datos fueron obtenidos de manera correcta",
                    Response = data
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> PostDataAsync(string controller, object data)
        {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");


                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiURL)
                };
                var response = await client.PostAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> PutDataAsync(string controller, object data)
        {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");


                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiURL)
                };
                var response = await client.PutAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> DeleteDataAsync(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiURL)
                };
                var response = await client.DeleteAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSucces = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSucces = false,
                    Message = ex.Message
                };
         
            }
        }
    }
}
