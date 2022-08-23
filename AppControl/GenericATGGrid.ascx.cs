using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using ATG.Database;
using Telerik.Web.UI;
using System.Data;

namespace AppControl
{
    public partial class GenericATGGrid : System.Web.UI.UserControl
    {
        // define a delegate for the SelectedIndexChanged event of the grid
        public delegate void GenericGridSelectedIndexChangedHandler(object sender, EventArgs e);
        public delegate void GenericGridNeedDataSourceHandler(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e);
        public delegate void GenericGridItemDataBoundHandler(object sender, GridItemEventArgs e);

        // define the event that will be raised when SelectedIndexChanged occurs
        public event GenericGridSelectedIndexChangedHandler GenericGridSelectedIndexChangedEvent;
        public event GenericGridNeedDataSourceHandler GenericGridNeedDataSourceEvent;
        public event GenericGridItemDataBoundHandler GenericGridItemDataBoundEvent;

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // set the default values for the Grid's properties
                SetDefaultProperties();
            }
        }

        /// <summary>
        /// Executes the delegate defined in either the parent Page or WebControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // execute the delegate defined in either the parent Page or WebControl
            if (GenericGridSelectedIndexChangedEvent != null)
                GenericGridSelectedIndexChangedEvent(sender, e);
        }

        /// <summary>
        /// Executes the delegate defined in either the parent Page or WebControl
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void radGrid1_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            // execute the delegate defined in either the parent Page or WebControl
            if (GenericGridNeedDataSourceEvent != null)
                GenericGridNeedDataSourceEvent(source, e);
        }

        /// <summary>
        /// Executes the delegate defined in either the parent Page or WebControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            // execute the delegate defined in either the parent Page or WebControl
            if (GenericGridItemDataBoundEvent != null)
                GenericGridItemDataBoundEvent(sender, e);
        }


        #endregion

        #region Public

        /// <summary>
        /// Set the default values for the grid's most used properties
        /// </summary>
        public void SetDefaultProperties()
        {
            radGrid1.AutoGenerateColumns = false;
            radGrid1.AllowPaging = false;
            radGrid1.AllowFilteringByColumn = false;
            radGrid1.AllowSorting = false;
            radGrid1.GridLines = GridLines.None;
        }

        public Telerik.Web.UI.RadGrid GridControl
        {
            get { return radGrid1; }
        }

        #endregion
    }
}