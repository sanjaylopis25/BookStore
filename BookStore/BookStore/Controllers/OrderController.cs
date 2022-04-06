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
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [Authorize]
        [HttpPost("orderBooks")]
        public IActionResult AddOrder(OrderPostModel orderPost)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.orderBL.AddOrder(orderPost);
                    if (result.Equals("books ordered successfully"))
                    {
                        return this.Ok(new { success = true, message = $"Books ordered Successfully " });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = result });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Books Order Unsuccesful" });
                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [Authorize]
        [HttpGet("getallOrders/{userId}")]
        public IActionResult GetAllOrders(int UserId)
        {
            try
            {
                var userEmail = User.FindFirst("EmailId").Value.ToString();
                if (userEmail != null)
                {
                    var result = this.orderBL.OrderBooks(UserId);
                    if (result != null)
                    {
                        return this.Ok(new { success = true, message = $"Ordered Books Displayed Successfully ", response = result });
                    }
                    else
                    {
                        return this.BadRequest(new { Status = false, Message = $"Books are not there " });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Password reset Unsuccesfully" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("deletebook/{OrderId}")]
        public IActionResult DeleteOrder(int OrderId)
        {
            try
            {
                var result = this.orderBL.DeleteOrder(OrderId);
                if (result.Equals(true))
                {
                    return this.Ok(new { success = true, message = $"Book order deleted Successfully ", response = OrderId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
