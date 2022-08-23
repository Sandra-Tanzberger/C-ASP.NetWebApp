//
// Class	:	BO_InsuranceCarrierPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:27 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_InsuranceCarrierPrimaryKey
    {

        #region Class Level Variables
		private string         	_carrierCodeNonDefault   	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_InsuranceCarrierPrimaryKey(string carrierCode) 
		{
	
			
            this._carrierCodeNonDefault = carrierCode;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "CARRIER_CODE" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string CarrierCode
		{
			get 
			{ 
                if(_carrierCodeNonDefault==null)return _carrierCodeNonDefault;
				else return _carrierCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("CarrierCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _carrierCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _carrierCodeNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			05/24/2011 11:58:27 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("CarrierCode",_carrierCodeNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
