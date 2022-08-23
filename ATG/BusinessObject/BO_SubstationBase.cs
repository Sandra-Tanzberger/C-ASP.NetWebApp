//
// Class	:	BO_SubstationBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/03/2013 3:28:28 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
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
	public class BO_SubstationFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string SubstationID              = "SUBSTATION_ID";
		public const string Street                    = "STREET";
		public const string ZipCode                   = "ZIP_CODE";
		public const string ZipCodeExtended           = "ZIP_CODE_EXTENDED";
		public const string StateCode                 = "STATE_CODE";
		public const string SubstationCityCode        = "SUBSTATION_CITY_CODE";
		public const string SubstationParishCode      = "SUBSTATION_PARISH_CODE";
		public const string NumSubstations            = "NUM_SUBSTATIONS";
	}
	
	/// <summary>
	/// Data access class for the "SUBSTATION" table.
	/// </summary>
	[Serializable]
	public class BO_SubstationBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_substationIDNonDefault  	= null;
		private string         	_streetNonDefault        	= null;
		private string         	_zipCodeNonDefault       	= null;
		private string         	_zipCodeExtendedNonDefault	= null;
		private string         	_stateCodeNonDefault     	= null;
		private string         	_substationCityCodeNonDefault	= null;
		private string         	_substationParishCodeNonDefault	= null;
		private int?           	_numSubstationsNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_SubstationBase() { }
					
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
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? SubstationID
		{
			get 
			{ 
                return _substationIDNonDefault;
			}
			set 
			{
            
                _substationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STREET" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string Street
		{
			get 
			{ 
                if(_streetNonDefault==null)return _streetNonDefault;
				else return _streetNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("Street length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _streetNonDefault =null;//null value 
                }
                else
                {		           
		            _streetNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZIP_CODE" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string ZipCode
		{
			get 
			{ 
                if(_zipCodeNonDefault==null)return _zipCodeNonDefault;
				else return _zipCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("ZipCode length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _zipCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _zipCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZIP_CODE_EXTENDED" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string ZipCodeExtended
		{
			get 
			{ 
                if(_zipCodeExtendedNonDefault==null)return _zipCodeExtendedNonDefault;
				else return _zipCodeExtendedNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("ZipCodeExtended length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _zipCodeExtendedNonDefault =null;//null value 
                }
                else
                {		           
		            _zipCodeExtendedNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_CODE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string StateCode
		{
			get 
			{ 
                if(_stateCodeNonDefault==null)return _stateCodeNonDefault;
				else return _stateCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("StateCode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _stateCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _stateCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SUBSTATION_CITY_CODE" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string SubstationCityCode
		{
			get 
			{ 
                if(_substationCityCodeNonDefault==null)return _substationCityCodeNonDefault;
				else return _substationCityCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("SubstationCityCode length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _substationCityCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _substationCityCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SUBSTATION_PARISH_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string SubstationParishCode
		{
			get 
			{ 
                if(_substationParishCodeNonDefault==null)return _substationParishCodeNonDefault;
				else return _substationParishCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("SubstationParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _substationParishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _substationParishCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_SUBSTATIONS" field.  
		/// </summary>
		public int? NumSubstations
		{
			get 
			{ 
                return _numSubstationsNonDefault;
			}
			set 
			{
            
                _numSubstationsNonDefault = value; 
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
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			if(_streetNonDefault!=null)
              oDatabaseHelper.AddParameter("@Street", _streetNonDefault);
            else
              oDatabaseHelper.AddParameter("@Street", DBNull.Value );
              
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			if(_zipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCode", DBNull.Value );
              
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			if(_zipCodeExtendedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCodeExtended", DBNull.Value );
              
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
              
			// Pass the value of '_substationCityCode' as parameter 'SubstationCityCode' of the stored procedure.
			if(_substationCityCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstationCityCode", _substationCityCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstationCityCode", DBNull.Value );
              
			// Pass the value of '_substationParishCode' as parameter 'SubstationParishCode' of the stored procedure.
			if(_substationParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstationParishCode", _substationParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstationParishCode", DBNull.Value );
              
			// Pass the value of '_numSubstations' as parameter 'NumSubstations' of the stored procedure.
			if(_numSubstationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumSubstations", _numSubstationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumSubstations", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SUBSTATION_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			if(_streetNonDefault!=null)
              oDatabaseHelper.AddParameter("@Street", _streetNonDefault);
            else
              oDatabaseHelper.AddParameter("@Street", DBNull.Value );
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			if(_zipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCode", DBNull.Value );
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			if(_zipCodeExtendedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZipCodeExtended", DBNull.Value );
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
			// Pass the value of '_substationCityCode' as parameter 'SubstationCityCode' of the stored procedure.
			if(_substationCityCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstationCityCode", _substationCityCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstationCityCode", DBNull.Value );
			// Pass the value of '_substationParishCode' as parameter 'SubstationParishCode' of the stored procedure.
			if(_substationParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstationParishCode", _substationParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstationParishCode", DBNull.Value );
			// Pass the value of '_numSubstations' as parameter 'NumSubstations' of the stored procedure.
			if(_numSubstationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumSubstations", _numSubstationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumSubstations", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_Insert", ref ExecutionState);
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
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_substationID' as parameter 'SubstationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubstationID", _substationIDNonDefault );
            
			// Pass the value of '_street' as parameter 'Street' of the stored procedure.
			oDatabaseHelper.AddParameter("@Street", _streetNonDefault );
            
			// Pass the value of '_zipCode' as parameter 'ZipCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZipCode", _zipCodeNonDefault );
            
			// Pass the value of '_zipCodeExtended' as parameter 'ZipCodeExtended' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZipCodeExtended", _zipCodeExtendedNonDefault );
            
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault );
            
			// Pass the value of '_substationCityCode' as parameter 'SubstationCityCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubstationCityCode", _substationCityCodeNonDefault );
            
			// Pass the value of '_substationParishCode' as parameter 'SubstationParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubstationParishCode", _substationParishCodeNonDefault );
            
			// Pass the value of '_numSubstations' as parameter 'NumSubstations' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumSubstations", _numSubstationsNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_Update", ref ExecutionState);
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
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_substationID' as parameter 'SubstationID' of the stored procedure.
			if(_substationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@SubstationID", _substationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@SubstationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_SubstationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_SubstationPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_SubstationFields">Field of the class BO_Substation</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SUBSTATION_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_SubstationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Substation</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Substation SelectOne(BO_SubstationPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SUBSTATION_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Substation obj=new BO_Substation();	
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
		/// <returns>list of objects of class BO_Substation in the form of object of BO_Substations </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Substations SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SUBSTATION_SelectAll", ref ExecutionState);
			BO_Substations BO_Substations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Substations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Substation</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Substation in the form of an object of class BO_Substations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Substations SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SUBSTATION_SelectByField", ref ExecutionState);
			BO_Substations BO_Substations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Substations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Substations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Substations SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Substations obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SUBSTATION_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Substations();
			obj = BO_Substation.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/03/2013 3:28:28 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SUBSTATION_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			01/03/2013 3:28:28 PM		Created function
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
		/// <param name="obj" type="SUBSTATION">Object of SUBSTATION to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_SubstationBase obj,IDataReader rdr) 
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
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Substations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Substations PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Substations list = new BO_Substations();
			
			while (rdr.Read())
			{
				BO_Substation obj = new BO_Substation();
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
		/// <returns>Object of BO_Substations</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/03/2013 3:28:28 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Substations PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Substations list = new BO_Substations();
			
            if (rdr.Read())
            {
                BO_Substation obj = new BO_Substation();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Substation();
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
