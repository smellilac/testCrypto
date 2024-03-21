using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingCrypto;

using Bybit.Net;
using Bybit.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Text.Json;

public class BybitExchange
{
    public async Task<string> GetBtcUsdtPair()
    {
        var restClient = new BybitRestClient();
        var tickerResult = await restClient.V5Api.ExchangeData.GetSpotTickersAsync("BTCUSDT");

        if (tickerResult.Success && tickerResult.Data != null)
        {
            var jsonResult = JsonSerializer.Serialize(tickerResult.Data);
            return jsonResult;
        }

        return "Pair not found";
    }
}
