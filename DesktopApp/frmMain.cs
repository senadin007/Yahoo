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
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            Thread.Sleep(1000);
            Start_Scraping();
            btnShow.Visible = true;
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
    }
}
