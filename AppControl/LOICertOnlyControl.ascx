<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LOICertOnlyControl.ascx.cs" Inherits="AppControl.LOICertOnlyControl" %>


<center>

<asp:Table ID="tblLOIntent" runat="server" Width="660px">
    <asp:TableRow style="font-size:10.0pt;font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="left" VerticalAlign="Top" Width="160">
            Tracking ID<br /><asp:Label ID="lblTrackID" runat="server" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Center" Width="300px"><asp:Image ID="LetterOfIntentLogo" runat="server" ImageUrl="~/images/DHH_LogoHrzntl.jpg" Height="120px" Width="400" /></asp:TableCell>
        <asp:TableCell HorizontalAlign="right" Width="200"><b>&nbsp;</b><br /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center"  ColumnSpan="3">
            <span style="font-size:16.0pt;font-family: Times New Roman; font-weight: bold">Letter of Intent<br />Application for Medicare Enrollment<br />for Non-Licensed Providers</span>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="3">&nbsp;</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-size:11.0pt;font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" ColumnSpan="3" style="padding-left: 20px;padding-right: 20px;">            
            <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Non- Licensed Medicare Enrolled Providers</span>
            <br /><span style="font-size:11.0pt">
            <ul><li>Community Mental Health Center</li>
            <li>Comprehensive Outpatient Rehabilitative Facility</li>
            <li>Portable X-Ray</li>
            <li>Outpatient Physical Therapy</li></ul>

                Providers that are not licensed by the State of Louisiana and are seeking Medicare 
                enrollment must submit required documents, including a Letter of Intent, to Health 
                Standards Section (HSS). The purpose of the Letter of Intent is to obtain information 
                about the authorized person and general information about the healthcare provider that 
                intends to submit an application for Medicare enrollment.  After submitting a completed 
                Letter of Intent HSS will assign you a secure login.  A secure login is required to 
                access HSS’ Provider Online Processing System (POPS).  Providers may view the status of 
                their enrollment process via POPS.
            </span></p>
            <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Electronic Signature</span>
            <br /><span style="font-size:11.0pt">
                POPS is the standard method for conducting licensing transactions. Non-licensed 
                providers who are seeking certification will receive email notifications regarding 
                the status of their Medicare enrollment application.  A username and password is 
                required to login to POPS. The facility’s authorized administrative person will 
                receive a username and password within 10 days of receipt of the Letter of Intent. 
                The username and password will serve as his/her electronic signature. The authorized 
                person is responsible for maintaining the security of the password.  The authorized 
                person should notify HSS immediately if he/she believes security has been compromised.
            </span></p>
             <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Email Address Requirement</span>
                <br /><span style="font-size:11.0pt">
                POPS will send automatic notifications to the facility as transactions are 
                completed or if additional information is required. Due to the automated 
                environment, it is imperative that the provider enter an email address that 
                will serve as the valid “business” email address. HSS should be notified 
                immediately if this email address is changed.
            </span></p>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<div class="breakAfter" id="printFootP1" runat="server" style="width: 660px;text-align: center">
    <p align="center" style="text-align:center"><b><span style="font-size:8.0pt;font-family:
        Garamond;">500 Laurel Street • Suite 100 (305-1811) • P.O. Box 3767 • Baton
        Rouge, Louisiana 70821-3767<br />Phone #: 225/342-3891 or #225/342-0138 • Fax #:“An Equal Opportunity Employer”</span></b></p><p><b><i>
        <span style="font-size:9.0pt; float: left;text-align:left;">  Application for Medicare Enrollment for Non-Licensed Providers (originated 03/10/2011)</span></i></b> <span style="font-size:9.0pt; float: right;text-align:right;">1</span></p></div>
