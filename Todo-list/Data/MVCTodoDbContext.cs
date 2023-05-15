//DbContextClass(Acts as bridge between entity framework core and database | enables to talk with database)

using Microsoft.EntityFrameworkCore;
using Todo_list.Models.Domain;

namespace Todo_list.Data
{
    public class MVCTodoDbContext : DbContext
    {
        public MVCTodoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
        //Todos is the table name that gets created
    }
}
