//
// Class	:	BO_ParishePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:24 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ParishePrimaryKey
    {

        #region Class Level Variables
		private string         	_parishCodeNonDefault    	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ParishePrimaryKey(string parishCode) 
		{
	
			
            this._parishCodeNonDefault = parishCode;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "PARISH_CODE" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				else return _parishCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _parishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _parishCodeNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			05/24/2011 11:58:24 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ParishCode",_parishCodeNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
