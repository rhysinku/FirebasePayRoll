using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebasePayRoll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Delete : ContentPage
    {
        FBHelper fbdb = new FBHelper();
        public Delete()
        {
            InitializeComponent();
        }

        private async void btnDelete(object sender, EventArgs e)
        {
            await fbdb.DeleteData(int.Parse(empnum.Text));
            await DisplayAlert("Success", "Delete Data", "OK");
        }

        private async void btnHome (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}