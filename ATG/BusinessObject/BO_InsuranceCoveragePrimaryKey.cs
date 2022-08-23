//
// Class	:	BO_InsuranceCoveragePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/24/2012 2:17:22 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_InsuranceCoveragePrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_carrierCodeNonDefault   	= null;
		private string         	_coverageTypeNonDefault  	= null;
		private DateTime?      	_effectiveDateNonDefault 	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_InsuranceCoveragePrimaryKey(decimal? popsIntID,string carrierCode,string coverageType,DateTime? effectiveDate) 
		{
	
			
            this._popsIntIDNonDefault = popsIntID;
			
            this._carrierCodeNonDefault = carrierCode;
			
            this._coverageTypeNonDefault = coverageType;
			
            this._effectiveDateNonDefault = effectiveDate;

		}

		#endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string CarrierCode
		{
			get 
			{ 
                if(_carrierCodeNonDefault==null)return _carrierCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _carrierCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
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
		            _carrierCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "COVERAGE_TYPE" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string CoverageType
		{
			get 
			{ 
                if(_coverageTypeNonDefault==null)return _coverageTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _coverageTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("CoverageType length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _coverageTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _coverageTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EFFECTIVE_DATE" field.  Mandatory.
		/// </summary>
		public DateTime? EffectiveDate
		{
			get 
			{ 
                return _effectiveDateNonDefault;
			}
			set 
			{
            
                _effectiveDateNonDefault = value; 
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
		/// DLGenerator			12/24/2012 2:17:22 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			nvc.Add("CarrierCode",_carrierCodeNonDefault.ToString());
			nvc.Add("CoverageType",_coverageTypeNonDefault.ToString());
			nvc.Add("EffectiveDate",_effectiveDateNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
