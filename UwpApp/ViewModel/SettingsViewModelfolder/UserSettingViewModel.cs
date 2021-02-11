using Domin.Data;
using System.Collections.ObjectModel;
using UwpApp.Services.Authentication;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class UserSettingViewModel : BindableBase
    {
        private User user;
        private Role role;
        private int userId;
        private string userName;
        private string name;
        private string userHash;
        private UsernameAndHash usernameAndHash;

        public UserSettingViewModel()
        {

        }



        public AuthenticateService  AuthenticateService  { get; set; }

        public User User
        {
            get => user;

            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged();

                }

            }
        }

        public int UserId
        {
            get => User.UserId;
            set
            {
                if (userId != value)
                {
                    User.UserId = value;
                    OnPropertyChanged();

                }

            }
        }

        public string UserName
        {
            get => User.UserName;
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => User.Name;
            set
            {
                if (name != value)
                {
                    User.Name = value;
                    OnPropertyChanged();

                }
            }
        }

        public UsernameAndHash UsernameAndHash
        {
            get => usernameAndHash;

            set
            {
                if (usernameAndHash != null)
                {
                    usernameAndHash = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public string UserHash
        {
            get => UsernameAndHash.PasswordHash;
            set
            {
                if (userHash!=value)
                {
                    userHash = value;
                    OnPropertyChanged();

                }
            }
        }





        public Role Role { get => role; set => role = value; }

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();


        public async void ChangePassword(string currentpassword,string username, string newpassword)
        {
            var result = AuthenticateService.ChangePassword(currentpassword, username, newpassword);

        }


        public async void LoadUsers()
        {
            var results = await App.Repository.Users.GetAsync();
            Users.Clear();
            foreach (var result in results)
            {
                Users.Add(result);
            }

        }


        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();
        public async void loadUserRoles()
        {
            var results = await App.Repository.Roles.GetAsync();
            Roles.Clear();
            foreach (var result in results)
            {
                Roles.Add(result);
            }
        }

        public async void AddUser(User user)
        {
            if (user != null)
            {
                try
                {
                    var result = App.Repository.Users.UpsertAsync(user);
                }
                catch (System.Exception ex)
                {



                }

            }

        }





    }
}
