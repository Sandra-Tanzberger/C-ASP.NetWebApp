//
// Class	:	BO_LookupValueBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:32 PM
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
	public class BO_LookupValueFields
	{
		public const string LookupKey                 = "LOOKUP_KEY";
		public const string LookupVal                 = "LOOKUP_VAL";
		public const string Valdesc                   = "VALDESC";
		public const string Allowedtypes              = "ALLOWEDTYPES";
		public const string Sortbyvalue               = "SORTBYVALUE";
		public const string Extra                     = "EXTRA";
		public const string Abbrev                    = "ABBREV";
		public const string Active                    = "ACTIVE";
		public const string Attributes1               = "ATTRIBUTES_1";
		public const string Attributes2               = "ATTRIBUTES_2";
		public const string Attributes3               = "ATTRIBUTES_3";
	}
	
	/// <summary>
	/// Data access class for the "LOOKUP_VALUES" table.
	/// </summary>
	[Serializable]
	public class BO_LookupValueBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_lookupKeyNonDefault     	= null;
		private string         	_lookupValNonDefault     	= null;
		private string         	_valdescNonDefault       	= null;
		private string         	_allowedtypesNonDefault  	= null;
		private int?           	_sortbyvalueNonDefault   	= null;
		private string         	_extraNonDefault         	= null;
		private string         	_abbrevNonDefault        	= null;
		private string         	_activeNonDefault        	= null;
		private string         	_attributes1NonDefault   	= null;
		private string         	_attributes2NonDefault   	= null;
		private string         	_attributes3NonDefault   	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_LookupValueBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "LOOKUP_KEY" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string LookupKey
		{
			get 
			{ 
                if(_lookupKeyNonDefault==null)return _lookupKeyNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _lookupKeyNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("LookupKey length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _lookupKeyNonDefault =null;//null value 
                }
                else
                {		           
		            _lookupKeyNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LOOKUP_VAL" field. Length must be between 0 and 6 characters. Mandatory.
		/// </summary>
		public string LookupVal
		{
			get 
			{ 
                if(_lookupValNonDefault==null)return _lookupValNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _lookupValNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 6)
					throw new ArgumentException("LookupVal length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _lookupValNonDefault =null;//null value 
                }
                else
                {		           
		            _lookupValNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VALDESC" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string Valdesc
		{
			get 
			{ 
                if(_valdescNonDefault==null)return _valdescNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _valdescNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("Valdesc length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _valdescNonDefault =null;//null value 
                }
                else
                {		           
		            _valdescNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ALLOWEDTYPES" field. Length must be between 0 and 256 characters. 
		/// </summary>
		public string Allowedtypes
		{
			get 
			{ 
                if(_allowedtypesNonDefault==null)return _allowedtypesNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _allowedtypesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 256)
					throw new ArgumentException("Allowedtypes length must be between 0 and 256 characters.");

				
                if(value ==null)
                {
                    _allowedtypesNonDefault =null;//null value 
                }
                else
                {		           
		            _allowedtypesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SORTBYVALUE" field.  
		/// </summary>
		public int? Sortbyvalue
		{
			get 
			{ 
                return _sortbyvalueNonDefault;
			}
			set 
			{
            
                _sortbyvalueNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EXTRA" field. Length must be between 0 and 255 characters. 
		/// </summary>
		public string Extra
		{
			get 
			{ 
                if(_extraNonDefault==null)return _extraNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _extraNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 255)
					throw new ArgumentException("Extra length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _extraNonDefault =null;//null value 
                }
                else
                {		           
		            _extraNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ABBREV" field. Length must be between 0 and 8 characters. 
		/// </summary>
		public string Abbrev
		{
			get 
			{ 
                if(_abbrevNonDefault==null)return _abbrevNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _abbrevNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 8)
					throw new ArgumentException("Abbrev length must be between 0 and 8 characters.");

				
                if(value ==null)
                {
                    _abbrevNonDefault =null;//null value 
                }
                else
                {		           
		            _abbrevNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ACTIVE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Active
		{
			get 
			{ 
                if(_activeNonDefault==null)return _activeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _activeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Active length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _activeNonDefault =null;//null value 
                }
                else
                {		           
		            _activeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTRIBUTES_1" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string Attributes1
		{
			get 
			{ 
                if(_attributes1NonDefault==null)return _attributes1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attributes1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("Attributes1 length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _attributes1NonDefault =null;//null value 
                }
                else
                {		           
		            _attributes1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTRIBUTES_2" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string Attributes2
		{
			get 
			{ 
                if(_attributes2NonDefault==null)return _attributes2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attributes2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("Attributes2 length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _attributes2NonDefault =null;//null value 
                }
                else
                {		           
		            _attributes2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTRIBUTES_3" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string Attributes3
		{
			get 
			{ 
                if(_attributes3NonDefault==null)return _attributes3NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attributes3NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("Attributes3 length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _attributes3NonDefault =null;//null value 
                }
                else
                {		           
		            _attributes3NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_lookupKey' as parameter 'LookupKey' of the stored procedure.
			if(_lookupKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@LookupKey", _lookupKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@LookupKey", DBNull.Value );
              
			// Pass the value of '_lookupVal' as parameter 'LookupVal' of the stored procedure.
			if(_lookupValNonDefault!=null)
              oDatabaseHelper.AddParameter("@LookupVal", _lookupValNonDefault);
            else
              oDatabaseHelper.AddParameter("@LookupVal", DBNull.Value );
              
			// Pass the value of '_valdesc' as parameter 'Valdesc' of the stored procedure.
			if(_valdescNonDefault!=null)
              oDatabaseHelper.AddParameter("@Valdesc", _valdescNonDefault);
            else
              oDatabaseHelper.AddParameter("@Valdesc", DBNull.Value );
              
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
              
			// Pass the value of '_sortbyvalue' as parameter 'Sortbyvalue' of the stored procedure.
			if(_sortbyvalueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Sortbyvalue", _sortbyvalueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Sortbyvalue", DBNull.Value );
              
			// Pass the value of '_extra' as parameter 'Extra' of the stored procedure.
			if(_extraNonDefault!=null)
              oDatabaseHelper.AddParameter("@Extra", _extraNonDefault);
            else
              oDatabaseHelper.AddParameter("@Extra", DBNull.Value );
              
			// Pass the value of '_abbrev' as parameter 'Abbrev' of the stored procedure.
			if(_abbrevNonDefault!=null)
              oDatabaseHelper.AddParameter("@Abbrev", _abbrevNonDefault);
            else
              oDatabaseHelper.AddParameter("@Abbrev", DBNull.Value );
              
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
              
			// Pass the value of '_attributes1' as parameter 'Attributes1' of the stored procedure.
			if(_attributes1NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes1", _attributes1NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes1", DBNull.Value );
              
			// Pass the value of '_attributes2' as parameter 'Attributes2' of the stored procedure.
			if(_attributes2NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes2", _attributes2NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes2", DBNull.Value );
              
			// Pass the value of '_attributes3' as parameter 'Attributes3' of the stored procedure.
			if(_attributes3NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes3", _attributes3NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes3", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_LOOKUP_VALUES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LOOKUP_VALUES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_lookupKey' as parameter 'LookupKey' of the stored procedure.
			if(_lookupKeyNonDefault!=null)
              oDatabaseHelper.AddParameter("@LookupKey", _lookupKeyNonDefault);
            else
              oDatabaseHelper.AddParameter("@LookupKey", DBNull.Value );
			// Pass the value of '_lookupVal' as parameter 'LookupVal' of the stored procedure.
			if(_lookupValNonDefault!=null)
              oDatabaseHelper.AddParameter("@LookupVal", _lookupValNonDefault);
            else
              oDatabaseHelper.AddParameter("@LookupVal", DBNull.Value );
			// Pass the value of '_valdesc' as parameter 'Valdesc' of the stored procedure.
			if(_valdescNonDefault!=null)
              oDatabaseHelper.AddParameter("@Valdesc", _valdescNonDefault);
            else
              oDatabaseHelper.AddParameter("@Valdesc", DBNull.Value );
			// Pass the value of '_allowedtypes' as parameter 'Allowedtypes' of the stored procedure.
			if(_allowedtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@Allowedtypes", _allowedtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@Allowedtypes", DBNull.Value );
			// Pass the value of '_sortbyvalue' as parameter 'Sortbyvalue' of the stored procedure.
			if(_sortbyvalueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Sortbyvalue", _sortbyvalueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Sortbyvalue", DBNull.Value );
			// Pass the value of '_extra' as parameter 'Extra' of the stored procedure.
			if(_extraNonDefault!=null)
              oDatabaseHelper.AddParameter("@Extra", _extraNonDefault);
            else
              oDatabaseHelper.AddParameter("@Extra", DBNull.Value );
			// Pass the value of '_abbrev' as parameter 'Abbrev' of the stored procedure.
			if(_abbrevNonDefault!=null)
              oDatabaseHelper.AddParameter("@Abbrev", _abbrevNonDefault);
            else
              oDatabaseHelper.AddParameter("@Abbrev", DBNull.Value );
			// Pass the value of '_active' as parameter 'Active' of the stored procedure.
			if(_activeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Active", _activeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Active", DBNull.Value );
			// Pass the value of '_attributes1' as parameter 'Attributes1' of the stored procedure.
			if(_attributes1NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes1", _attributes1NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes1", DBNull.Value );
			// Pass the value of '_attributes2' as parameter 'Attributes2' of the stored procedure.
			if(_attributes2NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes2", _attributes2NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes2", DBNull.Value );
			// Pass the value of '_attributes3' as parameter 'Attributes3' of the stored procedure.
			if(_attributes3NonDefault!=null)
              oDatabaseHelper.AddParameter("@Attributes3", _attributes3NonDefault);
            else
              oDatabaseHelper.AddParameter("@Attributes3", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LOOKUP_VALUES_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_LookupValue in the form of object of BO_LookupValues </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LookupValues SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LOOKUP_VALUES_SelectAll", ref ExecutionState);
			BO_LookupValues BO_LookupValues = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LookupValues;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_LookupValue</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_LookupValue in the form of an object of class BO_LookupValues</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LookupValues SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LOOKUP_VALUES_SelectByField", ref ExecutionState);
			BO_LookupValues BO_LookupValues = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LookupValues;
			
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
	    /// DLGenerator			01/19/2012 12:30:32 PM		Created function
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
		/// <param name="obj" type="LOOKUP_VALUES">Object of LOOKUP_VALUES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_LookupValueBase obj,IDataReader rdr) 
		{

			obj.LookupKey = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.LookupKey));
			obj.LookupVal = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.LookupVal));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Valdesc)))
			{
				obj.Valdesc = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Valdesc));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Allowedtypes)))
			{
				obj.Allowedtypes = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Allowedtypes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Sortbyvalue)))
			{
				obj.Sortbyvalue = rdr.GetInt32(rdr.GetOrdinal(BO_LookupValueFields.Sortbyvalue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Extra)))
			{
				obj.Extra = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Extra));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Abbrev)))
			{
				obj.Abbrev = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Abbrev));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Active)))
			{
				obj.Active = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Active));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Attributes1)))
			{
				obj.Attributes1 = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Attributes1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Attributes2)))
			{
				obj.Attributes2 = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Attributes2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_LookupValueFields.Attributes3)))
			{
				obj.Attributes3 = rdr.GetString(rdr.GetOrdinal(BO_LookupValueFields.Attributes3));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_LookupValues</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LookupValues PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_LookupValues list = new BO_LookupValues();
			
			while (rdr.Read())
			{
				BO_LookupValue obj = new BO_LookupValue();
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
		/// <returns>Object of BO_LookupValues</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:32 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LookupValues PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_LookupValues list = new BO_LookupValues();
			
            if (rdr.Read())
            {
                BO_LookupValue obj = new BO_LookupValue();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_LookupValue();
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
