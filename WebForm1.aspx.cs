using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Now;
            lblInfo.Visible = false;
        }      

        protected void Button1_Click(object sender, EventArgs e)
        {
            YahooInfo YahooData = new YahooInfo();
            YahooData.SaveData(Calendar1.SelectedDate);
            dsYahoo ds = new dsYahoo();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM YahooTable", con);
            adap.Fill(ds, "YahooTable");
            GridView1.DataSource = ds.Tables["YahooTable"].DefaultView;
            GridView1.DataBind(); 
            lblInfo.Visible = false;
        }

    }
}