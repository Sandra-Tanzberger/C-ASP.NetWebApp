//
// Class	:	BO_ProviderLoginPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:21 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ProviderLoginPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_loginIDNonDefault       	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ProviderLoginPrimaryKey(decimal? popsIntID,string loginID) 
		{
	
			
            this._popsIntIDNonDefault = popsIntID;
			
            this._loginIDNonDefault = loginID;

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
		/// This property is mapped to the "LOGIN_ID" field. Length must be between 0 and 16 characters. Mandatory.
		/// </summary>
		public string LoginID
		{
			get 
			{ 
                if(_loginIDNonDefault==null)return _loginIDNonDefault;
				else return _loginIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 16)
					throw new ArgumentException("LoginID length must be between 0 and 16 characters.");

				
                if(value ==null)
                {
                    _loginIDNonDefault =null;//null value 
                }
                else
                {		           
		            _loginIDNonDefault = value.Replace("'", "''"); 
                }
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
		/// DLGenerator			05/24/2011 11:58:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			nvc.Add("LoginID",_loginIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
