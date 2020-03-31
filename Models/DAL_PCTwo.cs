using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LU_SYSA14_2020_PartOne.Models
{
    static class DAL_PCTwo
    {
        private static string ConnectionString
        {
            get { return @"Server = uwdb18.srv.lu.se\icssql001; Database = SYSA14_PK_ProgAssignment2; User Id = sysa14reader; Password = INFreader1"; }

            // String connectionString = @"Server=uwdb18.srv.lu.se\icssql001; Database=SYSA14_PK_ProgAssignment2; User Id=sysa14reader; Password = INFreader1";
            // Data Source=CS-LEGIONY720;Initial Catalog=TestDatabase;Integrated Security=True
        }
        public static DataTable DisplayNumberOfRows()
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT[Tables].name AS [Tabellens namn], SUM([Partitions].[rows]) AS[Antalet rader] " +
                        "FROM sys.tables AS[Tables] JOIN sys.partitions AS[Partitions] ON[Tables].[object_id] = [Partitions].[object_id] " +
                        "AND[Partitions].index_id IN(0, 1) JOIN TablesOfInterest ON[Tables].name = TablesOfInterest.tableName GROUP BY[Tables].name; ", connection);
                    connection.Open();
                    //command.Prepare(); 
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("Tabellnamn", typeof(String));
                        tempTable.Columns.Add("Antal rader", typeof(String));
                        while (dataReader.Read())
                        {
                            String tempOne = dataReader.GetString(0).ToString();
                            String tempTwo = dataReader.GetInt64(1).ToString();
                            tempTable.Rows.Add(new String[] { tempOne, tempTwo });
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Controller_PCTwo.ErrorHandler(19171250);
                MessageBox.Show(e.Message);  
            }
 
            return tempTable;
        }
        public static DataTable DisplayAllColumnsName()
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT TABLE_NAME AS [Tabellens namn], COLUMN_NAME AS [Kolumnens namn] FROM INFORMATION_SCHEMA.COLUMNS " +
                        "JOIN TablesOfInterest AS[TI] ON  INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = TI.tableName; ", connection);
                    connection.Open();
                    //command.Prepare();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("Tabellnamn", typeof(String));
                        tempTable.Columns.Add("Kolumnnamn", typeof(String));
                        while (dataReader.Read())
                        {
                            String tempOne = dataReader.GetString(0).ToString();
                            String tempTwo = dataReader.GetString(1).ToString();
                            tempTable.Rows.Add(new String[] { tempOne, tempTwo });
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Controller_PCTwo.ErrorHandler(19171251);
                MessageBox.Show(e.Message); 
            }
            return tempTable;
        }
        public static DataTable DisplayAllColumnsName(string specificTableName)
        {
            DataTable tempTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                        "JOIN TablesOfInterest ON INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = TablesOfInterest.tableName " +
                        "WHERE TablesOfInterest.tableName = @Value";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.Prepare();
                    command.Parameters.AddWithValue("@Value", specificTableName);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        tempTable.Columns.Add("Kolumnnamn", typeof(String));
                        while (dataReader.Read())
                        {
                            String tempOne = dataReader.GetString(0).ToString();
                            tempTable.Rows.Add(tempOne);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
               Controller_PCTwo.ErrorHandler(19171252);
                MessageBox.Show(e.Message);
            }
            return tempTable;
        }


    }
}
