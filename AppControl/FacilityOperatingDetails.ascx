<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityOperatingDetails.ascx.cs" Inherits="AppControl.FacilityOperatingDetails" %>

<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<table id="tableOperatingDetails" class="formTable" width="100%" cellspacing="1" cellpadding="1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server">Hours of Operation:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxHoursMinutes" runat="server" 
            MaxLength="5" ToolTip="Hours From" Columns="5">
            </asp:TextBox>
            <asp:DropDownList ID="listAmPm" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server"> To </asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxHoursMinutes1" runat="server" 
            MaxLength="5" ToolTip="Hours To" Columns="5">
            </asp:TextBox>
            <asp:DropDownList ID="listAmPm1" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server">Days of Operation: </asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationMon" runat="server"
                Text="Monday" TextAlign="Right" />
        </td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationTue" runat="server"
                Text="Tuesday" TextAlign="Right" />
        </td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationWed" runat="server"
                Text="Wednesday" TextAlign="Right" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationThu" runat="server"
                Text="Thursday" TextAlign="Right" />
        </td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationFri" runat="server"
                Text="Friday" TextAlign="Right" />
        </td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationSat" runat="server"
                Text="Saturday" TextAlign="Right" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:CheckBox ID="CheckBoxDayOfOperationSun" runat="server"
                Text="Sunday" TextAlign="Right" />
        </td>
        <td></td>
        <td></td>
    </tr>
    
    <tr>
        <td>
            <asp:Label ID="LabelNumOperatingRooms" runat="server">Number of Operating Rooms: </asp:Label>
            <asp:TextBox ID="TextNumOperatingRooms" runat="server" 
                MaxLength="5" ToolTip="Number of Operating Rooms" Columns="5">
            </asp:TextBox>
        </td>
    </tr>        
</table>