//
// Class	:	BO_VehiclePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/07/2013 4:38:07 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_VehiclePrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_vehicleRecIDNonDefault  	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_VehiclePrimaryKey(decimal? vehicleRecID,decimal? popsIntID) 
		{
	
			
            this._vehicleRecIDNonDefault = vehicleRecID;
			
            this._popsIntIDNonDefault = popsIntID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "VEHICLE_REC_ID" field.  Mandatory.
		/// </summary>
		public decimal? VehicleRecID
		{
			get 
			{ 
                return _vehicleRecIDNonDefault;
			}
			set 
			{
            
                _vehicleRecIDNonDefault = value; 
			}
		}

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
		/// DLGenerator			01/07/2013 4:38:07 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("VehicleRecID",_vehicleRecIDNonDefault.ToString());
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
