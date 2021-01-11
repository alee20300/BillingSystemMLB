using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Models;

namespace UwpApp.ViewModel.Authentication
{
   public interface IAuthenticateService
    {


        Task<AutorizeDetailModel> Authenticate(string username, string password);
        Task ChangePassword(string currentPassword, string username, string newPassword);

    }
}
