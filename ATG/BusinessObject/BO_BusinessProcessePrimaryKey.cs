//
// Class	:	BO_BusinessProcessePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:32 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BusinessProcessePrimaryKey
    {

        #region Class Level Variables
		private string         	_businessProcessIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BusinessProcessePrimaryKey(string businessProcessID) 
		{
	
			
            this._businessProcessIDNonDefault = businessProcessID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "BUSINESS_PROCESS_ID" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string BusinessProcessID
		{
			get 
			{ 
                if(_businessProcessIDNonDefault==null)return _businessProcessIDNonDefault;
				else return _businessProcessIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("BusinessProcessID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _businessProcessIDNonDefault =null;//null value 
                }
                else
                {		           
		            _businessProcessIDNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			05/24/2011 11:58:32 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("BusinessProcessID",_businessProcessIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
