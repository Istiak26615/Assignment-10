using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    class CustomerManager
    {
        CustomerRipository _customerRipository = new CustomerRipository();
        public bool Add(Customer customer)
        {
            return _customerRipository.Add(customer);
        }
        public bool IsNameExists(Customer customer)
        {
            return _customerRipository.IsNameExists(customer);
        }
        public bool Delete(int id)
        {
            return _customerRipository.Delete(id);
        }
        public DataTable Display()
        {
            return _customerRipository.Display();
        }
        public bool Update(string name, string  address, int id)
        {
            return _customerRipository.Update(name, address, id);
        }
        public DataTable Search(string name)
        {
            return _customerRipository.Search(name);
        }
        public DataTable CustomerCombo()
        {
            return _customerRipository.CustomerCombo();
        }


    }
}
