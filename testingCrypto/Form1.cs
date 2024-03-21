namespace testingCrypto;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
public partial class Form1 : Form
{ 

    private HttpClient client;
    private Timer timer;

    public Form1()
    {
        InitializeComponent();
        textBox1.TextChanged += textBox1_TextChanged;

        client = new HttpClient();
        client.BaseAddress = new Uri("https://api.binance.com");

        timer = new Timer();
        timer.Interval = 5000; // 5 секунд
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    public void textBox1_TextChanged(object sender, EventArgs e) { }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        HttpResponseMessage response = await client.GetAsync("/api/v3/ticker/price?symbol=BTCUSDT");

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();

            // Обновление UI в главном потоке
            this.Invoke((MethodInvoker)delegate
            {
                textBox1.AppendText(result + Environment.NewLine); // Выводим результат в TextBox на форме
            });
        }
        else
        {
            MessageBox.Show("Error occurred: " + response.ReasonPhrase);
        }

    }
}