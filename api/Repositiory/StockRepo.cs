using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.stock;
using api.interfaces;
using api.model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositiory
{
    public class StockRepo(ApplicationDbContext context) : IStockRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Stock>> GetAllStock()
        {
            return await _context.Stocks.Include(e => e.Comments).ToListAsync();

        }


        public async Task<Stock> AddStock(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(e => e.Id == id);
            if (stock == null)
            {
                return null;
            }
            else
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                return stock;
            }

        }


        public async Task<Stock?> GetStockById(int id)
        {
            var stock = await _context.Stocks.Include(e => e.Comments).FirstOrDefaultAsync(e => e.Id == id);
            if (stock == null)
            {
                return null;
            }
            else
            {
                return stock;
            }
        }

        public async Task<Stock?> UpdateStock(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            else
            {
                stock.Symbol = updateStockRequestDto.Symbol;
                stock.ComapnyName = updateStockRequestDto.ComapnyName;
                stock.Industry = updateStockRequestDto.Industry;
                stock.Purchase = updateStockRequestDto.Purchase;
                stock.LastDiv = updateStockRequestDto.LastDiv;
                stock.MarketCap = updateStockRequestDto.MarketCap;
                await _context.SaveChangesAsync();
                return stock;
            }

        }

        public async Task<bool> IsStockExits(int id)
        {
            return await _context.Stocks.AnyAsync(e => e.Id == id);
        }
    }
}