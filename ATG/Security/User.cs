//
// Class	:	User.cs
// Author	:  	ST 
// Date		:	03-05-2013
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Data.Common;
using System.Linq;
using ATG.Database;

namespace ATG.Security
{
    internal class User
    {
        #region Class Level Variables

        private UserGroups userGroups = new UserGroups();//usergroups is created automatically so the collection will never be null when used even if no 
        //groups are set for this user,
        //makes it possible to use foreach without checking for null values
        private string userName = "";//for windows authentication userName = window login id

        #endregion

        #region Constructors/Destructors

        public User(string userName)
        {
            this.userName = userName;
            LoadUserGroups();
        }

        #endregion

        #region Properties

        public UserGroups UserGroups
        {
            get { return userGroups; }
        }

        #endregion

        #region Public Methods

        public bool HasAccess(string groupName)
        {
            return userGroups.Any(group => group.GroupName == groupName);
        }

        public bool IsReadOnly()
        {
            return userGroups.Any(group => group.GroupName == "SUR");
        }

        public bool IsReadOnly(string groupName)
        {
            return userGroups.Any(group => group.GroupName == groupName);
        }
    
        #endregion

        #region Private Methods

        private void LoadUserGroups()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            oDatabaseHelper.AddParameter("@UserID", userName.ToUpper(), ParameterDirection.Input);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_USER_SELECT_GROUPS", ref ExecutionState);

            while (dr.Read())
            {
                this.userGroups.Add(new UserGroup(dr.GetString(dr.GetOrdinal("GRPID"))));
            }
            dr.Close();
            oDatabaseHelper.Dispose();
        }

        #endregion 

    }
}