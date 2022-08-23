<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentAuthorization.ascx.cs" Inherits="AppControl.PaymentAuthorization" %>

<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<telerik:RadAjaxPanel ID="PayAuthRadPanel" runat="server">
    <table class="formTable" border="0" width="100%">
        <tr>
            <td style="padding-left:10px;width:170px;">
                <asp:Label ID="lblAuthPassword" runat="server">Authorization Password</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAuthPassword" runat="server" Text="" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left:10px;width:170px;">
                <p>I certify that the information provided is true, correct, and supportable by documentation 
                to the best of my knowledge. Documentation of the information provided is available upon 
                request by the Department of Health and Hospitals.</p>
                <p>Please contact HSS at 225-342-0138, or email <a href="mailto:HSS.mail@la.gov?Subject=POPS%20Authorization%20Password">HSS.mail@la.gov</a>, 
                to request a new Authorization password</p>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>