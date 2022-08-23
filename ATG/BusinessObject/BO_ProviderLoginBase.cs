//
// Class	:	BO_ProviderLoginBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	11/06/2012 11:33:44 AM
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
	public class BO_ProviderLoginFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string LoginID                   = "LOGIN_ID";
		public const string IsCurrent                 = "IS_CURRENT";
		public const string StateID                   = "STATE_ID";
		public const string IsConfirmed               = "IS_CONFIRMED";
		public const string EffectiveDate             = "EFFECTIVE_DATE";
		public const string ExpirationDate            = "EXPIRATION_DATE";
		public const string PassStaff                 = "PASS_STAFF";
		public const string AuthKey                   = "AUTH_KEY";
	}
	
	/// <summary>
	/// Data access class for the "PROVIDER_LOGIN" table.
	/// </summary>
	[Serializable]
	public class BO_ProviderLoginBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_loginIDNonDefault       	= null;
		private int?           	_isCurrentNonDefault     	= 1;
		private string         	_stateIDNonDefault       	= null;
		private int?           	_isConfirmedNonDefault   	= 0;
		private DateTime?      	_effectiveDateNonDefault 	= null;
		private DateTime?      	_expirationDateNonDefault	= null;
		private byte[]         	_passStaffNonDefault     	= null;
		private byte[]         	_authKeyNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ProviderLoginBase() { }
					
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
		public string LoginID
		{
			get 
			{ 
                if(_loginIDNonDefault==null)return _loginIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _loginIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 16)
					throw new ArgumentException("LoginID length must be between 0 and 16 characters.");

				
                if(value ==null)
                {
                    _loginIDNonDefault =null;//null value 
                }
                else
                {		           
		            _loginIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_CURRENT" field.  Mandatory.
		/// </summary>
		public int? IsCurrent
		{
			get 
			{ 
                return _isCurrentNonDefault;
			}
			set 
			{
            
                _isCurrentNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string StateID
		{
			get 
			{ 
                if(_stateIDNonDefault==null)return _stateIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("StateID length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _stateIDNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_CONFIRMED" field.  Mandatory.
		/// </summary>
		public int? IsConfirmed
		{
			get 
			{ 
                return _isConfirmedNonDefault;
			}
			set 
			{
            
                _isConfirmedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EFFECTIVE_DATE" field.  
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
		/// This property is mapped to the "PASS_STAFF" field.  
		/// </summary>
		public byte[] PassStaff
		{
			get 
			{ 
                return _passStaffNonDefault;
			}
			set 
			{
            
                _passStaffNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTH_KEY" field.  
		/// </summary>
		public byte[] AuthKey
		{
			get 
			{ 
                return _authKeyNonDefault;
			}
			set 
			{
            
                _authKeyNonDefault = value; 
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
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
              
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			if(_loginIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LoginID", DBNull.Value );
              
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			if(_isCurrentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsCurrent", DBNull.Value );
              
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// Pass the value of '_isConfirmed' as parameter 'IsConfirmed' of the stored procedure.
			if(_isConfirmedNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsConfirmed", _isConfirmedNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsConfirmed", DBNull.Value );
              
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
              
			// Pass the value of '_passStaff' as parameter 'PassStaff' of the stored procedure.
			if(_passStaffNonDefault!=null)
              oDatabaseHelper.AddParameter("@PassStaff", _passStaffNonDefault);
            else
              oDatabaseHelper.AddParameter("@PassStaff", DBNull.Value);			// Pass the value of '_authKey' as parameter 'AuthKey' of the stored procedure.
			if(_authKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthKey", _authKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthKey", DBNull.Value);			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_LOGIN_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			if(_loginIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LoginID", DBNull.Value );
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			if(_isCurrentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsCurrent", DBNull.Value );
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// Pass the value of '_isConfirmed' as parameter 'IsConfirmed' of the stored procedure.
			if(_isConfirmedNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsConfirmed", _isConfirmedNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsConfirmed", DBNull.Value );
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
			// Pass the value of '_passStaff' as parameter 'PassStaff' of the stored procedure.
			if(_passStaffNonDefault!=null)
              oDatabaseHelper.AddParameter("@PassStaff", _passStaffNonDefault);
            else
              oDatabaseHelper.AddParameter("@PassStaff", DBNull.Value);			// Pass the value of '_authKey' as parameter 'AuthKey' of the stored procedure.
			if(_authKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AuthKey", _authKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AuthKey", DBNull.Value);			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_Insert", ref ExecutionState);
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
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
            
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault );
            
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault );
            
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// Pass the value of '_isConfirmed' as parameter 'IsConfirmed' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsConfirmed", _isConfirmedNonDefault );
            
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault );
            
			// Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpirationDate", _expirationDateNonDefault );
            
			// Pass the value of '_passStaff' as parameter 'PassStaff' of the stored procedure.
			oDatabaseHelper.AddParameter("@PassStaff", _passStaffNonDefault );
            
			// Pass the value of '_authKey' as parameter 'AuthKey' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuthKey", _authKeyNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_Update", ref ExecutionState);
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
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			if(_loginIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LoginID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderLoginPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ProviderLoginPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ProviderLoginFields">Field of the class BO_ProviderLogin</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_LOGIN_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderLoginPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProviderLogin</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderLogin SelectOne(BO_ProviderLoginPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_LOGIN_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_ProviderLogin obj=new BO_ProviderLogin();	
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
		/// <returns>list of objects of class BO_ProviderLogin in the form of object of BO_ProviderLogins </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderLogins SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_LOGIN_SelectAll", ref ExecutionState);
			BO_ProviderLogins BO_ProviderLogins = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProviderLogins;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ProviderLogin</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ProviderLogin in the form of an object of class BO_ProviderLogins</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderLogins SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_LOGIN_SelectByField", ref ExecutionState);
			BO_ProviderLogins BO_ProviderLogins = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProviderLogins;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProviderLogins</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderLogins SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ProviderLogins obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_LOGIN_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_ProviderLogins();
			obj = BO_ProviderLogin.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			11/06/2012 11:33:44 AM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDER_LOGIN_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			11/06/2012 11:33:44 AM		Created function
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
		/// <param name="obj" type="PROVIDER_LOGIN">Object of PROVIDER_LOGIN to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ProviderLoginBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderLoginFields.PopsIntID)));
			obj.LoginID = rdr.GetString(rdr.GetOrdinal(BO_ProviderLoginFields.LoginID));
			obj.IsCurrent = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderLoginFields.IsCurrent));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderLoginFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_ProviderLoginFields.StateID));
			}
			
			obj.IsConfirmed = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderLoginFields.IsConfirmed));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderLoginFields.EffectiveDate)))
			{
				obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderLoginFields.EffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderLoginFields.ExpirationDate)))
			{
				obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderLoginFields.ExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderLoginFields.PassStaff)))
			{
				obj.PassStaff = (System.Byte[])rdr.GetValue(rdr.GetOrdinal(BO_ProviderLoginFields.PassStaff));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderLoginFields.AuthKey)))
			{
				obj.AuthKey = (System.Byte[])rdr.GetValue(rdr.GetOrdinal(BO_ProviderLoginFields.AuthKey));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ProviderLogins</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProviderLogins PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ProviderLogins list = new BO_ProviderLogins();
			
			while (rdr.Read())
			{
				BO_ProviderLogin obj = new BO_ProviderLogin();
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
		/// <returns>Object of BO_ProviderLogins</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			11/06/2012 11:33:44 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProviderLogins PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ProviderLogins list = new BO_ProviderLogins();
			
            if (rdr.Read())
            {
                BO_ProviderLogin obj = new BO_ProviderLogin();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ProviderLogin();
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
