using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Dog
    {

        [Required(ErrorMessage = "Please nter a gender.")]
        public string GenderId { get; set; }
        public Gender Gender { get; set; }
        // EF will instruct the database to automatically generate this value
        public int DogId { get; set; }

        [Required(ErrorMessage = "Please enter the Dog's name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a dog breed.")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "Please enter dog's age.")]
        [Range(1, 16, ErrorMessage = "age must be between 1 and 16.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please enter a weight in lbs.")]
        [Range(1, 120, ErrorMessage = "Weight must be between 1 and 120.")]
        public int? Weight { get; set; }

    }
}
