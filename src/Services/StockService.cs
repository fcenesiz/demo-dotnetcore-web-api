using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Stock;
using demo_dotnetcore_web_api.src.Helpers;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Mappers;

namespace demo_dotnetcore_web_api.src.Services
{
    // Logging
    // Mapping
    // Validation
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        public async Task<StockDto> CreateAsync(CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            var createdStock = await _stockRepository.CreateAsync(stockModel);
            return createdStock.ToStockDto();
        }

        public async Task<StockDto> CreateAsync(Stock stockModel)
        {

            var createdStock = await _stockRepository.CreateAsync(stockModel);
            return createdStock.ToStockDto();
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            return await _stockRepository.DeleteAsync(id);
        }

        public async Task<Pagination<StockDto>> GetAllAsync(StockQueryObject query)
        {
            var stocks = await _stockRepository.GetAllAsync(query);
            var stocksDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Pagination<StockDto>.Paginate(stocksDto, query.Page, query.PageSize);
        }

        public async Task<StockDto?> GetByIdAsync(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return null;
            }
            return stock.ToStockDto();
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            var stock = await _stockRepository.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                return null;
            }
            return stock;
        }

        public async Task<bool> StockExistsAsync(int id)
        {
            return await _stockRepository.StockExistsAsync(id);
        }

        public async Task<StockDto?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto)
        {
            var stockModel = await _stockRepository.UpdateAsync(id, stockRequestDto);
            if (stockModel == null)
            {
                return null;
            }
            return stockModel.ToStockDto();
        }
    }
}