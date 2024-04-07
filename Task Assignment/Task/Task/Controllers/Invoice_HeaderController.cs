using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice_HeaderController : ControllerBase
    {
        private readonly New_CompanyDB _context;

        public Invoice_HeaderController(New_CompanyDB context)
        {
            _context = context;
        }

        // GET: api/Invoice_Header
        [HttpGet]
        public IActionResult GetAll()
        {
            var allInvoiceHeaders = _context.InvoiceHeaders.ToList();
            return Ok(allInvoiceHeaders);
        }
        // GET: api/Invoice_Header/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var invoiceHeader = await _context.InvoiceHeaders.FindAsync(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }
            return Ok(invoiceHeader);
        }
        //ADD
        // POST: api/Invoice_Header
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Invoice_Header invoiceHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvoiceHeaders.Add(invoiceHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOne), new { id = invoiceHeader.Serial }, invoiceHeader);
        }
        //Update
        // PUT: api/Invoice_Header/id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Invoice_Header invoiceHeader)
        {
            if (id != invoiceHeader.Serial)
            {
                return BadRequest();
            }

            _context.Entry(invoiceHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InvoiceHeaders.Any(i => i.Serial == id))
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

        // DELETE: api/Invoice_Header/id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceHeader = await _context.InvoiceHeaders.FindAsync(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }

            _context.InvoiceHeaders.Remove(invoiceHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
