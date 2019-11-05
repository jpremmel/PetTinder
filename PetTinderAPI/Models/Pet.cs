using System.Collections.Generic;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace PetTinderAPI.Models
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
        //public virtual ICollection<string> Photos { get; set; } //******/START HERE ON TUESDAY*******
        // public ICollection<Pet> Interested { get; set; } //list of pets I've swiped right on
        // public ICollection<Pet> Matches { get; set; } //list of pets I've matched with (both pets swiped right)
        
        // public Pet()
        // {
        //     this.Photos = new HashSet<string>();
        // }
    }
}