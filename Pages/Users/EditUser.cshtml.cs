using Meritsios_2._0.Data;
using Meritsios_2._0.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritsios_2._0.Pages.Users
{
    public class EditUserModel : PageModel
    {
        private readonly UserDbContext dbContext;
        [BindProperty]
        public EditUserViewModel _EditUser { get; set; }
        public EditUserModel(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var user = dbContext._Users.Find(id);

            if (user != null)
            {
                _EditUser = new EditUserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    School = user.School,
                    Education = user.Education,
                    Location = user.Location
                };
            }


        }

        public IActionResult OnPostUpdate()
        {
            var user = dbContext._Users.Find(_EditUser.Id);

            if (user != null)
            {
                user.Name = _EditUser.Name;
                user.Email = _EditUser.Email;
                user.Phone = _EditUser.Phone;
                user.School = _EditUser.School;
                user.Education = _EditUser.Education;
                user.Location = _EditUser.Location;
                
                
                dbContext.SaveChanges();
                return RedirectToPage("/users/ListUsers");
            }

            return Page();


        }

        public IActionResult OnPostDelete()
        {
            var user = dbContext._Users.Find(_EditUser.Id);

            if (user != null)
            {
                dbContext._Users.Remove(user);
                dbContext.SaveChanges();
                return RedirectToPage("/users/ListUsers");
            }

            return Page();
        }


    }
}
