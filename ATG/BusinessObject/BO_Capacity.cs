//
// Class	:	BO_Capacity.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/26/2010 6:47:11 PM
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
    public class BO_CapacityGridFields
    {
        public const string TotalBeds = "TOTAL_BEDS";
        public const string DateStarted = "DATE_STARTED";
    }
	
	/// <summary>
	/// Data access class for the "CAPACITIES" table.
	/// </summary>
	[Serializable]
	public class BO_Capacity : BO_CapacityBase
	{
	
		#region Class Level Variables

        private int? _totalBeds = null;
        private DateTime? _dateStarted = null;

        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Capacity() : base()
        {
        }

        #endregion

        #region Properties

        public int? TotalBeds
        {
            get
            {
                return _totalBeds;
            }
            set
            {

                _totalBeds = value;
            }
        }

        public DateTime? DateStarted
        {
            get
            {
                return _dateStarted;
            }
            set
            {

                _dateStarted= value;
            }
        }

        #endregion

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
                    return CapacityID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        #region Methods (Public)

        /// <summary>
        /// Returns a collection of Capacities BO.
        /// The Stored procedure executed in here returns data grouped by ApplicationId
        /// for a specified PopsintId
        /// </summary>
        /// <param name="pk">Used in the WHERE clause</param>
        /// <returns></returns>
        public static BO_Capacities SelectAllByForeignKeyPopsIntIDGroupedApplicationId(BO_ProviderPrimaryKey pk)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Capacities obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_CAPACITIES_SelectAllByForeignKeyPopsIntIDGroupedApplicationId", ref ExecutionState);
            obj = new BO_Capacities();

            // replace with a custom function call
            // NOTE: look at BO_Application for reference
            obj = BO_Capacity.PopulateObjectsFromReaderWithCheckingReaderForHistoryGrid(dr, oDatabaseHelper);

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
        internal static BO_Capacities PopulateObjectsFromReaderWithCheckingReaderForHistoryGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {

            BO_Capacities list = new BO_Capacities();

            if (rdr.Read())
            {
                BO_Capacity obj = new BO_Capacity();
                PopulateObjectFromReaderForHistoryGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Capacity();
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
        /// <param name="obj">The BO_Capacity object instance</param>
        /// <param name="rdr">IDataReader from the query result</param>
        internal static void PopulateObjectFromReaderForHistoryGrid(BO_Capacity obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.ApplicationID)))
            {
                obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CapacityFields.ApplicationID)));
            }

            // custom columns
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityGridFields.TotalBeds)))
            {
                obj.TotalBeds= rdr.GetInt32(rdr.GetOrdinal(BO_CapacityGridFields.TotalBeds));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityGridFields.DateStarted)))
            {
                obj.DateStarted = rdr.GetDateTime(rdr.GetOrdinal(BO_CapacityGridFields.DateStarted));
            }

        }


        #endregion

	}
	
}
