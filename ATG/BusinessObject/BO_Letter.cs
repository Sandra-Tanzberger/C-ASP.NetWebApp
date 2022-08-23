//
// Class	:	BO_Letter.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/03/2012 1:51:10 PM
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
	/// Data access class for the "LETTERS" table.
	/// </summary>
	[Serializable]
	public class BO_Letter : BO_LetterBase
	{
        public class BO_LetterQueueFields
        {
            public const string QueueID = "QUEUE_ID";
            public const string ApplicatinID = "APPLICATION_ID";
            public const string PrintLabels = "PRINT_LABELS";
            public const string FacilityName = "FACILITY_NAME";
            public const string State_ID = "STATE_ID";
        }
	
		#region Class Level Variables

        private BO_LettersParameters _boParamters;

        private decimal? _queueID = null;
        private decimal? _applicationID = null;
        private bool? _printLables = null;
        private string _facilityName = null;
        private string _stateID = null;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_Letter() : base()
        {

        }

        #endregion

        #region Properties

        public decimal? QueueID
        {
            get { return _queueID; }
            set { _queueID = value; }
        }
        public decimal? ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }
        public bool? PrintLabels
        {
            get { return _printLables; }
            set { _printLables = value; }
        }
        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }
        public string StateID
        {
            get { return _stateID; }
            set { _stateID = value; }
        }

        public BO_LettersParameters Parameters
        {
            set { _boParamters = value; }
            get
            {
                if (_boParamters == null)
                {
                    _boParamters = new BO_LettersParameters();
                    _boParamters = BO_LettersParameter.SelectByField("LETTER_ID", LetterID);
                }
                
                return _boParamters; 
            }
        }

        #endregion

        #region Methods (Public)

        public static ArrayList SelectLetterTypes(string ProgramID)
        {
            ArrayList letterTypes = new ArrayList();
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_LETTERS_SelectLetterTypes", ref ExecutionState);
            while (dr.Read())
            {
                if(dr.GetString(dr.GetOrdinal(BO_LetterFields.Programs)).Contains(ProgramID))
                    letterTypes.Add(dr.GetString(dr.GetOrdinal(BO_LetterFields.LetterType)));
            }
            dr.Close();

            return letterTypes;
        }
        
        public static BO_Letters SelectUserQueue(string UserAuthID)
        {
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@UserAuthID", UserAuthID, System.Data.ParameterDirection.Input);
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("ATG_LETTERS_QUEUE_SelectAllByUser", ref ExecutionState);
			BO_Letters letters = PopulateObjectsFromReaderByUser(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return letters;
        }

        public static BO_Letters SelectLettersforSearchGrid(string ProgramID, string LetterType, string AnniverysaryMonth)
        {
            BO_Letters letters = new BO_Letters();
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            IDataReader dr = null;
            oDatabaseHelper.ClearParameters();//make sure old paramaters are not being passed
            bool ExecutionState = false;

            //get letter templates from letter table by letter type
            BO_Letters tmpLetters = BO_Letter.SelectByProgram(ProgramID, LetterType);

            //get applications id list for incomplete license renewal applications else get applications by provider to get most currently approved application
            if (LetterType.ToLower().Contains("renewal"))
            {
                oDatabaseHelper.AddParameter("@ProgramID", ProgramID, System.Data.ParameterDirection.Input);
                oDatabaseHelper.AddParameter("@AnniversaryMonth", AnniverysaryMonth, System.Data.ParameterDirection.Input);
                oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                dr = oDatabaseHelper.ExecuteReader("ATG_LETTERS_SelectApplicationIDByApplication", ref ExecutionState);
                letters = PopulateObjectsFromReaderByLetter(dr, tmpLetters);

            }
            else
            {
                oDatabaseHelper.AddParameter("@ProgramID", ProgramID, System.Data.ParameterDirection.Input);
                oDatabaseHelper.AddParameter("@AnniversaryMonth", AnniverysaryMonth, System.Data.ParameterDirection.Input);
                oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

                dr = oDatabaseHelper.ExecuteReader("ATG_LETTERS_SelectApplicationIDByProvider", ref ExecutionState);
                letters = PopulateObjectsFromReaderByLetter(dr, tmpLetters);
            }

            dr.Close();
            oDatabaseHelper.Dispose();

            return letters;
        }

        public static BO_Letters SelectByProgram(string programID, string letterType)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@ProgramID", programID);
            oDatabaseHelper.AddParameter("@LetterType", letterType);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_LETTERS_SelectByProgram", ref ExecutionState);
            BO_Letters BO_Letters = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Letters;

        }


        #endregion
		
		#region Methods (Private)

        private static BO_Letters PopulateObjectsFromReaderByUser(IDataReader rdr)
        {

            BO_Letters list = new BO_Letters();

            while (rdr.Read())
            {
                BO_Letter obj = new BO_Letter();
                PopulateObjectFromReaderByUser(obj, rdr);
                list.Add(obj);
            }
            return list;

        }

        private static void PopulateObjectFromReaderByUser(BO_Letter obj, IDataReader rdr)
        {
            obj.LetterID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_LetterFields.LetterID)));
            obj.LetterType = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.LetterType));
            obj.LetterDisplayName = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.LetterDisplayName));
            obj.ReportName = rdr.GetString(rdr.GetOrdinal(BO_LetterFields.ReportName));
            obj.QueueID = rdr.GetDecimal(rdr.GetOrdinal(BO_LetterQueueFields.QueueID));
            obj.ApplicationID = rdr.GetDecimal(rdr.GetOrdinal(BO_LetterQueueFields.ApplicatinID));
            obj.PrintLabels = rdr.GetBoolean(rdr.GetOrdinal(BO_LetterQueueFields.PrintLabels));
            obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_LetterQueueFields.FacilityName));
        }

        private static BO_Letters PopulateObjectsFromReaderByLetter(IDataReader rdr, BO_Letters tmpLetters)
        {

            BO_Letters list = new BO_Letters();

            while (rdr.Read())
            {
                foreach (BO_Letter letter in tmpLetters)
                {
                    BO_Letter obj = new BO_Letter();
                    PopulateObjectFromReaderByLetter(obj, rdr, letter);
                    list.Add(obj);
                }
            }
            return list;

        }

        private static void PopulateObjectFromReaderByLetter(BO_Letter obj, IDataReader rdr, BO_Letter tmpLetter)
        {
            obj.LetterID = tmpLetter.LetterID;
            obj.LetterType = tmpLetter.LetterType;
            obj.LetterDisplayName = tmpLetter.LetterDisplayName;
            obj.Programs = tmpLetter.Programs;
            obj.ReportName = tmpLetter.ReportName;
            obj.ApplicationID = rdr.GetDecimal(rdr.GetOrdinal(BO_LetterQueueFields.ApplicatinID));
            obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_LetterQueueFields.FacilityName));
            obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_LetterQueueFields.State_ID));
        }

        #endregion

	}
	
}
