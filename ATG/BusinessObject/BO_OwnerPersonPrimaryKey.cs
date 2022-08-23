//
// Class	:	BO_OwnerPersonPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:23 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_OwnerPersonPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_legalEntityIDNonDefault 	= null;
		private decimal?       	_personIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_OwnerPersonPrimaryKey(decimal? legalEntityID,decimal? personID) 
		{
	
			
            this._legalEntityIDNonDefault = legalEntityID;
			
            this._personIDNonDefault = personID;

		}

		#endregion

        #region Properties

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
			
			nvc.Add("LegalEntityID",_legalEntityIDNonDefault.ToString());
			nvc.Add("PersonID",_personIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
