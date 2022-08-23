//
// Class	:	BO_StatusHistoryBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/15/2017 2:04:58 PM
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
	public class BO_StatusHistoryFields
	{
		public const string ApplicationID             = "APPLICATION_ID";
		public const string StatusID                  = "STATUS_ID";
		public const string ApplicationStatus         = "APPLICATION_STATUS";
		public const string StatusDate                = "STATUS_DATE";
		public const string Comment                   = "COMMENT";
	}
	
	/// <summary>
	/// Data access class for the "STATUS_HISTORY" table.
	/// </summary>
	[Serializable]
	public class BO_StatusHistoryBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_statusIDNonDefault      	= null;
		private string         	_applicationStatusNonDefault	= null;
		private DateTime?      	_statusDateNonDefault    	= null;
		private string         	_commentNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_StatusHistoryBase() { }
					
		#endregion
		
		#region Properties

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
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? StatusID
		{
			get 
			{ 
                return _statusIDNonDefault;
			}
			set 
			{
            
                _statusIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "APPLICATION_STATUS" field. Length must be between 0 and 1 characters. Mandatory.
		/// </summary>
		public string ApplicationStatus
		{
			get 
			{ 
                if(_applicationStatusNonDefault==null)return _applicationStatusNonDefault;
				else return _applicationStatusNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1)
					throw new ArgumentException("ApplicationStatus length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _applicationStatusNonDefault =null;//null value 
                }
                else
                {		           
		            _applicationStatusNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATUS_DATE" field.  
		/// </summary>
		public DateTime? StatusDate
		{
			get 
			{ 
                return _statusDateNonDefault;
			}
			set 
			{
            
                _statusDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "COMMENT" field. Length must be between 0 and 1024 characters. 
		/// </summary>
		public string Comment
		{
			get 
			{ 
                if(_commentNonDefault==null)return _commentNonDefault;
				else return _commentNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1024)
					throw new ArgumentException("Comment length must be between 0 and 1024 characters.");

				
                if(value ==null)
                {
                    _commentNonDefault =null;//null value 
                }
                else
                {		           
		            _commentNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			if(_applicationStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationStatus", DBNull.Value );
              
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
              
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			if(_commentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comment", _commentNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comment", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_STATUS_HISTORY_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			if(_applicationStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationStatus", DBNull.Value );
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			if(_commentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Comment", _commentNonDefault);
            else
              oDatabaseHelper.AddParameter("@Comment", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_Insert", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_statusID' as parameter 'StatusID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusID", _statusIDNonDefault );
            
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault );
            
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault );
            
			// Pass the value of '_comment' as parameter 'Comment' of the stored procedure.
			oDatabaseHelper.AddParameter("@Comment", _commentNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_Update", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_statusID' as parameter 'StatusID' of the stored procedure.
			if(_statusIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@StatusID", _statusIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@StatusID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_StatusHistoryPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_StatusHistoryPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_StatusHistoryFields">Field of the class BO_StatusHistory</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_STATUS_HISTORY_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_StatusHistoryPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_StatusHistory</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_StatusHistory SelectOne(BO_StatusHistoryPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_STATUS_HISTORY_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_StatusHistory obj=new BO_StatusHistory();	
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
		/// <returns>list of objects of class BO_StatusHistory in the form of object of BO_StatusHistories </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_StatusHistories SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_STATUS_HISTORY_SelectAll", ref ExecutionState);
			BO_StatusHistories BO_StatusHistories = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_StatusHistories;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_StatusHistory</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_StatusHistory in the form of an object of class BO_StatusHistories</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_StatusHistories SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_STATUS_HISTORY_SelectByField", ref ExecutionState);
			BO_StatusHistories BO_StatusHistories = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_StatusHistories;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_StatusHistories</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_StatusHistories SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_StatusHistories obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_STATUS_HISTORY_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_StatusHistories();
			obj = BO_StatusHistory.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/15/2017 2:04:58 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_STATUS_HISTORY_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
	    /// DLGenerator			06/15/2017 2:04:58 PM		Created function
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
		/// <param name="obj" type="STATUS_HISTORY">Object of STATUS_HISTORY to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_StatusHistoryBase obj,IDataReader rdr) 
		{

			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_StatusHistoryFields.ApplicationID)));
			obj.StatusID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_StatusHistoryFields.StatusID)));
			obj.ApplicationStatus = rdr.GetString(rdr.GetOrdinal(BO_StatusHistoryFields.ApplicationStatus));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_StatusHistoryFields.StatusDate)))
			{
				obj.StatusDate = rdr.GetDateTime(rdr.GetOrdinal(BO_StatusHistoryFields.StatusDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_StatusHistoryFields.Comment)))
			{
				obj.Comment = rdr.GetString(rdr.GetOrdinal(BO_StatusHistoryFields.Comment));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_StatusHistories</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_StatusHistories PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_StatusHistories list = new BO_StatusHistories();
			
			while (rdr.Read())
			{
				BO_StatusHistory obj = new BO_StatusHistory();
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
		/// <returns>Object of BO_StatusHistories</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:58 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_StatusHistories PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_StatusHistories list = new BO_StatusHistories();
			
            if (rdr.Read())
            {
                BO_StatusHistory obj = new BO_StatusHistory();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_StatusHistory();
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
