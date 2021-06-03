using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirebasePayRoll
{
    public partial class MainPage : ContentPage
    {
      // FBHelper fbdb = new FBHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddPage (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Add());
        }

        private async void SearchPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search());
        }

        private async void DeletePage (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Delete());
        }

        private async void UpdatePage (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Update());
        }

    }
}
