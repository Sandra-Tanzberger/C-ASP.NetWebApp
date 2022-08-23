//
// Class	:	BO_LegalEntityBase.cs
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
	public class BO_LegalEntityFields
	{
		public const string LegalEntityID             = "LEGAL_ENTITY_ID";
		public const string EntityName                = "ENTITY_NAME";
		public const string AddressID                 = "ADDRESS_ID";
		public const string EntityEin                 = "ENTITY_EIN";
		public const string EntityDba                 = "ENTITY_DBA";
		public const string EntityUrl                 = "ENTITY_URL";
		public const string EntityPhone               = "ENTITY_PHONE";
		public const string EntityFax                 = "ENTITY_FAX";
	}
	
	/// <summary>
	/// Data access class for the "LEGAL_ENTITY" table.
	/// </summary>
	[Serializable]
	public class BO_LegalEntityBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_legalEntityIDNonDefault 	= null;
		private string         	_entityNameNonDefault    	= null;
		private decimal?       	_addressIDNonDefault     	= null;
		private string         	_entityEinNonDefault     	= null;
		private string         	_entityDbaNonDefault     	= null;
		private string         	_entityUrlNonDefault     	= null;
		private string         	_entityPhoneNonDefault   	= null;
		private string         	_entityFaxNonDefault     	= null;

		private BO_OwnerOtherProviders _bO_OwnerOtherProvidersLegalEntityID = null;
		private BO_OwnerPeople _bO_OwnerPeopleLegalEntityID = null;
		private BO_Ownerships _bO_OwnershipsLegalEntityID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_LegalEntityBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
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
		/// This property is mapped to the "ENTITY_NAME" field. Length must be between 0 and 68 characters. 
		/// </summary>
		public string EntityName
		{
			get 
			{ 
                if(_entityNameNonDefault==null)return _entityNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 68)
					throw new ArgumentException("EntityName length must be between 0 and 68 characters.");

				
                if(value ==null)
                {
                    _entityNameNonDefault =null;//null value 
                }
                else
                {		           
		            _entityNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? AddressID
		{
			get 
			{ 
                return _addressIDNonDefault;
			}
			set 
			{
            
                _addressIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ENTITY_EIN" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string EntityEin
		{
			get 
			{ 
                if(_entityEinNonDefault==null)return _entityEinNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityEinNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("EntityEin length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _entityEinNonDefault =null;//null value 
                }
                else
                {		           
		            _entityEinNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENTITY_DBA" field. Length must be between 0 and 68 characters. 
		/// </summary>
		public string EntityDba
		{
			get 
			{ 
                if(_entityDbaNonDefault==null)return _entityDbaNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityDbaNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 68)
					throw new ArgumentException("EntityDba length must be between 0 and 68 characters.");

				
                if(value ==null)
                {
                    _entityDbaNonDefault =null;//null value 
                }
                else
                {		           
		            _entityDbaNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENTITY_URL" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string EntityUrl
		{
			get 
			{ 
                if(_entityUrlNonDefault==null)return _entityUrlNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityUrlNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("EntityUrl length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _entityUrlNonDefault =null;//null value 
                }
                else
                {		           
		            _entityUrlNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENTITY_PHONE" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string EntityPhone
		{
			get 
			{ 
                if(_entityPhoneNonDefault==null)return _entityPhoneNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityPhoneNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("EntityPhone length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _entityPhoneNonDefault =null;//null value 
                }
                else
                {		           
		            _entityPhoneNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENTITY_FAX" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string EntityFax
		{
			get 
			{ 
                if(_entityFaxNonDefault==null)return _entityFaxNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _entityFaxNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("EntityFax length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _entityFaxNonDefault =null;//null value 
                }
                else
                {		           
		            _entityFaxNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNER_OTHER_PROVIDER'
		/// </summary>
		public BO_OwnerOtherProviders BO_OwnerOtherProvidersLegalEntityID
		{
			get 
			{
                if (_bO_OwnerOtherProvidersLegalEntityID == null)
                {
                    _bO_OwnerOtherProvidersLegalEntityID = new BO_OwnerOtherProviders();
                    _bO_OwnerOtherProvidersLegalEntityID = BO_OwnerOtherProvider.SelectByField("LEGAL_ENTITY_ID",LegalEntityID);
                }                
				return _bO_OwnerOtherProvidersLegalEntityID; 
			}
			set 
			{
				  _bO_OwnerOtherProvidersLegalEntityID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNER_PERSON'
		/// </summary>
		public BO_OwnerPeople BO_OwnerPeopleLegalEntityID
		{
			get 
			{
                if (_bO_OwnerPeopleLegalEntityID == null)
                {
                    _bO_OwnerPeopleLegalEntityID = new BO_OwnerPeople();
                    _bO_OwnerPeopleLegalEntityID = BO_OwnerPerson.SelectByField("LEGAL_ENTITY_ID",LegalEntityID);
                }                
				return _bO_OwnerPeopleLegalEntityID; 
			}
			set 
			{
				  _bO_OwnerPeopleLegalEntityID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNERSHIP'
		/// </summary>
		public BO_Ownerships BO_OwnershipsLegalEntityID
		{
			get 
			{
                if (_bO_OwnershipsLegalEntityID == null)
                {
                    _bO_OwnershipsLegalEntityID = new BO_Ownerships();
                    _bO_OwnershipsLegalEntityID = BO_Ownership.SelectByField("LEGAL_ENTITY_ID",LegalEntityID);
                }                
				return _bO_OwnershipsLegalEntityID; 
			}
			set 
			{
				  _bO_OwnershipsLegalEntityID = value;
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
			
			// Pass the value of '_entityName' as parameter 'EntityName' of the stored procedure.
			if(_entityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityName", _entityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityName", DBNull.Value );
              
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
              
			// Pass the value of '_entityEin' as parameter 'EntityEin' of the stored procedure.
			if(_entityEinNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityEin", _entityEinNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityEin", DBNull.Value );
              
			// Pass the value of '_entityDba' as parameter 'EntityDba' of the stored procedure.
			if(_entityDbaNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityDba", _entityDbaNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityDba", DBNull.Value );
              
			// Pass the value of '_entityUrl' as parameter 'EntityUrl' of the stored procedure.
			if(_entityUrlNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityUrl", _entityUrlNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityUrl", DBNull.Value );
              
			// Pass the value of '_entityPhone' as parameter 'EntityPhone' of the stored procedure.
			if(_entityPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityPhone", _entityPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityPhone", DBNull.Value );
              
			// Pass the value of '_entityFax' as parameter 'EntityFax' of the stored procedure.
			if(_entityFaxNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityFax", _entityFaxNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityFax", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_entityName' as parameter 'EntityName' of the stored procedure.
			if(_entityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityName", _entityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityName", DBNull.Value );
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			if(_addressIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddressID", DBNull.Value );
			// Pass the value of '_entityEin' as parameter 'EntityEin' of the stored procedure.
			if(_entityEinNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityEin", _entityEinNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityEin", DBNull.Value );
			// Pass the value of '_entityDba' as parameter 'EntityDba' of the stored procedure.
			if(_entityDbaNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityDba", _entityDbaNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityDba", DBNull.Value );
			// Pass the value of '_entityUrl' as parameter 'EntityUrl' of the stored procedure.
			if(_entityUrlNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityUrl", _entityUrlNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityUrl", DBNull.Value );
			// Pass the value of '_entityPhone' as parameter 'EntityPhone' of the stored procedure.
			if(_entityPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityPhone", _entityPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityPhone", DBNull.Value );
			// Pass the value of '_entityFax' as parameter 'EntityFax' of the stored procedure.
			if(_entityFaxNonDefault!=null)
              oDatabaseHelper.AddParameter("@EntityFax", _entityFaxNonDefault);
            else
              oDatabaseHelper.AddParameter("@EntityFax", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_Insert", ref ExecutionState);
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
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            
			// Pass the value of '_entityName' as parameter 'EntityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityName", _entityNameNonDefault );
            
			// Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddressID", _addressIDNonDefault );
            
			// Pass the value of '_entityEin' as parameter 'EntityEin' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityEin", _entityEinNonDefault );
            
			// Pass the value of '_entityDba' as parameter 'EntityDba' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityDba", _entityDbaNonDefault );
            
			// Pass the value of '_entityUrl' as parameter 'EntityUrl' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityUrl", _entityUrlNonDefault );
            
			// Pass the value of '_entityPhone' as parameter 'EntityPhone' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityPhone", _entityPhoneNonDefault );
            
			// Pass the value of '_entityFax' as parameter 'EntityFax' of the stored procedure.
			oDatabaseHelper.AddParameter("@EntityFax", _entityFaxNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_Update", ref ExecutionState);
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
			
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			if(_legalEntityIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LegalEntityID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_LegalEntityPrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_LegalEntityPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_LegalEntityFields">Field of the class BO_LegalEntity</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LEGAL_ENTITY_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_LegalEntityPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LegalEntity</returns>
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
		public static BO_LegalEntity SelectOne(BO_LegalEntityPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_LegalEntity obj=new BO_LegalEntity();	
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
		/// <returns>list of objects of class BO_LegalEntity in the form of object of BO_LegalEntities </returns>
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
		public static BO_LegalEntities SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectAll", ref ExecutionState);
			BO_LegalEntities BO_LegalEntities = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LegalEntities;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_LegalEntity</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_LegalEntity in the form of an object of class BO_LegalEntities</returns>
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
		public static BO_LegalEntities SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectByField", ref ExecutionState);
			BO_LegalEntities BO_LegalEntities = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LegalEntities;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class LEGAL_ENTITY</returns>
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
		public static BO_LegalEntity SelectOneWithOWNER_OTHER_PROVIDERUsingLegalEntityID(BO_LegalEntityPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LegalEntity obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectOneWithOWNER_OTHER_PROVIDERUsingLegalEntityID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_LegalEntity();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnerOtherProvidersLegalEntityID=BO_OwnerOtherProvider.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class LEGAL_ENTITY</returns>
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
		public static BO_LegalEntity SelectOneWithOWNER_PERSONUsingLegalEntityID(BO_LegalEntityPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LegalEntity obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectOneWithOWNER_PERSONUsingLegalEntityID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_LegalEntity();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnerPeopleLegalEntityID=BO_OwnerPerson.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class LEGAL_ENTITY</returns>
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
		public static BO_LegalEntity SelectOneWithOWNERSHIPUsingLegalEntityID(BO_LegalEntityPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LegalEntity obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectOneWithOWNERSHIPUsingLegalEntityID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_LegalEntity();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnershipsLegalEntityID=BO_Ownership.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="ADDRESSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LegalEntities</returns>
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
		public static BO_LegalEntities SelectAllByForeignKeyAddressID(BO_AddressPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_LegalEntities obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LEGAL_ENTITY_SelectAllByForeignKeyAddressID", ref ExecutionState);
			obj = new BO_LegalEntities();
			obj = BO_LegalEntity.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ADDRESSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
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
		public static bool DeleteAllByForeignKeyAddressID(BO_AddressPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_LEGAL_ENTITY_DeleteAllByForeignKeyAddressID", ref ExecutionState);
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
		/// <param name="obj" type="LEGAL_ENTITY">Object of LEGAL_ENTITY to populate</param>
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
		internal static void PopulateObjectFromReader(BO_LegalEntityBase obj,IDataReader rdr) 
		{

			obj.LegalEntityID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LegalEntityFields.LegalEntityID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityName)))
			{
				obj.EntityName = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.AddressID)))
			{
				obj.AddressID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LegalEntityFields.AddressID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityEin)))
			{
				obj.EntityEin = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityEin));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityDba)))
			{
				obj.EntityDba = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityDba));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityUrl)))
			{
				obj.EntityUrl = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityUrl));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityPhone)))
			{
				obj.EntityPhone = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityPhone));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LegalEntityFields.EntityFax)))
			{
				obj.EntityFax = rdr.GetString(rdr.GetOrdinal(BO_LegalEntityFields.EntityFax));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_LegalEntities</returns>
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
		internal static BO_LegalEntities PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_LegalEntities list = new BO_LegalEntities();
			
			while (rdr.Read())
			{
				BO_LegalEntity obj = new BO_LegalEntity();
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
		/// <returns>Object of BO_LegalEntities</returns>
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
		internal static BO_LegalEntities PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_LegalEntities list = new BO_LegalEntities();
			
            if (rdr.Read())
            {
                BO_LegalEntity obj = new BO_LegalEntity();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_LegalEntity();
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
