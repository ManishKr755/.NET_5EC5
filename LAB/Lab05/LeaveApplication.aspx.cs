using System;
using System.Web;

namespace LAB_05
{
    public partial class LeaveApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SelectedDate"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                DateTime date =
                    (DateTime)Session["SelectedDate"];

                lblSelectedDate.Text =
                    date.ToString("dd-MM-yyyy");

                if (Request.Cookies["UserName"] != null)
                {
                    txtName.Text =
                        Request.Cookies["UserName"].Value;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                lblMessage.Text = "Name.";
                return;
            }

            if (ddlLeaveType.SelectedValue == "")
            {
                lblMessage.Text = "Leave Type.";
                return;
            }

            if (txtReason.Text.Trim() == "")
            {
                lblMessage.Text = "Reason.";
                return;
            }

            DateTime date =
                (DateTime)Session["SelectedDate"];

            Session["Name"] = txtName.Text;
            Session["LeaveType"] = ddlLeaveType.SelectedValue;
            Session["Reason"] = txtReason.Text;

            if (chkRemember.Checked)
            {
                HttpCookie cookie =
                    new HttpCookie("UserName");

                cookie.Value = txtName.Text;

                cookie.Expires =
                    DateTime.Now.AddDays(1);

                Response.Cookies.Add(cookie);
            }

            lblMessage.Text =
                "Leave Application Details:" +
                "<br/><br/>" +

                "Name: " +
                Server.HtmlEncode(Session["Name"].ToString()) +
                "<br/><br/>" +

                "Selected Date: " +
                date.ToString("dd-MM-yyyy") +
                "<br/><br/>" +

                "Leave Type: " +
                Server.HtmlEncode(Session["LeaveType"].ToString()) +
                "<br/><br/>" +

                "Reason: " +
                Server.HtmlEncode(Session["Reason"].ToString());
        }
    }
}
