<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ownership.ascx.cs" Inherits="AppControl.Ownership" %>

<telerik:RadAjaxManagerProxy ID="LicHomeRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="OwnerInterest">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="OwnerInterest" LoadingPanelID="OwnerLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="OwnFacOther">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="OwnFacOther" LoadingPanelID="OwnerLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="OtherLicFacYes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="OwnFacOther" LoadingPanelID="OwnerLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="OtherLicFacNo">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="OwnFacOther" LoadingPanelID="OwnerLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="OwnershipRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function ConfirmDeleteOwnership( inGrdType ) {
              var gridCtrlOwner = $find("<%=OwnerInterest.ClientID %>");
              var gridCtrlOtherProv = $find("<%=OwnFacOther.ClientID %>");
              var selRow;

              if (inGrdType == "OWNER") {
                  selRow = gridCtrlOwner.get_masterTableView().get_selectedItems();
                  if (selRow.length > 0) {
                      var retVal = confirm("Are you sure you want to remove the selected Owner Interest record?");

                      if (retVal) {
                          return true;
                      }
                      else {
                          return false;
                      }
                  }
                  else {
                      alert("No record selected.");
                      return false;
                  }
              }
              else if (inGrdType == "OTHER_PROV") {
                  selRow = gridCtrlOtherProv.get_masterTableView().get_selectedItems();
                  if (selRow.length > 0) {
                      var retVal = confirm("Are you sure you want to remove the selected Owner Other Provider record?");

                      if (retVal) {
                          return true;
                      }
                      else {
                          return false;
                      }
                  }
                  else {
                      alert("No record selected.");
                      return false;
                  }
              }
          }
      </script>  
</telerik:RadCodeBlock>
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div id="DivIdentInfoHeader" class="formTableSectionDiv" runat="server">
    Identifying Information
</div>
<asp:Panel ID="pnlPrimaryOwner" runat="server" Width="97%" />
<div id="Div1" class="formTableSectionDiv" runat="server">
    Type of Entity
</div>
<asp:Table CssClass="formTable" ID="Table1" BorderWidth="0" Width="98%" runat="server">
</asp:Table>
<asp:Table CssClass="formTable" ID="OwnTbl1" BorderWidth="0" Width="98%" runat="server">
    <asp:TableHeaderRow VerticalAlign="Top">
        <asp:TableHeaderCell Width="33%" HorizontalAlign="Left" >
            <asp:RadioButton ID="optNonProfit" runat="server" Text="Non-Profit" GroupName="TypeEntity" onClick="TypeEntityClick( 'NP' );" />
            <br />(Must submit evidence of non-profit status)
        </asp:TableHeaderCell>
        <asp:TableHeaderCell Width="33%" HorizontalAlign="Left">
            <asp:RadioButton ID="optForProfit" runat="server" Text="For Profit" GroupName="TypeEntity" onClick="TypeEntityClick( 'FP' );" />
        </asp:TableHeaderCell>
        <asp:TableHeaderCell Width="33%" HorizontalAlign="Left">
            <asp:RadioButton ID="optGovernment" runat="server" Text="Government" GroupName="TypeEntity" onClick="TypeEntityClick( 'G' );" />
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Top" >
            <asp:RadioButtonList ID="optNonProfitTypeOwnership" runat="server" RepeatColumns="1" AutoPostBack="false" RepeatDirection="Vertical" Enabled="false" onClick="TypeOwnerClick( 'NP' );" />
            <asp:TextBox ID="txtOwnershipOtherNP" runat="server" MaxLength="25" />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Top" >
            <asp:RadioButtonList ID="optProfitTypeOwnership" runat="server" RepeatColumns="1" AutoPostBack="false" RepeatDirection="Vertical" Enabled="false" onClick="TypeOwnerClick( 'FP' );" />
            <asp:TextBox ID="txtOwnershipOtherFP" runat="server" MaxLength="25" />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Top" >
            <asp:RadioButtonList ID="optGovernmentTypeOwnership" runat="server" RepeatColumns="1" AutoPostBack="false" RepeatDirection="Vertical" Enabled="false" onClick="TypeOwnerClick( 'G' );" />
            <asp:TextBox ID="txtOwnershipOtherG" runat="server" MaxLength="25" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table> 
