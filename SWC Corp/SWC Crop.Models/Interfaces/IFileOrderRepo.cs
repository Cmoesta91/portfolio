using System.Collections.Generic;
using SWC_Crop.Models;

namespace SWC_Corp.Data
{
    public interface IFileOrderRepo
    {
        Orders Create(Orders order);
        void Delete(int orderNumber, Orders order);
        Orders ReadByOrderNumber(int orderNumber);
        void Update(int orderNumber, Orders newOrderInfo);
        int NextOrderNumber();
        List<Orders> LoadOrder();
        void SaveOrder();
    }
}