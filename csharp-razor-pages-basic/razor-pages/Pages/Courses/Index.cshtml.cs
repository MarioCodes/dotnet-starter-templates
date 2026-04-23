using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace razor_pages.Pages.Courses
{
    public class IndexModel(SchoolContext context) : PageModel
    {

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await context.Courses.ToListAsync();
        }
    }
}
