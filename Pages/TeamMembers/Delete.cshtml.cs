﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext _context;

        public DeleteModel(Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamMember TeamMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamMember = await _context.TeamMember
                .Include(t => t.Position)
                .Include(t => t.Team).FirstOrDefaultAsync(m => m.Id == id);

            if (TeamMember == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamMember = await _context.TeamMember.FindAsync(id);

            if (TeamMember != null)
            {
                _context.TeamMember.Remove(TeamMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
