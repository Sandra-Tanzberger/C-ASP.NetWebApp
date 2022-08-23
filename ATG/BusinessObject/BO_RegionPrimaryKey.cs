//
// Class	:	BO_RegionPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:22 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_RegionPrimaryKey
    {

        #region Class Level Variables
		private string         	_regionCodeNonDefault    	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_RegionPrimaryKey(string regionCode) 
		{
	
			
            this._regionCodeNonDefault = regionCode;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "REGION_CODE" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string RegionCode
		{
			get 
			{ 
                if(_regionCodeNonDefault==null)return _regionCodeNonDefault;
				else return _regionCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("RegionCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _regionCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _regionCodeNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			05/24/2011 11:58:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("RegionCode",_regionCodeNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
