using System;
using TradeCategory.Domain.Interfaces;

namespace TradeCategory.Models
{
    public class Trade : ITrade
    {
        public Trade() { }

        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliticallyExposed { get;  set; }
    }
}
