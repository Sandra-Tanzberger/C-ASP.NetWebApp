<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="ListLicenceLetter.ascx.cs" Inherits="AppControl.ListLicenceLetter" %>

<telerik:RadAjaxPanel ID="gridPanel" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>

    <asp:SqlDataSource ID="grdLetterDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SQL_AppConString %>" 
        SelectCommand="SELECT PROVIDERS.FACILITY_NAME + '-' + PROVIDERS.GEOGRAPHICAL_CITY NAMECITY, PROVIDERS.STATE_ID, PROVIDERS.LICENSURE_EXPIRATION_DATE,
 LK1.VALDESC + ' ' + ISNULL(LK3.VALDESC, '') STATUSCODE, SUBSTRING(LK2.VALDESC, 1, 1) SEND_TYPE, 
 MESSAGES.MESSAGE_SUBJECT, MESSAGES.MESSAGE_TEXT, MESSAGES.MESSAGE_PRINT_DATE, 
 MESSAGES.MESSAGE_DATE, MESSAGES.MESSAGE_ID, MESSAGES.MESSAGE_FAILURE_CODE, MESSAGES.APPLICATION_ID, BUSINESS_PROCESSES.BUSINESS_PROCESS_NAME
FROM (MESSAGES LEFT JOIN PROVIDERS ON MESSAGES.POPS_INT_ID = PROVIDERS.POPS_INT_ID) 
LEFT JOIN LOOKUP_VALUES LK1 ON (LK1.LOOKUP_KEY = 'MESSAGE_DELIVERY_STATUS' AND MESSAGES.MESSAGE_DELIVERY_STATUS = LK1.LOOKUP_VAL)
LEFT JOIN LOOKUP_VALUES LK2 ON (LK2.LOOKUP_KEY = 'MESSAGE_SEND_TYPE' AND MESSAGES.MESSAGE_SEND_TYPE = LK2.LOOKUP_VAL)
LEFT JOIN LOOKUP_VALUES LK3 ON (LK3.LOOKUP_KEY = 'MESSAGE_FAILURE_CODE' AND MESSAGES.MESSAGE_FAILURE_CODE = LK3.LOOKUP_VAL)
left join APPLICATIONS on APPLICATIONS.APPLICATION_ID = MESSAGES.APPLICATION_ID
left join BUSINESS_PROCESSES on BUSINESS_PROCESSES.BUSINESS_PROCESS_ID = APPLICATIONS.BUSINESS_PROCESS_ID
  WHERE MESSAGE_DIRECTION = '2' and APPLICATION_STATUS not in (@WhereText)
ORDER BY REFERENCE_ID">
        <SelectParameters>
            <asp:Parameter Name="WhereText" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
 
     <telerik:RadGrid ID="grdLetters" runat="server" EnableViewState="true" 
                     DataSourceID="grdLetterDataSource"
                     OnItemCommand="grdLetters_ItemCommand"
                     OnPreRender="grdLetters_PreRender" Visible="true" 
                     AutoGenerateColumns="False" AllowMultiRowSelection="true">
        <MasterTableView EditMode="InPlace" runat="server" DataKeyNames="MESSAGE_ID" 
            DataSourceID="grdLetterDataSource" CommandItemDisplay="Top">
            <CommandItemTemplate>
                <asp:LinkButton ID="btnPrintSelected" runat="server" CommandName="CustomPrint" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Print.gif" />
                    Print Selected Letters
                </asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btnResend" runat="server" CommandName="CustomReSend" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/mail.gif" />
                    Resend Selected Letters
                </asp:LinkButton>            
            </CommandItemTemplate>            
            <Columns>                            
                <telerik:GridBoundColumn DataField="MESSAGE_ID" DataType="System.Decimal" 
                    HeaderText="Msg ID" ReadOnly="True" visible="False"  SortExpression="MESSAGE_ID" UniqueName="MESSAGE_ID" AllowFiltering="False">
                </telerik:GridBoundColumn>
                <telerik:GridClientSelectColumn UniqueName="CheckboxSelectColumn"><HeaderStyle Width="5%" /></telerik:GridClientSelectColumn>    
                <telerik:GridBoundColumn ReadOnly="True" DataField="STATE_ID" HeaderText="State ID" 
                    SortExpression="STATE_ID" UniqueName="STATE_ID" AllowFiltering="true" FilterControlWidth="40px"><HeaderStyle Width="10%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ReadOnly="True" DataField="NAMECITY" 
                    HeaderText="Name" SortExpression="NAMECITY" UniqueName="NAMECITY" AllowFiltering="False"><HeaderStyle Width="18%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ReadOnly="True" DataField="MESSAGE_DATE" 
                    HeaderText="Date" SortExpression="MESSAGE_DATE" 
                    UniqueName="MESSAGE_DATE" DataType="System.DateTime" DataFormatString="{0:MM/dd/yy}" AllowFiltering="False"><HeaderStyle Width="8%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MESSAGE_SUBJECT" HeaderText="Subject" 
                    SortExpression="MESSAGE_SUBJECT" UniqueName="MESSAGE_SUBJECT" AllowFiltering="false"><HeaderStyle Width="18%" /><%--DataFormatString="<nobr>{0}</nobr>"--%>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ReadOnly="True" DataField="SEND_TYPE" 
                    HeaderText="Type" SortExpression="SEND_TYPE" 
                    UniqueName="SEND_TYPE" AllowFiltering="False"><HeaderStyle Width="5%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ReadOnly="True" DataField="STATUSCODE" 
                    HeaderText="Status" SortExpression="STATUSCODE" 
                    UniqueName="STATUSCODE" AllowFiltering="true" FilterControlWidth="30px"><HeaderStyle Width="10%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ReadOnly="True" DataField="MESSAGE_PRINT_DATE" 
                    HeaderText="Printed" SortExpression="MESSAGE_PRINT_DATE" 
                    UniqueName="MESSAGE_PRINT_DATE" DataType="System.DateTime" DataFormatString="{0:MM/dd/yy}" AllowFiltering="true" FilterControlWidth="30px"><HeaderStyle Width="9%" />
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn ReadOnly="True" DataField="BUSINESS_PROCESS_NAME" 
                    HeaderText="Process" SortExpression="BUSINESS_PROCESS_NAME" 
                    UniqueName="BUSINESS_PROCESS_NAME" AllowFiltering="true" FilterControlWidth="50px"><HeaderStyle Width="12%" />
                </telerik:GridBoundColumn>                                
            </Columns>
        </MasterTableView>
         <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">
             <selecting allowrowselect="True" />
             <Resizing AllowColumnResize="True" />
         </ClientSettings>
    </telerik:RadGrid>
</telerik:RadAjaxPanel>