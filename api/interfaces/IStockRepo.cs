using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto.stock;
using api.helpers;
using api.model;

namespace api.interfaces
{
    public interface IStockRepo
    {
        Task<List<Stock>> GetAllStock(QueryObject query);
        Task<Stock?> GetStockById(int id);
        Task<Stock> AddStock(Stock stock);
        Task<Stock?> UpdateStock(int id, UpdateStockRequestDto updateStockRequestDto);
        Task<Stock?> DeleteStock(int id);
        Task<bool> IsStockExits(int id);

    }
}