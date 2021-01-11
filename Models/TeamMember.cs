using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_medii_de_programare.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "TShirt Number")]
        [Range(0, 99, ErrorMessage = "The number of the player's TShirt must be between 0 and 99.")]
        public int TShirtNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The salary must be greather than 0!")]
        public int Salary { get; set; }

        [Required]
        public string Nationality { get; set; }

        //Relationships
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
