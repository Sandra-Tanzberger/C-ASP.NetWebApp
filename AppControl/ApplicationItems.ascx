<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationItems.ascx.cs" Inherits="AppControl.ApplicationItems" %>


<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div id="DivStateViewHeader" class="formTableSectionDiv" runat="server">
    Application
</div>
<telerik:RadAjaxPanel ID="p" runat="server">
<asp:Repeater ID="AppStatusRepeater" runat="server" OnItemDataBound="AppStatusRepeater_ItemDataBound" OnPreRender="AppStatusRepeater_PreRender" >
    <HeaderTemplate>
        <table class="formTable" border="0">
            <tr>
                <th width="100" align="left">Status</th>
                <th width="150" align="left">Date</th>
                <th width="400" align="left">Comments</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>        
            <tr valign="top">
                <td align="left" valign="top">
                    <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusDesc") %>' Visible='<%# DataBinder.Eval(Container.DataItem, "ShowLabel").Equals("true") ? true : false %>' />
                    <telerik:RadComboBox ID="cboStatus" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "ShowEdit").Equals("true") ? true : false %>'
                                       Enabled='<%# DataBinder.Eval(Container.DataItem, "Enabledcombo").Equals("true") ? true : false %>'
                                       Width="90" DataSource='<%# getAppStatOpts() %>' DataValueField="LOOKUP_VAL" DataTextField="VALDESC"
                                        />
                </td>
                <td align="left" valign="top">
                    <asp:Label ID="lblStatusDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusDate") %>' Visible='<%# DataBinder.Eval(Container.DataItem, "ShowLabel").Equals("true") ? true : false %>' />
                </td>
                <td align="left" valign="top">
                    <asp:Label ID="lblStatusComment" Width="400" runat="server" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "StatusComment") %>' 
                            Visible='<%# DataBinder.Eval(Container.DataItem, "ShowLabel").Equals("true") ? true : false %>' />
                    <asp:TextBox ID="txtStatusComment" runat="server" TextMode="MultiLine" MaxLength="1024" 
                                 onkeyup="return validateLimit(this, 1024)"
                                 Rows="2" 
                                 Text='<%# DataBinder.Eval(Container.DataItem, "CommentText") %>' 
                                 Visible='<%# DataBinder.Eval(Container.DataItem, "ShowEdit").Equals("true") ? true : false %>' />
                </td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
    <table class="formTable" border="0">
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="LicenseSurveyDate" runat="server">License Survey Date</asp:Label>
            </td>
            <td style="width: 200px;">
                <telerik:RadDatePicker ID="RadDatePickerLicSrvyDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211" Calendar-FastNavigationStep="12" >
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:Label ID="lblOrigLicDate" runat="server" Text="Original Licensure Date: " />
            </td>
            <td>
                
                <telerik:RadDatePicker ID="txtOrigLicDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211" Calendar-FastNavigationStep="12" Enabled="false">
                </telerik:RadDatePicker>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
             <td>&nbsp;</td>
            <td>
                <asp:Label ID="HealthApprovalDate" runat="server">Health Approval Date</asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="RadDatePickerHealthApprovalDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211" Calendar-FastNavigationStep="12" >
                </telerik:RadDatePicker>
            </td>
           
            <td>
                <asp:Label ID="lblLicIssueDt" runat="server" Text="Current License Issue Date: " />
            </td>
            <td>    
                <telerik:RadDatePicker ID="dtLicIssue" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211"
                                       ClientEvents-OnDateSelected="CheckIssueDate" Calendar-FastNavigationStep="12" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblStateFireApprovalDate" runat="server">State Fire Approval Date</asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="RadDatePickerStateFireApprovalDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211" Calendar-FastNavigationStep="12" >
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:Label ID="lblLicEffectiveDt" runat="server" Text="License Effective Date: " />
            </td>
            <td>    
                <telerik:RadDatePicker ID="dtLicEffective" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211"
                                       ClientEvents-OnDateSelected="CheckEffectDate" Calendar-FastNavigationStep="12" />
            </td>
            <td>
                <asp:CheckBox ID="chkEffDtOvrd" runat="server" Text="Override License Effective Date Rule" Font-Size="10pt" />
            </td>
        </tr>
       
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblTypeLicense" runat="server" Text="Type License" />
            </td>
            <td>
                <telerik:RadComboBox ID="cboTypeLicense" runat="server" Width="120" AutoPostBack="false" />
            </td>
             <td>
                <asp:Label ID="lblLicExpireDt" runat="server" Text="License Expiration Date: " />
            </td>
            <td>    
                <telerik:RadDatePicker ID="dtLicExpire" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211"  
                                       ClientEvents-OnDateSelected="CheckExpireDate" Calendar-FastNavigationStep="12" />
            </td>
            <td>
                <asp:CheckBox ID="chkExpDtOvrd" runat="server" Text="Override License Expiration Date Rule" Font-Size="10pt" />
            </td>
        </tr>
         <tr>
            <td colspan="3">&nbsp;</td>
           <td>
                <asp:Label ID="lbl1YrSurveyDueDate" runat="server" Text="1 Yr Survey Due Date: "  Visible="false"/>
            </td>
            <td>    
                <telerik:RadDatePicker ID="rd1YrSurveyDueDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211"  
                                       ClientEvents-OnDateSelected="CheckExpireDate" Calendar-FastNavigationStep="12" Visible="false"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:HiddenField ID="hidLastLicExpDate" runat="server" Value="" />
    <asp:HiddenField ID="hidSavedEffDate" runat="server" Value="" />
    <asp:HiddenField ID="hidSavedExpDate" runat="server" Value="" />
    <asp:HiddenField ID="hidDoEffExpDtValidate" runat="server" Value="Y" />
