using System;
using System.Collections.Generic;
using System.Linq;

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }

#region Portfolio

// simple generic portfolio
public class Portfolio<T> where T : IFinancialInstrument
{
    // instrument -> quantity we own
    private Dictionary<T, int> _holdings = new();

    public void Buy(T instrument, int quantity, decimal price)
    {
        // basic validation
        if (quantity <= 0 || price <= 0)
            throw new Exception("Invalid buy values");

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;

        Console.WriteLine($"Bought {quantity} of {instrument.Symbol}");
    }

    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        // check if we even have this
        if (!_holdings.ContainsKey(instrument) ||
            _holdings[instrument] < quantity)
        {
            Console.WriteLine("Not enough quantity to sell");
            return null;
        }

        _holdings[instrument] -= quantity;

        // remove if zero left
        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        decimal money = quantity * currentPrice;
        Console.WriteLine($"Sold {quantity} of {instrument.Symbol}");

        return money;
    }

    public decimal CalculateTotalValue()
    {
        decimal total = 0;

        foreach (var h in _holdings)
            total += h.Key.CurrentPrice * h.Value;

        return total;
    }

    // just comparing buy price vs current price
    public (T instrument, decimal returnPercentage)?
        GetTopPerformer(Dictionary<T, decimal> purchasePrices)
    {
        if (!_holdings.Any())
            return null;

        T best = default;
        decimal bestReturn = decimal.MinValue;

        foreach (var h in _holdings)
        {
            if (!purchasePrices.ContainsKey(h.Key))
                continue;

            decimal buyPrice = purchasePrices[h.Key];

            decimal ret =
                ((h.Key.CurrentPrice - buyPrice) / buyPrice) * 100;

            if (ret > bestReturn)
            {
                bestReturn = ret;
                best = h.Key;
            }
        }

        return (best, bestReturn);
    }

    public IEnumerable<T> Instruments => _holdings.Keys;
}

#endregion

#region Instruments

public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;

    // extra stock info
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;

    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

#endregion

#region Trading Strategy

public class TradingStrategy<T> where T : IFinancialInstrument
{
    // super simple strategy execution
    public void Execute(
        Portfolio<T> portfolio,
        IEnumerable<T> marketData,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        foreach (var instrument in marketData)
        {
            if (buyCondition(instrument))
                portfolio.Buy(instrument, 5, instrument.CurrentPrice);

            if (sellCondition(instrument))
                portfolio.Sell(instrument, 3, instrument.CurrentPrice);
        }
    }

    // fake/simple risk calculation
    public Dictionary<string, decimal>
        CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        decimal avg = prices.Average();

        decimal variance = prices
            .Select(p => (p - avg) * (p - avg))
            .Average();

        decimal volatility = (decimal)Math.Sqrt((double)variance);

        decimal sharpe = volatility == 0 ? 0 : avg / volatility;

        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", 1 }, // placeholder honestly
            { "SharpeRatio", sharpe }
        };
    }
}

#endregion

#region Price History

public enum Trend { Upward, Downward, Sideways }

public class PriceHistory<T> where T : IFinancialInstrument
{
    // store time series prices
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    public void AddPrice(T instrument, DateTime time, decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();

        _history[instrument].Add((time, price));
    }

    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (!_history.ContainsKey(instrument))
            return null;

        var recent = _history[instrument]
            .OrderByDescending(h => h.Item1)
            .Take(days)
            .Select(h => h.Item2);

        return recent.Any() ? recent.Average() : null;
    }

    public Trend DetectTrend(T instrument, int period)
    {
        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var prices = _history[instrument]
            .OrderByDescending(h => h.Item1)
            .Take(period)
            .Select(h => h.Item2)
            .ToList();

        if (prices.Count < 2)
            return Trend.Sideways;

        decimal oldPrice = prices.Last();
        decimal newPrice = prices.First();

        if (newPrice > oldPrice) return Trend.Upward;
        if (newPrice < oldPrice) return Trend.Downward;

        return Trend.Sideways;
    }
}

#endregion

#region Demo

class Program
{
    static void Main()
    {
        var apple = new Stock
        {
            Symbol = "AAPL",
            CurrentPrice = 180,
            CompanyName = "Apple"
        };

        var bond = new Bond
        {
            Symbol = "GOV10Y",
            CurrentPrice = 102,
            MaturityDate = DateTime.Now.AddYears(10)
        };

        var portfolio = new Portfolio<IFinancialInstrument>();

        portfolio.Buy(apple, 20, 170);
        portfolio.Buy(bond, 10, 100);

        Console.WriteLine("\nTotal Value: " +
            portfolio.CalculateTotalValue());

        var buyPrices = new Dictionary<IFinancialInstrument, decimal>
        {
            [apple] = 170,
            [bond] = 100
        };

        var best = portfolio.GetTopPerformer(buyPrices);

        Console.WriteLine($"Best performer: {best?.instrument.Symbol}");

        // simple strategy example
        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(
            portfolio,
            new List<IFinancialInstrument> { apple, bond },
            i => i.CurrentPrice < 150,
            i => i.CurrentPrice > 175
        );

        // price history example
        var history = new PriceHistory<IFinancialInstrument>();

        history.AddPrice(apple, DateTime.Today.AddDays(-3), 170);
        history.AddPrice(apple, DateTime.Today.AddDays(-2), 175);
        history.AddPrice(apple, DateTime.Today.AddDays(-1), 180);

        Console.WriteLine("Moving Avg: " +
            history.GetMovingAverage(apple, 3));

        Console.WriteLine("Trend: " +
            history.DetectTrend(apple, 3));
    }
}

#endregion
