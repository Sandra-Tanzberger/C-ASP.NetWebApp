using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
using ATG.BusinessObject;
using System.Collections.Generic;

namespace ATG
{
    public static class CommonFunc
    {
        public static Control FindControlRecursive( this Control ctrl, string controlID )
        {
            if ( string.Compare( ctrl.ID, controlID, true ) == 0 )
            {
                // We found the control!
                return ctrl;
            }
            else
            {
                // Recurse through ctrl's Controls collections
                foreach ( Control child in ctrl.Controls )
                {
                    Control lookFor = FindControlRecursive( child, controlID );

                    if ( lookFor != null )
                        return lookFor;     // We found the control
                }

                // If we reach here, control was not found
                return null;
            }
        }

        public static String FixQuoteSQL(String str)
        {
            return str.Replace("'", "''");
        }

        //Convert String to ProperCase
        public static String Proper_String(String strParam)
        {
			// 6/14/2007 - rjc - check for 0-length strings
			if ((strParam == null)
				|| (strParam.Length == 0)
			) {
				return strParam;
			}

            String strProper = strParam.Substring(0, 1).ToUpper();
            strParam = strParam.Substring(1).ToLower();
            String strPrev = "";

            for (int iIndex = 0; iIndex < strParam.Length; iIndex++)
            {
                if (iIndex > 1)
                    strPrev = strParam.Substring(iIndex - 1, 1);
                
                if (strPrev.Equals(" ") ||
                    strPrev.Equals("\t") ||
                    strPrev.Equals("\n") ||
                    strPrev.Equals("-") ||
                    strPrev.Equals(".") )
                {
                    strProper += strParam.Substring(iIndex, 1).ToUpper();
                }
                else
                {
                    strProper += strParam.Substring(iIndex, 1);
                }
            }
            return strProper;
        }

        public static string Proper_string(string s)
        {
			// 6/14/2007 - rjc - check for 0-length strings
			if ((s == null)
				|| (s.Length == 0)
			) {
				return s;
			}

            s = s.ToLower();
            string sProper = "";

            char[] seps = new char[] { ' ' };
            foreach (string ss in s.Split(seps))
            {
                sProper += char.ToUpper(ss[0]);
                sProper +=
                (ss.Substring(1, ss.Length - 1) + ' ');
            }
            return sProper;
        }

        /// <summary>
        /// Converts string to Title case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertToTitleCase(string input)
        {
            if ( input != null )
            {
                TextInfo ti = Thread.CurrentThread.CurrentCulture.TextInfo;
                //if a word is all in upper case, ToTitleCase method is not able to convert to title case. So we would make the input string all lower case.
                return ti.ToTitleCase( input.ToLower() );
            }
            else
                return input;
        }

        public static bool IsNumber( string evalStr )
        {
            string tmpTestVal = "";
            double tmpNumVar;
            bool isNum = false;

            tmpTestVal = evalStr == null ? "" : evalStr ;
            
            isNum = double.TryParse( tmpTestVal, out tmpNumVar );

            return isNum;

        }

        public static DataTable getStates()
        {
            DataTable retTbl = (DataTable) HttpContext.Current.Application["STATES_LIST"];
            retTbl.DefaultView.Sort = "StateName ASC";
            
            return retTbl;
        }

        public static DataTable getCitiesByState( string inStateCode )
        {
            DataTable retTbl = new DataTable();
            DataTable tmpTbl = (DataTable) HttpContext.Current.Application["CITY_COUNTY_ZIP_LIST"];

            retTbl = tmpTbl.Clone();
            retTbl.Clear();

            DataRow[] tmpRows = tmpTbl.Select( "StateCode = '" + inStateCode + "'");

            foreach ( DataRow tmpRw in tmpRows )
            {
                retTbl.ImportRow( tmpRw );
            }

            retTbl.DefaultView.Sort = "City ASC";

            return retTbl.DefaultView.ToTable( true, "City" );

        }

