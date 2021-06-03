using System;
using System.Collections.Generic;
using System.Text;
using FirebasePayRoll.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

namespace FirebasePayRoll
{
    class FBHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://payroll-65169-default-rtdb.firebaseio.com/");

        public async Task<List<Payrolldb>> AllData()
        {
            return (await firebase
                .Child("Data")
                .OnceAsync<Payrolldb>()).Select(read => new Payrolldb
                {
                    EmpNum = read.Object.EmpNum,
                    Name = read.Object.Name,
                    HoursWork = read.Object.HoursWork,
                    EmpStat = read.Object.EmpStat,
                    CivilStat = read.Object.CivilStat,
                    Gross = read.Object.Gross,
                    Deduction = read.Object.Gross,
                    Net = read.Object.Gross,

                }).ToList();
        }

        public async Task AddData (
            int empnum,
            string name,
            double hourswork,
            string empstat,
            string civilstat,
            double gross,
            double deduction,
            double net)
        {
            await firebase.Child("Data").PostAsync(new Payrolldb()
            {
            EmpNum = empnum,
            Name = name,
            HoursWork = hourswork,
            EmpStat = empstat,
            CivilStat = civilstat,
            Gross = gross,
            Deduction = deduction,
            Net = net
            });

        }

        public async Task UpdateData(int empnum,
            string name,
            double hourswork,
            string empstat,
            string civilstat,
            double gross,
            double deduction,
            double net)
        {
            var updatedata = (await firebase
                .Child("Data")
                .OnceAsync<Payrolldb>())
                .Where(a => a.Object.EmpNum == empnum).FirstOrDefault();

            await firebase
                .Child("Data")
                .Child(updatedata.Key)
                .PutAsync(new Payrolldb()
                {
                    EmpNum = empnum,
                    Name = name,
                    HoursWork = hourswork,
                    EmpStat = empstat,
                    CivilStat = civilstat,
                    Gross = gross,
                    Deduction = deduction,
                    Net = net
                });
        }

        public async Task<Payrolldb> SearchData (int empnum)
        {
            var display = await AllData();
            await firebase.Child("Data").OnceAsync<Payrolldb>();
            return display.Where(a => a.EmpNum == empnum).FirstOrDefault();
        }

        public async Task DeleteData (int empnum)
        {
            var deleteme = (await firebase.Child("Data").OnceAsync<Payrolldb>()).
                Where(a => a.Object.EmpNum == empnum).FirstOrDefault();

            await firebase.Child("Data").Child(deleteme.Key).DeleteAsync();
        }

    }

}
