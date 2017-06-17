using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlaySample.Droid.MediaPlayer_Droid))]
namespace AudioPlaySample.Droid
{
    public class MediaPlayer_Droid : App.IMediaPlayer
    {
        MediaPlayer player = null;

        private async Task StartPlayerAsync(string title)
        {
            var resourceId = (int)typeof(Resource.Raw).GetField(title).GetValue(null);

            await Task.Run(() => {
                if (player != null)
                {
                    if( player.IsPlaying ) {
                        player.Stop();
                    }
                    player.Release();
                    player = null;
                }

                player = new MediaPlayer();
                player.SetAudioStreamType(Stream.Music);

                player = MediaPlayer.Create(
                            global::Android.App.Application.Context,
                            resourceId
                        );
                player.Looping = false;
                player.Start();
            });
        }

        private void StopPlayer()
        {
            if ((player != null))
            {
                if (player.IsPlaying)
                {
                    player.Stop();
                }
                player.Release();
                player = null;
            }
        }

        public async Task PlayAsync(string title)
        {
            await StartPlayerAsync(title);
        }

        public void Stop()
        {
            StopPlayer();
        }
    }
}