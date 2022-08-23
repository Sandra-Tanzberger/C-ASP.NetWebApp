//
// Class	:	BO_Substation.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:41 AM
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
	/// Data access class for the "SUBSTATION" table.
	/// </summary>
    /// 

    public class BO_SubstationExtraFields
    {
        public const string  ParishName = "PARISH_NAME";
    }

	[Serializable]
	public class BO_Substation : BO_SubstationBase
	{
	
		#region Class Level Variables

        private string _parishName;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Substation() : base()
        {
        }

        #endregion

        #region Properties

        public string ParishName
        {
            get{return _parishName;}
            set{_parishName = value;}
        }

        #endregion

        #region Methods (Public)

        public static BO_Substations SelectAllByPopsIntID(BO_ProviderPrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@PopsIntID", pk.PopsIntID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PARISHES_SUBSTATIONS_SelectByPopsIntID", ref ExecutionState);
            BO_Substations BO_Substations = PopulateObjectsFromReaderByPopsIntID(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Substations;
        }

        #endregion
		
		#region Methods (Private)

        internal static BO_Substations PopulateObjectsFromReaderByPopsIntID(IDataReader rdr)
        {

            BO_Substations list = new BO_Substations();

            while (rdr.Read())
            {
                BO_Substation obj = new BO_Substation();
                PopulateObjectFromReaderByPopsIntID(obj, rdr);
                list.Add(obj);
            }
            return list;
        }

        internal static void PopulateObjectFromReaderByPopsIntID(BO_Substation obj, IDataReader rdr)
        {

            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SubstationFields.PopsIntID)));
            obj.SubstationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SubstationFields.SubstationID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.Street)))
            {
                obj.Street = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.Street));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.ZipCode)))
            {
                obj.ZipCode = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.ZipCode));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.ZipCodeExtended)))
            {
                obj.ZipCodeExtended = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.ZipCodeExtended));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.StateCode)))
            {
                obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.StateCode));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.SubstationCityCode)))
            {
                obj.SubstationCityCode = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.SubstationCityCode));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.SubstationParishCode)))
            {
                obj.SubstationParishCode = rdr.GetString(rdr.GetOrdinal(BO_SubstationFields.SubstationParishCode));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationFields.NumSubstations)))
            {
                obj.NumSubstations = rdr.GetInt32(rdr.GetOrdinal(BO_SubstationFields.NumSubstations));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SubstationExtraFields.ParishName)))
            {
                obj.ParishName = rdr.GetString(rdr.GetOrdinal(BO_SubstationExtraFields.ParishName));
            }

        }

        #endregion

	}
	
}
