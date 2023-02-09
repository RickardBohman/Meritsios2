using Meritsios_2._0.Data;
using Meritsios_2._0.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritsios_2._0.Pages.Users
{
    public class ListUsersModel : PageModel
    {
        private readonly UserDbContext dbContext;

        public List<User> _users { get; set; }

        public ListUsersModel(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            _users = dbContext._Users.ToList();
        }
    }
}
