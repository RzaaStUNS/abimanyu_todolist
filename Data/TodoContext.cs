using Microsoft.EntityFrameworkCore;
using abimanyu_todolist.Models;

namespace abimanyu_todolist.Data
{
    public class TodoContext : DbContext
    {
        
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}