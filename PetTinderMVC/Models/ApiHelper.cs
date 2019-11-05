using System.Threading.Tasks;
using RestSharp;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using PetTinderMVC.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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

        public static async Task<string> ApiCallCreatePet(Pet pet)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/pets/");
            RestRequest request = new RestRequest("/", Method.POST);
            request.AddJsonBody(pet);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallDeletePet(Pet pet)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/pets/{pet.PetId}");
            RestRequest request = new RestRequest("/", Method.DELETE);
            request.AddJsonBody(pet);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<byte[]> ApiCallGetPhoto(Pet pet, int photo)
        {
            System.Console.WriteLine(">>>>>>>>>>>> GOT TO: MVC API HELPER GET PHOTO METHOD <<<<<<<<<<<<<<<<<<<");
            RestClient client = new RestClient($"http://localhost:5000/api/pets/{pet.PetId}/photo");
            RestRequest request = new RestRequest("/", Method.GET);
            request.AddParameter("id", pet.PetId);
            request.AddParameter("photo", photo);
            var response = await client.ExecuteTaskAsync(request);
            System.Console.WriteLine(">>>>>>>RESPONSE TYPE: " + response.ContentType);
            byte[] bytes = response.RawBytes;


            
            return bytes;
        }

        // public static async <string> ApiCallUploadPhoto(Pet pet)
        // {
        //     RestClient client = new RestClient($"http://localhost:5000/api/pets/{pet.PetId}/upload");
        //     RestRequest request = new RestRequest("/", Method.POST);
        //     request.AddHeader("Content-Type", "multipart/form-data");




        // }

    }
}