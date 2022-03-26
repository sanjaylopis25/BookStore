using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public bool ForgetPassword(string EmailId)
        {
            try
            {
                return userRL.ForgetPassword(EmailId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userRL.Login(userLogin);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ResetPassword(string EmailId, string Password)
        {
            try
            {
                return userRL.ResetPassword(EmailId, Password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UserRegistration(UserPostModel user)
        {
            try
            {
                userRL.UserRegistration(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
