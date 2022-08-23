//
// Class	:	BO_BsnsrlMstrPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:24 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BsnsrlMstrPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_mstrIDNonDefault        	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BsnsrlMstrPrimaryKey(decimal? mstrID) 
		{
	
			
            this._mstrIDNonDefault = mstrID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "MSTR_ID" field.  Mandatory.
		/// </summary>
		public decimal? MstrID
		{
			get 
			{ 
                return _mstrIDNonDefault;
			}
			set 
			{
            
                _mstrIDNonDefault = value; 
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
			
			nvc.Add("MstrID",_mstrIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
