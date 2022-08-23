//
// Class	:	BO_AuditLogPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:30 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_AuditLogPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_auditIDNonDefault       	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_AuditLogPrimaryKey(decimal? auditID) 
		{
	
			
            this._auditIDNonDefault = auditID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "AUDIT_ID" field.  Mandatory.
		/// </summary>
		public decimal? AuditID
		{
			get 
			{ 
                return _auditIDNonDefault;
			}
			set 
			{
            
                _auditIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:30 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("AuditID",_auditIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
