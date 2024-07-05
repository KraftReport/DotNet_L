using Microsoft.AspNetCore.Mvc;
using StockApi.Data;
using StockApi.DTOs;
using StockApi.Interface;
using StockApi.Mapper;

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository stockRepository;
        public StockController(IStockRepository stock) 
        {
            stockRepository = stock;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStocks()
        {
            return Ok((await stockRepository.GetAllAsync()).Select(s => s.mapStockDTO())); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStock([FromRoute]int id)
        {
            return Ok((await stockRepository.GetByIdAsync(id)).mapStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> createAStock([FromBody]StockRequestDTO requestDTO)
        {
            await stockRepository.CreateAsync(requestDTO.MaptoStock()); 
            return CreatedAtAction(nameof(GetStock),new {id = requestDTO.MaptoStock().Id},requestDTO.MaptoStock().mapStockDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAStock([FromRoute]int id, [FromBody]StockUpdateDTO stockUpdateDTO)
        {
            return Ok((await stockRepository.UpdateAsync(id, stockUpdateDTO)).mapStockDTO());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAStock([FromRoute]int Id)
        {
            await stockRepository.DeleteAsync(Id);
            return NoContent();
        }

    }
}
