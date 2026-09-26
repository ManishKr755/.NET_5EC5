using System;
using System.Xml.Linq;

namespace LAB_04
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string gender = "";

                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else if (rbFemale.Checked)
                {
                    gender = "Female";
                }

                lblDetails.Text =
                    "<h3>Registration Details</h3>" +
                    "Name: " + txtName.Text +
                    "<br/><br/>" +
                    "Email: " + txtEmail.Text +
                    "<br/><br/>" +
                    "Gender: " + gender +
                    "<br/><br/>" +
                    "Event: " + ddlEvent.SelectedValue +
                    "<br/><br/>" +
                    "Phone: " + txtPhone.Text;
            }
        }
    }
}
