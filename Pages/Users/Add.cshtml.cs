using Meritsios_2._0.Data;
using Meritsios_2._0.Models.Domain;
using Meritsios_2._0.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Meritsios_2._0.Pages.Users
{


    public class AddModel : PageModel
    {
        private readonly UserDbContext dbContext;

        [BindProperty] 
        public AddUserViewModel AddUserRequest { get; set; }

        public AddModel(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            var userDomainModel = new User
            {
                Name = AddUserRequest.Name,
                Email = AddUserRequest.Email,
                Phone = AddUserRequest.Phone,
                School = AddUserRequest.School,
                Education = AddUserRequest.Education,
                Location = AddUserRequest.Location
                
            };

            dbContext._Users.Add(userDomainModel);
            dbContext.SaveChanges();
            return RedirectToPage("/index");
        }
    }
}
