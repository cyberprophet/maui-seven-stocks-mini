using System;
using System.Collections.Generic;

namespace DevExpress.Maui.Demo.Stocks
{
    public class MainViewModel
    {
        public IList<CollectionItemViewModel> Items
        {
            get; set;
        }
        public MainViewModel()
        {
            Items = new List<CollectionItemViewModel>();

            foreach (Symbol symbol in Data.Symbols)
            {
                var symbolViewModel = new CollectionItemViewModel
                {
                    Ticker = symbol.Ticker,
                    CompanyName = symbol.Name,
                    Change = symbol.Prices[0].Close - symbol.Prices[1].Close,
                    ChangePercent = symbol.Prices[0].Close / symbol.Prices[1].Close - 1,
                    Date = symbol.Prices[0].Date,
                    ClosePrice = symbol.Prices[0].Close
                };
                Items.Add(symbolViewModel);
            }
        }
    }
    public class CollectionItemViewModel
    {
        public string Ticker
        {
            get; set;
        }
        public string CompanyName
        {
            get; set;
        }
        public double ClosePrice
        {
            get; set;
        }
        public double Change
        {
            get; set;
        }
        public double ChangePercent
        {
            get; set;
        }
        public DateTime Date
        {
            get; set;
        }
    }
}