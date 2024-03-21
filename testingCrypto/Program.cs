namespace testingCrypto;

class Program
{
    static async Task Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1("Binance"));
        // Список базовых адресов для каждой биржи
        Dictionary<string, string> exchangeBaseUrls = new Dictionary<string, string>
            {
                {"Binance", "https://api.binance.com"},
                {"Bybit", "https://api.bybit.com"},
                {"Kucoin", "https://api.kucoin.com"},
                {"Bitget", "https://api.bitget.com"}
            };

        // Список эндпоинтов для каждой биржи
        Dictionary<string, string> exchangeEndpoints = new Dictionary<string, string>
            {
                {"Binance", "/api/v3/ticker/price?symbol=BTCUSDT"},
                {"Bybit", "/v2/public/tickers?symbol=BTCUSD"},
                {"Kucoin", "/api/v1/market/orderbook/level1?symbol=BTC-USDT"},
                {"Bitget", "/api/v1/ticker?contract=BTCUSDT"}
            };

        // Выберите биржу, с которой хотите работать
        string selectedExchange = "Bybit"; // Можно выбрать любую из доступных бирж

        if (exchangeBaseUrls.ContainsKey(selectedExchange) && exchangeEndpoints.ContainsKey(selectedExchange))
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(exchangeBaseUrls[selectedExchange]);

                while (true)
                {
                    HttpResponseMessage response = await client.GetAsync(exchangeEndpoints[selectedExchange]);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Error occurred: " + response.ReasonPhrase);
                    }

                    await Task.Delay(5000); // Пауза в 5 секунд между запросами
                }
            }
        }
        else
        {
            Console.WriteLine("Unsupported exchange selected");
        }
    }
}
