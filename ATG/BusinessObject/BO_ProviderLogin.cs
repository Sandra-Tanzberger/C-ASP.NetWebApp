//
// Class	:	BO_ProviderLogin.cs
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
	/// Data access class for the "PROVIDER_LOGIN" table.
	/// </summary>
	[Serializable]
	public class BO_ProviderLogin : BO_ProviderLoginBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_ProviderLogin() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)
        /// <summary>
        /// This method will return an object representing the record matching the primary key information specified.
        /// </summary>
        ///
        /// <param name="pk" type="ProviderLoginPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class ProviderLogin</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			03/07/2010 12:06:25 PM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_ProviderLogin SelectByLogin( string inLoginID )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter( "@inLoginID", inLoginID );
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_PROVIDER_LOGIN_SelectByLoginID", ref ExecutionState );
			
            if ( dr.Read() )
            {
                BO_ProviderLogin obj = new BO_ProviderLogin();
                PopulateObjectFromReader( obj, dr );
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


        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
