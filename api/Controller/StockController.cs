using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.stock;
using api.interfaces;
using api.mapper;
using api.model;
using api.Repositiory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(ApplicationDbContext context, IStockRepo stockRepo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IStockRepo _stockRepo = stockRepo;


        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _stockRepo.GetAllStock();
            var stockDyo = stocks.Select(e => e.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStockById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetStockById(id);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = stockDto.ToStockFromCreateStockDto();
            await _stockRepo.AddStock(stock);
            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStockRequestDto stockRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.UpdateStock(Id, stockRequestDto);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock.ToStockDto());
            }
        }


        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.DeleteStock(Id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}