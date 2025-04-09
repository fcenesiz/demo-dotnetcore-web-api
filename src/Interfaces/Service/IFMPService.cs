using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;

namespace demo_dotnetcore_web_api.src.Interfaces.Service
{
    // Financial Modeling Prep Service
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}