//
// Class	:	BO_Ownership.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:43 AM
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
    public class BO_OwnershipGridFields
    {
        public const string EntityName = "ENTITY_NAME";
        public const string DateStarted = "DATE_STARTED";
    }
	
	/// <summary>
	/// Data access class for the "OWNERSHIP" table.
	/// </summary>
	[Serializable]
	public class BO_Ownership : BO_OwnershipBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";

        private string _entityName = null;
        private DateTime? _dateStarted = null;

        private BO_LegalEntity _bO_LegalEntityDetail = null;
		
        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Ownership() : base()
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
                //if ( IsNewRec )
                //{
                    return _UI_TrackId;
                //}
                //else
                //{
                //    return EducationID.ToString();
                //}
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }

        public DateTime? DateStarted
        {
            get { return _dateStarted; }
            set { _dateStarted = value; }
        }

      		/// <summary>
		/// Provides access to the related table 'EDUCATION'
		/// </summary>
		public BO_LegalEntity BO_LegalEntityDetail
		{
			get 
			{
                //if ( _bO_LegalEntityApplication == null )
                //{
                //    _bO_LegalEntityApplication = new BO_LegalEntity();
                //    _bO_LegalEntityApplication = 
                //            BO_LegalEntity.SelectOneWithAllChildrenUsingLegalEntityID( new BO_LegalEntityPrimaryKey( LegalEntityID ) );
                //}
                return _bO_LegalEntityDetail; 
			}
			set 
			{
                _bO_LegalEntityDetail = value;
			}
		}
        
        #endregion

        #region Methods (Public)

        /// <summary>
        /// Returns the name of the Legal Entity and the Application Start Date in addition to the
        /// columsn from the Ownership table
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static BO_Ownerships SelectAllByForeignKeyPopsIntIDWithLegalEntityForGrid(BO_ProviderPrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Ownerships obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_OWNERSHIP_SelectAllByForeignKeyPopsIntIDWithLegalEntityForGrid", ref ExecutionState);
            obj = new BO_Ownerships();
            obj = BO_Ownership.PopulateObjectsFromReaderWithCheckingReaderForHistoryGrid(dr, oDatabaseHelper);
            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        public static BO_Ownerships PopulateObjectsFromReaderWithAllChildrenApplicationID( IDataReader rdr, BO_ApplicationPrimaryKey pk )
        {
            BO_Ownerships tmpOwnerships = new BO_Ownerships();

            while ( rdr.Read() )
            {
                BO_Ownership obj = new BO_Ownership();
                PopulateObjectFromReaderWithChildren( obj, rdr );
                tmpOwnerships.Add( obj );
            }

            return tmpOwnerships;
        }

        #endregion
		
		#region Methods (Private)

        /// <summary>
        /// This code is copied over from the base class's "PopulateObjectsFromReaderWithCheckingReader"
        /// method and then modified to call the "PopulateObjectFromReaderForHistoryGrid" method in this class
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="oDatabaseHelper"></param>
        /// <returns></returns>
        internal static BO_Ownerships PopulateObjectsFromReaderWithCheckingReaderForHistoryGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {
            BO_Ownerships list = new BO_Ownerships();

            if (rdr.Read())
            {
                BO_Ownership obj = new BO_Ownership();
                PopulateObjectFromReaderForHistoryGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Ownership();
                    PopulateObjectFromReaderForHistoryGrid(obj, rdr);
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

        /// <summary>
        /// This code is copied over from the base class's "PopulateObjectFromReader" method
        /// and then modified to add a custom field that is returned by the query and needed 
        /// for the History grid
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rdr"></param>
        internal static void PopulateObjectFromReaderForHistoryGrid(BO_Ownership obj, IDataReader rdr)
        {
            obj.LegalEntityID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.LegalEntityID)));
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.PopsIntID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnership)))
            {
                obj.TypeOwnership = rdr.GetString(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnership));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.ApplicationID)))
            {
                obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.ApplicationID)));
            }

            // custom columns
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipGridFields.EntityName)))
            {
                obj.EntityName = rdr.GetString(rdr.GetOrdinal(BO_OwnershipGridFields.EntityName));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipGridFields.DateStarted)))
            {
                obj.DateStarted = rdr.GetDateTime(rdr.GetOrdinal(BO_OwnershipGridFields.DateStarted));
            }
        }

        internal static void PopulateObjectFromReaderWithChildren( BO_Ownership obj, IDataReader rdr )
        {
            //Load base class fields
            PopulateObjectFromReader( obj, rdr );
            //Fill Person Details
            obj.BO_LegalEntityDetail = BO_LegalEntity.SelectOneWithAllChildrenUsingLegalEntityID( new BO_LegalEntityPrimaryKey( obj.LegalEntityID ) );
        }

        #endregion

	}
	
}
