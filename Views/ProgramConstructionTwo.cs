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
    public partial class ProgramConstructionTwo : Form
    {
        public ProgramConstructionTwo()
        {
            InitializeComponent();
        }

        private DataTable numberOfRows = new DataTable();
        private DataTable allColumnNames = new DataTable();

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
            Controller.HandleMenuChoice(7);
            this.Hide();
        }

        // ---------------------------------------------------------------------------------------
        public void DisplayErrorMessage (string errorMessage)
        {
            lblSQLFeedback.Text = errorMessage;
            lblSQLFeedback.Visible = true; 
        }
        public void ClearAllFeedback()
        {
            lblRetrieveDataNF.Visible = false;
            lblRetrieveDataPF.Visible = false;
            lblViewAlternativesNF.Visible = false;
            lblViewAlternativesPF.Visible = false;
            lblSQLFeedback.Visible = false; 
        }

        private void BtnRetrieveData_Click(object sender, EventArgs e)
        {
            groupBoxViewAlternatives.Visible = true; 
            dataGridViewDisplayRetrievedData.DataSource = null;
            ClearAllFeedback();
            numberOfRows.Clear();
            allColumnNames.Clear();
            comboBoxViewAlternatives.Items.Clear();
            comboBoxViewAlternatives.Items.AddRange(new string[]{"Antal rader per tabell",
            "Alla kolumnnamn"});
            comboBoxViewAlternatives.SelectedIndex = 0;
            numberOfRows = Controller_PCTwo.DisplayNumberOfRows();
            allColumnNames = Controller_PCTwo.DisplayAllColumnsName();
            if (numberOfRows.Rows.Count == 0 || allColumnNames.Rows.Count == 0)
            {
                if (numberOfRows.Rows.Count == 0 && allColumnNames.Rows.Count >0)
                {
                    lblRetrieveDataNF.Text = "Finns inga rader i någon av tabellerna i TablesOfInterest";
                    lblRetrieveDataNF.Visible = true; 
                }
                else if(numberOfRows.Rows.Count > 0 && allColumnNames.Rows.Count == 0)
                {
                    lblRetrieveDataNF.Text = "Finns inga kolumnnamn i någon av tabellerna i TablesOfInterest";
                    lblRetrieveDataNF.Visible = true;
                }
                else
                {
                    lblRetrieveDataNF.Text = "Finns inga rader eller kolumnnamn i någon av tabellerna i TablesOfInterest";
                    lblRetrieveDataNF.Visible = true;
                }
            }
            else 
            {
                lblRetrieveDataPF.Text = "Datan har hämtats, välj visningsalternativ nedan";
                lblRetrieveDataPF.Visible = true;
                foreach(DataRow row in numberOfRows.Rows)
                {
                    string temp = "Alla kolumnnamn för " + row["Tabellnamn"].ToString();
                    comboBoxViewAlternatives.Items.Add(temp);
                }
            }
        }

        private void BtnViewAlternatives_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            DataTable table = new DataTable(); 
            if (comboBoxViewAlternatives.Text == "Inga visningsalternativ ännu")
            {
                lblViewAlternativesNF.Text = "Ingen data har ännu hämtats";
                lblViewAlternativesNF.Visible = true; 
            }
            else
            {
                string temp = comboBoxViewAlternatives.SelectedItem.ToString();
                if (temp.Contains("Alla kolumnnamn för "))
                {
                    string tempString = temp.Substring(20, temp.Length - 20);
                    table = Controller_PCTwo.DisplayAllColumsNameForSpecificTable(tempString);
                    if (table.Rows.Count == 0)
                    {
                        lblViewAlternativesNF.Text = "Tabellen innehåller inga kolumnnamn";
                        lblViewAlternativesNF.Visible = true; 
                    }
                    else
                    {
                        dataGridViewDisplayRetrievedData.DataSource = table;
                        lblViewAlternativesPF.Text = $"Tabellen {tempString} kolumnnamn visas";
                        lblViewAlternativesPF.Visible = true; 
                    }
                }
                else if (temp.Contains("Antal rader per tabell"))
                {
                    table = Controller_PCTwo.DisplayNumberOfRows();
                    dataGridViewDisplayRetrievedData.DataSource = table;
                    dataGridViewDisplayRetrievedData.DataSource = table;
                    lblViewAlternativesPF.Text = "Antal rader för respektive tabell i TablesOfInterest visas";
                    lblViewAlternativesPF.Visible = true;
                }
                else if (temp.Contains("Alla kolumnnamn"))
                {
                    table = Controller_PCTwo.DisplayAllColumnsName();
                    dataGridViewDisplayRetrievedData.DataSource = table;
                    lblViewAlternativesPF.Text = "Alla kolumnnamn för respektive tabell i TablesOfInterest visas";
                    lblViewAlternativesPF.Visible = true; 
                }
            }


        }


    }
}
