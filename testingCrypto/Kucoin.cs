using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingCrypto;

using CryptoExchange.Net.Interfaces;
using Kucoin.Net;
using Kucoin.Net.Clients;
using Kucoin.Net.Objects;
using System;
using System.Text.Json;

public class KucoinExchange
{
    public async Task<string> GetBtcUsdtPair()
    {
        var client = new KucoinRestClient();
        var tradingPairsResult = await client.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");

        if (tradingPairsResult.Success && tradingPairsResult.Data != null)
        {
            var jsonResult = JsonSerializer.Serialize(tradingPairsResult.Data);
            return jsonResult;
        }

        return "Pair not found";
    }
}