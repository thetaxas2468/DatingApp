using DatingAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppBackend.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
    }
}
