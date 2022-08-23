//
// Class	:	BO_ProgramStaffBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/20/2019 1:59:08 PM
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
	public class BO_ProgramStaffFields
	{
		public const string ProgramStaffID            = "PROGRAM_STAFF_ID";
		public const string FirstName                 = "FIRST_NAME";
		public const string LastName                  = "LAST_NAME";
		public const string StaffType                 = "STAFF_TYPE";
		public const string Allowedtypes              = "ALLOWEDTYPES";
		public const string Active                    = "ACTIVE";
		public const string AspenStaffID              = "ASPEN_STAFF_ID";
		public const string LoginID                   = "LOGIN_ID";
	}
	
	/// <summary>
	/// Data access class for the "PROGRAM_STAFF" table.
	/// </summary>
	[Serializable]
	public class BO_ProgramStaffBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_programStaffIDNonDefault	= null;
		private string         	_firstNameNonDefault     	= null;
		private string         	_lastNameNonDefault      	= null;
		private string         	_staffTypeNonDefault     	= null;
		private string         	_allowedtypesNonDefault  	= null;
		private bool?          	_activeNonDefault        	= null;
		private string         	_aspenStaffIDNonDefault  	= null;
		private string         	_loginIDNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ProgramStaffBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ProgramStaffID
		{
			get 
			{ 
                return _programStaffIDNonDefault;
			}
			set 
			{
            
                _programStaffIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FIRST_NAME" field. Length must be between 0 and 20 characters. Mandatory.
		/// </summary>
		public string FirstName
		{
			get 
			{ 
                if(_firstNameNonDefault==null)return _firstNameNonDefault;
				else return _firstNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 20)
					throw new ArgumentException("FirstName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _firstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _firstNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LastName
		{
			get 
			{ 
                if(_lastNameNonDefault==null)return _lastNameNonDefault;
				else return _lastNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("LastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _lastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _lastNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFF_TYPE" field. Length must be between 0 and 256 characters. 
		/// </summary>
		public string StaffType
		{
			get 
			{ 
                if(_staffTypeNonDefault==null)return _staffTypeNonDefault;
				else return _staffTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 256)
					throw new ArgumentException("StaffType length must be between 0 and 256 characters.");

				
                if(value ==null)
                {
                    _staffTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _staffTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ALLOWEDTYPES" field. Length must be between 0 and 256 characters. 
		/// </summary>
		public string Allowedtypes
		{
			get 
			{ 
                if(_allowedtypesNonDefault==null)return _allowedtypesNonDefault;
				else return _allowedtypesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 256)
					throw new ArgumentException("Allowedtypes length must be between 0 and 256 characters.");

				
                if(value ==null)
                {
                    _allowedtypesNonDefault =null;//null value 
                }
                else
                {		           
		            _allowedtypesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ACTIVE" field.  Mandatory.
		/// </summary>
		public bool? Active
		{
			get 
			{ 
                return _activeNonDefault;
			}
			set 
			{
            
                _activeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ASPEN_STAFF_ID" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string AspenStaffID
		{
			get 
			{ 
                if(_aspenStaffIDNonDefault==null)return _aspenStaffIDNonDefault;
				else return _aspenStaffIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("AspenStaffID length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _aspenStaffIDNonDefault =null;//null value 
                }
                else
                {		           
		            _aspenStaffIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LOGIN_ID" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string LoginID
		{
			get 
			{ 
                if(_loginIDNonDefault==null)return _loginIDNonDefault;
				else return _loginIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("LoginID length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _loginIDNonDefault =null;//null value 
                }
                else
                {		           
		            _loginIDNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			if(_firstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FirstName", DBNull.Value );
              
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			if(_lastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LastName", DBNull.Value );
              
			// Pass the value of '_staffType' as parameter 'StaffType' of the stored procedure.
			if(_staffTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffType", _staffTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffType", DBNull.Value );
              
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
              
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
              
			// Pass the value of '_aspenStaffID' as parameter 'AspenStaffID' of the stored procedure.
			if(_aspenStaffIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenStaffID", _aspenStaffIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenStaffID", DBNull.Value );
              
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			if(_loginIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LoginID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAM_STAFF_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			if(_firstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FirstName", DBNull.Value );
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			if(_lastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LastName", DBNull.Value );
			// Pass the value of '_staffType' as parameter 'StaffType' of the stored procedure.
			if(_staffTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffType", _staffTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffType", DBNull.Value );
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
			// Pass the value of '_aspenStaffID' as parameter 'AspenStaffID' of the stored procedure.
			if(_aspenStaffIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenStaffID", _aspenStaffIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenStaffID", DBNull.Value );
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			if(_loginIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LoginID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_Insert", ref ExecutionState);
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
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programStaffID' as parameter 'ProgramStaffID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramStaffID", _programStaffIDNonDefault );
            
			// Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FirstName", _firstNameNonDefault );
            
			// Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@LastName", _lastNameNonDefault );
            
			// Pass the value of '_staffType' as parameter 'StaffType' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffType", _staffTypeNonDefault );
            
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault );
            
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			oDatabaseHelper.AddParameter("@Active", _activeNonDefault );
            
			// Pass the value of '_aspenStaffID' as parameter 'AspenStaffID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AspenStaffID", _aspenStaffIDNonDefault );
            
			// Pass the value of '_loginID' as parameter 'LoginID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LoginID", _loginIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_Update", ref ExecutionState);
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
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programStaffID' as parameter 'ProgramStaffID' of the stored procedure.
			if(_programStaffIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ProgramStaffID", _programStaffIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ProgramStaffID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ProgramStaffPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ProgramStaffPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ProgramStaffFields">Field of the class BO_ProgramStaff</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAM_STAFF_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ProgramStaffPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ProgramStaff</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProgramStaff SelectOne(BO_ProgramStaffPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAM_STAFF_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_ProgramStaff obj=new BO_ProgramStaff();	
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
		/// <returns>list of objects of class BO_ProgramStaff in the form of object of BO_ProgramStaffs </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProgramStaffs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAM_STAFF_SelectAll", ref ExecutionState);
			BO_ProgramStaffs BO_ProgramStaffs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProgramStaffs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ProgramStaff</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ProgramStaff in the form of an object of class BO_ProgramStaffs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ProgramStaffs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAM_STAFF_SelectByField", ref ExecutionState);
			BO_ProgramStaffs BO_ProgramStaffs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ProgramStaffs;
			
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
	    /// DLGenerator			09/20/2019 1:59:08 PM		Created function
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
		/// <param name="obj" type="PROGRAM_STAFF">Object of PROGRAM_STAFF to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ProgramStaffBase obj,IDataReader rdr) 
		{

			obj.ProgramStaffID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProgramStaffFields.ProgramStaffID)));
			obj.FirstName = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.FirstName));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.LastName)))
			{
				obj.LastName = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.LastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.StaffType)))
			{
				obj.StaffType = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.StaffType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.Allowedtypes)))
			{
				obj.Allowedtypes = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.Allowedtypes));
			}
			
			obj.Active = rdr.GetBoolean(rdr.GetOrdinal(BO_ProgramStaffFields.Active));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.AspenStaffID)))
			{
				obj.AspenStaffID = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.AspenStaffID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.LoginID)))
			{
				obj.LoginID = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.LoginID));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ProgramStaffs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProgramStaffs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ProgramStaffs list = new BO_ProgramStaffs();
			
			while (rdr.Read())
			{
				BO_ProgramStaff obj = new BO_ProgramStaff();
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
		/// <returns>Object of BO_ProgramStaffs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/20/2019 1:59:08 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ProgramStaffs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ProgramStaffs list = new BO_ProgramStaffs();
			
            if (rdr.Read())
            {
                BO_ProgramStaff obj = new BO_ProgramStaff();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ProgramStaff();
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
