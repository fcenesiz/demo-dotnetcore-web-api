using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Data;
using demo_dotnetcore_web_api.src.Dtos.Stock;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_dotnetcore_web_api.src.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {


        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {

            this._stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocksDto = await _stockService.GetAllAsync();
            return Ok(stocksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stockDto = await _stockService.GetByIdAsync(id);
            if (stockDto == null)
            {
                return NotFound();
            }
            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var createdStockDto = await _stockService.CreateAsync(stockDto);
            return CreatedAtAction(nameof(GetById), new { id = createdStockDto.Id }, createdStockDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockDto = await _stockService.UpdateAsync(id, updateDto);
            if (stockDto == null)
            {
                return NotFound();
            }
            return Ok(stockDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockService.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}