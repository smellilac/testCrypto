namespace testingCrypto;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using testingCryptol;

public partial class Form1 : Form
{
    private Timer timer;
    private string selectedExchange;
    private IExchange exchange;

    public Form1(string exchange)
    {
        InitializeComponent();
        textBox1.TextChanged += TextBox1_TextChanged;

        selectedExchange = exchange;

        timer = new Timer();
        timer.Interval = 5000;
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e) { }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        string result = "";

        switch (selectedExchange)
        {
            case "Binance":
                exchange = new BinanceExchange();
                break;
            case "Bybit":
                exchange = new BybitExchange();
                break;
            case "Kucoin":
                exchange = new KucoinExchange();
                break;
            case "Bitget":
                exchange = new BitgetExchange();
                break;
            default:
                MessageBox.Show("Unsupported exchange selected");
                break;
        }

        this.Invoke((MethodInvoker)async delegate
        {
            if (exchange != null)
            {
                string result = await exchange.GetBtcUsdtPair();
                textBox1.AppendText(result);
            }
        });
    }
}
