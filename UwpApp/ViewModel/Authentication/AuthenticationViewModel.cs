using Domin.Data;
using Swatinc;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Models;
using UwpApp.ViewModel.Command;
using ViewModels.Infrastructure.Common;

namespace UwpApp.ViewModel.Authentication
{
    public class AuthenticationViewModel : BindableBase
    {
        public AuthenticationViewModel()
        {
            
        }

        private string password;
        private string userName;

        public string UserName { get => userName; set => userName = value; }
        public string Password
        {
            get => password;

            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }





        public async Task<AutorizeDetailModel> Authenticate
             ()
        {





            //get username and password hash from database.
            var result = await GetHashForUser(userName);
            //if username is not found, return isAuthentcated as false.
            if (result is null)
            {
                return new AutorizeDetailModel()
                {
                    IsAuthenticated = false,
                    Message = "Username or password is incorrect!"
                };
            }
            //if hash match returns true, fetch other details for return model.
            if (VerifyPassword(password, result.PasswordHash))
            {

                var queryResult = await App.Repository.AthorizeDetails.GetauthorrizedData(userName);
                queryResult.IsAuthenticated = true;
                AutorizeDetailModel autorizeDetailModel = new AutorizeDetailModel(queryResult);
                
                return autorizeDetailModel;


            }
            else
            {
                //return IsAuthenticated as flase with message.
                return new AutorizeDetailModel()
                {
                    IsAuthenticated = false,
                    Message = "Username or password is incorrect!"
                };
            }
        }

        /// <summary>
        /// hashes the provided string password
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>return SHA512 hash</returns>
        private string HashPassword(string password)
        {
            return SwatIncCrypto.SwatIncSecurityCreateHashSHA512(password);
        }

        /// <summary>
        /// Hashes the password and compares with the hash from database
        /// </summary>
        /// <param name="password">string password</param>
        /// <param name="goodHash">Good hash from database</param>
        /// <returns>boolean to indicate whether the password is a match</returns>
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

        /// <summary>
        /// Fetches the user hash from database with the specified username
        /// </summary>
        /// <param name="username">The username and password</param>
        /// <returns>An instance of UsernameAndHashModel or null </returns>
        private async Task<UsernameAndHashModel> GetHashForUser(string username)
        {
            try
            {
                var result = await App.Repository.UsernameAndHash.GetUsernameAndHash(username);
                


                if (result!=null)
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
