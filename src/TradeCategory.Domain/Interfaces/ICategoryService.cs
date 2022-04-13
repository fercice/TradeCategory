using System;

namespace TradeCategory.Domain.Interfaces
{
    public interface ICategoryService
    {
        bool IsExpired(DateTime referenceDate, DateTime nextPaymentDate);

        bool IsHighRisk(double value, string clientSector);

        bool IsMediumRisk(double value, string clientSector);

        bool IsPoliticallyExposedPerson(bool isPoliticallyExposed);
    }
}