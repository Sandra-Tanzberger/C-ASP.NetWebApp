//
// Class	:	BO_MdsdbAdminfacBase.cs
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
	public class BO_MdsdbAdminfacFields
	{
		public const string Adminfacrowid             = "ADMINFACROWID";
		public const string Adminid                   = "ADMINID";
		public const string FacilityInternalID        = "FACILITY_INTERNAL_ID";
		public const string Primaryadm                = "PRIMARYADM";
		public const string Facid                     = "FACID";
		public const string Admtype                   = "ADMTYPE";
		public const string Admtypedes                = "ADMTYPEDES";
		public const string Started                   = "STARTED";
		public const string End                       = "END";
		public const string Employeeid                = "EMPLOYEEID";
		public const string Created                   = "CREATED";
	}
	
	/// <summary>
	/// Data access class for the "MDSDB_ADMINFAC" table.
	/// </summary>
	[Serializable]
	public class BO_MdsdbAdminfacBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_adminfacrowidNonDefault 	= null;
		private decimal?       	_adminidNonDefault       	= null;
		private decimal?       	_facilityInternalIDNonDefault	= null;
		private decimal?       	_primaryadmNonDefault    	= null;
		private string         	_facidNonDefault         	= null;
		private string         	_admtypeNonDefault       	= null;
		private string         	_admtypedesNonDefault    	= null;
		private DateTime?      	_startedNonDefault       	= null;
		private DateTime?      	_endNonDefault           	= null;
		private string         	_employeeidNonDefault    	= null;
		private DateTime?      	_createdNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_MdsdbAdminfacBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? Adminfacrowid
		{
			get 
			{ 
                return _adminfacrowidNonDefault;
			}
			set 
			{
            
                _adminfacrowidNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINID" field.  Mandatory.
		/// </summary>
		public decimal? Adminid
		{
			get 
			{ 
                return _adminidNonDefault;
			}
			set 
			{
            
                _adminidNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_INTERNAL_ID" field.  
		/// </summary>
		public decimal? FacilityInternalID
		{
			get 
			{ 
                return _facilityInternalIDNonDefault;
			}
			set 
			{
            
                _facilityInternalIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PRIMARYADM" field.  
		/// </summary>
		public decimal? Primaryadm
		{
			get 
			{ 
                return _primaryadmNonDefault;
			}
			set 
			{
            
                _primaryadmNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACID" field. Length must be between 0 and 16 characters. 
		/// </summary>
		public string Facid
		{
			get 
			{ 
                if(_facidNonDefault==null)return _facidNonDefault;
				else return _facidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 16)
					throw new ArgumentException("Facid length must be between 0 and 16 characters.");

				
                if(value ==null)
                {
                    _facidNonDefault =null;//null value 
                }
                else
                {		           
		            _facidNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMTYPE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string Admtype
		{
			get 
			{ 
                if(_admtypeNonDefault==null)return _admtypeNonDefault;
				else return _admtypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("Admtype length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _admtypeNonDefault =null;//null value 
                }
                else
                {		           
		            _admtypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMTYPEDES" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string Admtypedes
		{
			get 
			{ 
                if(_admtypedesNonDefault==null)return _admtypedesNonDefault;
				else return _admtypedesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("Admtypedes length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _admtypedesNonDefault =null;//null value 
                }
                else
                {		           
		            _admtypedesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STARTED" field.  
		/// </summary>
		public DateTime? Started
		{
			get 
			{ 
                return _startedNonDefault;
			}
			set 
			{
            
                _startedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "END" field.  
		/// </summary>
		public DateTime? End
		{
			get 
			{ 
                return _endNonDefault;
			}
			set 
			{
            
                _endNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EMPLOYEEID" field. Length must be between 0 and 16 characters. 
		/// </summary>
		public string Employeeid
		{
			get 
			{ 
                if(_employeeidNonDefault==null)return _employeeidNonDefault;
				else return _employeeidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 16)
					throw new ArgumentException("Employeeid length must be between 0 and 16 characters.");

				
                if(value ==null)
                {
                    _employeeidNonDefault =null;//null value 
                }
                else
                {		           
		            _employeeidNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CREATED" field.  
		/// </summary>
		public DateTime? Created
		{
			get 
			{ 
                return _createdNonDefault;
			}
			set 
			{
            
                _createdNonDefault = value; 
			}
		}

		#endregion
		
		#region Methods (Public)

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
		/// DLGenerator			05/24/2011 11:58:33 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_adminfacrowid' as parameter 'Adminfacrowid' of the stored procedure.
			if(_adminfacrowidNonDefault!=null)
                oDatabaseHelper.AddParameter("@Adminfacrowid", _adminfacrowidNonDefault );
            else
                oDatabaseHelper.AddParameter("@Adminfacrowid", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMINFAC_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_MdsdbAdminfacPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
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
		public static bool Delete(BO_MdsdbAdminfacPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMINFAC_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_MdsdbAdminfacFields">Field of the class BO_MdsdbAdminfac</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
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
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MDSDB_ADMINFAC_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_MdsdbAdminfacPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_MdsdbAdminfac</returns>
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
		public static BO_MdsdbAdminfac SelectOne(BO_MdsdbAdminfacPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMINFAC_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_MdsdbAdminfac obj=new BO_MdsdbAdminfac();	
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
		/// <returns>list of objects of class BO_MdsdbAdminfac in the form of object of BO_MdsdbAdminfacs </returns>
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
		public static BO_MdsdbAdminfacs SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMINFAC_SelectAll", ref ExecutionState);
			BO_MdsdbAdminfacs BO_MdsdbAdminfacs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MdsdbAdminfacs;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_MdsdbAdminfac</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_MdsdbAdminfac in the form of an object of class BO_MdsdbAdminfacs</returns>
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
		public static BO_MdsdbAdminfacs SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MDSDB_ADMINFAC_SelectByField", ref ExecutionState);
			BO_MdsdbAdminfacs BO_MdsdbAdminfacs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_MdsdbAdminfacs;
			
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
		/// <param name="obj" type="MDSDB_ADMINFAC">Object of MDSDB_ADMINFAC to populate</param>
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
		internal static void PopulateObjectFromReader(BO_MdsdbAdminfacBase obj,IDataReader rdr) 
		{

			obj.Adminfacrowid = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Adminfacrowid)));
			obj.Adminid = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Adminid)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.FacilityInternalID)))
			{
				obj.FacilityInternalID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MdsdbAdminfacFields.FacilityInternalID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Primaryadm)))
			{
				obj.Primaryadm = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Primaryadm)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Facid)))
			{
				obj.Facid = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Facid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Admtype)))
			{
				obj.Admtype = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Admtype));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Admtypedes)))
			{
				obj.Admtypedes = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Admtypedes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Started)))
			{
				obj.Started = rdr.GetDateTime(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Started));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.End)))
			{
				obj.End = rdr.GetDateTime(rdr.GetOrdinal(BO_MdsdbAdminfacFields.End));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Employeeid)))
			{
				obj.Employeeid = rdr.GetString(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Employeeid));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Created)))
			{
				obj.Created = rdr.GetDateTime(rdr.GetOrdinal(BO_MdsdbAdminfacFields.Created));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_MdsdbAdminfacs</returns>
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
		internal static BO_MdsdbAdminfacs PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_MdsdbAdminfacs list = new BO_MdsdbAdminfacs();
			
			while (rdr.Read())
			{
				BO_MdsdbAdminfac obj = new BO_MdsdbAdminfac();
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
		/// <returns>Object of BO_MdsdbAdminfacs</returns>
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
		internal static BO_MdsdbAdminfacs PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_MdsdbAdminfacs list = new BO_MdsdbAdminfacs();
			
            if (rdr.Read())
            {
                BO_MdsdbAdminfac obj = new BO_MdsdbAdminfac();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_MdsdbAdminfac();
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
