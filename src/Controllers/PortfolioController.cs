using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Extensions;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Models;
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
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
        {
            this._userManager = userManager;
            this._stockRepository = stockRepository;
            this._porfolioRepository = portfolioRepository;
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
    }
}