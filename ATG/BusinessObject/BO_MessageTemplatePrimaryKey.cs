//
// Class	:	BO_MessageTemplatePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:23 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_MessageTemplatePrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_templateIDNonDefault    	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_MessageTemplatePrimaryKey(decimal? templateID) 
		{
	
			
            this._templateIDNonDefault = templateID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "TEMPLATE_ID" field.  Mandatory.
		/// </summary>
		public decimal? TemplateID
		{
			get 
			{ 
                return _templateIDNonDefault;
			}
			set 
			{
            
                _templateIDNonDefault = value; 
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
		/// DLGenerator			05/24/2011 11:58:23 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("TemplateID",_templateIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
