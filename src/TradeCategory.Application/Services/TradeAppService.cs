using System;
using TradeCategory.Application.Interfaces;
using TradeCategory.Models;

namespace TradeCategory.Application.Services
{
    public class TradeAppService : ITradeAppService
    {
        private readonly ITradeCategoryAppService _tradeCategoryAppService;

        public TradeAppService(ITradeCategoryAppService tradeCategoryAppService) 
        {
            _tradeCategoryAppService = tradeCategoryAppService;
        }

        public string Trade(DateTime referenceDate, Trade trade) => _tradeCategoryAppService.CategorizeTrade(referenceDate, trade);
    }
}