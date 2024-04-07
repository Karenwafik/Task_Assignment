using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice_DetailsController : ControllerBase
    {
        private readonly New_CompanyDB _context;

        public Invoice_DetailsController(New_CompanyDB context)
        {
            _context = context;
        }

        // GET: api/Invoice_Details
        [HttpGet]
        public IActionResult GetAll()
        {
            var allInvoiceDetails = _context.InvoiceDetails.ToList();
            return Ok(allInvoiceDetails);
        }

        // GET: api/Invoice_Details/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            return Ok(invoiceDetail);
        }
        //ADD
        // POST: api/Invoice_Details
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Invoice_Details invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOne), new { id = invoiceDetail.InvoiceDetailId }, invoiceDetail);
        }
        //Update
        // PUT: api/Invoice_Details/id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Invoice_Details invoiceDetail)
        {
            if (id != invoiceDetail.InvoiceDetailId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InvoiceDetails.Any(i => i.InvoiceDetailId == id))
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

        // DELETE: api/Invoice_Details/id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            _context.InvoiceDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
       

