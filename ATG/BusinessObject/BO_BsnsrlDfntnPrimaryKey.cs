//
// Class	:	BO_BsnsrlDfntnPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:30 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BsnsrlDfntnPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_dfntnIDNonDefault       	= null;
		private decimal?       	_mstrIDNonDefault        	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BsnsrlDfntnPrimaryKey(decimal? dfntnID,decimal? mstrID) 
		{
	
			
            this._dfntnIDNonDefault = dfntnID;
			
            this._mstrIDNonDefault = mstrID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "DFNTN_ID" field.  Mandatory.
		/// </summary>
		public decimal? DfntnID
		{
			get 
			{ 
                return _dfntnIDNonDefault;
			}
			set 
			{
            
                _dfntnIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// DLGenerator			05/24/2011 11:58:30 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("DfntnID",_dfntnIDNonDefault.ToString());
			nvc.Add("MstrID",_mstrIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
