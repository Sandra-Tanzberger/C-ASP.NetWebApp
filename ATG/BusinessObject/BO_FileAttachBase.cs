//
// Class	:	BO_FileAttachBase.cs
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
	public class BO_FileAttachFields
	{
		public const string FileAttachID              = "FILE_ATTACH_ID";
		public const string AttachFilename            = "ATTACH_FILENAME";
		public const string AttachDescription         = "ATTACH_DESCRIPTION";
		public const string AttachmentType            = "ATTACHMENT_TYPE";
		public const string Attachment                = "ATTACHMENT";
		public const string AttachParentID            = "ATTACH_PARENT_ID";
		public const string AttachParentIdType        = "ATTACH_PARENT_ID_TYPE";
		public const string AttachSaved               = "ATTACH_SAVED";
		public const string SavedRefID                = "SAVED_REF_ID";
		public const string ContentType               = "CONTENT_TYPE";
		public const string FileSize                  = "FILE_SIZE";
		public const string AddDate                   = "ADD_DATE";
	}
	
	/// <summary>
	/// Data access class for the "FILE_ATTACH" table.
	/// </summary>
	[Serializable]
	public class BO_FileAttachBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_fileAttachIDNonDefault  	= null;
		private string         	_attachFilenameNonDefault	= null;
		private string         	_attachDescriptionNonDefault	= null;
		private string         	_attachmentTypeNonDefault	= null;
		private byte[]         	_attachmentNonDefault    	= null;
		private decimal?       	_attachParentIDNonDefault	= null;
		private string         	_attachParentIdTypeNonDefault	= null;
		private string         	_attachSavedNonDefault   	= null;
		private decimal?       	_savedRefIDNonDefault    	= null;
		private string         	_contentTypeNonDefault   	= null;
		private int?           	_fileSizeNonDefault      	= null;
		private DateTime?      	_addDateNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_FileAttachBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? FileAttachID
		{
			get 
			{ 
                return _fileAttachIDNonDefault;
			}
			set 
			{
            
                _fileAttachIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACH_FILENAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string AttachFilename
		{
			get 
			{ 
                if(_attachFilenameNonDefault==null)return _attachFilenameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attachFilenameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("AttachFilename length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _attachFilenameNonDefault =null;//null value 
                }
                else
                {		           
		            _attachFilenameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACH_DESCRIPTION" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string AttachDescription
		{
			get 
			{ 
                if(_attachDescriptionNonDefault==null)return _attachDescriptionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attachDescriptionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("AttachDescription length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _attachDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _attachDescriptionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACHMENT_TYPE" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string AttachmentType
		{
			get 
			{ 
                if(_attachmentTypeNonDefault==null)return _attachmentTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attachmentTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("AttachmentType length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _attachmentTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _attachmentTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACHMENT" field.  
		/// </summary>
		public byte[] Attachment
		{
			get 
			{ 
                return _attachmentNonDefault;
			}
			set 
			{
            
                _attachmentNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACH_PARENT_ID" field.  
		/// </summary>
		public decimal? AttachParentID
		{
			get 
			{ 
                return _attachParentIDNonDefault;
			}
			set 
			{
            
                _attachParentIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACH_PARENT_ID_TYPE" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string AttachParentIdType
		{
			get 
			{ 
                if(_attachParentIdTypeNonDefault==null)return _attachParentIdTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attachParentIdTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("AttachParentIdType length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _attachParentIdTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _attachParentIdTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTACH_SAVED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AttachSaved
		{
			get 
			{ 
                if(_attachSavedNonDefault==null)return _attachSavedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attachSavedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AttachSaved length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _attachSavedNonDefault =null;//null value 
                }
                else
                {		           
		            _attachSavedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SAVED_REF_ID" field.  
		/// </summary>
		public decimal? SavedRefID
		{
			get 
			{ 
                return _savedRefIDNonDefault;
			}
			set 
			{
            
                _savedRefIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CONTENT_TYPE" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string ContentType
		{
			get 
			{ 
                if(_contentTypeNonDefault==null)return _contentTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _contentTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("ContentType length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _contentTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _contentTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FILE_SIZE" field.  
		/// </summary>
		public int? FileSize
		{
			get 
			{ 
                return _fileSizeNonDefault;
			}
			set 
			{
            
                _fileSizeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADD_DATE" field.  
		/// </summary>
		public DateTime? AddDate
		{
			get 
			{ 
                return _addDateNonDefault;
			}
			set 
			{
            
                _addDateNonDefault = value; 
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
			
			// Pass the value of '_attachFilename' as parameter 'AttachFilename' of the stored procedure.
			if(_attachFilenameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachFilename", _attachFilenameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachFilename", DBNull.Value );
              
			// Pass the value of '_attachDescription' as parameter 'AttachDescription' of the stored procedure.
			if(_attachDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachDescription", _attachDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachDescription", DBNull.Value );
              
			// Pass the value of '_attachmentType' as parameter 'AttachmentType' of the stored procedure.
			if(_attachmentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachmentType", _attachmentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachmentType", DBNull.Value );
              
			// Pass the value of '_attachment' as parameter 'Attachment' of the stored procedure.
			if(_attachmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Attachment", _attachmentNonDefault  );
            else
              oDatabaseHelper.AddParameter("@Attachment", DBNull.Value );
            
            // Pass the value of '_attachParentID' as parameter 'AttachParentID' of the stored procedure.
			if(_attachParentIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachParentID", _attachParentIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachParentID", DBNull.Value );
              
			// Pass the value of '_attachParentIdType' as parameter 'AttachParentIdType' of the stored procedure.
			if(_attachParentIdTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachParentIdType", _attachParentIdTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachParentIdType", DBNull.Value );
              
			// Pass the value of '_attachSaved' as parameter 'AttachSaved' of the stored procedure.
			if(_attachSavedNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachSaved", _attachSavedNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachSaved", DBNull.Value );
              
			// Pass the value of '_savedRefID' as parameter 'SavedRefID' of the stored procedure.
			if(_savedRefIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SavedRefID", _savedRefIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SavedRefID", DBNull.Value );
              
			// Pass the value of '_contentType' as parameter 'ContentType' of the stored procedure.
			if(_contentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContentType", _contentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContentType", DBNull.Value );
              
			// Pass the value of '_fileSize' as parameter 'FileSize' of the stored procedure.
			if(_fileSizeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FileSize", _fileSizeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FileSize", DBNull.Value );
              
			// Pass the value of '_addDate' as parameter 'AddDate' of the stored procedure.
			if(_addDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddDate", _addDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FILE_ATTACH_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_attachFilename' as parameter 'AttachFilename' of the stored procedure.
			if(_attachFilenameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachFilename", _attachFilenameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachFilename", DBNull.Value );
			// Pass the value of '_attachDescription' as parameter 'AttachDescription' of the stored procedure.
			if(_attachDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachDescription", _attachDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachDescription", DBNull.Value );
			// Pass the value of '_attachmentType' as parameter 'AttachmentType' of the stored procedure.
			if(_attachmentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachmentType", _attachmentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachmentType", DBNull.Value );
			// Pass the value of '_attachment' as parameter 'Attachment' of the stored procedure.
			if(_attachmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@Attachment", _attachmentNonDefault );
            else
              oDatabaseHelper.AddParameter("@Attachment", DBNull.Value );
            // Pass the value of '_attachParentID' as parameter 'AttachParentID' of the stored procedure.
			if(_attachParentIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachParentID", _attachParentIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachParentID", DBNull.Value );
			// Pass the value of '_attachParentIdType' as parameter 'AttachParentIdType' of the stored procedure.
			if(_attachParentIdTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachParentIdType", _attachParentIdTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachParentIdType", DBNull.Value );
			// Pass the value of '_attachSaved' as parameter 'AttachSaved' of the stored procedure.
			if(_attachSavedNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttachSaved", _attachSavedNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttachSaved", DBNull.Value );
			// Pass the value of '_savedRefID' as parameter 'SavedRefID' of the stored procedure.
			if(_savedRefIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SavedRefID", _savedRefIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SavedRefID", DBNull.Value );
			// Pass the value of '_contentType' as parameter 'ContentType' of the stored procedure.
			if(_contentTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContentType", _contentTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContentType", DBNull.Value );
			// Pass the value of '_fileSize' as parameter 'FileSize' of the stored procedure.
			if(_fileSizeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FileSize", _fileSizeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FileSize", DBNull.Value );
			// Pass the value of '_addDate' as parameter 'AddDate' of the stored procedure.
			if(_addDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AddDate", _addDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AddDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_fileAttachID' as parameter 'FileAttachID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FileAttachID", _fileAttachIDNonDefault );
            
			// Pass the value of '_attachFilename' as parameter 'AttachFilename' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachFilename", _attachFilenameNonDefault );
            
			// Pass the value of '_attachDescription' as parameter 'AttachDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachDescription", _attachDescriptionNonDefault );
            
			// Pass the value of '_attachmentType' as parameter 'AttachmentType' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachmentType", _attachmentTypeNonDefault );
            
			// Pass the value of '_attachment' as parameter 'Attachment' of the stored procedure.
			oDatabaseHelper.AddParameter("@Attachment", _attachmentNonDefault );
            
			// Pass the value of '_attachParentID' as parameter 'AttachParentID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachParentID", _attachParentIDNonDefault );
            
			// Pass the value of '_attachParentIdType' as parameter 'AttachParentIdType' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachParentIdType", _attachParentIdTypeNonDefault );
            
			// Pass the value of '_attachSaved' as parameter 'AttachSaved' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttachSaved", _attachSavedNonDefault );
            
			// Pass the value of '_savedRefID' as parameter 'SavedRefID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SavedRefID", _savedRefIDNonDefault );
            
			// Pass the value of '_contentType' as parameter 'ContentType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ContentType", _contentTypeNonDefault );
            
			// Pass the value of '_fileSize' as parameter 'FileSize' of the stored procedure.
			oDatabaseHelper.AddParameter("@FileSize", _fileSizeNonDefault );
            
			// Pass the value of '_addDate' as parameter 'AddDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AddDate", _addDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:22 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_fileAttachID' as parameter 'FileAttachID' of the stored procedure.
			if(_fileAttachIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@FileAttachID", _fileAttachIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@FileAttachID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_FileAttachPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
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
		public static bool Delete(BO_FileAttachPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_FileAttachFields">Field of the class BO_FileAttach</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
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
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FILE_ATTACH_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_FileAttachPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_FileAttach</returns>
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
		public static BO_FileAttach SelectOne(BO_FileAttachPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FILE_ATTACH_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_FileAttach obj=new BO_FileAttach();	
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
		/// <returns>list of objects of class BO_FileAttach in the form of object of BO_FileAttaches </returns>
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
		public static BO_FileAttaches SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FILE_ATTACH_SelectAll", ref ExecutionState);
			BO_FileAttaches BO_FileAttaches = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_FileAttaches;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_FileAttach</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_FileAttach in the form of an object of class BO_FileAttaches</returns>
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
		public static BO_FileAttaches SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FILE_ATTACH_SelectByField", ref ExecutionState);
			BO_FileAttaches BO_FileAttaches = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_FileAttaches;
			
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
		/// <param name="obj" type="FILE_ATTACH">Object of FILE_ATTACH to populate</param>
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
		internal static void PopulateObjectFromReader(BO_FileAttachBase obj,IDataReader rdr) 
		{

			obj.FileAttachID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FileAttachFields.FileAttachID)));
			obj.AttachFilename = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.AttachFilename));
			obj.AttachDescription = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.AttachDescription));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.AttachmentType)))
			{
				obj.AttachmentType = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.AttachmentType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.Attachment)))
			{
				obj.Attachment = (System.Byte[])rdr.GetValue(rdr.GetOrdinal(BO_FileAttachFields.Attachment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.AttachParentID)))
			{
				obj.AttachParentID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FileAttachFields.AttachParentID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.AttachParentIdType)))
			{
				obj.AttachParentIdType = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.AttachParentIdType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.AttachSaved)))
			{
				obj.AttachSaved = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.AttachSaved));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.SavedRefID)))
			{
				obj.SavedRefID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FileAttachFields.SavedRefID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.ContentType)))
			{
				obj.ContentType = rdr.GetString(rdr.GetOrdinal(BO_FileAttachFields.ContentType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.FileSize)))
			{
				obj.FileSize = rdr.GetInt32(rdr.GetOrdinal(BO_FileAttachFields.FileSize));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FileAttachFields.AddDate)))
			{
				obj.AddDate = rdr.GetDateTime(rdr.GetOrdinal(BO_FileAttachFields.AddDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_FileAttaches</returns>
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
		internal static BO_FileAttaches PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_FileAttaches list = new BO_FileAttaches();
			
			while (rdr.Read())
			{
				BO_FileAttach obj = new BO_FileAttach();
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
		/// <returns>Object of BO_FileAttaches</returns>
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
		internal static BO_FileAttaches PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_FileAttaches list = new BO_FileAttaches();
			
            if (rdr.Read())
            {
                BO_FileAttach obj = new BO_FileAttach();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_FileAttach();
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
