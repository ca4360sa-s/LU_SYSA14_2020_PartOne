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
    }
}
