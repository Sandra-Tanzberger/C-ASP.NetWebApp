//
// Class	:	BO_ApplicationItemActionBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/15/2010 3:59:46 PM
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
	public class BO_ApplicationItemActionFields
	{
		public const string ApplicationID             = "APPLICATION_ID";
		public const string ChecklistItemID           = "CHECKLIST_ITEM_ID";
		public const string ActionDate                = "ACTION_DATE";
		public const string ActionID                  = "ACTION_ID";
		public const string ManagerID                 = "MANAGER_ID";
	}
	
	/// <summary>
	/// Data access class for the "APPLICATION_ITEM_ACTIONS" table.
	/// </summary>
	[Serializable]
	public class BO_ApplicationItemActionBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_checklistItemIDNonDefault	= null;
		private DateTime?      	_actionDateNonDefault    	= null;
		private decimal?       	_actionIDNonDefault      	= null;
		private Guid?          	_managerIDNonDefault     	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ApplicationItemActionBase() { }
					
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
		/// Returns the identifier of the persistent object. Mandatory.
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
		/// This property is mapped to the "ACTION_DATE" field.  Mandatory.
		/// </summary>
		public DateTime? ActionDate
		{
			get 
			{ 
                return _actionDateNonDefault;
			}
			set 
			{
            
                _actionDateNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ActionID
		{
			get 
			{ 
                return _actionIDNonDefault;
			}
			set 
			{
            
                _actionIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MANAGER_ID" field.  Mandatory.
		/// </summary>
		public Guid? ManagerID
		{
			get 
			{ 
                return _managerIDNonDefault;
			}
			set 
			{
            
                _managerIDNonDefault = value; 
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
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			if(_checklistItemIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemID", DBNull.Value );
              
			// Pass the value of '_actionDate' as parameter 'ActionDate' of the stored procedure.
			if(_actionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ActionDate", _actionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ActionDate", DBNull.Value );
              
			// Pass the value of '_actionID' as parameter 'ActionID' of the stored procedure.
			if(_actionIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ActionID", _actionIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ActionID", DBNull.Value );
              
			// Pass the value of '_managerID' as parameter 'ManagerID' of the stored procedure.
			if(_managerIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManagerID", _managerIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManagerID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			if(_checklistItemIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChecklistItemID", DBNull.Value );
			// Pass the value of '_actionDate' as parameter 'ActionDate' of the stored procedure.
			if(_actionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ActionDate", _actionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ActionDate", DBNull.Value );
			// Pass the value of '_actionID' as parameter 'ActionID' of the stored procedure.
			if(_actionIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ActionID", _actionIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ActionID", DBNull.Value );
			// Pass the value of '_managerID' as parameter 'ManagerID' of the stored procedure.
			if(_managerIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManagerID", _managerIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManagerID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_Insert", ref ExecutionState);
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
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault );
            
			// Pass the value of '_actionDate' as parameter 'ActionDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ActionDate", _actionDateNonDefault );
            
			// Pass the value of '_actionID' as parameter 'ActionID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ActionID", _actionIDNonDefault );
            
			// Pass the value of '_managerID' as parameter 'ManagerID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ManagerID", _managerIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_Update", ref ExecutionState);
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
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_checklistItemID' as parameter 'ChecklistItemID' of the stored procedure.
			if(_checklistItemIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ChecklistItemID", _checklistItemIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ChecklistItemID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ApplicationItemActionPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ApplicationItemActionPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ApplicationItemActionFields">Field of the class BO_ApplicationItemAction</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ITEM_ACTIONS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ApplicationItemActionPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ApplicationItemAction</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationItemAction SelectOne(BO_ApplicationItemActionPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_ApplicationItemAction obj=new BO_ApplicationItemAction();	
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
		/// <returns>list of objects of class BO_ApplicationItemAction in the form of object of BO_ApplicationItemActions </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationItemActions SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_SelectAll", ref ExecutionState);
			BO_ApplicationItemActions BO_ApplicationItemActions = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ApplicationItemActions;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ApplicationItemAction</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ApplicationItemAction in the form of an object of class BO_ApplicationItemActions</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationItemActions SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_SelectByField", ref ExecutionState);
			BO_ApplicationItemActions BO_ApplicationItemActions = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ApplicationItemActions;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ACTIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ApplicationItemActions</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationItemActions SelectAllByForeignKeyActionID(BO_ActionPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ApplicationItemActions obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_SelectAllByForeignKeyActionID", ref ExecutionState);
			obj = new BO_ApplicationItemActions();
			obj = BO_ApplicationItemAction.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="ACTIONSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyActionID(BO_ActionPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_APPLICATION_ITEM_ACTIONS_DeleteAllByForeignKeyActionID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATION_ITEMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_ApplicationItemActions</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationItemActions SelectAllByForeignKeyApplicationID(BO_ApplicationItemPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_ApplicationItemActions obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ITEM_ACTIONS_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_ApplicationItemActions();
			obj = BO_ApplicationItemAction.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATION_ITEMSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyApplicationID(BO_ApplicationItemPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_APPLICATION_ITEM_ACTIONS_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
	    /// DLGenerator			10/15/2010 3:59:46 PM		Created function
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
		/// <param name="obj" type="APPLICATION_ITEM_ACTIONS">Object of APPLICATION_ITEM_ACTIONS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ApplicationItemActionBase obj,IDataReader rdr) 
		{

			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationItemActionFields.ApplicationID)));
			obj.ChecklistItemID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationItemActionFields.ChecklistItemID)));
			obj.ActionDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationItemActionFields.ActionDate));
			obj.ActionID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationItemActionFields.ActionID)));
			obj.ManagerID = rdr.GetGuid(rdr.GetOrdinal(BO_ApplicationItemActionFields.ManagerID));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ApplicationItemActions</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ApplicationItemActions PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ApplicationItemActions list = new BO_ApplicationItemActions();
			
			while (rdr.Read())
			{
				BO_ApplicationItemAction obj = new BO_ApplicationItemAction();
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
		/// <returns>Object of BO_ApplicationItemActions</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			10/15/2010 3:59:46 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ApplicationItemActions PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ApplicationItemActions list = new BO_ApplicationItemActions();
			
            if (rdr.Read())
            {
                BO_ApplicationItemAction obj = new BO_ApplicationItemAction();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ApplicationItemAction();
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
