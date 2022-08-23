//
// Class	:	BO_Billing.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 12:38:19 PM
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
    /// Data access class for the "BILLING" table.
    /// </summary>
    [Serializable]
    public class BO_Billing : BO_BillingBase
    {
        public class BO_BillingGridFields
        {
            public const string ApplicationType = "APP_TYPE";
            public const string ApplicationStartDate = "APP_STATE_DATE";
        
        }

        #region Class Level Variables

        private string applicationType = null;
        private DateTime? applicationStartDate= null;
		
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

        public BO_Billing()
            : base()
        {
        }

        #endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
        /// 

        public string ApplicationType
        {
            set { applicationType = value; }
            get { return applicationType; }
        }

        public DateTime? ApplicationStartDate
        {
            set { applicationStartDate = value; }
            get { return applicationStartDate; }
        }

        #endregion

        #region Methods (Public)

        /// <summary>
        /// This method will create or update a billing record for the given provider and business process
        /// </summary>
        ///
        /// <param name="pk" type="ApplicationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Christie Swoboda			04/25/2011		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///

        public static BO_Billing SelectPreviousBillingRecord(BO_ProviderPrimaryKey pops, BO_ApplicationPrimaryKey app)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Billing obj = null;

            oDatabaseHelper.AddParameter("@PopsIntID", pops.PopsIntID);
            oDatabaseHelper.AddParameter("@ApplicationID", app.ApplicationID);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_BILLING_PreviousBalance", ref ExecutionState);
            obj = new BO_Billing();
            while (dr.Read())
            {
                PopulateObjectFromReader(obj, dr);
            }
            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }
        public static void NewBillingRecordByForeignKeyApplicationID( BO_ApplicationPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_BILLING_NewBillingRecord", ref ExecutionState );
            dr.Close();
            oDatabaseHelper.Dispose();
        }

        public static BO_Billings SelectAllLinkedByForeignKeyPopsIntID(decimal billingDetailsID)
        {
            BO_Billing bo_Billing = new BO_Billing();
            bo_Billing.BO_BillingDetailsBillingID = BO_BillingDetail.SelectByTypeBilling(billingDetailsID);
            BO_Billings obj = new BO_Billings();
            obj.Add(bo_Billing);
            return obj;
        }

        public static BO_Billings SelectAllUnlinkedByForeignKeyPopsIntID( BO_ProviderPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Billings obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_BILLING_SelectAllUnlinkedByForeignKeyPopsIntID", ref ExecutionState );
            obj = new BO_Billings();
            obj = BO_Billing.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr );

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        public static BO_Billings SelectAllUnlinkedInitialLicenses(string ProgramID)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Billings obj = null;

            oDatabaseHelper.AddParameter("@ProgramID", ProgramID, ParameterDirection.Input);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_BILLING_SelectAllUnlinkedInitialLicenses", ref ExecutionState);
            obj = new BO_Billings();
            obj = BO_Billing.PopulateObjectsFromReaderWithAllChildrenApplicationID(dr);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        public static BO_Billings PopulateObjectsFromReaderWithAllChildrenApplicationID( IDataReader rdr )
        {
            BO_Billings tmpBillings = new BO_Billings();

            while ( rdr.Read() )
            {
                BO_Billing tmpBilling = new BO_Billing();

                //Load base class fields
                PopulateObjectFromReader( tmpBilling, rdr );

                //Load detail Records
                //BO_BillingPrimaryKey tmpPK = new BO_BillingPrimaryKey( obj.PopsIntID, obj.BillingID, obj.ApplicationID );
                tmpBilling.BO_BillingDetailsBillingID = BO_BillingDetail.SelectByField( BO_BillingDetailFields.BillingID, tmpBilling.BillingID );

                tmpBillings.Add( tmpBilling );
            }

            return tmpBillings;
        }

        public static BO_Billing SelectOneWithAllChildren( BO_BillingPrimaryKey inBilllingPK )
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = inBilllingPK.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "GEN_BILLING_SelectbyPrimaryKey", ref ExecutionState );
            
            if ( dr.Read() )
            {
                BO_Billing obj = new BO_Billing();
                PopulateObjectFromReader( obj, dr );
                
                //Load detail Records
                //BO_BillingPrimaryKey tmpPK = new BO_BillingPrimaryKey( obj.PopsIntID, obj.BillingID, obj.ApplicationID );
                obj.BO_BillingDetailsBillingID = BO_BillingDetail.SelectByField( BO_BillingDetailFields.BillingID, obj.BillingID );
                
                dr.Close();
                oDatabaseHelper.Dispose();
                return obj;
            }
            else
            {
                dr.Close();
                oDatabaseHelper.Dispose();
                return null;
            }

        }

        //selects all billing records by popsintid with application type and start_date and all billing_detail records
        public static BO_Billings SelectAllByForeignKeyPopsIntIDWithAllChildren(BO_ProviderPrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@PopsIntID", pk.PopsIntID, System.Data.ParameterDirection.Input);
            
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader rdr = oDatabaseHelper.ExecuteReader( "ATG_BILLING_SelectAllByForeignKeyPopsIntIDWithApplication", ref ExecutionState );

            BO_Billings boBillings = new BO_Billings();

            while (rdr.Read())
            {
                BO_Billing boBilling = new BO_Billing();

                //Load base class fields
                PopulateObjectFromReaderWithApplication(boBilling, rdr);

                //Load detail Records
                boBilling.BO_BillingDetailsBillingID = BO_BillingDetail.SelectByField(BO_BillingDetailFields.BillingID, boBilling.BillingID);

                boBillings.Add(boBilling);
            }

            rdr.Close();
            oDatabaseHelper.Dispose();

            return boBillings;
        }

        #endregion

        #region Methods (Private)

        private static void PopulateObjectFromReaderWithApplication(BO_Billing obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.PopsIntID)))
            {
                obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.PopsIntID)));
            }

            obj.BillingID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.BillingID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.ApplicationID)))
            {
                obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.ApplicationID)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.PriceModelID)))
            {
                obj.PriceModelID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.PriceModelID)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.LicensureNum)))
            {
                obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.LicensureNum));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.OnlineTransactionFeePaid)))
            {
                obj.OnlineTransactionFeePaid = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.OnlineTransactionFeePaid));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.Balance)))
            {
                obj.Balance = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.Balance)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalCharges)))
            {
                obj.TotalCharges = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalCharges)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalPayments)))
            {
                obj.TotalPayments = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalPayments)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalRefunds)))
            {
                obj.TotalRefunds = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalRefunds)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.LicenseFeePaid)))
            {
                obj.LicenseFeePaid = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.LicenseFeePaid));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.IsDelinquent)))
            {
                obj.IsDelinquent = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.IsDelinquent));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.BillToName)))
            {
                obj.BillToName = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.BillToName));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.CheckLogPrefix)))
            {
                obj.CheckLogPrefix = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.CheckLogPrefix));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.ProgramID)))
            {
                obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_BillingFields.ProgramID));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingFields.TotalAdjustments)))
            {
                obj.TotalAdjustments = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BillingFields.TotalAdjustments)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingGridFields.ApplicationType)))
            {
                obj.ApplicationType = rdr.GetString(rdr.GetOrdinal(BO_BillingGridFields.ApplicationType));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BillingGridFields.ApplicationStartDate)))
            {
                obj.ApplicationStartDate = rdr.GetDateTime(rdr.GetOrdinal(BO_BillingGridFields.ApplicationStartDate));
            }
        }

        #endregion

    }

}
