<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BillingInsertForm.ascx.cs" Inherits="AppControl.BillingInsertForm" %>

<asp:table ID="tblEditForm" runat="server" Width="500px">
    <asp:TableRow>
        <asp:TableCell Width="100px">
            <asp:Literal ID="litTypeBilling" runat="server" Text="Billing Type: " />
        </asp:TableCell>
        <asp:TableCell Width="400px">
            <telerik:RadComboBox ID="cboTypeBilling" runat="server" DataValueField="LOOKUP_VAL" DataTextField="VALDESC" OnClientSelectedIndexChanged="TypeBilling_OnClientSelectedIndexChanged" Width="195px" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litTypeFee" runat="server" Text="Fee Type: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadComboBox ID="cboTypeFee" runat="server" DataValueField="LOOKUP_VAL" DataTextField="VALDESC" OnClientSelectedIndexChanged="TypeFee_OnClientSelectedIndexChanged" Width="395px" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ID="otherlitcell" style="display:none">
            <asp:Literal ID="litComment" runat="server" Text="Other: " />
        </asp:TableCell>
        <asp:TableCell ID="othertxtcell" style="display:none">
            <telerik:RadTextBox ID="txtComment" runat="server" Width="160" MaxLength="255"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litTransactionID" runat="server" Text="Check Number: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadTextBox ID="txtTransactionID" runat="server" Width="160" MaxLength="40"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litAmount" runat="server" Text="Amount: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtAmount" runat="server" Width="160" MaxLength="18" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
    </asp:TableRow>
</asp:table>
<asp:Literal ID="litAppID" runat="server" Text="Application ID: " Visible="false" />
<telerik:RadComboBox ID="cboAppID" runat="server" Visible="false" DataValueField="APPLICATION_ID" DataTextField="APPLICATION_ID" />
<asp:button id="btnInsert" text="Save" runat="server" CommandName="PerformInsert" />
&nbsp;
<asp:button id="btnCancel" text="Cancel" runat="server" causesvalidation="False" commandname="Cancel"></asp:button>
<asp:HiddenField ID="hidApplicationID" runat="server" Value="" />

<telerik:RadCodeBlock ID="BillingInsertRCB" runat="server">
    <script type="text/javascript">

       function TypeFee_OnClientSelectedIndexChanged(item) 
       {
           var cboTypeFee = $find("<%=cboTypeFee.ClientID %>");

           if (cboTypeFee.get_selectedItem().get_value() == '99') //other
           {
               document.getElementById("<%=otherlitcell.ClientID %>").style.display = "";
               document.getElementById("<%=othertxtcell.ClientID %>").style.display = "";
           }
           else
           {
               document.getElementById("<%=otherlitcell.ClientID %>").style.display = "none";
               document.getElementById("<%=othertxtcell.ClientID %>").style.display = "none";
           }
       }
       
       function TypeBilling_OnClientSelectedIndexChanged(item) {
           var cboTypeBilling = $find("<%=cboTypeBilling.ClientID %>");
           var cboTypeFee = $find("<%=cboTypeFee.ClientID %>");

           if (cboTypeBilling.get_selectedItem().get_value() == '3') //refund
           {
                var items = cboTypeFee._itemData; 
                 
                var itemsCount = items.length;

                for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++) {
                    var item = items[itemIndex].value;
                    var itemobj = cboTypeFee.findItemByValue(item);
                    if (itemobj)
                        itemobj.disable();
                }

                var item1 = cboTypeFee.findItemByValue("99");
                if (item1) {
                    item1.enable();
                    item1.select();
                }
                
               
           }
           else {
               document.getElementById("<%=txtComment.ClientID %>").style.display = "none";
               var items = cboTypeFee._itemData;

               var itemsCount = items.length;

               for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++) {
                   var item = items[itemIndex].value;
                   var itemobj = cboTypeFee.findItemByValue(item);
                   if (itemobj)
                       itemobj.enable();
               }
               
           }
       }                       
    </script>
</telerik:RadCodeBlock>