using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.stock;
using api.helpers;
using api.interfaces;
using api.model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositiory
{
    public class StockRepo(ApplicationDbContext context) : IStockRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Stock>> GetAllStock(QueryObject query)
        {
            var stocks = _context.Stocks.Include(e => e.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(e => e.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stocks = stocks.Where(e => e.ComapnyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol",StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(e => e.Symbol);
                }
            }
            return await stocks.ToListAsync();

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