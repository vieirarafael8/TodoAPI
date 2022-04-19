using DevotugasDaStreet.TodoTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly TodoContext _context;

        public ToDoItemController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetToDoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/ToDoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetToDoItem(int id)
        {
            var toDoItemModel = await _context.TodoItems.FindAsync(id);

            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return toDoItemModel;
        }

        // PUT: api/ToDoItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, TodoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItem
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostToDoItem(TodoItem toDoItem)
        {
            _context.TodoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItemModel", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItemModel = await _context.TodoItems.FindAsync(id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(toDoItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}