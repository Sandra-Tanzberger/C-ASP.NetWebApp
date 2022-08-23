using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ATG.BusinessObject;
using ATG.Interface;
using AtgWebUI;

namespace AppControl
{
    public partial class LettersReportViewer : System.Web.UI.UserControl
    {
        private List<Letter> lettersCollection = new List<Letter>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private class Letter
        {
            public string letterDisplayName;
            public decimal? letterTypeCode;//is letterID from letters table
            public string reportName;
            public List<ReportParameter> reportParams;

            public Letter(string letterDisplayName, decimal? letterTypeCode, ReportParameter param, string reportName)
            {
                reportParams = new List<ReportParameter>();
                this.letterDisplayName = letterDisplayName;
                this.letterTypeCode = letterTypeCode;
                this.reportName = reportName;
                this.reportParams.Add(param);
            }
        }
        /*
        public void LoadLetters(BO_Messages boMessages)
        {
            //messages only have one paramater ApplicationID which is a comma delimited list 1,2,3...
            //List<string> appIDList;
            System.Collections.Hashtable messages = null;
            messages = (System.Collections.Hashtable)Session["MessagesChecked"];

            foreach(BO_Message boMessage in boMessages)
            {
                //use Session["MessagesChecked"] from messages grid to determine whether application_id is in print queue
                if (InMessageQueue(boMessage.ApplicationID.ToString(), (System.Collections.Hashtable)messages))
                {
                    Letter letter;
                    if(MessageLetterTypeFound(out letter, getMessageType(boMessage.MessageSubject)))
                    {
                        letter.reportParams[0].Values.Add(boMessage.ApplicationID.ToString());
                    }
                    else
                    {
                        lettersCollection.Add(new Letter(boMessage.MessageSubject, getMessageType(boMessage.MessageSubject), (new ReportParameter("APPLICATION_ID", boMessage.ApplicationID.ToString())), getReportNameByMessageType(getMessageType(boMessage.MessageSubject))));
                    }
                }
            }
            LoadViewerControls();
        }
         */

        public void LoadLetters(BO_Letters lettersQueue, bool printLabels, bool printCover)
        {
            //messages only have one paramater ApplicationID which is a comma delimited list 1,2,3...
            //List<string> appIDList;
            List<string> labelsList = new List<string>();
            
            foreach (BO_Letter boLetter in lettersQueue)
            {
                Letter letter;
                if (LetterTypeFound(out letter, boLetter.LetterID))
                {
                    letter.reportParams[0].Values.Add(boLetter.ApplicationID.ToString());
                }
                else
                {
                    lettersCollection.Add(new Letter(boLetter.LetterDisplayName, boLetter.LetterID, (new ReportParameter(boLetter.Parameters[0].ParameterName, boLetter.ApplicationID.ToString())), boLetter.ReportName));
                }

                labelsList.Add(boLetter.ApplicationID.ToString());
            }

            if (printLabels)
            {
                Letter labels = new Letter("Mailing Labels", 9, (new ReportParameter("Application_Id")), "75DayPOPSLabelReport5262");
                foreach (string appID in labelsList)
                    labels.reportParams[0].Values.Add(appID);
                labels.reportParams.Add(new ReportParameter("RunBy","4"));
                lettersCollection.Add(labels);
            }
            if(printCover)
            {
                Letter labels = new Letter("Cover Letters", 99, (new ReportParameter("APPLICATION_ID")), "Full License Letter");
                foreach (string appID in labelsList)
                    labels.reportParams[0].Values.Add(appID);
                lettersCollection.Add(labels);
            }
            LoadViewerControls();
        }

        private bool LetterTypeFound(out Letter letter, decimal? letterTypeCode)
        {
            bool typeFound = false;
            letter = null;
            foreach (Letter currentLetter in lettersCollection)
            {
                if (currentLetter.letterTypeCode == letterTypeCode)
                {
                    typeFound = true;
                    letter = currentLetter;
                    break;
                }
            }
            return typeFound;
        }

        private void LoadViewerControls()
        {
            StateConfig config = StateConfig.getConfigObj();
            string reportServerUrl = config.Reports.ReportServerUrl;
            string reportPath = config.Reports.ReportPath;

            int i = 0;

            foreach (Letter letter in lettersCollection)
            {
                i += 1;
                ReportViewer viewer = new ReportViewer();
                viewer.ShowCredentialPrompts = false;
                viewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                viewer.ServerReport.ReportServerUrl = new Uri(reportServerUrl);
                viewer.ServerReport.ReportPath = reportPath + letter.reportName;
                viewer.ServerReport.DisplayName = letter.letterDisplayName;
                viewer.ServerReport.SetParameters(letter.reportParams);
                viewer.SizeToReportContent = true;
                //viewer.Width = Unit.Pixel(800);
                viewer.Width = Unit.Percentage(100);
                viewer.ShowRefreshButton = false;
                viewer.ShowFindControls = false;
                viewer.ShowParameterPrompts = false;
                viewer.ID = "viewer" + letter.letterDisplayName;
                Panel panel = new Panel();
                panel.CssClass = "LicensePanel";
                panel.ID = "panel" + letter.letterDisplayName;
                panel.Controls.Add(viewer);
                SliderDiv sliderDiv = new SliderDiv();
                sliderDiv.ID = "sliderdiv" + letter.letterDisplayName.Replace(" ", "").Trim().ToUpper();
                sliderDiv.TitleText = letter.letterDisplayName;
                sliderDiv.Controls.Add(panel);
                ReportViewers.Controls.Add(sliderDiv);
                sliderDiv.Visible = true;
                if (i == 1)
                    sliderDiv.Expanded = "true";
                else
                    sliderDiv.Expanded = "false";
                viewer.ServerReport.Refresh();
            }
        }
        /*
        private int getMessageType(string messageSubject)
        {
            int type = 0;
            if(messageSubject.Contains("15"))
                type =  15;
            if(messageSubject.Contains("30"))
                type = 30;
            if (messageSubject.Contains("75"))
                type = 75;

            return type;
        }

        private string getReportNameByMessageType(int letterTypeCode)
        {
            string name = "";
            switch (letterTypeCode)
            {
                case 15:
                    name = "75 Day Renewal Letter";
                    break;
                case 30:
                    name = "30 Day Renewal Letter";
                    break;
                case 75:
                    name = "75 Day Renewal Letter";
                    break;
                default:
                    name = "75 Day Renewal Letter";
                    break;
            }

            return name;
        }
        */
    }
}