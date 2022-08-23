<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialtyUnit.ascx.cs" Inherits="AppControl.SpecialtyUnit" %>

<telerik:RadAjaxManagerProxy ID="SU_RAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="SpecialtyUnitRepeater">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="SpecialtyUnitRepeater" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadScriptBlock ID="SpecUnitRSB" runat="server">
    <script type="text/javascript">
        function ToggleRO_SU_ChildCtrls(inChkBoxClientID, inContainerElemID, inChildComboID, inForceRO) {
            try {
                var tmpChkBox = document.getElementById(inChkBoxClientID);
                var TmpTbl = document.getElementById(inContainerElemID);
                var tmpCbo = $find(inChildComboID);

                if (inForceRO != "Y") {
                    if (null != tmpCbo)
                        ToggleRO_RadCombo(tmpCbo, !tmpChkBox.checked);

                    //Each check box can have its own attributes so they are handled here by type.
                    // 5 = Transplant
                    if (tmpChkBox.getAttribute('SU_TypeID') == "5") {
                        var dependChildCtrlArr = tmpChkBox.getAttribute('dependants').split(",");
                        var tmpDependChk = document.getElementById(dependChildCtrlArr[0]);
                        var tmpDependTxtCCN = document.getElementById(dependChildCtrlArr[1]);

                        if (null != tmpDependChk) {
                            if (!tmpChkBox.checked)
                                tmpDependChk.checked = false;

                            tmpDependChk.disabled = !tmpChkBox.checked;

                            if (null != tmpDependTxtCCN) {
                                tmpDependTxtCCN.disabled = !tmpDependChk.checked;

                            }
                        }
                    }

                    ChangeCtrlRO(!tmpChkBox.checked, TmpTbl, true);
                }
                else {
                    ChangeCtrlRO(true, TmpTbl, true);
                }
            }
            catch (e) { }
        }
    </script>
</telerik:RadScriptBlock>
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Repeater ID="SpecialtyUnitRepeater" runat="server" OnItemDataBound="SpecialtyUnitRepeater_ItemDataBound" OnPreRender="SpecialtyUnitRepeater_PreRender">
    <HeaderTemplate>
        <table id="tblSpecUnits" class="formTable" border="0">
    </HeaderTemplate>
    <ItemTemplate>
            <tr valign="top">
                <td style="width: 20px" valign="top">
                    <asp:Checkbox ID='chkSU' runat="server" AutoPostBack="false" />
                    <asp:HiddenField ID="hidSU_TypeID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TypeSpecialtyUnit") %>' />
                    <asp:HiddenField ID="hidSU_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TypeSpecialtyUnit") %>' />
                </td>
                <td style="width: 250px;padding-top: 5px;" valign="top">
                    <asp:Label ID='lblSU_Desc' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' />
                </td>
                <td style="width: 540px;padding-top: 5px" valign="top">
                    <table id='tblChildFields' runat="server">
                        <tr>
                            <td style="width: 200px;" valign="top">
                        	    <asp:Label ID='lblSU_CCN' runat="server" Text='CCN:' Visible='<%# DataBinder.Eval(Container.DataItem, "ShowCCN").Equals("true") ? true : false %>' />
                        	    <asp:TextBox ID="txtSU_CCN" runat="server" MaxLength="12" Text='' AutoPostBack="false"
                                      Visible='<%# DataBinder.Eval(Container.DataItem, "ShowCCN").Equals("true") ? true : false %>' />                                      
                            </td>
                            <td style="width: 340px;" valign="top">
                                <telerik:RadComboBox ID="lstSU_Level" runat="server" AutoPostBack="false"
                                                  Visible='<%# DataBinder.Eval(Container.DataItem, "ShowLevel").Equals("true") ? true : false %>' 
                                                  DataSource='<%# getLevelOpts() %>' DataValueField="LOOKUP_VAL" DataTextField="VALDESC" Enabled="false" />
                                <asp:ListBox ID="lstSU_SubType" runat="server" Height="130" CssClass="listBox" Width="158" 
                                                  Visible='<%# DataBinder.Eval(Container.DataItem, "ShowSubType").Equals("true") ? true : false %>' 
                                                  DataSource='<%# getSubTypeOpts() %>' SelectionMode="Multiple"
                                                  DataValueField="LOOKUP_VAL" DataTextField="VALDESC" AutoPostBack="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3"><hr /></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>