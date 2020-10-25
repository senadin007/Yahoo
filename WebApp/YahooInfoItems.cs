namespace WebApp
{

    public class AssetProfile
    {
        public string state { get; set; }
        public string city { get; set; }
        public string longBusinessSummary { get; set; }
        public int fullTimeEmployees { get; set; }
        
    }

    public class MarketCap
    {
        public long raw { get; set; }
        public string fmt { get; set; }
        public string longFmt { get; set; }
    }

    public class SummaryDetail
    {
        public MarketCap marketCap { get; set; }
    }

    public class Result
    {
        public AssetProfile assetProfile { get; set; }
        public SummaryDetail summaryDetail { get; set; }
    }
    public class QuoteSummary
    {
        public System.Collections.Generic.IList<Result> result { get; set; }
    }

    public class Example
    {
        public QuoteSummary quoteSummary { get; set; }
    }
}