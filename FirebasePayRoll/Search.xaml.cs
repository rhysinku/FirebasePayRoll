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
    public partial class Search : ContentPage
    {
       FBHelper fbdb = new FBHelper();
        public Search()
        {
            InitializeComponent();
        }

        private async void btnSearch(object sender, EventArgs e)
        {
            var searchme = await fbdb.SearchData(int.Parse(empnum.Text));
            if (searchme != null)
            {
                number.Text = searchme.EmpNum.ToString();
                name.Text = searchme.Name;
                hourwork.Text = searchme.HoursWork.ToString();
                empstat.Text = searchme.EmpStat;
                civilstat.Text = searchme.CivilStat;
                gross.Text = searchme.Gross.ToString();
                ddeduction.Text = searchme.Deduction.ToString();
                nnet.Text = searchme.Net.ToString();

              

                
            }
            else
            {
                await DisplayAlert("Error", "No Data Search", "OK");
            }
        }

        private async void btnHomePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}