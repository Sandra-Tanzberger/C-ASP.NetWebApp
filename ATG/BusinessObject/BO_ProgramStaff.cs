//
// Class	:	BO_ProgramStaff.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	10/06/2010 4:46:09 PM
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
	/// Data access class for the "PROGRAM_STAFF" table.
	/// </summary>
	[Serializable]
	public class BO_ProgramStaff : BO_ProgramStaffBase
	{
	
		#region Class Level Variables

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_ProgramStaff() : base()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods (Public)

        //used for program staff grid
        public static BO_ProgramStaffs SelectProgramStaffForGrid()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_ProgramStaffs obj = null;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROGRAM_STAFF_SelectProgramStaffForGrid", ref ExecutionState);
            obj = new BO_ProgramStaffs();
            obj = BO_ProgramStaff.PopulateObjectsFromReaderForGrid(dr);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        internal static BO_ProgramStaffs PopulateObjectsFromReaderForGrid(IDataReader rdr)
        {

            BO_ProgramStaffs list = new BO_ProgramStaffs();

            while (rdr.Read())
            {
                BO_ProgramStaff obj = new BO_ProgramStaff();
                PopulateObjectFromReaderForGrid(obj, rdr);
                list.Add(obj);
            }
            return list;

        }

        internal static void PopulateObjectFromReaderForGrid(BO_ProgramStaffBase obj, IDataReader rdr)
        {
            obj.ProgramStaffID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProgramStaffFields.ProgramStaffID)));
            obj.FirstName = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.FirstName));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.LastName)))
            {
                obj.LastName = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.LastName));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProgramStaffFields.LoginID)))
            {
                obj.LoginID = rdr.GetString(rdr.GetOrdinal(BO_ProgramStaffFields.LoginID));
            }
        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
