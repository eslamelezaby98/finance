using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.stock;
using api.mapper;
using api.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            var stockDyo = stocks.Select(e => e.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDto());
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStock([FromBody] CreateStockDto stockDto)
        {
            var stock = stockDto.ToStockFromCreateStockDto();
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStockRequestDto stockRequestDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                stock.Symbol = stockRequestDto.Symbol;
                stock.ComapnyName = stockRequestDto.ComapnyName;
                stock.Industry = stockRequestDto.Industry;
                stock.Purchase = stockRequestDto.Purchase;
                stock.LastDiv = stockRequestDto.LastDiv;
                stock.MarketCap = stockRequestDto.MarketCap;
                await _context.SaveChangesAsync();
                return Ok(stock.ToStockDto());
            }
        }


        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(e => e.Id == Id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}