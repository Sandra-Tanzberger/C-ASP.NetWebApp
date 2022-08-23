//
// Class	:	BO_Message.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:38 AM
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
    /// Class for the properties of the object
    /// </summary>
    public class BO_MessageApplicationGridFields
    {
        public const string NameCity = "NAMECITY";
        public const string StateID = "STATE_ID";
        public const string LicensureExpirationDate = "LICENSURE_EXPIRATION_DATE";
        public const string StatusCode = "STATUSCODE";
        public const string SendType = "SEND_TYPE";
        public const string BusinessProcessName = "BUSINESS_PROCESS_NAME";
    }

    /// <summary>
	/// Data access class for the "MESSAGES" table.
	/// </summary>
	[Serializable]
	public class BO_Message : BO_MessageBase
	{
	
		#region Class Level Variables

        public String NameCity = null;
        public String StateID = null;
        public DateTime? LicensureExpirationDate = null;
        public String StatusCode = null;
        public String SendType = null;
        public String BusinessProcessName = null;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Message() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        public static BO_Messages SelectAllByApplicationStatus( String inApplicationStatusFilter )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Messages obj = null;

            oDatabaseHelper.AddParameter( "@ApplicationStatus", inApplicationStatusFilter );

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_MESSAGES_SelectAllByApplicationStatus", ref ExecutionState );
            obj = new BO_Messages();
            obj = BO_Message.PopulateObjectsFromReaderForApplicationMessagesGrid( dr, oDatabaseHelper );

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        #endregion
		
		#region Methods (Private)
        internal static BO_Messages PopulateObjectsFromReaderForApplicationMessagesGrid( IDataReader rdr, DatabaseHelper oDatabaseHelper )
        {

            BO_Messages list = new BO_Messages();

            if ( rdr.Read() )
            {
                BO_Message obj = new BO_Message();
                PopulateApplicationMessagesGridObjectFromReader( obj, rdr );
                list.Add( obj );
                while ( rdr.Read() )
                {
                    obj = new BO_Message();
                    PopulateApplicationMessagesGridObjectFromReader( obj, rdr );
                    list.Add( obj );
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

        internal static void PopulateApplicationMessagesGridObjectFromReader( BO_Message obj, IDataReader rdr )
        {

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.NameCity ) ) )
            {
                obj.NameCity = rdr.GetString( rdr.GetOrdinal( BO_MessageApplicationGridFields.NameCity ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.StateID ) ) )
            {
                obj.StateID = rdr.GetString( rdr.GetOrdinal( BO_MessageApplicationGridFields.StateID ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.LicensureExpirationDate ) ) )
            {
                obj.LicensureExpirationDate = rdr.GetDateTime( rdr.GetOrdinal( BO_MessageApplicationGridFields.LicensureExpirationDate ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.StatusCode ) ) )
            {
                obj.StatusCode = rdr.GetString( rdr.GetOrdinal( BO_MessageApplicationGridFields.StatusCode ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.SendType ) ) )
            {
                obj.SendType = rdr.GetString( rdr.GetOrdinal( BO_MessageApplicationGridFields.SendType ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageFields.MessageSubject ) ) )
            {
                obj.MessageSubject = rdr.GetString( rdr.GetOrdinal( BO_MessageFields.MessageSubject ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageFields.MessageText ) ) )
            {
                obj.MessageText = rdr.GetString( rdr.GetOrdinal( BO_MessageFields.MessageText ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageFields.MessagePrintDate ) ) )
            {
                obj.MessagePrintDate = rdr.GetDateTime( rdr.GetOrdinal( BO_MessageFields.MessagePrintDate ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageFields.MessageDate ) ) )
            {
                obj.MessageDate = rdr.GetDateTime( rdr.GetOrdinal( BO_MessageFields.MessageDate ) );
            }

            obj.MessageID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_MessageFields.MessageID ) ) );

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageFields.MessageFailureCode ) ) )
            {
                obj.MessageFailureCode = rdr.GetString( rdr.GetOrdinal( BO_MessageFields.MessageFailureCode ) );
            }

            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_MessageApplicationGridFields.BusinessProcessName ) ) )
            {
                obj.BusinessProcessName = rdr.GetString( rdr.GetOrdinal( BO_MessageApplicationGridFields.BusinessProcessName ) );
            }

            obj.ApplicationID = Convert.ToDecimal( rdr.GetValue( rdr.GetOrdinal( BO_MessageFields.ApplicationID ) ) );

        }

        #endregion

	}
	
}
