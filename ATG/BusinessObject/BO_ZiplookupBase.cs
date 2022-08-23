//
// Class	:	BO_ZiplookupBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:33 AM
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
	public class BO_ZiplookupFields
	{
		public const string StateCode                 = "STATE_CODE";
		public const string Zip                       = "ZIP";
		public const string County                    = "COUNTY";
		public const string Cntyname                  = "CNTYNAME";
		public const string City                      = "CITY";
	}
	
	/// <summary>
	/// Data access class for the "ZIPLOOKUP" table.
	/// </summary>
	[Serializable]
	public class BO_ZiplookupBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_stateCodeNonDefault     	= null;
		private string         	_zipNonDefault           	= null;
		private string         	_countyNonDefault        	= null;
		private string         	_cntynameNonDefault      	= null;
		private string         	_cityNonDefault          	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ZiplookupBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "STATE_CODE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string StateCode
		{
			get 
			{ 
                if(_stateCodeNonDefault==null)return _stateCodeNonDefault;
				else return _stateCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("StateCode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _stateCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _stateCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZIP" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string Zip
		{
			get 
			{ 
                if(_zipNonDefault==null)return _zipNonDefault;
				else return _zipNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("Zip length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _zipNonDefault =null;//null value 
                }
                else
                {		           
		            _zipNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COUNTY" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string County
		{
			get 
			{ 
                if(_countyNonDefault==null)return _countyNonDefault;
				else return _countyNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("County length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _countyNonDefault =null;//null value 
                }
                else
                {		           
		            _countyNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CNTYNAME" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string Cntyname
		{
			get 
			{ 
                if(_cntynameNonDefault==null)return _cntynameNonDefault;
				else return _cntynameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("Cntyname length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _cntynameNonDefault =null;//null value 
                }
                else
                {		           
		            _cntynameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CITY" field. Length must be between 0 and 25 characters. Mandatory.
		/// </summary>
		public string City
		{
			get 
			{ 
                if(_cityNonDefault==null)return _cityNonDefault;
				else return _cityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 25)
					throw new ArgumentException("City length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _cityNonDefault =null;//null value 
                }
                else
                {		           
		            _cityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		#endregion
		
		#region Methods (Public)

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_Ziplookup in the form of object of BO_Ziplookups </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ziplookups SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ZIPLOOKUP_SelectAll", ref ExecutionState);
			BO_Ziplookups BO_Ziplookups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ziplookups;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Ziplookup</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Ziplookup in the form of an object of class BO_Ziplookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Ziplookups SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_ZIPLOOKUP_SelectByField", ref ExecutionState);
			BO_Ziplookups BO_Ziplookups = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Ziplookups;
			
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
	    /// DLGenerator			05/24/2011 11:58:33 AM		Created function
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
		/// <param name="obj" type="ZIPLOOKUP">Object of ZIPLOOKUP to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ZiplookupBase obj,IDataReader rdr) 
		{

			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ZiplookupFields.StateCode)))
			{
				obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.StateCode));
			}
			
			obj.Zip = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.Zip));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ZiplookupFields.County)))
			{
				obj.County = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.County));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ZiplookupFields.Cntyname)))
			{
				obj.Cntyname = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.Cntyname));
			}
			
			obj.City = rdr.GetString(rdr.GetOrdinal(BO_ZiplookupFields.City));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Ziplookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Ziplookups PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Ziplookups list = new BO_Ziplookups();
			
			while (rdr.Read())
			{
				BO_Ziplookup obj = new BO_Ziplookup();
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
		/// <returns>Object of BO_Ziplookups</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Ziplookups PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Ziplookups list = new BO_Ziplookups();
			
            if (rdr.Read())
            {
                BO_Ziplookup obj = new BO_Ziplookup();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Ziplookup();
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
