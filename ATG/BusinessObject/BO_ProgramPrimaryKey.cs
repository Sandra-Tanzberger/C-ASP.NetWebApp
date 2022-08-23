//
// Class	:	BO_ProgramPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:22 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ProgramPrimaryKey
    {

        #region Class Level Variables
		private string         	_programIDNonDefault     	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ProgramPrimaryKey(string programID) 
		{
	
			
            this._programIDNonDefault = programID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "PROGRAM_ID" field. Length must be between 0 and 3 characters. Mandatory.
		/// </summary>
		public string ProgramID
		{
			get 
			{ 
                if(_programIDNonDefault==null)return _programIDNonDefault;
				else return _programIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = value.Replace("'", "''"); 
                }
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
		/// DLGenerator			05/24/2011 11:58:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("ProgramID",_programIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
