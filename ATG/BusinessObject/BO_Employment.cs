//
// Class	:	BO_Employment.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/13/2010 9:44:38 AM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;

namespace ATG.BusinessObject
{
	
	/// <summary>
	/// Data access class for the "EMPLOYMENT" table.
	/// </summary>
	[Serializable]
	public class BO_Employment : BO_EmploymentBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _UI_TrackId = "";

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Employment() : base()
        {
        }

        #endregion

        #region Properties
        public bool IsNewRec
        {
            get
            {
                return _IsNewRec;
            }
            set
            {
                _IsNewRec = value;
            }
        }

        public bool Removed
        {
            get
            {
                return _Removed;
            }
            set
            {
                _Removed = value;
            }
        }

        public string UI_TrackID
        {
            get
            {
                if ( IsNewRec )
                {
                    return _UI_TrackId;
                }
                else
                {
                    return EmploymentID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        #endregion

        #region Methods (Public)

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
