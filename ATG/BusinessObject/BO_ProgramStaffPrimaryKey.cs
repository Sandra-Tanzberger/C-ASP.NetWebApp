//
// Class	:	BO_ProgramStaffPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:33 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ProgramStaffPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_programStaffIDNonDefault	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ProgramStaffPrimaryKey(decimal? programStaffID) 
		{
	
			
            this._programStaffIDNonDefault = programStaffID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "PROGRAM_STAFF_ID" field.  Mandatory.
		/// </summary>
		public decimal? ProgramStaffID
		{
			get 
			{ 
                return _programStaffIDNonDefault;
			}
			set 
			{
            
                _programStaffIDNonDefault = value; 
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
			
			nvc.Add("ProgramStaffID",_programStaffIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
