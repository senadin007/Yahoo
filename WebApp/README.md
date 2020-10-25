--------------
Yahoo scraping
--------------

Yahoo Finance changed their API for downloading historic data, breaking a lot of existing scripts and modules.
The application saves data from yahoo website to the database.

Its web aplication and desktop aplication. Both versions contain a local database in which data is stored.

Basic information that is stored in database: full company name, year founded, number of employees, headquarters city and state, market cap. 
Previous close price and open price depends on users date entry.

Inside project folder there is a ticker.csv file with symbols of companies (AAPL - Apple inc, ALV - Autoliv inc, ...).

For each ticker in file application collect information about company with assetProfile and summaryDetail.
https://query1.finance.yahoo.com/v10/finance/quoteSummary/[-|ticker|-]?modules=assetProfile%2CsummaryDetail

Previous close price and open price from history.
https://query1.finance.yahoo.com/v7/finance/download/[-|ticker|-]?period1=[-|period1|-]&period2=[-|period2|-]&interval=1d
