using LU_SYSA14_2020_PartOne.ServiceReferenceERPTwo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne.Controllers
{
    static class Controller_ERP_Two
    {
        //static AWebServiceForContentAndMetadataFromCRONUSSoapClient proxy = new AWebServiceForContentAndMetadataFromCRONUSSoapClient();
        private static AWebServiceForContentAndMetadataFromCRONUSSoapClient proxy = new AWebServiceForContentAndMetadataFromCRONUSSoapClient();
        public static DataTable DisplayMetadata(string tableName)
        {
            DataTable table = new DataTable();
            if (proxy.DisplayMetadataFromTable(tableName).Length > 0)
            {
                table.Columns.Add("COLUMN_NAME", typeof(string));
                table.Columns.Add("ORDINAL_POSITION", typeof(int));
                table.Columns.Add("IS_NULLABLE", typeof(string));
                table.Columns.Add("DATA_TYPE", typeof(string));
                table.Columns.Add("CHARACTER_MAXIMUM_LENGTH", typeof(int));

                foreach (var v in proxy.DisplayMetadataFromTable(tableName))
                {
                    table.Rows.Add(v.Column_name, v.Ordinal_position, v.Is_nullable, v.Data_type, v.Character_maximum_length);
                }
            }
            return table;
        }     
        public static DataTable DisplayEmployee()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployee().Length > 0)
            {
                table.Columns.Add("No_", typeof(string));
                table.Columns.Add("First Name", typeof(string));
                table.Columns.Add("Last Name", typeof(string));
                table.Columns.Add("Job Title", typeof(string));
                table.Columns.Add("Address", typeof(string));
                table.Columns.Add("City", typeof(string));
                foreach (var v in proxy.DisplayEmployee())
                {
                    table.Rows.Add(v.No_, v.FirstName, v.LastName, v.JobTitle, v.Address, v.City);
                }
            }
            return table;
        }                     
        public static DataTable DisplayEmployeeAbsence()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeeAbsence().Length > 0)
            {
                table.Columns.Add("Entry No_", typeof(int));
                table.Columns.Add("Employee No_", typeof(string));
                table.Columns.Add("From Date", typeof(DateTime));
                table.Columns.Add("Cause Of Absence Code", typeof(string));
                foreach (var v in proxy.DisplayEmployeeAbsence())
                {
                    table.Rows.Add(v.EntryNo_, v.EmployeeNo_, v.FromDate, v.CauseOfAbsenceCode);
                }
            }
            return table;
        }
        public static DataTable DisplayEmployeeQualification()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeeQualification().Length > 0)
            {
                table.Columns.Add("Employee No_", typeof(string));
                table.Columns.Add("Line No_", typeof(int));
                table.Columns.Add("Qualification Code", typeof(string));
                table.Columns.Add("Description", typeof(string));
                foreach (var v in proxy.DisplayEmployeeQualification())
                {
                    table.Rows.Add(v.EmployeeNo_, v.LineNo_, v.QualificationCode, v.Description);
                }
            }
            return table;
        }
        public static DataTable DisplayEmployeeStatisticsGroup()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeeStatisticsGroup().Length > 0)
            {
                table.Columns.Add("Code", typeof(string));
                table.Columns.Add("Description", typeof(string));
                foreach (var v in proxy.DisplayEmployeeStatisticsGroup())
                {
                    table.Rows.Add(v.Code, v.Description);
                }
            }
            return table;
        }
        public static DataTable DisplayEmploymentContract()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmploymentContract().Length > 0)
            {
                table.Columns.Add("Code", typeof(string));
                table.Columns.Add("Description", typeof(string));
                foreach (var v in proxy.DisplayEmploymentContract())
                {
                    table.Rows.Add(v.Code, v.Description);
                }
            }
            return table;
        }
        public static DataTable DisplayEmployeeRelative()
        {                    
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeesAndRelatives().Length > 0)
            {
                table.Columns.Add("Employee No_", typeof(string));
                table.Columns.Add("Line No_", typeof(int));
                table.Columns.Add("Relative Code", typeof(string));
                table.Columns.Add("First Name", typeof(string));
                table.Columns.Add("Last Name", typeof(string));
                foreach (var v in proxy.DisplayEmployeesAndRelatives())
                {
                    table.Rows.Add(v.EmployeeNo_, v.LineNo_, v.RelativeCode, v.FirstName, v.LastName);
                }
            }

                return table; 
        }
        //----------------------------------------------------------
        public static DataTable DisplayEmployeesSickDuring2004()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeesSickDuring2004().Length > 0)
            {
                table.Columns.Add("No_", typeof(string));
                table.Columns.Add("First Name", typeof(string));
                table.Columns.Add("Last Name", typeof(string));
                table.Columns.Add("Job Title", typeof(string));
                table.Columns.Add("Address", typeof(string));
                table.Columns.Add("City", typeof(string));
                foreach (var v in proxy.DisplayEmployeesSickDuring2004())
                {
                    table.Rows.Add(v.No_, v.FirstName, v.LastName, v.JobTitle, v.Address, v.City);
                }
            }
            return table;
        }
        public static DataTable DisplayEmployeeMostAbsentDuring2004()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayEmployeeMostAbsentDuring2004().Length > 0)
            {
                table.Columns.Add("First Name", typeof(string));
                foreach (var v in proxy.DisplayEmployeeMostAbsentDuring2004())
                {
                    table.Rows.Add(v.FirstName);
                }
            }
            return table;
        }
        public static DataTable DisplayAllKeys()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllKeys().Length > 0)
            {
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("xtype", typeof(string));
                foreach (var v in proxy.DisplayAllKeys())
                {
                    table.Rows.Add(v.Name, v.ID, v.Xtype);
                }
            }
            return table;
        }
        public static DataTable DisplayAllIndexes()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllIndexes().Length > 0)
            {
                table.Columns.Add("object_id", typeof(int));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("index_id", typeof(int));
                table.Columns.Add("type_desc", typeof(string));
                foreach (var v in proxy.DisplayAllIndexes())
                {
                    table.Rows.Add(v.Object_id, v.Name, v.Index_id, v.Typ_desc);
                }
            }
            return table;
        }
        public static DataTable DisplayAllConstraints()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllConstraints().Length > 0)
            {
                table.Columns.Add("CONSTRAINT_NAME", typeof(string));
                table.Columns.Add("CONSTRAINT_TYPE", typeof(string));
                foreach (var v in proxy.DisplayAllConstraints())
                {
                    table.Rows.Add(v.Constraint_name, v.Constraint_type);
                }
            }
            return table;
        }
        public static DataTable DisplayAllTablesViaINFORMATION_SCHEMA()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllTablesViaINFORMTION_SCHEMA().Length > 0)
            {
                table.Columns.Add("TABLE_NAME", typeof(string));
                table.Columns.Add("TABLE_TYPE", typeof(string));
                foreach (var v in proxy.DisplayAllTablesViaINFORMTION_SCHEMA())
                {
                    table.Rows.Add(v.NameT, v.TypeT);
                }
            }
            return table;
        }
        public static DataTable DisplayAllTablesViaSYSOBJECT()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllTablesViaSYSOBJECT().Length > 0)
            {
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("xtype", typeof(string));
                foreach (var v in proxy.DisplayAllTablesViaSYSOBJECT())
                {
                    table.Rows.Add(v.NameT, v.TypeT);
                }
            }
            return table;
        }
        public static DataTable DisplayAllColumsViaINFORMATION_SCHEMA()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayAllColumsViaINFORMATION_SCHEMA().Length > 0)
            {
                table.Columns.Add("TABLE_NAME", typeof(string));
                foreach (var v in proxy.DisplayAllColumsViaINFORMATION_SCHEMA())
                {
                    table.Rows.Add(v.NameT);
                }
            }
            return table;
        }
        public static DataTable DisplayAllColumsViaSYS()
        {
            DataTable table = new DataTable();
            if (proxy.DisplayALLColumsViaSYS().Length > 0)
            {
                table.Columns.Add("name", typeof(string));
                foreach (var v in proxy.DisplayALLColumsViaSYS())
                {
                    table.Rows.Add(v.NameT);
                }
            }
            return table;
        }
   
    
    
    }

    
}
