<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestForAccessControl.ascx.cs" Inherits="AppControl.RequestForAccessControl" %>

<center>
<asp:Table ID="tblLOIntent" runat="server" Width="660px">
    <asp:TableRow style="font-size:10.0pt;font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="left" VerticalAlign="Top" Width="160">
            Tracking ID<br /><asp:Label ID="lblTrackID" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-size:10.0pt;font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Center"><asp:Image ID="LetterOfIntentLogo" runat="server" ImageUrl="~/images/DHH_LogoHrzntl.jpg" Height="90px"/></asp:TableCell>
        <asp:TableCell HorizontalAlign="Center" Width="250px">
            <span style="font-size:14pt;font-family: Times New Roman; font-weight: bold">Health Standards Section<br />POPS Access Request Form</span>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">&nbsp;</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-size:11.0pt;font-family: Times New Roman;">
        <asp:TableCell ColumnSpan="3" style="padding-left: 20px;padding-right: 20px;">
            <p style="text-align:justify"><span style="font-size:11.0pt">
                I am requesting access to Health Standards Section’s Provider Online Processing System (POPS) 
                to conduct licensing business transactions for the following facility: 
            </span></p>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="Table1" runat="server" Width="650px" BorderWidth="0" GridLines="None">
    <asp:TableRow style="font-family: Times New Roman;" VerticalAlign="Top">
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
            </div>
        </asp:TableCell>
    </asp:TableRow>    
    <asp:TableRow style="font-family: Times New Roman;" VerticalAlign="Top">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblStateID" runat="server" Text="Enter State ID:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left"  Width="500">
            <asp:Literal ID="printStateID" runat="server" Text="" />
            <asp:TextBox ID="txtSrchStateID" runat="server" Text="" MaxLength="9" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSrchStateID" runat="server" Text="Locate Provider" CommandName="FindProvider" OnCommand="btnSrchStateID_Click"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;" Width="150">
            <asp:Label ID="lblFacilityName" runat="server" Text="Name of Facility:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left"  Width="500">
            <asp:Literal ID="printFacilityName" runat="server" Visible="true" Text="" />&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblGeoAddress" runat="server" Text="Geographic Address:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:Literal ID="printGeoAddress" runat="server" Visible="true"  Text=""/>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblGeoCity" runat="server" Text="Geographic City:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:Literal ID="printGeoCity" runat="server" Visible="true"  Text=""/>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblGeoZip" runat="server" Text="Geographic Zip:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:Literal ID="printGeoZip" runat="server" Visible="true"  Text=""/>&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblFacilityEmail" runat="server" Text="Business Email:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:TextBox ID="txtFacilityEmail" runat="server" Text="" MaxLength="100" Width="300" />
            <asp:Literal ID="printFacilityEmail" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblFacilityPhone" runat="server" Text="Business Phone:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <telerik:RadMaskedTextBox ID="txtFacilityPhone" runat="server" Mask="(###) ###-####" Columns="13" />            
            <asp:Literal ID="printFacilityPhone" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <div id="AdminPersInfo" style="margin-left: 5px;margin-top: 10px;padding-left: 5px;font-weight: bold;" runat="server">
                Authorized Administrative Person Information
            </div>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblAdminPersName" runat="server" Text="Name:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:TextBox ID="txtAdminPersName" runat="server" Text="" MaxLength="50" Width="300"/>
            <asp:Literal ID="printAdminPersName" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblAdminPersTitle" runat="server" Text="Title:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:TextBox ID="txtAdminPersTitle" runat="server" Text="" MaxLength="50" Width="300"/>
            <asp:Literal ID="printAdminPersTitle" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblAdminPersEmail" runat="server" Text="Email Address:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:TextBox ID="txtAdminPersEmail" runat="server" Text="" MaxLength="100" Width="300"/>
            <asp:Literal ID="printAdminPersEmail" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblConfEmail" runat="server" Text="Confirm Email Address:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <asp:TextBox ID="txtConfEmail" runat="server" Text="" MaxLength="100" Width="300" onPaste="return false;" onMouseDown="DisableRightClick(event)" onKeyDown="return DisableCtrlKey(event)" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <asp:Label ID="lblAdminPersPhone" runat="server" Text="Phone:" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" >
            <telerik:RadMaskedTextBox ID="txtAdminPersPhone" runat="server" Mask="(###) ###-####" Columns="13" />            
            <asp:Literal ID="printAdminPersPhone" runat="server" Visible="true" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:Table ID="Table2" runat="server" Width="650px">
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">
             <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Attestation Statement</span>
                <br /><span style="font-size:11.0pt">
                I certify that the information I have provided is true, correct and supportable
                by documentation to the best of my knowledge.
                <br /><br />
                I have read the “Electronic Signature” information and understand that I will receive login 
                information from HSS for the purpose of conducting licensure transactions online. 
                I understand that I am responsible for maintaining the security of the password(s). I will notify 
                HSS should any of my contact information, including business email address, change or I suspect 
                the security of my facility’s login information has been compromised.
            </span></p>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: center;font-size: 11.0pt;">
            <asp:Label ID="lblAuthName" runat="server" Text="Authorized Person's Name:" Width="200" />
            <asp:Label ID="lblAuthNameLine" runat="server" Text="________________________________________________" />
            <asp:Label ID="lblPrintOrType" runat="server" Text="(print or type)" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: center;font-size: 11.0pt;">
            <asp:Label ID="lblAuthPerTitle" runat="server" Text="Authorized Person's Title:" Width="200" />
            <asp:Label ID="lblAuthPerTitleLine" runat="server" Text="________________________________________________" />
            <br /><br />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: center;font-size: 11.0pt;">
            <asp:Label ID="lblSignatureTxt" runat="server" Text="Signature: " />
            <asp:Label ID="lblSignatureLine" runat="server" Text="__________________________________________    " />
            <asp:Label ID="lblDateSignedTxt" runat="server" Text="Date: " />
            <asp:Label ID="lblDateSignedLine" runat="server" Text="_______________" />
            <br /><br />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div class="breakAfter" id="printFootP1" runat="server" style="width: 660px;text-align: center">
    <p align="center" style="text-align:center"><b><span style="font-size:8.0pt;font-family:
        Garamond;">500 Laurel Street • Suite 100 (305-1811) • P.O. Box 3767 • Baton
        Rouge, Louisiana 70821-3767<br />Phone #: 225/342-3891 or #225/342-0138 • Fax #:
        225/342-5292 • WWW.DHH.LA.GOV<br />“An Equal Opportunity Employer”</span></b></p>
    <p><b><i>
        <span style="font-size:9.0pt; float: left;text-align:left;">POPS Access Request Form(12/13/10)</span></i></b>
        <span style="font-size:9.0pt; float: right;text-align:right;">1</span></p>
