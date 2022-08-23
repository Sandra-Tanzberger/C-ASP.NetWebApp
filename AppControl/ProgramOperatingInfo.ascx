<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ProgramOperatingInfo.ascx.cs" Inherits="AppControl.ProgramOperatingInfo" %>
<telerik:RadScriptBlock ID="ProgramOperatingInfoRSB" runat="server">
    <script type="text/javascript">
        function keyPress(sender, args) {
            if (!sender._isNormalChar(args.get_domEvent())) {
                return;
            }

            var maxWholeDigits = 5;
            var maxDecimalDigits = 2;
            var separator = sender.get_numberFormat().DecimalSeparator;
            var regExpStr = "^\\d{0," + maxWholeDigits + "}(\\" + separator + "\\d{0," + maxDecimalDigits + "})?$";
            var regex = new RegExp(regExpStr);  //this should give "/^\d{0,5}(\.\d{0,2})?$/"

            var caret = sender.get_caretPosition();
            var value = sender._textBoxElement.value;
            var char = args.get_keyCharacter()

            if (caret === value.length) {
                value = value + char;
            }
            else {
                //place the new char to the correct position based on caret location
                value = value.substr(0, caret) + char + value.substr(caret);
            }

            if (!regex.test(value)) {
                args.set_cancel(true);
            }

        }

    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxLoadingPanel ID="ProgramOperatingInfoRLP" runat="server" />
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<br />
<div id="divOperatingInfo" runat="server">
    <asp:Table ID="tblOperatingInfo" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="tblOperationDate" CssClass="formTable" CellSpacing="0" BorderWidth="0" GridLines="None" runat="server">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" Wrap="true">
                            If you answer yes to the following, submit/attach proof of operation (this proof shall be an occupational license or certificate of operation issued by local governmental<br />authorities, in addition to verifying information that indicates the facility held itself out to the public as an urgent care facility).
                        </asp:TableCell>
                    </asp:TableRow>    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            &nbsp;
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell VerticalAlign="Top" Width="200">
                            Were you in operation prior to June 15, 2005?
                        </asp:TableCell>
                        <asp:TableCell VerticalAlign="Top" Width="65">
                            <asp:DropDownList ID="ddlYesNo" runat="server" Font-Size="11px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell> 
                        <asp:TableCell VerticalAlign="Top" Width="200" Wrap="true" >
                            <span id="AttachLinkButtonSpan" runat="server">
                                <asp:LinkButton ID="ProofOptAttachAction" CommandName="Upload" runat="server" Text="Attach"
                                            CommandArgument="" OnCommand="ProofOptAttachAction_Click" Width="65"/>
                            </span>
                            <span id="ViewLinkButtonSpan" runat="server" visible="false">
                            </span>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <hr style="margin:10px;" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblLicenseInfo" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblLACDS" runat="server" >LA CDS: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLACDS" runat="server" Width="100px" MaxLength="11" Text="" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblLACDSExp" runat="server" >Expires: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="txtLACDSExpDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblUSDEACS" runat="server" >US DEA CS Registration: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtUSDEACS" runat="server" Width="300px" MaxLength="50" Text="" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblUSDEACSExp" runat="server" >Expires: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="txtUSDEACSExpDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblMT" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblMedicaidNo" runat="server" >Medicaid No.: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtMedicaidNo" runat="server" Width="60px" MaxLength="8" Text="" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblMTCurCertSrvDt" runat="server" >Cur Cert. Srv Dt: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="rdpMTCurCertSrvDt" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblCLIAnum" runat="server" >CLIA #: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtCLIAnum" runat="server" Width="300px" MaxLength="12" Text="" ></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblCertExpDt" runat="server" >Cert. Exp Date: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="rdpCertExpDt" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblAirAmb" runat="server" ># Air Ambulances: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAirAmb" runat="server" Width="300px" MaxLength="5" Text="" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblGroundAmb" runat="server" ># Ground Ambulances: </asp:Label>
                    </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="txtGroundAmb" runat="server" Width="300px" MaxLength="5" Text="" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblSorintVeh" runat="server" ># Sprint Veh.: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSprintVeh" runat="server" Width="300px" MaxLength="5" Text="" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="100px">
                        <asp:Label ID="lblLevelCareCode" runat="server" >Level Care Code: </asp:Label>
                    </asp:TableCell>
                   <asp:TableCell>
                        <asp:DropDownList ID="ddlLevelCareCode" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblNE" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblNECurCertSrvDt" runat="server" >Cur Cert. Srv Dt: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="rdpNECurCertSrvDt" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblOrigEnrollDt" runat="server" >Orig Enroll Date: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <telerik:RadDatePicker ID="rdpOrigEnrollDt" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblTotalNumAmbVeh" runat="server" >Total No. Ambulatory Vehicles : </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTotalNumAmbVeh" runat="server" Width="300px" MaxLength="5" Text="" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblTotalNumHandVeh" runat="server" >Total No. Handicapped Vehicles : </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTotalNumHandVeh" runat="server" Width="300px" MaxLength="5" Text="" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                       <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblTotalDailyCapAmb" runat="server" >Total Daily Capacity Ambulatory: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTotalDailyCapAmb" runat="server" Width="300px" MaxLength="5" Text=""></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="50px">
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label ID="lblTotalDailyCapHand" runat="server" >Total Daily Capacity Handicapped: </asp:Label>
                    </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="txtTotalDailyCapHand" runat="server" Width="300px" MaxLength="5" Text=""></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        
        
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table ID="tblOperatingRooms" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="LabelNumOperatingRooms" runat="server">Number of Operating Rooms: </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtNumOperatingRooms" runat="server" 
                            MaxLength="5" ToolTip="Number of Operating Rooms" Columns="5">
                            </asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>        
    </asp:Table>
    
</div>
<telerik:RadWindowManager ID="AttachRadWinMan" runat="server" >
    <Windows>
        <telerik:RadWindow ID="AttachRadWin" runat="server" VisibleOnPageLoad="true" VisibleStatusbar="false" Visible="false" />
    </Windows>
</telerik:RadWindowManager>
<p>
    &nbsp;</p>
