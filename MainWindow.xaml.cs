using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace Api
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Api();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        private async void Api()
        {
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Moscow&APPID=5431bc932d01f2d8b07a5818e24e4f52");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();
            temp.Content = answer;

            Image finalImage = new Image();
            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            temp.Content = oW.main.temp.ToString("0.##") + "°C";

            weather.Content = oW.weather[0].main;
            if (oW.weather[0].main == "Clear")
            {
                weather.Content = "Ясно";
            }
            if (oW.weather[0].main == "Clouds")
            {
                weather.Content = "Облачно";
            }

            city.Content = oW.name + ", " + oW.sys.country;

            gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

            speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

            humid.Content = "Влажность: " + oW.main.humidity + "%";
        }

        //часы
        void timer_Tick(object sender, EventArgs e)
        {
            timel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private async void searchb_Click(object sender, RoutedEventArgs e)
        {
            string text = Convert.ToString(search.Text);
            string url = @"http://api.openweathermap.org/data/2.5/weather?q=" + text + "&APPID=5431bc932d01f2d8b07a5818e24e4f52";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            if (text == "" || text == " ")
            {
                text = "Moscow";
            }

            response.Close();
            temp.Content = answer;

            Image finalImage = new Image();
            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            temp.Content = oW.main.temp.ToString("0.##") + "°C";

            weather.Content = oW.weather[0].main;
            if (oW.weather[0].main == "Clear")
            {
                weather.Content = "Ясно";
            }
            if (oW.weather[0].main == "Clouds")
            {
                weather.Content = "Облачно";
            }

            city.Content = oW.name + ", " + oW.sys.country;

            gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

            speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

            humid.Content = "Влажность: " + oW.main.humidity + "%";
        }

        private async void searchb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string text = Convert.ToString(search.Text);
                string url = @"http://api.openweathermap.org/data/2.5/weather?q=" + text + "&APPID=5431bc932d01f2d8b07a5818e24e4f52";
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";
                WebResponse response = await request.GetResponseAsync();
                string answer = string.Empty;
                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                if (text == "" || text == " ")
                {
                    text = "Moscow";
                }

                response.Close();
                temp.Content = answer;

                Image finalImage = new Image();
                OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                temp.Content = oW.main.temp.ToString("0.##") + "°C";

                weather.Content = oW.weather[0].main;
                if (oW.weather[0].main == "Clear")
                {
                    weather.Content = "Ясно";
                }
                if (oW.weather[0].main == "Clouds")
                {
                    weather.Content = "Облачно";
                }

                city.Content = oW.name + ", " + oW.sys.country;

                gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

                speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

                humid.Content = "Влажность: " + oW.main.humidity + "%";
            }
        }

        private async void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                string text = Convert.ToString(search.Text);
                string url = @"http://api.openweathermap.org/data/2.5/weather?q=" + text + "&APPID=5431bc932d01f2d8b07a5818e24e4f52";
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";
                WebResponse response = await request.GetResponseAsync();
                string answer = string.Empty;
                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                if (text == "" || text == " ")
                {
                    text = "Moscow";
                }

                response.Close();
                temp.Content = answer;

                Image finalImage = new Image();
                OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                temp.Content = oW.main.temp.ToString("0.##") + "°C";

                weather.Content = oW.weather[0].main;
                if (oW.weather[0].main == "Clear")
                {
                    weather.Content = "Ясно";
                }
                if (oW.weather[0].main == "Clouds")
                {
                    weather.Content = "Облачно";
                }

                city.Content = oW.name + ", " + oW.sys.country;

                gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

                speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

                humid.Content = "Влажность: " + oW.main.humidity + "%";
                if (text == "" || text == " ")
                {
                    text = "Moscow";
                }
            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as TextBox).Text = Regex.Replace((sender as TextBox).Text, @"\s+", "");
        }
    }

}
