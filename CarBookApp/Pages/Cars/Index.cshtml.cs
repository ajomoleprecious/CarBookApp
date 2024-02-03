using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        // add context for database access

        private readonly CarBookAppContext _context;
        // add a constructor to accept the database context as a parameter
        public IndexModel(CarBookAppContext context)
        {
            _context = context;
        }
        // add a list of cars
        public IList<Car> Cars { get; set; }
        // add a method to get the list of cars
        public async Task OnGetAsync()
        {
            Cars = await _context.Cars.ToListAsync();
        }
    }
}
