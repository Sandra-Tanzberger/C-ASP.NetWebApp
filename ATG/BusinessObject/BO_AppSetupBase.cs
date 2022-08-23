//
// Class	:	BO_AppSetupBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:34 PM
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
	public class BO_AppSetupFields
	{
		public const string SetupID                   = "SETUP_ID";
		public const string Setting                   = "SETTING";
		public const string DeployTarget              = "DEPLOY_TARGET";
		public const string SettingVal                = "SETTING_VAL";
	}
	
	/// <summary>
	/// Data access class for the "APP_SETUP" table.
	/// </summary>
	[Serializable]
	public class BO_AppSetupBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_setupIDNonDefault       	= null;
		private string         	_settingNonDefault       	= null;
		private string         	_deployTargetNonDefault  	= null;
		private string         	_settingValNonDefault    	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_AppSetupBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? SetupID
		{
			get 
			{ 
                return _setupIDNonDefault;
			}
			set 
			{
            
                _setupIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SETTING" field. Length must be between 0 and 10 characters. Mandatory.
		/// </summary>
		public string Setting
		{
			get 
			{ 
                if(_settingNonDefault==null)return _settingNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _settingNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 10)
					throw new ArgumentException("Setting length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _settingNonDefault =null;//null value 
                }
                else
                {		           
		            _settingNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DEPLOY_TARGET" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string DeployTarget
		{
			get 
			{ 
                if(_deployTargetNonDefault==null)return _deployTargetNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _deployTargetNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("DeployTarget length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _deployTargetNonDefault =null;//null value 
                }
                else
                {		           
		            _deployTargetNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SETTING_VAL" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string SettingVal
		{
			get 
			{ 
                if(_settingValNonDefault==null)return _settingValNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _settingValNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("SettingVal length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _settingValNonDefault =null;//null value 
                }
                else
                {		           
		            _settingValNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_setting' as parameter 'Setting' of the stored procedure.
			if(_settingNonDefault!=null)
              oDatabaseHelper.AddParameter("@Setting", _settingNonDefault);
            else
              oDatabaseHelper.AddParameter("@Setting", DBNull.Value );
              
			// Pass the value of '_deployTarget' as parameter 'DeployTarget' of the stored procedure.
			if(_deployTargetNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeployTarget", _deployTargetNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeployTarget", DBNull.Value );
              
			// Pass the value of '_settingVal' as parameter 'SettingVal' of the stored procedure.
			if(_settingValNonDefault!=null)
              oDatabaseHelper.AddParameter("@SettingVal", _settingValNonDefault);
            else
              oDatabaseHelper.AddParameter("@SettingVal", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APP_SETUP_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_setting' as parameter 'Setting' of the stored procedure.
			if(_settingNonDefault!=null)
              oDatabaseHelper.AddParameter("@Setting", _settingNonDefault);
            else
              oDatabaseHelper.AddParameter("@Setting", DBNull.Value );
			// Pass the value of '_deployTarget' as parameter 'DeployTarget' of the stored procedure.
			if(_deployTargetNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeployTarget", _deployTargetNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeployTarget", DBNull.Value );
			// Pass the value of '_settingVal' as parameter 'SettingVal' of the stored procedure.
			if(_settingValNonDefault!=null)
              oDatabaseHelper.AddParameter("@SettingVal", _settingValNonDefault);
            else
              oDatabaseHelper.AddParameter("@SettingVal", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_setupID' as parameter 'SetupID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SetupID", _setupIDNonDefault );
            
			// Pass the value of '_setting' as parameter 'Setting' of the stored procedure.
			oDatabaseHelper.AddParameter("@Setting", _settingNonDefault );
            
			// Pass the value of '_deployTarget' as parameter 'DeployTarget' of the stored procedure.
			oDatabaseHelper.AddParameter("@DeployTarget", _deployTargetNonDefault );
            
			// Pass the value of '_settingVal' as parameter 'SettingVal' of the stored procedure.
			oDatabaseHelper.AddParameter("@SettingVal", _settingValNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_setupID' as parameter 'SetupID' of the stored procedure.
			if(_setupIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@SetupID", _setupIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@SetupID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_AppSetupPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_AppSetupPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_AppSetupFields">Field of the class BO_AppSetup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APP_SETUP_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_AppSetupPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_AppSetup</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AppSetup SelectOne(BO_AppSetupPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APP_SETUP_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_AppSetup obj=new BO_AppSetup();	
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
		/// <returns>list of objects of class BO_AppSetup in the form of object of BO_AppSetups </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AppSetups SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APP_SETUP_SelectAll", ref ExecutionState);
			BO_AppSetups BO_AppSetups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_AppSetups;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_AppSetup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_AppSetup in the form of an object of class BO_AppSetups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_AppSetups SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APP_SETUP_SelectByField", ref ExecutionState);
			BO_AppSetups BO_AppSetups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_AppSetups;
			
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
	    /// DLGenerator			01/19/2012 12:30:34 PM		Created function
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
		/// <param name="obj" type="APP_SETUP">Object of APP_SETUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_AppSetupBase obj,IDataReader rdr) 
		{

			obj.SetupID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_AppSetupFields.SetupID)));
			obj.Setting = rdr.GetString(rdr.GetOrdinal(BO_AppSetupFields.Setting));
			obj.DeployTarget = rdr.GetString(rdr.GetOrdinal(BO_AppSetupFields.DeployTarget));
			obj.SettingVal = rdr.GetString(rdr.GetOrdinal(BO_AppSetupFields.SettingVal));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_AppSetups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_AppSetups PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_AppSetups list = new BO_AppSetups();
			
			while (rdr.Read())
			{
				BO_AppSetup obj = new BO_AppSetup();
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
		/// <returns>Object of BO_AppSetups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:34 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_AppSetups PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_AppSetups list = new BO_AppSetups();
			
            if (rdr.Read())
            {
                BO_AppSetup obj = new BO_AppSetup();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_AppSetup();
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
