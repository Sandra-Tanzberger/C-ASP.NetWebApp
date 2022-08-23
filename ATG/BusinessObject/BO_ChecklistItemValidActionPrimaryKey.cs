//
// Class	:	BO_ChecklistItemValidActionPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/29/2010 9:56:50 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ChecklistItemValidActionPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_checklistItemIDNonDefault	= null;
		private decimal?       	_actionIDNonDefault      	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ChecklistItemValidActionPrimaryKey(decimal? checklistItemID,decimal? actionID) 
		{
	
			
            this._checklistItemIDNonDefault = checklistItemID;
			
            this._actionIDNonDefault = actionID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ChecklistItemID
		{
			get 
			{ 
                return _checklistItemIDNonDefault;
			}
			set 
			{
            
                _checklistItemIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// DLGenerator			12/29/2010 9:56:50 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ChecklistItemID",_checklistItemIDNonDefault.ToString());
			nvc.Add("ActionID",_actionIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
