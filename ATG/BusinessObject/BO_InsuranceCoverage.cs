//
// Class	:	BO_InsuranceCoverage.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/24/2012 2:17:22 PM
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
    public class BO_InsuranceCoverageGridFields {
        public const string CarrierName = "CARRIER_NAME";
        public const string CoverageTypeDesc = "COVERAGE_TYPE_DESC";
    }
	
	/// <summary>
	/// Data access class for the "INSURANCE_COVERAGE" table.
	/// </summary>
	[Serializable]
	public class BO_InsuranceCoverage : BO_InsuranceCoverageBase
	{
	
		#region Class Level Variables
        private string _carrierName = null;
        private string _coverageTypeDesc = null;
        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_InsuranceCoverage() : base()
        {
        }

        #endregion

        #region Properties
        public string CarrierName
        {
            get { return _carrierName; }
            set { _carrierName = value; }
        }

        public string CoverageTypeDesc
        {
            get { return _coverageTypeDesc; }
            set { _coverageTypeDesc = value; }
        }
        #endregion

        #region Methods (Public)

        #endregion
		
		#region Methods (Private)

        #endregion

        public static BO_InsuranceCoverages SelectAllByPopsIntIdForGrid(decimal? popsIntId) {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_InsuranceCoverages obj = null;

            oDatabaseHelper.AddParameter("@PopsIntId", popsIntId);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_INSURANCE_COVERAGE_SelectAllByPopsIntIdForGrid", ref ExecutionState);
            obj = new BO_InsuranceCoverages();
            obj = BO_InsuranceCoverage.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        internal static BO_InsuranceCoverages PopulateObjectsFromReaderWithCheckingReaderForGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper) {
            BO_InsuranceCoverages list = new BO_InsuranceCoverages();

            if (rdr.Read()) {
                BO_InsuranceCoverage obj = new BO_InsuranceCoverage();
                PopulateObjectFromReaderForGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read()) {
                    obj = new BO_InsuranceCoverage();
                    PopulateObjectFromReaderForGrid(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        internal static void PopulateObjectFromReaderForGrid(BO_InsuranceCoverage obj, IDataReader rdr) {
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_InsuranceCoverageFields.PopsIntID)));
            obj.CarrierCode = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.CarrierCode));
            obj.CoverageType = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageType));
            obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.EffectiveDate));

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.ExpirationDate))) {
                obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.ExpirationDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.PolicyNum))) {
                obj.PolicyNum = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.PolicyNum));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageLimit))) {
                obj.CoverageLimit = rdr.GetDecimal(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageLimit));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.PrepaymentDueDate))) {
                obj.PrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.PrepaymentDueDate));
            }

            // custom fields

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageGridFields.CarrierName))) {
                obj.CarrierName = obj.CarrierCode + " - " + rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageGridFields.CarrierName));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageGridFields.CoverageTypeDesc))) {
                obj.CoverageTypeDesc = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageGridFields.CoverageTypeDesc));
            }
            
        }
	}
}