</telerik:RadAjaxPanel>
<div id="DivProviderViewHeader" class="formTableSectionDiv" runat="server">
    Process
</div>
<asp:Table ID="tblProviderView" CssClass="formTable" CellSpacing="0" BorderWidth="0" Width="98%" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblProposedEffectiveDt" runat="server" Text="Proposed Effective Date: " />
            <telerik:RadDatePicker ID="dtProposedEffectiveDt" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" Calendar-FastNavigationStep="12" Width="100" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<telerik:RadCodeBlock ID="RCB_AppItems" runat="server">
<script type="text/javascript">
    //global vars
    var LicDtChkMsgSent = false;
    
    function validateLimit(obj, maxchar) {

        if (this.id) obj = this;

        var remaningChar = maxchar - trimEnter(obj.value).length;

        if (remaningChar <= 0) {
            obj.value = obj.value.substring(maxchar, 0);
            return false;
        }
        else {
            return true;
        }
    }

    function get_object(id) {
        var object = null;
        if (document.layers) {
            object = document.layers[id];
        } else if (document.all) {
            object = document.all[id];
        } else if (document.getElementById) {
            object = document.getElementById(id);
        }
        return object;
    }
    function trimEnter(dataStr) {
        return dataStr.replace(/(\r\n|\r|\n)/g, "");
    }

    function CheckEffectDate(sender, eventargs) {
        if (LicDtChkMsgSent)
            LicDtChkMsgSent = false;
        else
            CheckDates('LicEffect');
    }

    function CheckExpireDate(sender, eventargs) {
        if (LicDtChkMsgSent)
            LicDtChkMsgSent = false;
        else
            CheckDates('LicExpire');
    }

    function CheckIssueDate(sender, eventargs) {
        if (LicDtChkMsgSent)
            LicDtChkMsgSent = false;
        else
            CheckDates('LicIssue');
    }

    function CheckDates(inDtFld) {
        var hidLastExpDate = document.getElementById("<%= hidLastLicExpDate.ClientID %>");
        var hidSaveEffDate = document.getElementById("<%= hidSavedEffDate.ClientID %>");
        var hidSaveExpDate = document.getElementById("<%= hidSavedExpDate.ClientID %>");
        var hidDoEffExpDtValidate = document.getElementById("<%= hidDoEffExpDtValidate.ClientID %>");

        var EffDtOvrd = document.getElementById("<%= chkEffDtOvrd.ClientID %>");
        var ExpDtOvrd = document.getElementById("<%= chkExpDtOvrd.ClientID %>");
        
        var EffDtPicker = $telerik.findControl(document, "<%= dtLicEffective.ClientID %>");
        var ExpDtPicker = $telerik.findControl(document, "<%= dtLicExpire.ClientID %>");
        var IssueDtPicker = $telerik.findControl(document, "<%= dtLicIssue.ClientID %>");
        
        var EffDate = EffDtPicker.get_selectedDate();
        var ExpDate = ExpDtPicker.get_selectedDate();
        var IssueDate = IssueDtPicker.get_selectedDate();

        var LastLicExpDate = new Date();
        var CompareDate = new Date();

//        alert(hidLastExpDate.value);
//        alert(hidEffDtOvrd.value);
//        alert(hidExpDtOvrd.value);

        if (hidLastExpDate != "")
            LastLicExpDate = new Date(hidLastExpDate.value);
        
        //No need to validate Effective and Expiration dates when set to readonly
        if (hidDoEffExpDtValidate.value == "Y") {
            switch (inDtFld) {
                case "LicEffect":
                    if (null != EffDate && hidLastExpDate.value != "" && !EffDtOvrd.checked) {
                        CompareDate = new Date(LastLicExpDate);
                        CompareDate.setFullYear(CompareDate.getFullYear() + 1);
                        if (EffDate > CompareDate) {
                            LicDtChkMsgSent = true;
                            alert('The license effective date entered is more than 366 days after the last license expiration date.\r\nSelect the "Override License Effective Date Rule" check box to override validation for this field.');
                            EffDtPicker.set_selectedDate(new Date(hidSaveEffDate.value));
                        }

                        CompareDate = new Date(LastLicExpDate);
                        CompareDate.setFullYear(CompareDate.getFullYear() - 1);
                        if (CompareDate > EffDate) {
                            LicDtChkMsgSent = true;
                            alert('The license effective date entered is more than 366 days before the last license expiration date.\r\nSelect the "Override License Effective Date Rule" check box to override validation for this field.');
                            EffDtPicker.set_selectedDate(new Date(hidSaveEffDate.value));
                        }
                    }
                    break;
                case "LicExpire":
                    if (null != EffDate && null != ExpDate && !ExpDtOvrd.checked) {
                        CompareDate = new Date(EffDate);
                        CompareDate.setFullYear(CompareDate.getFullYear() + 1);
                        if (ExpDate < EffDate) {
                            LicDtChkMsgSent = true;
                            alert("The license expiration date must be greater that the license effective date.");
                            ExpDtPicker.set_selectedDate(new Date(hidSaveExpDate.value));
                        }
                        else if (ExpDate > CompareDate) {
                            LicDtChkMsgSent = true;
                            alert('The license expiration date entered is more than 366 days after the license effective date.\r\nSelect the "Override License Expiration Date Rule" check box to override validation for this field.');
                            ExpDtPicker.set_selectedDate(new Date(hidSaveExpDate.value));
                        }
                    }
                    break;
                case "LicIssue":
                    if (null != ExpDate && null != IssueDate) {
                        if (IssueDate > ExpDate) {
                            LicDtChkMsgSent = true;
                            alert("The issue date must be before the expiration date");
                            IssueDtPicker.clear();
                        }
                    }
                    break;
            }
            
        }
        
    }

</script>
</telerik:RadCodeBlock>