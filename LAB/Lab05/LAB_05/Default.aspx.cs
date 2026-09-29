using System;

namespace LAB_05
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblSelectedDate.Text =
                "Selected Date: " +
                Calendar1.SelectedDate.ToString("dd-MM-yyyy");

            btnApplyLeave.Enabled = true;
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Session["SelectedDate"] = Calendar1.SelectedDate;

            Response.Redirect("LeaveApplication.aspx");
        }
    }
}