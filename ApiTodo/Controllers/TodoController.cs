using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;



[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
private readonly TodoContext _context;
public TodoController(TodoContext context)
{
_context = context;
}


// GET: api/todo/2
[HttpGet("{id}")]
[SwaggerOperation(Summary = "Get a todo by id", Description = "Returns a specific item targeted by its identifier")]
[SwaggerResponse(StatusCodes.Status200OK, "Item found", typeof(Todo))]
[SwaggerResponse(StatusCodes.Status404NotFound, "Item not found")]

public async Task<ActionResult<Todo>> GetItem([SwaggerParameter("The unique identifier of the item", Required=true)] int id)
{
// Find a specific item
// SingleAsync() throws an exception if no item is found (which is possible, depending on id)
// SingleOrDefaultAsync() is a safer choice here
var item = await _context.Todo.SingleOrDefaultAsync(t => t.Id == id);


if (item == null)
return NotFound();


return item;
}

// POST: api/item
[HttpPost]
[SwaggerOperation(Summary = "Create a new todo", Description ="Create a new todo")]
public async Task<ActionResult<Todo>> PostItem(Todo item)
{
_context.Todo.Add(item);
await _context.SaveChangesAsync();


return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
}

// PUT: api/item/2
[HttpPut("{id}")]
[SwaggerOperation(Summary = "Update a todo", Description = "Update a specific item targeted by its identifier")]

public async Task<IActionResult> PutItem(int id, Todo item)
{
if (id != item.Id)
return BadRequest();


_context.Entry(item).State = EntityState.Modified;


try
{
await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException)
{
if (!_context.Todo.Any(m => m.Id == id))
return NotFound();
else
throw;
}


return NoContent();
}

// DELETE: api/item/2
[HttpDelete("{id}")]
[SwaggerOperation(Summary = "Delete a todo", Description = "Delete a todo and related list")]
[SwaggerResponse(StatusCodes.Status204NoContent, "Todo deleted")]
[SwaggerResponse(StatusCodes.Status404NotFound, "Todo not found")]

public async Task<IActionResult> DeleteItem([SwaggerParameter(Description ="The todo id")] int id)
{
var item = await _context.Todo.FindAsync(id);


if (item == null)
return NotFound();


_context.Todo.Remove(item);
await _context.SaveChangesAsync();


return NoContent();
}


// GET: api/todo
[HttpGet]
[SwaggerOperation(Summary = "Get all Todos", Description = "Returns all todos")]

public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
{
// Get items
var todos = _context.Todo;
return await todos.ToListAsync();
}
}


