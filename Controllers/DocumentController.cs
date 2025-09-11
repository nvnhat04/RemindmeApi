using Microsoft.AspNetCore.Mvc;
using RemindMeApi.Data;
using RemindMeApi.Models;
using Microsoft.EntityFrameworkCore;
namespace RemindMeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DocumentController : ControllerBase
    {

        private readonly AppDbContext _context;

        public DocumentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var docs = await _context.Documents.ToListAsync();
            return Ok(docs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null)
            {
                return NotFound(new { message = "Not found document" });
            }
            return Ok(doc);
        }
        // Tạo doc mới
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] Document request)
        {
            request.UpdatedAt = DateTime.UtcNow;
            _context.Documents.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDocument), new { id = request.Id }, request);
        }

        // Cập nhật doc
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] Document request)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null) return NotFound();

            doc.Title = request.Title;
            doc.Content = request.Content;
            doc.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(doc);
        }

        // Xóa doc
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var doc = await _context.Documents.FindAsync(id);
            if (doc == null) return NotFound();

            _context.Documents.Remove(doc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
