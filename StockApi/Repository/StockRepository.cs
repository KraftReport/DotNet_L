using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using StockApi.DTOs;
using StockApi.Interface;
using StockApi.Mapper;
using StockApi.Models;
namespace StockApi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.stocks.ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int Id)
        {
            return await _context.stocks.FindAsync(Id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> UpdateAsync(int id,StockUpdateDTO stockUpdateDTO)
        {
            var found = await _context.stocks.FindAsync(id);
            found.Symbol = stockUpdateDTO.Symbol;
            found.MarketCap = stockUpdateDTO.MarketCap;
            found.Purchase = stockUpdateDTO.Purchase;
            found.Industry = stockUpdateDTO.Industry;
            found.CompanyName = stockUpdateDTO.CompanyName;
            found.LastDiv = stockUpdateDTO.LastDiv;
            await _context.SaveChangesAsync(); 
            return await _context.stocks.FindAsync(id);
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var found = await _context.stocks.FindAsync(id);
             _context.Remove(found);
            await _context.SaveChangesAsync();
            return new Stock();
        }

    }
}