<div class="LicSectionInfoDiv" style="width: 97%;">
    List names, addresses and phone numbers for persons or group of persons, or the Employer Identification Number (EIN) for organizations having direct or indirect ownership or a controlling interest (≥ 5%) of the corporate stock or partnership interest or any person or business entity which has a direct business interest, including, but not limited to, a wholly owned subsidiary, the details of any conversion rights which may exist for the benefit of any party and whether such stock, partnership interest, or ownership being held by the disclosed person or business entity is, in fact, owned by another person or business entity.
</div>
<div style="margin-left: 10px;width: 97%;" >
    <telerik:RadAjaxLoadingPanel ID="OwnerLoadingPanel" runat="server" />
    <telerik:RadGrid ID="OwnerInterest" runat="server" Width="98%"
                     OnNeedDataSource="OwnerInterest_NeedDataSource"
                     OnItemCreated="OwnerInterest_ItemCreated"
                     OnInsertCommand="OwnerInterest_InsertCommand"
                     OnDeleteCommand="OwnerInterest_DeleteCommand"
                     OnUpdateCommand="OwnerInterest_UpdateCommand" 
                     OnPreRender="OwnerInterest_PreRender"
                     AutoGenerateColumns="false">
        <MasterTableView>
            <CommandItemTemplate>
                <asp:LinkButton ID="btnOIAddNew" runat="server" CommandName="InitInsert" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add Owner
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnOIEditSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    Edit Selected Owner
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnOIDeleteSelected" runat="server" CommandName="DeleteSelected" OnClientClick="return ConfirmDeleteOwnership('OWNER');" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Delete Selected Owner
                </asp:LinkButton>
            </CommandItemTemplate>
            <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/OwnerEditForm.ascx" EditFormType="WebUserControl">
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<div id="DivOwnOtherFacHeader" class="formTableSectionDiv" runat="server">
    Other Licensed facilities
</div>
<div class="LicSectionInfoDiv" style="width: 97%;">
    Are any owners of the disclosing entity also owners (proprietorship, Partnership or Board Members) of other licensed health care facilities?  If yes, list names, addresses of individuals and Facility provider numbers. 
    <asp:RadioButton Font-Size="11px" ID="OtherLicFacNo" runat="server" GroupName="OtherLicFacYesNo" Text="No" AutoPostBack="true" oncheckedchanged="OtherLicFacYesNo_CheckedChanged" Checked="true" />
    <asp:RadioButton Font-Size="11px" ID="OtherLicFacYes" runat="server" GroupName="OtherLicFacYesNo" Text="Yes" AutoPostBack="true" oncheckedchanged="OtherLicFacYesNo_CheckedChanged" />
