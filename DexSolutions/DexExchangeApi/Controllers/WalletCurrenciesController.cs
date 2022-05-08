#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DexExchangeApi;
using DexExchangeApi.Data;

namespace DexExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletCurrenciesController : ControllerBase
    {
        private readonly DexExchangeApiContext _context;

        public WalletCurrenciesController(DexExchangeApiContext context)
        {
            _context = context;
        }

        // GET: api/WalletCurrencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletCurrency>>> GetWalletCurrency()
        {
            return await _context.WalletCurrency.ToListAsync();
        }

        // GET: api/WalletCurrencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WalletCurrency>> GetWalletCurrency(int id)
        {
            var walletCurrency = await _context.WalletCurrency.FindAsync(id);

            if (walletCurrency == null)
            {
                return NotFound();
            }

            return walletCurrency;
        }

        // PUT: api/WalletCurrencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalletCurrency(int id, WalletCurrency walletCurrency)
        {
            if (id != walletCurrency.WalletCurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(walletCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletCurrencyExists(id))
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

        // POST: api/WalletCurrencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WalletCurrency>> PostWalletCurrency(WalletCurrency walletCurrency)
        {
            _context.WalletCurrency.Add(walletCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWalletCurrency", new { id = walletCurrency.WalletCurrencyId }, walletCurrency);
        }

        // DELETE: api/WalletCurrencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalletCurrency(int id)
        {
            var walletCurrency = await _context.WalletCurrency.FindAsync(id);
            if (walletCurrency == null)
            {
                return NotFound();
            }

            _context.WalletCurrency.Remove(walletCurrency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WalletCurrencyExists(int id)
        {
            return _context.WalletCurrency.Any(e => e.WalletCurrencyId == id);
        }
    }
}
