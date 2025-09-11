using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemindMeApi.Data;
using RemindMeApi.Models;

namespace RemindMeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            return await _context.TaskItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
    }
}
