//
// Class	:	UserGroup.cs
// Author	:  	ST 
// Date		:	03-05-2013
// Description : A user group provides a role based type or permissions granting access to application funtionality

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;

namespace ATG.Security
{
    public class UserGroup
    {
        private string groupName = "";

        public UserGroup(string groupName)
        {
            this.groupName = groupName;
        }

        //group name is currently a 3 char uppercase string: as "SUR"
        public string GroupName
        {
            get { return groupName; }
        }

    }
}