using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace PetTinderMVC.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Bio { get; set; }
        public string LookingFor { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        // public ICollection<Pet> Interested { get; set; } //list of pets I've swiped right on
        // public ICollection<Pet> Matches { get; set; } //list of pets I've matched with (both pets swiped right)
        public virtual ApplicationUser User { get; set; }

        public static List<Pet> GetPets()
        {
            var apiCallTask = ApiHelper.ApiCall(0);
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Pet> petList = JsonConvert.DeserializeObject<List<Pet>>(jsonResponse.ToString());
            return petList;
        }

        public static Pet GetPet(int id)
        { 
            var apiCallTask = ApiHelper.ApiCall(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Pet pet = JsonConvert.DeserializeObject<Pet>(jsonResponse.ToString());
            return pet;
        }

        public static async Task<int> EditPet(Pet pet)
        {
            var apiCallTask = await ApiHelper.ApiCallEditPet(pet);
            return pet.PetId;
        }

        public static async Task<int> CreatePet(Pet pet)
        {
            var apiCallTask = await ApiHelper.ApiCallCreatePet(pet);
            return pet.PetId;
        }

        public static async Task<int> DeletePet(Pet pet)
        {
            var apiCallTask = await ApiHelper.ApiCallDeletePet(pet);
            return pet.PetId;
        }

    }
}