using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Stock;

namespace demo_dotnetcore_web_api.src.Interfaces
{
    public interface IStockService
    {
        Task<List<StockDto>> GetAllAsync();
        Task<StockDto?> GetByIdAsync(int id);
        Task<StockDto> CreateAsync(CreateStockRequestDto stockModel);
        Task<StockDto?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto);
        Task<Stock?> DeleteAsync(int id);
    }
}