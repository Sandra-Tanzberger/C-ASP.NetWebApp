//
// Class	:	BO_EmploymentBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:30 PM
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
	public class BO_EmploymentFields
	{
		public const string EmploymentID              = "EMPLOYMENT_ID";
		public const string PersonID                  = "PERSON_ID";
		public const string StartDate                 = "START_DATE";
		public const string EndDate                   = "END_DATE";
		public const string FacilityName              = "FACILITY_NAME";
		public const string FacilityAddress           = "FACILITY_ADDRESS";
		public const string JobDutySummary            = "JOB_DUTY_SUMMARY";
	}
	
	/// <summary>
	/// Data access class for the "EMPLOYMENT" table.
	/// </summary>
	[Serializable]
	public class BO_EmploymentBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_employmentIDNonDefault  	= null;
		private decimal?       	_personIDNonDefault      	= null;
		private DateTime?      	_startDateNonDefault     	= null;
		private DateTime?      	_endDateNonDefault       	= null;
		private string         	_facilityNameNonDefault  	= null;
		private string         	_facilityAddressNonDefault	= null;
		private string         	_jobDutySummaryNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_EmploymentBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? EmploymentID
		{
			get 
			{ 
                return _employmentIDNonDefault;
			}
			set 
			{
            
                _employmentIDNonDefault = value; 
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
		/// This property is mapped to the "START_DATE" field.  
		/// </summary>
		public DateTime? StartDate
		{
			get 
			{ 
                return _startDateNonDefault;
			}
			set 
			{
            
                _startDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "END_DATE" field.  
		/// </summary>
		public DateTime? EndDate
		{
			get 
			{ 
                return _endDateNonDefault;
			}
			set 
			{
            
                _endDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_NAME" field. Length must be between 0 and 60 characters. Mandatory.
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
				   if (value != null && value.Length > 60)
					throw new ArgumentException("FacilityName length must be between 0 and 60 characters.");

				
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
		/// This property is mapped to the "FACILITY_ADDRESS" field. Length must be between 0 and 150 characters. Mandatory.
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
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 150)
					throw new ArgumentException("FacilityAddress length must be between 0 and 150 characters.");

				
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
		/// This property is mapped to the "JOB_DUTY_SUMMARY" field. Length must be between 0 and 512 characters. Mandatory.
		/// </summary>
		public string JobDutySummary
		{
			get 
			{ 
                if(_jobDutySummaryNonDefault==null)return _jobDutySummaryNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _jobDutySummaryNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 512)
					throw new ArgumentException("JobDutySummary length must be between 0 and 512 characters.");

				
                if(value ==null)
                {
                    _jobDutySummaryNonDefault =null;//null value 
                }
                else
                {		           
		            _jobDutySummaryNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
              
			// Pass the value of '_startDate' as parameter 'StartDate' of the stored procedure.
			if(_startDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StartDate", _startDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StartDate", DBNull.Value );
              
			// Pass the value of '_endDate' as parameter 'EndDate' of the stored procedure.
			if(_endDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EndDate", _endDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EndDate", DBNull.Value );
              
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
              
			// Pass the value of '_jobDutySummary' as parameter 'JobDutySummary' of the stored procedure.
			if(_jobDutySummaryNonDefault!=null)
              oDatabaseHelper.AddParameter("@JobDutySummary", _jobDutySummaryNonDefault);
            else
              oDatabaseHelper.AddParameter("@JobDutySummary", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EMPLOYMENT_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// Pass the value of '_startDate' as parameter 'StartDate' of the stored procedure.
			if(_startDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StartDate", _startDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StartDate", DBNull.Value );
			// Pass the value of '_endDate' as parameter 'EndDate' of the stored procedure.
			if(_endDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@EndDate", _endDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@EndDate", DBNull.Value );
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
			// Pass the value of '_jobDutySummary' as parameter 'JobDutySummary' of the stored procedure.
			if(_jobDutySummaryNonDefault!=null)
              oDatabaseHelper.AddParameter("@JobDutySummary", _jobDutySummaryNonDefault);
            else
              oDatabaseHelper.AddParameter("@JobDutySummary", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_employmentID' as parameter 'EmploymentID' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmploymentID", _employmentIDNonDefault );
            
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            
			// Pass the value of '_startDate' as parameter 'StartDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StartDate", _startDateNonDefault );
            
			// Pass the value of '_endDate' as parameter 'EndDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@EndDate", _endDateNonDefault );
            
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault );
            
			// Pass the value of '_facilityAddress' as parameter 'FacilityAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityAddress", _facilityAddressNonDefault );
            
			// Pass the value of '_jobDutySummary' as parameter 'JobDutySummary' of the stored procedure.
			oDatabaseHelper.AddParameter("@JobDutySummary", _jobDutySummaryNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_employmentID' as parameter 'EmploymentID' of the stored procedure.
			if(_employmentIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@EmploymentID", _employmentIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@EmploymentID", DBNull.Value );
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_EmploymentPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_EmploymentPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_EmploymentFields">Field of the class BO_Employment</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:29 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_EMPLOYMENT_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_EmploymentPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Employment</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Employment SelectOne(BO_EmploymentPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EMPLOYMENT_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Employment obj=new BO_Employment();	
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
		/// <returns>list of objects of class BO_Employment in the form of object of BO_Employments </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Employments SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EMPLOYMENT_SelectAll", ref ExecutionState);
			BO_Employments BO_Employments = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Employments;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Employment</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Employment in the form of an object of class BO_Employments</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Employments SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EMPLOYMENT_SelectByField", ref ExecutionState);
			BO_Employments BO_Employments = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Employments;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Employments</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Employments SelectAllByForeignKeyPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Employments obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EMPLOYMENT_SelectAllByForeignKeyPersonID", ref ExecutionState);
			obj = new BO_Employments();
			obj = BO_Employment.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:30 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_EMPLOYMENT_DeleteAllByForeignKeyPersonID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:30 PM		Created function
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
		/// <param name="obj" type="EMPLOYMENT">Object of EMPLOYMENT to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_EmploymentBase obj,IDataReader rdr) 
		{

			obj.EmploymentID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_EmploymentFields.EmploymentID)));
			obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_EmploymentFields.PersonID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_EmploymentFields.StartDate)))
			{
				obj.StartDate = rdr.GetDateTime(rdr.GetOrdinal(BO_EmploymentFields.StartDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_EmploymentFields.EndDate)))
			{
				obj.EndDate = rdr.GetDateTime(rdr.GetOrdinal(BO_EmploymentFields.EndDate));
			}
			
			obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_EmploymentFields.FacilityName));
			obj.FacilityAddress = rdr.GetString(rdr.GetOrdinal(BO_EmploymentFields.FacilityAddress));
			obj.JobDutySummary = rdr.GetString(rdr.GetOrdinal(BO_EmploymentFields.JobDutySummary));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Employments</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Employments PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Employments list = new BO_Employments();
			
			while (rdr.Read())
			{
				BO_Employment obj = new BO_Employment();
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
		/// <returns>Object of BO_Employments</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Employments PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Employments list = new BO_Employments();
			
            if (rdr.Read())
            {
                BO_Employment obj = new BO_Employment();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Employment();
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
