using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne
{
    static class Controller
    {
        // Other
        public static void HandleMenuChoice(int selectedMenuNumber)
        {
            if (selectedMenuNumber == 1)
            {
               ModelViews.start.Show();
            }
            else if (selectedMenuNumber == 2)
            {
                ModelViews.programConstructionOne.Show();
            }
            else if (selectedMenuNumber == 3)
            {
                ModelViews.programConstructionTwo.Show();
            }
            else if (selectedMenuNumber == 4)
            {
                ModelViews.integrationTechnologiesOne.Show(); 
            }
            else if (selectedMenuNumber == 5)
            {
                ModelViews.integrationTechnologiesTwo.Show();
            }
            else if (selectedMenuNumber == 6)
            {
                ModelViews.integrationAndConfigurationOne.Show();
            }
            else if (selectedMenuNumber == 7)
            {
                ModelViews.integrationAndConfigurationTwo.Show();
            }
        }
        public static void ErrorHandler(int errorCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SqlException i DAL via metoden: ");
            switch (errorCode)
            {
                case 19171201:
                    builder.Append("CheckIfCustomerIDExist");
                    break;
                    
                case 19171202:
                    builder.Append("CheckIfProductIDExist");

                    break;

                case 19171203:
                    builder.Append("CheckIfOrderIDExist");


                    break;
                case 19171204:
                    builder.Append("CreatPrivateCustomer");

                    break;
                case 19171205:
                    builder.Append("CreateCompanyCustomer");

                    break;
                case 19171206:
                    builder.Append("CreateProduct");

                    break;
                case 19171207:
                    builder.Append("CreateOrder");

                    break;
                case 19171208:
                    builder.Append("CreateProduct_Order");

                    break;
                case 19171209:
                    builder.Append("UpdatePrivateCustomer");

                    break;
                case 19171210:
                    builder.Append("UpdateCompanyCustomer");

                    break;
                case 19171211:
                    builder.Append("UpdateProduct");

                    break;
                case 19171212:
                    builder.Append("DeletePrivateCustomer");

                    break;
                case 19171213:
                    builder.Append("DeleteCompanyCustomer");

                    break;
                case 19171214:
                    builder.Append("DeleteProduct");

                    break;
                case 19171215:
                    builder.Append("DeleteOrder");

                    break;
                case 19171216:
                    builder.Append("DisplayAllPrivateCustomers");

                    break;
                case 19171217:
                    builder.Append("DisplayAllCompanyCustomers");

                    break;
                case 19171218:
                    builder.Append("DisplayAllCustomers");

                    break;
                case 19171219:
                    builder.Append("DisplaySpecificPrivateCustomer");

                    break;
                case 19171220:
                    builder.Append("DisplaySpecificCompanyCustomer");

                    break;
                case 19171221:
                    builder.Append("DisplayAllProducts");

                    break;
                case 19171222:
                    builder.Append("DisplaySpecificProducts");

                    break;
                case 19171223:
                    builder.Append("DisplayAllOrders");

                    break;
                case 19171224:
                    builder.Append("DisplaySpecificOrder");

                    break;
                case 19171225:
                    builder.Append("StockQuantityForSpecificProduct");

                    break;
                case 19171226:
                    builder.Append("DeleteAllPrivateCustomers");

                    break;
                case 19171227:
                    builder.Append("DeleteAllCompanyCustomers");

                    break;
                case 19171228:
                    builder.Append("DeleteAllProducts");

                    break;
                case 19171229:
                    builder.Append("DeleteAllOrders");

                    break;
                case 19171230:
                    builder.Append("CheckIfCustomerIsPrivateCustomer");

                    break;
                case 19171231:
                    builder.Append("CheckIfCustomerIsCompanyCustomer");

                    break;                
                default:
                    break; 
            }
            ModelViews.productAndStockHandler.DisplaySQLErrorMessage(builder.ToString());

        }
        public static bool ControllInputIsInteger(string input)
        {
            return Models.ModelMethods.ControllInputIsInteger(input);
        }
        public static string GenerateProductID()
        {
            int i = Models.ModelMethods.AutoGenerateProductID();
            if (Models.DAL.CheckIfProductIDExists(i))
            {
                do 
                {
                    i = Models.ModelMethods.AutoGenerateProductID();
                } while (Models.DAL.CheckIfProductIDExists(i)) ; 
            }
            return i.ToString();   
        } 
        public static string GenerateCustomerID()
        {
            int i = Models.ModelMethods.AutoGenerateCustomerID();
            if (Models.DAL.CheckIfCustomerIDExist(i))
            {
                do
                {
                    i = Models.ModelMethods.AutoGenerateCustomerID();
                } while (Models.DAL.CheckIfCustomerIDExist(i));
            }
            return i.ToString();
        }
        public static string GenerateOrderID()
        {
            int i = Models.ModelMethods.AutoGenerateOrderID();
            if (Models.DAL.CheckIfOrderIDExist(i))
            {
                do
                {
                    i = Models.ModelMethods.AutoGenerateOrderID();
                } while (Models.DAL.CheckIfOrderIDExist(i));
            }
            return i.ToString();
        }
        public static bool CheckIfCustomerIDExist(int customerID)
        {
            return Models.DAL.CheckIfCustomerIDExist(customerID);
        }
        public static bool CheckIfProductIDExist(int productID)
        {
            return Models.DAL.CheckIfProductIDExists(productID); 
        }
        public static bool CheckIfCustomerIsPrivateCustomer(int customerID)
        {
            return Models.DAL.CheckIfCustomerIsPrivateCustomer(customerID);
        }
        public static bool ControllIfStockQuantityIsPositive(int stockQuantity)
        {
            return Models.ModelMethods.ControllInputPositiveStockQuantity(stockQuantity);
        }
        public static int StockQuantityForSpecificProduct(int productID)
        {
            return Models.DAL.StockQuantityForSpecificProduct(productID);
        }
        public static bool CheckIfOrderIDExist(int orderID)
        {
            return Models.DAL.CheckIfOrderIDExist(orderID);  
        }

        // Create-methods
        public static int CreateProduct(string productID, string productName, string productDescription, string stockQuantity)
        {
            /* Return values:
             * 0 = stockQuantity  is not int 
             * 1 = stockQuantity is not positivt 
             * 2 = produktID already exist  
             * 3 = the product has not been created 
             * 4 = the product has been created  
             */
            int condition = 0;
            bool isStockQuantityInteger = Models.ModelMethods.ControllInputIsInteger(stockQuantity);

            if (isStockQuantityInteger == true)
            {
                int tempStockQuantity = Int32.Parse(stockQuantity); 
                bool isStockQuantityPositive = Models.ModelMethods.ControllInputPositiveStockQuantity(tempStockQuantity);
                if (isStockQuantityPositive == true)
                {
                    int tempProductID = Int32.Parse(productID); // Auto-generated
                    bool doesProductIDExist = Models.DAL.CheckIfProductIDExists(tempProductID);
                    if (doesProductIDExist == false)
                    {
                        bool createProduct = Models.DAL.CreateProduct(tempProductID, productName, productDescription, tempStockQuantity);
                        if (createProduct == true)
                        {
                            condition = 4;
                        }
                        else if (createProduct == false)
                        {
                            condition = 3;
                        }
                    }
                    else if (doesProductIDExist == true)
                    {
                        condition = 2;
                    }
                }
                else if (isStockQuantityPositive == false)
                {
                    condition = 1; 
                }
            }
            return condition; 
        }
        public static bool CreatePrivateCustomer(int customerID, string firstName, string lastName, string address)
        {
            bool condition = false;
            if (!Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                condition = Models.DAL.CreatePrivateCustomer(customerID, firstName, lastName, address); 
            }
            return condition; 
        }
        public static bool CreateCompanyCustomer(int customerID, string companyName, string address)
        {
            bool condition = false;
            if (!Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                condition = Models.DAL.CreateCompanyCustomer(customerID, companyName, address);
            }
            return condition; 
        }
        public static bool CreateCustomerOrder(int orderID, int privateCustomerID = 0, int companyCustomerID = 0)
        {
            return Models.DAL.CreateOrder(orderID: orderID, privateCustomerID: privateCustomerID, companyCustomerID: companyCustomerID);
        }
        public static int CreateProduct_Orders(int productID, int orderID, int quantity)
        {
            return Models.DAL.CreateProduct_Orders(productID, orderID, quantity); 
        }

        // Read(view)-methods
        public static DataTable DisplayAllProducts()
        {
            return Models.DAL.DisplayAllProducts();
        }
        public static DataTable DisplaySpecificProduct(int productID)
        {
            DataTable tempTable = new DataTable();
            if (Models.DAL.CheckIfProductIDExists(productID))
            {
                tempTable = Models.DAL.DisplaySpecificProduct(productID);
            }
            return tempTable; 
        }
        public static DataTable DisplayAllCustomersBySelectedCategory(int inputOption)
        {
            DataTable table = new DataTable();
            if (inputOption == 1)
            {
                table = Models.DAL.DisplayAllCompanyCustomers();
            } else if (inputOption == 2)
            {
                table = Models.DAL.DisplayAllPrivateCustomers();
            } else if(inputOption == 3)
            {
                table = Models.DAL.DisplayAllCustomers();
            }
            return table; 
        }
        public static DataTable DisplaySpecificCustomer(int customerID)
        {
            DataTable table = new DataTable();
            if (Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                if (Models.DAL.CheckIfCustomerIsPrivateCustomer(customerID))
                {
                    table = Models.DAL.DisplaySpecificPrivateCustomer(customerID);
                }
                else
                {
                    table = Models.DAL.DisplaySpecificCompanyCustomer(customerID);
                }
            }
            return table; 
        }
        public static DataTable DisplayAllOrders()
        {
            return Models.DAL.DisplayAllOrders();
        }
        public static DataTable DisplayAllOrdersForSpecificCustomer(int customerID)
        {
            return Models.DAL.DisplayAllOrdersForSpecificCustomer(customerID); 
        }
        public static DataTable DisplaySpecificOrder(int orderID)
        {
            return Models.DAL.DisplaySpecificOrder(orderID);
        }

        // Update-methods
        public static int UpdateProduct(int productID, string productName = "", string productDescription = "", int stockQuantity =-1)
        {
            int condition = -1; 
            if (Models.DAL.CheckIfProductIDExists(productID))
            {
                condition = Models.DAL.UpdateProduct(productID, productName, productDescription, stockQuantity); 
            }
            return condition;
        }
        public static int UpdateCompanyCustomer(int customerID, string companyName = "", string address = "")
        {
            int condition = -1;
            if (Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                condition = -2;
                if (Models.DAL.CheckIfCustomerIsCompanyCustomer(customerID))
                {
                    condition = Models.DAL.UpdateCompanyCustomer(customerID, companyName, address);
                }
            }
            return condition; 
        }
        public static int UpdatePrivateCustomer(int customerID, string firstName = "", string lastName = "", string address = "")
        {
            int condition = -1;
            if (Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                condition = -2;
                if (Models.DAL.CheckIfCustomerIsPrivateCustomer(customerID))
                {
                    condition = Models.DAL.UpdatePrivateCustomer(customerID, firstName, lastName, address);
                }
            }
            return condition; 
        }
        
        // Delete
        public static bool DeleteAllProducts()
        {
            return Models.DAL.DeleteAllProducts(); 
        }
        public static bool DeleteSpecificProduct (int productID)
        {
            bool condition = false; 
            if (Models.DAL.CheckIfProductIDExists(productID))
            {
                condition = Models.DAL.DeleteProduct(productID);
            }
            return condition; 
        }
        public static int DeleteAllOfASpecificCustomerType(int inputOption)
        {
            int condition = 0;
            if (inputOption == 1)
            {
                if (Models.DAL.DeleteAllPrivateCustomers())
                {
                    condition = 1; 
                }
                else
                {
                    condition = -1; 
                }
            }
            else if (inputOption == 2)
            {
                if (Models.DAL.DeleteAllCompanyCustomers())
                {
                    condition = 2; 
                }
                else
                {
                    condition = -2; 
                }
            }
            else if (inputOption == 3)
            {
                bool tempOne = Models.DAL.DeleteAllPrivateCustomers();
                bool tempTwo = Models.DAL.DeleteAllCompanyCustomers(); 
                if(tempOne && tempTwo)
                {
                    condition = 3;
                }
                else if (tempOne && !tempTwo)
                {
                    condition = -4; 
                }
                else if (!tempOne && tempTwo)
                {
                    condition = -5; 
                }
                else if (!tempOne && !tempTwo)
                {
                    condition = -3; 
                }
            }
            return condition; 
        }
        public static bool DeleteSpecificCustomer(int customerID)
        {
            bool condition = false; 
            if (Models.DAL.CheckIfCustomerIDExist(customerID))
            {
                if (Models.DAL.CheckIfCustomerIsPrivateCustomer(customerID))
                {
                    condition = Models.DAL.DeletePrivateCustomer(customerID);
                }
                else
                {
                    condition = Models.DAL.DeleteCompanyCustomer(customerID); 
                }
            }
            return condition; 
        } 
        public static bool DeleteAllOrders()
        {
            return Models.DAL.DeleteAllOrders(); 
        }
        public static bool DeleteOrder(int orderID)
        {
            return Models.DAL.DeleteOrder(orderID); 
        }
    }
}
