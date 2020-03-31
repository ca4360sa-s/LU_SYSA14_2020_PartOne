using LU_SYSA14_2020_PartOne.Controllers;
using LU_SYSA14_2020_PartOne.ServiceReferenceERPTwo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LU_SYSA14_2020_PartOne.Views
{
    public partial class IntegrationAndConfigurationTwo : Form
    {
        public IntegrationAndConfigurationTwo()
        {
            InitializeComponent();
            comboBoxOthertTables.SelectedIndex = 0;
            comboBoxER.SelectedIndex = 0; 
        }
        private void StartmenyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(1);
            this.Hide();
        }

        private void ProgramkonstruktionUppgift1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(2);
            this.Hide();
        }

        private void ProgramkonstruktionUppgift2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(3);
            this.Hide();
        }

        private void WebServiceUppgift1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(4);
            this.Hide();
        }

        private void WebServiceUppgift2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(5);
            this.Hide();
        }

        private void ERPintegreringUppgift1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(6);
            this.Hide();
        }

        private void ERPintegreringUppgift2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //---------------------------------------------------------------------------------------------

        private void radioBtnEmployeeAndRelated_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewAlternativesEmployeeAndRelated.Visible = true;
            groupBoxViewAlternatrivesOtherTables.Visible = false; 
        }

        private void radioBtnOtherTables_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxViewAlternativesEmployeeAndRelated.Visible = false;
            groupBoxViewAlternatrivesOtherTables.Visible = true;
        }

        private void btnOtherTablesDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewDisplay.DataSource = null;
            lblERP_TwoNF.Visible = false;
            lblERP_TwoPF.Visible = false;
            DataTable table = new DataTable(); 
            string input = comboBoxOthertTables.Text;
            if (input == "Anställda och dess anhöriga")
            {
                table = Controller_ERP_Two.DisplayEmployeeRelative();
                if(table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                    lblERP_TwoNF.Visible = true; 
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true; 
                }
            }
            else if (input == "Anställda som varit borta p.g.a. sjukdom under 2004")
            {
                table = Controller_ERP_Two.DisplayEmployeesSickDuring2004();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om anställda och deras sjukfrånvaro";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Förnamn för anställd med längs sjukfrånvaro")
            {
                table = Controller_ERP_Two.DisplayEmployeeMostAbsentDuring2004();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om vilken anställd som har längst sjukfrånvaro";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla nycklar i CRONUS-databasen")
            {
                table = Controller_ERP_Two.DisplayAllKeys();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om nycklarna i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if (input == "Alla index i CRONUS-databasen")
            {
                table = Controller_ERP_Two.DisplayAllIndexes();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om indexen i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla constraints för samtliga tabeller")
            {
                table = Controller_ERP_Two.DisplayAllConstraints();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om constraints i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla tabeller i CRONUS-databasen (alt. 1)")
            {
                table = Controller_ERP_Two.DisplayAllTablesViaINFORMATION_SCHEMA();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om tabellerna i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla tabeller i CRONUS-databasen (alt. 2)")
            {
                table = Controller_ERP_Two.DisplayAllTablesViaSYSOBJECT();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om tabellerna i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla kolumner i CRONUS-databasen (alt. 1)")
            {
                table = Controller_ERP_Two.DisplayAllColumsViaINFORMATION_SCHEMA(); 
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om kolumnerna i CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else if(input == "Alla kolumner i CRONUS-databasen (alt. 2)")
            {
                table = Controller_ERP_Two.DisplayAllColumsViaSYS();
                if (table.Rows.Count == 0)
                {
                    lblERP_TwoNF.Text = "Finns ingen data om kolumnernai CRONUS-databasen";
                    lblERP_TwoNF.Visible = true;
                }
                else
                {
                    dataGridViewDisplay.DataSource = table;
                    lblERP_TwoPF.Text = "Resultatet visas";
                    lblERP_TwoPF.Visible = true;
                }
            }
            else
            {
                lblERP_TwoNF.Text = "Ange ett visningsalternativ";
                lblERP_TwoNF.Visible = true;
            }

        }

        private void btnERDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewDisplay.DataSource = null;
            lblERP_TwoPF.Visible = false;
            lblERP_TwoNF.Visible = false;
            DataTable table = new DataTable();
            string input = comboBoxER.Text;
            if (radioBtnERContent.Checked)
            {
                //Content
                if (input == "Employee")
                {
                    table = Controller_ERP_Two.DisplayEmployee();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else if (input == "Employee Absence")
                {
                    table = Controller_ERP_Two.DisplayEmployeeAbsence();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else if (input == "Employee Qualification")
                {
                    table = Controller_ERP_Two.DisplayEmployeeQualification();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else if (input == "Employee Relative")
                {
                    table = Controller_ERP_Two.DisplayEmployeeRelative();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else if (input == "Employee Statistics Group")
                {
                    table = Controller_ERP_Two.DisplayEmployeeStatisticsGroup();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else if (input == "Employment Contract")
                {
                    table = Controller_ERP_Two.DisplayEmploymentContract();
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen data om anställda och dess anhöriga";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else
                {
                    lblERP_TwoNF.Text = "Välj ett visningsalternativ";
                    lblERP_TwoNF.Visible = true;
                }
            }
            if (radioBtnERMetadata.Checked)
            {
                //Metadata
                if (input.Length > 0)
                {
                    string tableName = $"CRONUS Sverige AB${input}";
                    table = Controller_ERP_Two.DisplayMetadata(tableName);
                    if (table.Rows.Count == 0)
                    {
                        lblERP_TwoNF.Text = "Finns ingen metadata om tabellen";
                        lblERP_TwoNF.Visible = true;
                    }
                    else
                    {
                        dataGridViewDisplay.DataSource = table;
                        lblERP_TwoPF.Text = "Resultatet visas";
                        lblERP_TwoPF.Visible = true;
                    }
                }
                else
                {
                    lblERP_TwoNF.Text = "Välj ett visningsalternativ";
                    lblERP_TwoNF.Visible = true;
                }
            }
        }

    }
}
