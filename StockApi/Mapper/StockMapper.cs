using StockApi.DTOs;
using StockApi.Models;

namespace StockApi.Mapper
{
    public static class StockMapper
    {
        public static StockDTO mapStockDTO(this Stock stock)
        {
            return new StockDTO
            { 
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Purchase = stock.Purchase,
                Symbol = stock.Symbol
            };
        }

        public static Stock MaptoStock(this StockRequestDTO stockDTO)
        {
            return new Stock
            {
                CompanyName = stockDTO.CompanyName,
                Industry = stockDTO.Industry,
                LastDiv = stockDTO.LastDiv,
                MarketCap = stockDTO.MarketCap,
                Purchase = stockDTO.Purchase,
                Symbol = stockDTO.Symbol
            };

        }
    }
}
