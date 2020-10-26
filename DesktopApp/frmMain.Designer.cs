namespace DesktopApp
{
    partial class frmMain
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
            this.lblDatePicker = new MetroFramework.Controls.MetroLabel();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.btnShow = new MetroFramework.Controls.MetroButton();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblDatePicker
            // 
            this.lblDatePicker.Location = new System.Drawing.Point(29, 80);
            this.lblDatePicker.Name = "lblDatePicker";
            this.lblDatePicker.Size = new System.Drawing.Size(241, 23);
            this.lblDatePicker.TabIndex = 1;
            this.lblDatePicker.Text = "Select a date for open and close price";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(272, 254);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 36);
            this.btnStart.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(374, 296);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(97, 36);
            this.btnShow.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show results";
            this.btnShow.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(272, 80);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 6;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(26, 272);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(240, 18);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Data is downloading. Please wait...";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(374, 254);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 36);
            this.btnExit.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(271, 296);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 36);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete data";
            this.btnDelete.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 346);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.mCalendar);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblDatePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Yahoo! web scraping";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblDatePicker;
        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroButton btnShow;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.Label lblInfo;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroButton btnDelete;
    }
}

