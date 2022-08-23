using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace DHH
{
    public partial class LettersPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Collections.Hashtable target = null;
            target = (System.Collections.Hashtable)Session["MessagesChecked"];

            Literal ltrl = new Literal();
            ltrl.Text = @"<div>";
            foreach (string msgid in target.Keys)
            {
                object isChecked = null;
                isChecked = target[msgid];

                //Is message checked to be printed?
                if (isChecked != null)
                {
                    if ((bool)isChecked == true)
                    {
                        //Get message and address data and build html
                        BO_MessagePrimaryKey bomkey = new BO_MessagePrimaryKey(Convert.ToDecimal(msgid));
                        BO_Message bom = BO_Message.SelectOne(bomkey);
                        bom.MessagePrintDate = DateTime.Today;

                        BO_ProviderPrimaryKey boppkey = new BO_ProviderPrimaryKey(bom.PopsIntID);
                        BO_Provider boprov = BO_Provider.SelectOne(boppkey);

                        ltrl.Text = ltrl.Text + @"<DIV class=""breakAfter"">";
                        if (bom.MessageSendType == "2") // electronic, then add address and signature blocks
                        {
                            ltrl.Text = ltrl.Text + @"<br/><br/>" + boprov.FacilityName + "<br/>" + boprov.GeographicalStreet;

                            if (boprov.GeographicalStreetAddr2 != null)
                            {
                                ltrl.Text = ltrl.Text + @"<br/>" + boprov.GeographicalStreetAddr2;
                            }

                            ltrl.Text = ltrl.Text + @"<br/>" + boprov.GeographicalCity + ", " + boprov.GeographicalState + " " + boprov.GeographicalZip;
                        }

                        ltrl.Text = ltrl.Text + @"<br/>" + bom.MessageDate + "<br/><br/>" + bom.MessageText;

                        if (bom.MessageSendType == "2") // electronic, then add address and signature blocks
                        {
                            ltrl.Text = ltrl.Text + @"<br/><br/>DHH/Health Standards Section";
                        }

                        ltrl.Text = ltrl.Text + @"</DIV>";

                        bom.Update();
                    }
                }
            }
            ltrl.Text = ltrl.Text + @"</div>";

            LoadMyUserControl("Letters",
                                ltrl,
                                DocPrintPanel);
        }

        private void LoadMyUserControl(string CtrlName, Control CtrlToLoad, Control parent)
        {
            parent.Controls.Clear();
            parent.Controls.Add(CtrlToLoad);
            CtrlToLoad.ID = CtrlName;
        }
    }
}
