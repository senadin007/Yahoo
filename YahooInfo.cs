using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.ModelBinding;

namespace WebApp
{
    public class YahooInfo
               
    {
        WebClient webConnector;

        const string yahooAddressP = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/[-|ticker|-]?modules=assetProfile";
        const string yahooAddressS = "https://query1.finance.yahoo.com/v10/finance/quoteSummary/[-|ticker|-]?modules=summaryDetail";

      
        public Dictionary<DateTime, YahooInfoItems> getDataFromYahoo(string ticker)
        {
          return  fillDataDictionary(getData(constructYahooLink(ticker, yahooAddressP),true), getData(constructYahooLink(ticker, yahooAddressS), false));
         }
                        
        string constructYahooLink(string ticker,string yahooAddress)
        {
            string constructedUri = yahooAddress;

            constructedUri = constructedUri.Replace("[-|ticker|-]", ticker);         

            return constructedUri;
        }
               
        string getData(string webpageUriString, Boolean profile)
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
                                //extract the response we got from the internet server
                                tempStorageString = responseStreamReader.ReadToEnd();

                                //change the unix style line endings so they work here
                                if (profile == false)
                                {
                                    tempStorageString = tempStorageString.Replace("\n", Environment.NewLine);
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
             
        Dictionary<DateTime, YahooInfoItems > fillDataDictionary(string csvDataP, string csvDataS)
        {
            Dictionary<DateTime, YahooInfoItems> parsedStockData = new Dictionary<DateTime, YahooInfoItems>();

            YahooInfoItems newItem = new YahooInfoItems();
            string csvLine;
            int index;
            using (StringReader reader = new StringReader(csvDataP))
            {


                while ((csvLine = reader.ReadLine()) != null)
                {

                    int tempYear;
                    if (int.TryParse(getNumber(getBetween(csvLine, "founded", ",\"fullTimeEmployees")), out tempYear))
                    {
                        newItem.YearFounded = tempYear;
                    }

                    double tempEmpoyees;
                    if (Double.TryParse(getBetween(csvLine, "\"fullTimeEmployees\":", ",\"companyOfficers"), out tempEmpoyees))
                    {
                        newItem.Employees = tempEmpoyees;
                    }


                    newItem.HQCity = getBetween(csvLine, "\"city\":", ",\"state").Replace("\"", "");

                    if (csvLine.Contains("address2"))
                    {
                        newItem.HQStreet = getBetween(csvLine, "\"address1\":", ",\"address2").Replace("\"", "");
                    }
                    else
                    {
                        newItem.HQStreet = getBetween(csvLine, "\"address1\":", ",\"city").Replace("\"", "");
                    }
                                 
                }

            }

            using (StringReader reader = new StringReader(csvDataS))
            {
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] splitLine = csvLine.Split(',');

                    index = Array.FindIndex(splitLine, row => row.Contains("previousClose"));
                                       
                    double tempPreviousClose;
                    if (Double.TryParse(string.Format(splitLine[index].Substring(23).Replace(".", ","), "{0:#,##0.##}"), out tempPreviousClose))
                    {
                        newItem.previousClose = tempPreviousClose;
                    }

                    index = Array.FindIndex(splitLine, row => row.Contains("open"));
                
                    double tempOpen;
                    if (Double.TryParse(string.Format(splitLine[index].Substring(14).Replace(".", ","), "{0:#,##0.##}"), out tempOpen))
                    {
                        newItem.open = tempOpen;
                    }
                    index = Array.FindIndex(splitLine, row => row.Contains("marketCap"));
              
                    double tempmarketCap;
                    if (splitLine[index].Length > 23)
                    {
                        if (Double.TryParse(string.Format(splitLine[index].Substring(23).Replace(".", ","), "{0:#,##0.##}"), out tempmarketCap))
                        {
                            newItem.marketCap = tempmarketCap;
                        }
                    }
                   
                    parsedStockData.Add(DateTime.Now, newItem);
                }
                    
            }

            return parsedStockData;
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
    }
}