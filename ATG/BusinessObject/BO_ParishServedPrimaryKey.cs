//
// Class	:	BO_ParishServedPrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	05/24/2011 11:58:22 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_ParishServedPrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_parishServedIDNonDefault	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_ParishServedPrimaryKey(decimal? parishServedID,decimal? popsIntID) 
		{
	
			
            this._parishServedIDNonDefault = parishServedID;
			
            this._popsIntIDNonDefault = popsIntID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "PARISH_SERVED_ID" field.  Mandatory.
		/// </summary>
		public decimal? ParishServedID
		{
			get 
			{ 
                return _parishServedIDNonDefault;
			}
			set 
			{
            
                _parishServedIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
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
			
			nvc.Add("ParishServedID",_parishServedIDNonDefault.ToString());
			nvc.Add("PopsIntID",_popsIntIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
