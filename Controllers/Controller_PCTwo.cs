using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne
{
    static class Controller_PCTwo
    {
        public static void ErrorHandler(int errorCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SqlException i DAL via metoden: ");

            switch (errorCode)
            {               
                case 19171250:
                    builder.Append("DisplayNumberOfRows()");
                    break;
                case 19171251:
                    builder.Append("DisplayAllColumnsName()");

                    break;
                case 19171252:
                    builder.Append("DisplayAllColumnsName(string specificTableName)");

                    break;
                default:
                    break; 
            }
            ModelViews.programConstructionTwo.DisplayErrorMessage(builder.ToString()); 
        }
        public static DataTable DisplayNumberOfRows ()
        {
            return Models.DAL_PCTwo.DisplayNumberOfRows();
        }
        public static DataTable DisplayAllColumnsName()
        {
            return Models.DAL_PCTwo.DisplayAllColumnsName();
        }
        public static DataTable DisplayAllColumsNameForSpecificTable(string tableName)
        {
            return Models.DAL_PCTwo.DisplayAllColumnsName(tableName); 
        }

    }
}
