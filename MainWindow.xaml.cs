using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Api
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
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

        public async void Api()
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
            if (oW.weather[0].main == "Rain")
            {
                weather.Content = "Дождь";
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

        public async void searchb_Click(object sender, RoutedEventArgs e)
        {
            string text = Convert.ToString(search.Text);
            string url = @"http://api.openweathermap.org/data/2.5/weather?q=" + text + "&APPID=5431bc932d01f2d8b07a5818e24e4f52";

            try
            {
                HttpWebRequest request2 = WebRequest.Create(url) as HttpWebRequest;
                request2.Method = "HEAD";
                HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse;
                response2.Close();
                if (response2.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Город не найден");
                }
            }
            catch
            {
                MessageBox.Show("Город не найден");
                WebRequest requestn = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Moscow&APPID=5431bc932d01f2d8b07a5818e24e4f52");
                requestn.Method = "POST";
                requestn.ContentType = "application/x-www-urlencoded";
                WebResponse responsen = await requestn.GetResponseAsync();
                string answern = string.Empty;
                using (Stream s = responsen.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answern = await reader.ReadToEndAsync();
                    }
                }
                responsen.Close();
                temp.Content = answern;

                OpenWeather.OpenWeather oWn = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answern);

                temp.Content = oWn.main.temp.ToString("0.##") + "°C";

                weather.Content = oWn.weather[0].main;
                if (oWn.weather[0].main == "Clear")
                {
                    weather.Content = "Ясно";
                }
                if (oWn.weather[0].main == "Clouds")
                {
                    weather.Content = "Облачно";
                }
                if (oWn.weather[0].main == "Rain")
                {
                    weather.Content = "Дождь";
                }

                city.Content = oWn.name + ", " + oWn.sys.country;

                gust.Content = "Порыв ветра: " + oWn.wind.gust + "м/с";

                speed.Content = "Скорость ветра: " + oWn.wind.speed + "м/с";

                humid.Content = "Влажность: " + oWn.main.humidity + "%";
            }

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
            if (oW.weather[0].main == "Rain")
            {
                weather.Content = "Дождь";
            }

            city.Content = oW.name + ", " + oW.sys.country;

            gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

            speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

            humid.Content = "Влажность: " + oW.main.humidity + "%";
        }

        public async void searchb_KeyDown(object sender, KeyEventArgs e)
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
                if (oW.weather[0].main == "Rain")
                {
                    weather.Content = "Дождь";
                }

                city.Content = oW.name + ", " + oW.sys.country;

                gust.Content = "Порыв ветра: " + oW.wind.gust + "м/с";

                speed.Content = "Скорость ветра: " + oW.wind.speed + "м/с";

                humid.Content = "Влажность: " + oW.main.humidity + "%";
            }
        }

        public async void search_KeyDown(object sender, KeyEventArgs e)
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
                if (oW.weather[0].main == "Rain")
                {
                    weather.Content = "Дождь";
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

        public void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //(sender as TextBox).Text = Regex.Replace((sender as TextBox).Text, @"\s+", "");
        }
    }

}
