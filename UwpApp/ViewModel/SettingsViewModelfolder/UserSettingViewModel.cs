using Domin.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
  public  class UserSettingViewModel 
    {
        public UserSettingViewModel()
        {
                
        }

        public User User { get; set; }
        public Role role { get; set; }

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();


        public async void  LoadUsers()
        {
            var results = await App.Repository.Users.GetAsync();
            Users.Clear();
            foreach (var result in results)
            {
                Users.Add(result);
            }

        }









    }
}
