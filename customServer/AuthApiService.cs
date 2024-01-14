using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceFronted.customServer;
using EcommerceFronted.models;
using LogInDTONameSpace;
using Newtonsoft.Json.Linq;
using Registration_Namespace;

namespace EcommerceFronted.customServer
{
//     


    public class AuthApiService
    {
        private String BaseURL;
    private HttpClient client;
    public AuthApiService()
    {
        client =new HttpClient();
        BaseURL="http://localhost:5124/api/v1/authentication/";
    }

    public async Task<LoginResponse?> UserLogin(LoginDTO login)
    {
        String url=BaseURL+"login/";
        string jsonContent = JsonSerializer.Serialize(login);

			HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            
		

			// Send the POST request
			HttpResponseMessage response = await client.PostAsync(url, content);

			if (response.StatusCode==HttpStatusCode.OK)
			{
                string data = await response.Content.ReadAsStringAsync();
                 JObject jsonObject = JObject.Parse(data);
             LoginResponse loginResponse = new LoginResponse
             {
                usertoker=jsonObject["value"]["usertoker"].ToString(),
                msg=jsonObject["value"]["msg"].ToString(),

             };
               
                Console.WriteLine(loginResponse);
				Console.WriteLine("Successfully sent the POST request");
                return loginResponse;   
			}
			else
			{
				Console.WriteLine($"Error sending POST request. Status Code: {response.StatusCode}");
                return null;
			}
    }

     public async Task<String?> USerRegistration(RegisterDTO registerDTO)
    {
        String url=BaseURL+"register/";
        string jsonContent = JsonSerializer.Serialize(registerDTO);

			HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			// Send the POST request
			HttpResponseMessage response = await client.PostAsync(url, content);

			if (response.StatusCode==HttpStatusCode.OK)
			{
                string data = await response.Content.ReadAsStringAsync();
             
              
                Console.WriteLine(data);
				Console.WriteLine("Registered successfully");
                return null;
             
			}
			else
			{
				Console.WriteLine($"Error sending POST request. Status Code: {response.StatusCode}");
                return null;
			}
    }

        
    }
}