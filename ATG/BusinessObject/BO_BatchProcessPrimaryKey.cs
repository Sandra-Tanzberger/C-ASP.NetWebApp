//
// Class	:	BO_BatchProcessPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:30 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BatchProcessPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_batchIDNonDefault       	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BatchProcessPrimaryKey(decimal? batchID) 
		{
	
			
            this._batchIDNonDefault = batchID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "BATCH_ID" field.  Mandatory.
		/// </summary>
		public decimal? BatchID
		{
			get 
			{ 
                return _batchIDNonDefault;
			}
			set 
			{
            
                _batchIDNonDefault = value; 
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
			
			nvc.Add("BatchID",_batchIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
