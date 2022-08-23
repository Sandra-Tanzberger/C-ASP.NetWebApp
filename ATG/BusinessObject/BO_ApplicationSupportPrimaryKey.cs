//
// Class	:	BO_ApplicationSupportPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	02/01/2017 10:46:09 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ApplicationSupportPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_applicationSupportIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ApplicationSupportPrimaryKey(decimal? applicationSupportID) 
		{
	
			
            this._applicationSupportIDNonDefault = applicationSupportID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "APPLICATION_SUPPORT_ID" field.  Mandatory.
		/// </summary>
		public decimal? ApplicationSupportID
		{
			get 
			{ 
                return _applicationSupportIDNonDefault;
			}
			set 
			{
            
                _applicationSupportIDNonDefault = value; 
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
		/// DLGenerator			02/01/2017 10:46:09 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ApplicationSupportID",_applicationSupportIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
