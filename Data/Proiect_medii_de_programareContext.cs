using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_de_programare.Models;

namespace Proiect_medii_de_programare.Data
{
    public class Proiect_medii_de_programareContext : DbContext
    {
        public Proiect_medii_de_programareContext (DbContextOptions<Proiect_medii_de_programareContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_medii_de_programare.Models.Position> Position { get; set; }

        public DbSet<Proiect_medii_de_programare.Models.Team> Team { get; set; }

        public DbSet<Proiect_medii_de_programare.Models.TeamMember> TeamMember { get; set; }
    }
}
