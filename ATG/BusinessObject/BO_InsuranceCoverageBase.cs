//
// Class	:	BO_InsuranceCoverageBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/23/2013 9:50:21 AM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using System.IO;
using System.Xml;
using ATG.Database;

namespace ATG.BusinessObject
{

	/// <summary>
	/// Class for the properties of the object
	/// </summary>
	public class BO_InsuranceCoverageFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string CarrierCode               = "CARRIER_CODE";
		public const string CoverageType              = "COVERAGE_TYPE";
		public const string EffectiveDate             = "EFFECTIVE_DATE";
		public const string ExpirationDate            = "EXPIRATION_DATE";
		public const string PolicyNum                 = "POLICY_NUM";
		public const string CoverageLimit             = "COVERAGE_LIMIT";
		public const string PrepaymentDueDate         = "PREPAYMENT_DUE_DATE";
	}
	
	/// <summary>
	/// Data access class for the "INSURANCE_COVERAGE" table.
	/// </summary>
	[Serializable]
	public class BO_InsuranceCoverageBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_carrierCodeNonDefault   	= null;
		private string         	_coverageTypeNonDefault  	= null;
		private DateTime?      	_effectiveDateNonDefault 	= null;
		private DateTime?      	_expirationDateNonDefault	= null;
		private string         	_policyNumNonDefault     	= null;
		private decimal?       	_coverageLimitNonDefault 	= null;
		private DateTime?      	_prepaymentDueDateNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_InsuranceCoverageBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public string CarrierCode
		{
			get 
			{ 
                if(_carrierCodeNonDefault==null)return _carrierCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _carrierCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("CarrierCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _carrierCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _carrierCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public string CoverageType
		{
			get 
			{ 
                if(_coverageTypeNonDefault==null)return _coverageTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _coverageTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("CoverageType length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _coverageTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _coverageTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public DateTime? EffectiveDate
		{
			get 
			{ 
                return _effectiveDateNonDefault;
			}
			set 
			{
            
                _effectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? ExpirationDate
		{
			get 
			{ 
                return _expirationDateNonDefault;
			}
			set 
			{
            
                _expirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "POLICY_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string PolicyNum
		{
			get 
			{ 
                if(_policyNumNonDefault==null)return _policyNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _policyNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("PolicyNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _policyNumNonDefault =null;//null value 
                }
                else
                {		           
		            _policyNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COVERAGE_LIMIT" field.  
		/// </summary>
		public decimal? CoverageLimit
		{
			get 
			{ 
                return _coverageLimitNonDefault;
			}
			set 
			{
            
                _coverageLimitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PREPAYMENT_DUE_DATE" field.  
		/// </summary>
		public DateTime? PrepaymentDueDate
		{
			get 
			{ 
                return _prepaymentDueDateNonDefault;
			}
			set 
			{
            
                _prepaymentDueDateNonDefault = value; 
			}
		}

		#endregion
		
		#region Methods (Public)

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
        /// <param name="getBackValues" type="bool">Whether to get the default values inserted, from the database</param>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_carrierCode' as parameter 'CarrierCode' of the stored procedure.
			if(_carrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CarrierCode", _carrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CarrierCode", DBNull.Value );
              
			// Pass the value of '_coverageType' as parameter 'CoverageType' of the stored procedure.
			if(_coverageTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CoverageType", _coverageTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CoverageType", DBNull.Value );
              
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			if(_effectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value );
              
			// Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
			if(_expirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpirationDate", _expirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpirationDate", DBNull.Value );
              
			// Pass the value of '_policyNum' as parameter 'PolicyNum' of the stored procedure.
			if(_policyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@PolicyNum", _policyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@PolicyNum", DBNull.Value );
              
			// Pass the value of '_coverageLimit' as parameter 'CoverageLimit' of the stored procedure.
			if(_coverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@CoverageLimit", _coverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@CoverageLimit", DBNull.Value );
              
			// Pass the value of '_prepaymentDueDate' as parameter 'PrepaymentDueDate' of the stored procedure.
			if(_prepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PrepaymentDueDate", _prepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PrepaymentDueDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
				if (dr.Read())
				{
					PopulateObjectFromReader(this,dr);
				}
				dr.Close();
			}
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_carrierCode' as parameter 'CarrierCode' of the stored procedure.
			if(_carrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CarrierCode", _carrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CarrierCode", DBNull.Value );
			// Pass the value of '_coverageType' as parameter 'CoverageType' of the stored procedure.
			if(_coverageTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CoverageType", _coverageTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CoverageType", DBNull.Value );
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			if(_effectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value );
			// Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
			if(_expirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpirationDate", _expirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpirationDate", DBNull.Value );
			// Pass the value of '_policyNum' as parameter 'PolicyNum' of the stored procedure.
			if(_policyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@PolicyNum", _policyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@PolicyNum", DBNull.Value );
			// Pass the value of '_coverageLimit' as parameter 'CoverageLimit' of the stored procedure.
			if(_coverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@CoverageLimit", _coverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@CoverageLimit", DBNull.Value );
			// Pass the value of '_prepaymentDueDate' as parameter 'PrepaymentDueDate' of the stored procedure.
			if(_prepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PrepaymentDueDate", _prepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PrepaymentDueDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Update one new row into the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_carrierCode' as parameter 'CarrierCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@CarrierCode", _carrierCodeNonDefault );
            
			// Pass the value of '_coverageType' as parameter 'CoverageType' of the stored procedure.
			oDatabaseHelper.AddParameter("@CoverageType", _coverageTypeNonDefault );
            
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault );
            
			// Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpirationDate", _expirationDateNonDefault );
            
			// Pass the value of '_policyNum' as parameter 'PolicyNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@PolicyNum", _policyNumNonDefault );
            
			// Pass the value of '_coverageLimit' as parameter 'CoverageLimit' of the stored procedure.
			oDatabaseHelper.AddParameter("@CoverageLimit", _coverageLimitNonDefault );
            
			// Pass the value of '_prepaymentDueDate' as parameter 'PrepaymentDueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@PrepaymentDueDate", _prepaymentDueDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_Update", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_carrierCode' as parameter 'CarrierCode' of the stored procedure.
			if(_carrierCodeNonDefault!=null)
                oDatabaseHelper.AddParameter("@CarrierCode", _carrierCodeNonDefault );
            else
                oDatabaseHelper.AddParameter("@CarrierCode", DBNull.Value );
			// Pass the value of '_coverageType' as parameter 'CoverageType' of the stored procedure.
			if(_coverageTypeNonDefault!=null)
                oDatabaseHelper.AddParameter("@CoverageType", _coverageTypeNonDefault );
            else
                oDatabaseHelper.AddParameter("@CoverageType", DBNull.Value );
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			if(_effectiveDateNonDefault!=null)
                oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault );
            else
                oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_InsuranceCoveragePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_InsuranceCoveragePrimaryKey pk) 
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_InsuranceCoverageFields">Field of the class BO_InsuranceCoverage</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_INSURANCE_COVERAGE_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_InsuranceCoveragePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_InsuranceCoverage</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_InsuranceCoverage SelectOne(BO_InsuranceCoveragePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_InsuranceCoverage obj=new BO_InsuranceCoverage();	
				PopulateObjectFromReader(obj,dr);
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

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_InsuranceCoverage in the form of object of BO_InsuranceCoverages </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_InsuranceCoverages SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_SelectAll", ref ExecutionState);
			BO_InsuranceCoverages BO_InsuranceCoverages = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_InsuranceCoverages;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_InsuranceCoverage</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_InsuranceCoverage in the form of an object of class BO_InsuranceCoverages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_InsuranceCoverages SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_SelectByField", ref ExecutionState);
			BO_InsuranceCoverages BO_InsuranceCoverages = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_InsuranceCoverages;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="INSURANCE_CARRIERPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_InsuranceCoverages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_InsuranceCoverages SelectAllByForeignKeyCarrierCode(BO_InsuranceCarrierPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_InsuranceCoverages obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_SelectAllByForeignKeyCarrierCode", ref ExecutionState);
			obj = new BO_InsuranceCoverages();
			obj = BO_InsuranceCoverage.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="INSURANCE_CARRIERPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyCarrierCode(BO_InsuranceCarrierPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_INSURANCE_COVERAGE_DeleteAllByForeignKeyCarrierCode", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_InsuranceCoverages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_InsuranceCoverages SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_InsuranceCoverages obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_INSURANCE_COVERAGE_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_InsuranceCoverages();
			obj = BO_InsuranceCoverage.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_INSURANCE_COVERAGE_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		#endregion	
		
        #region Methods (Private)

        /// <summary>
	    /// tests a string to be a well formed xml or not,
	    /// it throws ArgumentException when string text is not well formed.otherwise this 
        /// method is executed silently .
	    /// </summary>
	    /// <param name="text" type="string">xml string to validate.</param>
        /// <param name="fieldName" type="string">field Name to validate.</param>
	    /// <exception > throws ArgumentException when text is not well formed parameter.otherwise this 
        /// method is executed silently .</exception>
	    /// <remarks>
	    ///
	    /// <RevisionHistory>
	    /// Author				Date			Description
	    /// DLGenerator			01/23/2013 9:50:21 AM		Created function
	    /// 
	    /// </RevisionHistory>
	    ///
	    /// </remarks>
	    ///
	    internal static void IsValidXmlString(string text,string fieldName)
	    {
		    XmlTextReader r = new XmlTextReader(new StringReader(text));
		    try
		    {
			    while (r.Read())
			    {
                  /*do nothing ,just continue as long as xml is valid*/ 
                }
		    }
		    catch(Exception)
		    {
			    throw new ArgumentException ("Field ("+fieldName+") xml text argument isn't well formed");				
		    }
		    finally
		    {
			    r.Close();
  			
		    }
          //end silently(well formed xml)
	    }    
		/// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
		/// <param name="obj" type="INSURANCE_COVERAGE">Object of INSURANCE_COVERAGE to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_InsuranceCoverageBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_InsuranceCoverageFields.PopsIntID)));
			obj.CarrierCode = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.CarrierCode));
			obj.CoverageType = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageType));
			obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.EffectiveDate));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.ExpirationDate)))
			{
				obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.ExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.PolicyNum)))
			{
				obj.PolicyNum = rdr.GetString(rdr.GetOrdinal(BO_InsuranceCoverageFields.PolicyNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageLimit)))
			{
				obj.CoverageLimit = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_InsuranceCoverageFields.CoverageLimit)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_InsuranceCoverageFields.PrepaymentDueDate)))
			{
				obj.PrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_InsuranceCoverageFields.PrepaymentDueDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_InsuranceCoverages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_InsuranceCoverages PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_InsuranceCoverages list = new BO_InsuranceCoverages();
			
			while (rdr.Read())
			{
				BO_InsuranceCoverage obj = new BO_InsuranceCoverage();
				PopulateObjectFromReader(obj,rdr);
				list.Add(obj);
			}
			return list;
			
		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_InsuranceCoverages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/23/2013 9:50:21 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_InsuranceCoverages PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_InsuranceCoverages list = new BO_InsuranceCoverages();
			
            if (rdr.Read())
            {
                BO_InsuranceCoverage obj = new BO_InsuranceCoverage();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_InsuranceCoverage();
                    PopulateObjectFromReader(obj, rdr);
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

	
    #endregion

	}
}
