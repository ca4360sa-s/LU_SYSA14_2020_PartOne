using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne.Models
{
    static class DAL
    {
        private static string connectionString = "Data Source=CS-LEGIONY720;Initial Catalog=LU_SYSA14_2020_PartOne_DB;Integrated Security=True";
            //"Data Source=CS-LegionY720;Initial Catalog=LU_SYSA14_2020_PartOne_DB;Integrated Security=True;Pooling=False"; 

        // Check/Exists-methods 

        public static bool CheckIfCustomerIDExist(int customerID)
        {
            bool condition = false;
            bool conditionPrivateCustomer = false;
            bool conditionCompanyCustomer = false; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM PrivateCustomer WHERE customerID = @Value; ";

                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        conditionPrivateCustomer = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171201);
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM CompanyCustomer WHERE customerID = @Value; ";

                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        conditionCompanyCustomer = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171201);
            }
            if(conditionPrivateCustomer || conditionCompanyCustomer)
            {
                condition = true;
            }
            return condition; 
        }
        public static bool CheckIfCustomerIsPrivateCustomer (int customerID)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT customerID FROM PrivateCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader(); 
                    if (dataReader.HasRows)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171230);
            }
            return condition;
        }
        public static bool CheckIfCustomerIsCompanyCustomer (int customerID)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT customerID FROM CompanyCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171231);
            }
            return condition;
        }
        public static bool CheckIfProductIDExists(int productID)
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT productID FROM Product WHERE productID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", productID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        condition = true; 
                    }
                    connection.Close(); 
                }
            } 
            catch (SqlException)
            {
                Controller.ErrorHandler(19171202); 
            }

            return condition; 
        }
        public static bool CheckIfOrderIDExist(int orderID)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT orderID FROM Orders WHERE orderID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", orderID);

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        condition = true;
                    }
                    connection.Close(); 
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171203);
            }
            return condition; 
        }        
        public static int StockQuantityForSpecificProduct(int productID)
        {
            int stockQuantity = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT stockQuantity FROM Product WHERE productID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", productID);
                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    stockQuantity = dataReader.GetInt32(0);
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171225);
            }
            return stockQuantity;
        }


        //Create-methods
        public static bool CreatePrivateCustomer(int customerID, string firstName, string lastName, string address)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "INSERT INTO PrivateCustomer (customerID, firstName, lastName, address)" +
                        "VALUES (@Value1, @Value2, @Value3, @Value4);";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value1", customerID);
                    command.Parameters.AddWithValue("@Value2", firstName);
                    command.Parameters.AddWithValue("@Value3", lastName);
                    command.Parameters.AddWithValue("@Value4", address);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected>0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {

                Controller.ErrorHandler(19171204); 
            }
            return condition; 
        }
        public static bool CreateCompanyCustomer(int customerID, string companyName, string address)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection= new SqlConnection(connectionString))
                {
                    string tempQuery = "INSERT INTO CompanyCustomer (customerID, companyName, address)" +
                        "VALUES (@Value1, @Value2, @Value3);"; 
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value1", customerID);
                    command.Parameters.AddWithValue("@Value2", companyName);
                    command.Parameters.AddWithValue("@Value3", address);
                    int rowsAffected = command.ExecuteNonQuery(); 

                    if(rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close(); 
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171205);
            }
            return condition; 
        }
        public static bool CreateProduct(int productID, string productName, string productDescription, int stockQuantity)
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "INSERT INTO Product (productID, productName, productDescription, stockQuantity )" +
                        "VALUES (@Value1, @Value2, @Value3, @Value4);";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value1", productID);
                    command.Parameters.AddWithValue("@Value2", productName);
                    command.Parameters.AddWithValue("@Value3", productDescription);
                    command.Parameters.AddWithValue("@Value4", stockQuantity);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171206);
            }
            return condition;
        }
        public static bool CreateOrder(int orderID, int privateCustomerID = 0, int companyCustomerID = 0)
        {
            bool condition = false;

            if (privateCustomerID != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "INSERT INTO Orders (orderID, privateCustomerID)" +
                            "VALUES (@Value1, @Value2);";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", orderID);
                        command.Parameters.AddWithValue("@Value2", privateCustomerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition = true;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171207);
                }
            } else if (companyCustomerID != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "INSERT INTO Orders (orderID, companyCustomerID)" +
                            "VALUES (@Value1, @Value2);";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", orderID);
                        command.Parameters.AddWithValue("@Value2", companyCustomerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition = true;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171207);
                }
            }
            return condition;
        }
        public static int CreateProduct_Orders(int productID, int orderID, int quantity)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "INSERT INTO Product_Orders (productID, orderID, quantity)" +
                        "VALUES (@Value1, @Value2, @Value3);";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value1", productID);
                    command.Parameters.AddWithValue("@Value2", orderID);
                    command.Parameters.AddWithValue("@Value3", quantity);
                    rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171208);
            }
            return rowsAffected; 
        }

        // Read(View)-methods
        public static DataTable DisplayAllCompanyCustomers()
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM CompanyCustomer;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("KundID", typeof(int));
                        tempTable.Columns.Add("Företagsnamn", typeof(string));
                        tempTable.Columns.Add("Adress", typeof(string));
                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171217);
            }
            return tempTable;
        }
        public static DataTable DisplayAllPrivateCustomers()
        {
            DataTable tempTable = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM PrivateCustomer;"; 
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("KundID", typeof(int));
                        tempTable.Columns.Add("Förnamn", typeof(string));
                        tempTable.Columns.Add("Efternamn", typeof(string));
                        tempTable.Columns.Add("Adress", typeof(string));
                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            string tempFour = dataReader.GetString(3);
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour });
                        }
                    }
                    connection.Close(); 
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171216); 
            }
            return tempTable;
        }
        public static DataTable DisplayAllCustomers()
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT CONCAT(pc.customerID, cc.customerID), CONCAT(pc.address, cc.address), " +
                        "pc.firstName, pc.lastName, cc.companyName FROM PrivateCustomer AS pc FULL OUTER JOIN " +
                        "CompanyCustomer AS cc ON pc.customerID = cc.customerID;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("KundID:n", typeof(int));
                        tempTable.Columns.Add("Adress", typeof(string));
                        tempTable.Columns.Add("Förnamn", typeof(string));
                        tempTable.Columns.Add("Efternamn", typeof(string));
                        tempTable.Columns.Add("Företagsnamn", typeof(string));
                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetString(0);
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = "";
                            if (!dataReader.IsDBNull(2))
                            {
                                tempThree = dataReader.GetString(2);
                            }
                            string tempFour = "";
                            if (!dataReader.IsDBNull(3))
                            {
                                tempFour = dataReader.GetString(3);

                            }
                            string tempFive = "";
                            if (!dataReader.IsDBNull(4))
                            {
                                tempFive = dataReader.GetString(4);
                            }                            
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour, tempFive });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171218);
            }
            return tempTable;
        }
        public static DataTable DisplaySpecificPrivateCustomer(int customerID)
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM PrivateCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("KundID", typeof(int));
                        tempTable.Columns.Add("Förnamn", typeof(string));
                        tempTable.Columns.Add("Efternamn", typeof(string));
                        tempTable.Columns.Add("Adress", typeof(string));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            string tempFour = dataReader.GetString(3);
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171219);
            }
            return tempTable;
        }
        public static DataTable DisplaySpecificCompanyCustomer(int customerID)
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM CompanyCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("KundID", typeof(int));
                        tempTable.Columns.Add("Företagsnamn", typeof(string));
                        tempTable.Columns.Add("Adress", typeof(string));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);

                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171220);
            }

            return tempTable;
        }
        public static DataTable DisplayAllProducts()
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM Product;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("ProduktID", typeof(int));
                        tempTable.Columns.Add("Produktnamn", typeof(string));
                        tempTable.Columns.Add("Beskrivning", typeof(string));
                        tempTable.Columns.Add("Lagervolym", typeof(int));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            string tempFour = dataReader.GetInt32(3).ToString();
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171221);
            }

            return tempTable;
        }
        public static DataTable DisplaySpecificProduct(int productID)
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT * FROM Product WHERE productID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", productID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("ProduktID", typeof(int));
                        tempTable.Columns.Add("Produktnamn", typeof(string));
                        tempTable.Columns.Add("Beskrivning", typeof(string));
                        tempTable.Columns.Add("Lagervolym", typeof(int));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            string tempFour = dataReader.GetInt32(3).ToString();
                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171222);
            }

            return tempTable;
        }
        public static DataTable DisplayAllOrders()
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT orderID, CONCAT(privateCustomerID, companyCustomerID) FROM Orders;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("OrderID", typeof(int));
                        tempTable.Columns.Add("KundID", typeof(int));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);

                            tempTable.Rows.Add(new string[] { tempOne, tempTwo });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171223);
            }
            return tempTable;
        }
        public static DataTable DisplaySpecificOrder(int orderID)
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT p.productID, p.productName, p.productDescription, po.quantity " +
                        "FROM Product AS p JOIN Product_Orders AS po ON p.productID = po.productID WHERE po.orderID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", orderID);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("ProduktID", typeof(int));
                        tempTable.Columns.Add("Produktnamn", typeof(string));
                        tempTable.Columns.Add("Beskrivning", typeof(string));
                        tempTable.Columns.Add("Kvantitet", typeof(int));

                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            string tempTwo = dataReader.GetString(1);
                            string tempThree = dataReader.GetString(2);
                            string tempFour = dataReader.GetInt32(3).ToString(); 

                            tempTable.Rows.Add(new string[] { tempOne, tempTwo, tempThree, tempFour });
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171224);
            }
            return tempTable;
        }
        public static DataTable DisplayAllOrdersForSpecificCustomer(int customerID)
        {
            DataTable tempTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "SELECT orderID FROM Orders WHERE privateCustomerID = @Value OR companyCustomerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("OrderID", typeof(int));
                        while (dataReader.Read())
                        {
                            string tempOne = dataReader.GetInt32(0).ToString();
                            tempTable.Rows.Add(tempOne);
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171223);
            }
            return tempTable;
        }

        // Update-methods
        public static int UpdatePrivateCustomer(int customerID, string firstName = "", string lastName = "", string address = "")
        {
            /* Returns 0 if the method failed (didn't perform any change) and 1 if the method executed a firstName update correctly. 10 if the method executed
             * a lastName update correctly. 100 if the method executed a address update correctly. Note that any combination of these may occur (1, 10, 11, 100,
             * 101, 110, 111).
             *
             * If a SqlException was triggered the metod will return 19171209. 
             * Note thet 19171209 is specific for SqlExceptions in this method. 
             */
            int condition = 0;
            if (firstName.Length > 0)
            { 
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE PrivateCustomer SET firstName = @Value1 WHERE customerID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", firstName);
                        command.Parameters.AddWithValue("@Value2", customerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 1;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171209);
                }  
            }
            if (lastName.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE PrivateCustomer SET lastName = @Value1 WHERE customerID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", lastName);
                        command.Parameters.AddWithValue("@Value2", customerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 10;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171209);
                }
            }
            if (address.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE PrivateCustomer SET address = @Value1 WHERE customerID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", address);
                        command.Parameters.AddWithValue("@Value2", customerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 100;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171209);
                }
            }
            return condition;
        }
        public static int UpdateCompanyCustomer(int customerID, string companyName = "", string address = "")
        {
            /* Returns 0 if the method failed (didn't perform any change) and 1 if the method executed a companyName update correctly. 10 if the method executed
             * a address update correctly. Note that any combination of these may occur (1, 10, 11,).
             *
             * If a SqlException was triggered the metod will return 19171210. Note thet 19171210 is specific for SqlExceptions in this method. 
             */
            int condition = 0;
            if (companyName.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE CompanyCustomer SET companyName = @Value1 WHERE customerID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", companyName);
                        command.Parameters.AddWithValue("@Value2", customerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 1;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171210);
                }
            }
            if (address.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE CompanyCustomer SET address = @Value1 WHERE customerID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", address);
                        command.Parameters.AddWithValue("@Value2", customerID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 10;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171210);
                }
            }
            return condition;
        }
        public static int UpdateProduct(int productID, string productName = "", string productDescription = "", int stockQuantity = -1)
        {
            /* Returns 0 if the method failed (didn't perform any change) and 1 if the method executed a productName update correctly. 10 if the method executed
             * a productDiscription update correctly. 100 if the method executed a stockQuantity update correctly. Note that any combination of these may occur (1, 10, 11, 100,
             * 101, 110, 111).
             * 
             * If a SqlException was triggered the metod will return 19171211. 
             * Note thet 19171211 is specific for SqlExceptions in this method. 
             * If a userinput is < 0 "error" 5181801 will be returned by the method. 
             */
            int condition = 0;

            if (productName.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE Product SET productName = @Value1 WHERE productID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", productName);
                        command.Parameters.AddWithValue("@Value2", productID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 1;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171211);
                }
            }
            if (productDescription.Length > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE Product SET productDescription = @Value1 WHERE productID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", productDescription);
                        command.Parameters.AddWithValue("@Value2", productID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 10;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171211);
                }
            }
            if (stockQuantity >= 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string tempQuery = "UPDATE Product SET stockQuantity = @Value1 WHERE productID = @Value2;";
                        SqlCommand command = new SqlCommand(tempQuery, connection);
                        connection.Open();
                        command.Prepare();
                        command.Parameters.AddWithValue("@Value1", stockQuantity);
                        command.Parameters.AddWithValue("@Value2", productID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            condition += 100;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException)
                {
                    Controller.ErrorHandler(19171211);
                }
            }
            if (stockQuantity <0)
            {
                Controller.ErrorHandler(5181801); 
            }
            return condition;
        }

        // Delete-methods
        public static bool DeletePrivateCustomer(int customerID)
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM PrivateCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171212);
            }
            return condition;
        }
        public static bool DeleteAllPrivateCustomers()
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM PrivateCustomer;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(191712226);
            }

            return condition;
        }
        public static bool DeleteCompanyCustomer(int customerID)
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM CompanyCustomer WHERE customerID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", customerID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171213);
            }

            return condition;
        }
        public static bool DeleteAllCompanyCustomers()
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM CompanyCustomer;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171227);
            }

            return condition;
        }
        public static bool DeleteProduct(int productID)
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM Product WHERE productID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", productID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171214);
            }

            return condition;
        }
        public static bool DeleteAllProducts()
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM Product;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171228);
            }

            return condition;
        }
        public static bool DeleteOrder(int orderID)
        {
            bool condition = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM Orders WHERE orderID = @Value;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", orderID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171228);
            }

            return condition;
        }
        public static bool DeleteAllOrders()
        {
            bool condition = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tempQuery = "DELETE FROM Orders;";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    connection.Open();
                    command.Prepare();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        condition = true;
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Controller.ErrorHandler(19171229);
            }

            return condition;
        }


    }
}
