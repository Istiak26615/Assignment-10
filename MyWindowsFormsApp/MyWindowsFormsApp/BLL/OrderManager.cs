using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;

namespace MyWindowsFormsApp.BLL
{
    public class OrderManager
    {
        OrderRipository _orderRepository = new OrderRipository();
        public bool Add(string name, double price,double bill)
        {
            return _orderRepository.Add(name, price,bill);
        }
        public bool IsNameExists(string name)
        {
            return _orderRepository.IsNameExists(name);
        }
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }
        public bool Update(string name, double price,double bill, int id)
        {
            return _orderRepository.Update(name, price,bill, id);
        }
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
          
        }
    }
}
