//
// Class	:	BO_OwnerPerson.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 2:43:43 PM
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
	/// Data access class for the "OWNER_PERSON" table.
	/// </summary>
	[Serializable]
	public class BO_OwnerPerson : BO_OwnerPersonBase
	{
	
		#region Class Level Variables

        private BO_Person _boPerson = null;
        private bool _IsNewRec = false;
        private bool _removed = false;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_OwnerPerson() : base()
        {
        }

        #endregion

        #region Properties
        public BO_Person BO_PersonDetail
        {
            get
            {
                return _boPerson;
            }
            set
            {
                _boPerson = value;
            }
        }

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
                return _removed;
            }
            set
            {
                _removed = value;
            }
        }

        #endregion

        #region Methods (Public)
        public static BO_OwnerPeople PopulateObjectsFromReaderWithAllChildrenApplicationID( IDataReader rdr )
        {
            BO_OwnerPeople tmpOwnPeople = new BO_OwnerPeople();

            while ( rdr.Read() )
            {
                BO_OwnerPerson obj = new BO_OwnerPerson();
                PopulateObjectFromReaderWithChildren( obj, rdr );
                tmpOwnPeople.Add( obj );
            }

            return tmpOwnPeople;
        }
        #endregion
		
		#region Methods (Private)
        internal static void PopulateObjectFromReaderWithChildren( BO_OwnerPerson obj, IDataReader rdr )
        {
            //Load base class fields
            PopulateObjectFromReader( obj, rdr );
            //Fill Person Details
            obj.BO_PersonDetail = BO_Person.SelectOneWithAllChildrenUsingPersonID( new BO_PersonPrimaryKey( obj.PersonID ) );
        }
        #endregion

	}
	
}
