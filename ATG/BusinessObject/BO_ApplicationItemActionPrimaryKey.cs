//
// Class	:	BO_ApplicationItemActionPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/15/2010 3:59:46 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ApplicationItemActionPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_checklistItemIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ApplicationItemActionPrimaryKey(decimal? applicationID,decimal? checklistItemID) 
		{
	
			
            this._applicationIDNonDefault = applicationID;
			
            this._checklistItemIDNonDefault = checklistItemID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? ApplicationID
		{
			get 
			{ 
                return _applicationIDNonDefault;
			}
			set 
			{
            
                _applicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECKLIST_ITEM_ID" field.  Mandatory.
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
		/// DLGenerator			10/15/2010 3:59:46 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ApplicationID",_applicationIDNonDefault.ToString());
			nvc.Add("ChecklistItemID",_checklistItemIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
