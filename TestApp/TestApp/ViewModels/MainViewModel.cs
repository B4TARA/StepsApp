using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows;
using System.Data;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using TestApp.Commands;
using System.Windows.Input;
using System.Runtime.Serialization.Json;

namespace TestApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<List<UserInfo>> UserMonth;
        public List<UserInfo> UsersInfo;  

        public List<Users> UsersMonth { get; set; } 
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set 
            { 
                _selectedIndex = value; 
                OnPropertyChanged("SelectedIndex");
                SeriesCollection[0].Values.Clear();
                for (int i = 0; i < 30; i++)
                {
                    if (UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault() != null)
                    {
                        int steps = UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault().Steps;
                        SeriesCollection[0].Values.Add(steps);
                    }
                }
            }
        }


        private Command import;
        public ICommand Import
        {
            get
            {
                return import ??
                    (import = new Command(obj =>
                    {
                        for(int i = 0; i < 30; i++ )
                        {
                            if (UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault() != null)
                            {
                                UserImport User = new UserImport();
                                User.Day = i + 1;
                                User.MaxSteps = UsersMonth[SelectedIndex].MaxSteps;
                                User.MinSteps = UsersMonth[SelectedIndex].MinSteps;
                                User.AvgSteps = UsersMonth[SelectedIndex].AvgSteps;
                                User.Rank = UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault().Rank;
                                User.Status = UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault().Status;
                                User.Steps = UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault().Steps;
                                User.User = UserMonth[i].Where(u => u.User.Equals(UsersMonth[SelectedIndex].User)).FirstOrDefault().User;

                                File.AppendAllText("import.json", JsonConvert.SerializeObject(User));
                                File.AppendAllText("import.json", "\n");
                                if(i==29)
                                {
                                    File.AppendAllText("import.json", "\n");
                                    File.AppendAllText("import.json", "");
                                }
                            }
                            
                        }
                        MessageBox.Show("Импортировано!");
                    }));
            }
        }

        public MainViewModel()
        {
            var flag = false;
            UsersMonth = new List<Users>();
            UserMonth = new ObservableCollection<List<UserInfo>>();
            UsersInfo = new List<UserInfo>();
            for (int i = 1; i <= 30; i++)
            {
                string file = "data/day" + i.ToString() + ".json";
                var res = JsonConvert.DeserializeObject<List<UserInfo>>(File.ReadAllText(file));
                
                foreach (var f in res)
                {  
                    if (flag == false)
                    {
                        Users users = new Users();
                        users.User = f.User;
                        users.AvgSteps = f.Steps;
                        users.MaxSteps = f.Steps;
                        users.MinSteps = f.Steps;
                        UsersMonth.Add(users);
                    }
                    else
                    {
                        if (UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault() != null)
                        {
                            UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault().AvgSteps += f.Steps;
                            if (f.Steps > UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault().MaxSteps) UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault().MaxSteps = f.Steps;
                            if (f.Steps < UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault().MinSteps) UsersMonth.Where(u => u.User.Equals(f.User)).FirstOrDefault().MinSteps = f.Steps;
                        }
                    }
                }
                flag = true;
                UserMonth.Add(res);
            }

            foreach (var f in UsersMonth)
            {
                f.AvgSteps = f.AvgSteps / 30;
            }


            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<int> (),
                },
            };

            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
        }
    }
}
