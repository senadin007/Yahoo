<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yahoo finance</title>
    <style>
         .secDIV {
            margin:auto;
            width: 57%;
            display: flex;
            justify-content: center;
            padding:10px;
            padding-top:30px;
            background-color:white;
            box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
            height: 330px;
        }
        .sec1 {
            margin:0px;
            float: left;
            display: inline-block;
        }
         .sec2 {
            margin:0px;
            padding-left:20px;
            display: inline-block;
            float: left;
            width: 323px;
            height: 208px;
        }
         .sec3 {
            margin:auto;
            display: flex;
            padding:10px;
            border:none;
            width: 80%;
        }
         .label {
            font-size:20px;
            font-family:Arial;
            float:right;
            Color: #CC3300;
         }

          body {
            background-color: #e6e8e6;
           }

         h2 {
            font-family:Arial;
            text-align:center;
         }
               
         .button {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 10px 26px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            transition-duration: 0.4s;
            float:right;
            outline:none;
         }

        .button2:hover {
            box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Yahoo! finance</h2>
            <div class="secDIV">
                <span class="sec1">
                    <asp:Calendar ID="Calendar" runat="server" Width="291px" BackColor="white" DayNameFormat="Shortest" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="black" Height="200px" ShowGridLines="false">
                        <DayHeaderStyle BackColor="#4CAF50" Font-Bold="True" Height="1px" ForeColor="White"  />
                        <NextPrevStyle Font-Size="9pt" ForeColor="white" />
                        <OtherMonthDayStyle ForeColor="#b3b1af" />
                        <SelectedDayStyle BackColor="#70e675" Font-Bold="True" />
                        <SelectorStyle BackColor="#4CAF50" />
                        <TitleStyle BackColor="#4CAF50" Font-Bold="True" Font-Size="9pt" ForeColor="white" />
                        <TodayDayStyle BackColor="#4CAF50" ForeColor="White" />
                </asp:Calendar>
                
                </span>
                <span class="sec2">
                    <asp:Label ID="lblHead" runat="server" CssClass="label" Text="Scrap information from Yahoo!" ForeColor="Green"></asp:Label> 
                    <br />
                    <br />
                    <asp:Button ID="btnStart" runat="server" OnClick="btnStart_Click" Text="Start" Width="117px" class="button button2" Height="40px"/>
                    <br />
                    <br />
                    <br />
                    <br />
                </span>               
               </div>
            <br />       
            <br />
             <asp:GridView ID="dgDataC" runat="server" class="sec3">
                </asp:GridView>
            <br />
            <asp:GridView ID="dgDataP" runat="server" class="sec3">
                </asp:GridView>
          </div>
    </form>
</body>
</html>
