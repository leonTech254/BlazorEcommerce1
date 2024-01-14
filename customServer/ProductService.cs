using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceFronted.models;

namespace EcommerceFronted.customServer
{
    public class ProductServices
    {
        private string BaseURL;
        private HttpClient client;

        public ProductServices()
        {
            client = new HttpClient();
            BaseURL = "http://localhost:5087/api/v1/products/";
        }

      public async Task<string?> AddProduct(Products product)
{
    product.dateAdded=DateTime.Now.ToString();
    try
    {
        string url = BaseURL + "AddProduct/"; 
        string jsonContent = JsonSerializer.Serialize(product);

        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Send the POST request
        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);
            Console.WriteLine("Product added successfully");
            return null;
        }
        else
        {
             string errorContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"Error content: {errorContent}");
            Console.WriteLine($"Error sending POST request. Status Code: {response.StatusCode}");
            return "Error adding product.";
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        return "An error occurred while adding the product.";
    }
}
        public async Task<string?> DeleteProduct(Products product)
        {
             try
    {
        string url = $"{BaseURL}DeleteProduct/{product.Id}";

        HttpResponseMessage response = await client.DeleteAsync(url);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Product Deleted Successfully");
            return null;
        }
        else
        {
            Console.WriteLine($"Error sending DELETE request. Status Code: {response.StatusCode}");
            return "Error deleting product.";
        }
    }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return "An error occurred while deleting the product.";
            }
        }

        public async Task<Products?> GetProductById(int id)
        {
            try
            {
                string url = BaseURL + $"getProductById/{id}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Products products= JsonSerializer.Deserialize<Products>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return products;
                }
                else
                {
                    Console.WriteLine($"Error sending GET request. Status Code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Products>?> GetAllProduct()
        {
            try
            {
                string url = BaseURL + "GetAllProducts";
                Console.WriteLine("fhsfhjsf");
                HttpResponseMessage response = await client.GetAsync(url);
               

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(data+"np data");

                    return JsonSerializer.Deserialize<List<Products>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    Console.WriteLine($"Error sending GET request. Status Code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        public async Task<string?> UpdateProduct(int id, Products product)
        {
            try
            {
                string url = BaseURL + $"UpdateProduct/{id}";
                string jsonContent = JsonSerializer.Serialize(product);

                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("Product Updated Successfully");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Error sending PUT request. Status Code: {response.StatusCode}");
                    return "Error updating product.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return "An error occurred while updating the product.";
            }
        }
    }
}
