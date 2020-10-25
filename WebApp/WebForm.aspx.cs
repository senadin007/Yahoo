using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
        }      
        protected void btnStart_Click(object sender, EventArgs e)
        {
            Start_Scraping();
            string sql = "SELECT ISNULL(CompanyName,'') AS Company, ISNULL([Year],0) AS YearFounded, ISNULL(Employees,'') AS NumberOfEmployees, ISNULL(HQCity,'') AS City, ISNULL(HQState,'') AS State, ISNULL(PCP,0) AS PreviousClosePrice, ISNULL(OP,0) AS OpenPrice, ISNULL(MC,0) AS MarketCap   FROM YahooTable ORDER BY Symbol";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(dt);
            dgData.DataSource = dt;
            dgData.DataBind();
        }
        void Start_Scraping()
        {
            YahooInfo YahooData = new YahooInfo();
            YahooData.SaveData(Calendar.SelectedDate);             
        }       
    }
}