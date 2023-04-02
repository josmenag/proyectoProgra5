using CarListApp.Maui.Models;
using CarListApp.Maui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarListApp.Maui.Services
{
    public class CarApiService
    {
        HttpClient _httpClient;
        public string StatusMessage;

        public CarApiService()
        {
            var baseAddress = GetBaseAdress();
            _httpClient = new() { BaseAddress = new Uri(baseAddress) };
        }

        private string GetBaseAdress()
        {
                return "https://p5cars-api.azurewebsites.net";
        }

        public async Task<List<Car>> GetCars()
        {
            try
            {
                await SetAuthToken();
                var response = await _httpClient.GetAsync("/cars");
                var contentStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var cars = await JsonSerializer.DeserializeAsync<List<Car>>(contentStream, options);
                return cars;

            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }


        public async Task<Car> GetCar(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/cars/" + id);
                var car = JsonSerializer.Deserialize<Car>(response);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public async Task AddCar(Car car)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/cars/", car);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to add data.";
            }
        }

        public async Task DeleteCar(int id)
        {
            try
            {

                var response = await _httpClient.DeleteAsync("/cars/" + id);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
        }

        public async Task UpdateCar(int id, Car car)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("/cars/" + id, car);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
        }

        public async Task<AuthResponseModel> Login(LoginModel loginModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/login", loginModel);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Login Successful";

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var authResponse = JsonSerializer.Deserialize<AuthResponseModel>(json, options);


                return authResponse;
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to log in.";
                return new AuthResponseModel();
            }
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}






