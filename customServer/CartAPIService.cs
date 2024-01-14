using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceFronted.models;

namespace EcommerceFronted.customServer
{
    public class CartAPIService
    {
        private string BaseURL;
        private HttpClient client;

        public CartAPIService()
        {
            client = new HttpClient();
            BaseURL = "http://localhost:5013/api/cart/";
        }

       public async Task<string?> AddToCart(int productId, int quantity, string token)
{
    Console.WriteLine(token);
    try
    {

        string url = $"{BaseURL}AddToCart/{productId}/{quantity}/";
        var response = await SendAuthorizedRequest(url, HttpMethod.Post, token);

        if (response.IsSuccessStatusCode) 
        {
            string data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);
            Console.WriteLine("Product added to cart successfully");
            return null;
        }
        else
        {
            string errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error content: {errorContent}");
            Console.WriteLine($"Error sending POST request. Status Code: {response.StatusCode}");
            return "Error adding product to cart.";
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        return "An error occurred while adding the product to cart.";
    }
}


        public async Task<List<CartItem>> GetAllCartItems()
        {
            try
            {
                string url = $"{BaseURL}GetAll";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<CartItem>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    Console.WriteLine($"Error sending GET request. Status Code: {response.StatusCode}");
                    return new List<CartItem>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<CartItem>();
            }
        }


      private async Task<HttpResponseMessage> SendAuthorizedRequest(string url, HttpMethod method, string token)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("Authorization", $"Bearer {token}");
            return await client.SendAsync(request);
        }

    }
}
