//
// Class	:	BO_OwnerOtherProvider.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/01/2010 10:45:48 AM
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
	/// Data access class for the "OWNER_OTHER_PROVIDER" table.
	/// </summary>
	[Serializable]
	public class BO_OwnerOtherProvider : BO_OwnerOtherProviderBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";
        private decimal _OrigLegalEntityID = 0;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_OwnerOtherProvider() : base()
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
                    return OwnOtherProvID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        public decimal OrigLegalEntityID
        {
            get
            {
                return _OrigLegalEntityID;
            }
            set
            {
                _OrigLegalEntityID = value;
            }
        }

        #endregion

        #region Methods (Public)
        /// <summary>
        /// This method will Update one new row into the database using the property Information. Created to allow
        /// update of legal entity id as it was not suporrted through generation tool.
        /// </summary>
        ///
        /// <returns>True if succeeded</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Shawn Martin		03/15/2011 		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public bool UpdateWithNewLegalEntityID()
        {

            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_ownOtherProvID' as parameter 'OwnOtherProvID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@OwnOtherProvID", this.OwnOtherProvID );

            // Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@OrigLegalEntityID", this.OrigLegalEntityID );

            // Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@LegalEntityID", this.LegalEntityID );

            // Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
            oDatabaseHelper.AddParameter( "@FacilityName", this.FacilityName );

            // Pass the value of '_facilityAddress' as parameter 'FacilityAddress' of the stored procedure.
            oDatabaseHelper.AddParameter( "@FacilityAddress", this.FacilityAddress );

            // Pass the value of '_providerNum' as parameter 'ProviderNum' of the stored procedure.
            oDatabaseHelper.AddParameter( "@ProviderNum", this.ProviderNum );

            // Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
            oDatabaseHelper.AddParameter( "@StateID", this.StateID );

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            oDatabaseHelper.ExecuteScalar( "ATG_OWNER_OTHER_PROVIDER_Update", ref ExecutionState );
            oDatabaseHelper.Dispose();
            return ExecutionState;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
