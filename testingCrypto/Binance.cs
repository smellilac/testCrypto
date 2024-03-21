using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingCrypto;

using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Objects;
using System;
using System.Text.Json;

public class BinanceExchange : IExchange
{
    public async Task<string> GetBtcUsdtPair()
    {
        var restClient = new BinanceRestClient();
        var tickerResult = await restClient.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");

        if (tickerResult.Success && tickerResult.Data != null)
        {
            var jsonResult = JsonSerializer.Serialize(tickerResult.Data);
            return jsonResult;
        }

        return "Pair not found";
    }
}