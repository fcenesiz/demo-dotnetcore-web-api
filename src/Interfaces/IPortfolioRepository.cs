using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Models;

namespace demo_dotnetcore_web_api.src.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPorfolio(AppUser appUser);
    }
}