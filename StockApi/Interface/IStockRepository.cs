using StockApi.DTOs;
using StockApi.Models;

namespace StockApi.Interface
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id); 
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, StockUpdateDTO stockDto);
        Task<Stock?> DeleteAsync(int id); 
    }
}
