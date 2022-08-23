//
// Class	:	BO_RlOprtrPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:24 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_RlOprtrPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_rlOprtrIDNonDefault     	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_RlOprtrPrimaryKey(decimal? rlOprtrID) 
		{
	
			
            this._rlOprtrIDNonDefault = rlOprtrID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "RL_OPRTR_ID" field.  Mandatory.
		/// </summary>
		public decimal? RlOprtrID
		{
			get 
			{ 
                return _rlOprtrIDNonDefault;
			}
			set 
			{
            
                _rlOprtrIDNonDefault = value; 
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
			
			nvc.Add("RlOprtrID",_rlOprtrIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
