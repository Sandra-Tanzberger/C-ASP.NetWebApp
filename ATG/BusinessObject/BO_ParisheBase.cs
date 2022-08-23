//
// Class	:	BO_ParisheBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:18 PM
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
	public class BO_ParisheFields
	{
		public const string ParishCode                = "PARISH_CODE";
		public const string ParishName                = "PARISH_NAME";
		public const string DhhAdminRegion            = "DHH_ADMIN_REGION";
		public const string HssFieldOffice            = "HSS_FIELD_OFFICE";
	}
	
	/// <summary>
	/// Data access class for the "PARISHES" table.
	/// </summary>
	[Serializable]
	public class BO_ParisheBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_parishCodeNonDefault    	= null;
		private string         	_parishNameNonDefault    	= null;
		private int?           	_dhhAdminRegionNonDefault	= null;
		private int?           	_hssFieldOfficeNonDefault	= null;

		private BO_Addresses _bO_AddressesParishCode = null;
		private BO_LetterOfIntents _bO_LetterOfIntentsParishCode = null;
		private BO_ParishServeds _bO_ParishServedsParishCode = null;
		private BO_Providers _bO_ProvidersParishCode = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ParisheBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _parishCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _parishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _parishCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PARISH_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string ParishName
		{
			get 
			{ 
                if(_parishNameNonDefault==null)return _parishNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _parishNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("ParishName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _parishNameNonDefault =null;//null value 
                }
                else
                {		           
		            _parishNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DHH_ADMIN_REGION" field.  
		/// </summary>
		public int? DhhAdminRegion
		{
			get 
			{ 
                return _dhhAdminRegionNonDefault;
			}
			set 
			{
            
                _dhhAdminRegionNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "HSS_FIELD_OFFICE" field.  
		/// </summary>
		public int? HssFieldOffice
		{
			get 
			{ 
                return _hssFieldOfficeNonDefault;
			}
			set 
			{
            
                _hssFieldOfficeNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'ADDRESS'
		/// </summary>
		public BO_Addresses BO_AddressesParishCode
		{
			get 
			{
                if (_bO_AddressesParishCode == null)
                {
                    _bO_AddressesParishCode = new BO_Addresses();
                    _bO_AddressesParishCode = BO_Address.SelectByField("PARISH_CODE",ParishCode);
                }                
				return _bO_AddressesParishCode; 
			}
			set 
			{
				  _bO_AddressesParishCode = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LETTER_OF_INTENT'
		/// </summary>
		public BO_LetterOfIntents BO_LetterOfIntentsParishCode
		{
			get 
			{
                if (_bO_LetterOfIntentsParishCode == null)
                {
                    _bO_LetterOfIntentsParishCode = new BO_LetterOfIntents();
                    _bO_LetterOfIntentsParishCode = BO_LetterOfIntent.SelectByField("PARISH_CODE",ParishCode);
                }                
				return _bO_LetterOfIntentsParishCode; 
			}
			set 
			{
				  _bO_LetterOfIntentsParishCode = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PARISH_SERVED'
		/// </summary>
		public BO_ParishServeds BO_ParishServedsParishCode
		{
			get 
			{
                if (_bO_ParishServedsParishCode == null)
                {
                    _bO_ParishServedsParishCode = new BO_ParishServeds();
                    _bO_ParishServedsParishCode = BO_ParishServed.SelectByField("PARISH_CODE",ParishCode);
                }                
				return _bO_ParishServedsParishCode; 
			}
			set 
			{
				  _bO_ParishServedsParishCode = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDERS'
		/// </summary>
		public BO_Providers BO_ProvidersParishCode
		{
			get 
			{
                if (_bO_ProvidersParishCode == null)
                {
                    _bO_ProvidersParishCode = new BO_Providers();
                    _bO_ProvidersParishCode = BO_Provider.SelectByField("PARISH_CODE",ParishCode);
                }                
				return _bO_ProvidersParishCode; 
			}
			set 
			{
				  _bO_ProvidersParishCode = value;
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
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
              
			// Pass the value of '_parishName' as parameter 'ParishName' of the stored procedure.
			if(_parishNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishName", _parishNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishName", DBNull.Value );
              
			// Pass the value of '_dhhAdminRegion' as parameter 'DhhAdminRegion' of the stored procedure.
			if(_dhhAdminRegionNonDefault!=null)
              oDatabaseHelper.AddParameter("@DhhAdminRegion", _dhhAdminRegionNonDefault);
            else
              oDatabaseHelper.AddParameter("@DhhAdminRegion", DBNull.Value );
              
			// Pass the value of '_hssFieldOffice' as parameter 'HssFieldOffice' of the stored procedure.
			if(_hssFieldOfficeNonDefault!=null)
              oDatabaseHelper.AddParameter("@HssFieldOffice", _hssFieldOfficeNonDefault);
            else
              oDatabaseHelper.AddParameter("@HssFieldOffice", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PARISHES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
			// Pass the value of '_parishName' as parameter 'ParishName' of the stored procedure.
			if(_parishNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishName", _parishNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishName", DBNull.Value );
			// Pass the value of '_dhhAdminRegion' as parameter 'DhhAdminRegion' of the stored procedure.
			if(_dhhAdminRegionNonDefault!=null)
              oDatabaseHelper.AddParameter("@DhhAdminRegion", _dhhAdminRegionNonDefault);
            else
              oDatabaseHelper.AddParameter("@DhhAdminRegion", DBNull.Value );
			// Pass the value of '_hssFieldOffice' as parameter 'HssFieldOffice' of the stored procedure.
			if(_hssFieldOfficeNonDefault!=null)
              oDatabaseHelper.AddParameter("@HssFieldOffice", _hssFieldOfficeNonDefault);
            else
              oDatabaseHelper.AddParameter("@HssFieldOffice", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PARISHES_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            
			// Pass the value of '_parishName' as parameter 'ParishName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishName", _parishNameNonDefault );
            
			// Pass the value of '_dhhAdminRegion' as parameter 'DhhAdminRegion' of the stored procedure.
			oDatabaseHelper.AddParameter("@DhhAdminRegion", _dhhAdminRegionNonDefault );
            
			// Pass the value of '_hssFieldOffice' as parameter 'HssFieldOffice' of the stored procedure.
			oDatabaseHelper.AddParameter("@HssFieldOffice", _hssFieldOfficeNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PARISHES_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
                oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            else
                oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PARISHES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ParishePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ParishePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PARISHES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ParisheFields">Field of the class BO_Parishe</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PARISHES_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ParishePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Parishe</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishe SelectOne(BO_ParishePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Parishe obj=new BO_Parishe();	
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
		/// <returns>list of objects of class BO_Parishe in the form of object of BO_Parishes </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishes SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectAll", ref ExecutionState);
			BO_Parishes BO_Parishes = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Parishes;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Parishe</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Parishe in the form of an object of class BO_Parishes</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishes SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectByField", ref ExecutionState);
			BO_Parishes BO_Parishes = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Parishes;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PARISHES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishe SelectOneWithADDRESSUsingParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Parishe obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectOneWithADDRESSUsingParishCode", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Parishe();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AddressesParishCode=BO_Address.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PARISHES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishe SelectOneWithLETTER_OF_INTENTUsingParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Parishe obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectOneWithLETTER_OF_INTENTUsingParishCode", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Parishe();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LetterOfIntentsParishCode=BO_LetterOfIntent.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PARISHES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishe SelectOneWithPARISH_SERVEDUsingParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Parishe obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectOneWithPARISH_SERVEDUsingParishCode", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Parishe();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ParishServedsParishCode=BO_ParishServed.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PARISHES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Parishe SelectOneWithPROVIDERSUsingParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Parishe obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PARISHES_SelectOneWithPROVIDERSUsingParishCode", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Parishe();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProvidersParishCode=BO_Provider.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
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
	    /// DLGenerator			01/19/2012 12:30:18 PM		Created function
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
		/// <param name="obj" type="PARISHES">Object of PARISHES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ParisheBase obj,IDataReader rdr) 
		{

			obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_ParisheFields.ParishCode));
			obj.ParishName = rdr.GetString(rdr.GetOrdinal(BO_ParisheFields.ParishName));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ParisheFields.DhhAdminRegion)))
			{
				obj.DhhAdminRegion = rdr.GetInt32(rdr.GetOrdinal(BO_ParisheFields.DhhAdminRegion));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ParisheFields.HssFieldOffice)))
			{
				obj.HssFieldOffice = rdr.GetInt32(rdr.GetOrdinal(BO_ParisheFields.HssFieldOffice));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Parishes</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Parishes PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Parishes list = new BO_Parishes();
			
			while (rdr.Read())
			{
				BO_Parishe obj = new BO_Parishe();
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
		/// <returns>Object of BO_Parishes</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:18 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Parishes PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Parishes list = new BO_Parishes();
			
            if (rdr.Read())
            {
                BO_Parishe obj = new BO_Parishe();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Parishe();
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
