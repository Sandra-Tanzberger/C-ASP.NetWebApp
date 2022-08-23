//
// Class	:	BO_ApplicationAccessBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/23/2019 2:37:55 PM
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
	public class BO_ApplicationAccessFields
	{
		public const string Grpid                     = "GRPID";
		public const string Loginid                   = "LOGINID";
	}
	
	/// <summary>
	/// Data access class for the "APPLICATION_ACCESS" table.
	/// </summary>
	[Serializable]
	public class BO_ApplicationAccessBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_grpidNonDefault         	= null;
		private string         	_loginidNonDefault       	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ApplicationAccessBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "GRPID" field. Length must be between 0 and 20 characters. Mandatory.
		/// </summary>
		public string Grpid
		{
			get 
			{ 
                if(_grpidNonDefault==null)return _grpidNonDefault;
				else return _grpidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 20)
					throw new ArgumentException("Grpid length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _grpidNonDefault =null;//null value 
                }
                else
                {		           
		            _grpidNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LOGINID" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string Loginid
		{
			get 
			{ 
                if(_loginidNonDefault==null)return _loginidNonDefault;
				else return _loginidNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("Loginid length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _loginidNonDefault =null;//null value 
                }
                else
                {		           
		            _loginidNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_grpid' as parameter 'Grpid' of the stored procedure.
			if(_grpidNonDefault!=null)
              oDatabaseHelper.AddParameter("@Grpid", _grpidNonDefault);
            else
              oDatabaseHelper.AddParameter("@Grpid", DBNull.Value );
              
			// Pass the value of '_loginid' as parameter 'Loginid' of the stored procedure.
			if(_loginidNonDefault!=null)
              oDatabaseHelper.AddParameter("@Loginid", _loginidNonDefault);
            else
              oDatabaseHelper.AddParameter("@Loginid", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ACCESS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ACCESS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_grpid' as parameter 'Grpid' of the stored procedure.
			if(_grpidNonDefault!=null)
              oDatabaseHelper.AddParameter("@Grpid", _grpidNonDefault);
            else
              oDatabaseHelper.AddParameter("@Grpid", DBNull.Value );
			// Pass the value of '_loginid' as parameter 'Loginid' of the stored procedure.
			if(_loginidNonDefault!=null)
              oDatabaseHelper.AddParameter("@Loginid", _loginidNonDefault);
            else
              oDatabaseHelper.AddParameter("@Loginid", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATION_ACCESS_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_ApplicationAccess in the form of object of BO_ApplicationAccesses </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationAccesses SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ACCESS_SelectAll", ref ExecutionState);
			BO_ApplicationAccesses BO_ApplicationAccesses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ApplicationAccesses;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_ApplicationAccess</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_ApplicationAccess in the form of an object of class BO_ApplicationAccesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_ApplicationAccesses SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATION_ACCESS_SelectByField", ref ExecutionState);
			BO_ApplicationAccesses BO_ApplicationAccesses = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_ApplicationAccesses;
			
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
	    /// DLGenerator			09/23/2019 2:37:55 PM		Created function
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
		/// <param name="obj" type="APPLICATION_ACCESS">Object of APPLICATION_ACCESS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ApplicationAccessBase obj,IDataReader rdr) 
		{

			obj.Grpid = rdr.GetString(rdr.GetOrdinal(BO_ApplicationAccessFields.Grpid));
			obj.Loginid = rdr.GetString(rdr.GetOrdinal(BO_ApplicationAccessFields.Loginid));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_ApplicationAccesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ApplicationAccesses PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_ApplicationAccesses list = new BO_ApplicationAccesses();
			
			while (rdr.Read())
			{
				BO_ApplicationAccess obj = new BO_ApplicationAccess();
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
		/// <returns>Object of BO_ApplicationAccesses</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			09/23/2019 2:37:55 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_ApplicationAccesses PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_ApplicationAccesses list = new BO_ApplicationAccesses();
			
            if (rdr.Read())
            {
                BO_ApplicationAccess obj = new BO_ApplicationAccess();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ApplicationAccess();
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
