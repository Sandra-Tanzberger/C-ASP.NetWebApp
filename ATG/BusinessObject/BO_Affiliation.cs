//
// Class	:	BO_Affiliation.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:35 AM
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
    public class BO_AffiliationGridFields
    {
        public const string FacilityName = "FACILITY_NAME";
        public const string AffiliationTypeDesc = "AFFILIATION_TYPE_DESC";
        public const string Street = "STREET";
        public const string City = "CITY";
        public const string StateCode = "STATE_CODE";
        public const string ZipCode = "ZIP_CODE";
        public const string ParishCode = "PARISH_CODE";
        public const string StatusCodeDesc = "STATUS_CODE_DESC";
    }
	
	/// <summary>
	/// Data access class for the "AFFILIATION" table.
	/// </summary>
	[Serializable]
	public class BO_Affiliation : BO_AffiliationBase
	{
	
		#region Class Level Variables

        private string _facilityName = null;
        private string _affiliationTypeDesc = null;
        private string _street = null;
        private string _city = null;
        private string _stateCode = null;
        private string _zipCode = null;
        private string _parishCode = null;
        private string _statusCodeDesc = null;
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";
        private bool _newRecCommitToDB = false;
        
        private BO_Provider _AffiliationDetail = null;
        private BO_Address _bo_AddressAffiliationID = null;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Affiliation() : base()
        {
        }

        #endregion

        #region Properties

        public string AffiliationTypeDesc
        {
            get { return _affiliationTypeDesc; }
            set { _affiliationTypeDesc = value; }
        }

        public BO_Address BO_AddressAffiliationID
        {
            get { return _bo_AddressAffiliationID; }
            set { _bo_AddressAffiliationID = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string ParishCode
        {
            get { return _parishCode; }
            set { _parishCode = value; }
        }

        public string StatusCodeDesc 
        {
            get { return _statusCodeDesc; }
            set { _statusCodeDesc = value; }
        }

        public bool IsNewRec
        {
            get{ return _IsNewRec; }
            set{ _IsNewRec = value; }
        }

        public bool Removed
        {
            get{ return _Removed; }
            set{ _Removed = value; }
        }

        public string UI_TrackID
        {
            get
            {
                if ( IsNewRec )
                {
                    return _UI_TrackId;
                }
                else
                {
                    return AffiliationID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        public bool NewRecCommitToDB
        {
            get { return _newRecCommitToDB; }
            set { _newRecCommitToDB = value; }
        }

        public BO_Provider AffiliationDetail
        {
            get { return _AffiliationDetail; }
            set { _AffiliationDetail = value; }
        }

        #endregion

        #region Methods (Public)

        //SMM 04/03/2012 - Added as a way to get original UI_Trackid. The property definition for this uses a flag for IsNewRec
        //and will return the affiliation id when false. This will allow for matching on the original value.
        public string getTrackID()
        {
            return _UI_TrackId;
        }

        public static BO_Affiliations SelectAllUsingForeignKeyPopsIntId( decimal inPopsIntId )
        {
            BO_Affiliations tmpAffils = null;

            return tmpAffils;
        }

        /// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
        ///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <returns>Object of BO_Affiliations</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			12/29/2010 9:56:49 AM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Affiliations PopulateObjectsFromReaderWithAllChildrenApplicationID( IDataReader rdr, BO_ApplicationPrimaryKey pk )
        {
            BO_Affiliations tmpAffiliations = new BO_Affiliations();

            while ( rdr.Read() )
            {
                BO_Affiliation obj = new BO_Affiliation();
                PopulateObjectFromReaderWithChildren( obj, rdr );
                tmpAffiliations.Add( obj );
            }

            return tmpAffiliations;
        }

        internal static void PopulateObjectFromReaderWithChildren( BO_Affiliation obj, IDataReader rdr )
        {
            //Load base class fields
            PopulateObjectFromReader( obj, rdr );

            // rjc - 08/28/2012 - need to check for null before attempting GetString()
            int ord = rdr.GetOrdinal(BO_AffiliationGridFields.StatusCodeDesc);
            if (!rdr.IsDBNull(ord)) {
                obj.StatusCodeDesc = rdr.GetString(ord);
            }

            //Fill address Details
            obj.BO_AddressAffiliationID = BO_Address.SelectOne( new BO_AddressPrimaryKey( obj.AddressID ) );
            
            obj.BO_SpecialtyUnitsAffiliationID = BO_SpecialtyUnit.SelectAllByForeignKeyAffiliationID ( 
                                                    new BO_AffiliationPrimaryKey( obj.PopsIntID, obj.AffiliationID, obj.ApplicationID )
                                                 );
            
            obj.BO_CapacitiesAffiliationID = BO_Capacity.SelectAllByForeignKeyAffiliationID(
                                                new BO_AffiliationPrimaryKey( obj.PopsIntID, obj.AffiliationID, obj.ApplicationID )
                                             );

            obj.BO_ServicesAffiliationID = BO_Service.SelectAllByForeignKeyAffiliationID(
                                                new BO_AffiliationPrimaryKey( obj.PopsIntID, obj.AffiliationID, obj.ApplicationID )
                                             );
        }
        
        /// <summary>
        /// Retrieves rows that are used for populating the History Grid for Offsites/Branches
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static BO_Affiliations SelectWithAddressDescByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Affiliations obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_AFFILIATION_SelectWithAddressDescByForeignKeyApplicationID", ref ExecutionState);
            obj = new BO_Affiliations();
            obj = BO_Affiliation.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        /// <summary>
        /// Retrieves affiliations that are not on the passed in application
        /// </summary>
        /// <param name="Providerpk"></param>
        /// <param name="Applicationpk"></param>
        /// <returns></returns>
        public static BO_Affiliations SelectAllByPopsIntIDNotOnApplication( BO_ProviderPrimaryKey Providerpk, BO_ApplicationPrimaryKey Applicationpk )
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Affiliations obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvcProv = Providerpk.GetKeysAndValues();
            foreach ( string key in nvcProv.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvcProv[key] );
            }

            System.Collections.Specialized.NameValueCollection nvcApp = Applicationpk.GetKeysAndValues();
            foreach ( string key in nvcApp.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvcApp[key] );
            }
            
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_AFFILIATION_SelectAllByPopsIntIDNotOnApplication", ref ExecutionState );
            obj = new BO_Affiliations();
            obj = BO_Affiliation.PopulateObjectsFromReader( dr );

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        /// <summary>
        /// This method will Delete one row from the database using the property Information
        /// </summary>
        ///
        /// <returns>True if succeeded</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			02/22/2011 1:13:50 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public void DeleteCascadeChildren()
        {
            ////Remove address object
            //if ( null != this.BO_AddressAffiliationID )
            //    this.BO_AddressAffiliationID.Delete();

            //Remove Specialty Units
            if ( null != this.BO_SpecialtyUnitsAffiliationID )
            {
                int RecCnt = this.BO_SpecialtyUnitsAffiliationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_SpecialtyUnitsAffiliationID[delCnt].Delete();
                }
            }

            //Remove capacity data
            if ( null != this.BO_CapacitiesAffiliationID )
            {
                int RecCnt = this.BO_CapacitiesAffiliationID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_CapacitiesAffiliationID[delCnt].Delete();
                }
            }

            Delete();

        }

        #endregion
		
		#region Methods (Private)

        internal static BO_Affiliations PopulateObjectsFromReaderWithCheckingReaderForGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {
            BO_Affiliations list = new BO_Affiliations();

            if (rdr.Read())
            {
                BO_Affiliation obj = new BO_Affiliation();
                PopulateObjectFromReaderForGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Affiliation();
                    PopulateObjectFromReaderForGrid(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        internal static void PopulateObjectFromReaderForGrid(BO_Affiliation obj, IDataReader rdr)
        {
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.PopsIntID)));
            obj.AffiliationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.AffiliationID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TypeAffiliation)))
            {
                obj.TypeAffiliation = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TypeAffiliation));
            }

            obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.ApplicationID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.AddressID)))
            {
                obj.AddressID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.AddressID)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Active)))
            {
                obj.Active = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.Active));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.BranchID)))
            {
                obj.BranchID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AffiliationFields.BranchID)));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.MedicareBranchID)))
            {
                obj.MedicareBranchID = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.MedicareBranchID));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.ClosedDate)))
            {
                obj.ClosedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.ClosedDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OpenedDate)))
            {
                obj.OpenedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OpenedDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OperStatCode)))
            {
                obj.OperStatCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.OperStatCode));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.LicensureNum)))
            {
                obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.LicensureNum));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.OriginalLicensureDate)))
            {
                obj.OriginalLicensureDate = rdr.GetDateTime(rdr.GetOrdinal(BO_AffiliationFields.OriginalLicensureDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TelephoneNumber)))
            {
                obj.TelephoneNumber = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.TelephoneNumber));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.FaxPhoneNumber)))
            {
                obj.FaxPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_AffiliationFields.FaxPhoneNumber));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.NumberOfBeds)))
            {
                obj.NumberOfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.NumberOfBeds));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.TotalLicBeds)))
            {
                obj.TotalLicBeds = rdr.GetInt32( rdr.GetOrdinal( BO_AffiliationFields.TotalLicBeds ) );
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.PsychiatricBeds)))
            {
                obj.PsychiatricBeds = rdr.GetInt32( rdr.GetOrdinal( BO_AffiliationFields.PsychiatricBeds ) );
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.RehabilitationBeds)))
            {
                obj.RehabilitationBeds = rdr.GetInt32( rdr.GetOrdinal( BO_AffiliationFields.RehabilitationBeds ) );
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.SnfBeds)))
            {
                obj.SnfBeds = rdr.GetInt32( rdr.GetOrdinal( BO_AffiliationFields.SnfBeds ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_AffiliationFields.OtherBeds ) ) )
            {
                obj.OtherBeds = rdr.GetInt32( rdr.GetOrdinal( BO_AffiliationFields.OtherBeds ) );
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationFields.Unit)))
            {
                obj.Unit = rdr.GetInt32(rdr.GetOrdinal(BO_AffiliationFields.Unit));
            }

            // custom columns
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.FacilityName)))
            {
                obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.FacilityName));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.AffiliationTypeDesc)))
            {
                obj.AffiliationTypeDesc = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.AffiliationTypeDesc));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.StatusCodeDesc))) {
                obj.StatusCodeDesc = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.StatusCodeDesc));
            }
            
            //Affiliation structure and data have been changed so these are no longer needed. The is now an address
            //object associated with each affiliation and details can be retreived from there.
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.Street)))
            {
                obj.Street = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.Street));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.City)))
            {
                obj.City = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.City));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.StateCode)))
            {
                obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.StateCode));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.ZipCode)))
            {
                obj.ZipCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.ZipCode));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_AffiliationGridFields.ParishCode)))
            {
                obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_AffiliationGridFields.ParishCode));
            }
        }


        #endregion

    }
	
}
