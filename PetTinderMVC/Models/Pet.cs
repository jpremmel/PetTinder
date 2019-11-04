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
        public ICollection<Pet> Interested { get; set; } //list of pets I've swiped right on
        public ICollection<Pet> Matches { get; set; } //list of pets I've matched with (both pets swiped right)

        

    }
}