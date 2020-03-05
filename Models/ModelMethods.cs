using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne.Models
{
    static class ModelMethods
    {       
        public static int AutoGenerateCustomerID()
        {
            Random random = new Random();
            int customerID = random.Next(1000, 3000);

            return customerID;
        }
        public static int AutoGenerateProductID()
        {
            Random random = new Random();
            int productID = random.Next(4000, 6000);

            return productID;
        }
        public static int AutoGenerateOrderID()
        {
            Random random = new Random();
            int orderID = random.Next(7000, 9000);

            return orderID;
        }
        public static bool ControllInputPositiveStockQuantity(int inputStockQuantity)
        {
            bool condition = true;
            if (inputStockQuantity < 0)
            {
                condition = false;
            }
            return condition;
        }
        public static bool ControllInputIsInteger(string userInputToControll)
        {
            bool condition = true;
            try
            {
                int temp = Int32.Parse(userInputToControll);
            }
            catch (FormatException)
            {
                condition = false;
            }
            return condition;
        }
    }
}
