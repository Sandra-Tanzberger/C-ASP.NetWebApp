//
// Class	:	BO_AspenCommentPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/20/2019 12:46:53 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_AspenCommentPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_aspenCommentIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_AspenCommentPrimaryKey(decimal? aspenCommentID) 
		{
	
			
            this._aspenCommentIDNonDefault = aspenCommentID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "ASPEN_COMMENT_ID" field.  Mandatory.
		/// </summary>
		public decimal? AspenCommentID
		{
			get 
			{ 
                return _aspenCommentIDNonDefault;
			}
			set 
			{
            
                _aspenCommentIDNonDefault = value; 
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
		/// DLGenerator			06/20/2019 12:46:53 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("AspenCommentID",_aspenCommentIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
