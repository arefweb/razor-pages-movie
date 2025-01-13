using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        // Where does the context come form? When the CreateModel class is instantiated, the ASP.NET Core dependency injection framework automatically provides an instance of RazorPagesMovieContext to the constructor. This allows CreateModel to interact with the database context. You can see this in Program.cs file.
        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        // When the form is submitted, the Razor Pages framework looks for a method named OnPostAsync (or OnPost if you’re using synchronous code) in the PageModel class (i.e., CreateModel) and calls it. This is part of the page lifecycle in Razor Pages.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // The Add and SaveChangesAsync methods are part of Entity Framework Core, which is an object-relational mapping (ORM) framework for .NET. They are defined in the DbSet<T> and DbContext classes, respectively.
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
