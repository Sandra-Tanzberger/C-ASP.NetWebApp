//
// Class	:	BO_ProgramBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:32 PM
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
	public class BO_ProgramFields
	{
		public const string ProgramID                 = "PROGRAM_ID";
		public const string ProgramDescription        = "PROGRAM_DESCRIPTION";
		public const string AspenTypecode             = "ASPEN_TYPECODE";
		public const string Active                    = "ACTIVE";
		public const string Licensed                  = "LICENSED";
		public const string Certified                 = "CERTIFIED";
	}
	
	/// <summary>
	/// Data access class for the "PROGRAMS" table.
	/// </summary>
	[Serializable]
	public class BO_ProgramBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_programIDNonDefault     	= null;
		private string         	_programDescriptionNonDefault	= null;
		private string         	_aspenTypecodeNonDefault 	= null;
		private bool?          	_activeNonDefault        	= true;
		private string         	_licensedNonDefault      	= null;
		private string         	_certifiedNonDefault     	= null;

		private BO_Applications _bO_ApplicationsProgramID = null;
		private BO_Fees _bO_FeesProgramID = null;
		private BO_LetterOfIntents _bO_LetterOfIntentsProgramID = null;
		private BO_ProgramBusinessProcesses _bO_ProgramBusinessProcessesProgramID = null;
		private BO_ProgramStaffs _bO_ProgramStaffsProgramID = null;
		private BO_Providers _bO_ProvidersProgramID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ProgramBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public string ProgramID
		{
			get 
			{ 
                if(_programIDNonDefault==null)return _programIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _programIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROGRAM_DESCRIPTION" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string ProgramDescription
		{
			get 
			{ 
                if(_programDescriptionNonDefault==null)return _programDescriptionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _programDescriptionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("ProgramDescription length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _programDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _programDescriptionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ASPEN_TYPECODE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string AspenTypecode
		{
			get 
			{ 
                if(_aspenTypecodeNonDefault==null)return _aspenTypecodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _aspenTypecodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("AspenTypecode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _aspenTypecodeNonDefault =null;//null value 
                }
                else
                {		           
		            _aspenTypecodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// This property is mapped to the "LICENSED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Licensed
		{
			get 
			{ 
                if(_licensedNonDefault==null)return _licensedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Licensed length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licensedNonDefault =null;//null value 
                }
                else
                {		           
		            _licensedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CERTIFIED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Certified
		{
			get 
			{ 
                if(_certifiedNonDefault==null)return _certifiedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _certifiedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Certified length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _certifiedNonDefault =null;//null value 
                }
                else
                {		           
		            _certifiedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATIONS'
		/// </summary>
		public BO_Applications BO_ApplicationsProgramID
		{
			get 
			{
                if (_bO_ApplicationsProgramID == null)
                {
                    _bO_ApplicationsProgramID = new BO_Applications();
                    _bO_ApplicationsProgramID = BO_Application.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_ApplicationsProgramID; 
			}
			set 
			{
				  _bO_ApplicationsProgramID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'FEES'
		/// </summary>
		public BO_Fees BO_FeesProgramID
		{
			get 
			{
                if (_bO_FeesProgramID == null)
                {
                    _bO_FeesProgramID = new BO_Fees();
                    _bO_FeesProgramID = BO_Fee.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_FeesProgramID; 
			}
			set 
			{
				  _bO_FeesProgramID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LETTER_OF_INTENT'
		/// </summary>
		public BO_LetterOfIntents BO_LetterOfIntentsProgramID
		{
			get 
			{
                if (_bO_LetterOfIntentsProgramID == null)
                {
                    _bO_LetterOfIntentsProgramID = new BO_LetterOfIntents();
                    _bO_LetterOfIntentsProgramID = BO_LetterOfIntent.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_LetterOfIntentsProgramID; 
			}
			set 
			{
				  _bO_LetterOfIntentsProgramID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROGRAM_BUSINESS_PROCESSES'
		/// </summary>
		public BO_ProgramBusinessProcesses BO_ProgramBusinessProcessesProgramID
		{
			get 
			{
                if (_bO_ProgramBusinessProcessesProgramID == null)
                {
                    _bO_ProgramBusinessProcessesProgramID = new BO_ProgramBusinessProcesses();
                    _bO_ProgramBusinessProcessesProgramID = BO_ProgramBusinessProcesse.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_ProgramBusinessProcessesProgramID; 
			}
			set 
			{
				  _bO_ProgramBusinessProcessesProgramID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROGRAM_STAFF'
		/// </summary>
		public BO_ProgramStaffs BO_ProgramStaffsProgramID
		{
			get 
			{
                if (_bO_ProgramStaffsProgramID == null)
                {
                    _bO_ProgramStaffsProgramID = new BO_ProgramStaffs();
                    _bO_ProgramStaffsProgramID = BO_ProgramStaff.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_ProgramStaffsProgramID; 
			}
			set 
			{
				  _bO_ProgramStaffsProgramID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDERS'
		/// </summary>
		public BO_Providers BO_ProvidersProgramID
		{
			get 
			{
                if (_bO_ProvidersProgramID == null)
                {
                    _bO_ProvidersProgramID = new BO_Providers();
                    _bO_ProvidersProgramID = BO_Provider.SelectByField("PROGRAM_ID",ProgramID);
                }                
				return _bO_ProvidersProgramID; 
			}
			set 
			{
				  _bO_ProvidersProgramID = value;
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_programDescription' as parameter 'ProgramDescription' of the stored procedure.
			if(_programDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramDescription", _programDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramDescription", DBNull.Value );
              
			// Pass the value of '_aspenTypecode' as parameter 'AspenTypecode' of the stored procedure.
			if(_aspenTypecodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenTypecode", _aspenTypecodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenTypecode", DBNull.Value );
              
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
              
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			if(_licensedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Licensed", DBNull.Value );
              
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			if(_certifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Certified", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_programDescription' as parameter 'ProgramDescription' of the stored procedure.
			if(_programDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramDescription", _programDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramDescription", DBNull.Value );
			// Pass the value of '_aspenTypecode' as parameter 'AspenTypecode' of the stored procedure.
			if(_aspenTypecodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenTypecode", _aspenTypecodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenTypecode", DBNull.Value );
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			if(_licensedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Licensed", DBNull.Value );
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			if(_certifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@Certified", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_programDescription' as parameter 'ProgramDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramDescription", _programDescriptionNonDefault );
            
			// Pass the value of '_aspenTypecode' as parameter 'AspenTypecode' of the stored procedure.
			oDatabaseHelper.AddParameter("@AspenTypecode", _aspenTypecodeNonDefault );
            
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			oDatabaseHelper.AddParameter("@Active", _activeNonDefault );
            
			// Pass the value of '_licensed' as parameter 'Licensed' of the stored procedure.
			oDatabaseHelper.AddParameter("@Licensed", _licensedNonDefault );
            
			// Pass the value of '_certified' as parameter 'Certified' of the stored procedure.
			oDatabaseHelper.AddParameter("@Certified", _certifiedNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ProgramPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ProgramPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ProgramFields">Field of the class BO_Program</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_PROGRAMS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ProgramPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Program</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOne(BO_ProgramPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Program obj=new BO_Program();	
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
		/// <returns>list of objects of class BO_Program in the form of object of BO_Programs </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Programs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectAll", ref ExecutionState);
			BO_Programs BO_Programs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Programs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Program</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Program in the form of an object of class BO_Programs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Programs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectByField", ref ExecutionState);
			BO_Programs BO_Programs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Programs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithAPPLICATIONSUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithAPPLICATIONSUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationsProgramID=BO_Application.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithFEESUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithFEESUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_FeesProgramID=BO_Fee.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithLETTER_OF_INTENTUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithLETTER_OF_INTENTUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LetterOfIntentsProgramID=BO_LetterOfIntent.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithPROGRAM_BUSINESS_PROCESSESUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithPROGRAM_BUSINESS_PROCESSESUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProgramBusinessProcessesProgramID=BO_ProgramBusinessProcesse.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithPROGRAM_STAFFUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithPROGRAM_STAFFUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProgramStaffsProgramID=BO_ProgramStaff.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROGRAMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Program SelectOneWithPROVIDERSUsingProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Program obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROGRAMS_SelectOneWithPROVIDERSUsingProgramID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Program();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProvidersProgramID=BO_Provider.PopulateObjectsFromReader(dr);
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
	    /// DLGenerator			01/19/2012 12:30:32 PM		Created function
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
		/// <param name="obj" type="PROGRAMS">Object of PROGRAMS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ProgramBase obj,IDataReader rdr) 
		{

			obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_ProgramFields.ProgramID));
			obj.ProgramDescription = rdr.GetString(rdr.GetOrdinal(BO_ProgramFields.ProgramDescription));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramFields.AspenTypecode)))
			{
				obj.AspenTypecode = rdr.GetString(rdr.GetOrdinal(BO_ProgramFields.AspenTypecode));
			}
			
			obj.Active = rdr.GetBoolean(rdr.GetOrdinal(BO_ProgramFields.Active));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramFields.Licensed)))
			{
				obj.Licensed = rdr.GetString(rdr.GetOrdinal(BO_ProgramFields.Licensed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramFields.Certified)))
			{
				obj.Certified = rdr.GetString(rdr.GetOrdinal(BO_ProgramFields.Certified));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Programs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Programs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Programs list = new BO_Programs();
			
			while (rdr.Read())
			{
				BO_Program obj = new BO_Program();
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
		/// <returns>Object of BO_Programs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Programs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Programs list = new BO_Programs();
			
            if (rdr.Read())
            {
                BO_Program obj = new BO_Program();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Program();
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
