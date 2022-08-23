//
// Class	:	BO_LicensePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/31/2011 9:51:14 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_LicensePrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_licenseIDNonDefault     	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_LicensePrimaryKey(decimal? licenseID) 
		{
	
			
            this._licenseIDNonDefault = licenseID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "LICENSE_ID" field.  Mandatory.
		/// </summary>
		public decimal? LicenseID
		{
			get 
			{ 
                return _licenseIDNonDefault;
			}
			set 
			{
            
                _licenseIDNonDefault = value; 
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
		/// DLGenerator			10/31/2011 9:51:14 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("LicenseID",_licenseIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
