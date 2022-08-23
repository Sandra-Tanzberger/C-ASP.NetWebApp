//
// Class	:	BO_Person.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 12:38:20 PM
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
	/// Data access class for the "PERSON" table.
	/// </summary>
	[Serializable]
	public class BO_Person : BO_PersonBase
	{
	
		#region Class Level Variables
        private bool _IsNewRec = false;
        private bool _Removed = false;
        private string _PersonType = "";
        private string _UI_TrackId = "";
        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Person() : base()
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
                    return PersonID.ToString();
                }
            }
            set
            {
                _UI_TrackId = value;
            }
        }

        public string PersonType
        {
            get
            {
                return _PersonType;
            }
            set
            {
                _PersonType = value;
            }
        }

        #endregion

        #region Methods (Public)
        /// <summary>
        /// This method will get row(s) from the database using the value of the field specified 
        /// along with the details of the child tables.
        /// </summary>
        ///
        /// <param name="pk" type="PERSONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
        ///
        /// <returns>object of class PERSON</returns>
        ///
        /// <remarks>
        ///
        /// <RevisionHistory>
        /// Author				Date			Description
        /// Shawn Martin		12/15/2010      Created function
        /// 
        /// </RevisionHistory>
        ///
        /// </remarks>
        ///
        public static BO_Person SelectOneWithAllChildrenUsingPersonID( BO_PersonPrimaryKey pk )
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_Person obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach ( string key in nvc.Keys )
            {
                oDatabaseHelper.AddParameter( "@" + key, nvc[key] );
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter( "@ErrorCode", -1, System.Data.ParameterDirection.Output );

            IDataReader dr = oDatabaseHelper.ExecuteReader( "ATG_PERSON_SelectOneAllChildrenUsingPersonID", ref ExecutionState );
            if ( dr.Read() )
            {
                obj = new BO_Person();
                PopulateObjectFromReader( obj, dr );

                dr.NextResult();

                //Get the Employment child records.
                obj.BO_EmploymentsPersonID = BO_Employment.PopulateObjectsFromReader( dr );

                dr.NextResult();

                //Get the Education child records.
                obj.BO_EducationsPersonID = BO_Education.PopulateObjectsFromReader( dr );
            }
            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        #endregion
		
		#region Methods (Private)

        #endregion

	}
	
}
