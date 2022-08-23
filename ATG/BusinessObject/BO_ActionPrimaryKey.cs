//
// Class	:	BO_ActionPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/29/2010 9:56:48 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ActionPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_actionIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ActionPrimaryKey(decimal? actionID) 
		{
	
			
            this._actionIDNonDefault = actionID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "ACTION_ID" field.  Mandatory.
		/// </summary>
		public decimal? ActionID
		{
			get 
			{ 
                return _actionIDNonDefault;
			}
			set 
			{
            
                _actionIDNonDefault = value; 
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
		/// DLGenerator			12/29/2010 9:56:48 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ActionID",_actionIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
