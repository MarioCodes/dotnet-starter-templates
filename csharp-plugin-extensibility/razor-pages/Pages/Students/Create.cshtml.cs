using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Students
{
    public class CreateModel(SchoolContext context) : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        // what we read from front's form is a StudentVM ...
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var entry = context.Add(new Student());
            // ... but what we save into the DDBB is a Student
            // this does name pattern matching from StudentVM to Student
            entry.CurrentValues.SetValues(StudentVM);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
