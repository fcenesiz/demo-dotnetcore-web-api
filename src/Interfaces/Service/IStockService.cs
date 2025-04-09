using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Stock;
using demo_dotnetcore_web_api.src.Helpers;

namespace demo_dotnetcore_web_api.src.Interfaces
{
    public interface IStockService
    {
        Task<Pagination<StockDto>> GetAllAsync(StockQueryObject query);
        Task<StockDto?> GetByIdAsync(int id);
        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<StockDto> CreateAsync(CreateStockRequestDto stockModel);
        Task<StockDto> CreateAsync(Stock stockModel);
        Task<StockDto?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExistsAsync(int id);
    }
}