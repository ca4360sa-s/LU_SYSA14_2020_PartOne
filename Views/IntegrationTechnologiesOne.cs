using LU_SYSA14_2020_PartOne.ServiceReferenceWSOne;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace LU_SYSA14_2020_PartOne.Views
{
    public partial class IntegrationTechnologiesOne : Form
    {
        public IntegrationTechnologiesOne()
        {
            InitializeComponent();
        }
        AWebServiceToHandleFilesSoapClient client = new AWebServiceToHandleFilesSoapClient();
        Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
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
        //-----------------------------------------------------------------------------------
        private void ClearAllFeedback()
        {
            lblRetrieveAllFilesNF.Visible = false;
            lblRetrieveAllFilesPF.Visible = false;
            lblViewSelectedFileNF.Visible = false;
            lblViewSelectedFilePF.Visible = false; 
        }

        private void btnRetrieveAllFiles_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            dictionary.Clear();
            comboBoxSelectFile.Items.Clear();
            textBoxDisplayFile.Text = ""; 
            groupBoxViewFileAlternatives.Visible = false; 
            if (client.FindAllFileNamesInTheDirectory() == null)
            {
                lblRetrieveAllFilesNF.Text = "Mappen innehåller inga filer";
                lblRetrieveAllFilesNF.Visible = true; 
            }
            else
            {
                foreach (var v in client.FindAllFileNamesInTheDirectory())
                {
                    string temp = Path.GetFileName(v.ToString());
                    dictionary.Add(temp, v.ToString());
                    comboBoxSelectFile.Items.Add(temp);
                }
                lblRetrieveAllFilesPF.Text = "Hämtningen har genomförts";
                lblRetrieveAllFilesPF.Visible = true;
                groupBoxViewFileAlternatives.Visible = true;
                comboBoxSelectFile.SelectedIndex = 0;
            }

        }

        private void btnViewSelectedFile_Click(object sender, EventArgs e)
        {
            ClearAllFeedback();
            string pathForSelectedFile = dictionary[comboBoxSelectFile.SelectedItem.ToString()];
            textBoxDisplayFile.Text = client.DisplayAFile(pathForSelectedFile);
            if (textBoxDisplayFile.Text.Length == 0)
            {
                lblViewSelectedFileNF.Text = "Filen innehåller ingen text";
                lblViewSelectedFileNF.Visible = true; 
            }
            else
            {
                lblViewSelectedFilePF.Text = "Filens innehåll visas";
                lblViewSelectedFilePF.Visible = true;
            }
        }
    }
}
