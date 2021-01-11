using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_de_programare.Data;
using Proiect_medii_de_programare.Models;

namespace Proiect_medii_de_programare.Pages.TeamMembers
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext _context;

        public IndexModel(Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        public IList<TeamMember> TeamMember { get;set; }

        public async Task OnGetAsync()
        {
            TeamMember = await _context.TeamMember
                .Include(t => t.Position)
                .Include(t => t.Team).ToListAsync();
        }
    }
}
