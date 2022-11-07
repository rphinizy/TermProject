using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Dog
    {
        [Required(ErrorMessage = "Please enter origin of pet. (i.e, earth, mars, bellerophon... etc")]
        public string OriginId { get; set; }
        [Column("Place of Origin")]
        [Display(Name="Place of Origin")]
        public Origin Origin { get; set; }

        [Required(ErrorMessage = "Please enter a gender.")]
        public string GenderId { get; set; }
        public Gender Gender { get; set; }
        // EF will instruct the database to automatically generate this value

        public int DogId { get; set; }
        [Required(ErrorMessage = "Please enter the Dog's name.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Letters and Numbers allowed.")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a dog breed.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Letters and Numbers allowed.")]
        [StringLength(20)]
        public string Breed { get; set; }

        [Required(ErrorMessage = "Please enter dog's age.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Please enter a weight in lbs.")]
        [Range(1, 120, ErrorMessage = "Weight must be between 1 and 120.")]
        public int? Weight { get; set; }

    }
}
