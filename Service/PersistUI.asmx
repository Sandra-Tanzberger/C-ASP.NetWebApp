<%@ WebService Language="C#" Class="Service.PersistUI" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace Service
{
    /// <summary>
    /// Summary description for PersistUI
    /// </summary>
    [WebService( Namespace = "http://tempuri.org/" )]
    [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
    [System.ComponentModel.ToolboxItem( false )]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class PersistUI : System.Web.Services.WebService
    {

        [WebMethod(EnableSession=true)]
        public void SetSplitterHeight( int inNewHeight )
        {
            Session["ContentHeight"] = inNewHeight;
        }
    }
}