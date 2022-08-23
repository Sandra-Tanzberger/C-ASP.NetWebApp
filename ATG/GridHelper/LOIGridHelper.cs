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
    public class LOIGridHelper
    {
        private DataTable _gridDataSource = null;
        private String _typeLOIView = null;

        public void Initialize( String inTypeLOIView, String inSelectKey )
        {
            _typeLOIView = inTypeLOIView;
            BO_LetterOfIntents boLOIs = null;

            switch ( inSelectKey )
            {
                case "ALL":
                    boLOIs = BO_LetterOfIntent.SelectAll();
                    break;
                case "LOI":
                    boLOIs = BO_LetterOfIntent.SelectByField( "LETTER_OF_INTENT_TYPE", "1" );
                    break;
                case "RFA":
                    boLOIs = BO_LetterOfIntent.SelectByField( "LETTER_OF_INTENT_TYPE", "2" );
                    break;
                case "CER":
                    boLOIs = BO_LetterOfIntent.SelectByField( "LETTER_OF_INTENT_TYPE", "3" );
                    break;
                case "LOI_OA":
                    boLOIs = BO_LetterOfIntent.SelectByField( "LETTER_OF_INTENT_TYPE", "4" );
                    break;
                default:
                    break;
            }

            if ( null != boLOIs )
            {
                _gridDataSource = _LoadGridDataLOI( boLOIs );
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
            switch ( _typeLOIView )
            {
                case "ALL":
                    return BuildLOIGridColumns();
                default:
                    return BuildLOIGridColumns();
            }
        }

        /// <summary>
        /// Define the columns for the IDR grid
        /// </summary>
        private GridBoundColumn[] BuildLOIGridColumns()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[9];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "TypeLOI";
            tmpCol.DataField = "TypeLOI";
            tmpCol.HeaderText = "Type LOI";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LetterOfIntentID";
            tmpCol.DataField = "LetterOfIntentID";
            tmpCol.HeaderText = "Tracking Id";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityType";
            tmpCol.DataField = "FacilityType";
            tmpCol.HeaderText = "Fac. Type";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Name";
            tmpCol.DataField = "Name";
            tmpCol.HeaderText = "Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );
            tmpCol.AllowFiltering = true;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PlanToOpenDate";
            tmpCol.DataField = "PlanToOpenDate";
            tmpCol.HeaderText = "Open Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 100 );
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "GeographicCity";
            tmpCol.DataField = "GeographicCity";
            tmpCol.HeaderText = "City";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 100 );
            tmpCol.AllowFiltering = true;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DisplayConfirmed";
            tmpCol.DataField = "DisplayConfirmed";
            tmpCol.HeaderText = "Confirmed";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Confirmed";
            tmpCol.DataField = "Confirmed";
            tmpCol.HeaderText = "Confirmed";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DisplayType";
            tmpCol.DataField = "DisplayType";
            tmpCol.HeaderText = "Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 150 );
            tmpCol.AllowFiltering = true;
            retColList[8] = tmpCol; 
            
            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            switch ( _typeLOIView )
            {
                case "ALL":
                    tmpDCol = new DataColumn( "TypeLOI" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "LetterOfIntentID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityType" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Name" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PlanToOpenDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "GeographicCity" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "DisplayConfirmed" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Confirmed" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "DisplayType" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
                default:
                    tmpDCol = new DataColumn( "TypeLOI" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "LetterOfIntentID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FacilityType" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Name" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PlanToOpenDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "GeographicCity" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "DisplayConfirmed" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Confirmed" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "DisplayType" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
            }

            return tmpDTbl;
        }

        private DataTable _LoadGridDataLOI( BO_LetterOfIntents inLOIList )
        {
            DataTable retTable = _getGridDataTableStruct();

            if ( null != inLOIList )
            {
                foreach ( BO_LetterOfIntent boLOI in inLOIList )
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["LetterOfIntentID"] = boLOI.LetterOfIntentID;
                    tmpDR["FacilityType"] = boLOI.FacilityType;
                    //SMM 01/22/2012 - Removed title case conversion
                    //tmpDR["Name"] = CommonFunc.ConvertToTitleCase( boLOI.Name );
                    tmpDR["Name"] = boLOI.Name;
                    tmpDR["PlanToOpenDate"] = ( null != boLOI.PlanToOpenDate ? boLOI.PlanToOpenDate.Value.ToShortDateString() : "" );
                    tmpDR["GeographicCity"] = CommonFunc.ConvertToTitleCase( boLOI.GeographicCity );
                    tmpDR["Confirmed"] = boLOI.Confirmed;
                    
                    if ( boLOI.Confirmed.ToString().Equals( "1" ) )
                    {
                        tmpDR["DisplayConfirmed"] = "Yes" ;
                    }
                    else
                    {
                        tmpDR["DisplayConfirmed"] = "No";
                    }


                    if ( boLOI.LetterOfIntentType.Equals( "1" ) )
                    {
                        tmpDR["DisplayType"] = "LOI - Initial Licensure" ;
                    }
                    else if ( boLOI.LetterOfIntentType.Equals( "2" ) )
                    {
                        tmpDR["DisplayType"] = "RFA" ;
                    }
                    else if ( boLOI.LetterOfIntentType.Equals( "3" ) )
                    {
                        tmpDR["DisplayType"] = "CER";
                    }
                    else if ( boLOI.LetterOfIntentType.Equals( "4" ) )
                    {
                        tmpDR["DisplayType"] = "LOI - Offsite Addition";
                    }
                    else
                    {
                        tmpDR["DisplayType"] = "" ;
                    }

                    tmpDR["TypeLOI"] = boLOI.LetterOfIntentType;
                    
                    retTable.Rows.Add( tmpDR );
                }
            }
            return retTable;
        }

    }
}
