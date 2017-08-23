using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SignalR.StockTicker.WpfSubscriber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();      
            
            this.Loaded += PopulateStockFeed;
            this.Unloaded -= PopulateStockFeed;
        }

        private async void PopulateStockFeed(object sender, RoutedEventArgs e)
        {
            await DoStuffAsync();
        }

        private async Task DoStuffAsync()
        {
            var hubConnection = new HubConnection("http://localhost:2713/");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("stockTickerMini");
            stockTickerHubProxy.On<Stock>("UpdateStockPrice", UpdateStockFeed);
            await hubConnection.Start();
        }

        private void UpdateStockFeed(Stock stock)
        {
            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                StockTickerFeed.Items.Add($"Stock update for {stock.Symbol} new price {stock.Price}");
            }));
        }
    }
}
