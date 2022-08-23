//
// Class	:	BO_OwnerOtherProviderBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:24 PM
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
	public class BO_OwnerOtherProviderFields
	{
		public const string OwnOtherProvID            = "OWN_OTHER_PROV_ID";
		public const string LegalEntityID             = "LEGAL_ENTITY_ID";
		public const string FacilityName              = "FACILITY_NAME";
		public const string FacilityAddress           = "FACILITY_ADDRESS";
		public const string ProviderNum               = "PROVIDER_NUM";
		public const string StateID                   = "STATE_ID";
	}
	
	/// <summary>
	/// Data access class for the "OWNER_OTHER_PROVIDER" table.
	/// </summary>
	[Serializable]
	public class BO_OwnerOtherProviderBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_ownOtherProvIDNonDefault	= null;
		private decimal?       	_legalEntityIDNonDefault 	= null;
		private string         	_facilityNameNonDefault  	= null;
		private string         	_facilityAddressNonDefault	= null;
		private string         	_providerNumNonDefault   	= null;
		private string         	_stateIDNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_OwnerOtherProviderBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? OwnOtherProvID
		{
			get 
			{ 
                return _ownOtherProvIDNonDefault;
			}
			set 
			{
            
                _ownOtherProvIDNonDefault = value; 
			}
		}

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
		/// This property is mapped to the "FACILITY_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string FacilityName
		{
			get 
			{ 
                if(_facilityNameNonDefault==null)return _facilityNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("FacilityName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _facilityNameNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_ADDRESS" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string FacilityAddress
		{
			get 
			{ 
                if(_facilityAddressNonDefault==null)return _facilityAddressNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityAddressNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("FacilityAddress length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _facilityAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityAddressNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROVIDER_NUM" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string ProviderNum
		{
			get 
			{ 
                if(_providerNumNonDefault==null)return _providerNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _providerNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("ProviderNum length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _providerNumNonDefault =null;//null value 
                }
                else
                {		           
		            _providerNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
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
              
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
              
			// Pass the value of '_facilityAddress' as parameter 'FacilityAddress' of the stored procedure.
			if(_facilityAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityAddress", _facilityAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityAddress", DBNull.Value );
              
			// Pass the value of '_providerNum' as parameter 'ProviderNum' of the stored procedure.
			if(_providerNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProviderNum", _providerNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProviderNum", DBNull.Value );
              
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNER_OTHER_PROVIDER_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
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
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
			// Pass the value of '_facilityAddress' as parameter 'FacilityAddress' of the stored procedure.
			if(_facilityAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityAddress", _facilityAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityAddress", DBNull.Value );
			// Pass the value of '_providerNum' as parameter 'ProviderNum' of the stored procedure.
			if(_providerNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProviderNum", _providerNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProviderNum", DBNull.Value );
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_ownOtherProvID' as parameter 'OwnOtherProvID' of the stored procedure.
			oDatabaseHelper.AddParameter("@OwnOtherProvID", _ownOtherProvIDNonDefault );
            
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault );
            
			// Pass the value of '_facilityAddress' as parameter 'FacilityAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityAddress", _facilityAddressNonDefault );
            
			// Pass the value of '_providerNum' as parameter 'ProviderNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProviderNum", _providerNumNonDefault );
            
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_ownOtherProvID' as parameter 'OwnOtherProvID' of the stored procedure.
			if(_ownOtherProvIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@OwnOtherProvID", _ownOtherProvIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@OwnOtherProvID", DBNull.Value );
			// Pass the value of '_legalEntityID' as parameter 'LegalEntityID' of the stored procedure.
			if(_legalEntityIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LegalEntityID", _legalEntityIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LegalEntityID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_OwnerOtherProviderPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_OwnerOtherProviderPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_OwnerOtherProviderFields">Field of the class BO_OwnerOtherProvider</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_OWNER_OTHER_PROVIDER_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_OwnerOtherProviderPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_OwnerOtherProvider</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_OwnerOtherProvider SelectOne(BO_OwnerOtherProviderPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNER_OTHER_PROVIDER_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_OwnerOtherProvider obj=new BO_OwnerOtherProvider();	
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
		/// <returns>list of objects of class BO_OwnerOtherProvider in the form of object of BO_OwnerOtherProviders </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_OwnerOtherProviders SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNER_OTHER_PROVIDER_SelectAll", ref ExecutionState);
			BO_OwnerOtherProviders BO_OwnerOtherProviders = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_OwnerOtherProviders;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_OwnerOtherProvider</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_OwnerOtherProvider in the form of an object of class BO_OwnerOtherProviders</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_OwnerOtherProviders SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNER_OTHER_PROVIDER_SelectByField", ref ExecutionState);
			BO_OwnerOtherProviders BO_OwnerOtherProviders = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_OwnerOtherProviders;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="LEGAL_ENTITYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_OwnerOtherProviders</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_OwnerOtherProviders SelectAllByForeignKeyLegalEntityID(BO_LegalEntityPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_OwnerOtherProviders obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_OWNER_OTHER_PROVIDER_SelectAllByForeignKeyLegalEntityID", ref ExecutionState);
			obj = new BO_OwnerOtherProviders();
			obj = BO_OwnerOtherProvider.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:24 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_OWNER_OTHER_PROVIDER_DeleteAllByForeignKeyLegalEntityID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:24 PM		Created function
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
		/// <param name="obj" type="OWNER_OTHER_PROVIDER">Object of OWNER_OTHER_PROVIDER to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_OwnerOtherProviderBase obj,IDataReader rdr) 
		{

			obj.OwnOtherProvID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnerOtherProviderFields.OwnOtherProvID)));
			obj.LegalEntityID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_OwnerOtherProviderFields.LegalEntityID)));
			obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_OwnerOtherProviderFields.FacilityName));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnerOtherProviderFields.FacilityAddress)))
			{
				obj.FacilityAddress = rdr.GetString(rdr.GetOrdinal(BO_OwnerOtherProviderFields.FacilityAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnerOtherProviderFields.ProviderNum)))
			{
				obj.ProviderNum = rdr.GetString(rdr.GetOrdinal(BO_OwnerOtherProviderFields.ProviderNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_OwnerOtherProviderFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_OwnerOtherProviderFields.StateID));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_OwnerOtherProviders</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_OwnerOtherProviders PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_OwnerOtherProviders list = new BO_OwnerOtherProviders();
			
			while (rdr.Read())
			{
				BO_OwnerOtherProvider obj = new BO_OwnerOtherProvider();
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
		/// <returns>Object of BO_OwnerOtherProviders</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:24 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_OwnerOtherProviders PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_OwnerOtherProviders list = new BO_OwnerOtherProviders();
			
            if (rdr.Read())
            {
                BO_OwnerOtherProvider obj = new BO_OwnerOtherProvider();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_OwnerOtherProvider();
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
