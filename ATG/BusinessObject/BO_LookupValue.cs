//
// Class	:	BO_LookupValue.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/27/2010 11:24:40 AM
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
	/// Data access class for the "LOOKUP_VALUES" table.
	/// </summary>
	[Serializable]
	public class BO_LookupValue : BO_LookupValueBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_LookupValue() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        /// <summary>
        /// Returns LookupValues result set ordered by the "LOOKUP_VAL" column
        /// </summary>
        /// <param name="field">Name of the column used in the WHERE clause</param>
        /// <param name="fieldValue">Value used in the WHERE clause</param>
        /// <returns></returns>
        public static BO_LookupValues SelectByFieldOrderByLookupVal(string field, object fieldValue)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@Field", field);
            oDatabaseHelper.AddParameter("@Value", fieldValue);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_LOOKUP_VALUES_SelectByFieldOrderByLookupVal", ref ExecutionState);
            BO_LookupValues BO_LookupValues = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LookupValues;
        }

        public static BO_LookupValues SelectByFieldByKeyAndProgram(string key, string programID)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@Key", key);
            oDatabaseHelper.AddParameter("@ProgramID", programID);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_LOOKUP_VALUES_SelectByProgram", ref ExecutionState);
            BO_LookupValues BO_LookupValues = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LookupValues;
        }

        public static BO_LookupValues SelectByFieldOrderByValDESC(string field, object fieldValue)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;


            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@Field", field);
            oDatabaseHelper.AddParameter("@Value", fieldValue);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_LOOKUP_VALUES_SelectByField_SORTEDBYDESC", ref ExecutionState);
            BO_LookupValues BO_LookupValues = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LookupValues;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
