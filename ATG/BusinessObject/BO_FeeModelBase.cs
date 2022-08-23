//
// Class	:	BO_FeeModelBase.cs
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
	public class BO_FeeModelFields
	{
		public const string PriceModelID              = "PRICE_MODEL_ID";
		public const string ModelEffectiveDate        = "MODEL_EFFECTIVE_DATE";
		public const string IsLocked                  = "IS_LOCKED";
		public const string ModelExpirationDate       = "MODEL_EXPIRATION_DATE";
	}
	
	/// <summary>
	/// Data access class for the "FEE_MODEL" table.
	/// </summary>
	[Serializable]
	public class BO_FeeModelBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_priceModelIDNonDefault  	= null;
		private DateTime?      	_modelEffectiveDateNonDefault	= null;
		private string         	_isLockedNonDefault      	= null;
		private DateTime?      	_modelExpirationDateNonDefault	= null;

		private BO_Billings _bO_BillingsPriceModelID = null;
		private BO_Fees _bO_FeesPriceModelID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_FeeModelBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? PriceModelID
		{
			get 
			{ 
                return _priceModelIDNonDefault;
			}
			set 
			{
            
                _priceModelIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MODEL_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? ModelEffectiveDate
		{
			get 
			{ 
                return _modelEffectiveDateNonDefault;
			}
			set 
			{
            
                _modelEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "IS_LOCKED" field. Length must be between 0 and 1 characters. Mandatory.
		/// </summary>
		public string IsLocked
		{
			get 
			{ 
                if(_isLockedNonDefault==null)return _isLockedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isLockedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1)
					throw new ArgumentException("IsLocked length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _isLockedNonDefault =null;//null value 
                }
                else
                {		           
		            _isLockedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MODEL_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? ModelExpirationDate
		{
			get 
			{ 
                return _modelExpirationDateNonDefault;
			}
			set 
			{
            
                _modelExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// Provides access to the related table 'BILLING'
		/// </summary>
		public BO_Billings BO_BillingsPriceModelID
		{
			get 
			{
                if (_bO_BillingsPriceModelID == null)
                {
                    _bO_BillingsPriceModelID = new BO_Billings();
                    _bO_BillingsPriceModelID = BO_Billing.SelectByField("PRICE_MODEL_ID",PriceModelID);
                }                
				return _bO_BillingsPriceModelID; 
			}
			set 
			{
				  _bO_BillingsPriceModelID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'FEES'
		/// </summary>
		public BO_Fees BO_FeesPriceModelID
		{
			get 
			{
                if (_bO_FeesPriceModelID == null)
                {
                    _bO_FeesPriceModelID = new BO_Fees();
                    _bO_FeesPriceModelID = BO_Fee.SelectByField("PRICE_MODEL_ID",PriceModelID);
                }                
				return _bO_FeesPriceModelID; 
			}
			set 
			{
				  _bO_FeesPriceModelID = value;
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
			
			// Pass the value of '_modelEffectiveDate' as parameter 'ModelEffectiveDate' of the stored procedure.
			if(_modelEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ModelEffectiveDate", _modelEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ModelEffectiveDate", DBNull.Value );
              
			// Pass the value of '_isLocked' as parameter 'IsLocked' of the stored procedure.
			if(_isLockedNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsLocked", _isLockedNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsLocked", DBNull.Value );
              
			// Pass the value of '_modelExpirationDate' as parameter 'ModelExpirationDate' of the stored procedure.
			if(_modelExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ModelExpirationDate", _modelExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ModelExpirationDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_modelEffectiveDate' as parameter 'ModelEffectiveDate' of the stored procedure.
			if(_modelEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ModelEffectiveDate", _modelEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ModelEffectiveDate", DBNull.Value );
			// Pass the value of '_isLocked' as parameter 'IsLocked' of the stored procedure.
			if(_isLockedNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsLocked", _isLockedNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsLocked", DBNull.Value );
			// Pass the value of '_modelExpirationDate' as parameter 'ModelExpirationDate' of the stored procedure.
			if(_modelExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ModelExpirationDate", _modelExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ModelExpirationDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_Insert", ref ExecutionState);
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
			
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault );
            
			// Pass the value of '_modelEffectiveDate' as parameter 'ModelEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ModelEffectiveDate", _modelEffectiveDateNonDefault );
            
			// Pass the value of '_isLocked' as parameter 'IsLocked' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsLocked", _isLockedNonDefault );
            
			// Pass the value of '_modelExpirationDate' as parameter 'ModelExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ModelExpirationDate", _modelExpirationDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_Update", ref ExecutionState);
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
			
			// Pass the value of '_priceModelID' as parameter 'PriceModelID' of the stored procedure.
			if(_priceModelIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PriceModelID", _priceModelIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PriceModelID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_FeeModelPrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_FeeModelPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_FeeModelFields">Field of the class BO_FeeModel</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_FEE_MODEL_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_FeeModelPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_FeeModel</returns>
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
		public static BO_FeeModel SelectOne(BO_FeeModelPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_FeeModel obj=new BO_FeeModel();	
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
		/// <returns>list of objects of class BO_FeeModel in the form of object of BO_FeeModels </returns>
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
		public static BO_FeeModels SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_SelectAll", ref ExecutionState);
			BO_FeeModels BO_FeeModels = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_FeeModels;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_FeeModel</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_FeeModel in the form of an object of class BO_FeeModels</returns>
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
		public static BO_FeeModels SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_SelectByField", ref ExecutionState);
			BO_FeeModels BO_FeeModels = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_FeeModels;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="FEE_MODELPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class FEE_MODEL</returns>
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
		public static BO_FeeModel SelectOneWithBILLINGUsingPriceModelID(BO_FeeModelPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_FeeModel obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_SelectOneWithBILLINGUsingPriceModelID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_FeeModel();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BillingsPriceModelID=BO_Billing.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="FEE_MODELPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class FEE_MODEL</returns>
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
		public static BO_FeeModel SelectOneWithFEESUsingPriceModelID(BO_FeeModelPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_FeeModel obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_FEE_MODEL_SelectOneWithFEESUsingPriceModelID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_FeeModel();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_FeesPriceModelID=BO_Fee.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
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
		/// <param name="obj" type="FEE_MODEL">Object of FEE_MODEL to populate</param>
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
		internal static void PopulateObjectFromReader(BO_FeeModelBase obj,IDataReader rdr) 
		{

			obj.PriceModelID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_FeeModelFields.PriceModelID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeModelFields.ModelEffectiveDate)))
			{
				obj.ModelEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_FeeModelFields.ModelEffectiveDate));
			}
			
			obj.IsLocked = rdr.GetString(rdr.GetOrdinal(BO_FeeModelFields.IsLocked));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_FeeModelFields.ModelExpirationDate)))
			{
				obj.ModelExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_FeeModelFields.ModelExpirationDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_FeeModels</returns>
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
		internal static BO_FeeModels PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_FeeModels list = new BO_FeeModels();
			
			while (rdr.Read())
			{
				BO_FeeModel obj = new BO_FeeModel();
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
		/// <returns>Object of BO_FeeModels</returns>
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
		internal static BO_FeeModels PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_FeeModels list = new BO_FeeModels();
			
            if (rdr.Read())
            {
                BO_FeeModel obj = new BO_FeeModel();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_FeeModel();
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
