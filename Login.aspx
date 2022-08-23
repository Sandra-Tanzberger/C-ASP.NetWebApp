<%@ Page Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="Public.Login" %>

<asp:Content ID="LeftPane" ContentPlaceHolderID="Left_Menu_Content" Runat="Server" />
<asp:Content ID="Login" ContentPlaceHolderID="Right_Content" Runat="server">
    <div class="LoginDiv" >
            <table class="UserLogin" border="0">
                <tr>
                    <th colspan="2"><asp:Literal ID="LoginHeaderText" runat="server" Text="Provider Authentication" /></th>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">Login ID:</td>
                    <td align="left">                
                        <telerik:RadTextBox runat="server" ID="LoginID" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="left">        
                        <asp:RequiredFieldValidator runat="server" ID="ReqFldValidatorLoginID" ControlToValidate="LoginID" 
                            ErrorMessage="* Login ID required" ValidationGroup="LoginValidationGroup" />
                    </td>
                </tr>
                <tr>
                    <td align="right">Password:</td>
                    <td align="left">                
                        <telerik:RadTextBox runat="server" ID="UserPass" TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="left">
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="UserPass"
                            ErrorMessage="* Password required" ValidationGroup="LoginValidationGroup" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button Width="100px" runat="server" ID="LoginBtn" Text="Login" OnCommand="AuthenticateUser" UseSubmitBehavior="true" ValidationGroup="LoginValidationGroup" />
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>

