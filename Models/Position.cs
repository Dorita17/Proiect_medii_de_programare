using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_medii_de_programare.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //Relationships
        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}
