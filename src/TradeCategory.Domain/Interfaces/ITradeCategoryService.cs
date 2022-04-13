using System;
using TradeCategory.Models;

namespace TradeCategory.Domain.Interfaces
{
    public interface ITradeCategoryService
    {
        string CategorizeTrade(DateTime referenceDate, Trade trade);
    }
}