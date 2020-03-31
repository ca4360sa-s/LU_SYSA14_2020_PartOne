using LU_SYSA14_2020_PartOne.ServiceReferenceERPOne;
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
    public partial class IntegrationAndConfigurationOne : Form
    {
        public IntegrationAndConfigurationOne()
        {
            InitializeComponent();
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
        }

        private void ERPintegreringUppgift2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(7);
            this.Hide();
        }

        //-------------------------------------------------------------------------------------
        AWebServiceForCRONUSSoapClient proxy = new AWebServiceForCRONUSSoapClient(); 
        public void ClearAllFeedback()
        {
            // Create Employee
            lblCENo_NF.Visible = false; 
            lblCEFirstNameNF.Visible = false;
            lblCELastNameNF.Visible = false;
            lblCEJobTitleNF.Visible = false;
            lblCEAddressNF.Visible = false;
            lblCECityNF.Visible = false;
            lblCECreateEmployeeNF.Visible = false;
            lblCECreateEmployeePF.Visible = false;
            // Update Employee
            lblUENo_NF.Visible = false;
            lblUpdateEmployeeNF.Visible = false;
            lblUpdateEmployeePF.Visible = false;
            //Delete Employee
            lblDENo_NF.Visible = false;
            lblDeleteEmployeeNF.Visible = false;
            lblDeleteEmployeePF.Visible = false;
            // View Alternatives
            lblViewSpecificEmployeeNo_NF.Visible = false;
            lblVEViewAllNF.Visible = false;
            lblVEViewAllPF.Visible = false;

        }
        public void ClearAllInputCE()
        {
            //Create input
            textBoxCENo_.Text = "";
            textBoxCEFirstName.Text = "";
            textBoxCELastName.Text = "";
            textBoxCEJobTitle.Text = "";
            textBoxCEAddress.Text = "";
            textBoxCECity.Text = "";
        }
        public void ClearAllInputUE()
        {          
            // Update input
            textBoxUENo_.Text = "";
            textBoxUEFirstName.Text = "";
            textBoxUELastName.Text = "";
            textBoxUEJobTitle.Text = "";
            textBoxUEAddress.Text = "";
            textBoxUECity.Text = "";
        }

        private void radioBtnViewSpecificEmployee_CheckedChanged(object sender, EventArgs e)
        {
            panelViewSpecificEmployee.Visible = true; 
        }

        private void radioBtnViewAllEmployees_CheckedChanged(object sender, EventArgs e)
        {
            panelViewSpecificEmployee.Visible = false;
            textBoxViewSpecificEmployee.Text = "";
        }

        private void btnCECreateEmployee_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string no_ = textBoxCENo_.Text;
            string firstName = textBoxCEFirstName.Text;
            string lastName = textBoxCELastName.Text;
            string jobTitle = textBoxCEJobTitle.Text;
            string address = textBoxCEAddress.Text;
            string city = textBoxCECity.Text;
            bool conditionOne = true; 
            if (no_.Length == 0)
            {
                lblCENo_NF.Text = "Ange No_";
                lblCENo_NF.Visible = true; 
                conditionOne = false; 
            }
            if (firstName.Length == 0)
            {
                lblCEFirstNameNF.Text = "Ange förnamn";
                lblCEFirstNameNF.Visible = true; 
                conditionOne = false;

            }
            if (lastName.Length == 0)
            {
                lblCELastNameNF.Text = "Ange efternamn";
                lblCELastNameNF.Visible = true; 
                conditionOne = false;

            }
            if (jobTitle.Length == 0)
            {
                lblCEJobTitleNF.Text = "Ange jobbtitel";
                lblCEJobTitleNF.Visible = true; 
                conditionOne = false;

            }
            if (address.Length == 0)
            {
                lblCEAddressNF.Text = "Ange adress";
                lblCEAddressNF.Visible = true; 
                conditionOne = false;

            }
            if (city.Length == 0)
            {
                lblCECityNF.Text = "Ange stad";
                lblCECityNF.Visible = true; 
                conditionOne = false;

            }
            if (conditionOne)
            {
                bool tempEmployee = proxy.CreateEmployee(no_, firstName, lastName, jobTitle, address, city);
                if (tempEmployee)
                {
                    lblCECreateEmployeePF.Text = "Den anställde har lagts till";
                    lblCECreateEmployeePF.Visible = true;
                    ClearAllInputCE(); 
                }
                else
                {
                    lblCECreateEmployeeNF.Text = "Den anställde finns redan";
                    lblCECreateEmployeeNF.Visible = true; 
                }
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string no_ = textBoxUENo_.Text;
            string firstName = textBoxUEFirstName.Text;
            string lastName = textBoxUELastName.Text;
            string jobTitle = textBoxUEJobTitle.Text;
            string address = textBoxUEAddress.Text;
            string city = textBoxUECity.Text; 
            if(no_.Length == 0)
            {
                lblUENo_NF.Text = "Ange aktuellt no_";
                lblUENo_NF.Visible = true; 
            }
            else
            {
                string feedback = proxy.UpdateEmployee(no_, firstName, lastName, jobTitle, address, city); 
                if(feedback.Length == 0)
                {
                    lblUpdateEmployeeNF.Text = "Det angivna no_ tillhör ingen anställd";
                    lblUpdateEmployeeNF.Visible = true; 
                }
                else
                {
                    lblUpdateEmployeePF.Text = feedback;
                    lblUpdateEmployeePF.Visible = true;
                    ClearAllInputUE(); 
                }
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            ClearAllFeedback(); 
            string no_ = textBoxDENo_.Text; 
            if(no_.Length == 0)
            {
                lblDENo_NF.Text = "Ange aktuellt no_";
                lblDENo_NF.Visible = true;
            }
            else
            {
                if (!proxy.DeleteEmployee(no_))
                {
                    lblDeleteEmployeeNF.Text = "Angivet no_ finns ej";
                    lblDeleteEmployeeNF.Visible = true;                    
                }
                else
                {
                    lblDeleteEmployeePF.Text = "Den anställde har raderats";
                    lblDeleteEmployeePF.Visible = true;
                    textBoxDENo_.Text = ""; 
                }
            }
        }

        private void btnVCViewUnspecificCustomers_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dataGridViewDisplay.DataSource = null; 
            string no_ = textBoxViewSpecificEmployee.Text;
            DataTable table = new DataTable();
            table.Columns.Add("No_", typeof(string));
            table.Columns.Add("Förnamn", typeof(string));
            table.Columns.Add("Efternamn", typeof(string));
            table.Columns.Add("Jobbtitel", typeof(string));
            table.Columns.Add("Adress", typeof(string));
            table.Columns.Add("Stad", typeof(string));
            if (radioBtnViewAllEmployees.Checked)
            {
                no_ = "";
                if (proxy.ViewEmployee(no_).Length == 0)
                {
                    lblVEViewAllNF.Text = "Finns inga anställda";
                    lblVEViewAllNF.Visible = true; 
                }
                else
                {
                    foreach (var v in proxy.ViewEmployee(no_))
                    {
                        table.Rows.Add(new string[] { v.No_, v.FirstName, v.LastName, v.JobTitle, v.Address, v.City });
                    }
                    dataGridViewDisplay.DataSource = table;
                    lblVEViewAllPF.Text = "Resutatet visas";
                    lblVEViewAllPF.Visible = true; 
                }
            }
            else
            {
                if(no_.Length == 0)
                {
                    lblViewSpecificEmployeeNo_NF.Text = "Ange no_";
                    lblViewSpecificEmployeeNo_NF.Visible = true; 
                }
                else
                {
                    if (proxy.ViewEmployee(no_).Length == 0)
                    {
                        lblViewSpecificEmployeeNo_NF.Text = "No_:t finns ej";
                        lblViewSpecificEmployeeNo_NF.Visible = true;
                    }
                    else
                    {
                        foreach (var v in proxy.ViewEmployee(no_))
                        {
                            table.Rows.Add(new string[] { v.No_, v.FirstName, v.LastName, v.JobTitle, v.Address, v.City });
                        }
                        dataGridViewDisplay.DataSource = table;
                        lblVEViewAllPF.Text = "Resutatet visas";
                        lblVEViewAllPF.Visible = true;
                    }
                }
            }
           
        }
    }
}
