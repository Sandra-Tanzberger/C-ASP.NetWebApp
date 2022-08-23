//
// Class	:	BO_FileAttachPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/01/2011 8:38:03 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_FileAttachPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_fileAttachIDNonDefault  	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_FileAttachPrimaryKey(decimal? fileAttachID) 
		{
	
			
            this._fileAttachIDNonDefault = fileAttachID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "FILE_ATTACH_ID" field.  Mandatory.
		/// </summary>
		public decimal? FileAttachID
		{
			get 
			{ 
                return _fileAttachIDNonDefault;
			}
			set 
			{
            
                _fileAttachIDNonDefault = value; 
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
		/// DLGenerator			05/01/2011 8:38:03 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("FileAttachID",_fileAttachIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
