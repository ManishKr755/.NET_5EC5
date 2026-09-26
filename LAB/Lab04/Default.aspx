<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="LAB_04.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Online Event Registration</title>
</head>

<body>

<form id="form1" runat="server">

    <!-- Main heading of the registration form -->
    <h2>Online Event Registration</h2>

    <!-- Name field -->
    Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

    <!-- Checks that the name field is not empty -->
    <asp:RequiredFieldValidator
        ID="rfvName"
        runat="server"
        ControlToValidate="txtName"
        ErrorMessage="* Name is required"
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <br /><br />

    <!-- Email field -->
    Email:
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

    <!-- Checks that the email field is not empty -->
    <asp:RequiredFieldValidator
        ID="rfvEmail"
        runat="server"
        ControlToValidate="txtEmail"
        ErrorMessage="* Email is required"
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <!-- Checks whether the email has a valid format -->
    <asp:RegularExpressionValidator
        ID="revEmail"
        runat="server"
        ControlToValidate="txtEmail"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        ErrorMessage="* Enter a valid email"
        ForeColor="Red">
    </asp:RegularExpressionValidator>

    <br /><br />

    <!-- Gender selection -->
    Gender:

    <asp:RadioButton
        ID="rbMale"
        runat="server"
        Text="Male"
        GroupName="Gender" />

    <asp:RadioButton
        ID="rbFemale"
        runat="server"
        Text="Female"
        GroupName="Gender" />

    <br /><br />

    <!-- Event selection -->
    Event:

    <asp:DropDownList
        ID="ddlEvent"
        runat="server">

        <%-- Empty value allows the validator to detect that no event was selected --%>
        <asp:ListItem Text="-- Select Event --" Value=""></asp:ListItem>

        <asp:ListItem Text="Tech Seminar" Value="Tech Seminar"></asp:ListItem>
        <asp:ListItem Text="Workshop" Value="Workshop"></asp:ListItem>
        <asp:ListItem Text="Web Development" Value="Web Development"></asp:ListItem>

    </asp:DropDownList>

    <!-- Ensures that an event is selected -->
    <asp:RequiredFieldValidator
        ID="rfvEvent"
        runat="server"
        ControlToValidate="ddlEvent"
        InitialValue=""
        ErrorMessage="* Please select an event"
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <br /><br />

    <!-- Phone number field -->
    Phone:

    <asp:TextBox
        ID="txtPhone"
        runat="server">
    </asp:TextBox>

    <!-- Checks that the phone number is not empty -->
    <asp:RequiredFieldValidator
        ID="rfvPhone"
        runat="server"
        ControlToValidate="txtPhone"
        ErrorMessage="* Phone is required"
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <!-- Checks that the phone number contains exactly 10 digits -->
    <asp:RegularExpressionValidator
        ID="revPhone"
        runat="server"
        ControlToValidate="txtPhone"
        ValidationExpression="^[0-9]{10}$"
        ErrorMessage="* Enter 10 digit phone number"
        ForeColor="Red">
    </asp:RegularExpressionValidator>

    <br /><br />

    <!-- Register button -->
    <asp:Button
        ID="btnRegister"
        runat="server"
        Text="Register"
        OnClick="btnRegister_Click" />

    <br /><br />

    <!-- Displays registration details after successful submission -->
    <asp:Label
        ID="lblDetails"
        runat="server">
    </asp:Label>

</form>

</body>
</html>
