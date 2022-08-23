//
// Class	:	BO_SubstationPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/07/2013 4:38:07 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_SubstationPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_substationIDNonDefault  	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_SubstationPrimaryKey(decimal? popsIntID,decimal? substationID) 
		{
	
			
            this._popsIntIDNonDefault = popsIntID;
			
            this._substationIDNonDefault = substationID;

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
		/// This property is mapped to the "SUBSTATION_ID" field.  Mandatory.
		/// </summary>
		public decimal? SubstationID
		{
			get 
			{ 
                return _substationIDNonDefault;
			}
			set 
			{
            
                _substationIDNonDefault = value; 
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
			
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			nvc.Add("SubstationID",_substationIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
