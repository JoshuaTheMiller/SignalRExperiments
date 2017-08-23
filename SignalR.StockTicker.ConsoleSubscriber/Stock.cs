using System;

namespace SignalR.StockTicker.ConsoleSubscriber
{
    public class Stock
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }
    }
}