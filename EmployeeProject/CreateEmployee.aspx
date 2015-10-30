<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="EmployeeProject.CreateEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create new employee</title>
    <style type="text/css">
        .auto-style1 {
            width: 35px;
        }
        .auto-style2 {
            width: 372px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td colspan="2" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblCreateEmployee" runat="server" Text="Create Employee" Font-Size="XX-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" Display="Dynamic" ErrorMessage="Employee Name Cannot be blank">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="txtDepartment" Display="Dynamic" ErrorMessage="Department Cannot be blank">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Label ID="lblSkills" runat="server" Text="Skills"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:CheckBoxList ID="chkSkills" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value=".Net">.Net</asp:ListItem>
                        <asp:ListItem Value="SQL">SQL</asp:ListItem>
                        <asp:ListItem Value="Html">Html</asp:ListItem>
                        <asp:ListItem Value="CSS">CSS</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rbGender" Display="Dynamic" ErrorMessage="Please Select Gender">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Label ID="lblStream" runat="server" Text="Stream"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlStream" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Dev</asp:ListItem>
                        <asp:ListItem>Test</asp:ListItem>
                        <asp:ListItem>DevOps</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStream" runat="server" ControlToValidate="ddlStream" Display="Dynamic" ErrorMessage="Please select Stream" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Status" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="Right" class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="vsCreateEmployee" runat="server" Width="368px" />
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
