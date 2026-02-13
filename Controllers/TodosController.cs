using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using abimanyu_todolist.Data;
using abimanyu_todolist.Models;

namespace abimanyu_todolist.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _context;

  
        public TodosController(TodoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _context.Todos.ToListAsync();
            return Ok(todos); // Mengembalikan 200 OK beserta data array JSON
        }

        // 2. GET TODO BY ID: GET /api/todos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound(new { message = "Data Todo tidak ditemukan" }); 
            }

            return Ok(todo); 
        }
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] Todo todo)
        {

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if (todo == null)
            {
                return NotFound(new { message = "Data Todo tidak ditemukan" }); // 404
            }


            todo.IsCompleted = true; 
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if (todo == null)
            {
                return NotFound(new { message = "Data Todo tidak ditemukan" }); // 404
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Todo berhasil dihapus" }); // 200 OK
        }
    }
}