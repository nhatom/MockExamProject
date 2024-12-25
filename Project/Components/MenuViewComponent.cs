using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Models;

namespace Project.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent(DataContext dataContext)
        {
            _context = dataContext;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var sql = "SELECT * FROM MENU WHERE IsActive = 1 AND Position = 1";
            var listofMenu = await _context.MENU.Where(p => p.IsActive == 1 && p.Position == 1).ToListAsync();

            return View("Default", listofMenu);
        }


    }
}
