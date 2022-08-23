//
// Class	:	BO_BsnsObjctBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:19 PM
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
	public class BO_BsnsObjctFields
	{
		public const string ObjctID                   = "OBJCT_ID";
		public const string ObjctTypID                = "OBJCT_TYP_ID";
		public const string ObjctNM                   = "OBJCT_NM";
		public const string ObjctDesc                 = "OBJCT_DESC";
	}
	
	/// <summary>
	/// Data access class for the "BSNS_OBJCT" table.
	/// </summary>
	[Serializable]
	public class BO_BsnsObjctBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_objctIDNonDefault       	= null;
		private decimal?       	_objctTypIDNonDefault    	= null;
		private string         	_objctNMNonDefault       	= null;
		private string         	_objctDescNonDefault     	= null;

		private BO_BsnsObjctDtls _bO_BsnsObjctDtlsObjctID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BsnsObjctBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
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
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ObjctTypID
		{
			get 
			{ 
                return _objctTypIDNonDefault;
			}
			set 
			{
            
                _objctTypIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OBJCT_NM" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string ObjctNM
		{
			get 
			{ 
                if(_objctNMNonDefault==null)return _objctNMNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _objctNMNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("ObjctNM length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _objctNMNonDefault =null;//null value 
                }
                else
                {		           
		            _objctNMNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OBJCT_DESC" field. Length must be between 0 and 200 characters. 
		/// </summary>
		public string ObjctDesc
		{
			get 
			{ 
                if(_objctDescNonDefault==null)return _objctDescNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _objctDescNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 200)
					throw new ArgumentException("ObjctDesc length must be between 0 and 200 characters.");

				
                if(value ==null)
                {
                    _objctDescNonDefault =null;//null value 
                }
                else
                {		           
		            _objctDescNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Provides access to the related table 'BSNS_OBJCT_DTL'
		/// </summary>
		public BO_BsnsObjctDtls BO_BsnsObjctDtlsObjctID
		{
			get 
			{
                if (_bO_BsnsObjctDtlsObjctID == null)
                {
                    _bO_BsnsObjctDtlsObjctID = new BO_BsnsObjctDtls();
                    _bO_BsnsObjctDtlsObjctID = BO_BsnsObjctDtl.SelectByField("OBJCT_ID",ObjctID);
                }                
				return _bO_BsnsObjctDtlsObjctID; 
			}
			set 
			{
				  _bO_BsnsObjctDtlsObjctID = value;
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctTypID' as parameter 'ObjctTypID' of the stored procedure.
			if(_objctTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctTypID", _objctTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctTypID", DBNull.Value );
              
			// Pass the value of '_objctNM' as parameter 'ObjctNM' of the stored procedure.
			if(_objctNMNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctNM", _objctNMNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctNM", DBNull.Value );
              
			// Pass the value of '_objctDesc' as parameter 'ObjctDesc' of the stored procedure.
			if(_objctDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctDesc", _objctDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctDesc", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctTypID' as parameter 'ObjctTypID' of the stored procedure.
			if(_objctTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctTypID", _objctTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctTypID", DBNull.Value );
			// Pass the value of '_objctNM' as parameter 'ObjctNM' of the stored procedure.
			if(_objctNMNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctNM", _objctNMNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctNM", DBNull.Value );
			// Pass the value of '_objctDesc' as parameter 'ObjctDesc' of the stored procedure.
			if(_objctDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObjctDesc", _objctDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObjctDesc", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault );
            
			// Pass the value of '_objctTypID' as parameter 'ObjctTypID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctTypID", _objctTypIDNonDefault );
            
			// Pass the value of '_objctNM' as parameter 'ObjctNM' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctNM", _objctNMNonDefault );
            
			// Pass the value of '_objctDesc' as parameter 'ObjctDesc' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObjctDesc", _objctDescNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_objctID' as parameter 'ObjctID' of the stored procedure.
			if(_objctIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ObjctID", _objctIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ObjctID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsObjctPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BsnsObjctPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BsnsObjctFields">Field of the class BO_BsnsObjct</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNS_OBJCT_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsObjctPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsObjct</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjct SelectOne(BO_BsnsObjctPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BsnsObjct obj=new BO_BsnsObjct();	
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
		/// <returns>list of objects of class BO_BsnsObjct in the form of object of BO_BsnsObjcts </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjcts SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_SelectAll", ref ExecutionState);
			BO_BsnsObjcts BO_BsnsObjcts = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsObjcts;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BsnsObjct</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BsnsObjct in the form of an object of class BO_BsnsObjcts</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjcts SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_SelectByField", ref ExecutionState);
			BO_BsnsObjcts BO_BsnsObjcts = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsObjcts;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNS_OBJCTPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BSNS_OBJCT</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjct SelectOneWithBSNS_OBJCT_DTLUsingObjctID(BO_BsnsObjctPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsObjct obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_SelectOneWithBSNS_OBJCT_DTLUsingObjctID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BsnsObjct();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BsnsObjctDtlsObjctID=BO_BsnsObjctDtl.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="OBJCT_TYPPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsObjcts</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsObjcts SelectAllByForeignKeyObjctTypID(BO_ObjctTypPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsObjcts obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNS_OBJCT_SelectAllByForeignKeyObjctTypID", ref ExecutionState);
			obj = new BO_BsnsObjcts();
			obj = BO_BsnsObjct.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="OBJCT_TYPPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyObjctTypID(BO_ObjctTypPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNS_OBJCT_DeleteAllByForeignKeyObjctTypID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:19 PM		Created function
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
		/// <param name="obj" type="BSNS_OBJCT">Object of BSNS_OBJCT to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BsnsObjctBase obj,IDataReader rdr) 
		{

			obj.ObjctID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctTypID)))
			{
				obj.ObjctTypID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctTypID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctNM)))
			{
				obj.ObjctNM = rdr.GetString(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctNM));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctDesc)))
			{
				obj.ObjctDesc = rdr.GetString(rdr.GetOrdinal(BO_BsnsObjctFields.ObjctDesc));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BsnsObjcts</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsObjcts PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BsnsObjcts list = new BO_BsnsObjcts();
			
			while (rdr.Read())
			{
				BO_BsnsObjct obj = new BO_BsnsObjct();
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
		/// <returns>Object of BO_BsnsObjcts</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsObjcts PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BsnsObjcts list = new BO_BsnsObjcts();
			
            if (rdr.Read())
            {
                BO_BsnsObjct obj = new BO_BsnsObjct();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BsnsObjct();
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
