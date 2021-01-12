using Domin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
    public class UsernameAndHashModel
    {
        public UsernameAndHashModel()
        {

        }
        public UsernameAndHashModel(UsernameAndHash usernameAndHasH)
        {
            UserName = usernameAndHasH.UserName;
            PasswordHash = usernameAndHasH.PasswordHash;
        }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
