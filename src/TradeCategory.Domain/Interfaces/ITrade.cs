using System;

namespace TradeCategory.Domain.Interfaces
{
    public interface ITrade
    {
        double Value { get; }

        string ClientSector { get; }

        DateTime NextPaymentDate { get; }

        bool IsPoliticallyExposed { get; }
    }
}