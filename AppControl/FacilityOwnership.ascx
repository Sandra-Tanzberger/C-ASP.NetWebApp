<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityOwnership.ascx.cs" Inherits="AppControl.FacilityOwnership" %>

<style type="text/css">
    .style1
    {
        width: 100px;
    }
    .style2
    {
        width: 300px;
    }
    .style3
    {
        width: 100px;
        text-align: right;
    }
    .style4
    {
        width: 100px;
    }
    .style5
    {
        width: 25px;
        text-align: right;
    }
    .style6
    {
        width: 100px;
    }
</style>

<telerik:RadGrid ID="grdOwnerShip" runat="server" AutoGenerateColumns="false" 
    Width="100%" Height="130px" 
    onneeddatasource="grdOwnerShip_NeedDataSource" 
    onselectedindexchanged="grdOwnerShip_SelectedIndexChanged" 
    ClientSettings-Scrolling-AllowScroll="true">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="DATESTARTED" DataField="DATESTARTED"
                HeaderText="Application Start Date" visible="true" HeaderStyle-Width="50%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="ENTITYNAME" DataField="ENTITYNAME" 
                HeaderText="Name of the Entity" visible="true" HeaderStyle-Width="50%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="APPLICATIONID" DataField="APPLICATIONID" 
                HeaderText="APPLICATIONID" visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="TYPEOWNERSHIP" DataField="TYPEOWNERSHIP" 
                HeaderText="TYPEOWNERSHIP" visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LEGALENTITYID" DataField="LEGALENTITYID" 
                HeaderText="LEGALENTITYID" visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="PERCENT_OWN" DataField="PERCENT_OWN"
                HeaderText="Percent Ownership" visible="False">
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="true" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>
<br />
<table id="tableFacilityDetails" class="formTable" width="725" cellspacing="1" cellpadding="1">
    <tr>
        <td class="style1">
            <asp:Label ID="Label16" runat="server">Ownership Type</asp:Label>
        </td>
        <td class="style2">
            <asp:DropDownList ID="listOwnershipType" runat="server" Enabled="false" />
        </td>
        <td class="style3">
            <asp:Label ID="Label52" runat="server">EIN </asp:Label>
        </td>
        <td class="style4">
            <asp:TextBox ID="TextBoxEIN" runat="server" MaxLength="10" Columns="10" Rows="1" ToolTip="EIN" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </asp:TextBox>
        </td>
        <td class="style5"></td>
        <td class="style6"></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label17" runat="server">Entity</asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBoxEntity" runat="server" Width="95%" Rows="1" ToolTip="Entity - Name of Corporation" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </asp:TextBox>
        </td>
        <td class="style3">Percent Ownership </td>
        <td class="style4"><asp:TextBox ID="txtPercentOwn" runat="server" Width="25" Text="" Enabled="false" /></td>
        <td class="style5"></td>
        <td class="style6"></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label24" runat="server">Entity Street Address</asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBoxEntityStreetAddress" runat="server" Width="95%" Rows="1" ToolTip="Entity Street Address" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </asp:TextBox>
        </td>
        <td class="style3"></td>
        <td class="style4"></td>
        <td class="style5"></td>
        <td class="style6"></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label25" runat="server">Entity City</asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBoxEntityCity" runat="server" MaxLength="20" Columns="20" Rows="1" ToolTip="Entity City" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </asp:TextBox>
        </td>
        <td class="style3">
            <asp:Label ID="Label50" runat="server">State </asp:Label>
        </td>                                
        <td class="style4">
            <asp:TextBox ID="TextBoxEntityState" runat="server" MaxLength="2" Columns="2" Rows="1" ToolTip="Entity State" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </asp:TextBox>
        </td>
        <td class="style5">
            <asp:Label ID="Label51" runat="server">Zip </asp:Label>
        </td>                                
        <td class="style6">
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxEntityZip" runat="server" Columns="10" Rows="1" ToolTip="Entity Zip" Mask="#####-####" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </telerik:RadMaskedTextBox>
        </td>                    
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label26" runat="server">Entity Phone</asp:Label>
        </td>
        <td class="style2">
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxEntityPhone" runat="server" Mask="(###) ###-####" Columns="13" ToolTip="Entity Phone" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </telerik:RadMaskedTextBox>
        </td>
        <td class="style3">
            <asp:Label ID="Label27" runat="server">Fax </asp:Label>
        </td>
        <td class="style4">
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxEntityFax" runat="server" Mask="(###) ###-####" Columns="13" ToolTip="Entity Fax" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </telerik:RadMaskedTextBox>
        </td>
        <td class="style5"></td>
        <td class="style6"></td>
    </tr>
</table>
