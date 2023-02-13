using botWhatsapp.DataAccess.Abstractions.Entities;
using botWhatsapp.Entities;
using GT.Transversal;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace botWhatsapp.DataAccess.DbContext
{
    public class botDbContext : DbContextBase
    {
        public botDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Option> Options => Set<Option>();
        public DbSet<Conversation> Conversations => Set<Conversation>();
        public DbSet<Response> Responses => Set<Response>();
    }
}
