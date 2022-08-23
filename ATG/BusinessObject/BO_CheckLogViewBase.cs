//
// Class	:	BO_CheckLogViewBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	04/01/2013 3:04:17 PM
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
	public class BO_CheckLogViewFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string BillingID                 = "BILLING_ID";
		public const string BillingDetailID           = "BILLING_DETAIL_ID";
		public const string DateEntered               = "DATE_ENTERED";
		public const string CompanyIndividual         = "COMPANY_INDIVIDUAL";
		public const string StateID                   = "STATE_ID";
		public const string Amount                    = "AMOUNT";
		public const string CheckNum                  = "CHECK_NUM";
		public const string Code                      = "CODE";
		public const string FeeCategory               = "FEE_CATEGORY";
		public const string TypeFee                   = "TYPE_FEE";
		public const string CheckDate                 = "CHECK_DATE";
		public const string PivNum                    = "PIV_NUM";
		public const string ProcessedBY               = "PROCESSED_BY";
	}
	
	/// <summary>
	/// Data access class for the "CHECK_LOG_VIEW" table.
	/// </summary>
	[Serializable]
	public class BO_CheckLogViewBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_billingIDNonDefault     	= null;
		private decimal?       	_billingDetailIDNonDefault	= null;
		private DateTime?      	_dateEnteredNonDefault   	= null;
		private string         	_companyIndividualNonDefault	= null;
		private string         	_stateIDNonDefault       	= null;
		private decimal?       	_amountNonDefault        	= null;
		private string         	_checkNumNonDefault      	= null;
		private string         	_codeNonDefault          	= null;
		private string         	_feeCategoryNonDefault   	= null;
		private string         	_typeFeeNonDefault       	= null;
		private DateTime?      	_checkDateNonDefault     	= null;
		private string         	_pivNumNonDefault        	= null;
		private string         	_processedBYNonDefault   	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_CheckLogViewBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "POPS_INT_ID" field.  
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "APPLICATION_ID" field.  
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
		/// This property is mapped to the "BILLING_ID" field.  Mandatory.
		/// </summary>
		public decimal? BillingID
		{
			get 
			{ 
                return _billingIDNonDefault;
			}
			set 
			{
            
                _billingIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BILLING_DETAIL_ID" field.  Mandatory.
		/// </summary>
		public decimal? BillingDetailID
		{
			get 
			{ 
                return _billingDetailIDNonDefault;
			}
			set 
			{
            
                _billingDetailIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DATE_ENTERED" field.  
		/// </summary>
		public DateTime? DateEntered
		{
			get 
			{ 
                return _dateEnteredNonDefault;
			}
			set 
			{
            
                _dateEnteredNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "COMPANY_INDIVIDUAL" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string CompanyIndividual
		{
			get 
			{ 
                if(_companyIndividualNonDefault==null)return _companyIndividualNonDefault;
				else return _companyIndividualNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("CompanyIndividual length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _companyIndividualNonDefault =null;//null value 
                }
                else
                {		           
		            _companyIndividualNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string StateID
		{
			get 
			{ 
                if(_stateIDNonDefault==null)return _stateIDNonDefault;
				else return _stateIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("StateID length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _stateIDNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AMOUNT" field.  Mandatory.
		/// </summary>
		public decimal? Amount
		{
			get 
			{ 
                return _amountNonDefault;
			}
			set 
			{
            
                _amountNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECK_NUM" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string CheckNum
		{
			get 
			{ 
                if(_checkNumNonDefault==null)return _checkNumNonDefault;
				else return _checkNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("CheckNum length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _checkNumNonDefault =null;//null value 
                }
                else
                {		           
		            _checkNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CODE" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string Code
		{
			get 
			{ 
                if(_codeNonDefault==null)return _codeNonDefault;
				else return _codeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("Code length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _codeNonDefault =null;//null value 
                }
                else
                {		           
		            _codeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FEE_CATEGORY" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string FeeCategory
		{
			get 
			{ 
                if(_feeCategoryNonDefault==null)return _feeCategoryNonDefault;
				else return _feeCategoryNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("FeeCategory length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _feeCategoryNonDefault =null;//null value 
                }
                else
                {		           
		            _feeCategoryNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FEE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string TypeFee
		{
			get 
			{ 
                if(_typeFeeNonDefault==null)return _typeFeeNonDefault;
				else return _typeFeeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("TypeFee length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _typeFeeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFeeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECK_DATE" field.  
		/// </summary>
		public DateTime? CheckDate
		{
			get 
			{ 
                return _checkDateNonDefault;
			}
			set 
			{
            
                _checkDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PIV_NUM" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string PivNum
		{
			get 
			{ 
                if(_pivNumNonDefault==null)return _pivNumNonDefault;
				else return _pivNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("PivNum length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _pivNumNonDefault =null;//null value 
                }
                else
                {		           
		            _pivNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROCESSED_BY" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string ProcessedBY
		{
			get 
			{ 
                if(_processedBYNonDefault==null)return _processedBYNonDefault;
				else return _processedBYNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("ProcessedBY length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _processedBYNonDefault =null;//null value 
                }
                else
                {		           
		            _processedBYNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		#endregion
		
		#region Methods (Public)

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_CheckLogView in the form of object of BO_CheckLogViews </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/01/2013 3:04:17 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_CheckLogViews SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECK_LOG_VIEW_SelectAll", ref ExecutionState);
			BO_CheckLogViews BO_CheckLogViews = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_CheckLogViews;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_CheckLogView</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_CheckLogView in the form of an object of class BO_CheckLogViews</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/01/2013 3:04:17 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_CheckLogViews SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CHECK_LOG_VIEW_SelectByField", ref ExecutionState);
			BO_CheckLogViews BO_CheckLogViews = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_CheckLogViews;
			
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
	    /// DLGenerator			04/01/2013 3:04:17 PM		Created function
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
		/// <param name="obj" type="CHECK_LOG_VIEW">Object of CHECK_LOG_VIEW to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/01/2013 3:04:17 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_CheckLogViewBase obj,IDataReader rdr) 
		{

			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.PopsIntID)))
			{
				obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CheckLogViewFields.PopsIntID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.ApplicationID)))
			{
				obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CheckLogViewFields.ApplicationID)));
			}
			
			obj.BillingID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CheckLogViewFields.BillingID)));
			obj.BillingDetailID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CheckLogViewFields.BillingDetailID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.DateEntered)))
			{
				obj.DateEntered = rdr.GetDateTime(rdr.GetOrdinal(BO_CheckLogViewFields.DateEntered));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.CompanyIndividual)))
			{
				obj.CompanyIndividual = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.CompanyIndividual));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.StateID));
			}
			
			obj.Amount = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CheckLogViewFields.Amount)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.CheckNum)))
			{
				obj.CheckNum = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.CheckNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.Code)))
			{
				obj.Code = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.FeeCategory)))
			{
				obj.FeeCategory = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.FeeCategory));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.TypeFee)))
			{
				obj.TypeFee = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.TypeFee));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.CheckDate)))
			{
				obj.CheckDate = rdr.GetDateTime(rdr.GetOrdinal(BO_CheckLogViewFields.CheckDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.PivNum)))
			{
				obj.PivNum = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.PivNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CheckLogViewFields.ProcessedBY)))
			{
				obj.ProcessedBY = rdr.GetString(rdr.GetOrdinal(BO_CheckLogViewFields.ProcessedBY));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_CheckLogViews</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/01/2013 3:04:17 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_CheckLogViews PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_CheckLogViews list = new BO_CheckLogViews();
			
			while (rdr.Read())
			{
				BO_CheckLogView obj = new BO_CheckLogView();
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
		/// <returns>Object of BO_CheckLogViews</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			04/01/2013 3:04:17 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_CheckLogViews PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_CheckLogViews list = new BO_CheckLogViews();
			
            if (rdr.Read())
            {
                BO_CheckLogView obj = new BO_CheckLogView();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_CheckLogView();
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
