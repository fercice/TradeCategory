using System;
using TradeCategory.Models;

namespace TradeCategory.Domain.Interfaces
{
    public interface ITradeService
    {
        string Trade(DateTime referenceDate, Trade trade);
    }
}