<asp:Table ID="Table1" runat="server" Width="660px">
    <asp:TableRow style="font-size:11.0pt;font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">            
            <p style="text-align:justify"><span style="font-size:11.0pt">
                A list of documents required for Medicare enrollment can be found on each 
                program’s Welcome Page. Please contact the program desk if you have 
                questions.  Program desk contact information and links to each program’s 
                Welcome Page online at:<br /><br />
                <a href="http://new.dhh.louisiana.gov/index.cfm/directory/category/154" target="_blank">
                http://new.dhh.louisiana.gov/index.cfm/directory/category/154
                </a>
            </span></p><br />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell HorizontalAlign="Left" style="padding-left: 20px;padding-right: 20px;">
            <div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
            </div>
            <asp:Label ID="lblTypeFacility" runat="server" Text="Type Facility:" Width="180" />
            <telerik:RadComboBox ID="listTypeFacility" runat="server" Width="302" ZIndex="9999" />
            <asp:Literal ID="printTypeFacility" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacilityName" runat="server" Text="Name of Facility:" Width="180" />
            <asp:TextBox ID="txtFacilityName" runat="server" Text="" Width="300" MaxLength="50" />
            <asp:Literal ID="printFacilityName" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacilityOpen" runat="server" Text="Date Plan to Open Facility:" Width="180" />
            <telerik:RadDatePicker ID="dtFacilityOpen" runat="server"  Calendar-FastNavigationStep="12" />
            <asp:Literal ID="printFacilityOpen" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblGeoAddress" runat="server" Text="Geographic Address:" Width="180" />
            <asp:TextBox ID="txtGeoAddress" runat="server" Text="" Width="300" MaxLength="100"/>
            <asp:Literal ID="printGeoAddress" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblGeoCity" runat="server" Text="Geographic City:" Width="180" />
            <telerik:RadComboBox ID="listGeoCity" runat="server" ZIndex="9999" AutoPostBack="true" OnSelectedIndexChanged="listGeoCity_SelectedIndexChanged"/>
            <asp:Literal ID="printGeoCity" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblGeoZip" runat="server" Text="Geographic Zip:" Width="180" />
            <telerik:RadComboBox ID="listGeoZip" runat="server" ZIndex="9999" />
            <asp:Literal ID="printGeoZip" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacilityPhone" runat="server" Text="Facility Phone:" Width="180" />
            <telerik:RadMaskedTextBox ID="txtFacilityPhone" runat="server" Mask="(###) ###-####" Columns="13" />
            <asp:Literal ID="printFacilityPhone" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacilityFax" runat="server" Text="Facility Fax:" Width="180" />
            <telerik:RadMaskedTextBox ID="txtFacilityFax" runat="server" Mask="(###) ###-####" Columns="13" />
            <asp:Literal ID="printFacilityFax" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacilityEmail" runat="server" Text="Facility email:" Width="180" />
            <asp:TextBox ID="txtFacilityEmail" runat="server" Text="" MaxLength="100"/>
            <asp:Literal ID="printFacilityEmail" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblMailAddr" runat="server" Text="Mail Address:" Width="180" />
            <asp:TextBox ID="txtMailAddr" runat="server" Text="" Width="300" MaxLength="100" />
            <asp:Literal ID="printMailAddr" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblMailState" runat="server" Text="Mail State:" Width="180" />
            <telerik:RadComboBox ID="listMailState" runat="server" ZIndex="9999" AutoPostBack="true" OnSelectedIndexChanged="listMailState_SelectedIndexChanged" />
            <asp:Literal ID="printMailState" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblMailCity" runat="server" Text="Mail City:" Width="180" />
            <telerik:RadComboBox ID="listMailCity2" runat="server" ZIndex="9999" AutoPostBack="true" OnSelectedIndexChanged="listMailCity2_SelectedIndexChanged" />
            <asp:Literal ID="printMailCity" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblMailZip" runat="server" Text="Mail Zip:" Width="180" />
            <telerik:RadComboBox ID="listMailZip" runat="server" ZIndex="9999" />
            <asp:Literal ID="printMailZip" runat="server" Visible="false" />
            <br />
            <div id="AdminPersInfo" style="margin-left: 5px;margin-top: 10px;padding-left: 5px;font-weight: bold;" runat="server">
                Authorized Administrative Person Information
            </div>
            <asp:Label ID="lblAdminPersName" runat="server" Text="Name:" Width="180" />
            <asp:TextBox ID="txtAdminPersName" runat="server" Text="" MaxLength="50" />
            <asp:Literal ID="printAdminPersName" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblAdminPersTitle" runat="server" Text="Title:" Width="180" />
            <asp:TextBox ID="txtAdminPersTitle" runat="server" Text="" MaxLength="50" />
            <asp:Literal ID="printAdminPersTitle" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblAdminPersEmail" runat="server" Text="Email Address:" Width="180" />
            <asp:TextBox ID="txtAdminPersEmail" runat="server" Text="" MaxLength="100" />
            <asp:Literal ID="printAdminPersEmail" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblConfEmail" runat="server" Text="Confirm Email Address:" Width="180" />
            <asp:TextBox ID="txtConfEmail" runat="server" Text="" MaxLength="100" onPaste="return false;" onMouseDown="DisableRightClick(event)" onKeyDown="return DisableCtrlKey(event)" />
            <br />
            <asp:Label ID="lblAdminPersPhone" runat="server" Text="Phone:" Width="180" />
            <telerik:RadMaskedTextBox ID="txtAdminPersPhone" runat="server" Mask="(###) ###-####" Columns="13" />
            <asp:Literal ID="printAdminPersPhone" runat="server" Visible="false" />
            <br /><br />
            <asp:Label ID="lblFacInFac" runat="server" Text="Is this facility located within another certified provider?"/>&nbsp;&nbsp;
            <asp:RadioButtonList ID="FacInFac" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                     <asp:ListItem ID="FacInFacYes" runat="server" Value="1" Text="Yes"/>
                     <asp:ListItem ID="FacInFacNo" runat="server" Value="0" Text="No" Selected="True"/>
            </asp:RadioButtonList>         
            <asp:Literal ID="printFacInFac" runat="server" Visible="false" />
            <br />
            <asp:Literal ID="litIfYes" runat="server">If yes, complete Provider Name and CCN below:</asp:Literal><br />
            <asp:Label ID="lblFacInFacName" runat="server" Text="Provider Name:" style="display:none" Width="180"/>&nbsp;&nbsp;
            <asp:TextBox ID="txtFacInFacName" runat="server" Text="" MaxLength="50" style="display:none" />
            <asp:Literal ID="printFacInFacName" runat="server" Visible="false" />
            <br />
            <asp:Label ID="lblFacInFacCCN" runat="server" Text="Provider CMS Certification Number (CCN):" style="display:none" />&nbsp;&nbsp;
            <asp:TextBox ID="txtFacInFacCCN" runat="server" Text="" MaxLength="12" style="display:none" />
            <asp:Literal ID="printFacInFacCCN" runat="server" Visible="false" />
            <br /><br />

        </asp:TableCell></asp:TableRow><asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">
            <p style="text-align: left;">
            <span style="font-size:11.0pt; font-weight: bold">Comments</span>
            <asp:TextBox ID="txtTypeService" runat="server" TextMode="MultiLine" Rows="10" Columns="60" Visible="true" MaxLength="500"/>            
            <asp:Label ID="lblTypeService" runat="server" BorderWidth="1" BorderStyle="Solid" Height="180" Width="600" Visible="false" />
            </p>
        </asp:TableCell></asp:TableRow></asp:Table><br />
