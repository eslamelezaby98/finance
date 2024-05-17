using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto.stock;
using api.model;

namespace api.mapper
{
    public static class StockMapper
    {
        public static StockDtos ToStockDto(this Stock stock)
        {
            return new StockDtos
            {
                Id = stock.Id,
                ComapnyName = stock.ComapnyName,
                Industry = stock.Industry,
                LastDiv = stock.LastDiv,
                Symbol = stock.Symbol,
                Purchase = stock.Purchase,
                MarketCap = stock.MarketCap,
            };
        }

        public static Stock ToStockFromCreateStockDto(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Symbol = createStockDto.Symbol,
                ComapnyName = createStockDto.ComapnyName,
                Industry = createStockDto.Industry,
                Purchase = createStockDto.Purchase,
                LastDiv = createStockDto.LastDiv,
                MarketCap = createStockDto.MarketCap,

            };
        }

        public static Stock ToStockFromUpdateStockDto(this UpdateStockRequestDto updateStockRequestDto)
        {
            return new Stock
            {
                Symbol = updateStockRequestDto.Symbol,
                ComapnyName = updateStockRequestDto.ComapnyName,
                Industry = updateStockRequestDto.Industry,
                Purchase = updateStockRequestDto.Purchase,
                LastDiv = updateStockRequestDto.LastDiv,
                MarketCap = updateStockRequestDto.MarketCap,
            };
        }
    }
}