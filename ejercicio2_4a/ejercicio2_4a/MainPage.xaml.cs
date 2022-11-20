using ejercicio2_4a.Models;
using Plugin.Media;

using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ejercicio2_4a
{
    public partial class MainPage : ContentPage
    {
        MediaFile FileVideo;
        videoplayer video = null;

        public MainPage()
        {
            InitializeComponent();
            if (App.DBase != null) { }
        }

        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var name = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HHmmss") + ".mp4";

                FileVideo = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    SaveToAlbum = true,
                    Name = name,
                    Directory = "MisVideos"

                });

                if (FileVideo == null)
                    return;


                mediaElement.Source = FileVideo.Path;

                await DisplayAlert("El Video se ha guardado en storage correctamente", "Path: " + FileVideo.Path, "OK");

                video = new videoplayer
                {
                    Id = 0,
                    Nombre = name,
                    Path = FileVideo.Path,
                    fecha = DateTime.Now
                };

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }

    

    private async void btnsalvar_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (FileVideo == null)
                {
                    await DisplayAlert("Importante", "Agrega un video", "OK");
                    return;
                }

                var result = await App.DBase.insertUpdateVideo(video);

                if (result > 0)
                {
                    await DisplayAlert("Importante", "El video se ha guardado correctamente en SQL LITE", "OK");

                    FileVideo = null;
                    video = null;
                    mediaElement.Source = null;
                }
                else
                    await DisplayAlert("Aviso", "El video no se pudo guardar en la base de datos", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
