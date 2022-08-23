//
// Class	:	BO_MdsdbAdminfacPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:33 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_MdsdbAdminfacPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_adminfacrowidNonDefault 	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_MdsdbAdminfacPrimaryKey(decimal? adminfacrowid) 
		{
	
			
            this._adminfacrowidNonDefault = adminfacrowid;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "ADMINFACROWID" field.  Mandatory.
		/// </summary>
		public decimal? Adminfacrowid
		{
			get 
			{ 
                return _adminfacrowidNonDefault;
			}
			set 
			{
            
                _adminfacrowidNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:33 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("Adminfacrowid",_adminfacrowidNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