<div class="breakAfter" id="printFootP2" runat="server" style="width: 660px;text-align: center">
    <p><b><i>
        <span style="font-size:9.0pt; float: left;text-align:left;">Application for Medicare Enrollment for Non-Licensed Providers (originated 03/10/2011)</span></i></b>
        <span style="font-size:9.0pt; float: right;text-align:right;">2</span>
    </p>
</div>
<asp:Table ID="Table2" runat="server" Width="650px">
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;">
             <p style="text-align:justify"><span style="font-size:11.0pt; font-weight: bold">Attestation Statement</span>
                <br /><span style="font-size:11.0pt">
                I certify that the information I have provided is true, correct and supportable
                by documentation to the best of my knowledge.
                <br /><br />
                I have read the “Electronic Signature” information and understand that I will
                receive a username and password from HSS. I understand that I am responsible for
                maintaining the security of the password. I will notify HSS should any of my
                contact information, including business email address, change or I suspect the
                security of my password has been compromised.
            </span></p><br />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: left;font-size: 11.0pt;">
            <asp:Label ID="AuthSigTxt" runat="server" Text="Authorized Person's Signature:" Width="200" />
            <asp:Label ID="AuthSigLine" runat="server" Text="________________________________________________" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: left;font-size: 11.0pt;">
            <asp:Label ID="DateSignedTxt" runat="server" Text="Date Signed:" Width="200" />
            <asp:Label ID="DateSignedLine" runat="server" Text="________________________________________________" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="font-family: Times New Roman;">
        <asp:TableCell style="padding-left: 20px;padding-right: 20px;text-align: left;font-size: 11.0pt;">
            <p style="text-align:left">
                <br /><span style="font-size:11.0pt">
                Please mail <b>Letter of Intent</b> to:<br /><br />
                Health Standards Section<br />
                P.O. Box 3767<br />
                Baton Rouge, LA 70821
            </span></p><br />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div id="printFootP3" runat="server" style="width: 660px;text-align: center">
    <div style="height: 480px"></div>
    <p><b><i>
        <span style="font-size:9.0pt; float: left;text-align:left;">Application for Medicare Enrollment for Non-Licensed Providers (originated 03/10/2011)</span></i></b>
        <span style="font-size:9.0pt; float: right;text-align:right;">3</span>
    </p>
</div>
</center>

<%--    <script type="text/javascript">
        alert("0");

        function OnClientFacInFacClicked() {
        alert("1");
           var count = <%=FacInFac.Items.Count %>;  
        alert("2");
           var id = "<%=FacInFac.ClientID%>";  
        alert("3");
           var checked = false;  
           var selValue;

           for(i=0;i<count;i++)  
           {  
        alert("4");
              var item = document.getElementById(id+"_"+i.toString());
        alert("5");
              if (item)
                  if(item.checked==true)  
                  {  
                     selValue = i;
                     checked = true;  
                     break;  
                  }  
           }
        alert("6");

           if (selValue == 0) { //first item in the list, Yes                           
            document.getElementById("<%=lblFacInFacName.ClientID %>").style.display = '';
            document.getElementById("<%=txtFacInFacName.ClientID %>").style.display = '';
            document.getElementById("<%=lblFacInFacCCN.ClientID %>").style.display = '';
            document.getElementById("<%=txtFacInFacCCN.ClientID %>").style.display = '';
           }
           else
           {
            document.getElementById("<%=lblFacInFacName.ClientID %>").style.display = 'none';
            document.getElementById("<%=txtFacInFacName.ClientID %>").style.display = 'none';
            document.getElementById("<%=lblFacInFacCCN.ClientID %>").style.display = 'none';
            document.getElementById("<%=txtFacInFacCCN.ClientID %>").style.display = 'none';
           } 
        alert("7");

        }
    </script>--%>