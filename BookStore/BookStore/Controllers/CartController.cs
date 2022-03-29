﻿using BusinessLayer.Interface;
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
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;

        }
        [Authorize]
        [HttpPost("addBooksInCart")]
        public IActionResult AddBookToCart(CartPostModel cartBook)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.cartBL.AddBookToCart(cartBook);
                    if (result.Equals("book added in cart successfully"))
                    {
                        return this.Ok(new { success = true, message = $"Book added in Cart Successfully " });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to add Book!" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [Authorize]
        [HttpDelete("deleteCart/{CartId}")]
        public IActionResult DeleteCart(int CartId)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.cartBL.DeleteCart(CartId);
                    if (result.Equals("Book Deleted in Cart Successfully"))
                    {
                        return this.Ok(new { success = true, message = $"Book in Cart deleted Successfully " });
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
        [Authorize]
        [HttpGet("getallbook/{userId}")]
        public IActionResult GetAllBooksinCart(int userId)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.cartBL.GetAllBooksinCart(userId);
                    if (result != null)
                    {
                        return this.Ok(new { success = true, message = $"All Books Displayed in the cart Successfully ", response = result });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = $"Books are not there " });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to getallBooks" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [Authorize]
        [HttpPut("updateCart/{CartId}")]
        public IActionResult UpdateCart(int CartId, int Quantity)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.cartBL.UpdateCart(CartId, Quantity);
                    if (result.Equals(true))
                    {
                        return this.Ok(new { success = true, message = $"Cart updated Successfully ", response = Quantity });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unable to update" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
