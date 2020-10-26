using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class frmMain : MetroForm
    {
        YahooInfo YahooData = new YahooInfo();
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (YahooData.DataInTable("SELECT ISNULL(COUNT(ID),0) FROM Companies") != 0)
            {
                btnShow.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnShow.Visible = false;
                btnDelete.Visible = false;
            }
            lblInfo.Visible = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (YahooData.DataInTable($"SELECT ISNULL(COUNT(ID),0) FROM Positions WHERE date='{mCalendar.SelectionRange.Start.Date.ToString("yyyy-MM-dd")}'") != 0)
            {
                DialogResult dialogResult = MessageBox.Show("There are already data with this date", "Information", MessageBoxButtons.OK);
            }
            else
            {
                lblInfo.Visible = true;
                btnShow.Visible = false;
                btnDelete.Visible = false;
                Start_Scraping();
                btnShow.Visible = true;
                lblInfo.Visible = false;
                btnDelete.Visible = true;
            }
        }
        void Start_Scraping()
        {
            YahooData.SaveData(mCalendar.SelectionRange.Start.Date);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            frmResults frm = new frmResults();
            frm.ShowDialog();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all data?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                YahooData.Delete_Data();
                MessageBox.Show("Data si deleted!");
            }           
        }
    }
}
