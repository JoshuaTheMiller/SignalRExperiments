using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalR.StockTicker.ConsoleSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStuff().Wait();

            Console.ReadKey();
        }

        private static async Task DoStuff()
        {
            var hubConnection = new HubConnection("http://localhost:2713/");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("stockTickerMini");
            stockTickerHubProxy.On<Stock>("UpdateStockPrice", UpdateStockFeed);
            await hubConnection.Start();
        }

        private static void UpdateStockFeed(Stock stock)
        {
            Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price);
        }
    }
}
