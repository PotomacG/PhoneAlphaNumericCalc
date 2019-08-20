using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PhoneEntry : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 7 && txtPhone.Text.Length != 10)
            {
                PopMessage.Show("Please Enter a 7 or 10 digit phone number");
                txtPhone.Text = "";
            }
            else
            {
                //NOTE: Example did not diplay digits during replacement, so they were intentionally left out of the results
                //           ie.  12 will translate to 1A, 1B, 1C (12 will not be displayed when the replacement takes place.)

                CalcNumbers.SetNumbers(txtPhone.Text);  //All of the work takes place here
                LoadGrid();  //Display the results
                lblCount.Text = "Total number of combinations: " + CalcNumbers.outputList.Count.ToString();
                divResults.Visible = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //Reset controls and give it another go
            txtPhone.Text = "";
            gvResults.DataSource = null;
            gvResults.DataBind();
            gvResults.PageIndex = 0;
            divResults.Visible = false;
        }

        private void LoadGrid()
        {
            gvResults.DataSource = CalcNumbers.outputList;
            gvResults.DataBind();            
        }

        protected void gvResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResults.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

    }
}