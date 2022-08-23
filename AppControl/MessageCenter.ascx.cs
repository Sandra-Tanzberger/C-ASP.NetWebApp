using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class MessageCenter : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            BO_Messages prvdrMsgs = BO_Message.SelectAll();

            MsgsGrid2.DataSource = prvdrMsgs;
            //MsgsGrid2.AllowFilteringByColumn = showFilter;
            //MsgsGrid2.AutoGenerateColumns = false;
            //MsgsGrid2.AllowPaging = true;
            //MsgsGrid2.AllowSorting = true;
            //MsgsGrid2.GridLines = GridLines.Both;
            //MsgsGrid2.AllowFilteringByColumn = true;
            
            RadPane _mainPane = (RadPane) Page.FindControlRecursive( "LicMainPane" );

            if ( _mainPane != null )
            {
                int ContentHeight = (int) _mainPane.Height.Value;
                int ContentWidth = (int) _mainPane.Width.Value;
                MsgsGrid2.Height = Unit.Pixel( ContentHeight - 1 );
                MsgsGrid2.Width = Unit.Pixel( ContentWidth - 1 );
            }
            //int ContentHeight = (int) LicSplitter.Height.Value;
            //int LicNavMenuHeight = (int) LicNavMenu.Height.Value;

            MsgsGrid2.DataBind();

        }

        public bool showFilter
        {
            get
            {
                return this.ViewState["showFilter"] == null ? false : (bool) this.ViewState["showFilter"];
            }
            set
            {
                this.ViewState["showFilter"] = value;
            }
        }
    }
}