//
// Class	:	BO_OwnerOtherProviderPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:22 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_OwnerOtherProviderPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_ownOtherProvIDNonDefault	= null;
		private decimal?       	_legalEntityIDNonDefault 	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_OwnerOtherProviderPrimaryKey(decimal? ownOtherProvID,decimal? legalEntityID) 
		{
	
			
            this._ownOtherProvIDNonDefault = ownOtherProvID;
			
            this._legalEntityIDNonDefault = legalEntityID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "OWN_OTHER_PROV_ID" field.  Mandatory.
		/// </summary>
		public decimal? OwnOtherProvID
		{
			get 
			{ 
                return _ownOtherProvIDNonDefault;
			}
			set 
			{
            
                _ownOtherProvIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? LegalEntityID
		{
			get 
			{ 
                return _legalEntityIDNonDefault;
			}
			set 
			{
            
                _legalEntityIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("OwnOtherProvID",_ownOtherProvIDNonDefault.ToString());
			nvc.Add("LegalEntityID",_legalEntityIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
