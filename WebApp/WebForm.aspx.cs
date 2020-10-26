using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        YahooInfo YahooData = new YahooInfo();
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
        }      
        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (YahooData.DataInTable($"SELECT ISNULL(COUNT(ID),0) FROM Positions WHERE date='{Calendar.SelectedDate.ToString("yyyy-MM-dd")}'") != 0)
            {
                DialogResult dialogResult = MessageBox.Show("There are already data with this date", "Information", MessageBoxButtons.OK);
            }
            else
            {
                Start_Scraping();
                FillFirstTable();
                FillSecondTable();
            }
           
        }
        void Start_Scraping()
        {
            YahooData.SaveData(Calendar.SelectedDate);             
        }
        void FillFirstTable()
        {
            string sql = "SELECT ISNULL(CompanyName,'') AS Company, ISNULL([Year],0) AS YearFounded, ISNULL(Employees,'') AS NumberOfEmployees, ISNULL(HQCity,'') AS City, ISNULL(HQState,'') AS State, ISNULL(MC,0) AS MarketCap  FROM Companies ORDER BY Symbol";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(dt);
            dgDataC.DataSource = dt;
            dgDataC.DataBind();
        }
        void FillSecondTable()
        {
            string sql = "SELECT FORMAT([Date],'dd-MM-yyyy') as Date, Symbol, ISNULL(PCP,0) AS PreviousClosePrice, ISNULL(OP,0) AS OpenPrice   FROM Positions ORDER BY Date,Symbol";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(dt);
            dgDataP.DataSource = dt;
            dgDataP.DataBind();
        }
    }
}