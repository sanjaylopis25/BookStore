using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;

        }
        [HttpPost("register")]
        public ActionResult UserRegistration(UserPostModel userPostModel)
        {
            try
            {
                this.userBL.UserRegistration(userPostModel);
                return this.Ok(new { success = true, message = $"Registration Successful {userPostModel.EmailId}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("login")]
        public ActionResult Login(UserLogin login)
        {
            try
            {
                string result = this.userBL.Login(login);
                if (result != null)
                {                   
                    return this.Ok(new { success = true, message = $"Login Successful, token={result }" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Incorrect Email and Password" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string EmailId)
        {
            if (string.IsNullOrEmpty(EmailId))
            {
                return BadRequest("Email should not be null or empty");
            }
            try
            {
                var result = this.userBL.ForgetPassword(EmailId);
                if (result != false)
                {
                    return this.Ok(new { Success = true, message = "Token generated.Please check your email", token = result });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Invalid User Please enter valid email and password." });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });

            }
        }

        [AllowAnonymous]
        [HttpPut("ResetPassword")]

        public ActionResult ResetPassword(string Password)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, Password);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = $"Email is not Authorized" });
                    }
                }
                return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
