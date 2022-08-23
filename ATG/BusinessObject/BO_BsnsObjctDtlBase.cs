//
// Class	:	BO_BsnsObjctDtlBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:35 PM
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
	public class BO_BsnsObjctDtlFields
	{
		public const string ObjctDtlID                = "OBJCT_DTL_ID";
		public const string ObjctID                   = "OBJCT_ID";
		public const string KeyNM                     = "KEY_NM";
		public const string CnstntVal                 = "CNSTNT_VAL";
		public const string DataType                  = "DATA_TYPE";
	}
	
	/// <summary>
	/// Data access class for the "BSNS_OBJCT_DTL" table.
	/// </summary>
	[Serializable]
	public class BO_BsnsObjctDtlBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_objctDtlIDNonDefault    	= null;
		private decimal?       	_objctIDNonDefault       	= null;
		private string         	_keyNMNonDefault         	= null;
		private string         	_cnstntValNonDefault     	= null;
		private string         	_dataTypeNonDefault      	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BsnsObjctDtlBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ObjctDtlID
		{
			get 
			{ 
                return _objctDtlIDNonDefault;
			}
			set 
			{
            
                _objctDtlIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? ObjctID
		{
			get 
			{ 
                return _objctIDNonDefault;
			}
			set 
			{
            
                _objctIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "KEY_NM" field. Length must be between 0 and 200 characters. 
		/// </summary>
		public string KeyNM
		{
			get 
			{ 
                if(_keyNMNonDefault==null)return _keyNMNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _keyNMNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 200)
					throw new ArgumentException("KeyNM length must be between 0 and 200 characters.");

				
                if(value ==null)
                {
                    _keyNMNonDefault =null;//null value 
                }
                else
                {		           
		            _keyNMNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CNSTNT_VAL" field. Length must be between 0 and 200 characters. 
		/// </summary>
		public string CnstntVal
		{
			get 
			{ 
                if(_cnstntValNonDefault==null)return _cnstntValNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _cnstntValNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 200)
					throw new ArgumentException("CnstntVal length must be between 0 and 200 characters.");

				
                if(value ==null)
                {
                    _cnstntValNonDefault =null;//null value 
                }
                else
                {		           
		            _cnstntValNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DATA_TYPE" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string DataType
		{
			get 
			{ 
                if(_dataTypeNonDefault==null)return _dataTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dataTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("DataType length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _dataTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _dataTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			if(_objctIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctID", DBNull.Value );
              
			// Pass the value of '_keyNM' as parameter 'KeyNM' of the stored procedure.
			if(_keyNMNonDefault!=null)
              oDatabaseHelper.AddParameter("@KeyNM", _keyNMNonDefault);
            else
              oDatabaseHelper.AddParameter("@KeyNM", DBNull.Value );
              
			// Pass the value of '_cnstntVal' as parameter 'CnstntVal' of the stored procedure.
			if(_cnstntValNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnstntVal", _cnstntValNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnstntVal", DBNull.Value );
              
			// Pass the value of '_dataType' as parameter 'DataType' of the stored procedure.
			if(_dataTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DataType", _dataTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DataType", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_DTL_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			if(_objctIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctID", DBNull.Value );
			// Pass the value of '_keyNM' as parameter 'KeyNM' of the stored procedure.
			if(_keyNMNonDefault!=null)
              oDatabaseHelper.AddParameter("@KeyNM", _keyNMNonDefault);
            else
              oDatabaseHelper.AddParameter("@KeyNM", DBNull.Value );
			// Pass the value of '_cnstntVal' as parameter 'CnstntVal' of the stored procedure.
			if(_cnstntValNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnstntVal", _cnstntValNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnstntVal", DBNull.Value );
			// Pass the value of '_dataType' as parameter 'DataType' of the stored procedure.
			if(_dataTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@DataType", _dataTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@DataType", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctDtlID' as parameter 'ObjctDtlID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctDtlID", _objctDtlIDNonDefault );
            
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault );
            
			// Pass the value of '_keyNM' as parameter 'KeyNM' of the stored procedure.
			oDatabaseHelper.AddParameter("@KeyNM", _keyNMNonDefault );
            
			// Pass the value of '_cnstntVal' as parameter 'CnstntVal' of the stored procedure.
			oDatabaseHelper.AddParameter("@CnstntVal", _cnstntValNonDefault );
            
			// Pass the value of '_dataType' as parameter 'DataType' of the stored procedure.
			oDatabaseHelper.AddParameter("@DataType", _dataTypeNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctDtlID' as parameter 'ObjctDtlID' of the stored procedure.
			if(_objctDtlIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ObjctDtlID", _objctDtlIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ObjctDtlID", DBNull.Value );
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			if(_objctIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ObjctID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsObjctDtlPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BsnsObjctDtlPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BsnsObjctDtlFields">Field of the class BO_BsnsObjctDtl</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DTL_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsObjctDtlPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsObjctDtl</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjctDtl SelectOne(BO_BsnsObjctDtlPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_DTL_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BsnsObjctDtl obj=new BO_BsnsObjctDtl();	
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
		/// <returns>list of objects of class BO_BsnsObjctDtl in the form of object of BO_BsnsObjctDtls </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjctDtls SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_DTL_SelectAll", ref ExecutionState);
			BO_BsnsObjctDtls BO_BsnsObjctDtls = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsObjctDtls;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BsnsObjctDtl</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BsnsObjctDtl in the form of an object of class BO_BsnsObjctDtls</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjctDtls SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_DTL_SelectByField", ref ExecutionState);
			BO_BsnsObjctDtls BO_BsnsObjctDtls = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsObjctDtls;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNS_OBJCTPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsObjctDtls</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjctDtls SelectAllByForeignKeyObjctID(BO_BsnsObjctPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsObjctDtls obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_DTL_SelectAllByForeignKeyObjctID", ref ExecutionState);
			obj = new BO_BsnsObjctDtls();
			obj = BO_BsnsObjctDtl.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNS_OBJCTPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyObjctID(BO_BsnsObjctPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNS_OBJCT_DTL_DeleteAllByForeignKeyObjctID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:35 PM		Created function
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
		/// <param name="obj" type="BSNS_OBJCT_DTL">Object of BSNS_OBJCT_DTL to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BsnsObjctDtlBase obj,IDataReader rdr) 
		{

			obj.ObjctDtlID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsObjctDtlFields.ObjctDtlID)));
			obj.ObjctID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsObjctDtlFields.ObjctID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctDtlFields.KeyNM)))
			{
				obj.KeyNM = rdr.GetString(rdr.GetOrdinal(BO_BsnsObjctDtlFields.KeyNM));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctDtlFields.CnstntVal)))
			{
				obj.CnstntVal = rdr.GetString(rdr.GetOrdinal(BO_BsnsObjctDtlFields.CnstntVal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctDtlFields.DataType)))
			{
				obj.DataType = rdr.GetString(rdr.GetOrdinal(BO_BsnsObjctDtlFields.DataType));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BsnsObjctDtls</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsObjctDtls PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BsnsObjctDtls list = new BO_BsnsObjctDtls();
			
			while (rdr.Read())
			{
				BO_BsnsObjctDtl obj = new BO_BsnsObjctDtl();
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
		/// <returns>Object of BO_BsnsObjctDtls</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:35 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsObjctDtls PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BsnsObjctDtls list = new BO_BsnsObjctDtls();
			
            if (rdr.Read())
            {
                BO_BsnsObjctDtl obj = new BO_BsnsObjctDtl();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BsnsObjctDtl();
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
