//
// Class	:	BO_Ziplookup.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/08/2010 9:05:24 AM
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
	/// Data access class for the "ZIPLOOKUP" table.
	/// </summary>
	[Serializable]
	public class BO_Ziplookup : BO_ZiplookupBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Ziplookup() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified
        /// </summary>
        ///
        /// <param name="field" type="string">Field of the class BO_Ziplookup</param>
        /// <param name="fieldValue" type="object">Value for the field specified.</param>
        ///
        /// <returns>List of object of class BO_Ziplookup in the form of an object of class BO_Ziplookups</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			10/08/2010 9:05:23 AM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Ziplookups SelectCitiesByState( string StateCode)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter( "@State_Code", StateCode );
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_ZIPLOOKUP_SelectCitiesByState", ref ExecutionState );
            BO_Ziplookups BO_Ziplookups = PopulateObjectCitiesFromReader( dr );
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ziplookups;

        }

        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified
        /// </summary>
        ///
        /// <param name="field" type="string">Field of the class BO_Ziplookup</param>
        /// <param name="fieldValue" type="object">Value for the field specified.</param>
        ///
        /// <returns>List of object of class BO_Ziplookup in the form of an object of class BO_Ziplookups</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			10/08/2010 9:05:23 AM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Ziplookups SelectZipcodeByCity( string CityName , string State)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter( "@City", CityName );
            oDatabaseHelper.AddParameter("@State", State);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_ZIPLOOKUP_SelectZipcodeByCity", ref ExecutionState );
            BO_Ziplookups BO_Ziplookups = PopulateObjectZipCodesFromReader( dr );
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ziplookups;

        }

        public static BO_Ziplookups SelectParishes(string StateCode, string City)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@STATE_CODE", StateCode);
            oDatabaseHelper.AddParameter("@CITY", City);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_ZIPLOOKUP_SelectParishByCityState", ref ExecutionState);
            BO_Ziplookups BO_Ziplookups = PopulateObjectpParishFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ziplookups;
        }

        #endregion
		
		#region Methods (Private)
        /// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
        /// <param name="obj" type="ZIPLOOKUP">Object of ZIPLOOKUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			10/08/2010 9:05:23 AM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        internal static BO_Ziplookups PopulateObjectCitiesFromReader( IDataReader rdr )
        {
            BO_Ziplookups list = new BO_Ziplookups();

            while ( rdr.Read() )
            {
                BO_Ziplookup obj = new BO_Ziplookup();
                obj.City = rdr.GetString( rdr.GetOrdinal( BO_ZiplookupFields.City ) );
                list.Add( obj );
            }
            return list;

        }

        internal static BO_Ziplookups PopulateObjectpParishFromReader(IDataReader rdr)
        {
            BO_Ziplookups list = new BO_Ziplookups();

            while (rdr.Read())
            {
                BO_Ziplookup obj = new BO_Ziplookup();
                obj.County = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.County));
                obj.Cntyname = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.Cntyname));
                list.Add(obj);
            }
            return list;

        }

        /// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
        /// <param name="obj" type="ZIPLOOKUP">Object of ZIPLOOKUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// DLGenerator			10/08/2010 9:05:23 AM		Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        internal static BO_Ziplookups PopulateObjectZipCodesFromReader( IDataReader rdr )
        {
            BO_Ziplookups list = new BO_Ziplookups();

            while ( rdr.Read() )
            {
                BO_Ziplookup obj = new BO_Ziplookup();
                obj.Zip = rdr.GetString( rdr.GetOrdinal( BO_ZiplookupFields.Zip ) );
                list.Add( obj );
            }
            return list;

        }

        #endregion

	}
	
}
