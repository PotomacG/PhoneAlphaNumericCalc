using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    public static class PopMessage
    {
        /// <summary> 
        /// Shows a client-side JavaScript alert in the browser. 
        /// </summary> 
        /// <param name="message">The message to appear in the alert.</param> 
        public static void Show(string message)
        {
            ////NOTE: If adding line feed on a C# page use \\n between lines 
            ////                                        on a VB page use \n between lines
            // Cleans the message to allow single quotation marks 
            string cleanMessage = message.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

            // Gets the executing web page 
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page 
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                ScriptManager.RegisterStartupScript(page, typeof(PopMessage), "alert", script, false);
                // page.ClientScript.RegisterClientScriptBlock(typeof(ShowMessage), "alert", script);
            }
        }

    }
}