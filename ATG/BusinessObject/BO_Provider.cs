//
// Class	:	BO_Provider.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/15/2010 4:08:38 PM
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
    public class BO_ProviderGridFields
    {
        public const string FieldOffice = "FIELD_OFFICE";
        public const string StatusCodeDesc = "STATUS_CODE_DESC";
    }
	
	/// <summary>
	/// Data access class for the "PROVIDERS" table.
	/// </summary>
	[Serializable]
	public class BO_Provider : BO_ProviderBase
	{
	
		#region Class Level Variables

        private string _fieldOffice = null;
        private string _statusCodeDesc = null;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Provider() : base()
        {
        }

        #endregion

        #region Properties

        public string FieldOffice
        {
            get { return _fieldOffice; }
            set { _fieldOffice = value; }
        }

        public string StatusCodeDesc
        {
            get { return _statusCodeDesc; }
            set { _statusCodeDesc = value; }
        }
        #endregion

        #region Methods (Public)

        /// <summary>
        /// This code is copied over from the base class's "SelectAllByForeignKeyProgramID"
        /// method and then modified to call the "ATG_PROVIDERS_SelectAllByForeignKeyProgramIDForGrid" 
        /// custom stored procedure
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public static BO_Providers SelectAllByForeignKeyProgramIDForGrid(BO_ProgramPrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Providers obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            
            // Custom query for returning only the columns required for the provider Grid
            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDERS_SelectAllByForeignKeyProgramIDForGrid", ref ExecutionState);
            obj = new BO_Providers();
            obj = BO_Provider.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        /// <summary>
        /// This method returns all PROVIDER rows
        /// This is used for populating the Grid when user selects the 'All' option
        /// </summary>
        /// <returns></returns>
        public static BO_Providers SelectAllForGrid()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            // Custom query for returning only the columns required for the provider Grid
            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDERS_SelectAllForGrid", ref ExecutionState);
            BO_Providers  obj = BO_Provider.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
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
        internal static BO_Providers PopulateObjectsFromReaderWithCheckingReaderForGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {
            BO_Providers list = new BO_Providers();

            if (rdr.Read())
            {
                BO_Provider obj = new BO_Provider();
                PopulateObjectFromReaderForGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Provider();
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

        /// <summary>
        /// This code is copied over from the base class's "PopulateObjectFromReader" method
        /// and then modified to:
        /// 1) Remove the columns that are not used by the Provider grid
        /// 2) Add a custom column that is returned by the query and needed for the History grid
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rdr"></param>
        internal static void PopulateObjectFromReaderForGrid(BO_Provider obj, IDataReader rdr)
        {
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.PopsIntID)));

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ProgramID)))
            {
                obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ProgramID));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AspenIntID)))
            {
                obj.AspenIntID = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.AspenIntID)));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateID)))
            {
                obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StateID));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FacilityName)))
            {
                obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FacilityName));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalCity)))
            {
                obj.GeographicalCity = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalCity));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Parish)))
            {
                obj.Parish = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Parish));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChapAccreditionYN)))
            {
                obj.ChapAccreditionYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ChapAccreditionYN));
            }
            if ( !rdr.IsDBNull( rdr.GetOrdinal( BO_ProviderFields.LicensureExpirationDate ) ) )
            {
                obj.LicensureExpirationDate = rdr.GetDateTime( rdr.GetOrdinal( BO_ProviderFields.LicensureExpirationDate ) );
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureNum)))
            {
                obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LicensureNum));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfCorporation)))
            {
                obj.NameOfCorporation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfCorporation));
            }
            // custom column - Field Office
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderGridFields.FieldOffice)))
            {
                obj.FieldOffice = rdr.GetString(rdr.GetOrdinal(BO_ProviderGridFields.FieldOffice));
            }
            // custom column - Status Code Description
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderGridFields.StatusCodeDesc)))
            {
                obj.StatusCodeDesc = rdr.GetString(rdr.GetOrdinal(BO_ProviderGridFields.StatusCodeDesc));
            }
        }


        #endregion

	}
	
}
