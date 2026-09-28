<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="LeaveApplication.aspx.cs"
    Inherits="LAB_05.LeaveApplication" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Leave Application</title>
</head>

<body>

<form id="form1" runat="server">

    <h2>Leave Application</h2>

    Name:
    <asp:TextBox
        ID="txtName"
        runat="server">
    </asp:TextBox>

    <br /><br />

    Selected Date:
    <asp:Label
        ID="lblSelectedDate"
        runat="server">
    </asp:Label>

    <br /><br />

    Leave Type:

    <asp:DropDownList
        ID="ddlLeaveType"
        runat="server">

        <asp:ListItem Text="-- Select Leave Type --" Value="" />
        <asp:ListItem Text="Sick Leave" Value="Sick Leave" />
        <asp:ListItem Text="Casual Leave" Value="Casual Leave" />
        <asp:ListItem Text="Medical Leave" Value="Medical Leave" />
        <asp:ListItem Text="Emergency Leave" Value="Emergency Leave" />

    </asp:DropDownList>

    <br /><br />

    Reason:

    <br />

    <asp:TextBox
        ID="txtReason"
        runat="server"
        TextMode="MultiLine"
        Rows="4">
    </asp:TextBox>

    <br /><br />

    <asp:CheckBox
        ID="chkRemember"
        runat="server"
        Text="Remember Me" />

    <br /><br />

    <asp:Button
        ID="btnSubmit"
        runat="server"
        Text="Submit"
        OnClick="btnSubmit_Click" />

    <br /><br />

    <asp:Label
        ID="lblMessage"
        runat="server">
    </asp:Label>

</form>

</body>
</html>
