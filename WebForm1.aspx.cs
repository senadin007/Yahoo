using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<string> Tickers = new List<string>();
        string Company;
        SqlConnection cnn;
        SqlCommand cmd;
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User01\Desktop\Zadatak1\WebApp\App_Data\dbYahoo.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Now;
            lblInfo.Visible = false;
        }

        void getData(DateTime date)
        {
            lblInfo.Visible = true;
            lblInfo.Text = "Data is saving. Please wait...";
            string period1 = date.AddDays(-3).ToString("yyyy-MM-dd");
            string period2 = date.AddDays(+3).ToString("yyyy-MM-dd");
            string period = date.ToString("yyyy-MM-dd");

            string htmlLink = string.Format("https://finance.yahoo.com/calendar/earnings?from={0}&to={1}&day={2}", period1, period2, period);
            var getHtmlWeb = new HtmlWeb();
            var document = getHtmlWeb.Load(htmlLink);
            var aTags = document.DocumentNode.SelectNodes("//td//a[contains(@class, 'Fw(600) C($linkColor)')]");
            int counter = 1;
            if (aTags != null)
            {
                foreach (var aTag in aTags)
                {
                    string d = aTag.InnerHtml;

                    string textOnly = HttpUtility.HtmlDecode(d.ToString());

                    Tickers.Add(getYahooInfo(period,textOnly));                                     
                                     
                    counter++;
                }
            }
            dsYahoo ds = new dsYahoo();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM YahooTable", con);
            adap.Fill(ds, "YahooTable");

            GridView1.DataSource = ds.Tables["YahooTable"].DefaultView; 
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Delete_Data();
            getData(Calendar1.SelectedDate);
            lblInfo.Visible = false;
         
        }

        string getYahooInfo(string period,string symbol)
        {
            StringBuilder textString = new StringBuilder();
            YahooInfo  wc1 = new YahooInfo();
            Dictionary<DateTime, YahooInfoItems > downloadedStockData;

            //request data from Yahoo for the past 10 days
            downloadedStockData = wc1.getDataFromYahoo(symbol);
            GetFullName(symbol);

            foreach (KeyValuePair<DateTime, YahooInfoItems> singleItem in downloadedStockData)
            {
                Insert_Data(symbol, Company, singleItem.Value.YearFounded, singleItem.Value.Employees, singleItem.Value.HQCity, singleItem.Value.HQStreet, Calendar1.SelectedDate, singleItem.Value.previousClose, singleItem.Value.open, singleItem.Value.marketCap);
              
            }
           
            return  textString.ToString();
        }
        public void Insert_Data(string _Symbol,string _Company, int _Year, Double _Employees, string _City, string _Street, DateTime _Period, Double _PCP, Double _OP, Double _MC)
        {
            
            String query = "INSERT INTO [dbo].[YahooTable] ([Symbol], [CompanyName], [Year], [Employees], [HqCity], [HqStreet], [Date], [PCP], [OP], [MC]) VALUES (@Symbol, @CompanyName, @Year, @Employees, @HqCity, @HqStreet, @Date, @PCP, @OP, @MC)";

            cnn = new SqlConnection(con);
            cnn.Open();
            cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@Symbol", _Symbol);
            cmd.Parameters.AddWithValue("@CompanyName", _Company);
            cmd.Parameters.AddWithValue("@Year", _Year);
            cmd.Parameters.AddWithValue("@Employees", _Employees);
            cmd.Parameters.AddWithValue("@HqCity", _City);
            cmd.Parameters.AddWithValue("@HqStreet", _Street);
            cmd.Parameters.AddWithValue("@Date", _Period);
            cmd.Parameters.AddWithValue("@PCP", _PCP);
            cmd.Parameters.AddWithValue("@OP", _OP);
            cmd.Parameters.AddWithValue("@MC", _MC);
            cmd.ExecuteNonQuery();
            cnn.Close();
                       
        }

        public void Delete_Data()
        {
                        
            cnn = new SqlConnection(con);
            cnn.Open();
            cmd = new SqlCommand("Truncate table YahooTable", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
                     
         }

        private void GetFullName(string symbol)
        {
            
            string htmlLink = string.Format("https://finance.yahoo.com/quote/{0}/profile?p={0}", symbol);
            var getHtmlWeb = new HtmlWeb();
            var document = getHtmlWeb.Load(htmlLink);
            var aTags = document.DocumentNode.SelectNodes("//h1[contains(@class, 'D(ib) Fz(18px)')]");
            int counter = 1;
            if (aTags != null)
            {
                foreach (var aTag in aTags)
                {
                    string d = aTag.InnerHtml;
                    Company  = HttpUtility.HtmlDecode(d.ToString());
                    counter++;
                }
            }

        }

    }
}