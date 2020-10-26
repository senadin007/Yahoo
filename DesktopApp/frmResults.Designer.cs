namespace DesktopApp
{
    partial class frmResults
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgResultsC = new System.Windows.Forms.DataGridView();
            this.bsResultsC = new System.Windows.Forms.BindingSource(this.components);
            this.dgResultsP = new System.Windows.Forms.DataGridView();
            this.bsResultsP = new System.Windows.Forms.BindingSource(this.components);
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousClosePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearFounded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfEmployees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultsC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResultsC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultsP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResultsP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgResultsC
            // 
            this.dgResultsC.AllowUserToAddRows = false;
            this.dgResultsC.AllowUserToDeleteRows = false;
            this.dgResultsC.AutoGenerateColumns = false;
            this.dgResultsC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultsC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Company,
            this.YearFounded,
            this.NumberOfEmployees,
            this.City,
            this.State,
            this.MarketCap});
            this.dgResultsC.DataSource = this.bsResultsC;
            this.dgResultsC.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgResultsC.Location = new System.Drawing.Point(27, 74);
            this.dgResultsC.Margin = new System.Windows.Forms.Padding(4);
            this.dgResultsC.MultiSelect = false;
            this.dgResultsC.Name = "dgResultsC";
            this.dgResultsC.ReadOnly = true;
            this.dgResultsC.RowHeadersVisible = false;
            this.dgResultsC.RowHeadersWidth = 51;
            this.dgResultsC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultsC.Size = new System.Drawing.Size(807, 527);
            this.dgResultsC.TabIndex = 0;
            // 
            // dgResultsP
            // 
            this.dgResultsP.AllowUserToAddRows = false;
            this.dgResultsP.AllowUserToDeleteRows = false;
            this.dgResultsP.AutoGenerateColumns = false;
            this.dgResultsP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultsP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Symbol,
            this.PreviousClosePrice,
            this.OpenPrice});
            this.dgResultsP.DataSource = this.bsResultsP;
            this.dgResultsP.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgResultsP.Location = new System.Drawing.Point(842, 74);
            this.dgResultsP.Margin = new System.Windows.Forms.Padding(4);
            this.dgResultsP.MultiSelect = false;
            this.dgResultsP.Name = "dgResultsP";
            this.dgResultsP.ReadOnly = true;
            this.dgResultsP.RowHeadersVisible = false;
            this.dgResultsP.RowHeadersWidth = 51;
            this.dgResultsP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultsP.Size = new System.Drawing.Size(530, 527);
            this.dgResultsP.TabIndex = 1;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 70;
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.MinimumWidth = 6;
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.Width = 60;
            // 
            // PreviousClosePrice
            // 
            this.PreviousClosePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PreviousClosePrice.DataPropertyName = "PreviousClosePrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.PreviousClosePrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.PreviousClosePrice.HeaderText = "Previous close price";
            this.PreviousClosePrice.MinimumWidth = 6;
            this.PreviousClosePrice.Name = "PreviousClosePrice";
            this.PreviousClosePrice.ReadOnly = true;
            // 
            // OpenPrice
            // 
            this.OpenPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OpenPrice.DataPropertyName = "OpenPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.OpenPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.OpenPrice.HeaderText = "Open price";
            this.OpenPrice.MinimumWidth = 6;
            this.OpenPrice.Name = "OpenPrice";
            this.OpenPrice.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "Company name";
            this.Company.MinimumWidth = 6;
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // YearFounded
            // 
            this.YearFounded.DataPropertyName = "YearFounded";
            this.YearFounded.HeaderText = "Year founded";
            this.YearFounded.MinimumWidth = 6;
            this.YearFounded.Name = "YearFounded";
            this.YearFounded.ReadOnly = true;
            this.YearFounded.Width = 62;
            // 
            // NumberOfEmployees
            // 
            this.NumberOfEmployees.DataPropertyName = "NumberOfEmployees";
            this.NumberOfEmployees.HeaderText = "Number of employees";
            this.NumberOfEmployees.MinimumWidth = 6;
            this.NumberOfEmployees.Name = "NumberOfEmployees";
            this.NumberOfEmployees.ReadOnly = true;
            this.NumberOfEmployees.Width = 80;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.MinimumWidth = 6;
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 80;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 45;
            // 
            // MarketCap
            // 
            this.MarketCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MarketCap.DataPropertyName = "MarketCap";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.MarketCap.DefaultCellStyle = dataGridViewCellStyle4;
            this.MarketCap.HeaderText = "Market cap";
            this.MarketCap.MinimumWidth = 6;
            this.MarketCap.Name = "MarketCap";
            this.MarketCap.ReadOnly = true;
            // 
            // frmResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 626);
            this.Controls.Add(this.dgResultsP);
            this.Controls.Add(this.dgResultsC);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmResults";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.frmResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultsC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResultsC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultsP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResultsP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResultsC;
        private System.Windows.Forms.DataGridView dgResultsP;
        private System.Windows.Forms.BindingSource bsResultsC;
        private System.Windows.Forms.BindingSource bsResultsP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearFounded;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousClosePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenPrice;
    }
}