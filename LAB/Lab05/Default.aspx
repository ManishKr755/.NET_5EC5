<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="LAB_05.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Calendar</title>
</head>

<body>

<form id="form1" runat="server">

    <h2>Calendar</h2>

    <asp:Calendar
        ID="Calendar1"
        runat="server"
        OnSelectionChanged="Calendar1_SelectionChanged">
    </asp:Calendar>

    <br />

    <asp:Label
        ID="lblSelectedDate"
        runat="server"
        Text="Selected Date:">
    </asp:Label>

    <br /><br />

    <asp:Button
        ID="btnApplyLeave"
        runat="server"
        Text="Apply Leave"
        Enabled="false"
        OnClick="btnApplyLeave_Click" />

</form>

</body>
</html>
