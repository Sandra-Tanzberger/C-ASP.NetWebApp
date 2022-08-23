<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityGrid.ascx.cs" Inherits="AppControl.FacilityGrid" %>

<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">  
    <script type="text/javascript">  
        function rowDoubleClick(sender, eventArgs)  
        {
            __doPostBack("<%= this.UniqueID %>", "RowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());      
        }              
    </script> 
</telerik:RadScriptBlock> 
        
<telerik:RadGrid ID="grdProviders" runat="server" 
    GridLines="None" Width="100%" Height="300px" 
    OnNeedDataSource="grdProviders_NeedDataSource" 
    OnItemCommand="grdProviders_ItemCommand" >
    <MasterTableView CommandItemDisplay=Top>
        <CommandItemTemplate>
            <asp:LinkButton ID="btnView" runat="server" CommandName="View" >View</asp:LinkButton>
        </CommandItemTemplate>                
        <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="false">
        <Selecting AllowRowSelect="True" />
        <Scrolling AllowScroll="True" />
        <ClientEvents OnRowDblClick="rowDoubleClick" /> 
    </ClientSettings>
</telerik:RadGrid>                 

<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true" Behaviors="None" />

