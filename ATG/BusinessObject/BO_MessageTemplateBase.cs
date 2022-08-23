//
// Class	:	BO_MessageTemplateBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:29 PM
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
	public class BO_MessageTemplateFields
	{
		public const string TemplateID                = "TEMPLATE_ID";
		public const string TemplateProcessID         = "TEMPLATE_PROCESS_ID";
		public const string Description               = "DESCRIPTION";
		public const string TemplateText              = "TEMPLATE_TEXT";
		public const string AllowedTypes              = "ALLOWED_TYPES";
	}
	
	/// <summary>
	/// Data access class for the "MESSAGE_TEMPLATE" table.
	/// </summary>
	[Serializable]
	public class BO_MessageTemplateBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_templateIDNonDefault    	= null;
		private string         	_templateProcessIDNonDefault	= null;
		private string         	_descriptionNonDefault   	= null;
		private string         	_templateTextNonDefault  	= null;
		private string         	_allowedTypesNonDefault  	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_MessageTemplateBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? TemplateID
		{
			get 
			{ 
                return _templateIDNonDefault;
			}
			set 
			{
            
                _templateIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TEMPLATE_PROCESS_ID" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string TemplateProcessID
		{
			get 
			{ 
                if(_templateProcessIDNonDefault==null)return _templateProcessIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _templateProcessIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("TemplateProcessID length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _templateProcessIDNonDefault =null;//null value 
                }
                else
                {		           
		            _templateProcessIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DESCRIPTION" field. Length must be between 0 and 255 characters. Mandatory.
		/// </summary>
		public string Description
		{
			get 
			{ 
                if(_descriptionNonDefault==null)return _descriptionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _descriptionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 255)
					throw new ArgumentException("Description length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _descriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _descriptionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TEMPLATE_TEXT" field. Length must be between 0 and 2147483647 characters. Mandatory.
		/// </summary>
		public string TemplateText
		{
			get 
			{ 
                if(_templateTextNonDefault==null)return _templateTextNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _templateTextNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 2147483647)
					throw new ArgumentException("TemplateText length must be between 0 and 2147483647 characters.");

				
                if(value ==null)
                {
                    _templateTextNonDefault =null;//null value 
                }
                else
                {		           
		            _templateTextNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ALLOWED_TYPES" field. Length must be between 0 and 255 characters. 
		/// </summary>
		public string AllowedTypes
		{
			get 
			{ 
                if(_allowedTypesNonDefault==null)return _allowedTypesNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _allowedTypesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 255)
					throw new ArgumentException("AllowedTypes length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _allowedTypesNonDefault =null;//null value 
                }
                else
                {		           
		            _allowedTypesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
			
			// Pass the value of '_templateProcessID' as parameter 'TemplateProcessID' of the stored procedure.
			if(_templateProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@TemplateProcessID", _templateProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@TemplateProcessID", DBNull.Value );
              
			// Pass the value of '_description' as parameter 'Description' of the stored procedure.
			if(_descriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@Description", _descriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@Description", DBNull.Value );
              
			// Pass the value of '_templateText' as parameter 'TemplateText' of the stored procedure.
			if(_templateTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@TemplateText", _templateTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@TemplateText", DBNull.Value );
              
			// Pass the value of '_allowedTypes' as parameter 'AllowedTypes' of the stored procedure.
			if(_allowedTypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@AllowedTypes", _allowedTypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@AllowedTypes", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGE_TEMPLATE_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_templateProcessID' as parameter 'TemplateProcessID' of the stored procedure.
			if(_templateProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@TemplateProcessID", _templateProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@TemplateProcessID", DBNull.Value );
			// Pass the value of '_description' as parameter 'Description' of the stored procedure.
			if(_descriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@Description", _descriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@Description", DBNull.Value );
			// Pass the value of '_templateText' as parameter 'TemplateText' of the stored procedure.
			if(_templateTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@TemplateText", _templateTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@TemplateText", DBNull.Value );
			// Pass the value of '_allowedTypes' as parameter 'AllowedTypes' of the stored procedure.
			if(_allowedTypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@AllowedTypes", _allowedTypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@AllowedTypes", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_Insert", ref ExecutionState);
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
			
			// Pass the value of '_templateID' as parameter 'TemplateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@TemplateID", _templateIDNonDefault );
            
			// Pass the value of '_templateProcessID' as parameter 'TemplateProcessID' of the stored procedure.
			oDatabaseHelper.AddParameter("@TemplateProcessID", _templateProcessIDNonDefault );
            
			// Pass the value of '_description' as parameter 'Description' of the stored procedure.
			oDatabaseHelper.AddParameter("@Description", _descriptionNonDefault );
            
			// Pass the value of '_templateText' as parameter 'TemplateText' of the stored procedure.
			oDatabaseHelper.AddParameter("@TemplateText", _templateTextNonDefault );
            
			// Pass the value of '_allowedTypes' as parameter 'AllowedTypes' of the stored procedure.
			oDatabaseHelper.AddParameter("@AllowedTypes", _allowedTypesNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_Update", ref ExecutionState);
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
			
			// Pass the value of '_templateID' as parameter 'TemplateID' of the stored procedure.
			if(_templateIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@TemplateID", _templateIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@TemplateID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_MessageTemplatePrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_MessageTemplatePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_MessageTemplateFields">Field of the class BO_MessageTemplate</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGE_TEMPLATE_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_MessageTemplatePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_MessageTemplate</returns>
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
		public static BO_MessageTemplate SelectOne(BO_MessageTemplatePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGE_TEMPLATE_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_MessageTemplate obj=new BO_MessageTemplate();	
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
		/// <returns>list of objects of class BO_MessageTemplate in the form of object of BO_MessageTemplates </returns>
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
		public static BO_MessageTemplates SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGE_TEMPLATE_SelectAll", ref ExecutionState);
			BO_MessageTemplates BO_MessageTemplates = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MessageTemplates;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_MessageTemplate</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_MessageTemplate in the form of an object of class BO_MessageTemplates</returns>
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
		public static BO_MessageTemplates SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGE_TEMPLATE_SelectByField", ref ExecutionState);
			BO_MessageTemplates BO_MessageTemplates = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MessageTemplates;
			
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
	    /// DLGenerator			01/19/2012 12:30:29 PM		Created function
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
		/// <param name="obj" type="MESSAGE_TEMPLATE">Object of MESSAGE_TEMPLATE to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
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
		internal static void PopulateObjectFromReader(BO_MessageTemplateBase obj,IDataReader rdr) 
		{

			obj.TemplateID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MessageTemplateFields.TemplateID)));
			obj.TemplateProcessID = rdr.GetString(rdr.GetOrdinal(BO_MessageTemplateFields.TemplateProcessID));
			obj.Description = rdr.GetString(rdr.GetOrdinal(BO_MessageTemplateFields.Description));
			obj.TemplateText = rdr.GetString(rdr.GetOrdinal(BO_MessageTemplateFields.TemplateText));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageTemplateFields.AllowedTypes)))
			{
				obj.AllowedTypes = rdr.GetString(rdr.GetOrdinal(BO_MessageTemplateFields.AllowedTypes));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_MessageTemplates</returns>
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
		internal static BO_MessageTemplates PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_MessageTemplates list = new BO_MessageTemplates();
			
			while (rdr.Read())
			{
				BO_MessageTemplate obj = new BO_MessageTemplate();
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
		/// <returns>Object of BO_MessageTemplates</returns>
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
		internal static BO_MessageTemplates PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_MessageTemplates list = new BO_MessageTemplates();
			
            if (rdr.Read())
            {
                BO_MessageTemplate obj = new BO_MessageTemplate();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_MessageTemplate();
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
