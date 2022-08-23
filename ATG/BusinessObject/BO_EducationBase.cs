//
// Class	:	BO_EducationBase.cs
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
	public class BO_EducationFields
	{
		public const string EducationID               = "EDUCATION_ID";
		public const string PersonID                  = "PERSON_ID";
		public const string CollegeSchool             = "COLLEGE_SCHOOL";
		public const string GraduationDate            = "GRADUATION_DATE";
		public const string DegreeObtained            = "DEGREE_OBTAINED";
	}
	
	/// <summary>
	/// Data access class for the "EDUCATION" table.
	/// </summary>
	[Serializable]
	public class BO_EducationBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_educationIDNonDefault   	= null;
		private decimal?       	_personIDNonDefault      	= null;
		private string         	_collegeSchoolNonDefault 	= null;
		private DateTime?      	_graduationDateNonDefault	= null;
		private string         	_degreeObtainedNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_EducationBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? EducationID
		{
			get 
			{ 
                return _educationIDNonDefault;
			}
			set 
			{
            
                _educationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
		/// </summary>
		public decimal? PersonID
		{
			get 
			{ 
                return _personIDNonDefault;
			}
			set 
			{
            
                _personIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "COLLEGE_SCHOOL" field. Length must be between 0 and 100 characters. Mandatory.
		/// </summary>
		public string CollegeSchool
		{
			get 
			{ 
                if(_collegeSchoolNonDefault==null)return _collegeSchoolNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _collegeSchoolNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 100)
					throw new ArgumentException("CollegeSchool length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _collegeSchoolNonDefault =null;//null value 
                }
                else
                {		           
		            _collegeSchoolNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GRADUATION_DATE" field.  
		/// </summary>
		public DateTime? GraduationDate
		{
			get 
			{ 
                return _graduationDateNonDefault;
			}
			set 
			{
            
                _graduationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DEGREE_OBTAINED" field. Length must be between 0 and 50 characters. Mandatory.
		/// </summary>
		public string DegreeObtained
		{
			get 
			{ 
                if(_degreeObtainedNonDefault==null)return _degreeObtainedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _degreeObtainedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 50)
					throw new ArgumentException("DegreeObtained length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _degreeObtainedNonDefault =null;//null value 
                }
                else
                {		           
		            _degreeObtainedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
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
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
              
			// Pass the value of '_collegeSchool' as parameter 'CollegeSchool' of the stored procedure.
			if(_collegeSchoolNonDefault!=null)
              oDatabaseHelper.AddParameter("@CollegeSchool", _collegeSchoolNonDefault);
            else
              oDatabaseHelper.AddParameter("@CollegeSchool", DBNull.Value );
              
			// Pass the value of '_graduationDate' as parameter 'GraduationDate' of the stored procedure.
			if(_graduationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GraduationDate", _graduationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GraduationDate", DBNull.Value );
              
			// Pass the value of '_degreeObtained' as parameter 'DegreeObtained' of the stored procedure.
			if(_degreeObtainedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DegreeObtained", _degreeObtainedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DegreeObtained", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EDUCATION_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
			
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// Pass the value of '_collegeSchool' as parameter 'CollegeSchool' of the stored procedure.
			if(_collegeSchoolNonDefault!=null)
              oDatabaseHelper.AddParameter("@CollegeSchool", _collegeSchoolNonDefault);
            else
              oDatabaseHelper.AddParameter("@CollegeSchool", DBNull.Value );
			// Pass the value of '_graduationDate' as parameter 'GraduationDate' of the stored procedure.
			if(_graduationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GraduationDate", _graduationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GraduationDate", DBNull.Value );
			// Pass the value of '_degreeObtained' as parameter 'DegreeObtained' of the stored procedure.
			if(_degreeObtainedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DegreeObtained", _degreeObtainedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DegreeObtained", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_Insert", ref ExecutionState);
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
			
			// Pass the value of '_educationID' as parameter 'EducationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@EducationID", _educationIDNonDefault );
            
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            
			// Pass the value of '_collegeSchool' as parameter 'CollegeSchool' of the stored procedure.
			oDatabaseHelper.AddParameter("@CollegeSchool", _collegeSchoolNonDefault );
            
			// Pass the value of '_graduationDate' as parameter 'GraduationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@GraduationDate", _graduationDateNonDefault );
            
			// Pass the value of '_degreeObtained' as parameter 'DegreeObtained' of the stored procedure.
			oDatabaseHelper.AddParameter("@DegreeObtained", _degreeObtainedNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_Update", ref ExecutionState);
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
			
			// Pass the value of '_educationID' as parameter 'EducationID' of the stored procedure.
			if(_educationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@EducationID", _educationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@EducationID", DBNull.Value );
			// Pass the value of '_personID' as parameter 'PersonID' of the stored procedure.
			if(_personIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PersonID", _personIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_EducationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
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
		public static bool Delete(BO_EducationPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_EducationFields">Field of the class BO_Education</param>
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
			
			oDatabaseHelper.ExecuteScalar("GEN_EDUCATION_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_EducationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Education</returns>
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
		public static BO_Education SelectOne(BO_EducationPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EDUCATION_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Education obj=new BO_Education();	
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
		/// <returns>list of objects of class BO_Education in the form of object of BO_Educations </returns>
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
		public static BO_Educations SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EDUCATION_SelectAll", ref ExecutionState);
			BO_Educations BO_Educations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Educations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Education</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Education in the form of an object of class BO_Educations</returns>
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
		public static BO_Educations SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EDUCATION_SelectByField", ref ExecutionState);
			BO_Educations BO_Educations = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Educations;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Educations</returns>
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
		public static BO_Educations SelectAllByForeignKeyPersonID(BO_PersonPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Educations obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_EDUCATION_SelectAllByForeignKeyPersonID", ref ExecutionState);
			obj = new BO_Educations();
			obj = BO_Education.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be deleted.</param>
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
		public static bool DeleteAllByForeignKeyPersonID(BO_PersonPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_EDUCATION_DeleteAllByForeignKeyPersonID", ref ExecutionState);
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
		/// <param name="obj" type="EDUCATION">Object of EDUCATION to populate</param>
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
		internal static void PopulateObjectFromReader(BO_EducationBase obj,IDataReader rdr) 
		{

			obj.EducationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_EducationFields.EducationID)));
			obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_EducationFields.PersonID)));
			obj.CollegeSchool = rdr.GetString(rdr.GetOrdinal(BO_EducationFields.CollegeSchool));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_EducationFields.GraduationDate)))
			{
				obj.GraduationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_EducationFields.GraduationDate));
			}
			
			obj.DegreeObtained = rdr.GetString(rdr.GetOrdinal(BO_EducationFields.DegreeObtained));

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Educations</returns>
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
		internal static BO_Educations PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Educations list = new BO_Educations();
			
			while (rdr.Read())
			{
				BO_Education obj = new BO_Education();
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
		/// <returns>Object of BO_Educations</returns>
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
		internal static BO_Educations PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Educations list = new BO_Educations();
			
            if (rdr.Read())
            {
                BO_Education obj = new BO_Education();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Education();
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
