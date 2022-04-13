using System;
using TradeCategory.Domain.Enums;
using TradeCategory.Application.Interfaces;
using TradeCategory.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TradeCategory.Application.Services
{
    public class TradeCategoryAppService : ITradeCategoryAppService
    {
        private readonly ICategoryAppService _categoryAppService;

        public TradeCategoryAppService(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public string CategorizeTrade(DateTime referenceDate, Trade trade)
        {
            if (_categoryAppService.IsPoliticallyExposedPerson(trade.IsPoliticallyExposed))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.PEP);

            if (_categoryAppService.IsExpired(referenceDate, trade.NextPaymentDate))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.EXPIRED);

            if (_categoryAppService.IsHighRisk(trade.Value, trade.ClientSector))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.HIGHRISK);

            if (_categoryAppService.IsMediumRisk(trade.Value, trade.ClientSector))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.MEDIUMRISK);            

            return string.Empty;
        }
    }
}