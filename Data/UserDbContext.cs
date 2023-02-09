using Meritsios_2._0.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meritsios_2._0.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> _Users { get; set; }
    }

}
