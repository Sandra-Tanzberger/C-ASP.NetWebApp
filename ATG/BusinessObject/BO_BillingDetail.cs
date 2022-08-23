//
// Class	:	BO_BillingDetail.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/15/2010 3:59:40 PM
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
	/// Data access class for the "BILLING_DETAILS" table.
	/// </summary>
	[Serializable]
	public class BO_BillingDetail : BO_BillingDetailBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_BillingDetail() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)
        /// <summary>
        /// This method will Update rows in the database using the Batch ID supplied
        /// </summary>
        ///
        /// <returns>True if succeeded</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Shawn Martin		07/19/2011      Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public bool UpdatePivByBatchID( decimal inBatchID, string inPivNum )
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_billingDetailID' as parameter 'BillingDetailID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@BatchID", inBatchID );

            // Pass the value of '_billingID' as parameter 'BillingID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@PivNum", inPivNum );

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            oDatabaseHelper.ExecuteScalar( "ATG_BILLING_DETAILS_UpdatePivByBatchID", ref ExecutionState );
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }

        public static BO_BillingDetails SelectByTypeBilling(decimal billingDetailsID)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            oDatabaseHelper.AddParameter("@BillingDetailID", billingDetailsID);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("GEN_BILLING_DETAILS_SelectByPrimaryKey", ref ExecutionState);
            BO_BillingDetails BO_BillingDetails = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BillingDetails;

        }
        #endregion
		
		#region Methods (Private)



        #endregion

	}
	
}
