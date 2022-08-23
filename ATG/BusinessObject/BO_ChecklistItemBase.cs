//
// Class	:	BO_ChecklistItemBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:31 PM
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
	public class BO_ChecklistItemFields
	{
		public const string ChecklistItemID           = "CHECKLIST_ITEM_ID";
		public const string ChecklistItemName         = "CHECKLIST_ITEM_NAME";
		public const string BusinessProcessID         = "BUSINESS_PROCESS_ID";
		public const string Seq                       = "SEQ";
		public const string IsRequired                = "IS_REQUIRED";
		public const string Allowedtypes              = "ALLOWEDTYPES";
		public const string ChecklistUiItemText       = "CHECKLIST_UI_ITEM_TEXT";
		public const string ChecklistUiItemType       = "CHECKLIST_UI_ITEM_TYPE";
		public const string ChecklistItemDatatype     = "CHECKLIST_ITEM_DATATYPE";
		public const string ChecklistItemActionType   = "CHECKLIST_ITEM_ACTION_TYPE";
	}
	
	/// <summary>
	/// Data access class for the "CHECKLIST_ITEMS" table.
	/// </summary>
	[Serializable]
	public class BO_ChecklistItemBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_checklistItemIDNonDefault	= null;
		private string         	_checklistItemNameNonDefault	= null;
		private string         	_businessProcessIDNonDefault	= null;
		private int?           	_seqNonDefault           	= null;
		private bool?          	_isRequiredNonDefault    	= null;
		private string         	_allowedtypesNonDefault  	= null;
		private string         	_checklistUiItemTextNonDefault	= null;
		private string         	_checklistUiItemTypeNonDefault	= null;
		private string         	_checklistItemDatatypeNonDefault	= null;
		private string         	_checklistItemActionTypeNonDefault	= null;

		private BO_ApplicationItems _bO_ApplicationItemsChecklistItemID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ChecklistItemBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ChecklistItemID
		{
			get 
			{ 
                return _checklistItemIDNonDefault;
			}
			set 
			{
            
                _checklistItemIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_ITEM_NAME" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string ChecklistItemName
		{
			get 
			{ 
                if(_checklistItemNameNonDefault==null)return _checklistItemNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checklistItemNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("ChecklistItemName length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _checklistItemNameNonDefault =null;//null value 
                }
                else
                {		           
		            _checklistItemNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// This property is mapped to the "IS_REQUIRED" field.  Mandatory.
		/// </summary>
		public bool? IsRequired
		{
			get 
			{ 
                return _isRequiredNonDefault;
			}
			set 
			{
            
                _isRequiredNonDefault = value; 
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
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _allowedtypesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
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
		            _allowedtypesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_UI_ITEM_TEXT" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string ChecklistUiItemText
		{
			get 
			{ 
                if(_checklistUiItemTextNonDefault==null)return _checklistUiItemTextNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checklistUiItemTextNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("ChecklistUiItemText length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _checklistUiItemTextNonDefault =null;//null value 
                }
                else
                {		           
		            _checklistUiItemTextNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_UI_ITEM_TYPE" field. Length must be between 0 and 20 characters. Mandatory.
		/// </summary>
		public string ChecklistUiItemType
		{
			get 
			{ 
                if(_checklistUiItemTypeNonDefault==null)return _checklistUiItemTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checklistUiItemTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 20)
					throw new ArgumentException("ChecklistUiItemType length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _checklistUiItemTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _checklistUiItemTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_ITEM_DATATYPE" field. Length must be between 0 and 10 characters. Mandatory.
		/// </summary>
		public string ChecklistItemDatatype
		{
			get 
			{ 
                if(_checklistItemDatatypeNonDefault==null)return _checklistItemDatatypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checklistItemDatatypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 10)
					throw new ArgumentException("ChecklistItemDatatype length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _checklistItemDatatypeNonDefault =null;//null value 
                }
                else
                {		           
		            _checklistItemDatatypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_ITEM_ACTION_TYPE" field. Length must be between 0 and 10 characters. Mandatory.
		/// </summary>
		public string ChecklistItemActionType
		{
			get 
			{ 
                if(_checklistItemActionTypeNonDefault==null)return _checklistItemActionTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checklistItemActionTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 10)
					throw new ArgumentException("ChecklistItemActionType length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _checklistItemActionTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _checklistItemActionTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATION_ITEMS'
		/// </summary>
		public BO_ApplicationItems BO_ApplicationItemsChecklistItemID
		{
			get 
			{
                if (_bO_ApplicationItemsChecklistItemID == null)
                {
                    _bO_ApplicationItemsChecklistItemID = new BO_ApplicationItems();
                    _bO_ApplicationItemsChecklistItemID = BO_ApplicationItem.SelectByField("CHECKLIST_ITEM_ID",ChecklistItemID);
                }                
				return _bO_ApplicationItemsChecklistItemID; 
			}
			set 
			{
				  _bO_ApplicationItemsChecklistItemID = value;
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
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_checklistItemName' as parameter 'ChecklistItemName' of the stored procedure.
			if(_checklistItemNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemName", _checklistItemNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemName", DBNull.Value );
              
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
              
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			if(_seqNonDefault!=null)
              oDatabaseHelper.AddParameter("@Seq", _seqNonDefault);
            else
              oDatabaseHelper.AddParameter("@Seq", DBNull.Value );
              
			// Pass the value of '_isRequired' as parameter 'IsRequired' of the stored procedure.
			if(_isRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsRequired", _isRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsRequired", DBNull.Value );
              
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
              
			// Pass the value of '_checklistUiItemText' as parameter 'ChecklistUiItemText' of the stored procedure.
			if(_checklistUiItemTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistUiItemText", _checklistUiItemTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistUiItemText", DBNull.Value );
              
			// Pass the value of '_checklistUiItemType' as parameter 'ChecklistUiItemType' of the stored procedure.
			if(_checklistUiItemTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistUiItemType", _checklistUiItemTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistUiItemType", DBNull.Value );
              
			// Pass the value of '_checklistItemDatatype' as parameter 'ChecklistItemDatatype' of the stored procedure.
			if(_checklistItemDatatypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemDatatype", _checklistItemDatatypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemDatatype", DBNull.Value );
              
			// Pass the value of '_checklistItemActionType' as parameter 'ChecklistItemActionType' of the stored procedure.
			if(_checklistItemActionTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemActionType", _checklistItemActionTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemActionType", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_checklistItemName' as parameter 'ChecklistItemName' of the stored procedure.
			if(_checklistItemNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemName", _checklistItemNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemName", DBNull.Value );
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			if(_seqNonDefault!=null)
              oDatabaseHelper.AddParameter("@Seq", _seqNonDefault);
            else
              oDatabaseHelper.AddParameter("@Seq", DBNull.Value );
			// Pass the value of '_isRequired' as parameter 'IsRequired' of the stored procedure.
			if(_isRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsRequired", _isRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsRequired", DBNull.Value );
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
			// Pass the value of '_checklistUiItemText' as parameter 'ChecklistUiItemText' of the stored procedure.
			if(_checklistUiItemTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistUiItemText", _checklistUiItemTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistUiItemText", DBNull.Value );
			// Pass the value of '_checklistUiItemType' as parameter 'ChecklistUiItemType' of the stored procedure.
			if(_checklistUiItemTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistUiItemType", _checklistUiItemTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistUiItemType", DBNull.Value );
			// Pass the value of '_checklistItemDatatype' as parameter 'ChecklistItemDatatype' of the stored procedure.
			if(_checklistItemDatatypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemDatatype", _checklistItemDatatypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemDatatype", DBNull.Value );
			// Pass the value of '_checklistItemActionType' as parameter 'ChecklistItemActionType' of the stored procedure.
			if(_checklistItemActionTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemActionType", _checklistItemActionTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemActionType", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault );
            
			// Pass the value of '_checklistItemName' as parameter 'ChecklistItemName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistItemName", _checklistItemNameNonDefault );
            
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault );
            
			// Pass the value of '_seq' as parameter 'Seq' of the stored procedure.
			oDatabaseHelper.AddParameter("@Seq", _seqNonDefault );
            
			// Pass the value of '_isRequired' as parameter 'IsRequired' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsRequired", _isRequiredNonDefault );
            
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault );
            
			// Pass the value of '_checklistUiItemText' as parameter 'ChecklistUiItemText' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistUiItemText", _checklistUiItemTextNonDefault );
            
			// Pass the value of '_checklistUiItemType' as parameter 'ChecklistUiItemType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistUiItemType", _checklistUiItemTypeNonDefault );
            
			// Pass the value of '_checklistItemDatatype' as parameter 'ChecklistItemDatatype' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistItemDatatype", _checklistItemDatatypeNonDefault );
            
			// Pass the value of '_checklistItemActionType' as parameter 'ChecklistItemActionType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistItemActionType", _checklistItemActionTypeNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:30 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			if(_checklistItemIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ChecklistItemID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ChecklistItemPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
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
		public static bool Delete(BO_ChecklistItemPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ChecklistItemFields">Field of the class BO_ChecklistItem</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
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
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CHECKLIST_ITEMS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ChecklistItemPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ChecklistItem</returns>
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
		public static BO_ChecklistItem SelectOne(BO_ChecklistItemPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_ChecklistItem obj=new BO_ChecklistItem();	
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
		/// <returns>list of objects of class BO_ChecklistItem in the form of object of BO_ChecklistItems </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ChecklistItems SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_SelectAll", ref ExecutionState);
			BO_ChecklistItems BO_ChecklistItems = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ChecklistItems;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ChecklistItem</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ChecklistItem in the form of an object of class BO_ChecklistItems</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ChecklistItems SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_SelectByField", ref ExecutionState);
			BO_ChecklistItems BO_ChecklistItems = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ChecklistItems;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="CHECKLIST_ITEMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class CHECKLIST_ITEMS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ChecklistItem SelectOneWithAPPLICATION_ITEMSUsingChecklistItemID(BO_ChecklistItemPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ChecklistItem obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_SelectOneWithAPPLICATION_ITEMSUsingChecklistItemID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_ChecklistItem();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationItemsChecklistItemID=BO_ApplicationItem.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class BO_ChecklistItems</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ChecklistItems SelectAllByForeignKeyBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ChecklistItems obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECKLIST_ITEMS_SelectAllByForeignKeyBusinessProcessID", ref ExecutionState);
			obj = new BO_ChecklistItems();
			obj = BO_ChecklistItem.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_CHECKLIST_ITEMS_DeleteAllByForeignKeyBusinessProcessID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:31 PM		Created function
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
		/// <param name="obj" type="CHECKLIST_ITEMS">Object of CHECKLIST_ITEMS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ChecklistItemBase obj,IDataReader rdr) 
		{

			obj.ChecklistItemID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistItemID)));
			obj.ChecklistItemName = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistItemName));
			obj.BusinessProcessID = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.BusinessProcessID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ChecklistItemFields.Seq)))
			{
				obj.Seq = rdr.GetInt32(rdr.GetOrdinal(BO_ChecklistItemFields.Seq));
			}
			
			obj.IsRequired = rdr.GetBoolean(rdr.GetOrdinal(BO_ChecklistItemFields.IsRequired));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ChecklistItemFields.Allowedtypes)))
			{
				obj.Allowedtypes = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.Allowedtypes));
			}
			
			obj.ChecklistUiItemText = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistUiItemText));
			obj.ChecklistUiItemType = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistUiItemType));
			obj.ChecklistItemDatatype = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistItemDatatype));
			obj.ChecklistItemActionType = rdr.GetString(rdr.GetOrdinal(BO_ChecklistItemFields.ChecklistItemActionType));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ChecklistItems</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ChecklistItems PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ChecklistItems list = new BO_ChecklistItems();
			
			while (rdr.Read())
			{
				BO_ChecklistItem obj = new BO_ChecklistItem();
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
		/// <returns>Object of BO_ChecklistItems</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:31 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ChecklistItems PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ChecklistItems list = new BO_ChecklistItems();
			
            if (rdr.Read())
            {
                BO_ChecklistItem obj = new BO_ChecklistItem();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ChecklistItem();
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
