//
// Class	:	BO_LettersQueue.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/03/2012 1:51:11 PM
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
	/// Data access class for the "LETTERS_QUEUE" table.
	/// </summary>
	[Serializable]
	public class BO_LettersQueue : BO_LettersQueueBase
	{
	
		#region Class Level Variables

        private BO_Letters _boLetters;

        #endregion
		
		#region Constants
		
		#endregion

        #region Constructors / Destructors 
        
        public BO_LettersQueue() : base()
        {
        }

        public BO_LettersQueue(string UserAuthID): base()
        {
            this.UserAuthID = UserAuthID;
        }

        public BO_LettersQueue(string UserAuthID, decimal LetterID, decimal ApplicationID, bool PrintLabels): base()
        {
            this.UserAuthID = UserAuthID;
            this.LetterID = LetterID;
            this.ApplicationID = ApplicationID;
            this.PrintLabels = PrintLabels;
        }

        #endregion

        #region Properties

        public BO_Letters Letters
        {
            get
            {
               
                _boLetters = new BO_Letters();
                _boLetters = BO_Letter.SelectUserQueue(UserAuthID);
                return _boLetters;
            }
            set
            {
                _boLetters = value;
            }
        }

        #endregion

        #region Methods (Public)

        public static void DeleteAllByKeyFields(string UserAuthID, decimal ApplicationID, decimal LetterID)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@UserAuthID", UserAuthID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@ApplicationID", ApplicationID, System.Data.ParameterDirection.Input);
            oDatabaseHelper.AddParameter("@LetterID", LetterID, System.Data.ParameterDirection.Input);
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("ATG_LETTERS_QUEUE_DeleteAllByKeyFields", ref ExecutionState);
            oDatabaseHelper.Dispose();
        }

        public static void UpdatePrintLabels(string UserAuthID, bool PrintLabels)
        {
            bool ExecutionState = false;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            // Pass the value of '_userAuthID' as parameter 'UserAuthID' of the stored procedure.
            oDatabaseHelper.AddParameter("@UserAuthID", UserAuthID);

            // Pass the value of '_printLabels' as parameter 'PrintLabels' of the stored procedure.
            oDatabaseHelper.AddParameter("@PrintLabels", PrintLabels);

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.ExecuteScalar("ATG_LETTERS_QUEUE_UpdatePrintLabels", ref ExecutionState);
            oDatabaseHelper.Dispose();
        }

        #endregion
		
		#region Methods (Private)

        #endregion
	
    }
}