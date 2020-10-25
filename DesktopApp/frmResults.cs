using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class frmResults : MetroForm 
    {
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";

        public frmResults()
        {
            InitializeComponent();
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            string sql = "SELECT ISNULL(CompanyName,'') AS Company, ISNULL([Year],0) AS YearFounded, ISNULL(Employees,'') AS NumberOfEmployees, ISNULL(HQCity,'') AS City, ISNULL(HQState,'') AS State, ISNULL(PCP,0) AS PreviousClosePrice, ISNULL(OP,0) AS OpenPrice, ISNULL(MC,0) AS MarketCap   FROM YahooTable ORDER BY Symbol";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(dt);
            dgResults .DataSource = dt;
        }
    }
}
