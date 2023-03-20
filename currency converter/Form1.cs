using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace currency_converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Converter converter = new Converter(comboBox1.Text, comboBox2.Text, textBox1.Text);

                textBox2.Text = converter.Calculate().ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
    }

    class Converter
    {
        private string currencyFrom;
        private string currencyTo;
        private double amount;

        public Converter(string currencyFrom, string currencyTo, string amount)
        {
            if (currencyFrom == "" || currencyTo == "" || amount == "")
                throw new Exception("Выберите конвертируемы валюты и укажите исходное значение!");

            this.currencyFrom = currencyFrom.Substring(0,3);
            this.currencyTo = currencyTo.Substring(0,3);
            this.amount = double.Parse(amount);
        }
        private double GetExchangeRate(string currency)
        {
            switch (currency)
            {
                case "USD": return 1.0;
                case "EUR": return 0.85;
                case "GBP": return 0.72;
                case "JPY": return 110.0;
                case "AUD": return 1.3;
                case "CAD": return 1.25;
                case "CHF": return 0.92;
                case "CNY": return 6.5;
                case "NZD": return 1.4;
                case "SEK": return 8.5;
                default : return 1.0;
            }
        }

        public double Calculate()
        {
            double rateFrom = GetExchangeRate(currencyFrom);
            double rateTo = GetExchangeRate(currencyTo);

            return amount * rateFrom / rateTo;
        }
    }
}
