<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<!DOCTYPE html>


<script>
    function postValueToMain(strDate) {
        window.opener.document.getElementById('txtDate').value = strDate;
        window.close();
    }

</script>





<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body><body bgcolor="#353535">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <p style="width: 359px">
&nbsp;&nbsp;</p>
        <p style="width: 359px">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" BackColor="#FE5852" ForeColor="White">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FE5852" ForeColor="White">
            </asp:DropDownList>
&nbsp;<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"  BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" ShowTitle="False" Width="220px" >
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <asp:Literal id="Literal1" runat="server"></asp:Literal>

        </p>
        <p>
            <asp:Button ID="btnToday" runat="server" Text="今天" Width="107px" OnClick="btnToday_Click" BackColor="#FE5852" ForeColor="White" />
&nbsp;&nbsp;
            <asp:Button ID="btnQuit" runat="server" Text="取消" Width="107px" OnClick="btnQuit_Click" BackColor="#FE5852" ForeColor="White" />
        </p>
    <div>
    
    </div>
    </form>
</body>
</html>
