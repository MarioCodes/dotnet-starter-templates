using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace razor_pages.Pages.Courses
{
    public class CreateModel(SchoolContext context) : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Courses.Add(Course);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
