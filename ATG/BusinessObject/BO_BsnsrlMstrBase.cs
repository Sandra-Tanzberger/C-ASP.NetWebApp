//
// Class	:	BO_BsnsrlMstrBase.cs
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
	public class BO_BsnsrlMstrFields
	{
		public const string MstrID                    = "MSTR_ID";
		public const string BsnsrlEnbld               = "BSNSRL_ENBLD";
		public const string BusinessProcessID         = "BUSINESS_PROCESS_ID";
	}
	
	/// <summary>
	/// Data access class for the "BSNSRL_MSTR" table.
	/// </summary>
	[Serializable]
	public class BO_BsnsrlMstrBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_mstrIDNonDefault        	= null;
		private int?           	_bsnsrlEnbldNonDefault   	= null;
		private string         	_businessProcessIDNonDefault	= null;

		private BO_BsnsrlDfntns _bO_BsnsrlDfntnsMstrID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BsnsrlMstrBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? MstrID
		{
			get 
			{ 
                return _mstrIDNonDefault;
			}
			set 
			{
            
                _mstrIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BSNSRL_ENBLD" field.  
		/// </summary>
		public int? BsnsrlEnbld
		{
			get 
			{ 
                return _bsnsrlEnbldNonDefault;
			}
			set 
			{
            
                _bsnsrlEnbldNonDefault = value; 
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
		/// Provides access to the related table 'BSNSRL_DFNTN'
		/// </summary>
		public BO_BsnsrlDfntns BO_BsnsrlDfntnsMstrID
		{
			get 
			{
                if (_bO_BsnsrlDfntnsMstrID == null)
                {
                    _bO_BsnsrlDfntnsMstrID = new BO_BsnsrlDfntns();
                    _bO_BsnsrlDfntnsMstrID = BO_BsnsrlDfntn.SelectByField("MSTR_ID",MstrID);
                }                
				return _bO_BsnsrlDfntnsMstrID; 
			}
			set 
			{
				  _bO_BsnsrlDfntnsMstrID = value;
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
			
			// Pass the value of '_bsnsrlEnbld' as parameter 'BsnsrlEnbld' of the stored procedure.
			if(_bsnsrlEnbldNonDefault!=null)
              oDatabaseHelper.AddParameter("@BsnsrlEnbld", _bsnsrlEnbldNonDefault);
            else
              oDatabaseHelper.AddParameter("@BsnsrlEnbld", DBNull.Value );
              
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_bsnsrlEnbld' as parameter 'BsnsrlEnbld' of the stored procedure.
			if(_bsnsrlEnbldNonDefault!=null)
              oDatabaseHelper.AddParameter("@BsnsrlEnbld", _bsnsrlEnbldNonDefault);
            else
              oDatabaseHelper.AddParameter("@BsnsrlEnbld", DBNull.Value );
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault );
            
			// Pass the value of '_bsnsrlEnbld' as parameter 'BsnsrlEnbld' of the stored procedure.
			oDatabaseHelper.AddParameter("@BsnsrlEnbld", _bsnsrlEnbldNonDefault );
            
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:21 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			if(_mstrIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@MstrID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlMstrPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
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
		public static bool Delete(BO_BsnsrlMstrPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BsnsrlMstrFields">Field of the class BO_BsnsrlMstr</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
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
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_MSTR_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlMstrPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlMstr</returns>
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
		public static BO_BsnsrlMstr SelectOne(BO_BsnsrlMstrPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BsnsrlMstr obj=new BO_BsnsrlMstr();	
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
		/// <returns>list of objects of class BO_BsnsrlMstr in the form of object of BO_BsnsrlMstrs </returns>
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
		public static BO_BsnsrlMstrs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_SelectAll", ref ExecutionState);
			BO_BsnsrlMstrs BO_BsnsrlMstrs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlMstrs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BsnsrlMstr</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BsnsrlMstr in the form of an object of class BO_BsnsrlMstrs</returns>
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
		public static BO_BsnsrlMstrs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_SelectByField", ref ExecutionState);
			BO_BsnsrlMstrs BO_BsnsrlMstrs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlMstrs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_MSTRPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BSNSRL_MSTR</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlMstr SelectOneWithBSNSRL_DFNTNUsingMstrID(BO_BsnsrlMstrPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlMstr obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_SelectOneWithBSNSRL_DFNTNUsingMstrID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BsnsrlMstr();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BsnsrlDfntnsMstrID=BO_BsnsrlDfntn.PopulateObjectsFromReader(dr);
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
		/// <returns>object of class BO_BsnsrlMstrs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlMstrs SelectAllByForeignKeyBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlMstrs obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_MSTR_SelectAllByForeignKeyBusinessProcessID", ref ExecutionState);
			obj = new BO_BsnsrlMstrs();
			obj = BO_BsnsrlMstr.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:21 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_MSTR_DeleteAllByForeignKeyBusinessProcessID", ref ExecutionState);
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
		/// <param name="obj" type="BSNSRL_MSTR">Object of BSNSRL_MSTR to populate</param>
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
		internal static void PopulateObjectFromReader(BO_BsnsrlMstrBase obj,IDataReader rdr) 
		{

			obj.MstrID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlMstrFields.MstrID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlMstrFields.BsnsrlEnbld)))
			{
				obj.BsnsrlEnbld = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlMstrFields.BsnsrlEnbld));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlMstrFields.BusinessProcessID)))
			{
				obj.BusinessProcessID = rdr.GetString(rdr.GetOrdinal(BO_BsnsrlMstrFields.BusinessProcessID));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BsnsrlMstrs</returns>
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
		internal static BO_BsnsrlMstrs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BsnsrlMstrs list = new BO_BsnsrlMstrs();
			
			while (rdr.Read())
			{
				BO_BsnsrlMstr obj = new BO_BsnsrlMstr();
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
		/// <returns>Object of BO_BsnsrlMstrs</returns>
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
		internal static BO_BsnsrlMstrs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BsnsrlMstrs list = new BO_BsnsrlMstrs();
			
            if (rdr.Read())
            {
                BO_BsnsrlMstr obj = new BO_BsnsrlMstr();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BsnsrlMstr();
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
