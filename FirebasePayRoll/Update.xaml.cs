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
    public partial class Update : ContentPage
    {
        FBHelper fbdb = new FBHelper();
        public Update()
        {
            InitializeComponent();
        }

        private async void btnUpdate(object sender, EventArgs e)
        {
            var searchme = await fbdb.SearchData(int.Parse(empnum.Text));
            if (searchme != null)
            {
                string name = searchme.Name;
                string empstat = searchme.EmpStat;
                string civilstat = searchme.CivilStat;
                double hwork = double.Parse(hourwork.Text);
                double rateperday, rateperhour, basic, overtimehour,
                    overtime, gross, wtax, phil, pagibig, net, deduction;

                if (empstat == "R")
                {
                    rateperday = 800;
                }
                else if (empstat == "P")
                {
                    rateperday = 600;
                }
                else if (empstat == "C")
                {
                    rateperday = 500;
                }
                else if (empstat == "T")
                {
                    rateperday = 450;
                }
                else
                {
                    rateperday = 400;
                }

                rateperhour = rateperday / 8;
                basic = hwork * rateperday;
                overtimehour = hwork - 120;

                if (hwork > 120)
                {
                    overtime = overtimehour * (rateperhour * 1.5);
                }

                else
                {
                    overtime = 0;
                }
                gross = basic + overtime;

                if (gross > 10000)
                {
                    wtax = 0.1 * gross;
                }
                else if (gross > 5000)
                {
                    wtax = 0.08 * gross;
                }
                else
                {
                    wtax = 0.05 * gross;
                }

                if (civilstat == "S")
                {
                    phil = 500;
                }
                else if (civilstat == "M")
                {
                    phil = 300;
                }
                else
                {
                    phil = 400;
                }

                if (gross > 10000)
                {
                    pagibig = 0.05 * gross;
                }
                else if (gross > 5000)
                {
                    pagibig = 0.03 * gross;
                }
                else
                {
                    pagibig = 0.02 * gross;
                }

                deduction = wtax + phil + pagibig;
                net = gross - deduction;

                await fbdb.UpdateData(
                    int.Parse(empnum.Text),
                    name,
                    double.Parse(hourwork.Text),
                    empstat,
                    civilstat,
                    gross,
                    deduction,
                    net);

                await DisplayAlert("Success", "Data Save", "OK");
                empnum.Text = string.Empty; 
                hourwork.Text = string.Empty;
              
            }
            else
            {
                await DisplayAlert("Error", "No Data Search", "OK");
            }
        }

        private async void btnHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}