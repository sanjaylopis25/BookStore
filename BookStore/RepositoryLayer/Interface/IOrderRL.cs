using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.User;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        string AddOrder(OrderPostModel orderPost);
        List<OrderModel> OrderBooks(int UserId);
        bool DeleteOrder(int OrderId);
    }
}
