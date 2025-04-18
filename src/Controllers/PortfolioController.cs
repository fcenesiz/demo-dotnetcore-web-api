using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Extensions;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Interfaces.Service;
using demo_dotnetcore_web_api.src.Models;
using demo_dotnetcore_web_api.src.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace demo_dotnetcore_web_api.src.Controllers
{

    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _porfolioRepository;
        private readonly IFMPService _fMPService;
        public PortfolioController(
            UserManager<AppUser> userManager,
             IStockRepository stockRepository,
              IPortfolioRepository portfolioRepository,
              IFMPService fMPService
        )
        {
            this._userManager = userManager;
            this._stockRepository = stockRepository;
            this._porfolioRepository = portfolioRepository;
            this._fMPService = fMPService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPorfolio = await _porfolioRepository.GetUserPorfolio(appUser);

            return Ok(userPorfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                stock = await _fMPService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return null;
                }
                await _stockRepository.CreateAsync(stock);
            }

            if (stock == null)
            {
                return BadRequest("Stock not found");
            }

            var userPortfolio = await _porfolioRepository.GetUserPorfolio(appUser);

            if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Can not add same stock to portfolio");
            }

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };
            await _porfolioRepository.CreateAsync(portfolioModel);
            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _porfolioRepository.GetUserPorfolio(appUser);
            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();

            if (filteredStock.Count() == 1)
            {
                await _porfolioRepository.DeletePortfolio(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock is not in your portfolio");
            }

            return Ok();

        }

    }
}