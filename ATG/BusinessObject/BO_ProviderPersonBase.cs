//
// Class	:	BO_ProviderPersonBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/26/2012 12:21:26 AM
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
	public class BO_ProviderPersonFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string PersonID                  = "PERSON_ID";
		public const string IsCurrent                 = "IS_CURRENT";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string PersonType                = "PERSON_TYPE";
		public const string EffectiveDate             = "EFFECTIVE_DATE";
		public const string ExpirationDate            = "EXPIRATION_DATE";
		public const string PrimaryFacAdmin           = "PRIMARY_FAC_ADMIN";
	}
	
	/// <summary>
	/// Data access class for the "PROVIDER_PERSON" table.
	/// </summary>
	[Serializable]
	public class BO_ProviderPersonBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_personIDNonDefault      	= null;
		private int?           	_isCurrentNonDefault     	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_personTypeNonDefault    	= null;
		private DateTime?      	_effectiveDateNonDefault 	= null;
		private DateTime?      	_expirationDateNonDefault	= null;
		private string         	_primaryFacAdminNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ProviderPersonBase() { }
					
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
		public decimal? PersonID
		{
			get 
			{ 
                return _personIDNonDefault;
			}
			set 
			{
            
                _personIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_CURRENT" field.  
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
		/// This property is mapped to the "PERSON_TYPE" field. Length must be between 0 and 2 characters. Mandatory.
		/// </summary>
		public string PersonType
		{
			get 
			{ 
                if(_personTypeNonDefault==null)return _personTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _personTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 2)
					throw new ArgumentException("PersonType length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _personTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _personTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// This property is mapped to the "PRIMARY_FAC_ADMIN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string PrimaryFacAdmin
		{
			get 
			{ 
                if(_primaryFacAdminNonDefault==null)return _primaryFacAdminNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _primaryFacAdminNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("PrimaryFacAdmin length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _primaryFacAdminNonDefault =null;//null value 
                }
                else
                {		           
		            _primaryFacAdminNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
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
              
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
              
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			if(_isCurrentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsCurrent", DBNull.Value );
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_personType' as parameter 'PersonType' of the stored procedure.
			if(_personTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonType", _personTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonType", DBNull.Value );
              
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
              
			// Pass the value of '_primaryFacAdmin' as parameter 'PrimaryFacAdmin' of the stored procedure.
			if(_primaryFacAdminNonDefault!=null)
              oDatabaseHelper.AddParameter("@PrimaryFacAdmin", _primaryFacAdminNonDefault);
            else
              oDatabaseHelper.AddParameter("@PrimaryFacAdmin", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
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
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			if(_isCurrentNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsCurrent", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_personType' as parameter 'PersonType' of the stored procedure.
			if(_personTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonType", _personTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonType", DBNull.Value );
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
			// Pass the value of '_primaryFacAdmin' as parameter 'PrimaryFacAdmin' of the stored procedure.
			if(_primaryFacAdminNonDefault!=null)
              oDatabaseHelper.AddParameter("@PrimaryFacAdmin", _primaryFacAdminNonDefault);
            else
              oDatabaseHelper.AddParameter("@PrimaryFacAdmin", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_Insert", ref ExecutionState);
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
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
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
            
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            
			// Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsCurrent", _isCurrentNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_personType' as parameter 'PersonType' of the stored procedure.
			oDatabaseHelper.AddParameter("@PersonType", _personTypeNonDefault );
            
			// Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@EffectiveDate", _effectiveDateNonDefault );
            
			// Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpirationDate", _expirationDateNonDefault );
            
			// Pass the value of '_primaryFacAdmin' as parameter 'PrimaryFacAdmin' of the stored procedure.
			oDatabaseHelper.AddParameter("@PrimaryFacAdmin", _primaryFacAdminNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_Update", ref ExecutionState);
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
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
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
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderPersonPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ProviderPersonPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ProviderPersonFields">Field of the class BO_ProviderPerson</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDER_PERSON_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderPersonPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProviderPerson</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPerson SelectOne(BO_ProviderPersonPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_ProviderPerson obj=new BO_ProviderPerson();	
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
		/// <returns>list of objects of class BO_ProviderPerson in the form of object of BO_ProviderPeople </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPeople SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectAll", ref ExecutionState);
			BO_ProviderPeople BO_ProviderPeople = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProviderPeople;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ProviderPerson</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ProviderPerson in the form of an object of class BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPeople SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectByField", ref ExecutionState);
			BO_ProviderPeople BO_ProviderPeople = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProviderPeople;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPeople SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ProviderPeople obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_ProviderPeople();
			obj = BO_ProviderPerson.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDER_PERSON_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPeople SelectAllByForeignKeyPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ProviderPeople obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectAllByForeignKeyPersonID", ref ExecutionState);
			obj = new BO_ProviderPeople();
			obj = BO_ProviderPerson.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyPersonID(BO_PersonPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDER_PERSON_DeleteAllByForeignKeyPersonID", ref ExecutionState);
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
		/// <returns>object of class BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProviderPeople SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ProviderPeople obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDER_PERSON_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_ProviderPeople();
			obj = BO_ProviderPerson.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/26/2012 12:21:25 AM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDER_PERSON_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			06/26/2012 12:21:26 AM		Created function
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
		/// <param name="obj" type="PROVIDER_PERSON">Object of PROVIDER_PERSON to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:26 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ProviderPersonBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PopsIntID)));
			obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PersonID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.IsCurrent)))
			{
				obj.IsCurrent = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderPersonFields.IsCurrent));
			}
			
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.ApplicationID)));
			obj.PersonType = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonFields.PersonType));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate)))
			{
				obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate)))
			{
				obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.PrimaryFacAdmin)))
			{
				obj.PrimaryFacAdmin = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonFields.PrimaryFacAdmin));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:26 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProviderPeople PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ProviderPeople list = new BO_ProviderPeople();
			
			while (rdr.Read())
			{
				BO_ProviderPerson obj = new BO_ProviderPerson();
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
		/// <returns>Object of BO_ProviderPeople</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/26/2012 12:21:26 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProviderPeople PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ProviderPeople list = new BO_ProviderPeople();
			
            if (rdr.Read())
            {
                BO_ProviderPerson obj = new BO_ProviderPerson();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ProviderPerson();
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
