//
// Class	:	BO_LettersQueuePrimaryKey.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/03/2012 1:51:11 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ATG.BusinessObject
{
    public class BO_LettersQueuePrimaryKey
    {

        #region Class Level Variables
		private decimal?       	_queueIDNonDefault       	= null;
        #endregion

        #region Constants

        #endregion

        #region Constructors / Destructors

		/// <summary>
        /// Constructor setting values for all fields
        /// </summary>
		public BO_LettersQueuePrimaryKey(decimal? queueID) 
		{
	
			
            this._queueIDNonDefault = queueID;

		}

		#endregion

        #region Properties

		/// <summary>
		/// This property is mapped to the "QUEUE_ID" field.  Mandatory.
		/// </summary>
		public decimal? QueueID
		{
			get 
			{ 
                return _queueIDNonDefault;
			}
			set 
			{
            
                _queueIDNonDefault = value; 
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
		/// DLGenerator			08/03/2012 1:51:11 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public NameValueCollection GetKeysAndValues() 
		{

			NameValueCollection nvc=new NameValueCollection();
			
			nvc.Add("QueueID",_queueIDNonDefault.ToString());
			return nvc;
			
		}

		#endregion	
		
        #region Methods (Private)

        #endregion

    }
}
    
