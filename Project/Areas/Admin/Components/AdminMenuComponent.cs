using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public AdminMenuComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sql = "SELECT * FROM ADMINMENU WHERE IsActive = 1 ";
            var listofMenu = await _dataContext.AdminMenus.FromSqlRaw(sql).ToListAsync();
            

            return View("Default", listofMenu);

        }
    }
}
