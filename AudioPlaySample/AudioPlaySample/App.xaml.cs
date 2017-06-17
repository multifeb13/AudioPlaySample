using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AudioPlaySample
{
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();
            //
            //MainPage = new AudioPlaySample.MainPage();
            Button btnPlay1 = new Button
            {
                Text = "Play 1",
                Command = new Command((obj) => {
                    DependencyService.Get<IMediaPlayer>().PlayAsync("se01");
                })
            };

            Button btnPlay2 = new Button
            {
                Text = "Play 2",
                Command = new Command((obj) => {
                    DependencyService.Get<IMediaPlayer>().PlayAsync("se02");
                })
            };

            // The root page of your application
            var content = new ContentPage
            {
                Title = "AudioPlaySample",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        btnPlay1,
                        btnPlay2,
                    }
                },
                Padding = new Thickness(10)
            };
            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public interface IMediaPlayer
        {
            Task PlayAsync(string title);
            void Stop();
        }
    }
}
