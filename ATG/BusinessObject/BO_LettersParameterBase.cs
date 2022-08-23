//
// Class	:	BO_LettersParameterBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/03/2012 1:51:11 PM
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
	public class BO_LettersParameterFields
	{
		public const string ParameterID               = "PARAMETER_ID";
		public const string LetterID                  = "LETTER_ID";
		public const string ParameterName             = "PARAMETER_NAME";
		public const string TableName                 = "TABLE_NAME";
		public const string ColumnName                = "COLUMN_NAME";
	}
	
	/// <summary>
	/// Data access class for the "LETTERS_PARAMETERS" table.
	/// </summary>
	[Serializable]
	public class BO_LettersParameterBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper;// = new DatabaseHelper();

		private decimal?       	_parameterIDNonDefault   	= null;
		private decimal?       	_letterIDNonDefault      	= null;
		private string         	_parameterNameNonDefault 	= null;
		private string         	_tableNameNonDefault     	= null;
		private string         	_columnNameNonDefault    	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_LettersParameterBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ParameterID
		{
			get 
			{ 
                return _parameterIDNonDefault;
			}
			set 
			{
            
                _parameterIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LETTER_ID" field.  Mandatory.
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
		/// This property is mapped to the "PARAMETER_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string ParameterName
		{
			get 
			{ 
                if(_parameterNameNonDefault==null)return _parameterNameNonDefault;
				else return _parameterNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("ParameterName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _parameterNameNonDefault =null;//null value 
                }
                else
                {		           
		            _parameterNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TABLE_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string TableName
		{
			get 
			{ 
                if(_tableNameNonDefault==null)return _tableNameNonDefault;
				else return _tableNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("TableName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _tableNameNonDefault =null;//null value 
                }
                else
                {		           
		            _tableNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COLUMN_NAME" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string ColumnName
		{
			get 
			{ 
                if(_columnNameNonDefault==null)return _columnNameNonDefault;
				else return _columnNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("ColumnName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _columnNameNonDefault =null;//null value 
                }
                else
                {		           
		            _columnNameNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterID' as parameter 'LetterID' of the stored procedure.
			if(_letterIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterID", _letterIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterID", DBNull.Value );
              
			// Pass the value of '_parameterName' as parameter 'ParameterName' of the stored procedure.
			if(_parameterNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParameterName", _parameterNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParameterName", DBNull.Value );
              
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			if(_tableNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@TableName", DBNull.Value );
              
			// Pass the value of '_columnName' as parameter 'ColumnName' of the stored procedure.
			if(_columnNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ColumnName", _columnNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ColumnName", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_PARAMETERS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_letterID' as parameter 'LetterID' of the stored procedure.
			if(_letterIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@LetterID", _letterIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@LetterID", DBNull.Value );
			// Pass the value of '_parameterName' as parameter 'ParameterName' of the stored procedure.
			if(_parameterNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParameterName", _parameterNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParameterName", DBNull.Value );
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			if(_tableNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@TableName", DBNull.Value );
			// Pass the value of '_columnName' as parameter 'ColumnName' of the stored procedure.
			if(_columnNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ColumnName", _columnNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ColumnName", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_Insert", ref ExecutionState);
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
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parameterID' as parameter 'ParameterID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParameterID", _parameterIDNonDefault );
            
			// Pass the value of '_letterID' as parameter 'LetterID' of the stored procedure.
			oDatabaseHelper.AddParameter("@LetterID", _letterIDNonDefault );
            
			// Pass the value of '_parameterName' as parameter 'ParameterName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParameterName", _parameterNameNonDefault );
            
			// Pass the value of '_tableName' as parameter 'TableName' of the stored procedure.
			oDatabaseHelper.AddParameter("@TableName", _tableNameNonDefault );
            
			// Pass the value of '_columnName' as parameter 'ColumnName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ColumnName", _columnNameNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_Update", ref ExecutionState);
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
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_parameterID' as parameter 'ParameterID' of the stored procedure.
			if(_parameterIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ParameterID", _parameterIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ParameterID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_LettersParameterPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_LettersParameterPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_LettersParameterFields">Field of the class BO_LettersParameter</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_LETTERS_PARAMETERS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_LettersParameterPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_LettersParameter</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LettersParameter SelectOne(BO_LettersParameterPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_PARAMETERS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_LettersParameter obj=new BO_LettersParameter();	
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
		/// <returns>list of objects of class BO_LettersParameter in the form of object of BO_LettersParameters </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LettersParameters SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_PARAMETERS_SelectAll", ref ExecutionState);
			BO_LettersParameters BO_LettersParameters = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LettersParameters;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_LettersParameter</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_LettersParameter in the form of an object of class BO_LettersParameters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_LettersParameters SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_LETTERS_PARAMETERS_SelectByField", ref ExecutionState);
			BO_LettersParameters BO_LettersParameters = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_LettersParameters;
			
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
	    /// DLGenerator			08/03/2012 1:51:11 PM		Created function
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
		/// <param name="obj" type="LETTERS_PARAMETERS">Object of LETTERS_PARAMETERS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_LettersParameterBase obj,IDataReader rdr) 
		{

			obj.ParameterID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LettersParameterFields.ParameterID)));
			obj.LetterID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LettersParameterFields.LetterID)));
			obj.ParameterName = rdr.GetString(rdr.GetOrdinal(BO_LettersParameterFields.ParameterName));
			obj.TableName = rdr.GetString(rdr.GetOrdinal(BO_LettersParameterFields.TableName));
			obj.ColumnName = rdr.GetString(rdr.GetOrdinal(BO_LettersParameterFields.ColumnName));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_LettersParameters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LettersParameters PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_LettersParameters list = new BO_LettersParameters();
			
			while (rdr.Read())
			{
				BO_LettersParameter obj = new BO_LettersParameter();
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
		/// <returns>Object of BO_LettersParameters</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/03/2012 1:51:11 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_LettersParameters PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_LettersParameters list = new BO_LettersParameters();
			
            if (rdr.Read())
            {
                BO_LettersParameter obj = new BO_LettersParameter();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_LettersParameter();
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
