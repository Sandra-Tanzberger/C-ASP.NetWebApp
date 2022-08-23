<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="LoginLetterPrint.aspx.cs" Inherits="DHH.LoginLetterPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>

    <style media="all" type="text/css" >
        html {color:#000; background:#FFF;}

        /*reset*/        
        body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,code,form,fieldset,legend,input,textarea,p,blockquote,th,td 
        {
        	margin:0; 
        	padding:0;
        }

        .letter 
        {
            width: 7.0in;
            height: 9.5in;
            overflow: hidden;
        }
        .letterHeader 
	    {
	    	width: 95%;
		    height: 1.5in;
		    overflow: hidden;
	    }
	    .letterBody
	    {
		    clear: both;
		    width: 95%;
		    height: 7.3in;
		    overflow: hidden;
		    font-family: Times New Roman; 
		    font-size: 12pt;
	    }
	    .letterFooter
	    {
	    	clear: both;
	    	width: 95%;
	    	height: 0.5in;
	    	overflow: hidden;
	    	font-family: Garamond; 
	    	font-size: 10pt; 
	    	color: #C0C0C0; 
	    	text-align: center; 
	    	font-weight: bold;
	    	height: 30px;
	    }
    </style>
    
    <style media="print" type="text/css" >
	    *  
	    {
		    color: #000 !important; 
	        background: white !important;
	    }
    	
	    .noShow
	    {
		    visibility: hidden;
		    display: none;
	    }
    </style>
</head>
<body>
    <form id="PrintForm" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

        <div class="noShow" >
            <a href="javascript:window.print()">Print Letter</a>
        </div>
        
        <div class="letter">
            <div class="letterHeader">
                <div style="float:left">
                    <img src="../images/DHH_LogoHrzntl.jpg" alt="logo" height="120px"/>
                </div>
                <div style="float:right; font-size: 16pt; font-weight:bold;">
                    <br />
                    Health Standards Section
                    <br />
                    POPS Confidential Memo
                </div>
                <br style="clear:both;"/>
            </div>            
            
            <div class="letterBody">
                <div >
                    <div style="float: left; width: 90px;">Date:</div>
                    <div style="float: left;"><asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label></div>
                </div>
                
                <br style="clear:both;"/>
                <br />
                
                <div>
                    <div style="float: left; width: 90px;">To:</div>
                    <div style="float: left;" >
                        <asp:Label ID="lblAdministrator" runat="server" Text="Administrator"></asp:Label>
                        <br/>
                        <asp:Label ID="lblFacName" runat="server" Text="Facility Name"></asp:Label>
                        <br/>
                        <asp:Label ID="lblFacStreet" runat="server" Text="Facility Mail Address"></asp:Label>
                        <br/>
                        <asp:Label ID="lblCityStateZip" runat="server" Text="City, ST, Zip"></asp:Label>
                     </div>
                </div>
                
                <br style="clear:both;"/>
                <br />
                
                <div>
                    <div style="float: left; width: 90px;">
                        From: 
                    </div>
                    <div style="float: left;">
                        Health Standards Section
                        <br/>
                        P.O. Box 3767
                        <br />
                        Baton Rouge, LA 70821-3767
                    </div>
                </div>
                
                <br style="clear:both;"/>
                <br />

                <div>
                    <div style="float: left; width: 90px;">
                        Subject: 
                    </div>
                    <div style="float: left;">
                        POPS State (Login) ID &amp; Passwords
                    </div>
                </div>
                
                <br style="clear:both;"/>
                <br />
                
                <div>
                    This memo is notification of your facility's State ID, or Login ID, and 
                    passwords for conducting State licensing business via Health Standards 
                    Section's (HSS) Provider Online Processing System (POPS). The State ID and 
                    Authorized password will serve as the authorized person's electronic signature. 
                    The authorized person is responsible for maintaining the security of the password. 
                </div>

                <br style="clear:both;"/>
                
                <div>
                    <div style="float: left; width: 195px;">
                        Facility State ID:
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblStateID" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br style="clear:both;"/>
                    <div style="float: left; width: 195px;">
                        Authorized Person:
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblAuthPerson" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br style="clear:both;"/>
                    <div style="float: left; width: 195px;">
                        Title:
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br style="clear:both;"/>
                    <br/>
                    <div style="float: left; width: 195px;">
                        Authorized Password:
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblAuthPwd" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br style="clear:both;"/>
                    <div style="float: left; width: 195px;">
                        Clerk Password:
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblPwd" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                
                <br style="clear:both;"/>
                <br />
                
                <div>
                    Keep this information confidential. If you believe that your facility’s password 
                    security has been compromised contact the Program Desk immediately. <b>This Login 
                    ID and password will automatically be deactivated if not used within 45 days.</b>
                </div>

                <br style="clear:both;"/>
                
                <div>
                    Please notify Health Standards Section when there is a change in the 
                    administrator or authorized person(s).
                </div>

                <br style="clear:both;"/>
                
                <div>
                    Visit HSS Internet home page for a complete listing of programs, contact 
                    numbers and to access POPS web site: 
                    <br />
                    <br />
                    http://dhh.louisiana.gov/healthstandards
                </div>
                <br style="clear:both;"/>
            </div>
            
            <div class="letterFooter">
                N. 5th St, Second Floor&nbsp;&#8226;&nbsp;(70802)&nbsp;&#8226;&nbsp;P.O. Box 3767&nbsp;&#8226;&nbsp;Baton Rouge, Louisiana 70821-3767
                <br/>
                Phone #: 225/342-0138&nbsp;&#8226;&nbsp;Fax #: 225/342-5073&nbsp;&#8226;&nbsp;www.dhh.la.gov/healthstandards
                <br/>
                &quot;An Equal Opportunity Employer&quot;
                <br style="clear:both;"/>
            </div>

        </div>    
    </form>    
</body>
</html>

