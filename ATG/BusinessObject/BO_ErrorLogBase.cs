//
// Class	:	BO_ErrorLogBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:22 PM
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
	public class BO_ErrorLogFields
	{
		public const string ErrorID                   = "ERROR_ID";
		public const string ErrorCD                   = "ERROR_CD";
		public const string ErrorMsg                  = "ERROR_MSG";
		public const string ErrorDatetime             = "ERROR_DATETIME";
	}
	
	/// <summary>
	/// Data access class for the "ERROR_LOG" table.
	/// </summary>
	[Serializable]
	public class BO_ErrorLogBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private int?           	_errorIDNonDefault       	= null;
		private string         	_errorCDNonDefault       	= null;
		private string         	_errorMsgNonDefault      	= null;
		private DateTime?      	_errorDatetimeNonDefault 	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ErrorLogBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "ERROR_ID" field.  Mandatory.
		/// </summary>
		public int? ErrorID
		{
			get 
			{ 
                return _errorIDNonDefault;
			}
			set 
			{
            
                _errorIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ERROR_CD" field. Length must be between 0 and 255 characters. 
		/// </summary>
		public string ErrorCD
		{
			get 
			{ 
                if(_errorCDNonDefault==null)return _errorCDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _errorCDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 255)
					throw new ArgumentException("ErrorCD length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _errorCDNonDefault =null;//null value 
                }
                else
                {		           
		            _errorCDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ERROR_MSG" field. Length must be between 0 and 1000 characters. 
		/// </summary>
		public string ErrorMsg
		{
			get 
			{ 
                if(_errorMsgNonDefault==null)return _errorMsgNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _errorMsgNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1000)
					throw new ArgumentException("ErrorMsg length must be between 0 and 1000 characters.");

				
                if(value ==null)
                {
                    _errorMsgNonDefault =null;//null value 
                }
                else
                {		           
		            _errorMsgNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ERROR_DATETIME" field.  
		/// </summary>
		public DateTime? ErrorDatetime
		{
			get 
			{ 
                return _errorDatetimeNonDefault;
			}
			set 
			{
            
                _errorDatetimeNonDefault = value; 
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
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_errorID' as parameter 'ErrorID' of the stored procedure.
			if(_errorIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorID", _errorIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorID", DBNull.Value );
              
			// Pass the value of '_errorCD' as parameter 'ErrorCD' of the stored procedure.
			if(_errorCDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorCD", _errorCDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorCD", DBNull.Value );
              
			// Pass the value of '_errorMsg' as parameter 'ErrorMsg' of the stored procedure.
			if(_errorMsgNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMsg", _errorMsgNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMsg", DBNull.Value );
              
			// Pass the value of '_errorDatetime' as parameter 'ErrorDatetime' of the stored procedure.
			if(_errorDatetimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorDatetime", _errorDatetimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorDatetime", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_ERROR_LOG_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_LOG_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_errorID' as parameter 'ErrorID' of the stored procedure.
			if(_errorIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorID", _errorIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorID", DBNull.Value );
			// Pass the value of '_errorCD' as parameter 'ErrorCD' of the stored procedure.
			if(_errorCDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorCD", _errorCDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorCD", DBNull.Value );
			// Pass the value of '_errorMsg' as parameter 'ErrorMsg' of the stored procedure.
			if(_errorMsgNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMsg", _errorMsgNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMsg", DBNull.Value );
			// Pass the value of '_errorDatetime' as parameter 'ErrorDatetime' of the stored procedure.
			if(_errorDatetimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorDatetime", _errorDatetimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorDatetime", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_ERROR_LOG_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_ErrorLog in the form of object of BO_ErrorLogs </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ErrorLogs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_LOG_SelectAll", ref ExecutionState);
			BO_ErrorLogs BO_ErrorLogs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ErrorLogs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ErrorLog</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ErrorLog in the form of an object of class BO_ErrorLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ErrorLogs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_LOG_SelectByField", ref ExecutionState);
			BO_ErrorLogs BO_ErrorLogs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ErrorLogs;
			
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
	    /// DLGenerator			01/19/2012 12:30:22 PM		Created function
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
		/// <param name="obj" type="ERROR_LOG">Object of ERROR_LOG to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ErrorLogBase obj,IDataReader rdr) 
		{

			obj.ErrorID = rdr.GetInt32(rdr.GetOrdinal(BO_ErrorLogFields.ErrorID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ErrorLogFields.ErrorCD)))
			{
				obj.ErrorCD = rdr.GetString(rdr.GetOrdinal(BO_ErrorLogFields.ErrorCD));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ErrorLogFields.ErrorMsg)))
			{
				obj.ErrorMsg = rdr.GetString(rdr.GetOrdinal(BO_ErrorLogFields.ErrorMsg));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ErrorLogFields.ErrorDatetime)))
			{
				obj.ErrorDatetime = rdr.GetDateTime(rdr.GetOrdinal(BO_ErrorLogFields.ErrorDatetime));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ErrorLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ErrorLogs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ErrorLogs list = new BO_ErrorLogs();
			
			while (rdr.Read())
			{
				BO_ErrorLog obj = new BO_ErrorLog();
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
		/// <returns>Object of BO_ErrorLogs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ErrorLogs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ErrorLogs list = new BO_ErrorLogs();
			
            if (rdr.Read())
            {
                BO_ErrorLog obj = new BO_ErrorLog();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ErrorLog();
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
