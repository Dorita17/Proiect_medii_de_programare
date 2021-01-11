using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_medii_de_programare.Data;
using Proiect_medii_de_programare.Models;

namespace Proiect_medii_de_programare.Pages.TeamMembers
{
    public class EditModel : PageModel
    {
        private readonly Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext _context;

        public EditModel(Proiect_medii_de_programare.Data.Proiect_medii_de_programareContext context)
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
           ViewData["PositionId"] = new SelectList(_context.Position, "Id", "Description");
           ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(TeamMember.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMember.Any(e => e.Id == id);
        }
    }
}
