using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace ATG.GridHelper
{
    public class FacilityGridHelper
    {
        private DataTable _gridDataSource = null;
        private String _typeFacilityView = null;

        public void Initialize( String inTypeFacilityView, String inSelectKey )
        {
            _typeFacilityView = inTypeFacilityView;

            switch ( _typeFacilityView )
            {
                case "PROGRAM":
                    BO_Providers boProviders = null;
                    if ( !string.IsNullOrEmpty( inSelectKey ) && inSelectKey.Equals( "~" ) )
                    {
                        // get ALL records
                        boProviders = BO_Provider.SelectAllForGrid();
                    }
                    else
                    {
                        // get rows for the specified Program Id
                        BO_ProgramPrimaryKey boProgPK = new BO_ProgramPrimaryKey( inSelectKey );
                        boProviders = BO_Provider.SelectAllByForeignKeyProgramIDForGrid( boProgPK );
                    }

                    _gridDataSource = _LoadGridDataProgram( boProviders );

                    break;
                case "PROCESS":
                    BO_Applications boApplications = null;
                    if ( !string.IsNullOrEmpty( inSelectKey ) && inSelectKey.Equals( "~" ) )
                    {
                        // get ALL records
                        boApplications = BO_Application.SelectAllProvidersInProcessForGrid();
                    }
                    else
                    {
                        // get rows for the specified Business Process Id
                        BO_BusinessProcessePrimaryKey boBusinessProcPK = new BO_BusinessProcessePrimaryKey( inSelectKey );
                        boApplications = BO_Application.SelectProvidersByProcessForGrid( boBusinessProcPK );
                    }
                    
                    _gridDataSource = _LoadGridDataProcess( boApplications );
                    
                    break;
                default:
                    break;
            }
        }

        public DataTable GridDataSource
        {
            get
            {
                return _gridDataSource;
            }
            set
            {
                _gridDataSource = value;
            }
        }

        public GridBoundColumn[] GridColumnList()
        {

            switch ( _typeFacilityView )
            {
                case "PROGRAM":
                    return BuildProvGridColumns();
                case "PROCESS":
                    return BuildProvProcessGridColumns();
                default:
                    return BuildProvGridColumns();
            }
            
        }

        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        private GridBoundColumn[] BuildProvGridColumns()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[13];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StateID";
            tmpCol.DataField = "StateID";
            tmpCol.HeaderText = "State Id";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityName";
            tmpCol.DataField = "FacilityName";
            tmpCol.HeaderText = "Facility Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 215 );
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel( 190 );
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StatusCodeDesc";
            tmpCol.DataField = "StatusCodeDesc";
            tmpCol.HeaderText = "Operating Status";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel(125);
            tmpCol.AllowFiltering = true;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "GeographicalCity";
            tmpCol.DataField = "GeographicalCity";
            tmpCol.HeaderText = "Geographical City";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Parish";
            tmpCol.DataField = "Parish";
            tmpCol.HeaderText = "Parish";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FieldOffice";
            tmpCol.DataField = "FieldOffice";
            tmpCol.HeaderText = "Field Office";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "AniversaryMonth";
            tmpCol.DataField = "AniversaryMonth";
            tmpCol.HeaderText = "Anniversary Month";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel( 30 );
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ChapAccreditionYN";
            tmpCol.DataField = "ChapAccreditionYN";
            tmpCol.HeaderText = "Accredited";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel( 20 );
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "PopsIntID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[8] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "AspenIntID";
            tmpCol.DataField = "AspenIntID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[9] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ProgramID";
            tmpCol.DataField = "ProgramID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[10] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LisensureNum";
            tmpCol.DataField = "LisensureNum";
            tmpCol.HeaderText = "Licensure #";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel(125);
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel(30);
            retColList[11] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "NameOfCorporation";
            tmpCol.DataField = "NameOfCorporation";
            tmpCol.HeaderText = "Owner/Entity";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel(125);
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel(30);
            retColList[12] = tmpCol;
            return retColList;
        }

        /// <summary>
        /// Define the columns for the Providers-Process grid
        /// </summary>
        private GridBoundColumn[] BuildProvProcessGridColumns()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[9];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StateID";
            tmpCol.DataField = "StateID";
            tmpCol.HeaderText = "State Id";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "BusinessProcessName";
            tmpCol.DataField = "BusinessProcessName";
            tmpCol.HeaderText = "Application Process";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityName";
            tmpCol.DataField = "FacilityName";
            tmpCol.HeaderText = "Facility Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 215 );
            tmpCol.AllowFiltering = true;
            tmpCol.FilterControlWidth = Unit.Pixel( 190 );
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "AniversaryMonth";
            tmpCol.DataField = "AniversaryMonth";
            tmpCol.HeaderText = "Anniversary Month";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ApplicationStatusDesc";
            tmpCol.DataField = "ApplicationStatusDesc";
            tmpCol.HeaderText = "Status";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "SubmissionDate";
            tmpCol.DataField = "SubmissionDate";
            tmpCol.HeaderText = "Submission Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "PopsIntID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "AspenIntID";
            tmpCol.DataField = "AspenIntID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ProgramID";
            tmpCol.DataField = "ProgramID";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[8] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            switch ( _typeFacilityView )
            {
                case "PROGRAM":
                    tmpDCol = new DataColumn( "StateID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn("StatusCodeDesc");
                    tmpDTbl.Columns.Add(tmpDCol);
                    tmpDCol = new DataColumn("GeographicalCity");
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Parish" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FieldOffice" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "ChapAccreditionYN" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PopsIntID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "AspenIntID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "ProgramID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "AniversaryMonth" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "LisensureNum" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "NameOfCorporation" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
                case "PROCESS":
                    tmpDCol = new DataColumn( "StateID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "BusinessProcessName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "SubmissionDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "ApplicationStatusDesc" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PopsIntID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "AspenIntID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "ProgramID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "AniversaryMonth" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
            }

            return tmpDTbl;
        }

        private DataTable _LoadGridDataProgram( BO_Providers inProviderList )
        {
            DataTable retTable = _getGridDataTableStruct();

            if ( null != inProviderList )
            {
                foreach ( BO_Provider boProv in inProviderList )
                {
                    string tmpAnivMnth = "";

                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["StateID"] = boProv.StateID;
                    //SMM 01/22/2012 - Removed title case conversion
                    //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boProv.FacilityName );
                    tmpDR["FacilityName"] = boProv.FacilityName;
                    tmpDR["StatusCodeDesc"] = boProv.StatusCodeDesc;
                    tmpDR["GeographicalCity"] = CommonFunc.ConvertToTitleCase( boProv.GeographicalCity );
                    tmpDR["Parish"] = CommonFunc.ConvertToTitleCase( boProv.Parish );
                    tmpDR["FieldOffice"] = boProv.FieldOffice;
                    tmpDR["ChapAccreditionYN"] = boProv.ChapAccreditionYN;
                    tmpDR["PopsIntID"] = boProv.PopsIntID;
                    tmpDR["AspenIntID"] = boProv.AspenIntID;
                    tmpDR["ProgramID"] = boProv.ProgramID;
                    tmpDR["LisensureNum"] = boProv.LicensureNum;
                    tmpDR["NameOfCorporation"] = boProv.NameOfCorporation;

                    if ( null != boProv.LicensureExpirationDate )
                        tmpAnivMnth = boProv.LicensureExpirationDate.Value.ToString( "MMM" );
                    else
                        tmpAnivMnth = "";

                    tmpDR["AniversaryMonth"] = tmpAnivMnth;
                    

                    retTable.Rows.Add( tmpDR );
                }
            }
            return retTable;
        }

        private DataTable _LoadGridDataProcess( BO_Applications inApplicationsList )
        {
            DataTable retTable = _getGridDataTableStruct();

            if ( null != inApplicationsList )
            {
                foreach ( BO_Application boApp in inApplicationsList )
                {
                    DataRow tmpDR = retTable.NewRow();
                    string tmpAnivMnth = "";
                    
                    tmpDR["StateID"] = boApp.StateID;
                    tmpDR["BusinessProcessName"] = CommonFunc.ConvertToTitleCase( boApp.BusinessProcessName );
                    //SMM 01/22/2012 - Removed title case conversion
                    //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boApp.FacilityName );
                    tmpDR["FacilityName"] = boApp.FacilityName;

                    if ( null != boApp.LicensureExpirationDate )
                        tmpAnivMnth = boApp.LicensureExpirationDate.Value.ToString( "MMM" );
                    else
                        tmpAnivMnth = "";

                    tmpDR["AniversaryMonth"] = tmpAnivMnth;
                    tmpDR["SubmissionDate"] = boApp.SubmissionDate;
                    tmpDR["ApplicationStatusDesc"] = CommonFunc.ConvertToTitleCase( boApp.ApplicationStatusDesc );
                    tmpDR["PopsIntID"] = boApp.PopsIntID;
                    tmpDR["AspenIntID"] = boApp.AspenIntID;
                    tmpDR["ProgramID"] = boApp.ProgramID;

                    retTable.Rows.Add( tmpDR );
                }
            }

            return retTable;
        }
    }
}
