//
// Class	:	BO_BsnsObjctDtlPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:25 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BsnsObjctDtlPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_objctDtlIDNonDefault    	= null;
		private decimal?       	_objctIDNonDefault       	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BsnsObjctDtlPrimaryKey(decimal? objctDtlID,decimal? objctID) 
		{
	
			
            this._objctDtlIDNonDefault = objctDtlID;
			
            this._objctIDNonDefault = objctID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "OBJCT_DTL_ID" field.  Mandatory.
		/// </summary>
		public decimal? ObjctDtlID
		{
			get 
			{ 
                return _objctDtlIDNonDefault;
			}
			set 
			{
            
                _objctDtlIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ObjctID
		{
			get 
			{ 
                return _objctIDNonDefault;
			}
			set 
			{
            
                _objctIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:25 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ObjctDtlID",_objctDtlIDNonDefault.ToString());
			nvc.Add("ObjctID",_objctIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
