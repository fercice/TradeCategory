using System;
using TradeCategory.Application.Interfaces;

namespace TradeCategory.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        public CategoryAppService() { }

        public bool IsExpired(DateTime referenceDate, DateTime nextPaymentDate) => nextPaymentDate.AddDays(30) < referenceDate ? true : false;

        public bool IsHighRisk(double value, string clientSector) => (value > 1000000 && clientSector.ToUpper() == "PRIVATE") ? true : false;

        public bool IsMediumRisk(double value, string clientSector) => (value > 1000000 && clientSector.ToUpper() == "PUBLIC") ? true : false;

        public bool IsPoliticallyExposedPerson(bool isPoliticallyExposed) => isPoliticallyExposed ? true : false;        
    }
}