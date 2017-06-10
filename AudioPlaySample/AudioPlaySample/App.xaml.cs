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
            Button btnPlay = new Button
            {
                Text = "Play/Pause",
                Command = new Command((obj) => {
                    DependencyService.Get<IMediaPlayer>().PlayAsync("se01");
                })
            };

            Button btnStop = new Button
            {
                Text = "Stop",
                Command = new Command((obj) => {
                    DependencyService.Get<IMediaPlayer>().Stop();
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
                btnPlay,
                btnStop
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
