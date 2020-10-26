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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            lblInfo.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            btnShow.Visible = false;
            btnDelete.Visible = false;
            Start_Scraping();
            btnShow.Visible = true;
            lblInfo.Visible = false;
            btnDelete.Visible = true;
        }
        void Start_Scraping()
        {
            YahooInfo YahooData = new YahooInfo();
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
                YahooInfo YahooData = new YahooInfo();
                YahooData.Delete_Data();
                MessageBox.Show("Data si deleted!");
            }           
        }
    }
}
