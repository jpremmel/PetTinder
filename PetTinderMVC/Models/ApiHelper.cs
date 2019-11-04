using System.Threading.Tasks;
using RestSharp;
using PetTinderMVC.Models;
using System.Collections.Generic;

namespace PetTinderMVC.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall(int id)
        {
            RestClient client;
            if (id != 0)
            {
                client = new RestClient($"http://localhost:5000/api/pets/{id}");
            }
            else
            {
                client = new RestClient("http://localhost:5000/api/pets");
            }
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallEditPet(Pet pet)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/pets/{pet.PetId}");
            RestRequest request = new RestRequest("/", Method.PUT);
            request.AddJsonBody(pet);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}