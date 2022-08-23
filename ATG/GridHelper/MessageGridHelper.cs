using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace ATG.GridHelper
{
    public class MessageGridHelper
    {
        private DataTable _gridDataSource = null;
        private String _typeMessageView = null;

        public void Initialize( String inTypeMessageView, String inSelectKey )
        {
            _typeMessageView = inTypeMessageView;

            switch ( _typeMessageView )
            {
                case "APPLICATION":
                    BO_Messages boMessages = null;
                    boMessages = BO_Message.SelectAllByApplicationStatus( inSelectKey );
                    _gridDataSource = _LoadGridDataApplicationLetters( boMessages );
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
            switch ( _typeMessageView )
            {
                case "APPLICATION":
                    return BuildAppMessageGridColumns();
                default:
                    return BuildAppMessageGridColumns();
            }
        }

        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        private GridBoundColumn[] BuildAppMessageGridColumns()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[9];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MessageID";
            tmpCol.DataField = "MessageID";
            tmpCol.HeaderText = "MessageID";
            tmpCol.Visible = false ;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StateID";
            tmpCol.DataField = "StateID";
            tmpCol.HeaderText = "State ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "NameCity";
            tmpCol.DataField = "NameCity";
            tmpCol.HeaderText = "Facility - City";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );
            tmpCol.AllowFiltering = true;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MessageDate";
            tmpCol.DataField = "MessageDate";
            tmpCol.HeaderText = "Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MessageSubject";
            tmpCol.DataField = "MessageSubject";
            tmpCol.HeaderText = "Subject";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "SendType";
            tmpCol.DataField = "SendType";
            tmpCol.HeaderText = "Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = false;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StatusCode";
            tmpCol.DataField = "StatusCode";
            tmpCol.HeaderText = "Status";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MessagePrintDate";
            tmpCol.DataField = "MessagePrintDate";
            tmpCol.HeaderText = "Printed";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 95 );
            tmpCol.AllowFiltering = true;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "BusinessProcessName";
            tmpCol.DataField = "BusinessProcessName";
            tmpCol.HeaderText = "Process";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 110 );
            tmpCol.AllowFiltering = true;
            retColList[8] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            switch ( _typeMessageView )
            {
                case "APPLICATION":
                    tmpDCol = new DataColumn( "MessageID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "StateID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "NameCity" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "MessageDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "MessageSubject" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "SendType" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "StatusCode" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "MessagePrintDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "BusinessProcessName" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    break;
            }

            return tmpDTbl;
        }

        private DataTable _LoadGridDataApplicationLetters( BO_Messages inApplicationMessageList )
        {
            DataTable retTable = _getGridDataTableStruct();

            if ( null != inApplicationMessageList )
            {
                foreach ( BO_Message boMsg in inApplicationMessageList )
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["MessageID"] = boMsg.MessageID;
                    tmpDR["StateID"] = boMsg.StateID;
                    tmpDR["NameCity"] = CommonFunc.ConvertToTitleCase( boMsg.NameCity );
                    tmpDR["MessageDate"] = ( null != boMsg.MessageDate ? boMsg.MessageDate.Value.ToShortDateString() : "" );
                    tmpDR["MessageSubject"] = boMsg.MessageSubject;
                    tmpDR["SendType"] = boMsg.SendType;
                    tmpDR["StatusCode"] = boMsg.StatusCode;
                    tmpDR["MessagePrintDate"] = ( null != boMsg.MessagePrintDate ? boMsg.MessagePrintDate.Value.ToShortDateString() : "" );
                    tmpDR["BusinessProcessName"] = CommonFunc.ConvertToTitleCase( boMsg.BusinessProcessName );

                    retTable.Rows.Add( tmpDR );
                }
            }
            return retTable;
        }

    }
}
