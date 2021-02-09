using Domin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
    public class AutorizeDetailModel
    {
        public AutorizeDetailModel()
        {

        }
        public AutorizeDetailModel( AutorizeDetail autorizeDetail)
        {
            User = autorizeDetail.User;
            UserName = autorizeDetail.User.UserName;
            UserId = autorizeDetail.User.UserId;
            Claims = autorizeDetail.Claims;
         


        }

     
        public User User { get; set; }
        public String UserName { get; set; }

        public int UserId { get; set; }
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();


        public string Message { get; set; }


        public bool IsAuthenticated { get; set; }

    }
}