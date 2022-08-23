//
// Class	:	BO_MdsdbAdmnlkupBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:33 AM
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
	public class BO_MdsdbAdmnlkupFields
	{
		public const string Adminid                   = "ADMINID";
		public const string Admsal                    = "ADMSAL";
		public const string Admfirst                  = "ADMFIRST";
		public const string Admmid                    = "ADMMID";
		public const string Admlast                   = "ADMLAST";
		public const string Admtitle                  = "ADMTITLE";
		public const string AdmSsn                    = "ADM_SSN";
		public const string AdmLic                    = "ADM_LIC";
		public const string Lictype                   = "LICTYPE";
		public const string Lictypedes                = "LICTYPEDES";
		public const string Licexpire                 = "LICEXPIRE";
		public const string Admtype                   = "ADMTYPE";
		public const string Admtypedes                = "ADMTYPEDES";
		public const string Created                   = "CREATED";
		public const string Admaddr                   = "ADMADDR";
		public const string Employeeid                = "EMPLOYEEID";
		public const string Admcity                   = "ADMCITY";
		public const string Admst                     = "ADMST";
		public const string Admzip                    = "ADMZIP";
		public const string Admphone                  = "ADMPHONE";
		public const string Admemail                  = "ADMEMAIL";
		public const string AdminrFax                 = "ADMINR_FAX";
	}
	
	/// <summary>
	/// Data access class for the "MDSDB_ADMNLKUP" table.
	/// </summary>
	[Serializable]
	public class BO_MdsdbAdmnlkupBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_adminidNonDefault       	= null;
		private string         	_admsalNonDefault        	= null;
		private string         	_admfirstNonDefault      	= null;
		private string         	_admmidNonDefault        	= null;
		private string         	_admlastNonDefault       	= null;
		private string         	_admtitleNonDefault      	= null;
		private string         	_admSsnNonDefault        	= null;
		private string         	_admLicNonDefault        	= null;
		private string         	_lictypeNonDefault       	= null;
		private string         	_lictypedesNonDefault    	= null;
		private DateTime?      	_licexpireNonDefault     	= null;
		private string         	_admtypeNonDefault       	= null;
		private string         	_admtypedesNonDefault    	= null;
		private DateTime?      	_createdNonDefault       	= null;
		private string         	_admaddrNonDefault       	= null;
		private string         	_employeeidNonDefault    	= null;
		private string         	_admcityNonDefault       	= null;
		private string         	_admstNonDefault         	= null;
		private string         	_admzipNonDefault        	= null;
		private string         	_admphoneNonDefault      	= null;
		private string         	_admemailNonDefault      	= null;
		private string         	_adminrFaxNonDefault     	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_MdsdbAdmnlkupBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? Adminid
		{
			get 
			{ 
                return _adminidNonDefault;
			}
			set 
			{
            
                _adminidNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMSAL" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string Admsal
		{
			get 
			{ 
                if(_admsalNonDefault==null)return _admsalNonDefault;
				else return _admsalNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("Admsal length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _admsalNonDefault =null;//null value 
                }
                else
                {		           
		            _admsalNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMFIRST" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string Admfirst
		{
			get 
			{ 
                if(_admfirstNonDefault==null)return _admfirstNonDefault;
				else return _admfirstNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("Admfirst length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _admfirstNonDefault =null;//null value 
                }
                else
                {		           
		            _admfirstNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMMID" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Admmid
		{
			get 
			{ 
                if(_admmidNonDefault==null)return _admmidNonDefault;
				else return _admmidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Admmid length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _admmidNonDefault =null;//null value 
                }
                else
                {		           
		            _admmidNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMLAST" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string Admlast
		{
			get 
			{ 
                if(_admlastNonDefault==null)return _admlastNonDefault;
				else return _admlastNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("Admlast length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _admlastNonDefault =null;//null value 
                }
                else
                {		           
		            _admlastNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMTITLE" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string Admtitle
		{
			get 
			{ 
                if(_admtitleNonDefault==null)return _admtitleNonDefault;
				else return _admtitleNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("Admtitle length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _admtitleNonDefault =null;//null value 
                }
                else
                {		           
		            _admtitleNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADM_SSN" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string AdmSsn
		{
			get 
			{ 
                if(_admSsnNonDefault==null)return _admSsnNonDefault;
				else return _admSsnNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("AdmSsn length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _admSsnNonDefault =null;//null value 
                }
                else
                {		           
		            _admSsnNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADM_LIC" field. Length must be between 0 and 14 characters. 
		/// </summary>
		public string AdmLic
		{
			get 
			{ 
                if(_admLicNonDefault==null)return _admLicNonDefault;
				else return _admLicNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 14)
					throw new ArgumentException("AdmLic length must be between 0 and 14 characters.");

				
                if(value ==null)
                {
                    _admLicNonDefault =null;//null value 
                }
                else
                {		           
		            _admLicNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICTYPE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string Lictype
		{
			get 
			{ 
                if(_lictypeNonDefault==null)return _lictypeNonDefault;
				else return _lictypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("Lictype length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _lictypeNonDefault =null;//null value 
                }
                else
                {		           
		            _lictypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICTYPEDES" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string Lictypedes
		{
			get 
			{ 
                if(_lictypedesNonDefault==null)return _lictypedesNonDefault;
				else return _lictypedesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("Lictypedes length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _lictypedesNonDefault =null;//null value 
                }
                else
                {		           
		            _lictypedesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICEXPIRE" field.  
		/// </summary>
		public DateTime? Licexpire
		{
			get 
			{ 
                return _licexpireNonDefault;
			}
			set 
			{
            
                _licexpireNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMTYPE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string Admtype
		{
			get 
			{ 
                if(_admtypeNonDefault==null)return _admtypeNonDefault;
				else return _admtypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("Admtype length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _admtypeNonDefault =null;//null value 
                }
                else
                {		           
		            _admtypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMTYPEDES" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string Admtypedes
		{
			get 
			{ 
                if(_admtypedesNonDefault==null)return _admtypedesNonDefault;
				else return _admtypedesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("Admtypedes length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _admtypedesNonDefault =null;//null value 
                }
                else
                {		           
		            _admtypedesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CREATED" field.  
		/// </summary>
		public DateTime? Created
		{
			get 
			{ 
                return _createdNonDefault;
			}
			set 
			{
            
                _createdNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMADDR" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string Admaddr
		{
			get 
			{ 
                if(_admaddrNonDefault==null)return _admaddrNonDefault;
				else return _admaddrNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("Admaddr length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _admaddrNonDefault =null;//null value 
                }
                else
                {		           
		            _admaddrNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMPLOYEEID" field. Length must be between 0 and 16 characters. 
		/// </summary>
		public string Employeeid
		{
			get 
			{ 
                if(_employeeidNonDefault==null)return _employeeidNonDefault;
				else return _employeeidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 16)
					throw new ArgumentException("Employeeid length must be between 0 and 16 characters.");

				
                if(value ==null)
                {
                    _employeeidNonDefault =null;//null value 
                }
                else
                {		           
		            _employeeidNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMCITY" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string Admcity
		{
			get 
			{ 
                if(_admcityNonDefault==null)return _admcityNonDefault;
				else return _admcityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("Admcity length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _admcityNonDefault =null;//null value 
                }
                else
                {		           
		            _admcityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMST" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string Admst
		{
			get 
			{ 
                if(_admstNonDefault==null)return _admstNonDefault;
				else return _admstNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("Admst length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _admstNonDefault =null;//null value 
                }
                else
                {		           
		            _admstNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMZIP" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string Admzip
		{
			get 
			{ 
                if(_admzipNonDefault==null)return _admzipNonDefault;
				else return _admzipNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("Admzip length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _admzipNonDefault =null;//null value 
                }
                else
                {		           
		            _admzipNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMPHONE" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string Admphone
		{
			get 
			{ 
                if(_admphoneNonDefault==null)return _admphoneNonDefault;
				else return _admphoneNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("Admphone length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _admphoneNonDefault =null;//null value 
                }
                else
                {		           
		            _admphoneNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMEMAIL" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string Admemail
		{
			get 
			{ 
                if(_admemailNonDefault==null)return _admemailNonDefault;
				else return _admemailNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("Admemail length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _admemailNonDefault =null;//null value 
                }
                else
                {		           
		            _admemailNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINR_FAX" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string AdminrFax
		{
			get 
			{ 
                if(_adminrFaxNonDefault==null)return _adminrFaxNonDefault;
				else return _adminrFaxNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("AdminrFax length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _adminrFaxNonDefault =null;//null value 
                }
                else
                {		           
		            _adminrFaxNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		#endregion
		
		#region Methods (Public)

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
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_adminid' as parameter 'Adminid' of the stored procedure.
			if(_adminidNonDefault!=null)
                oDatabaseHelper.AddParameter("@Adminid", _adminidNonDefault );
            else
                oDatabaseHelper.AddParameter("@Adminid", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMNLKUP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_MdsdbAdmnlkupPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_MdsdbAdmnlkupPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMNLKUP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_MdsdbAdmnlkupFields">Field of the class BO_MdsdbAdmnlkup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMNLKUP_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_MdsdbAdmnlkupPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_MdsdbAdmnlkup</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_MdsdbAdmnlkup SelectOne(BO_MdsdbAdmnlkupPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMNLKUP_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_MdsdbAdmnlkup obj=new BO_MdsdbAdmnlkup();	
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
		/// <returns>list of objects of class BO_MdsdbAdmnlkup in the form of object of BO_MdsdbAdmnlkups </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_MdsdbAdmnlkups SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMNLKUP_SelectAll", ref ExecutionState);
			BO_MdsdbAdmnlkups BO_MdsdbAdmnlkups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MdsdbAdmnlkups;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_MdsdbAdmnlkup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_MdsdbAdmnlkup in the form of an object of class BO_MdsdbAdmnlkups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_MdsdbAdmnlkups SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMNLKUP_SelectByField", ref ExecutionState);
			BO_MdsdbAdmnlkups BO_MdsdbAdmnlkups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MdsdbAdmnlkups;
			
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
	    /// DLGenerator			05/24/2011 11:58:33 AM		Created function
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
		/// <param name="obj" type="MDSDB_ADMNLKUP">Object of MDSDB_ADMNLKUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_MdsdbAdmnlkupBase obj,IDataReader rdr) 
		{

			obj.Adminid = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Adminid)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admsal)))
			{
				obj.Admsal = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admsal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admfirst)))
			{
				obj.Admfirst = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admfirst));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admmid)))
			{
				obj.Admmid = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admmid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admlast)))
			{
				obj.Admlast = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admlast));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtitle)))
			{
				obj.Admtitle = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtitle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdmSsn)))
			{
				obj.AdmSsn = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdmSsn));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdmLic)))
			{
				obj.AdmLic = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdmLic));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Lictype)))
			{
				obj.Lictype = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Lictype));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Lictypedes)))
			{
				obj.Lictypedes = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Lictypedes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Licexpire)))
			{
				obj.Licexpire = rdr.GetDateTime(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Licexpire));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtype)))
			{
				obj.Admtype = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtype));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtypedes)))
			{
				obj.Admtypedes = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admtypedes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Created)))
			{
				obj.Created = rdr.GetDateTime(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Created));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admaddr)))
			{
				obj.Admaddr = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admaddr));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Employeeid)))
			{
				obj.Employeeid = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Employeeid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admcity)))
			{
				obj.Admcity = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admcity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admst)))
			{
				obj.Admst = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admst));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admzip)))
			{
				obj.Admzip = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admzip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admphone)))
			{
				obj.Admphone = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admphone));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admemail)))
			{
				obj.Admemail = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.Admemail));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdminrFax)))
			{
				obj.AdminrFax = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdmnlkupFields.AdminrFax));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_MdsdbAdmnlkups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_MdsdbAdmnlkups PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_MdsdbAdmnlkups list = new BO_MdsdbAdmnlkups();
			
			while (rdr.Read())
			{
				BO_MdsdbAdmnlkup obj = new BO_MdsdbAdmnlkup();
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
		/// <returns>Object of BO_MdsdbAdmnlkups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_MdsdbAdmnlkups PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_MdsdbAdmnlkups list = new BO_MdsdbAdmnlkups();
			
            if (rdr.Read())
            {
                BO_MdsdbAdmnlkup obj = new BO_MdsdbAdmnlkup();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_MdsdbAdmnlkup();
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
