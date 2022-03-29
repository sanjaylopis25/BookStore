using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;

        }
        [Authorize]
        [HttpPost("addAddress/{userId}")]
        public IActionResult AddAddress(int userId, AddressPostModel addressPost)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.addressBL.AddAddress(userId, addressPost);
                    if (result.Equals("Address added  successfully"))
                    {
                        return this.Ok(new { success = true, message = $"Address Added Successfully " });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to add Address" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPut("updateAddress/{AddressId}")]
        public IActionResult UpdateAddress(int AddressId, AddressPostModel addressPost)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.addressBL.UpdateAddress(AddressId, addressPost);
                    if (result.Equals(true))
                    {
                        return this.Ok(new { success = true, message = $"Address updated Successfully " });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to update address" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpDelete("deleteAddress/{AddressId}")]
        public IActionResult DeleteAddress(int AddressId)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.addressBL.DeleteAddress(AddressId);
                    if (result.Equals(true))
                    {
                        return this.Ok(new { success = true, message = $"Address deleted Successfully " });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to delete" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("GetAllAddress")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.addressBL.GetAllAddress();
                    if (result != null)
                    {
                        return this.Ok(new { success = true, message = $"All Address Displayed Successfully ", response = result });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = $"address are not there " });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to getAll Address" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("getaddressbyUserId/{userId}")]
        public IActionResult GetAddressByAddressId(int userId)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.addressBL.GetAddressByAddressId(userId);
                    if (result != null)
                    {
                        return this.Ok(new { success = true, message = $"Address is Displayed Successfully by UserId ", response = result });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = $"Address id not exists " });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to get Address by userId" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
