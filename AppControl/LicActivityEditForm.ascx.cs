using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class LicActivityEditForm : System.Web.UI.UserControl
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            listAppType.DataSource = CurrentBusinessProcessList;
            listAppType.DataTextField = "BusinessProcessName";
            listAppType.DataValueField = "BusinessProcessID";
            listAppType.Height = Unit.Pixel( 100 );
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return (BO_Provider) Session["CurrentProvider"];
            }
        }

        private DataTable CurrentBusinessProcessList
        {
            get
            {
                DataTable tmpDTbl = new DataTable();

                //if ( CurrentBusinessProcessList == null )
                //{
                    BO_BusinessProcesses tmpBP = BO_BusinessProcesse.SelectAll();

                    DataColumn tmpDCol = null;

                    tmpDCol = new DataColumn( "BusinessProcessName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "BusinessProcessID" );
                    tmpDTbl.Columns.Add( tmpDCol );

                    DataRow tmpDRow = null;
                    foreach ( BO_BusinessProcesse boBP in tmpBP )
                    {
                        if ( ( null == boBP.Allowedtypes || boBP.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                             && ( !boBP.BusinessProcessID.Equals( "1" ) //no ETL type
                             && !boBP.BusinessProcessID.Equals( "2" ) ) //no Initials (these are auto generated)
                            )
                        {
                            tmpDRow = tmpDTbl.NewRow();
                            tmpDRow["BusinessProcessName"] = boBP.BusinessProcessName;
                            tmpDRow["BusinessProcessID"] = boBP.BusinessProcessID;
                            tmpDTbl.Rows.Add( tmpDRow );
                        }
                    }

                //    CurrentBusinessProcessList = tmpDTbl;
                //}

                    return tmpDTbl; // (DataTable) Session["CurrentBusinessProcessList"];
            }
            //set
            //{
            //    Session["CurrentBusinessProcessList"] = value;
            //}
        }
    }
}