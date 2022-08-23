using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ATG.Utilities.RTF {

    /// <summary>
    /// Summary description for RTFUtil
    /// </summary>
    public class RTFUtil {
        protected RTFUtil() {
        }

        static public string StripRTF(
            string inRTF
            , string inCRLF
        ) {
            string rtf = inRTF;

            // replace "\par" and "\pard" with a space. note that
            // "\p" is a special regular expression, so we need
            // to double the slashes
            //$str =~ s/\\par / /g;
            rtf = Regex.Replace(rtf, @"\\pard?", inCRLF);
            //rtf = Regex.Replace(rtf, @"\\par", inCRLF);

            // replace "\XXX" rtf codes with nothing
            //$str =~ s/\\([a-z]+)(-?\d+)?(?:[ ]|(?=[^a-z0-9]))//og;
            rtf = Regex.Replace(rtf, @"\\([a-z]+)(-?\d+)?(?:[ ]|(?=[^a-z0-9]))", "");

            // replace anything within braces with nothing
            //$str =~ s/\{.*?\}//g;
            rtf = Regex.Replace(rtf, @"\{.*?\}", "");

            // replace "\\^" and "\\ " with nothing. note that "\[" is 
            // special and needs the \\
            //$str =~ s/\\[^ ]+ //g;
            rtf = Regex.Replace(rtf, @"\\[^ ]+", "");

            // replace "\{" and "\}" with nothing
            //$str =~ s/[\{\}]//g;
            rtf = Regex.Replace(rtf, @"[\{\}]", "");
            return rtf;
        }
    }

}