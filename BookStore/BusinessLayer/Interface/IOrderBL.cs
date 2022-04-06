using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        string AddOrder(OrderPostModel orderPost);
        bool DeleteOrder(int OrderId);
        List<OrderModel> OrderBooks(int UserId);
    }
}
