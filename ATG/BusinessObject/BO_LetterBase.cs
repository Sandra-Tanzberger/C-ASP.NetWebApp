//
// Class	:	BO_LetterBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/09/2012 2:03:36 PM
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
	public class BO_LetterFields
	{
		public const string LetterID                  = "LETTER_ID";
		public const string LetterType                = "LETTER_TYPE";
		public const string LetterDisplayName         = "LETTER_DISPLAY_NAME";
		public const string Programs                  = "PROGRAMS";
		public const string ReportName                = "REPORT_NAME";
	}
	
	/// <summary>
	/// Data access class for the "LETTERS" table.
	/// </summary>
	[Serializable]
	public class BO_LetterBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper;// = new DatabaseHelper();

		private decimal?       	_letterIDNonDefault      	= null;
		private string         	_letterTypeNonDefault    	= null;
		private string         	_letterDisplayNameNonDefault	= null;
		private string         	_programsNonDefault      	= null;
		private string         	_reportNameNonDefault    	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_LetterBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? LetterID
		{
			get 
			{ 
                return _letterIDNonDefault;
			}
			set 
			{
            
                _letterIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LETTER_TYPE" field. Length must be between 0 and 128 characters. Mandatory.
		/// </summary>
		public string LetterType
		{
			get 
			{ 
                if(_letterTypeNonDefault==null)return _letterTypeNonDefault;
				else return _letterTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 128)
					throw new ArgumentException("LetterType length must be between 0 and 128 characters.");

				
                if(value ==null)
                {
                    _letterTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _letterTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LETTER_DISPLAY_NAME" field. Length must be between 0 and 128 characters. Mandatory.
		/// </summary>
		public string LetterDisplayName
		{
			get 
			{ 
                if(_letterDisplayNameNonDefault==null)return _letterDisplayNameNonDefault;
				else return _letterDisplayNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 128)
					throw new ArgumentException("LetterDisplayName length must be between 0 and 128 characters.");

				
                if(value ==null)
                {
                    _letterDisplayNameNonDefault =null;//null value 
                }
                else
                {		           
		            _letterDisplayNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROGRAMS" field. Length must be between 0 and 128 characters. Mandatory.
		/// </summary>
		public string Programs
		{
			get 
			{ 
                if(_programsNonDefault==null)return _programsNonDefault;
				else return _programsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 128)
					throw new ArgumentException("Programs length must be between 0 and 128 characters.");

				
                if(value ==null)
                {
                    _programsNonDefault =null;//null value 
                }
                else
                {		           
		            _programsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REPORT_NAME" field. Length must be between 0 and 128 characters. Mandatory.
		/// </summary>
		public string ReportName
		{
			get 
			{ 
                if(_reportNameNonDefault==null)return _reportNameNonDefault;
				else return _reportNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 128)
					throw new ArgumentException("ReportName length must be between 0 and 128 characters.");

				
                if(value ==null)
                {
                    _reportNameNonDefault =null;//null value 
                }
                else
                {		           
		            _reportNameNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterType' as parameter 'LetterType' of the stored procedure.
			if(_letterTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterType", _letterTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterType", DBNull.Value );
              
			// Pass the value of '_letterDisplayName' as parameter 'LetterDisplayName' of the stored procedure.
			if(_letterDisplayNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterDisplayName", _letterDisplayNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterDisplayName", DBNull.Value );
              
			// Pass the value of '_programs' as parameter 'Programs' of the stored procedure.
			if(_programsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Programs", _programsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Programs", DBNull.Value );
              
			// Pass the value of '_reportName' as parameter 'ReportName' of the stored procedure.
			if(_reportNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReportName", _reportNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReportName", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_LETTERS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterType' as parameter 'LetterType' of the stored procedure.
			if(_letterTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterType", _letterTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterType", DBNull.Value );
			// Pass the value of '_letterDisplayName' as parameter 'LetterDisplayName' of the stored procedure.
			if(_letterDisplayNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterDisplayName", _letterDisplayNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterDisplayName", DBNull.Value );
			// Pass the value of '_programs' as parameter 'Programs' of the stored procedure.
			if(_programsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Programs", _programsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Programs", DBNull.Value );
			// Pass the value of '_reportName' as parameter 'ReportName' of the stored procedure.
			if(_reportNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReportName", _reportNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReportName", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_Insert", ref ExecutionState);
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
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterID' as parameter 'LetterID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterID", _letterIDNonDefault );
            
			// Pass the value of '_letterType' as parameter 'LetterType' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterType", _letterTypeNonDefault );
            
			// Pass the value of '_letterDisplayName' as parameter 'LetterDisplayName' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterDisplayName", _letterDisplayNameNonDefault );
            
			// Pass the value of '_programs' as parameter 'Programs' of the stored procedure.
			oDatabaseHelper.AddParameter("@Programs", _programsNonDefault );
            
			// Pass the value of '_reportName' as parameter 'ReportName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ReportName", _reportNameNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_Update", ref ExecutionState);
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
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterID' as parameter 'LetterID' of the stored procedure.
			if(_letterIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@LetterID", _letterIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@LetterID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_LetterPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_LetterPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_LetterFields">Field of the class BO_Letter</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_LetterPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Letter</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Letter SelectOne(BO_LetterPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Letter obj=new BO_Letter();	
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
		/// <returns>list of objects of class BO_Letter in the form of object of BO_Letters </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Letters SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_SelectAll", ref ExecutionState);
			BO_Letters BO_Letters = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Letters;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Letter</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Letter in the form of an object of class BO_Letters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Letters SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_SelectByField", ref ExecutionState);
			BO_Letters BO_Letters = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Letters;
			
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
	    /// DLGenerator			08/09/2012 2:03:36 PM		Created function
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
		/// <param name="obj" type="LETTERS">Object of LETTERS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_LetterBase obj,IDataReader rdr) 
		{

			obj.LetterID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LetterFields.LetterID)));
			obj.LetterType = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.LetterType));
			obj.LetterDisplayName = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.LetterDisplayName));
			obj.Programs = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.Programs));
			obj.ReportName = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.ReportName));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Letters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Letters PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Letters list = new BO_Letters();
			
			while (rdr.Read())
			{
				BO_Letter obj = new BO_Letter();
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
		/// <returns>Object of BO_Letters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/09/2012 2:03:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Letters PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Letters list = new BO_Letters();
			
            if (rdr.Read())
            {
                BO_Letter obj = new BO_Letter();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Letter();
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
