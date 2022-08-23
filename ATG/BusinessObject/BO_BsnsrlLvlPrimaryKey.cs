//
// Class	:	BO_BsnsrlLvlPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:20 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_BsnsrlLvlPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_lvlIDNonDefault         	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_BsnsrlLvlPrimaryKey(decimal? lvlID) 
		{
	
			
            this._lvlIDNonDefault = lvlID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "LVL_ID" field.  Mandatory.
		/// </summary>
		public decimal? LvlID
		{
			get 
			{ 
                return _lvlIDNonDefault;
			}
			set 
			{
            
                _lvlIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:20 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("LvlID",_lvlIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
