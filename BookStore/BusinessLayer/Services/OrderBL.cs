﻿using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public string AddOrder(OrderPostModel orderPost)
        {
            try
            {
                return orderRL.AddOrder(orderPost);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            try
            {
                return orderRL.DeleteOrder(OrderId);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrderModel> OrderBooks(int UserId)
        {
            try
            {
                return orderRL.OrderBooks(UserId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
