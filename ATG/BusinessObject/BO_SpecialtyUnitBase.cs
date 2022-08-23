//
// Class	:	BO_SpecialtyUnitBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:20 PM
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
	public class BO_SpecialtyUnitFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string SpecialtyUnitID           = "SPECIALTY_UNIT_ID";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string TypeSpecialtyUnit         = "TYPE_SPECIALTY_UNIT";
		public const string AffiliationID             = "AFFILIATION_ID";
		public const string SubtypeSpecialtyUnit      = "SUBTYPE_SPECIALTY_UNIT";
		public const string Level                     = "LEVEL";
		public const string StateID                   = "STATE_ID";
		public const string SurveyDate                = "SURVEY_DATE";
		public const string Ccn                       = "CCN";
	}
	
	/// <summary>
	/// Data access class for the "SPECIALTY_UNIT" table.
	/// </summary>
	[Serializable]
	public class BO_SpecialtyUnitBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_specialtyUnitIDNonDefault	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_typeSpecialtyUnitNonDefault	= null;
		private decimal?       	_affiliationIDNonDefault 	= null;
		private string         	_subtypeSpecialtyUnitNonDefault	= null;
		private string         	_levelNonDefault         	= null;
		private string         	_stateIDNonDefault       	= null;
		private DateTime?      	_surveyDateNonDefault    	= null;
		private string         	_ccnNonDefault           	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_SpecialtyUnitBase() { }
					
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
		public decimal? SpecialtyUnitID
		{
			get 
			{ 
                return _specialtyUnitIDNonDefault;
			}
			set 
			{
            
                _specialtyUnitIDNonDefault = value; 
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
		/// This property is mapped to the "TYPE_SPECIALTY_UNIT" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeSpecialtyUnit
		{
			get 
			{ 
                if(_typeSpecialtyUnitNonDefault==null)return _typeSpecialtyUnitNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeSpecialtyUnitNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeSpecialtyUnit length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeSpecialtyUnitNonDefault =null;//null value 
                }
                else
                {		           
		            _typeSpecialtyUnitNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? AffiliationID
		{
			get 
			{ 
                return _affiliationIDNonDefault;
			}
			set 
			{
            
                _affiliationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SUBTYPE_SPECIALTY_UNIT" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string SubtypeSpecialtyUnit
		{
			get 
			{ 
                if(_subtypeSpecialtyUnitNonDefault==null)return _subtypeSpecialtyUnitNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _subtypeSpecialtyUnitNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("SubtypeSpecialtyUnit length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _subtypeSpecialtyUnitNonDefault =null;//null value 
                }
                else
                {		           
		            _subtypeSpecialtyUnitNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LEVEL" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string Level
		{
			get 
			{ 
                if(_levelNonDefault==null)return _levelNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _levelNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("Level length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _levelNonDefault =null;//null value 
                }
                else
                {		           
		            _levelNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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

		/// <summary>
		/// This property is mapped to the "SURVEY_DATE" field.  
		/// </summary>
		public DateTime? SurveyDate
		{
			get 
			{ 
                return _surveyDateNonDefault;
			}
			set 
			{
            
                _surveyDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CCN" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string Ccn
		{
			get 
			{ 
                if(_ccnNonDefault==null)return _ccnNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _ccnNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("Ccn length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _ccnNonDefault =null;//null value 
                }
                else
                {		           
		            _ccnNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_typeSpecialtyUnit' as parameter 'TypeSpecialtyUnit' of the stored procedure.
			if(_typeSpecialtyUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeSpecialtyUnit", _typeSpecialtyUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeSpecialtyUnit", DBNull.Value );
              
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
              
			// Pass the value of '_subtypeSpecialtyUnit' as parameter 'SubtypeSpecialtyUnit' of the stored procedure.
			if(_subtypeSpecialtyUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubtypeSpecialtyUnit", _subtypeSpecialtyUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubtypeSpecialtyUnit", DBNull.Value );
              
			// Pass the value of '_level' as parameter 'Level' of the stored procedure.
			if(_levelNonDefault!=null)
              oDatabaseHelper.AddParameter("@Level", _levelNonDefault);
            else
              oDatabaseHelper.AddParameter("@Level", DBNull.Value );
              
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// Pass the value of '_surveyDate' as parameter 'SurveyDate' of the stored procedure.
			if(_surveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@SurveyDate", _surveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@SurveyDate", DBNull.Value );
              
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			if(_ccnNonDefault!=null)
              oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault);
            else
              oDatabaseHelper.AddParameter("@Ccn", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_typeSpecialtyUnit' as parameter 'TypeSpecialtyUnit' of the stored procedure.
			if(_typeSpecialtyUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeSpecialtyUnit", _typeSpecialtyUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeSpecialtyUnit", DBNull.Value );
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
			// Pass the value of '_subtypeSpecialtyUnit' as parameter 'SubtypeSpecialtyUnit' of the stored procedure.
			if(_subtypeSpecialtyUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubtypeSpecialtyUnit", _subtypeSpecialtyUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubtypeSpecialtyUnit", DBNull.Value );
			// Pass the value of '_level' as parameter 'Level' of the stored procedure.
			if(_levelNonDefault!=null)
              oDatabaseHelper.AddParameter("@Level", _levelNonDefault);
            else
              oDatabaseHelper.AddParameter("@Level", DBNull.Value );
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// Pass the value of '_surveyDate' as parameter 'SurveyDate' of the stored procedure.
			if(_surveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@SurveyDate", _surveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@SurveyDate", DBNull.Value );
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			if(_ccnNonDefault!=null)
              oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault);
            else
              oDatabaseHelper.AddParameter("@Ccn", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
            
			// Pass the value of '_specialtyUnitID' as parameter 'SpecialtyUnitID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SpecialtyUnitID", _specialtyUnitIDNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_typeSpecialtyUnit' as parameter 'TypeSpecialtyUnit' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeSpecialtyUnit", _typeSpecialtyUnitNonDefault );
            
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault );
            
			// Pass the value of '_subtypeSpecialtyUnit' as parameter 'SubtypeSpecialtyUnit' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubtypeSpecialtyUnit", _subtypeSpecialtyUnitNonDefault );
            
			// Pass the value of '_level' as parameter 'Level' of the stored procedure.
			oDatabaseHelper.AddParameter("@Level", _levelNonDefault );
            
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// Pass the value of '_surveyDate' as parameter 'SurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@SurveyDate", _surveyDateNonDefault );
            
			// Pass the value of '_ccn' as parameter 'Ccn' of the stored procedure.
			oDatabaseHelper.AddParameter("@Ccn", _ccnNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
			// Pass the value of '_specialtyUnitID' as parameter 'SpecialtyUnitID' of the stored procedure.
			if(_specialtyUnitIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@SpecialtyUnitID", _specialtyUnitIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@SpecialtyUnitID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_SpecialtyUnitPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_SpecialtyUnitPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_SpecialtyUnitFields">Field of the class BO_SpecialtyUnit</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SPECIALTY_UNIT_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_SpecialtyUnitPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_SpecialtyUnit</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnit SelectOne(BO_SpecialtyUnitPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_SpecialtyUnit obj=new BO_SpecialtyUnit();	
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
		/// <returns>list of objects of class BO_SpecialtyUnit in the form of object of BO_SpecialtyUnits </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnits SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectAll", ref ExecutionState);
			BO_SpecialtyUnits BO_SpecialtyUnits = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_SpecialtyUnits;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_SpecialtyUnit</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_SpecialtyUnit in the form of an object of class BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnits SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectByField", ref ExecutionState);
			BO_SpecialtyUnits BO_SpecialtyUnits = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_SpecialtyUnits;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnits SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_SpecialtyUnits obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_SpecialtyUnits();
			obj = BO_SpecialtyUnit.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SPECIALTY_UNIT_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnits SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_SpecialtyUnits obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_SpecialtyUnits();
			obj = BO_SpecialtyUnit.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SPECIALTY_UNIT_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_SpecialtyUnits SelectAllByForeignKeyAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_SpecialtyUnits obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SPECIALTY_UNIT_SelectAllByForeignKeyAffiliationID", ref ExecutionState);
			obj = new BO_SpecialtyUnits();
			obj = BO_SpecialtyUnit.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyAffiliationID(BO_AffiliationPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SPECIALTY_UNIT_DeleteAllByForeignKeyAffiliationID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
		/// <param name="obj" type="SPECIALTY_UNIT">Object of SPECIALTY_UNIT to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_SpecialtyUnitBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SpecialtyUnitFields.PopsIntID)));
			obj.SpecialtyUnitID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SpecialtyUnitFields.SpecialtyUnitID)));
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SpecialtyUnitFields.ApplicationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.TypeSpecialtyUnit)))
			{
				obj.TypeSpecialtyUnit = rdr.GetString(rdr.GetOrdinal(BO_SpecialtyUnitFields.TypeSpecialtyUnit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.AffiliationID)))
			{
				obj.AffiliationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_SpecialtyUnitFields.AffiliationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.SubtypeSpecialtyUnit)))
			{
				obj.SubtypeSpecialtyUnit = rdr.GetString(rdr.GetOrdinal(BO_SpecialtyUnitFields.SubtypeSpecialtyUnit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.Level)))
			{
				obj.Level = rdr.GetString(rdr.GetOrdinal(BO_SpecialtyUnitFields.Level));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_SpecialtyUnitFields.StateID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.SurveyDate)))
			{
				obj.SurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_SpecialtyUnitFields.SurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_SpecialtyUnitFields.Ccn)))
			{
				obj.Ccn = rdr.GetString(rdr.GetOrdinal(BO_SpecialtyUnitFields.Ccn));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_SpecialtyUnits PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_SpecialtyUnits list = new BO_SpecialtyUnits();
			
			while (rdr.Read())
			{
				BO_SpecialtyUnit obj = new BO_SpecialtyUnit();
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
		/// <returns>Object of BO_SpecialtyUnits</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_SpecialtyUnits PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_SpecialtyUnits list = new BO_SpecialtyUnits();
			
            if (rdr.Read())
            {
                BO_SpecialtyUnit obj = new BO_SpecialtyUnit();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_SpecialtyUnit();
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
