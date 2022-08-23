<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeyPersonnelEditForm.ascx.cs" Inherits="AppControl.KeyPersonnelEditForm" %>

<telerik:RadAjaxManagerProxy ID="KeyPersonnelRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnNewPerson">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="KeyPersonnelTable" LoadingPanelID="lpKeyPersonnelEducation" />
                <telerik:AjaxUpdatedControl ControlID="rgKeyPersonnelEducation" LoadingPanelID="lpKeyPersonnelEducation" />
                <telerik:AjaxUpdatedControl ControlID="rgKeyPersonnelEmployment" LoadingPanelID="lpKeyPersonnelEducation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgKeyPersonnelEducation">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgKeyPersonnelEducation" LoadingPanelID="lpKeyPersonnelEducation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgKeyPersonnelEmployment">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgKeyPersonnelEmployment" LoadingPanelID="lpKeyPersonnelEducation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div style="background-color: #EDE99E;" >
<asp:Table ID="KeyPersonnelTable" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblKPFName" runat="server" Text="First Name: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtKPFirstName" runat="server" MaxLength="15" ></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblKPMInit" runat="server" Text="Middle Initial: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtKPMiddleInitial" runat="server" MaxLength="1" ></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblKPLName" runat="server" Text="Last Name: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtKPLastName" runat="server" MaxLength="20" ></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblKPPhone" runat="server">Phone Number: </asp:Label>
        </asp:TableCell>
        <asp:TableCell  VerticalAlign="Bottom" HorizontalAlign="Left">
            <telerik:RadMaskedTextBox ID="txtKPPhone" runat="server" Mask="(###) ###-####" />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblKPFax" runat="server">Fax Number: </asp:Label>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="3">
            <telerik:RadMaskedTextBox ID="txtKPFax" runat="server" Mask="(###) ###-####" />
         </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblKPEmail" runat="server">Email Address: </asp:Label>
         </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="5">
            <asp:TextBox ID="txtKPEmail" runat="server" MaxLength="40" Width="350"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

<div id="DivAdministrativeHeader" class="formTableSectionDiv" runat="server">
    Educational Qualifications
</div>
<div style="margin-left: 10px;width: 97%;" >
    <telerik:RadAjaxLoadingPanel ID="lpKeyPersonnelEducation" runat="server" />
    <telerik:RadGrid ID="rgKeyPersonnelEducation" runat="server" Width="98%"
                     OnNeedDataSource="rgKeyPersonnelEducation_NeedDataSource"
                     OnItemCreated="rgKeyPersonnelEducation_ItemCreated"
                     OnInsertCommand="rgKeyPersonnelEducation_InsertCommand"
                     OnDeleteCommand="rgKeyPersonnelEducation_DeleteCommand"
                     OnUpdateCommand="rgKeyPersonnelEducation_UpdateCommand"
                     OnPreRender="rgKeyPersonnelEducation_PreRender"                      
                     AutoGenerateColumns="false">
        <MasterTableView>
            <CommandItemTemplate>
                <asp:LinkButton ID="btnEDAddNew" runat="server" CommandName="InitInsert" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add Education Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEDEditSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    Edit Selected Education Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEDViewSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    View Selected Education Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEDDeleteSelected" runat="server" CommandName="DeleteSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Delete Selected Education Item
                </asp:LinkButton>
            </CommandItemTemplate>
            <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/EducationEditForm.ascx" EditFormType="WebUserControl">
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<div id="Div1" class="formTableSectionDiv" runat="server">
    Employment History
</div>
<div style="margin-left: 10px;width: 97%;" >
    <telerik:RadGrid ID="rgKeyPersonnelEmployment" runat="server" Width="98%"
                     OnNeedDataSource="rgKeyPersonnelEmployment_NeedDataSource"
                     OnItemCreated="rgKeyPersonnelEmployment_ItemCreated"
                     OnInsertCommand="rgKeyPersonnelEmployment_InsertCommand"
                     OnDeleteCommand="rgKeyPersonnelEmployment_DeleteCommand"
                     OnUpdateCommand="rgKeyPersonnelEmployment_UpdateCommand"
                     OnPreRender="rgKeyPersonnelEmployment_PreRender"
                     AutoGenerateColumns="false"
    >
        <MasterTableView>
            <CommandItemTemplate>
                <asp:LinkButton ID="btnEMAddNew" runat="server" CommandName="InitInsert" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add Employment Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEMEditSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    Edit Selected Employment Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEMViewSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    View Selected Employment Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnEMDeleteSelected" runat="server" CommandName="DeleteSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Delete Selected Employment Item
                </asp:LinkButton>
            </CommandItemTemplate>
            <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/EmploymentEditForm.ascx" EditFormType="WebUserControl">
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<br />
&nbsp;&nbsp;&nbsp;
<asp:button id="btnNewPerson" text="New Person" runat="server" CommandName="AddNewPerson" 
            OnCommand="AddNewPerson_Click" Visible="false" />
<asp:HiddenField ID="IsNewRec" runat="server" Value="N" />
<br />
</div>
