﻿using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void UserRegistration(UserPostModel user);
        public string Login(UserLogin userLogin);
        public bool ForgetPassword(string EmailId);
        public bool ResetPassword(string EmailId, string Password);
    }
}
