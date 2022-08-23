//
// Class	:	BO_ProviderPerson.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	09/21/2010 11:54:36 AM
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
    public class BO_ProviderPersonGridFields
    {
        public const string DateStarted = "DATE_STARTED";
        public const string PersonTypeDesc = "PERSON_TYPE_DESC";
        public const string FirstName = "FIRST_NAME";
        public const string LastName = "LAST_NAME";
    }

	
	/// <summary>
	/// Data access class for the "PROVIDER_PERSON" table.
	/// </summary>
	[Serializable]
	public class BO_ProviderPerson : BO_ProviderPersonBase
	{
	
		#region Class Level Variables

        private DateTime? _dateStarted = null;
        private string _personTypeDesc = null;
        private string _firstName = null;
        private string _lastName = null;
        private BO_Person _boPerson = null;
        private bool _IsNewRec = false;
        private bool _removed = false;
        private string _UI_TrackId = "";
        
        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_ProviderPerson() : base()
        {
        }

        #endregion

        #region Properties

        public DateTime? DateStarted
        {
            get { return _dateStarted; }
            set { _dateStarted = value; }
        }

        public string PersonTypeDesc
        {
            get { return _personTypeDesc; }
            set { _personTypeDesc = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

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

        #endregion

        #region Methods (Public)

        public void SetPrimaryFAC()
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
            if (PopsIntID != null)
                oDatabaseHelper.AddParameter("@PopsIntID", PopsIntID);
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value);
            //application id
            if (ApplicationID != null)
                oDatabaseHelper.AddParameter("@ApplicationID", ApplicationID);
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value);
            //person id
            if (PersonID != null)
                oDatabaseHelper.AddParameter("@PersonID", PersonID);
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value);
            // Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
      

            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("ATG_PROVIDER_PERSON_SET_PRIMARYFAC", ref ExecutionState);
            oDatabaseHelper.Dispose();
            //return ExecutionState;
        }

        public BO_Person InsertProviderPerson()
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
            if (PopsIntID != null)
                oDatabaseHelper.AddParameter("@PopsIntID", PopsIntID);
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value);
            // Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
            if (IsCurrent != null)
                oDatabaseHelper.AddParameter("@IsCurrent", IsCurrent);
            else
                oDatabaseHelper.AddParameter("@IsCurrent", DBNull.Value);
            // Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
            if (ApplicationID != null)
                oDatabaseHelper.AddParameter("@ApplicationID", ApplicationID);
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value);
            // Pass the value of '_personType' as parameter 'PersonType' of the stored procedure.
            if (PersonType != null)
                oDatabaseHelper.AddParameter("@PersonType", PersonType);
            else
                oDatabaseHelper.AddParameter("@PersonType", DBNull.Value);
            // Pass the value of '_effectiveDate' as parameter 'EffectiveDate' of the stored procedure.
            if (EffectiveDate != null)
                oDatabaseHelper.AddParameter("@EffectiveDate", EffectiveDate);
            else
                oDatabaseHelper.AddParameter("@EffectiveDate", DBNull.Value);
            // Pass the value of '_expirationDate' as parameter 'ExpirationDate' of the stored procedure.
            if (ExpirationDate != null)
                oDatabaseHelper.AddParameter("@ExpirationDate", ExpirationDate);
            else
                oDatabaseHelper.AddParameter("@ExpirationDate", DBNull.Value);
            // Pass the value of '_primaryFacAdmin' as parameter 'PrimaryFacAdmin' of the stored procedure.
            if (PrimaryFacAdmin != null)
                oDatabaseHelper.AddParameter("@PrimaryFacAdmin", PrimaryFacAdmin);
            else
                oDatabaseHelper.AddParameter("@PrimaryFacAdmin", DBNull.Value);

            // Pass the value of '_title' as parameter 'Title' of the stored procedure.
            if (BO_PersonDetail.Title != null)
                oDatabaseHelper.AddParameter("@Title", BO_PersonDetail.Title);
            else
                oDatabaseHelper.AddParameter("@Title", DBNull.Value);
            // Pass the value of '_addressID' as parameter 'AddressID' of the stored procedure.
            if (BO_PersonDetail.AddressID != null)
                oDatabaseHelper.AddParameter("@AddressID", BO_PersonDetail.AddressID);
            else
                oDatabaseHelper.AddParameter("@AddressID", DBNull.Value);
            // Pass the value of '_firstName' as parameter 'FirstName' of the stored procedure.
            if (BO_PersonDetail.FirstName != null)
                oDatabaseHelper.AddParameter("@FirstName", BO_PersonDetail.FirstName);
            else
                oDatabaseHelper.AddParameter("@FirstName", DBNull.Value);
            // Pass the value of '_middleInitial' as parameter 'MiddleInitial' of the stored procedure.
            if (BO_PersonDetail.MiddleInitial != null)
                oDatabaseHelper.AddParameter("@MiddleInitial", BO_PersonDetail.MiddleInitial);
            else
                oDatabaseHelper.AddParameter("@MiddleInitial", DBNull.Value);
            // Pass the value of '_lastName' as parameter 'LastName' of the stored procedure.
            if (BO_PersonDetail.LastName != null)
                oDatabaseHelper.AddParameter("@LastName", BO_PersonDetail.LastName);
            else
                oDatabaseHelper.AddParameter("@LastName", DBNull.Value);
            // Pass the value of '_phoneNumber' as parameter 'PhoneNumber' of the stored procedure.
            if (BO_PersonDetail.PhoneNumber != null)
                oDatabaseHelper.AddParameter("@PhoneNumber", BO_PersonDetail.PhoneNumber);
            else
                oDatabaseHelper.AddParameter("@PhoneNumber", DBNull.Value);
            // Pass the value of '_faxNumber' as parameter 'FaxNumber' of the stored procedure.
            if (BO_PersonDetail.FaxNumber != null)
                oDatabaseHelper.AddParameter("@FaxNumber", BO_PersonDetail.FaxNumber);
            else
                oDatabaseHelper.AddParameter("@FaxNumber", DBNull.Value);
            // Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
            if (BO_PersonDetail.EmailAddress!= null)
                oDatabaseHelper.AddParameter("@EmailAddress", BO_PersonDetail.EmailAddress);
            else
                oDatabaseHelper.AddParameter("@EmailAddress", DBNull.Value);
            // Pass the value of '_driversLicenseClassCode' as parameter 'DriversLicenseClassCode' of the stored procedure.
            if (BO_PersonDetail.DriversLicenseClassCode != null)
                oDatabaseHelper.AddParameter("@DriversLicenseClassCode", BO_PersonDetail.DriversLicenseClassCode);
            else
                oDatabaseHelper.AddParameter("@DriversLicenseClassCode", DBNull.Value);
            // Pass the value of '_driversLicenseNum' as parameter 'DriversLicenseNum' of the stored procedure.
            if (BO_PersonDetail.DriversLicenseNum != null)
                oDatabaseHelper.AddParameter("@DriversLicenseNum", BO_PersonDetail.DriversLicenseNum);
            else
                oDatabaseHelper.AddParameter("@DriversLicenseNum", DBNull.Value);
            // Pass the value of '_driversLicenseState' as parameter 'DriversLicenseState' of the stored procedure.
            if (BO_PersonDetail.DriversLicenseState != null)
                oDatabaseHelper.AddParameter("@DriversLicenseState", BO_PersonDetail.DriversLicenseState);
            else
                oDatabaseHelper.AddParameter("@DriversLicenseState", DBNull.Value);
            // Pass the value of '_currentResumeID' as parameter 'CurrentResumeID' of the stored procedure.
            if (BO_PersonDetail.CurrentResumeID != null)
                oDatabaseHelper.AddParameter("@CurrentResumeID", BO_PersonDetail.CurrentResumeID);
            else
                oDatabaseHelper.AddParameter("@CurrentResumeID", DBNull.Value);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.

            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDER_PERSON_PERSON_Insert", ref ExecutionState);
            while (dr.Read())
            {
                PopulatePersonPersonIDFromReader(dr);
            }
            dr.Close();
            oDatabaseHelper.Dispose();
            return this.BO_PersonDetail;

        }

        private void PopulatePersonPersonIDFromReader(IDataReader rdr)
        {
            this.BO_PersonDetail.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal("PERSON_ID")));
        }

        public bool DeleteProviderPerson()
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
            if (PopsIntID != null)
                oDatabaseHelper.AddParameter("@PopsIntID", PopsIntID);
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value);
            // Pass the value of '_isCurrent' as parameter 'IsCurrent' of the stored procedure.
            if (PersonID != null)
                oDatabaseHelper.AddParameter("@PersonID", PersonID);
            else
                oDatabaseHelper.AddParameter("@PersonID", DBNull.Value);
            // Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
            if (ApplicationID != null)
                oDatabaseHelper.AddParameter("@ApplicationID", ApplicationID);
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value);
            // Pass the value of '_personType' as parameter 'PersonType' of the stored procedure.

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("ATG_PROVIDER_PERSON_PERSON_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
            return ExecutionState;
        }

        public static BO_ProviderPeople SelectAllByForeignKeyPopsIntIDForGrid(BO_ProviderPrimaryKey pk)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_ProviderPeople obj = null;

            // Pass the values of all key parameters to the stored procedure.
            System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
            foreach (string key in nvc.Keys)
            {
                oDatabaseHelper.AddParameter("@" + key, nvc[key]);
            }

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDER_PERSON_SelectAllByForeignKeyPopsIntIDForGrid", ref ExecutionState);
            obj = new BO_ProviderPeople();
            obj = BO_ProviderPerson.PopulateObjectsFromReaderWithCheckingReaderForGrid(dr, oDatabaseHelper);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;

        }

        public static BO_ProviderPeople SelectByApplicationPersonTypeForGrid(BO_ProviderPrimaryKey pk, BO_ApplicationPrimaryKey ak, string PersonType)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_ProviderPeople obj = null;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@PopsIntID", pk.PopsIntID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ApplicationID", ak.ApplicationID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@PersonType", PersonType, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDER_PERSON_SelectByApplicationPersonType", ref ExecutionState);
            obj = new BO_ProviderPeople();
            obj = BO_ProviderPerson.PopulateObjectsFromReaderWithAllChildrenApplicationID(dr, ak);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        //used for key personnel grid
        public static BO_ProviderPeople SelectPersonnelForGrid(BO_ProviderPrimaryKey pk, BO_ApplicationPrimaryKey ak)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
            BO_ProviderPeople obj = null;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@PopsIntID", pk.PopsIntID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ApplicationID", ak.ApplicationID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_PROVIDER_PERSON_SelectPersonnelForGrid", ref ExecutionState);
            obj = new BO_ProviderPeople();
            obj = BO_ProviderPerson.PopulateObjectsFromReaderForPersonnelGrid(dr, ak);

            dr.Close();
            oDatabaseHelper.Dispose();
            return obj;
        }

        public static BO_ProviderPeople PopulateObjectsFromReaderForPersonnelGrid(IDataReader rdr, BO_ApplicationPrimaryKey pk)
        {
            BO_ProviderPeople tmpProvPeople = new BO_ProviderPeople();

            while (rdr.Read())
            {
                BO_ProviderPerson obj = new BO_ProviderPerson();
                PopulateObjectFromReaderWithChildrenForPersonnelGrid(obj, rdr);
                tmpProvPeople.Add(obj);
            }

            return tmpProvPeople;
        }

        //used for key personnel grid
        internal static void PopulateObjectFromReaderWithChildrenForPersonnelGrid(BO_ProviderPerson obj, IDataReader rdr)
        {
            //Load base class fields
            PopulateObjectFromReaderForPersonnelGrid(obj, rdr);
            //Fill Person Details
            obj.BO_PersonDetail = BO_Person.SelectOneWithAllChildrenUsingPersonID(new BO_PersonPrimaryKey(obj.PersonID));
        }

        //used for key personnel grid
        internal static void PopulateObjectFromReaderForPersonnelGrid(BO_ProviderPerson obj, IDataReader rdr)
        {

            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PopsIntID)));
            obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PersonID)));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.IsCurrent)))
            {
                obj.IsCurrent = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderPersonFields.IsCurrent));
            }

            obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.ApplicationID)));
            obj.PersonType = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonFields.PersonType));
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate)))
            {
                obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate)))
            {
                obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.PrimaryFacAdmin)))
            {
                obj.PrimaryFacAdmin = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonFields.PrimaryFacAdmin));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonGridFields.PersonTypeDesc)))
            {
                obj.PersonTypeDesc = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonGridFields.PersonTypeDesc));
            }
        }

        public static BO_ProviderPeople PopulateObjectsFromReaderWithAllChildrenApplicationID( IDataReader rdr, BO_ApplicationPrimaryKey pk )
        {
            BO_ProviderPeople tmpProvPeople = new BO_ProviderPeople();

            while ( rdr.Read() )
            {
                BO_ProviderPerson obj = new BO_ProviderPerson();
                PopulateObjectFromReaderWithChildren( obj, rdr );
                tmpProvPeople.Add( obj );
            }

            return tmpProvPeople;
        }
        
        #endregion
		
		#region Methods (Private)

        //used for key personnel grid
        internal static BO_ProviderPeople PopulateObjectsFromReaderWithCheckingReaderForGrid(IDataReader rdr, DatabaseHelper oDatabaseHelper)
        {
            BO_ProviderPeople list = new BO_ProviderPeople();

            if (rdr.Read())
            {
                BO_ProviderPerson obj = new BO_ProviderPerson();
                PopulateObjectFromReaderForGrid(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_ProviderPerson();
                    PopulateObjectFromReaderForGrid(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
        }

        //used for key personnel grid
        internal static void PopulateObjectFromReaderForGrid(BO_ProviderPerson obj, IDataReader rdr)
        {
            obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PopsIntID)));
            obj.PersonID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderPersonFields.PersonID)));

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate)))
            {
                obj.EffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.EffectiveDate));
            }

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate)))
            {
                obj.ExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonFields.ExpirationDate));
            }

            // custom columns
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonGridFields.DateStarted)))
            {
                obj.DateStarted = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderPersonGridFields.DateStarted));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonGridFields.PersonTypeDesc)))
            {
                obj.PersonTypeDesc = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonGridFields.PersonTypeDesc));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonGridFields.FirstName)))
            {
                obj.FirstName = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonGridFields.FirstName));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderPersonGridFields.LastName)))
            {
                obj.LastName = rdr.GetString(rdr.GetOrdinal(BO_ProviderPersonGridFields.LastName));
            }

        }

        internal static void PopulateObjectFromReaderWithChildren( BO_ProviderPerson obj, IDataReader rdr )
        {
            //Load base class fields
            PopulateObjectFromReader( obj, rdr );
            //Fill Person Details
            obj.BO_PersonDetail = BO_Person.SelectOneWithAllChildrenUsingPersonID( new BO_PersonPrimaryKey( obj.PersonID ) );
        }

        #endregion
        
        public void DeleteCascadeChildren()
        {
            if ( null != this.BO_PersonDetail.AddressID )
                BO_Address.DeleteByField( BO_AddressFields.AddressID, this.BO_PersonDetail.AddressID );

            //The person record may represent multiple types of entities and exclusivly unique to
            //to them so there are no dependencies accors preson types. Go through all collections
            //and remove records.

            //Remove Education Records
            if ( null != this.BO_PersonDetail.BO_EducationsPersonID )
            {
                int RecCnt = this.BO_PersonDetail.BO_EducationsPersonID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_PersonDetail.BO_EducationsPersonID[delCnt].Delete();
                }
            }

            //Remove Employment Records
            if ( null != this.BO_PersonDetail.BO_EmploymentsPersonID )
            {
                int RecCnt = this.BO_PersonDetail.BO_EmploymentsPersonID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_PersonDetail.BO_EmploymentsPersonID[delCnt].Delete();
                }
            }

            //Remove Owner Person Records
            if ( null != this.BO_PersonDetail.BO_OwnerPeoplePersonID )
            {
                int RecCnt = this.BO_PersonDetail.BO_OwnerPeoplePersonID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_PersonDetail.BO_OwnerPeoplePersonID[delCnt].Delete();
                }
            }

            //Remove Provider Person Records
            if ( null != this.BO_PersonDetail.BO_ProviderPeoplePersonID )
            {
                int RecCnt = this.BO_PersonDetail.BO_ProviderPeoplePersonID.Count;

                for ( int delCnt = 0; delCnt < RecCnt; delCnt++ )
                {
                    this.BO_PersonDetail.BO_ProviderPeoplePersonID[delCnt].Delete();
                }
            }

            Delete();
        }
    }
	
}
