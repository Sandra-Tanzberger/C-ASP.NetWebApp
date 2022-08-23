//
// Class	:	BO_BsnsrlDfntnBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:25 PM
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
	public class BO_BsnsrlDfntnFields
	{
		public const string DfntnID                   = "DFNTN_ID";
		public const string MstrID                    = "MSTR_ID";
		public const string ImplID                    = "IMPL_ID";
		public const string RlSetID                   = "RL_SET_ID";
		public const string LvlID                     = "LVL_ID";
		public const string RlID                      = "RL_ID";
		public const string RsltID                    = "RSLT_ID";
		public const string ImplTypID                 = "IMPL_TYP_ID";
		public const string DfntnTxt                  = "DFNTN_TXT";
		public const string RlStID                    = "RL_ST_ID";
	}
	
	/// <summary>
	/// Data access class for the "BSNSRL_DFNTN" table.
	/// </summary>
	[Serializable]
	public class BO_BsnsrlDfntnBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_dfntnIDNonDefault       	= null;
		private decimal?       	_mstrIDNonDefault        	= null;
		private int?           	_implIDNonDefault        	= null;
		private int?           	_rlSetIDNonDefault       	= null;
		private decimal?       	_lvlIDNonDefault         	= null;
		private int?           	_rlIDNonDefault          	= null;
		private decimal?       	_rsltIDNonDefault        	= null;
		private decimal?       	_implTypIDNonDefault     	= null;
		private string         	_dfntnTxtNonDefault      	= null;
		private decimal?       	_rlStIDNonDefault        	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_BsnsrlDfntnBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? DfntnID
		{
			get 
			{ 
                return _dfntnIDNonDefault;
			}
			set 
			{
            
                _dfntnIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
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
		/// This property is mapped to the "IMPL_ID" field.  Mandatory.
		/// </summary>
		public int? ImplID
		{
			get 
			{ 
                return _implIDNonDefault;
			}
			set 
			{
            
                _implIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_SET_ID" field.  
		/// </summary>
		public int? RlSetID
		{
			get 
			{ 
                return _rlSetIDNonDefault;
			}
			set 
			{
            
                _rlSetIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? LvlID
		{
			get 
			{ 
                return _lvlIDNonDefault;
			}
			set 
			{
            
                _lvlIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RL_ID" field.  
		/// </summary>
		public int? RlID
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
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? RsltID
		{
			get 
			{ 
                return _rsltIDNonDefault;
			}
			set 
			{
            
                _rsltIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ImplTypID
		{
			get 
			{ 
                return _implTypIDNonDefault;
			}
			set 
			{
            
                _implTypIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DFNTN_TXT" field. Length must be between 0 and 200 characters. Mandatory.
		/// </summary>
		public string DfntnTxt
		{
			get 
			{ 
                if(_dfntnTxtNonDefault==null)return _dfntnTxtNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dfntnTxtNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 200)
					throw new ArgumentException("DfntnTxt length must be between 0 and 200 characters.");

				
                if(value ==null)
                {
                    _dfntnTxtNonDefault =null;//null value 
                }
                else
                {		           
		            _dfntnTxtNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? RlStID
		{
			get 
			{ 
                return _rlStIDNonDefault;
			}
			set 
			{
            
                _rlStIDNonDefault = value; 
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
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			if(_mstrIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@MstrID", DBNull.Value );
              
			// Pass the value of '_implID' as parameter 'ImplID' of the stored procedure.
			if(_implIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ImplID", _implIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ImplID", DBNull.Value );
              
			// Pass the value of '_rlSetID' as parameter 'RlSetID' of the stored procedure.
			if(_rlSetIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlSetID", _rlSetIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlSetID", DBNull.Value );
              
			// Pass the value of '_lvlID' as parameter 'LvlID' of the stored procedure.
			if(_lvlIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LvlID", _lvlIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LvlID", DBNull.Value );
              
			// Pass the value of '_rlID' as parameter 'RlID' of the stored procedure.
			if(_rlIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlID", _rlIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlID", DBNull.Value );
              
			// Pass the value of '_rsltID' as parameter 'RsltID' of the stored procedure.
			if(_rsltIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RsltID", _rsltIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RsltID", DBNull.Value );
              
			// Pass the value of '_implTypID' as parameter 'ImplTypID' of the stored procedure.
			if(_implTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ImplTypID", _implTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ImplTypID", DBNull.Value );
              
			// Pass the value of '_dfntnTxt' as parameter 'DfntnTxt' of the stored procedure.
			if(_dfntnTxtNonDefault!=null)
              oDatabaseHelper.AddParameter("@DfntnTxt", _dfntnTxtNonDefault);
            else
              oDatabaseHelper.AddParameter("@DfntnTxt", DBNull.Value );
              
			// Pass the value of '_rlStID' as parameter 'RlStID' of the stored procedure.
			if(_rlStIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlStID", _rlStIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlStID", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			if(_mstrIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@MstrID", DBNull.Value );
			// Pass the value of '_implID' as parameter 'ImplID' of the stored procedure.
			if(_implIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ImplID", _implIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ImplID", DBNull.Value );
			// Pass the value of '_rlSetID' as parameter 'RlSetID' of the stored procedure.
			if(_rlSetIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlSetID", _rlSetIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlSetID", DBNull.Value );
			// Pass the value of '_lvlID' as parameter 'LvlID' of the stored procedure.
			if(_lvlIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LvlID", _lvlIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LvlID", DBNull.Value );
			// Pass the value of '_rlID' as parameter 'RlID' of the stored procedure.
			if(_rlIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlID", _rlIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlID", DBNull.Value );
			// Pass the value of '_rsltID' as parameter 'RsltID' of the stored procedure.
			if(_rsltIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RsltID", _rsltIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RsltID", DBNull.Value );
			// Pass the value of '_implTypID' as parameter 'ImplTypID' of the stored procedure.
			if(_implTypIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ImplTypID", _implTypIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ImplTypID", DBNull.Value );
			// Pass the value of '_dfntnTxt' as parameter 'DfntnTxt' of the stored procedure.
			if(_dfntnTxtNonDefault!=null)
              oDatabaseHelper.AddParameter("@DfntnTxt", _dfntnTxtNonDefault);
            else
              oDatabaseHelper.AddParameter("@DfntnTxt", DBNull.Value );
			// Pass the value of '_rlStID' as parameter 'RlStID' of the stored procedure.
			if(_rlStIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RlStID", _rlStIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RlStID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_dfntnID' as parameter 'DfntnID' of the stored procedure.
			oDatabaseHelper.AddParameter("@DfntnID", _dfntnIDNonDefault );
            
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault );
            
			// Pass the value of '_implID' as parameter 'ImplID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ImplID", _implIDNonDefault );
            
			// Pass the value of '_rlSetID' as parameter 'RlSetID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlSetID", _rlSetIDNonDefault );
            
			// Pass the value of '_lvlID' as parameter 'LvlID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LvlID", _lvlIDNonDefault );
            
			// Pass the value of '_rlID' as parameter 'RlID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlID", _rlIDNonDefault );
            
			// Pass the value of '_rsltID' as parameter 'RsltID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RsltID", _rsltIDNonDefault );
            
			// Pass the value of '_implTypID' as parameter 'ImplTypID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ImplTypID", _implTypIDNonDefault );
            
			// Pass the value of '_dfntnTxt' as parameter 'DfntnTxt' of the stored procedure.
			oDatabaseHelper.AddParameter("@DfntnTxt", _dfntnTxtNonDefault );
            
			// Pass the value of '_rlStID' as parameter 'RlStID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RlStID", _rlStIDNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_dfntnID' as parameter 'DfntnID' of the stored procedure.
			if(_dfntnIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@DfntnID", _dfntnIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@DfntnID", DBNull.Value );
			// Pass the value of '_mstrID' as parameter 'MstrID' of the stored procedure.
			if(_mstrIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@MstrID", _mstrIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@MstrID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlDfntnPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_BsnsrlDfntnPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_BsnsrlDfntnFields">Field of the class BO_BsnsrlDfntn</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_BSNSRL_DFNTN_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_BsnsrlDfntnPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntn</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntn SelectOne(BO_BsnsrlDfntnPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_BsnsrlDfntn obj=new BO_BsnsrlDfntn();	
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
		/// <returns>list of objects of class BO_BsnsrlDfntn in the form of object of BO_BsnsrlDfntns </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAll", ref ExecutionState);
			BO_BsnsrlDfntns BO_BsnsrlDfntns = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlDfntns;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_BsnsrlDfntn</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_BsnsrlDfntn in the form of an object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectByField", ref ExecutionState);
			BO_BsnsrlDfntns BO_BsnsrlDfntns = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_BsnsrlDfntns;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="IMPL_TYPPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAllByForeignKeyImplTypID(BO_ImplTypPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlDfntns obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAllByForeignKeyImplTypID", ref ExecutionState);
			obj = new BO_BsnsrlDfntns();
			obj = BO_BsnsrlDfntn.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="IMPL_TYPPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyImplTypID(BO_ImplTypPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_DFNTN_DeleteAllByForeignKeyImplTypID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_LVLPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAllByForeignKeyLvlID(BO_BsnsrlLvlPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlDfntns obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAllByForeignKeyLvlID", ref ExecutionState);
			obj = new BO_BsnsrlDfntns();
			obj = BO_BsnsrlDfntn.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_LVLPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyLvlID(BO_BsnsrlLvlPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_DFNTN_DeleteAllByForeignKeyLvlID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_MSTRPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAllByForeignKeyMstrID(BO_BsnsrlMstrPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlDfntns obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAllByForeignKeyMstrID", ref ExecutionState);
			obj = new BO_BsnsrlDfntns();
			obj = BO_BsnsrlDfntn.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_MSTRPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyMstrID(BO_BsnsrlMstrPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_DFNTN_DeleteAllByForeignKeyMstrID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_QRYPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAllByForeignKeyRlStID(BO_BsnsrlQryPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlDfntns obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAllByForeignKeyRlStID", ref ExecutionState);
			obj = new BO_BsnsrlDfntns();
			obj = BO_BsnsrlDfntn.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_QRYPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyRlStID(BO_BsnsrlQryPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_DFNTN_DeleteAllByForeignKeyRlStID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_RSLTPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_BsnsrlDfntns SelectAllByForeignKeyRsltID(BO_BsnsrlRsltPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_BsnsrlDfntns obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_BSNSRL_DFNTN_SelectAllByForeignKeyRsltID", ref ExecutionState);
			obj = new BO_BsnsrlDfntns();
			obj = BO_BsnsrlDfntn.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BSNSRL_RSLTPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyRsltID(BO_BsnsrlRsltPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_BSNSRL_DFNTN_DeleteAllByForeignKeyRsltID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:25 PM		Created function
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
		/// <param name="obj" type="BSNSRL_DFNTN">Object of BSNSRL_DFNTN to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_BsnsrlDfntnBase obj,IDataReader rdr) 
		{

			obj.DfntnID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.DfntnID)));
			obj.MstrID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.MstrID)));
			obj.ImplID = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlDfntnFields.ImplID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RlSetID)))
			{
				obj.RlSetID = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RlSetID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlDfntnFields.LvlID)))
			{
				obj.LvlID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.LvlID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RlID)))
			{
				obj.RlID = rdr.GetInt32(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RlID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RsltID)))
			{
				obj.RsltID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RsltID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_BsnsrlDfntnFields.ImplTypID)))
			{
				obj.ImplTypID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.ImplTypID)));
			}
			
			obj.DfntnTxt = rdr.GetString(rdr.GetOrdinal(BO_BsnsrlDfntnFields.DfntnTxt));
			obj.RlStID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_BsnsrlDfntnFields.RlStID)));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsrlDfntns PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_BsnsrlDfntns list = new BO_BsnsrlDfntns();
			
			while (rdr.Read())
			{
				BO_BsnsrlDfntn obj = new BO_BsnsrlDfntn();
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
		/// <returns>Object of BO_BsnsrlDfntns</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:25 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_BsnsrlDfntns PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_BsnsrlDfntns list = new BO_BsnsrlDfntns();
			
            if (rdr.Read())
            {
                BO_BsnsrlDfntn obj = new BO_BsnsrlDfntn();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_BsnsrlDfntn();
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
