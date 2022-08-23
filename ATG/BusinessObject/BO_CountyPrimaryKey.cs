//
// Class	:	BO_CountyPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	02/02/2011 1:42:41 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_CountyPrimaryKey
    {

        #region Class Level Variables
		private string         	_countyCodeNonDefault    	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_CountyPrimaryKey(string countyCode) 
		{
	
			
            this._countyCodeNonDefault = countyCode;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "COUNTY_CODE" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string CountyCode
		{
			get 
			{ 
                if(_countyCodeNonDefault==null)return _countyCodeNonDefault;
				else return _countyCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("CountyCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _countyCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _countyCodeNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			02/02/2011 1:42:41 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("CountyCode",_countyCodeNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
