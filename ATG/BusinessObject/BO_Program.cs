//
// Class	:	BO_Program.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	04/03/2010 3:52:06 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using ATG.Database;

namespace ATG.BusinessObject
{
	
	/// <summary>
	/// Data access class for the "PROGRAMS" table.
	/// </summary>
	[Serializable]
	public class BO_Program : BO_ProgramBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Program() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        public static BO_Programs SelectAllSortByDescription()
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROGRAMS_SelectAllSortByDescription", ref ExecutionState);
            BO_Programs BO_Programs = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Programs;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
