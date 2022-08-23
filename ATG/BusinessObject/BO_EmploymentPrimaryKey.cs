//
// Class	:	BO_EmploymentPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:23 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_EmploymentPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_employmentIDNonDefault  	= null;
		private decimal?       	_personIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_EmploymentPrimaryKey(decimal? employmentID,decimal? personID) 
		{
	
			
            this._employmentIDNonDefault = employmentID;
			
            this._personIDNonDefault = personID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "EMPLOYMENT_ID" field.  Mandatory.
		/// </summary>
		public decimal? EmploymentID
		{
			get 
			{ 
                return _employmentIDNonDefault;
			}
			set 
			{
            
                _employmentIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:23 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("EmploymentID",_employmentIDNonDefault.ToString());
			nvc.Add("PersonID",_personIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
