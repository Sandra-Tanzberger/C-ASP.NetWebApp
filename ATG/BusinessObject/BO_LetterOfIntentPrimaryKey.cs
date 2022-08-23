//
// Class	:	BO_LetterOfIntentPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:21 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_LetterOfIntentPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_letterOfIntentIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_LetterOfIntentPrimaryKey(decimal? letterOfIntentID) 
		{
	
			
            this._letterOfIntentIDNonDefault = letterOfIntentID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "LETTER_OF_INTENT_ID" field.  Mandatory.
		/// </summary>
		public decimal? LetterOfIntentID
		{
			get 
			{ 
                return _letterOfIntentIDNonDefault;
			}
			set 
			{
            
                _letterOfIntentIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:21 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("LetterOfIntentID",_letterOfIntentIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
