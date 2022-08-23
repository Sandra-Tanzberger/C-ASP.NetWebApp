//
// Class	:	BO_RLBase.cs
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
	public class BO_RLFields
	{
		public const string RlID                      = "RL_ID";
		public const string RlDesc                    = "RL_DESC";
		public const string RlTypID                   = "RL_TYP_ID";
		public const string RlFrmObjct                = "RL_FRM_OBJCT";
		public const string RlFrmObjctDtl             = "RL_FRM_OBJCT_DTL";
		public const string OprtrTypID                = "OPRTR_TYP_ID";
		public const string RlToObjct                 = "RL_TO_OBJCT";
		public const string RlToObjctDtl              = "RL_TO_OBJCT_DTL";
	}
	
	/// <summary>
	/// Data access class for the "RL" table.
	/// </summary>
	[Serializable]
	public class BO_RLBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_rlIDNonDefault          	= null;
		private string         	_rlDescNonDefault        	= null;
		private int?           	_rlTypIDNonDefault       	= null;
		private int?           	_rlFrmObjctNonDefault    	= null;
		private int?           	_rlFrmObjctDtlNonDefault 	= null;
		private decimal?       	_oprtrTypIDNonDefault    	= null;
		private int?           	_rlToObjctNonDefault     	= null;
		private int?           	_rlToObjctDtlNonDefault  	= null;

		private BO_QryGrps _bO_QryGrpsRlID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_RLBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? RlID
		{
			get 
			{ 
                return _rlIDNonDefault;
			}
			set 
			{
            
                _rlIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_DESC" field. Length must be between 0 and 200 characters. Mandatory.
		/// </summary>
		public string RlDesc
		{
			get 
			{ 
                if(_rlDescNonDefault==null)return _rlDescNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _rlDescNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 200)
					throw new ArgumentException("RlDesc length must be between 0 and 200 characters.");

				
                if(value ==null)
                {
                    _rlDescNonDefault =null;//null value 
                }
                else
                {		           
		            _rlDescNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_TYP_ID" field.  
		/// </summary>
		public int? RlTypID
		{
			get 
			{ 
                return _rlTypIDNonDefault;
			}
			set 
			{
            
                _rlTypIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_FRM_OBJCT" field.  
		/// </summary>
		public int? RlFrmObjct
		{
			get 
			{ 
                return _rlFrmObjctNonDefault;
			}
			set 
			{
            
                _rlFrmObjctNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_FRM_OBJCT_DTL" field.  
		/// </summary>
		public int? RlFrmObjctDtl
		{
			get 
			{ 
                return _rlFrmObjctDtlNonDefault;
			}
			set 
			{
            
                _rlFrmObjctDtlNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? OprtrTypID
		{
			get 
			{ 
                return _oprtrTypIDNonDefault;
			}
			set 
			{
            
                _oprtrTypIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_TO_OBJCT" field.  
		/// </summary>
		public int? RlToObjct
		{
			get 
			{ 
                return _rlToObjctNonDefault;
			}
			set 
			{
            
                _rlToObjctNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_TO_OBJCT_DTL" field.  
		/// </summary>
		public int? RlToObjctDtl
		{
			get 
			{ 
                return _rlToObjctDtlNonDefault;
			}
			set 
			{
            
                _rlToObjctDtlNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'QRY_GRP'
		/// </summary>
		public BO_QryGrps BO_QryGrpsRlID
		{
			get 
			{
                if (_bO_QryGrpsRlID == null)
                {
                    _bO_QryGrpsRlID = new BO_QryGrps();
                    _bO_QryGrpsRlID = BO_QryGrp.SelectByField("RL_ID",RlID);
                }                
				return _bO_QryGrpsRlID; 
			}
			set 
			{
				  _bO_QryGrpsRlID = value;
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
			
			// Pass the value of '_rlDesc' as parameter 'RlDesc' of the stored procedure.
			if(_rlDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlDesc", _rlDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlDesc", DBNull.Value );
              
			// Pass the value of '_rlTypID' as parameter 'RlTypID' of the stored procedure.
			if(_rlTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlTypID", _rlTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlTypID", DBNull.Value );
              
			// Pass the value of '_rlFrmObjct' as parameter 'RlFrmObjct' of the stored procedure.
			if(_rlFrmObjctNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlFrmObjct", _rlFrmObjctNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlFrmObjct", DBNull.Value );
              
			// Pass the value of '_rlFrmObjctDtl' as parameter 'RlFrmObjctDtl' of the stored procedure.
			if(_rlFrmObjctDtlNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlFrmObjctDtl", _rlFrmObjctDtlNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlFrmObjctDtl", DBNull.Value );
              
			// Pass the value of '_oprtrTypID' as parameter 'OprtrTypID' of the stored procedure.
			if(_oprtrTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@OprtrTypID", _oprtrTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@OprtrTypID", DBNull.Value );
              
			// Pass the value of '_rlToObjct' as parameter 'RlToObjct' of the stored procedure.
			if(_rlToObjctNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlToObjct", _rlToObjctNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlToObjct", DBNull.Value );
              
			// Pass the value of '_rlToObjctDtl' as parameter 'RlToObjctDtl' of the stored procedure.
			if(_rlToObjctDtlNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlToObjctDtl", _rlToObjctDtlNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlToObjctDtl", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_RL_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_rlDesc' as parameter 'RlDesc' of the stored procedure.
			if(_rlDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlDesc", _rlDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlDesc", DBNull.Value );
			// Pass the value of '_rlTypID' as parameter 'RlTypID' of the stored procedure.
			if(_rlTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlTypID", _rlTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlTypID", DBNull.Value );
			// Pass the value of '_rlFrmObjct' as parameter 'RlFrmObjct' of the stored procedure.
			if(_rlFrmObjctNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlFrmObjct", _rlFrmObjctNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlFrmObjct", DBNull.Value );
			// Pass the value of '_rlFrmObjctDtl' as parameter 'RlFrmObjctDtl' of the stored procedure.
			if(_rlFrmObjctDtlNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlFrmObjctDtl", _rlFrmObjctDtlNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlFrmObjctDtl", DBNull.Value );
			// Pass the value of '_oprtrTypID' as parameter 'OprtrTypID' of the stored procedure.
			if(_oprtrTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@OprtrTypID", _oprtrTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@OprtrTypID", DBNull.Value );
			// Pass the value of '_rlToObjct' as parameter 'RlToObjct' of the stored procedure.
			if(_rlToObjctNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlToObjct", _rlToObjctNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlToObjct", DBNull.Value );
			// Pass the value of '_rlToObjctDtl' as parameter 'RlToObjctDtl' of the stored procedure.
			if(_rlToObjctDtlNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlToObjctDtl", _rlToObjctDtlNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlToObjctDtl", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_RL_Insert", ref ExecutionState);
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
			
			// Pass the value of '_rlID' as parameter 'RlID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlID", _rlIDNonDefault );
            
			// Pass the value of '_rlDesc' as parameter 'RlDesc' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlDesc", _rlDescNonDefault );
            
			// Pass the value of '_rlTypID' as parameter 'RlTypID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlTypID", _rlTypIDNonDefault );
            
			// Pass the value of '_rlFrmObjct' as parameter 'RlFrmObjct' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlFrmObjct", _rlFrmObjctNonDefault );
            
			// Pass the value of '_rlFrmObjctDtl' as parameter 'RlFrmObjctDtl' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlFrmObjctDtl", _rlFrmObjctDtlNonDefault );
            
			// Pass the value of '_oprtrTypID' as parameter 'OprtrTypID' of the stored procedure.
			oDatabaseHelper.AddParameter("@OprtrTypID", _oprtrTypIDNonDefault );
            
			// Pass the value of '_rlToObjct' as parameter 'RlToObjct' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlToObjct", _rlToObjctNonDefault );
            
			// Pass the value of '_rlToObjctDtl' as parameter 'RlToObjctDtl' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlToObjctDtl", _rlToObjctDtlNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_RL_Update", ref ExecutionState);
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
			
			// Pass the value of '_rlID' as parameter 'RlID' of the stored procedure.
			if(_rlIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@RlID", _rlIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@RlID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_RL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_RLPrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_RLPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_RL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_RLFields">Field of the class BO_RL</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_RL_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_RLPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_RL</returns>
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
		public static BO_RL SelectOne(BO_RLPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_RL obj=new BO_RL();	
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
		/// <returns>list of objects of class BO_RL in the form of object of BO_RLs </returns>
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
		public static BO_RLs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_SelectAll", ref ExecutionState);
			BO_RLs BO_RLs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_RLs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_RL</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_RL in the form of an object of class BO_RLs</returns>
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
		public static BO_RLs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_SelectByField", ref ExecutionState);
			BO_RLs BO_RLs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_RLs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="RLPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class RL</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_RL SelectOneWithQRY_GRPUsingRlID(BO_RLPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_RL obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_SelectOneWithQRY_GRPUsingRlID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_RL();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_QryGrpsRlID=BO_QryGrp.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="OPRTR_TYPPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_RLs</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_RLs SelectAllByForeignKeyOprtrTypID(BO_OprtrTypPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_RLs obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_RL_SelectAllByForeignKeyOprtrTypID", ref ExecutionState);
			obj = new BO_RLs();
			obj = BO_RL.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="OPRTR_TYPPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:22 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyOprtrTypID(BO_OprtrTypPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_RL_DeleteAllByForeignKeyOprtrTypID", ref ExecutionState);
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
		/// <param name="obj" type="RL">Object of RL to populate</param>
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
		internal static void PopulateObjectFromReader(BO_RLBase obj,IDataReader rdr) 
		{

			obj.RlID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_RLFields.RlID)));
			obj.RlDesc = rdr.GetString(rdr.GetOrdinal(BO_RLFields.RlDesc));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.RlTypID)))
			{
				obj.RlTypID = rdr.GetInt32(rdr.GetOrdinal(BO_RLFields.RlTypID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.RlFrmObjct)))
			{
				obj.RlFrmObjct = rdr.GetInt32(rdr.GetOrdinal(BO_RLFields.RlFrmObjct));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.RlFrmObjctDtl)))
			{
				obj.RlFrmObjctDtl = rdr.GetInt32(rdr.GetOrdinal(BO_RLFields.RlFrmObjctDtl));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.OprtrTypID)))
			{
				obj.OprtrTypID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_RLFields.OprtrTypID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.RlToObjct)))
			{
				obj.RlToObjct = rdr.GetInt32(rdr.GetOrdinal(BO_RLFields.RlToObjct));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_RLFields.RlToObjctDtl)))
			{
				obj.RlToObjctDtl = rdr.GetInt32(rdr.GetOrdinal(BO_RLFields.RlToObjctDtl));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_RLs</returns>
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
		internal static BO_RLs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_RLs list = new BO_RLs();
			
			while (rdr.Read())
			{
				BO_RL obj = new BO_RL();
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
		/// <returns>Object of BO_RLs</returns>
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
		internal static BO_RLs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_RLs list = new BO_RLs();
			
            if (rdr.Read())
            {
                BO_RL obj = new BO_RL();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_RL();
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
