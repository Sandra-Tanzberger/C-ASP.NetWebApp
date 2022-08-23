//
// Class	:	BO_ErrorMessageLookupBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:21 PM
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
	public class BO_ErrorMessageLookupFields
	{
		public const string ErrorMessageKey           = "ERROR_MESSAGE_KEY";
		public const string ErrorMessageText          = "ERROR_MESSAGE_TEXT";
	}
	
	/// <summary>
	/// Data access class for the "ERROR_MESSAGE_LOOKUP" table.
	/// </summary>
	[Serializable]
	public class BO_ErrorMessageLookupBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_errorMessageKeyNonDefault	= null;
		private string         	_errorMessageTextNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ErrorMessageLookupBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "ERROR_MESSAGE_KEY" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string ErrorMessageKey
		{
			get 
			{ 
                if(_errorMessageKeyNonDefault==null)return _errorMessageKeyNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _errorMessageKeyNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("ErrorMessageKey length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _errorMessageKeyNonDefault =null;//null value 
                }
                else
                {		           
		            _errorMessageKeyNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ERROR_MESSAGE_TEXT" field. Length must be between 0 and 255 characters. Mandatory.
		/// </summary>
		public string ErrorMessageText
		{
			get 
			{ 
                if(_errorMessageTextNonDefault==null)return _errorMessageTextNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _errorMessageTextNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 255)
					throw new ArgumentException("ErrorMessageText length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _errorMessageTextNonDefault =null;//null value 
                }
                else
                {		           
		            _errorMessageTextNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_errorMessageKey' as parameter 'ErrorMessageKey' of the stored procedure.
			if(_errorMessageKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMessageKey", _errorMessageKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMessageKey", DBNull.Value );
              
			// Pass the value of '_errorMessageText' as parameter 'ErrorMessageText' of the stored procedure.
			if(_errorMessageTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMessageText", _errorMessageTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMessageText", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_ERROR_MESSAGE_LOOKUP_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_MESSAGE_LOOKUP_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_errorMessageKey' as parameter 'ErrorMessageKey' of the stored procedure.
			if(_errorMessageKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMessageKey", _errorMessageKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMessageKey", DBNull.Value );
			// Pass the value of '_errorMessageText' as parameter 'ErrorMessageText' of the stored procedure.
			if(_errorMessageTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@ErrorMessageText", _errorMessageTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@ErrorMessageText", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_ERROR_MESSAGE_LOOKUP_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_ErrorMessageLookup in the form of object of BO_ErrorMessageLookups </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ErrorMessageLookups SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_MESSAGE_LOOKUP_SelectAll", ref ExecutionState);
			BO_ErrorMessageLookups BO_ErrorMessageLookups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ErrorMessageLookups;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ErrorMessageLookup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ErrorMessageLookup in the form of an object of class BO_ErrorMessageLookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ErrorMessageLookups SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ERROR_MESSAGE_LOOKUP_SelectByField", ref ExecutionState);
			BO_ErrorMessageLookups BO_ErrorMessageLookups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ErrorMessageLookups;
			
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
	    /// DLGenerator			01/19/2012 12:30:21 PM		Created function
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
		/// <param name="obj" type="ERROR_MESSAGE_LOOKUP">Object of ERROR_MESSAGE_LOOKUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ErrorMessageLookupBase obj,IDataReader rdr) 
		{

			obj.ErrorMessageKey = rdr.GetString(rdr.GetOrdinal(BO_ErrorMessageLookupFields.ErrorMessageKey));
			obj.ErrorMessageText = rdr.GetString(rdr.GetOrdinal(BO_ErrorMessageLookupFields.ErrorMessageText));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ErrorMessageLookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ErrorMessageLookups PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ErrorMessageLookups list = new BO_ErrorMessageLookups();
			
			while (rdr.Read())
			{
				BO_ErrorMessageLookup obj = new BO_ErrorMessageLookup();
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
		/// <returns>Object of BO_ErrorMessageLookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ErrorMessageLookups PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ErrorMessageLookups list = new BO_ErrorMessageLookups();
			
            if (rdr.Read())
            {
                BO_ErrorMessageLookup obj = new BO_ErrorMessageLookup();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ErrorMessageLookup();
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
