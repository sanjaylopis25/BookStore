using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void UserRegistration(UserPostModel user);
        public string Login(UserLogin userLogin);
        public bool ForgetPassword(string EmailId);
        public bool ResetPassword(string EmailId, string Password);
    }
}
