namespace LU_SYSA14_2020_PartOne.Views
{
    partial class ProgramConstructionTwo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeadInfo = new System.Windows.Forms.Label();
            this.groupBoxViewAlternatives = new System.Windows.Forms.GroupBox();
            this.lblViewAlternativesPF = new System.Windows.Forms.Label();
            this.lblViewAlternativesNF = new System.Windows.Forms.Label();
            this.dataGridViewDisplayRetrievedData = new System.Windows.Forms.DataGridView();
            this.comboBoxViewAlternatives = new System.Windows.Forms.ComboBox();
            this.btnViewAlternatives = new System.Windows.Forms.Button();
            this.btnRetrieveData = new System.Windows.Forms.Button();
            this.menuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.menyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startmenyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programkonstruktionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programkonstruktionUppgift1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programkonstruktionUppgift2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrationsteknologierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webServiceUppgift1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webServiceUppgift2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eRPintegreringUppgift1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eRPintegreringUppgift2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRetrieveDataNF = new System.Windows.Forms.Label();
            this.lblRetrieveDataPF = new System.Windows.Forms.Label();
            this.lblSQLFeedback = new System.Windows.Forms.Label();
            this.groupBoxViewAlternatives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisplayRetrievedData)).BeginInit();
            this.menuStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeadInfo
            // 
            this.lblHeadInfo.AutoSize = true;
            this.lblHeadInfo.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadInfo.Location = new System.Drawing.Point(297, 80);
            this.lblHeadInfo.Name = "lblHeadInfo";
            this.lblHeadInfo.Size = new System.Drawing.Size(516, 32);
            this.lblHeadInfo.TabIndex = 0;
            this.lblHeadInfo.Text = "Metadata för tabellerna i TablesOfInterest";
            // 
            // groupBoxViewAlternatives
            // 
            this.groupBoxViewAlternatives.Controls.Add(this.lblViewAlternativesPF);
            this.groupBoxViewAlternatives.Controls.Add(this.lblViewAlternativesNF);
            this.groupBoxViewAlternatives.Controls.Add(this.dataGridViewDisplayRetrievedData);
            this.groupBoxViewAlternatives.Controls.Add(this.comboBoxViewAlternatives);
            this.groupBoxViewAlternatives.Controls.Add(this.btnViewAlternatives);
            this.groupBoxViewAlternatives.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxViewAlternatives.Location = new System.Drawing.Point(303, 193);
            this.groupBoxViewAlternatives.Name = "groupBoxViewAlternatives";
            this.groupBoxViewAlternatives.Size = new System.Drawing.Size(510, 452);
            this.groupBoxViewAlternatives.TabIndex = 2;
            this.groupBoxViewAlternatives.TabStop = false;
            this.groupBoxViewAlternatives.Text = "Visningsalternativ";
            // 
            // lblViewAlternativesPF
            // 
            this.lblViewAlternativesPF.AutoSize = true;
            this.lblViewAlternativesPF.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewAlternativesPF.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblViewAlternativesPF.Location = new System.Drawing.Point(30, 47);
            this.lblViewAlternativesPF.Name = "lblViewAlternativesPF";
            this.lblViewAlternativesPF.Size = new System.Drawing.Size(62, 16);
            this.lblViewAlternativesPF.TabIndex = 7;
            this.lblViewAlternativesPF.Text = "Feedback";
            this.lblViewAlternativesPF.Visible = false;
            // 
            // lblViewAlternativesNF
            // 
            this.lblViewAlternativesNF.AutoSize = true;
            this.lblViewAlternativesNF.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewAlternativesNF.ForeColor = System.Drawing.Color.Red;
            this.lblViewAlternativesNF.Location = new System.Drawing.Point(29, 47);
            this.lblViewAlternativesNF.Name = "lblViewAlternativesNF";
            this.lblViewAlternativesNF.Size = new System.Drawing.Size(62, 16);
            this.lblViewAlternativesNF.TabIndex = 6;
            this.lblViewAlternativesNF.Text = "Feedback";
            this.lblViewAlternativesNF.Visible = false;
            // 
            // dataGridViewDisplayRetrievedData
            // 
            this.dataGridViewDisplayRetrievedData.AllowUserToAddRows = false;
            this.dataGridViewDisplayRetrievedData.AllowUserToDeleteRows = false;
            this.dataGridViewDisplayRetrievedData.AllowUserToResizeRows = false;
            this.dataGridViewDisplayRetrievedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDisplayRetrievedData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDisplayRetrievedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisplayRetrievedData.Location = new System.Drawing.Point(33, 125);
            this.dataGridViewDisplayRetrievedData.Name = "dataGridViewDisplayRetrievedData";
            this.dataGridViewDisplayRetrievedData.ReadOnly = true;
            this.dataGridViewDisplayRetrievedData.RowHeadersVisible = false;
            this.dataGridViewDisplayRetrievedData.RowTemplate.Height = 24;
            this.dataGridViewDisplayRetrievedData.Size = new System.Drawing.Size(438, 303);
            this.dataGridViewDisplayRetrievedData.TabIndex = 5;
            // 
            // comboBoxViewAlternatives
            // 
            this.comboBoxViewAlternatives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxViewAlternatives.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxViewAlternatives.FormattingEnabled = true;
            this.comboBoxViewAlternatives.Location = new System.Drawing.Point(33, 69);
            this.comboBoxViewAlternatives.Name = "comboBoxViewAlternatives";
            this.comboBoxViewAlternatives.Size = new System.Drawing.Size(253, 27);
            this.comboBoxViewAlternatives.TabIndex = 4;
            this.comboBoxViewAlternatives.Items.Add("Inga visningsalternativ ännu");
            this.comboBoxViewAlternatives.SelectedIndex = 0;
            // 
            // btnViewAlternatives
            // 
            this.btnViewAlternatives.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAlternatives.Location = new System.Drawing.Point(339, 69);
            this.btnViewAlternatives.Name = "btnViewAlternatives";
            this.btnViewAlternatives.Size = new System.Drawing.Size(132, 35);
            this.btnViewAlternatives.TabIndex = 0;
            this.btnViewAlternatives.Text = "Visa";
            this.btnViewAlternatives.UseVisualStyleBackColor = true;
            this.btnViewAlternatives.Click += new System.EventHandler(this.BtnViewAlternatives_Click);
            // 
            // btnRetrieveData
            // 
            this.btnRetrieveData.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrieveData.Location = new System.Drawing.Point(489, 144);
            this.btnRetrieveData.Name = "btnRetrieveData";
            this.btnRetrieveData.Size = new System.Drawing.Size(132, 35);
            this.btnRetrieveData.TabIndex = 3;
            this.btnRetrieveData.Text = "Hämta data";
            this.btnRetrieveData.UseVisualStyleBackColor = true;
            this.btnRetrieveData.Click += new System.EventHandler(this.BtnRetrieveData_Click);
            // 
            // menuStripMainMenu
            // 
            this.menuStripMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menyToolStripMenuItem});
            this.menuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainMenu.Name = "menuStripMainMenu";
            this.menuStripMainMenu.Size = new System.Drawing.Size(1182, 28);
            this.menuStripMainMenu.TabIndex = 6;
            this.menuStripMainMenu.Text = "menuStrip1";
            // 
            // menyToolStripMenuItem
            // 
            this.menyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startmenyToolStripMenuItem,
            this.programkonstruktionToolStripMenuItem,
            this.integrationsteknologierToolStripMenuItem,
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem});
            this.menyToolStripMenuItem.Name = "menyToolStripMenuItem";
            this.menyToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.menyToolStripMenuItem.Text = "Meny";
            // 
            // startmenyToolStripMenuItem
            // 
            this.startmenyToolStripMenuItem.Name = "startmenyToolStripMenuItem";
            this.startmenyToolStripMenuItem.Size = new System.Drawing.Size(377, 26);
            this.startmenyToolStripMenuItem.Text = "Startmeny";
            this.startmenyToolStripMenuItem.Click += new System.EventHandler(this.StartmenyToolStripMenuItem_Click);
            // 
            // programkonstruktionToolStripMenuItem
            // 
            this.programkonstruktionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programkonstruktionUppgift1ToolStripMenuItem,
            this.programkonstruktionUppgift2ToolStripMenuItem});
            this.programkonstruktionToolStripMenuItem.Name = "programkonstruktionToolStripMenuItem";
            this.programkonstruktionToolStripMenuItem.Size = new System.Drawing.Size(377, 26);
            this.programkonstruktionToolStripMenuItem.Text = "Programkonstruktion";
            // 
            // programkonstruktionUppgift1ToolStripMenuItem
            // 
            this.programkonstruktionUppgift1ToolStripMenuItem.Name = "programkonstruktionUppgift1ToolStripMenuItem";
            this.programkonstruktionUppgift1ToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.programkonstruktionUppgift1ToolStripMenuItem.Text = "Programkonstruktion Uppgift 1";
            this.programkonstruktionUppgift1ToolStripMenuItem.Click += new System.EventHandler(this.ProgramkonstruktionUppgift1ToolStripMenuItem_Click);
            // 
            // programkonstruktionUppgift2ToolStripMenuItem
            // 
            this.programkonstruktionUppgift2ToolStripMenuItem.Name = "programkonstruktionUppgift2ToolStripMenuItem";
            this.programkonstruktionUppgift2ToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.programkonstruktionUppgift2ToolStripMenuItem.Text = "Programkonstruktion Uppgift 2";
            this.programkonstruktionUppgift2ToolStripMenuItem.Click += new System.EventHandler(this.ProgramkonstruktionUppgift2ToolStripMenuItem_Click);
            // 
            // integrationsteknologierToolStripMenuItem
            // 
            this.integrationsteknologierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webServiceUppgift1ToolStripMenuItem,
            this.webServiceUppgift2ToolStripMenuItem});
            this.integrationsteknologierToolStripMenuItem.Name = "integrationsteknologierToolStripMenuItem";
            this.integrationsteknologierToolStripMenuItem.Size = new System.Drawing.Size(377, 26);
            this.integrationsteknologierToolStripMenuItem.Text = "Integrationsteknologier";
            // 
            // webServiceUppgift1ToolStripMenuItem
            // 
            this.webServiceUppgift1ToolStripMenuItem.Name = "webServiceUppgift1ToolStripMenuItem";
            this.webServiceUppgift1ToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.webServiceUppgift1ToolStripMenuItem.Text = "Web Service Uppgift 1";
            this.webServiceUppgift1ToolStripMenuItem.Click += new System.EventHandler(this.WebServiceUppgift1ToolStripMenuItem_Click);
            // 
            // webServiceUppgift2ToolStripMenuItem
            // 
            this.webServiceUppgift2ToolStripMenuItem.Name = "webServiceUppgift2ToolStripMenuItem";
            this.webServiceUppgift2ToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.webServiceUppgift2ToolStripMenuItem.Text = "Web Service Uppgift 2";
            this.webServiceUppgift2ToolStripMenuItem.Click += new System.EventHandler(this.WebServiceUppgift2ToolStripMenuItem_Click);
            // 
            // integrationOchKonfigureringAvERPsystemToolStripMenuItem
            // 
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eRPintegreringUppgift1ToolStripMenuItem,
            this.eRPintegreringUppgift2ToolStripMenuItem});
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem.Name = "integrationOchKonfigureringAvERPsystemToolStripMenuItem";
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem.Size = new System.Drawing.Size(377, 26);
            this.integrationOchKonfigureringAvERPsystemToolStripMenuItem.Text = "Integration och konfigurering av ERP-system";
            // 
            // eRPintegreringUppgift1ToolStripMenuItem
            // 
            this.eRPintegreringUppgift1ToolStripMenuItem.Name = "eRPintegreringUppgift1ToolStripMenuItem";
            this.eRPintegreringUppgift1ToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.eRPintegreringUppgift1ToolStripMenuItem.Text = "ERP-integrering Uppgift 1";
            this.eRPintegreringUppgift1ToolStripMenuItem.Click += new System.EventHandler(this.ERPintegreringUppgift1ToolStripMenuItem_Click);
            // 
            // eRPintegreringUppgift2ToolStripMenuItem
            // 
            this.eRPintegreringUppgift2ToolStripMenuItem.Name = "eRPintegreringUppgift2ToolStripMenuItem";
            this.eRPintegreringUppgift2ToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.eRPintegreringUppgift2ToolStripMenuItem.Text = "ERP-integrering Uppgift 2";
            this.eRPintegreringUppgift2ToolStripMenuItem.Click += new System.EventHandler(this.ERPintegreringUppgift2ToolStripMenuItem_Click);
            // 
            // lblRetrieveDataNF
            // 
            this.lblRetrieveDataNF.AutoSize = true;
            this.lblRetrieveDataNF.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetrieveDataNF.ForeColor = System.Drawing.Color.Red;
            this.lblRetrieveDataNF.Location = new System.Drawing.Point(627, 153);
            this.lblRetrieveDataNF.Name = "lblRetrieveDataNF";
            this.lblRetrieveDataNF.Size = new System.Drawing.Size(62, 16);
            this.lblRetrieveDataNF.TabIndex = 7;
            this.lblRetrieveDataNF.Text = "Feedback";
            this.lblRetrieveDataNF.Visible = false;
            // 
            // lblRetrieveDataPF
            // 
            this.lblRetrieveDataPF.AutoSize = true;
            this.lblRetrieveDataPF.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetrieveDataPF.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblRetrieveDataPF.Location = new System.Drawing.Point(627, 155);
            this.lblRetrieveDataPF.Name = "lblRetrieveDataPF";
            this.lblRetrieveDataPF.Size = new System.Drawing.Size(62, 16);
            this.lblRetrieveDataPF.TabIndex = 8;
            this.lblRetrieveDataPF.Text = "Feedback";
            this.lblRetrieveDataPF.Visible = false;
            // 
            // lblSQLFeedback
            // 
            this.lblSQLFeedback.AutoSize = true;
            this.lblSQLFeedback.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQLFeedback.ForeColor = System.Drawing.Color.Red;
            this.lblSQLFeedback.Location = new System.Drawing.Point(300, 112);
            this.lblSQLFeedback.Name = "lblSQLFeedback";
            this.lblSQLFeedback.Size = new System.Drawing.Size(88, 16);
            this.lblSQLFeedback.TabIndex = 9;
            this.lblSQLFeedback.Text = "SQLFeedback";
            this.lblSQLFeedback.Visible = false;
            // 
            // ProgramConstructionTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.lblSQLFeedback);
            this.Controls.Add(this.lblRetrieveDataPF);
            this.Controls.Add(this.lblRetrieveDataNF);
            this.Controls.Add(this.menuStripMainMenu);
            this.Controls.Add(this.btnRetrieveData);
            this.Controls.Add(this.groupBoxViewAlternatives);
            this.Controls.Add(this.lblHeadInfo);
            this.Name = "ProgramConstructionTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programkonstruktion Uppgift 2";
            this.groupBoxViewAlternatives.ResumeLayout(false);
            this.groupBoxViewAlternatives.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisplayRetrievedData)).EndInit();
            this.menuStripMainMenu.ResumeLayout(false);
            this.menuStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeadInfo;
        private System.Windows.Forms.GroupBox groupBoxViewAlternatives;
        private System.Windows.Forms.DataGridView dataGridViewDisplayRetrievedData;
        private System.Windows.Forms.ComboBox comboBoxViewAlternatives;
        private System.Windows.Forms.Button btnViewAlternatives;
        private System.Windows.Forms.Button btnRetrieveData;
        private System.Windows.Forms.MenuStrip menuStripMainMenu;
        private System.Windows.Forms.ToolStripMenuItem menyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startmenyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programkonstruktionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programkonstruktionUppgift1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programkonstruktionUppgift2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integrationsteknologierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webServiceUppgift1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webServiceUppgift2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integrationOchKonfigureringAvERPsystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eRPintegreringUppgift1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eRPintegreringUppgift2ToolStripMenuItem;
        private System.Windows.Forms.Label lblViewAlternativesNF;
        private System.Windows.Forms.Label lblViewAlternativesPF;
        private System.Windows.Forms.Label lblRetrieveDataNF;
        private System.Windows.Forms.Label lblRetrieveDataPF;
        private System.Windows.Forms.Label lblSQLFeedback;
    }
}