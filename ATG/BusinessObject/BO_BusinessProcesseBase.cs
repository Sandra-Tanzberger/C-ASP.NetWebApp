//
// Class	:	BO_BusinessProcesseBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:23 PM
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
	public class BO_BusinessProcesseFields
	{
		public const string BusinessProcessID         = "BUSINESS_PROCESS_ID";
		public const string BusinessProcessName       = "BUSINESS_PROCESS_NAME";
		public const string Seq                       = "SEQ";
		public const string Allowedtypes              = "ALLOWEDTYPES";
	}
	
	/// <summary>
	/// Data access class for the "BUSINESS_PROCESSES" table.
	/// </summary>
	[Serializable]
	public class BO_BusinessProcesseBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_businessProcessIDNonDefault	= null;
		private string         	_businessProcessNameNonDefault	= null;
		private int?           	_seqNonDefault           	= null;
		private string         	_allowedtypesNonDefault  	= null;

		private BO_Applications _bO_ApplicationsBusinessProcessID = null;
		private BO_BsnsrlMstrs _bO_BsnsrlMstrsBusinessProcessID = null;
		private BO_ChecklistItems _bO_ChecklistItemsBusinessProcessID = null;
		private BO_ProgramBusinessProcesses _bO_ProgramBusinessProcessesBusinessProcessID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BusinessProcesseBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public string BusinessProcessID
		{
			get 
			{ 
                if(_businessProcessIDNonDefault==null)return _businessProcessIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _businessProcessIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("BusinessProcessID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _businessProcessIDNonDefault =null;//null value 
                }
                else
                {		           
		            _businessProcessIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BUSINESS_PROCESS_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string BusinessProcessName
		{
			get 
			{ 
                if(_businessProcessNameNonDefault==null)return _businessProcessNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _businessProcessNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("BusinessProcessName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _businessProcessNameNonDefault =null;//null value 
                }
                else
                {		           
		            _businessProcessNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SEQ" field.  
		/// </summary>
		public int? Seq
		{
			get 
			{ 
                return _seqNonDefault;
			}
			set 
			{
            
                _seqNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ALLOWEDTYPES" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string Allowedtypes
		{
			get 
			{ 
                if(_allowedtypesNonDefault==null)return _allowedtypesNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _allowedtypesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("Allowedtypes length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _allowedtypesNonDefault =null;//null value 
                }
                else
                {		           
		            _allowedtypesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATIONS'
		/// </summary>
		public BO_Applications BO_ApplicationsBusinessProcessID
		{
			get 
			{
                if (_bO_ApplicationsBusinessProcessID == null)
                {
                    _bO_ApplicationsBusinessProcessID = new BO_Applications();
                    _bO_ApplicationsBusinessProcessID = BO_Application.SelectByField("BUSINESS_PROCESS_ID",BusinessProcessID);
                }                
				return _bO_ApplicationsBusinessProcessID; 
			}
			set 
			{
				  _bO_ApplicationsBusinessProcessID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'BSNSRL_MSTR'
		/// </summary>
		public BO_BsnsrlMstrs BO_BsnsrlMstrsBusinessProcessID
		{
			get 
			{
                if (_bO_BsnsrlMstrsBusinessProcessID == null)
                {
                    _bO_BsnsrlMstrsBusinessProcessID = new BO_BsnsrlMstrs();
                    _bO_BsnsrlMstrsBusinessProcessID = BO_BsnsrlMstr.SelectByField("BUSINESS_PROCESS_ID",BusinessProcessID);
                }                
				return _bO_BsnsrlMstrsBusinessProcessID; 
			}
			set 
			{
				  _bO_BsnsrlMstrsBusinessProcessID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'CHECKLIST_ITEMS'
		/// </summary>
		public BO_ChecklistItems BO_ChecklistItemsBusinessProcessID
		{
			get 
			{
                if (_bO_ChecklistItemsBusinessProcessID == null)
                {
                    _bO_ChecklistItemsBusinessProcessID = new BO_ChecklistItems();
                    _bO_ChecklistItemsBusinessProcessID = BO_ChecklistItem.SelectByField("BUSINESS_PROCESS_ID",BusinessProcessID);
                }                
				return _bO_ChecklistItemsBusinessProcessID; 
			}
			set 
			{
				  _bO_ChecklistItemsBusinessProcessID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROGRAM_BUSINESS_PROCESSES'
		/// </summary>
		public BO_ProgramBusinessProcesses BO_ProgramBusinessProcessesBusinessProcessID
		{
			get 
			{
                if (_bO_ProgramBusinessProcessesBusinessProcessID == null)
                {
                    _bO_ProgramBusinessProcessesBusinessProcessID = new BO_ProgramBusinessProcesses();
                    _bO_ProgramBusinessProcessesBusinessProcessID = BO_ProgramBusinessProcesse.SelectByField("BUSINESS_PROCESS_ID",BusinessProcessID);
                }                
				return _bO_ProgramBusinessProcessesBusinessProcessID; 
			}
			set 
			{
				  _bO_ProgramBusinessProcessesBusinessProcessID = value;
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
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
              
			// Pass the value of '_businessProcessName' as parameter 'BusinessProcessName' of the stored procedure.
			if(_businessProcessNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessName", _businessProcessNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessName", DBNull.Value );
              
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			if(_seqNonDefault!=null)
              oDatabaseHelper.AddParameter("@Seq", _seqNonDefault);
            else
              oDatabaseHelper.AddParameter("@Seq", DBNull.Value );
              
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
			// Pass the value of '_businessProcessName' as parameter 'BusinessProcessName' of the stored procedure.
			if(_businessProcessNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessName", _businessProcessNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessName", DBNull.Value );
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			if(_seqNonDefault!=null)
              oDatabaseHelper.AddParameter("@Seq", _seqNonDefault);
            else
              oDatabaseHelper.AddParameter("@Seq", DBNull.Value );
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault );
            
			// Pass the value of '_businessProcessName' as parameter 'BusinessProcessName' of the stored procedure.
			oDatabaseHelper.AddParameter("@BusinessProcessName", _businessProcessNameNonDefault );
            
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			oDatabaseHelper.AddParameter("@Seq", _seqNonDefault );
            
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BusinessProcessePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BusinessProcessePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BusinessProcesseFields">Field of the class BO_BusinessProcesse</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BUSINESS_PROCESSES_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BusinessProcessePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BusinessProcesse</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesse SelectOne(BO_BusinessProcessePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BusinessProcesse obj=new BO_BusinessProcesse();	
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
		/// <returns>list of objects of class BO_BusinessProcesse in the form of object of BO_BusinessProcesses </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesses SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectAll", ref ExecutionState);
			BO_BusinessProcesses BO_BusinessProcesses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BusinessProcesses;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BusinessProcesse</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BusinessProcesse in the form of an object of class BO_BusinessProcesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesses SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectByField", ref ExecutionState);
			BO_BusinessProcesses BO_BusinessProcesses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BusinessProcesses;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BUSINESS_PROCESSES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesse SelectOneWithAPPLICATIONSUsingBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BusinessProcesse obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectOneWithAPPLICATIONSUsingBusinessProcessID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BusinessProcesse();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationsBusinessProcessID=BO_Application.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BUSINESS_PROCESSES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesse SelectOneWithBSNSRL_MSTRUsingBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BusinessProcesse obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectOneWithBSNSRL_MSTRUsingBusinessProcessID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BusinessProcesse();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BsnsrlMstrsBusinessProcessID=BO_BsnsrlMstr.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BUSINESS_PROCESSES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesse SelectOneWithCHECKLIST_ITEMSUsingBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BusinessProcesse obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectOneWithCHECKLIST_ITEMSUsingBusinessProcessID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BusinessProcesse();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ChecklistItemsBusinessProcessID=BO_ChecklistItem.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BUSINESS_PROCESSES</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BusinessProcesse SelectOneWithPROGRAM_BUSINESS_PROCESSESUsingBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BusinessProcesse obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BUSINESS_PROCESSES_SelectOneWithPROGRAM_BUSINESS_PROCESSESUsingBusinessProcessID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BusinessProcesse();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProgramBusinessProcessesBusinessProcessID=BO_ProgramBusinessProcesse.PopulateObjectsFromReader(dr);
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
	    /// DLGenerator			01/19/2012 12:30:23 PM		Created function
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
		/// <param name="obj" type="BUSINESS_PROCESSES">Object of BUSINESS_PROCESSES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BusinessProcesseBase obj,IDataReader rdr) 
		{

			obj.BusinessProcessID = rdr.GetString(rdr.GetOrdinal(BO_BusinessProcesseFields.BusinessProcessID));
			obj.BusinessProcessName = rdr.GetString(rdr.GetOrdinal(BO_BusinessProcesseFields.BusinessProcessName));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BusinessProcesseFields.Seq)))
			{
				obj.Seq = rdr.GetInt32(rdr.GetOrdinal(BO_BusinessProcesseFields.Seq));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BusinessProcesseFields.Allowedtypes)))
			{
				obj.Allowedtypes = rdr.GetString(rdr.GetOrdinal(BO_BusinessProcesseFields.Allowedtypes));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BusinessProcesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BusinessProcesses PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BusinessProcesses list = new BO_BusinessProcesses();
			
			while (rdr.Read())
			{
				BO_BusinessProcesse obj = new BO_BusinessProcesse();
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
		/// <returns>Object of BO_BusinessProcesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BusinessProcesses PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BusinessProcesses list = new BO_BusinessProcesses();
			
            if (rdr.Read())
            {
                BO_BusinessProcesse obj = new BO_BusinessProcesse();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BusinessProcesse();
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
