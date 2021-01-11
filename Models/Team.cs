using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_medii_de_programare.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Buget { get; set; }

        //Relationships
        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}
