//
// Class	:	BO_CheckLogView.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/30/2011 10:15:04 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using ATG.Database;

namespace ATG.BusinessObject
{
	
	/// <summary>
	/// Data access class for the "CHECK_LOG_VIEW" table.
	/// </summary>
	[Serializable]
	public class BO_CheckLogView : BO_CheckLogViewBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_CheckLogView() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        public static BO_CheckLogViews SelectByTypeView( string inTypeView, string inFilter )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            oDatabaseHelper.AddParameter( "@TypeView", inTypeView );
            oDatabaseHelper.AddParameter( "@Filter", inFilter);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_CHECK_LOG_VIEW_SelectByTypeView", ref ExecutionState );
            BO_CheckLogViews BO_CheckLogViews = PopulateObjectsFromReader( dr );
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_CheckLogViews;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
