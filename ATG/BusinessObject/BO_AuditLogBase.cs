//
// Class	:	BO_AuditLogBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:26 PM
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
	public class BO_AuditLogFields
	{
		public const string AuditID                   = "AUDIT_ID";
		public const string TableName                 = "TABLE_NAME";
		public const string FieldName                 = "FIELD_NAME";
		public const string OldValue                  = "OLD_VALUE";
		public const string NewValue                  = "NEW_VALUE";
		public const string ChangeDatetime            = "CHANGE_DATETIME";
	}
	
	/// <summary>
	/// Data access class for the "AUDIT_LOG" table.
	/// </summary>
	[Serializable]
	public class BO_AuditLogBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_auditIDNonDefault       	= null;
		private string         	_tableNameNonDefault     	= null;
		private string         	_fieldNameNonDefault     	= null;
		private string         	_oldValueNonDefault      	= null;
		private string         	_newValueNonDefault      	= null;
		private DateTime?      	_changeDatetimeNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_AuditLogBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? AuditID
		{
			get 
			{ 
                return _auditIDNonDefault;
			}
			set 
			{
            
                _auditIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TABLE_NAME" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string TableName
		{
			get 
			{ 
                if(_tableNameNonDefault==null)return _tableNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _tableNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("TableName length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _tableNameNonDefault =null;//null value 
                }
                else
                {		           
		            _tableNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FIELD_NAME" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string FieldName
		{
			get 
			{ 
                if(_fieldNameNonDefault==null)return _fieldNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _fieldNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("FieldName length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _fieldNameNonDefault =null;//null value 
                }
                else
                {		           
		            _fieldNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OLD_VALUE" field. Length must be between 0 and 1000 characters. Mandatory.
		/// </summary>
		public string OldValue
		{
			get 
			{ 
                if(_oldValueNonDefault==null)return _oldValueNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _oldValueNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1000)
					throw new ArgumentException("OldValue length must be between 0 and 1000 characters.");

				
                if(value ==null)
                {
                    _oldValueNonDefault =null;//null value 
                }
                else
                {		           
		            _oldValueNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NEW_VALUE" field. Length must be between 0 and 1000 characters. Mandatory.
		/// </summary>
		public string NewValue
		{
			get 
			{ 
                if(_newValueNonDefault==null)return _newValueNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _newValueNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1000)
					throw new ArgumentException("NewValue length must be between 0 and 1000 characters.");

				
                if(value ==null)
                {
                    _newValueNonDefault =null;//null value 
                }
                else
                {		           
		            _newValueNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_DATETIME" field.  Mandatory.
		/// </summary>
		public DateTime? ChangeDatetime
		{
			get 
			{ 
                return _changeDatetimeNonDefault;
			}
			set 
			{
            
                _changeDatetimeNonDefault = value; 
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
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			if(_tableNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@TableName", DBNull.Value );
              
			// Pass the value of '_fieldName' as parameter 'FieldName' of the stored procedure.
			if(_fieldNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FieldName", _fieldNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FieldName", DBNull.Value );
              
			// Pass the value of '_oldValue' as parameter 'OldValue' of the stored procedure.
			if(_oldValueNonDefault!=null)
              oDatabaseHelper.AddParameter("@OldValue", _oldValueNonDefault);
            else
              oDatabaseHelper.AddParameter("@OldValue", DBNull.Value );
              
			// Pass the value of '_newValue' as parameter 'NewValue' of the stored procedure.
			if(_newValueNonDefault!=null)
              oDatabaseHelper.AddParameter("@NewValue", _newValueNonDefault);
            else
              oDatabaseHelper.AddParameter("@NewValue", DBNull.Value );
              
			// Pass the value of '_changeDatetime' as parameter 'ChangeDatetime' of the stored procedure.
			if(_changeDatetimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeDatetime", _changeDatetimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeDatetime", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AUDIT_LOG_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			if(_tableNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@TableName", DBNull.Value );
			// Pass the value of '_fieldName' as parameter 'FieldName' of the stored procedure.
			if(_fieldNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FieldName", _fieldNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FieldName", DBNull.Value );
			// Pass the value of '_oldValue' as parameter 'OldValue' of the stored procedure.
			if(_oldValueNonDefault!=null)
              oDatabaseHelper.AddParameter("@OldValue", _oldValueNonDefault);
            else
              oDatabaseHelper.AddParameter("@OldValue", DBNull.Value );
			// Pass the value of '_newValue' as parameter 'NewValue' of the stored procedure.
			if(_newValueNonDefault!=null)
              oDatabaseHelper.AddParameter("@NewValue", _newValueNonDefault);
            else
              oDatabaseHelper.AddParameter("@NewValue", DBNull.Value );
			// Pass the value of '_changeDatetime' as parameter 'ChangeDatetime' of the stored procedure.
			if(_changeDatetimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeDatetime", _changeDatetimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeDatetime", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_auditID' as parameter 'AuditID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AuditID", _auditIDNonDefault );
            
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault );
            
			// Pass the value of '_fieldName' as parameter 'FieldName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FieldName", _fieldNameNonDefault );
            
			// Pass the value of '_oldValue' as parameter 'OldValue' of the stored procedure.
			oDatabaseHelper.AddParameter("@OldValue", _oldValueNonDefault );
            
			// Pass the value of '_newValue' as parameter 'NewValue' of the stored procedure.
			oDatabaseHelper.AddParameter("@NewValue", _newValueNonDefault );
            
			// Pass the value of '_changeDatetime' as parameter 'ChangeDatetime' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeDatetime", _changeDatetimeNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_auditID' as parameter 'AuditID' of the stored procedure.
			if(_auditIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@AuditID", _auditIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@AuditID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_AuditLogPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_AuditLogPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_AuditLogFields">Field of the class BO_AuditLog</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_AUDIT_LOG_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_AuditLogPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_AuditLog</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AuditLog SelectOne(BO_AuditLogPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AUDIT_LOG_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_AuditLog obj=new BO_AuditLog();	
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
		/// <returns>list of objects of class BO_AuditLog in the form of object of BO_AuditLogs </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AuditLogs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AUDIT_LOG_SelectAll", ref ExecutionState);
			BO_AuditLogs BO_AuditLogs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_AuditLogs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_AuditLog</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_AuditLog in the form of an object of class BO_AuditLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AuditLogs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_AUDIT_LOG_SelectByField", ref ExecutionState);
			BO_AuditLogs BO_AuditLogs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_AuditLogs;
			
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
	    /// DLGenerator			01/19/2012 12:30:26 PM		Created function
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
		/// <param name="obj" type="AUDIT_LOG">Object of AUDIT_LOG to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_AuditLogBase obj,IDataReader rdr) 
		{

			obj.AuditID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AuditLogFields.AuditID)));
			obj.TableName = rdr.GetString(rdr.GetOrdinal(BO_AuditLogFields.TableName));
			obj.FieldName = rdr.GetString(rdr.GetOrdinal(BO_AuditLogFields.FieldName));
			obj.OldValue = rdr.GetString(rdr.GetOrdinal(BO_AuditLogFields.OldValue));
			obj.NewValue = rdr.GetString(rdr.GetOrdinal(BO_AuditLogFields.NewValue));
			obj.ChangeDatetime = rdr.GetDateTime(rdr.GetOrdinal(BO_AuditLogFields.ChangeDatetime));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_AuditLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_AuditLogs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_AuditLogs list = new BO_AuditLogs();
			
			while (rdr.Read())
			{
				BO_AuditLog obj = new BO_AuditLog();
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
		/// <returns>Object of BO_AuditLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:26 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_AuditLogs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_AuditLogs list = new BO_AuditLogs();
			
            if (rdr.Read())
            {
                BO_AuditLog obj = new BO_AuditLog();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_AuditLog();
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
