//
// Class	:	BO_EducationPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:24 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_EducationPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_educationIDNonDefault   	= null;
		private decimal?       	_personIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_EducationPrimaryKey(decimal? educationID,decimal? personID) 
		{
	
			
            this._educationIDNonDefault = educationID;
			
            this._personIDNonDefault = personID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "EDUCATION_ID" field.  Mandatory.
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
		/// The foreign key connected with another persistent object.
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

		#endregion

        #region Methods (Public)

		/// <summary>
        /// Method to get the list of fields and their values
        /// </summary>
		///
        /// <returns>Name value collection containing the fields and the values</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			05/24/2011 11:58:24 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("EducationID",_educationIDNonDefault.ToString());
			nvc.Add("PersonID",_personIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
