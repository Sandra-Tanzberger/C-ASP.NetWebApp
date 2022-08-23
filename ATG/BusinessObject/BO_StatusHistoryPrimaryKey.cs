//
// Class	:	BO_StatusHistoryPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:28 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_StatusHistoryPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_statusIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_StatusHistoryPrimaryKey(decimal? applicationID,decimal? statusID) 
		{
	
			
            this._applicationIDNonDefault = applicationID;
			
            this._statusIDNonDefault = statusID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ApplicationID
		{
			get 
			{ 
                return _applicationIDNonDefault;
			}
			set 
			{
            
                _applicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATUS_ID" field.  Mandatory.
		/// </summary>
		public decimal? StatusID
		{
			get 
			{ 
                return _statusIDNonDefault;
			}
			set 
			{
            
                _statusIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:28 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ApplicationID",_applicationIDNonDefault.ToString());
			nvc.Add("StatusID",_statusIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
