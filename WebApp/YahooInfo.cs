using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Web.Script.Serialization;

namespace WebApp
{
    public class YahooInfo

    {
        public string Symbol, CompanyName, HQCity, HQState = "";
        public int YearFounded = 0;
        public double Employees, previousClose, open, marketCap = 0;

        SqlConnection cnn;
        SqlCommand cmd;
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";

        WebClient webConnector;
              
        public void SaveData(DateTime Period)
        {
            Delete_Data();
            GetDataFromCSV(Period);
        }
              
        //For each symbol in tickers.csv find information and stores them in database
        public void GetDataFromCSV(DateTime Period)
        {
            using (TextFieldParser csvReader = new TextFieldParser(AppDomain.CurrentDomain.BaseDirectory + @"App_Data\tickers.csv"))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] Fields = csvReader.ReadFields();

                long unixTime1 = ((DateTimeOffset)Period.Date.AddHours(12)).ToUnixTimeSeconds();
                long unixTime2 = ((DateTimeOffset)Period.Date.AddHours(36)).ToUnixTimeSeconds();

                foreach (string ticker in Fields)
                {
                    HQCity = ""; HQState = ""; YearFounded = 0; Employees = 0; previousClose = 0; open = 0; marketCap = 0;
                    string yahooAddress = $"https://query1.finance.yahoo.com/v10/finance/quoteSummary/{ticker}?modules=assetProfile%2CsummaryDetail";
                    string historyAddress = $"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1={unixTime1}&period2={unixTime2}&interval=1d";

                    Symbol = ticker;
                    FillData(GetData(yahooAddress, 0), GetData(historyAddress, 1));
                    GetFullName(Symbol);
                    Insert_Data(Symbol, CompanyName, YearFounded, Employees, HQCity, HQState , Period, previousClose, open, marketCap);
                }
            }
        }
        //Geting stream from URI
        string GetData(string webpageUriString, int type)
        {
            string tempStorageString = "";
            try
            {
                if (webpageUriString != "")
                {
                    using (webConnector = new WebClient())
                    {
                        using (Stream responseStream = webConnector.OpenRead(webpageUriString))
                        {
                            using (StreamReader responseStreamReader = new StreamReader(responseStream))
                            {
                                tempStorageString = responseStreamReader.ReadToEnd();

                                if (type == 1)
                                {
                                    tempStorageString = tempStorageString.Replace("\n", ",");
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException)
            {
                return "";
            }
            return tempStorageString;
        }
        //csvData contains profile and summary information. csvHistory contains information about open and close price on date
        void FillData(string csvData, string csvDataHistory)
        {
            string csvLine;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Items = jss.Deserialize<Example>(csvData);
                  
            HQCity = Items.quoteSummary.result[0].assetProfile.city ?? "";
            HQState = Items.quoteSummary.result[0].assetProfile.state ?? "";
            Employees = Items.quoteSummary.result[0].assetProfile.fullTimeEmployees;

            int tempYear = 0;
            if (Items.quoteSummary.result[0].assetProfile.longBusinessSummary != null)
            {
                string info = Items.quoteSummary.result[0].assetProfile.longBusinessSummary;
                int lstindex = info.LastIndexOf("founded in ");
                if (int.TryParse((info.Substring(lstindex + 11, 4)), out tempYear))
                {
                    YearFounded = tempYear;
                }
                else
                {
                    YearFounded = 0;
                }

                if (YearFounded == 0)
                {
                    if (int.TryParse(getNumber(getBetween("founded", info)), out tempYear))
                    {
                        YearFounded = tempYear;
                    }
                    else
                    {
                        YearFounded = 0;
                    }
                }

            }

            marketCap = Items.quoteSummary.result[0].summaryDetail.marketCap.raw ;
            
            using (StringReader reader = new StringReader(csvDataHistory))
            {
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] splitLine = csvLine.Split(',');
                    double tempOpen;
                    if (Double.TryParse(splitLine[8].Replace(".", ","), out tempOpen))
                    {
                        open = tempOpen;
                    }
                    double tempPreviousClose;
                    if (Double.TryParse(splitLine[11].Replace(".", ","), out tempPreviousClose))
                    {
                        previousClose = tempPreviousClose;
                    }
                }
            }
        }

        /*Returning string from inital defined word to the last word in text.
         It is used to get year founded in description.
        */
        public string getBetween(string strStart,string strSource)
        {
            string strEnd = strSource.Last().ToString();
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
        //Finding year in string
        string getNumber(string a)
        {
            string b = string.Empty;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                {
                    b += a[i];
                    if (b.Length == 4)
                    {
                        break;
                    }
                }
            }
            return b;
        }
        //Inserting data in dbYahoo
        public void Insert_Data(string _Symbol, string _Company, int _Year, Double _Employees, string _City, string _State, DateTime _Period, Double _PCP, Double _OP, Double _MC)
        {

            String query = "INSERT INTO [dbo].[YahooTable] ([Symbol], [CompanyName], [Year], [Employees], [HqCity], [HqState], [Date], [PCP], [OP], [MC]) VALUES (@Symbol, @CompanyName, @Year, @Employees, @HqCity, @HqState, @Date, @PCP, @OP, @MC)";

            cnn = new SqlConnection(con);
            cnn.Open();
            cmd = new SqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@Symbol", _Symbol);
            cmd.Parameters.AddWithValue("@CompanyName", _Company);
            cmd.Parameters.AddWithValue("@Year", _Year);
            cmd.Parameters.AddWithValue("@Employees", _Employees);
            cmd.Parameters.AddWithValue("@HqCity", _City);
            cmd.Parameters.AddWithValue("@HqState", _State);
            cmd.Parameters.AddWithValue("@Date", _Period);
            cmd.Parameters.AddWithValue("@PCP", _PCP);
            cmd.Parameters.AddWithValue("@OP", _OP);
            cmd.Parameters.AddWithValue("@MC", _MC);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        // Deleting all data from table dbYahoo before inserting new data
        public void Delete_Data()
        {
            cnn = new SqlConnection(con);
            cnn.Open();
            cmd = new SqlCommand("Truncate table YahooTable", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Metod for scraping FullCompanyName because the same is missing from profile information.
        void GetFullName(string symbol)
        {
            string htmlLink = string.Format("https://finance.yahoo.com/quote/{0}/profile?p={0}", symbol);
            var getHtmlWeb = new HtmlAgilityPack.HtmlWeb();
            var document = getHtmlWeb.Load(htmlLink);
            var aTags = document.DocumentNode.SelectNodes("//h1[contains(@class, 'D(ib) Fz(18px)')]");
            if (aTags != null)
            {
                foreach (var aTag in aTags)
                {
                    string d = aTag.InnerHtml;
                    CompanyName = HttpUtility.HtmlDecode(d.ToString());
                }
            }
            else
            {
                CompanyName = "";
            }

        }
    }
}