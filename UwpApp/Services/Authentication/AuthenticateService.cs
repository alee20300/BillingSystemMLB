using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Models;
using UwpApp.ViewModel.Authentication;

namespace UwpApp.Services.Authentication
{
    public class AuthenticateService : IAuthenticateService

    {
        public Task<AutorizeDetailModel> Authenticate(string username, string password)
        {


            throw new NotImplementedException();
        }

        public Task ChangePassword(string currentPassword, string username, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
