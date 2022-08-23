//
// Class	:	BO_OwnershipBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/12/2012 9:28:30 PM
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
	public class BO_OwnershipFields
	{
		public const string LegalEntityID             = "LEGAL_ENTITY_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string TypeOwnership             = "TYPE_OWNERSHIP";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string IsPrimary                 = "IS_PRIMARY";
		public const string OwnOtherProvider          = "OWN_OTHER_PROVIDER";
		public const string EffectiveDate             = "EFFECTIVE_DATE";
		public const string ExpireDate                = "EXPIRE_DATE";
		public const string PercentOwnership          = "PERCENT_OWNERSHIP";
		public const string TypeOwnershipOther        = "TYPE_OWNERSHIP_OTHER";
	}
	
	/// <summary>
	/// Data access class for the "OWNERSHIP" table.
	/// </summary>
	[Serializable]
	public class BO_OwnershipBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_legalEntityIDNonDefault 	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_typeOwnershipNonDefault 	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_isPrimaryNonDefault     	= null;
		private string         	_ownOtherProviderNonDefault	= null;
		private DateTime?      	_effectiveDateNonDefault 	= null;
		private DateTime?      	_expireDateNonDefault    	= null;
		private int?           	_percentOwnershipNonDefault	= null;
		private string         	_typeOwnershipOtherNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_OwnershipBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? LegalEntityID
		{
			get 
			{ 
                return _legalEntityIDNonDefault;
			}
			set 
			{
            
                _legalEntityIDNonDefault = value; 
			}
		}

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
		/// This property is mapped to the "TYPE_OWNERSHIP" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string TypeOwnership
		{
			get 
			{ 
                if(_typeOwnershipNonDefault==null)return _typeOwnershipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeOwnershipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("TypeOwnership length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _typeOwnershipNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOwnershipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? ApplicationID
		{
			get 
			{ 
                return _applicationIDNonDefault;
			}
			set 
			{
            
                _applicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_PRIMARY" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string IsPrimary
		{
			get 
			{ 
                if(_isPrimaryNonDefault==null)return _isPrimaryNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isPrimaryNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("IsPrimary length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _isPrimaryNonDefault =null;//null value 
                }
                else
                {		           
		            _isPrimaryNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OWN_OTHER_PROVIDER" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OwnOtherProvider
		{
			get 
			{ 
                if(_ownOtherProviderNonDefault==null)return _ownOtherProviderNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _ownOtherProviderNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OwnOtherProvider length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _ownOtherProviderNonDefault =null;//null value 
                }
                else
                {		           
		            _ownOtherProviderNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
		/// This property is mapped to the "EXPIRE_DATE" field.  
		/// </summary>
		public DateTime? ExpireDate
		{
			get 
			{ 
                return _expireDateNonDefault;
			}
			set 
			{
            
                _expireDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PERCENT_OWNERSHIP" field.  
		/// </summary>
		public int? PercentOwnership
		{
			get 
			{ 
                return _percentOwnershipNonDefault;
			}
			set 
			{
            
                _percentOwnershipNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_OWNERSHIP_OTHER" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string TypeOwnershipOther
		{
			get 
			{ 
                if(_typeOwnershipOtherNonDefault==null)return _typeOwnershipOtherNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeOwnershipOtherNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("TypeOwnershipOther length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _typeOwnershipOtherNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOwnershipOtherNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			if(_legalEntityIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LegalEntityID", DBNull.Value );
              
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_typeOwnership' as parameter 'TypeOwnership' of the stored procedure.
			if(_typeOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnership", _typeOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnership", DBNull.Value );
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_isPrimary' as parameter 'IsPrimary' of the stored procedure.
			if(_isPrimaryNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsPrimary", _isPrimaryNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsPrimary", DBNull.Value );
              
			// Pass the value of '_ownOtherProvider' as parameter 'OwnOtherProvider' of the stored procedure.
			if(_ownOtherProviderNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnOtherProvider", _ownOtherProviderNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnOtherProvider", DBNull.Value );
              
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			if(_effectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value );
              
			// Pass the value of '_expireDate' as parameter 'ExpireDate' of the stored procedure.
			if(_expireDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpireDate", _expireDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpireDate", DBNull.Value );
              
			// Pass the value of '_percentOwnership' as parameter 'PercentOwnership' of the stored procedure.
			if(_percentOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@PercentOwnership", _percentOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@PercentOwnership", DBNull.Value );
              
			// Pass the value of '_typeOwnershipOther' as parameter 'TypeOwnershipOther' of the stored procedure.
			if(_typeOwnershipOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnershipOther", _typeOwnershipOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnershipOther", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			if(_legalEntityIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LegalEntityID", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_typeOwnership' as parameter 'TypeOwnership' of the stored procedure.
			if(_typeOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnership", _typeOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnership", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_isPrimary' as parameter 'IsPrimary' of the stored procedure.
			if(_isPrimaryNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsPrimary", _isPrimaryNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsPrimary", DBNull.Value );
			// Pass the value of '_ownOtherProvider' as parameter 'OwnOtherProvider' of the stored procedure.
			if(_ownOtherProviderNonDefault!=null)
              oDatabaseHelper.AddParameter("@OwnOtherProvider", _ownOtherProviderNonDefault);
            else
              oDatabaseHelper.AddParameter("@OwnOtherProvider", DBNull.Value );
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			if(_effectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value );
			// Pass the value of '_expireDate' as parameter 'ExpireDate' of the stored procedure.
			if(_expireDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpireDate", _expireDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpireDate", DBNull.Value );
			// Pass the value of '_percentOwnership' as parameter 'PercentOwnership' of the stored procedure.
			if(_percentOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@PercentOwnership", _percentOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@PercentOwnership", DBNull.Value );
			// Pass the value of '_typeOwnershipOther' as parameter 'TypeOwnershipOther' of the stored procedure.
			if(_typeOwnershipOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnershipOther", _typeOwnershipOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnershipOther", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_Insert", ref ExecutionState);
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
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_typeOwnership' as parameter 'TypeOwnership' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOwnership", _typeOwnershipNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_isPrimary' as parameter 'IsPrimary' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsPrimary", _isPrimaryNonDefault );
            
			// Pass the value of '_ownOtherProvider' as parameter 'OwnOtherProvider' of the stored procedure.
			oDatabaseHelper.AddParameter("@OwnOtherProvider", _ownOtherProviderNonDefault );
            
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault );
            
			// Pass the value of '_expireDate' as parameter 'ExpireDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpireDate", _expireDateNonDefault );
            
			// Pass the value of '_percentOwnership' as parameter 'PercentOwnership' of the stored procedure.
			oDatabaseHelper.AddParameter("@PercentOwnership", _percentOwnershipNonDefault );
            
			// Pass the value of '_typeOwnershipOther' as parameter 'TypeOwnershipOther' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOwnershipOther", _typeOwnershipOtherNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_Update", ref ExecutionState);
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
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			if(_legalEntityIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LegalEntityID", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_OwnershipPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_OwnershipPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_OwnershipFields">Field of the class BO_Ownership</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNERSHIP_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_OwnershipPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Ownership</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownership SelectOne(BO_OwnershipPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Ownership obj=new BO_Ownership();	
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
		/// <returns>list of objects of class BO_Ownership in the form of object of BO_Ownerships </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownerships SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectAll", ref ExecutionState);
			BO_Ownerships BO_Ownerships = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ownerships;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Ownership</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Ownership in the form of an object of class BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownerships SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectByField", ref ExecutionState);
			BO_Ownerships BO_Ownerships = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ownerships;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownerships SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Ownerships obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Ownerships();
			obj = BO_Ownership.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_OWNERSHIP_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownerships SelectAllByForeignKeyLegalEntityID(BO_LegalEntityPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Ownerships obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectAllByForeignKeyLegalEntityID", ref ExecutionState);
			obj = new BO_Ownerships();
			obj = BO_Ownership.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyLegalEntityID(BO_LegalEntityPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_OWNERSHIP_DeleteAllByForeignKeyLegalEntityID", ref ExecutionState);
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
		/// <returns>object of class BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ownerships SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Ownerships obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNERSHIP_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Ownerships();
			obj = BO_Ownership.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/12/2012 9:28:30 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_OWNERSHIP_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			06/12/2012 9:28:30 PM		Created function
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
		/// <param name="obj" type="OWNERSHIP">Object of OWNERSHIP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_OwnershipBase obj,IDataReader rdr) 
		{

			obj.LegalEntityID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.LegalEntityID)));
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.PopsIntID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnership)))
			{
				obj.TypeOwnership = rdr.GetString(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnership));
			}
			
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnershipFields.ApplicationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.IsPrimary)))
			{
				obj.IsPrimary = rdr.GetString(rdr.GetOrdinal(BO_OwnershipFields.IsPrimary));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.OwnOtherProvider)))
			{
				obj.OwnOtherProvider = rdr.GetString(rdr.GetOrdinal(BO_OwnershipFields.OwnOtherProvider));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.EffectiveDate)))
			{
				obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_OwnershipFields.EffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.ExpireDate)))
			{
				obj.ExpireDate = rdr.GetDateTime(rdr.GetOrdinal(BO_OwnershipFields.ExpireDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.PercentOwnership)))
			{
				obj.PercentOwnership = rdr.GetInt32(rdr.GetOrdinal(BO_OwnershipFields.PercentOwnership));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnershipOther)))
			{
				obj.TypeOwnershipOther = rdr.GetString(rdr.GetOrdinal(BO_OwnershipFields.TypeOwnershipOther));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Ownerships PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Ownerships list = new BO_Ownerships();
			
			while (rdr.Read())
			{
				BO_Ownership obj = new BO_Ownership();
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
		/// <returns>Object of BO_Ownerships</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/12/2012 9:28:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Ownerships PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Ownerships list = new BO_Ownerships();
			
            if (rdr.Read())
            {
                BO_Ownership obj = new BO_Ownership();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Ownership();
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
