﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netbanking.RemessaArquivo.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netbanking.RemessaArquivo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemessaItemsController : ControllerBase
    {
        private readonly RemessaContext _context;

        public RemessaItemsController(RemessaContext context)
        {
            _context = context;
        }

        // GET: api/RemessaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemessaItem>>> GetRemessaItems()
        {
            return await _context.RemessaItems.ToListAsync();
        }

        // GET: api/RemessaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RemessaItem>> GetRemessaItem(long id)
        {
            var remessaItem = await _context.RemessaItems.FindAsync(id);

            if (remessaItem == null)
            {
                return NotFound();
            }

            return remessaItem;
        }

        // PUT: api/RemessaItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemessaItem(long id, RemessaItem remessaItem)
        {
            if (id != remessaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(remessaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemessaItemExists(id))
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

        // POST: api/RemessaItems
        [HttpPost]
        public async Task<ActionResult<RemessaItem>> PostRemessaItem(RemessaItem remessaItem)
        {

            _context.RemessaItems.Add(remessaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRemessaItem), new { id = remessaItem.Id }, remessaItem);
        }

        // DELETE: api/RemessaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemessaItem(long id)
        {
            var remessaItem = await _context.RemessaItems.FindAsync(id);
            if (remessaItem == null)
            {
                return NotFound();
            }

            _context.RemessaItems.Remove(remessaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RemessaItemExists(long id)
        {
            return _context.RemessaItems.Any(e => e.Id == id);
        }
    }
}
