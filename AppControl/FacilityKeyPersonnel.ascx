<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityKeyPersonnel.ascx.cs" Inherits="AppControl.FacilityKeyPersonnel" %>

<telerik:RadGrid ID="grdPersonnel" runat="server" AutoGenerateColumns="false" 
    Width="100%" Height="130px" 
    onneeddatasource="grdPersonnel_NeedDataSource" 
    onselectedindexchanged="grdPersonnel_SelectedIndexChanged" 
    ClientSettings-Scrolling-AllowScroll="true">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="DATESTARTED" DataField="DATESTARTED"
                HeaderText="Application Start Date" visible="true" HeaderStyle-Width="10%" 
                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="PERSONTYPEDESC" DataField="PERSONTYPEDESC" 
                HeaderText="Designation" visible="true" HeaderStyle-Width="20%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="FIRSTNAME" DataField="FIRSTNAME" 
                HeaderText="First Name" visible="true" HeaderStyle-Width="25%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LASTNAME" DataField="LASTNAME" 
                HeaderText="Last Name" visible="true" HeaderStyle-Width="25%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="EFFECTIVEDATE" DataField="EFFECTIVEDATE"
                HeaderText="Effective Date" visible="true" HeaderStyle-Width="10%" 
                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="EXPIRATIONDATE" DataField="EXPIRATIONDATE"
                HeaderText="Expiration Date" visible="true" HeaderStyle-Width="10%" 
                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="PERSONID" DataField="PERSONID" 
                visible="false">
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="true" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>
<br />
<asp:Table ID="PersonTable" CssClass="formTable" BorderWidth="0" runat="server" Width="700">
    <asp:TableRow>
        <asp:TableCell>Title</asp:TableCell>
        <asp:TableCell ColumnSpan="5"><asp:TextBox ID="txtPersTitle" runat="server" Text="" Enabled="false" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFName" runat="server" Text="First Name: " />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="TextBoxFirstName" runat="server" Columns="15" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblMInit" runat="server" Text="Middle Initial: " />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="TextBoxMiddleInitial" runat="server" MaxLength="02" Columns="02" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblLName" runat="server" Text="Last Name: " />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="TextBoxLastName" runat="server" Columns="20" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblPhone" runat="server">Phone Number: </asp:Label>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxPhone" runat="server" Columns="12" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblFax" runat="server">Fax Number: </asp:Label>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxFax" runat="server" Columns="12" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
         </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblEmail" runat="server">Email Address: </asp:Label>
         </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxEmail" runat="server" Columns="20" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray"></asp:TextBox>
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblDrivLicClassCode" runat="server">Drivers License Class</asp:Label>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxDrivLicClassCode" runat="server" Columns="03" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblDrivLicNum" runat="server">Drivers License Number</asp:Label>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxDrivLicNum" runat="server" Columns="11" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:Label ID="lblDrivLicState" runat="server">Drivers License State</asp:Label>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom">
            <asp:TextBox ID="TextBoxDrivLicState" runat="server" Columns="02" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" ></asp:TextBox>
        </asp:TableCell></asp:TableRow></asp:Table>