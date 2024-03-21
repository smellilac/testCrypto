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
                BinanceExchange binanceExchange = new BinanceExchange();
                result = await binanceExchange.GetBtcUsdtPrice();
                MessageBox.Show(result);
                break;
            case "Bybit":
                BybitExchange bybitExchange = new BybitExchange();
                result = await bybitExchange.GetBtcUsdtPair();
                MessageBox.Show(result);
                break;
            case "Kucoin":
                KucoinExchange kucoinExchange = new KucoinExchange();
                result = await kucoinExchange.GetBtcUsdtPair();
                MessageBox.Show(result);
                break;
            case "Bitget":
                BitgetExchange bitgetExchange = new BitgetExchange();
                result = await bitgetExchange.GetBtcUsdtPair();
                MessageBox.Show(result);
                break;
            default:
                MessageBox.Show("Unsupported exchange selected");
                break;
        }

        this.Invoke((MethodInvoker)delegate
        {
            textBox1.AppendText(result + Environment.NewLine);
        });
    }
}
