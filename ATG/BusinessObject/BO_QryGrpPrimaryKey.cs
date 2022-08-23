//
// Class	:	BO_QryGrpPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:20 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_QryGrpPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_grpIDNonDefault         	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_QryGrpPrimaryKey(decimal? grpID) 
		{
	
			
            this._grpIDNonDefault = grpID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "GRP_ID" field.  Mandatory.
		/// </summary>
		public decimal? GrpID
		{
			get 
			{ 
                return _grpIDNonDefault;
			}
			set 
			{
            
                _grpIDNonDefault = value; 
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
			
			nvc.Add("GrpID",_grpIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
