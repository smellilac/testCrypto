using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingCryptol;

using Bitget.Net.Clients;
using System;
using System.Text.Json;

public class BitgetExchange
{
    public async Task<string> GetBtcUsdtPair()
    {
        var restClient = new BitgetRestClient();
        var tickerResult = await restClient.SpotApi.ExchangeData.GetTickerAsync("BTCUSDT");

        if (tickerResult.Success && tickerResult.Data != null)
        {
            var jsonResult = JsonSerializer.Serialize(tickerResult.Data);
            return jsonResult;
        }

        return "Pair not found";
    }
}