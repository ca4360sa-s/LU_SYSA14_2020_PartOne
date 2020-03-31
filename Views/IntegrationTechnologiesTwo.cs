using LU_SYSA14_2020_PartOne.ServiceReferenceWSTwo;
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
    public partial class IntegrationTechnologiesTwo : Form
    {
        public IntegrationTechnologiesTwo()
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
        }

        private void ERPintegreringUppgift1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(6);
            this.Hide();
        }

        private void ERPintegreringUppgift2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.HandleMenuChoice(7);
            this.Hide();
        }

        //-----------------------------------------------------------------------------------
        public void ClearAllFeedback()
        {
            lblDisplayAllProductsNF.Visible = false;
            lblDisplayAllProductsPF.Visible = false; 
        }
        private void btnDisplayAllProducts_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dataGridViewDisplayAllProducts.DataSource = null;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProduktID", typeof(int));
            dataTable.Columns.Add("Produktnamn", typeof(string));
            dataTable.Columns.Add("Beskrivning", typeof(string));
            dataTable.Columns.Add("Lagerkvantitet", typeof(int));
            AWebServiceToHandleDBSoapClient client = new AWebServiceToHandleDBSoapClient();
            if(client.DisplayAllProducts().Length == 0){
                lblDisplayAllProductsNF.Text = "Finns inga produkter att visa";
                lblDisplayAllProductsNF.Visible = true; 
            }
            else
            {
                foreach (var v in client.DisplayAllProducts())
                {
                    dataTable.Rows.Add(new string[] { v.ProductID.ToString(), v.ProductName, v.ProductDiscription, v.StockQuantity.ToString() });
                }
                dataGridViewDisplayAllProducts.DataSource = dataTable;
                lblDisplayAllProductsPF.Text = "Resultatet visas";
                lblDisplayAllProductsPF.Visible = true; 
            }


        }
    }
}
