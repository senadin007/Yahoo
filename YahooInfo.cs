using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.ModelBinding;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.Web.UI;

namespace WebApp
{
    public class YahooInfo
               
    {
        public string Symbol = "";
        public string CompanyName = "";
        public int YearFounded = 0;
        public double Employees = 0;
        public string HQCity = "";
        public string HQStreet = "";
        public double previousClose = 0;
        public double open = 0;
        public double marketCap = 0;

        SqlConnection cnn;
        SqlCommand cmd;
        string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"App_Data\dbYahoo.mdf;Integrated Security=True";

        WebClient webConnector;

        const string yahooAddressP = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/[-|ticker|-]?modules=assetProfile";
        const string yahooAddressS = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/[-|ticker|-]?modules=summaryDetail";
        const string historyAddress = "https://query1.finance.yahoo.com/v7/finance/download/[-|ticker|-]?period1=[-|period1|-]&period2=[-|period2|-]&interval=1d";

        public void SaveData(DateTime Period)
        {
            Delete_Data();
            GetDataFromCSV(Period);
        }
             
                        
        string ConstructYahooLink(string ticker,string yahooAddress)
        {
            string constructedUri = yahooAddress;

            constructedUri = constructedUri.Replace("[-|ticker|-]", ticker);         

            return constructedUri;
        }

        string ConstructYahooHistoryLink(DateTime period1, DateTime period2, string ticker, string yahooAddress)
        {
            string constructedUri = yahooAddress;
            long unixTime1 = ((DateTimeOffset)period1).ToUnixTimeSeconds();
            long unixTime2 = ((DateTimeOffset)period2).ToUnixTimeSeconds();

            constructedUri = constructedUri.Replace("[-|ticker|-]", ticker);
            constructedUri = constructedUri.Replace("[-|period1|-]", unixTime1.ToString());
            constructedUri = constructedUri.Replace("[-|period2|-]", unixTime2.ToString());

            return constructedUri;
        }

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
                                    tempStorageString = tempStorageString.Replace("\n", Environment.NewLine);
                                }
                                else if (type == 2)
                                {
                                    tempStorageString = tempStorageString.Replace("\n", ",");
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return "";
            }
            return tempStorageString;
            }

        public void GetDataFromCSV(DateTime Period)
        {
            using (TextFieldParser csvReader = new TextFieldParser(AppDomain.CurrentDomain.BaseDirectory + @"App_Data\tickers1.csv"))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] Fields = csvReader.ReadFields();
               
                foreach (string ticker in Fields)
                {
                    Symbol = ticker;
                    FillData(GetData(ConstructYahooLink(ticker, yahooAddressP), 0), GetData(ConstructYahooLink(ticker, yahooAddressS), 1), GetData(ConstructYahooHistoryLink(Period, Period.AddDays(1), ticker, historyAddress), 2));
                    GetFullName(Symbol);
                    Insert_Data(Symbol, CompanyName, YearFounded, Employees, HQCity, HQStreet, Period, previousClose, open, marketCap);
                }
            }
        }

        void FillData(string csvDataP, string csvDataS, string csvDataHistory)
        {
                                   
            string csvLine;
            int index;
            using (StringReader reader = new StringReader(csvDataP))
            {


                while ((csvLine = reader.ReadLine()) != null)
                {

                    int tempYear;
                    if (int.TryParse(getNumber(getBetween(csvLine, "founded", ",\"fullTimeEmployees")), out tempYear))
                    {
                        YearFounded = tempYear;
                    }

                    double tempEmpoyees;
                    if (Double.TryParse(getBetween(csvLine, "\"fullTimeEmployees\":", ",\"companyOfficers"), out tempEmpoyees))
                    {
                        Employees = tempEmpoyees;
                    }

                    HQCity = getBetween(csvLine, "\"city\":", ",\"state").Replace("\"", "");

                    if (csvLine.Contains("address2"))
                    {
                        HQStreet = getBetween(csvLine, "\"address1\":", ",\"address2").Replace("\"", "");
                    }
                    else
                    {
                        HQStreet = getBetween(csvLine, "\"address1\":", ",\"city").Replace("\"", "");
                    }     
                }
            }

            using (StringReader reader = new StringReader(csvDataS))
            {
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] splitLine = csvLine.Split(',');
                                        
                    index = Array.FindIndex(splitLine, row => row.Contains("marketCap"));
              
                    double tempmarketCap;
                    if (index >=0 && splitLine[index].Length > 23)
                    {
                        if (Double.TryParse(splitLine[index].Substring(23).Replace(".", ","), out tempmarketCap))
                        {
                            marketCap = tempmarketCap;
                        }
                    }                 
                }
            }

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

        string getNumber(string a)
        {
            string b = string.Empty;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            return b;
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        public void Insert_Data(string _Symbol, string _Company, int _Year, Double _Employees, string _City, string _Street, DateTime _Period, Double _PCP, Double _OP, Double _MC)
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