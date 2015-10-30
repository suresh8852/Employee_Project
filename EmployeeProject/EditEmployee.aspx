<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="EmployeeProject.EditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td colspan="3" align ="center">
                    <asp:Label ID="lblEditEmployee" runat="server" Font-Size="XX-Large" Text="Edit Employee"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblEmployeeID" runat="server" Text="EmployeeID"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblEmpID" runat="server" Text="EmpID" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Display="Dynamic" ErrorMessage="Employee Name cannot be blank">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="txtDepartment" Display="Dynamic" ErrorMessage="Department cannot be blank">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblSkills" runat="server" Text="Skills"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:CheckBoxList ID="cblSkills" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>.Net</asp:ListItem>
                        <asp:ListItem>SQL</asp:ListItem>
                        <asp:ListItem>Html</asp:ListItem>
                        <asp:ListItem>CSS</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rbGender" Display="Dynamic" ErrorMessage="Please Select Gender">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Label ID="lblStream" runat="server" Text="Stream"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlStream" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Dev</asp:ListItem>
                        <asp:ListItem>Test</asp:ListItem>
                        <asp:ListItem>DevOps</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStream" runat="server" ControlToValidate="ddlStream" Display="Dynamic" ErrorMessage="Please Select Stream" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align ="Right">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr align ="center">
                <td colspan="3">
                    <asp:Label ID="lblStatus" runat="server" Text="Status" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="vsEditEmployee" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