        public static DataTable getZipByCityState( string inCity, string inStateCode )
        {
            DataTable retTbl = new DataTable();
            DataTable tmpTbl = (DataTable) HttpContext.Current.Application["CITY_COUNTY_ZIP_LIST"];

            retTbl = tmpTbl.Clone();
            retTbl.Clear();

            DataRow[] tmpRows = tmpTbl.Select( "StateCode = '" + inStateCode + "' and City = '" + inCity + "'" );

            foreach ( DataRow tmpRw in tmpRows )
            {
                retTbl.ImportRow( tmpRw );
            }

            retTbl.DefaultView.Sort = "Zip ASC";
            
            return retTbl.DefaultView.ToTable( true, "Zip" );

        }

        public static DataTable getCountiesByZip( string inZipCode )
        {
            DataTable retTbl = new DataTable();
            DataTable tmpTbl = (DataTable) HttpContext.Current.Application["CITY_COUNTY_ZIP_LIST"];

            retTbl = tmpTbl.Clone();
            retTbl.Clear();

            DataRow[] tmpRows = tmpTbl.Select( "ZIP = '" + inZipCode + "'" );

            foreach ( DataRow tmpRw in tmpRows )
            {
                retTbl.ImportRow( tmpRw );
            }

            retTbl.DefaultView.Sort = "Cntyname ASC";

            return retTbl.DefaultView.ToTable( true, "Cntyname" );

        }

        public static DataTable getCitiesByZip( string inZipCode )
        {
            DataTable retTbl = new DataTable();
            DataTable tmpTbl = (DataTable) HttpContext.Current.Application["CITY_COUNTY_ZIP_LIST"];

            retTbl = tmpTbl.Clone();
            retTbl.Clear();

            DataRow[] tmpRows = tmpTbl.Select( "ZIP = '" + inZipCode + "'" );

            foreach ( DataRow tmpRw in tmpRows )
            {
                retTbl.ImportRow( tmpRw );
            }

            retTbl.DefaultView.Sort = "City ASC";

            return retTbl.DefaultView.ToTable( true, "City" );

        }

        public static DataTable getStatesByZip( string inZipCode )
        {
            DataTable retTbl = new DataTable();
            DataTable tmpTbl = (DataTable) HttpContext.Current.Application["CITY_COUNTY_ZIP_LIST"];
            string[] distCol = { "StateCode", "StateName" };

            retTbl = tmpTbl.Clone();
            retTbl.Clear();

            DataRow[] tmpRows = tmpTbl.Select( "ZIP = '" + inZipCode + "'" );

            foreach ( DataRow tmpRw in tmpRows )
            {
               retTbl.ImportRow( tmpRw );
            }

            retTbl.DefaultView.Sort = "StateCode ASC";

            return retTbl.DefaultView.ToTable( true, distCol );

        }

        /**
         * Get the user name of the currently logged in user
        **/
        public static String getUserName() {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
                String userName = System.Web.HttpContext.Current.User.Identity.Name;
                // strip domain
                if (userName.Contains("\\")) {
                    userName = userName.Substring(userName.LastIndexOf('\\') + 1);
                }
                return userName;
            }
            return "";
        }

        public static BO_LookupValues SortLookupValues(BO_LookupValues collection)
        {
            SortedList<string, string> keyValuePair = new SortedList<string,string>();
            BO_LookupValues sortedCollection = new BO_LookupValues();
            foreach(BO_LookupValue item in collection)
                keyValuePair.Add(item.Valdesc, item.LookupVal);

            foreach (KeyValuePair<string, string> kvp in keyValuePair)
                sortedCollection.Add(collection[collection.IndexOf(GetItemByVal(collection,kvp.Key))]);

            return sortedCollection;
        }

        private static BO_LookupValue GetItemByVal(BO_LookupValues collection, string val)
        {
            BO_LookupValue itemSelected = null;
            foreach (BO_LookupValue item in collection)
            {
                if (item.Valdesc == val)
                {
                    itemSelected = item;
                    break;
                }
            }
            return itemSelected;
        }
    }        
}

