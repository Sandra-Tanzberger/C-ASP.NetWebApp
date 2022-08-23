<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageCenter.ascx.cs" Inherits="AppControl.MessageCenter" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="MsgsGrid2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="MsgsGrid2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock runat="server" ID="radCodeBlock">
    <script type="text/javascript">
        var shFltr = true;

        function showFilterItem() {
            var mastbl = $find('<%=MsgsGrid2.ClientID %>').get_masterTableView();
            if (!shFltr) {
                shFltr = true;
                alert("show");                
                mastbl.showFilterItem();
                //$find('<%=MsgsGrid2.ClientID %>').Rebind();
            }
            else {
                shFltr = false;
                alert("hide");
                mastbl.hideFilterItem();
            }
        } 
    </script>
</telerik:RadCodeBlock>
<div style="display: none;">
    Show filtering item 
    <input id="Radio1" type="radio" runat="server" name="showHideGroup" checked="true" onclick="showFilterItem()" />
    <label for="Radio1">Yes</label> 
    <input id="Radio2" type="radio" runat="server" name="showHideGroup" onclick="showFilterItem()"/>
    <label for="Radio2" >No</label>
</div>
<telerik:RadGrid ID="MsgsGrid2" runat="server" 
                Width="100%" 
                ClientSettings-Selecting-AllowRowSelect="true" 
                ClientSettings-EnablePostBackOnRowClick="true" 
    AllowPaging="True" AllowSorting="True" BorderStyle="None"
>
<PagerStyle Mode="NextPrevAndNumeric" Font-Bold="False" Font-Italic="False" 
        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
        HorizontalAlign="Right" Position="Top" Wrap="True" />
<MasterTableView AllowFilteringByColumn="true" EnableViewState="true">
    <RowIndicatorColumn>
        <HeaderStyle Width="20px"></HeaderStyle>
    </RowIndicatorColumn>
    <ExpandCollapseColumn>
        <HeaderStyle Width="20px"></HeaderStyle>
    </ExpandCollapseColumn>
</MasterTableView>
<ClientSettings EnablePostBackOnRowClick="True">
    <Scrolling AllowScroll="true"  />
    <Selecting AllowRowSelect="True"></Selecting>
</ClientSettings>
</telerik:RadGrid>
