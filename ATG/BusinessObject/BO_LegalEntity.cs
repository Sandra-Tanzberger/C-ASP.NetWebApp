//
// Class	:	BO_LegalEntity.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 12:38:20 PM
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
	/// Data access class for the "LEGAL_ENTITY" table.
	/// </summary>
	[Serializable]
	public class BO_LegalEntity : BO_LegalEntityBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";

        private BO_Address _boAddress = null;
        private BO_OwnerOtherProviders _bO_OwnerOtherProvidersLegalEntityID = null;
		
        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_LegalEntity() : base()
        {
        }

        #endregion

        #region Properties
        public bool IsNewRec
        {
            get
            {
                return _IsNewRec;
            }
            set
            {
                _IsNewRec = value;
            }
        }

        public bool Removed
        {
            get
            {
                return _Removed;
            }
            set
            {
                _Removed = value;
            }
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
                    return LegalEntityID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        public BO_Address BO_AddressDetail
        {
            get{
                return _boAddress;
            }
            set{
                _boAddress = value;
            }
        }

        /// <summary>
        /// Provides access to the related table 'OWNER_OTHER_PROVIDER'
        /// </summary>
        public BO_OwnerOtherProviders BO_OwnerOtherProvidersLegalEntityID
        {
            get
            {
                if ( _bO_OwnerOtherProvidersLegalEntityID == null )
                {
                    _bO_OwnerOtherProvidersLegalEntityID = new BO_OwnerOtherProviders();
                    _bO_OwnerOtherProvidersLegalEntityID = BO_OwnerOtherProvider.SelectByField( "LEGAL_ENTITY_ID", LegalEntityID );
                }
                return _bO_OwnerOtherProvidersLegalEntityID;
            }
            set
            {
                _bO_OwnerOtherProvidersLegalEntityID = value;
            }
        }

        #endregion

        #region Methods (Public)
        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified 
        /// along with the details of the child table.
        /// </summary>
        ///
        /// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class LEGAL_ENTITY</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			12/20/2010 9:10:04 AM				Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_LegalEntity SelectOneWithAllChildrenUsingLegalEntityID( BO_LegalEntityPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_LegalEntity obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_LEGAL_ENTITY_SelectOneWithAllChildrenUsingLegalEntityID", ref ExecutionState );
            if ( dr.Read() )
            {
                obj = new BO_LegalEntity();
                PopulateObjectFromReader( obj, dr );

                obj.BO_AddressDetail = BO_Address.SelectOneWithLEGAL_ENTITYUsingAddressID( new BO_AddressPrimaryKey(obj.AddressID) );

                dr.NextResult();
                obj.BO_OwnerOtherProvidersLegalEntityID = BO_OwnerOtherProvider.PopulateObjectsFromReader( dr );

                //Go through collection and assign the original Legal entity id to implementation field
                foreach ( BO_OwnerOtherProvider boOOP in obj.BO_OwnerOtherProvidersLegalEntityID )
                {
                    boOOP.OrigLegalEntityID = boOOP.LegalEntityID.Value;
                }

                dr.NextResult();
                obj.BO_OwnerPeopleLegalEntityID = BO_OwnerPerson.PopulateObjectsFromReaderWithAllChildrenApplicationID( dr );
            }
            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
