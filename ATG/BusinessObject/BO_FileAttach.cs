//
// Class	:	BO_FileAttach.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/01/2010 10:45:44 AM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;

namespace ATG.BusinessObject
{
	
	/// <summary>
	/// Data access class for the "FILE_ATTACH" table.
	/// </summary>
	[Serializable]
	public class BO_FileAttach : BO_FileAttachBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_FileAttach() : base()
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
                    return FileAttachID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        #endregion

        #region Methods (Public)
        /// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
        /// <param name="obj" type="FILE_ATTACH">Object of FILE_ATTACH to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			01/11/2011 8:57:15 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        internal static void PopulateObjectFromReaderSummary( BO_FileAttachBase obj, IDataReader rdr )
        {

            obj.FileAttachID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_FileAttachFields.FileAttachID ) ) );
            obj.AttachFilename = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.AttachFilename ) );
            obj.AttachDescription = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.AttachDescription ) );
            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.AttachmentType ) ) )
            {
                obj.AttachmentType = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.AttachmentType ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.AttachParentID ) ) )
            {
                obj.AttachParentID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_FileAttachFields.AttachParentID ) ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.AttachParentIdType ) ) )
            {
                obj.AttachParentIdType = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.AttachParentIdType ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.AttachSaved ) ) )
            {
                obj.AttachSaved = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.AttachSaved ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.SavedRefID ) ) )
            {
                obj.SavedRefID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_FileAttachFields.SavedRefID ) ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.ContentType ) ) )
            {
                obj.ContentType = rdr.GetString( rdr.GetOrdinal( BO_FileAttachFields.ContentType ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.FileSize ) ) )
            {
                obj.FileSize = rdr.GetInt32( rdr.GetOrdinal( BO_FileAttachFields.FileSize ) );
            }

            if (!rdr.IsDBNull( rdr.GetOrdinal( BO_FileAttachFields.AddDate) ) )
            {
                obj.AddDate = rdr.GetDateTime( rdr.GetOrdinal( BO_FileAttachFields.AddDate ) );
            }

        }

        /// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
        ///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <returns>Object of BO_FileAttaches</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			01/11/2011 8:57:15 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        internal static BO_FileAttaches PopulateObjectsFromReaderSummary( IDataReader rdr )
        {

            BO_FileAttaches list = new BO_FileAttaches();

            while ( rdr.Read() )
            {
                BO_FileAttach obj = new BO_FileAttach();
                PopulateObjectFromReaderSummary( obj, rdr );
                list.Add( obj );
            }
            return list;

        }
        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
