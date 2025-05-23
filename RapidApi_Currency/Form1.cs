﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace RapidApi_Currency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal dollar = 0;
        decimal euro = 0;
        decimal sterlin = 0;


        private async void Form1_Load(object sender, EventArgs e)
        {
            //Dollar
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "ee46bfe5f8msh9847dc72b78f403p12245cjsn61d2010bb2e7" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(body).;

                var json = JObject.Parse(body);
                var value = json["result"].ToString();
                lblDollar.Text = "Dollar: " + value;
                dollar = decimal.Parse(value);
            }

            // Euro
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "ee46bfe5f8msh9847dc72b78f403p12245cjsn61d2010bb2e7" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();
                //Console.WriteLine(body).;

                var json = JObject.Parse(body);
                var value = json["result"].ToString();
                lblEuro.Text = "Euro: " + value;
                euro = decimal.Parse(value);
            }

            //Sterlin
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=GBP&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "ee46bfe5f8msh9847dc72b78f403p12245cjsn61d2010bb2e7" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                //Console.WriteLine(body).;

                var json = JObject.Parse(body);
                var value = json["result"].ToString();
                lblSterlin.Text = "Sterlin: " + value;
                sterlin = decimal.Parse(value);
            }
            txtTotalPrice.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
          
            decimal totalPrice = 0;


            if (rdbDollar.Checked)
            {
                totalPrice = unitPrice * dollar;
            }
            else if (rdbEuro.Checked)
            {
                totalPrice = unitPrice * euro;
            }
            else if (rdbSterlin.Checked)
            {
                totalPrice = unitPrice * sterlin;
            }

            txtTotalPrice.Text = totalPrice.ToString("0.00");
        }
    }
}


