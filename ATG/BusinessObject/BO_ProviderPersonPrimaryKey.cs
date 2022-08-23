//
// Class	:	BO_ProviderPersonPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:32 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ProviderPersonPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_personIDNonDefault      	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ProviderPersonPrimaryKey(decimal? popsIntID,decimal? personID,decimal? applicationID) 
		{
	
			
            this._popsIntIDNonDefault = popsIntID;
			
            this._personIDNonDefault = personID;
			
            this._applicationIDNonDefault = applicationID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:32 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			nvc.Add("PersonID",_personIDNonDefault.ToString());
			nvc.Add("ApplicationID",_applicationIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
