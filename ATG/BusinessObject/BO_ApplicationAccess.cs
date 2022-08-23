//
// Class	:	BO_ApplicationAccess.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/23/2019 2:37:55 PM
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
	/// Data access class for the "APPLICATION_ACCESS" table.
	/// </summary>
	[Serializable]
	public class BO_ApplicationAccess : BO_ApplicationAccessBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_ApplicationAccess() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        public static BO_ApplicationAccesses SelectAllDistinct()
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_APPLICATION_ACCESS_SelectAll", ref ExecutionState);
            BO_ApplicationAccesses BO_ApplicationAccesses = PopulateObjectsFromReaderForAddGrid(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ApplicationAccesses;
        }

        public static bool Delete(string GRPID, string LOGINID)
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@GRPID", GRPID);
            oDatabaseHelper.AddParameter("@LOGINID", LOGINID);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteReader("ATG_APPLICATION_ACCESS_DeleteByGRPIDandLOGINID", ref ExecutionState);

            oDatabaseHelper.Dispose();
            return ExecutionState;
        }

        public static bool Insert(string GRPID, string LOGINID)
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@Grpid", GRPID);
            oDatabaseHelper.AddParameter("@Loginid", LOGINID);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteReader("ATG_APPLICATION_ACCESS_Insert", ref ExecutionState);
           
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }

        #endregion
		
		#region Methods (Private)

        internal static BO_ApplicationAccesses PopulateObjectsFromReaderForAddGrid(IDataReader rdr)
        {

            BO_ApplicationAccesses list = new BO_ApplicationAccesses();

            while (rdr.Read())
            {
                BO_ApplicationAccess obj = new BO_ApplicationAccess();
                PopulateObjectFromReaderForAddGrid(obj, rdr);
                list.Add(obj);
            }
            return list;
        }

        internal static void PopulateObjectFromReaderForAddGrid(BO_ApplicationAccessBase obj, IDataReader rdr)
        {

            obj.Grpid = rdr.GetString(rdr.GetOrdinal(BO_ApplicationAccessFields.Grpid));
        }


        #endregion

	}
	
}
