namespace testingCrypto;

class Program
{
    static async Task Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://api.binance.com");

            while (true)
            {
                HttpResponseMessage response = await client.GetAsync("/api/v3/ticker/price?symbol=BTCUSDT");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Error occurred: " + response.ReasonPhrase);
                }

                await Task.Delay(5000); // Пауза в 5 секунд перед отправкой следующего запроса
            }
        }
    }
}