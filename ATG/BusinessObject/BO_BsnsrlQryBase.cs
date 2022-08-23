//
// Class	:	BO_BsnsrlQryBase.cs
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
	public class BO_BsnsrlQryFields
	{
		public const string QryID                     = "QRY_ID";
		public const string GrpID                     = "GRP_ID";
		public const string GrpJoin                   = "GRP_JOIN";
		public const string GrpOrdr                   = "GRP_ORDR";
	}
	
	/// <summary>
	/// Data access class for the "BSNSRL_QRY" table.
	/// </summary>
	[Serializable]
	public class BO_BsnsrlQryBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_qryIDNonDefault         	= null;
		private decimal?       	_grpIDNonDefault         	= null;
		private int?           	_grpJoinNonDefault       	= null;
		private int?           	_grpOrdrNonDefault       	= null;

		private BO_BsnsrlDfntns _bO_BsnsrlDfntnsRlStID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BsnsrlQryBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? QryID
		{
			get 
			{ 
                return _qryIDNonDefault;
			}
			set 
			{
            
                _qryIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? GrpID
		{
			get 
			{ 
                return _grpIDNonDefault;
			}
			set 
			{
            
                _grpIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "GRP_JOIN" field.  
		/// </summary>
		public int? GrpJoin
		{
			get 
			{ 
                return _grpJoinNonDefault;
			}
			set 
			{
            
                _grpJoinNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "GRP_ORDR" field.  
		/// </summary>
		public int? GrpOrdr
		{
			get 
			{ 
                return _grpOrdrNonDefault;
			}
			set 
			{
            
                _grpOrdrNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'BSNSRL_DFNTN'
		/// </summary>
		public BO_BsnsrlDfntns BO_BsnsrlDfntnsRlStID
		{
			get 
			{
                if (_bO_BsnsrlDfntnsRlStID == null)
                {
                    _bO_BsnsrlDfntnsRlStID = new BO_BsnsrlDfntns();
                    _bO_BsnsrlDfntnsRlStID = BO_BsnsrlDfntn.SelectByField("QRY_ID",QryID);
                }                
				return _bO_BsnsrlDfntnsRlStID; 
			}
			set 
			{
				  _bO_BsnsrlDfntnsRlStID = value;
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
			
			// Pass the value of '_grpID' as parameter 'GrpID' of the stored procedure.
			if(_grpIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpID", _grpIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpID", DBNull.Value );
              
			// Pass the value of '_grpJoin' as parameter 'GrpJoin' of the stored procedure.
			if(_grpJoinNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpJoin", _grpJoinNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpJoin", DBNull.Value );
              
			// Pass the value of '_grpOrdr' as parameter 'GrpOrdr' of the stored procedure.
			if(_grpOrdrNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpOrdr", _grpOrdrNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpOrdr", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_grpID' as parameter 'GrpID' of the stored procedure.
			if(_grpIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpID", _grpIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpID", DBNull.Value );
			// Pass the value of '_grpJoin' as parameter 'GrpJoin' of the stored procedure.
			if(_grpJoinNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpJoin", _grpJoinNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpJoin", DBNull.Value );
			// Pass the value of '_grpOrdr' as parameter 'GrpOrdr' of the stored procedure.
			if(_grpOrdrNonDefault!=null)
              oDatabaseHelper.AddParameter("@GrpOrdr", _grpOrdrNonDefault);
            else
              oDatabaseHelper.AddParameter("@GrpOrdr", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_Insert", ref ExecutionState);
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
			
			// Pass the value of '_qryID' as parameter 'QryID' of the stored procedure.
			oDatabaseHelper.AddParameter("@QryID", _qryIDNonDefault );
            
			// Pass the value of '_grpID' as parameter 'GrpID' of the stored procedure.
			oDatabaseHelper.AddParameter("@GrpID", _grpIDNonDefault );
            
			// Pass the value of '_grpJoin' as parameter 'GrpJoin' of the stored procedure.
			oDatabaseHelper.AddParameter("@GrpJoin", _grpJoinNonDefault );
            
			// Pass the value of '_grpOrdr' as parameter 'GrpOrdr' of the stored procedure.
			oDatabaseHelper.AddParameter("@GrpOrdr", _grpOrdrNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_Update", ref ExecutionState);
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
			
			// Pass the value of '_qryID' as parameter 'QryID' of the stored procedure.
			if(_qryIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@QryID", _qryIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@QryID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlQryPrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_BsnsrlQryPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BsnsrlQryFields">Field of the class BO_BsnsrlQry</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_QRY_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlQryPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlQry</returns>
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
		public static BO_BsnsrlQry SelectOne(BO_BsnsrlQryPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BsnsrlQry obj=new BO_BsnsrlQry();	
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
		/// <returns>list of objects of class BO_BsnsrlQry in the form of object of BO_BsnsrlQries </returns>
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
		public static BO_BsnsrlQries SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_SelectAll", ref ExecutionState);
			BO_BsnsrlQries BO_BsnsrlQries = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlQries;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BsnsrlQry</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BsnsrlQry in the form of an object of class BO_BsnsrlQries</returns>
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
		public static BO_BsnsrlQries SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_SelectByField", ref ExecutionState);
			BO_BsnsrlQries BO_BsnsrlQries = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlQries;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_QRYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BSNSRL_QRY</returns>
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
		public static BO_BsnsrlQry SelectOneWithBSNSRL_DFNTNUsingRlStID(BO_BsnsrlQryPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlQry obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_SelectOneWithBSNSRL_DFNTNUsingRlStID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_BsnsrlQry();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BsnsrlDfntnsRlStID=BO_BsnsrlDfntn.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="QRY_GRPPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlQries</returns>
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
		public static BO_BsnsrlQries SelectAllByForeignKeyGrpID(BO_QryGrpPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlQries obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_QRY_SelectAllByForeignKeyGrpID", ref ExecutionState);
			obj = new BO_BsnsrlQries();
			obj = BO_BsnsrlQry.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="QRY_GRPPrimaryKey">Primary Key information based on which data is to be deleted.</param>
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
		public static bool DeleteAllByForeignKeyGrpID(BO_QryGrpPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_QRY_DeleteAllByForeignKeyGrpID", ref ExecutionState);
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
		/// <param name="obj" type="BSNSRL_QRY">Object of BSNSRL_QRY to populate</param>
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
		internal static void PopulateObjectFromReader(BO_BsnsrlQryBase obj,IDataReader rdr) 
		{

			obj.QryID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlQryFields.QryID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpID)))
			{
				obj.GrpID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpJoin)))
			{
				obj.GrpJoin = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpJoin));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpOrdr)))
			{
				obj.GrpOrdr = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlQryFields.GrpOrdr));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BsnsrlQries</returns>
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
		internal static BO_BsnsrlQries PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BsnsrlQries list = new BO_BsnsrlQries();
			
			while (rdr.Read())
			{
				BO_BsnsrlQry obj = new BO_BsnsrlQry();
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
		/// <returns>Object of BO_BsnsrlQries</returns>
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
		internal static BO_BsnsrlQries PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BsnsrlQries list = new BO_BsnsrlQries();
			
            if (rdr.Read())
            {
                BO_BsnsrlQry obj = new BO_BsnsrlQry();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BsnsrlQry();
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
