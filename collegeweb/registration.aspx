<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 280px">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font size="28">Registration form</font>
        <br />
        <br />
        <br />
        <br />
        Student name:<asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Name is required" Font-Bold="True" Font-Italic="True" Font-Size="Small" Font-Underline="True" ForeColor="Blue"></asp:RequiredFieldValidator>
        <br />
        <br />
        email-id:<asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" ErrorMessage="email is required" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="Blue"></asp:RequiredFieldValidator>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="not valid" ValidationExpression="@gmail.com" ForeColor="#0099FF"></asp:RegularExpressionValidator>
        <br />
        <br />
        mobno:<asp:TextBox ID="txtmob" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmob" ErrorMessage="mobile no. is required" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="#3333FF"></asp:RequiredFieldValidator>
        <br />
        <br />
        course:<asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged">
            <asp:ListItem Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        class:<asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
            <asp:ListItem Selected="True"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <br />
        <br />
        Gender:<asp:RadioButton ID="rbtnmale" runat="server" Text="Male" />
&nbsp;&nbsp;
        <asp:RadioButton ID="rbtnfemale" runat="server" Text="female" />
        <br />
        <br />
        password:<asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpass" ErrorMessage="password is required" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="#0000CC"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        confirm password:<asp:TextBox ID="txtcpass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcpass" ErrorMessage="confirm password is required" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="#0000CC"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass" ControlToValidate="txtcpass" Display="Dynamic" ErrorMessage="password is not match" Font-Bold="True" Font-Italic="True" Font-Underline="True" ForeColor="Blue"></asp:CompareValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnsub" runat="server" OnClick="btnsub_Click" Text="submit" Font-Bold="True" Font-Italic="True" Font-Size="Large" ForeColor="Blue" />
        &nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
