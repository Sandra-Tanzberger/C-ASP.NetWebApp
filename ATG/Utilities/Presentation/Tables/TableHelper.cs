using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ATG.Utilities.Presentation.Tables {


	/// <summary>
	/// Used as helper class for creating dynamic tables
	/// </summary>
	public class TableHelper {
		private TableHelper() {
		}

		static public TableRow AddRow(
		  Table ioTable
		, int inColCnt
		) {
			TableRow tmpRow = new TableRow();

            tmpRow.VerticalAlign = VerticalAlign.Bottom;

			for (int i = 0; i < inColCnt; i++) {
				tmpRow.Cells.Add(new TableCell());
			}

			ioTable.Rows.Add(tmpRow);

			return tmpRow;

		}

        /* TextBox Methods - */

        static public TextBox AddTextBox(
		  TableCell ioCell
		, string inID
		, string inText
        , int inWidth
        , int inMaxLength
        , bool inReadOnly
		) {
			TextBox textBox = new TextBox();
			textBox.Text = inText;
			textBox.ID = inID;
            textBox.Width = inWidth;
            textBox.MaxLength = inMaxLength;
			
            if (inReadOnly)
            {
                textBox.ReadOnly = inReadOnly;
                textBox.BackColor = Color.WhiteSmoke;
            }
            
            ioCell.Controls.Add(textBox);
			return textBox;
		}

        //SMM 09/12/2007 - Added addtional argument for precision. This argument is used to determine
        // the number of max characters allowed for entry. Also used with onblur event for validation.
		static public TextBox AddTextBoxNumber(
		  TableCell ioCell
		, string inID
		, string inText
		, int inMaxLength
        , int inPrecision
		, int inWidth
        , bool inReadOnly
		) {
			int tmpMaxChar = 0;

            if ( inPrecision > 0 )
                tmpMaxChar = inMaxLength + 1; //Add one position for decimal point
            else
                tmpMaxChar = inMaxLength;

            TextBox textBox = AddTextBox(ioCell, inID, inText, inWidth, tmpMaxChar, inReadOnly);
            textBox.Attributes.Add("OnKeyPress", "MaskNumber(this, " + ((inPrecision > 0) ? "1" : "0") + ");");
            textBox.Attributes.Add("OnBlur", "CheckNumberFormat(this, " + inMaxLength + ", " + inPrecision + " );");
            return textBox;
		}

        //SMM 11/12/2008 - Added for phone number formatting
        static public TextBox AddTextBoxPhone(
          TableCell ioCell
        , string inID
        , string inText
        , int inMaxLength
        , int inPrecision
        , int inWidth
        , bool inReadOnly
        )
        {
            TextBox textBox = AddTextBox(ioCell, inID, inText, inWidth, inMaxLength, inReadOnly);
            textBox.Attributes.Add("OnKeyPress", "MaskPhone(this);");
            textBox.Attributes.Add("OnBlur", "validateandformatUSPhone(this, 0);");
            return textBox;
        }

        static public TextBox AddTextBoxDate(
		  TableCell ioCell
		, string inID
		, string inText
        , int inWidth
        , bool inReadOnly
        )
        {
            TextBox textBox = AddTextBox(ioCell, inID, inText, inWidth, 10, inReadOnly);
			textBox.Attributes.Add("OnBlur", "CheckDate(this);");
			return textBox;
		}

        /* ComboBox Methods */

        static public DropDownList AddDropDownList(
          TableCell ioCell
		, string inID
		)
        {
            DropDownList tmpDDL = new DropDownList();
            tmpDDL.ID = inID;
            ioCell.Controls.Add(tmpDDL);
            return tmpDDL;
        }

        static public DropDownList AddDropDownListWithDataSource(
          TableCell ioCell
        , string inID
        , System.Data.DataView inDDL_Source
        , string inKeyCol
        , string inDisplayCol
        )
        {
            DropDownList tmpDDL = AddDropDownList( ioCell, inID );
            tmpDDL.DataSource = inDDL_Source;
            tmpDDL.DataValueField = inKeyCol;
            tmpDDL.DataTextField = inDisplayCol;
            tmpDDL.DataBind();
            return tmpDDL;
        }

        /* Button Methods */

        static public Button AddButton(
          TableCell ioCell
        , string inID
        )
        {
            Button tmpBtn = new Button();
            tmpBtn.ID = inID;
            ioCell.Controls.Add(tmpBtn);
            return tmpBtn;
        }

        static public Button AddButtonUpdateTotal(
          TableCell ioCell
        , string inID
        , string inUpdateMethod
        , string inBtnTxt
        )
        {
            Button tmpBtn = AddButton(ioCell, inID);
            tmpBtn.CommandName = inUpdateMethod ;
            tmpBtn.Text = inBtnTxt;
            return tmpBtn; 
        }

        static public CheckBox AddCheckbox(
          TableCell ioCell
        , string inID
        , string value
        )
        {
            CheckBox tmpBtn = new CheckBox();
            tmpBtn.ID = inID;
            tmpBtn.Checked = (value =="Y");
            ioCell.Controls.Add(tmpBtn);
            return tmpBtn;
        }

    }
}