</div>
<div style="margin-left: 10px;width: 97%;" >
    <telerik:RadGrid ID="OwnFacOther" runat="server" Width="98%"
                     OnNeedDataSource="OwnFacOther_NeedDataSource"
                     OnItemCreated="OwnFacOther_ItemCreated"
                     OnInsertCommand="OwnFacOther_InsertCommand"
                     OnDeleteCommand="OwnFacOther_DeleteCommand"
                     OnUpdateCommand="OwnFacOther_UpdateCommand" 
                     OnPreRender="OwnFacOther_PreRender"
                     AutoGenerateColumns="false">
        <MasterTableView>
            <CommandItemTemplate>
                <asp:LinkButton ID="btnOFOAddNew" runat="server" CommandName="InitInsert" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add new
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnOFOEditSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    Edit Selected
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnOFOViewSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    View Selected
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnOFODeleteSelected" runat="server" CommandName="DeleteSelected" OnClientClick="return ConfirmDeleteOwnership('OTHER_PROV');" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Delete Selected
                </asp:LinkButton>
            </CommandItemTemplate>
            <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/OwnFacOtherEditForm.ascx" EditFormType="WebUserControl">
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<telerik:RadCodeBlock ID="RCB_Ownership" runat="server">
    <script type="text/javascript" >
    function TypeEntityClick(inOptListToEnable) {
        var LstNonProfit = document.getElementById("<%=optNonProfitTypeOwnership.ClientID %>");
        var LstForProfit = document.getElementById("<%=optProfitTypeOwnership.ClientID %>");
        var LstGovernment = document.getElementById("<%=optGovernmentTypeOwnership.ClientID %>");

        var inputElementArray;
        var inputElementArray2;

        switch (inOptListToEnable) {
            case "NP":
                RecursiveEnable(LstNonProfit);
                LstForProfit.disabled = true;
                if (null != LstGovernment) {
                    LstGovernment.disabled = true;
                }
                inputElementArray = LstForProfit.getElementsByTagName('input');
                if (null != LstGovernment) {
                    inputElementArray2 = LstGovernment.getElementsByTagName('input');
                } 
                break;
            case "FP":
                LstNonProfit.disabled = true;
                RecursiveEnable(LstForProfit);
                if (null != LstGovernment) {
                    LstGovernment.disabled = true;
                }
                inputElementArray = LstNonProfit.getElementsByTagName('input');
                if (null != LstGovernment) {
                    inputElementArray2 = LstGovernment.getElementsByTagName('input');
                } 
                break;
            case "G":
                LstNonProfit.disabled = true;
                LstForProfit.disabled = true;
                RecursiveEnable(LstGovernment);
                inputElementArray = LstNonProfit.getElementsByTagName('input');
                inputElementArray2 = LstForProfit.getElementsByTagName('input');
                break;
        }

        for (var i = 0; i < inputElementArray.length; i++) {
            var inputElement = inputElementArray[i];

            inputElement.checked = false;
        }

        if (null != inputElementArray2 && inputElementArray2.length > 0) {
            for (var i = 0; i < inputElementArray2.length; i++) {
                var inputElement = inputElementArray2[i];

                inputElement.checked = false;
            }
        }

        TypeOwnerClick(inOptListToEnable);

    }

    function RecursiveEnable(control) {
        var children = control.childNodes;

        try { control.removeAttribute('disabled') }
        catch (ex) { }

        for (var j = 0; j < children.length; j++) {
            RecursiveEnable(children[j]);
        }
    }

    function TypeOwnerClick(inOptList) {
        var LstNonProfit = document.getElementById("<%=optNonProfitTypeOwnership.ClientID %>");
        var LstForProfit = document.getElementById("<%=optProfitTypeOwnership.ClientID %>");
        var LstGovernment = document.getElementById("<%=optGovernmentTypeOwnership.ClientID %>");

        var txtNP = document.getElementById("<%=txtOwnershipOtherNP.ClientID %>");
        var txtFP = document.getElementById("<%=txtOwnershipOtherFP.ClientID %>");
        var txtG = document.getElementById("<%=txtOwnershipOtherG.ClientID %>");

        var inputElementArray;
        var labelElementArray;

        var selectedIndex = -1;
        var inOther = false;

        switch (inOptList) {
            case "NP":
                inputElementArray = LstNonProfit.getElementsByTagName('input');
                labelElementArray = LstNonProfit.getElementsByTagName('label');
                break;
            case "FP":
                inputElementArray = LstForProfit.getElementsByTagName('input');
                labelElementArray = LstForProfit.getElementsByTagName('label');
                break;
            case "G":
                inputElementArray = LstGovernment.getElementsByTagName('input');
                labelElementArray = LstGovernment.getElementsByTagName('label');
                break;
        }

        for (var i = 0; i < inputElementArray.length; i++) {
            var inputElement = inputElementArray[i];

            if (inputElement.checked == true) {
                selectedIndex = i;
                break;
            }
        }
       
        for (var i = 0; i < labelElementArray.length; i++) {
            var labelElement = labelElementArray[i];
            if (labelElement.innerHTML == "OTHER" && selectedIndex == i) {
                
                inOther = true;
                
                if (inOptList == 'NP') {
                    if (txtNP != null) {
                        txtNP.disabled = false;
                    }
                    if (txtFP != null) {
                        txtFP.disabled = true;
                        txtFP.value = "";
                    }
                    if (txtG != null) {
                        txtG.disabled = true;
                        txtG.value = "";
                    }
                }
                else if (inOptList == 'FP') {
                    if (txtFP != null) {
                        txtFP.disabled = false;
                    }
                    if (txtNP != null) {
                        txtNP.disabled = true;
                        txtNP.value = "";
                    }
                    if (txtG != null) {
                        txtG.disabled = true;
                        txtG.value = "";
                    }
                }
                else if (inOptList == 'G') {
                    if (txtG != null) {
                        txtG.disabled = false;
                    }
                    if (txtNP != null) {
                        txtNP.disabled = true;
                        txtNP.value = "";
                    }
                    if (txtFP != null) {
                        txtFP.disabled = true;
                        txtFP.value = "";
                    }
                }
                break;
            }
        }

        if (inOther == false) {
            if (txtG != null) {
                txtG.disabled = true;
                txtG.value = "";
            }
            if (txtNP != null) {
                txtNP.disabled = true;
                txtNP.value = "";
            }
            if (txtFP != null) {
                txtFP.disabled = true;
                txtFP.value = "";
            }
        }
        
    }    

</script>
</telerik:RadCodeBlock>