</div>
<asp:Table ID="Table4" runat="server" Width="660px">
    <asp:TableRow style="font-size:11.0pt;font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">
            <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Electronic Signature</span>
            <br /><span style="font-size:11.0pt">
            POPS is the standard method for conducting licensing business transactions, such as license 
            renewal, address change, Key Personnel Changes, unit/bed increase or decrease, and Change of 
            Ownership.
            <br /><br />
            A username and password is required to login to POPS. The facility’s authorized administrative 
            person will receive a username and password within 10 days of receipt of this request. <b>The 
            username and password will serve as his/her electronic signature.</b> The authorized person is 
            responsible for maintaining the security of the password.  The authorized person should notify 
            HSS immediately if he/she believes security has been compromised.
            </span></p>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">
             <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Email Address Requirement</span>
                <br /><span style="font-size:11.0pt">
                POPS will send automatic notifications to the facility as transactions are completed
                or if additional information is required. If licensure is granted, the provider
                will be notified via email to renew online. Due to the automated environment,
                it is imperative that the provider enter an email address that will serve as
                the valid “business” email address. HSS should be notified immediately if this
                email address is changed.
            </span></p><br />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="Table5" runat="server" Width="650px">
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: left;font-size: 11.0pt;">
            <p style="text-align:left">
                <br /><span style="font-size:11.0pt">
                Please mail request form to:<br /><br />
                Health Standards Section<br />
                POPS Request<br />
                P.O. Box 3767<br />
                Baton Rouge, LA 70821
            </span></p><br />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Table ID="printSpaceTable" runat="server" Width="650px" Height="375">
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: left;font-size: 11.0pt;">
            &nbsp;
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div id="printFootP2" runat="server" style="width: 660px;text-align: center">
    <p align="center" style="text-align:center"><b><span style="font-size:8.0pt;font-family:
        Garamond;">500 Laurel Street • Suite 100 (305-1811) • P.O. Box 3767 • Baton
        Rouge, Louisiana 70821-3767<br />Phone #: 225/342-3891 or #225/342-0138 • Fax #:
        225/342-5292 • WWW.DHH.LA.GOV<br />“An Equal Opportunity Employer”</span></b></p>
    <p><b><i>
        <span style="font-size:9.0pt; float: left;text-align:left;">POPS Access Request Form(12/13/10)</span></i></b>
        <span style="font-size:9.0pt; float: right;text-align:right;">2</span></p>
</div>
