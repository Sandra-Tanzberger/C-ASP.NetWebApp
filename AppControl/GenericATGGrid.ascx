<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericATGGrid.ascx.cs" Inherits="AppControl.GenericATGGrid" %>

<telerik:RadGrid ID="radGrid1" runat="server" 
    GridLines="None" Width="100%" Height="100px" 
    OnSelectedIndexChanged="radGrid1_SelectedIndexChanged" 
    OnNeedDataSource="radGrid1_NeedDataSource" 
    onitemdatabound="radGrid1_ItemDataBound" >
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
</MasterTableView>

    <ClientSettings EnablePostBackOnRowClick="True">
        <Selecting AllowRowSelect="True" />
        <Scrolling AllowScroll="True" />
    </ClientSettings>
</telerik:RadGrid>
