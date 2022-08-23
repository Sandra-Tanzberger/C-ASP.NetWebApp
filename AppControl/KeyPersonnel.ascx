<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeyPersonnel.ascx.cs" Inherits="AppControl.KeyPersonnel" %>

<telerik:RadAjaxManagerProxy ID="KeyPersonnelRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="chkKeyPersChangeNo">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rapKeyPersonnel" LoadingPanelID="KeyPersLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="chkKeyPersChangeYes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rapKeyPersonnel" LoadingPanelID="KeyPersLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<asp:Table ID="tblPersonnelChangeForm" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="labelPersChange">Has there been a change in Key Personnel since the last license application?</asp:Label>
            <asp:RadioButton ID="chkKeyPersChangeNo" runat="server" GroupName="PersChange" Text="No" AutoPostBack="true" OnCheckedChanged="PersChange_CheckedChanged" />
            <asp:RadioButton ID="chkKeyPersChangeYes" runat="server" GroupName="PersChange" Text="Yes" AutoPostBack="true" OnCheckedChanged="PersChange_CheckedChanged" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<telerik:RadAjaxLoadingPanel ID="KeyPersLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="rapKeyPersonnel" runat="server" Width="98%" BorderColor="Black"
                      BorderStyle="Solid" BorderWidth="0px" CssClass="LicSectionContainer">
                      
       <asp:Table id="tblPrimaryFACAdmin" BorderWidth="0" runat="server" GridLines="None">
            <asp:TableRow>
               <asp:TableCell><asp:RadioButton ID="rbKPAdministrator" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell>    
                    <atg:SliderDiv UserOverride="true" ID="sldrKPAdministrator" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button" >
                        <asp:panel CssClass="LicensePanel" id="pnlKPAdministrator" runat="server">
                        </asp:panel>
                    </atg:SliderDiv>  
                </asp:TableCell> 
            </asp:TableRow>  
            
            
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPAltAdministrator" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell>    
                    <atg:SliderDiv UserOverride="true" ID="sldrKPAltAdministrator" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPAltAdministrator" runat="server">
                        </asp:panel>
                    </atg:SliderDiv> 
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPDON" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell>  
                <atg:SliderDiv UserOverride="true" ID="sldrKPDON" runat="server" 
                               ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                               Expanded="false" TitleText="" LinkDisplayType="Button">
                    <asp:panel CssClass="LicensePanel" id="pnlKPDON" runat="server">
                    </asp:panel>
                </atg:SliderDiv>  
             </asp:TableCell>
            </asp:TableRow>
              
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPAltDON" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell>  
                    <atg:SliderDiv UserOverride="true" ID="sldrKPAltDON" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPAltDON" runat="server">
                        </asp:panel>
                    </atg:SliderDiv>  
             </asp:TableCell>
            </asp:TableRow>
              
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPDirector" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell> 
                    <atg:SliderDiv UserOverride="true" ID="sldrKPDirector" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPDirector" runat="server">
                        </asp:panel>
                    </atg:SliderDiv>    
               </asp:TableCell>
            </asp:TableRow>   
                    
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPMedDirector" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell> 
                    <atg:SliderDiv UserOverride="true" ID="sldrKPMedDirector" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPMedDirector" runat="server">
                        </asp:panel>
                    </atg:SliderDiv>    
               </asp:TableCell>
            </asp:TableRow>
                    
            <asp:TableRow>
             <asp:TableCell><asp:RadioButton ID="rbKPFacilityRn" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
               <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPFacilityRn" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPFacilityRn" runat="server">
                        </asp:panel>
                    </atg:SliderDiv>  
              </asp:TableCell>
            </asp:TableRow>
    
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPRN" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPRN" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPRN" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPPhysAsst" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPPhysAsst" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPPhysAsst" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPLPN" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPLPN" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPLPN" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPCD" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPCD" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPCD" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPHM" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPHM" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPHM" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:RadioButton ID="rbKPRNC" GroupName="RDPrimaryFACAdmin" runat="server" /></asp:TableCell> 
                <asp:TableCell>
                    <atg:SliderDiv UserOverride="true" ID="sldrKPRNC" runat="server" 
                                   ExpandMethod="Link" LinkText="View" AdditionalTitleText="" 
                                   Expanded="false" TitleText="" LinkDisplayType="Button">
                        <asp:panel CssClass="LicensePanel" id="pnlKPRNC" runat="server" />
                    </atg:SliderDiv>  
                </asp:TableCell>
            </asp:TableRow>
    </asp:Table>  
</telerik:RadAjaxPanel>

