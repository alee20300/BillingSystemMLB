using Swatinc;
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


        private string HashPassword(string password)
        {
            return SwatIncCrypto.SwatIncSecurityCreateHashSHA512(password);
        }


        private bool VerifyPassword(string password, string goodHash)
        {
            return SwatIncCrypto.VerifyPassword(password, goodHash);
        }
        public async Task ChangePassword(string currentPassword, string username, string newPassword)
        {

            try
            {
                //get user hash
                var usernameAndHash = await GetHashForUser(username);
                if (usernameAndHash is null)
                {
                    throw new Exception($"An error occured while changing the password.\nCannot find user: {username}");
                }
                //verify that the current password match
                if (VerifyPassword(currentPassword, usernameAndHash.PasswordHash))
                {
                    //change the password
                    await ChangeUserHash(newPassword, username);
                }
                else
                {
                    throw new Exception("The current password provided is invalid!");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task<UsernameAndHashModel> GetHashForUser(string username)
        {
            try
            {
                var result = await App.Repository.UsernameAndHash.GetUsernameAndHash(username);



                if (result != null)
                {
                    UsernameAndHashModel usernameAndHashModel = new UsernameAndHashModel(result);
                    return usernameAndHashModel;
                }
                else
                {
                    UsernameAndHashModel usernameAndHashModel = new UsernameAndHashModel();
                    return usernameAndHashModel;
                }


            }
            catch (Exception)
            {
                throw;
            }
        }





        /// <summary>
        /// updates the database with new password hash
        /// </summary>
        /// <param name="password">The new password</param>
        public async Task ChangeUserHash(string password, string username)
        {

            try
            {
                var result = await App.Repository.UsernameAndHash.GetUsernameAndHash(username);
                result.PasswordHash = SwatIncCrypto.SwatIncSecurityCreateHashSHA512(password);
                var save = await App.Repository.UsernameAndHash.UpsertAsync(result);
            }
            catch (Exception)
            {

                throw;
            }





        }

    }
}
