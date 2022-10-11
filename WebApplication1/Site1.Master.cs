using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {

                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;                                         // If no user logging in LinkButton1->'user login' should be visible
                    LinkButton2.Visible = true;                                         // The same for LinkedButton2->'sign up'

                    LinkButton3.Visible = false;                                        // If no one logging in 'log out' should not be shown
                    LinkButton7.Visible = false;                                        // THe same for 'hello user'

                    LinkButton6.Visible = true;                                         // If no user logging in LinkButton7->'admin login' should be visible

                    LinkButton11.Visible = false;                                       // If no one logging in 'agents' should not be shown
                    LinkButton12.Visible = false;                                       // THe same for 'appointments'
                    LinkButton8.Visible = false;                                        // THe same for 'appointments management'
                    LinkButton9.Visible = false;                                        // THe same for 'house management'
                    LinkButton10.Visible = false;                                       // THe same for 'member management'
                }

                else if (Session["role"].Equals("user"))                                // WHEN USER LOGGED IN
                {
                    LinkButton1.Visible = false;                                        // When User logged in, "user login" is NOT visible
                    LinkButton2.Visible = false;                                        // The same for LinkedButton2->'sign up'

                    LinkButton3.Visible = true;                                         // If User logging in 'log out', will become visible
                    LinkButton7.Visible = true;                                         // THe same for 'hello user'
                    LinkButton7.Text = "Hello  " +Session["username"].ToString();      // Output "Hello user_name"

                    LinkButton11.Visible = true;                                        // If User logs in in 'agents' should not be shown
                    LinkButton12.Visible = false;                                       // THe same for 'appointments'
                    LinkButton8.Visible = false;                                        // THe same for 'appointments management'
                    LinkButton9.Visible = false;                                        // THe same for 'house management'
                    LinkButton10.Visible = false;                                       // THe same for 'member management'
                }
                else if (Session["role"].Equals("admin"))                                // WHEN ADMIN LOGGED IN
                {
                    LinkButton1.Visible = false;                                        // When Admin logged in, "user login" is NOT visible
                    LinkButton2.Visible = false;                                        // The same for LinkedButton2->'sign up'

                    LinkButton3.Visible = true;                                         // If Admin logging in 'log out', will become visible
                    LinkButton7.Visible = true;                                         // THe same for 'hello user'
                    LinkButton7.Text = "Hello Admin ";                                  // Output "Hello user_name"

                    LinkButton11.Visible = true;                                        // If Admin logs in 'Agents' become visible
                    LinkButton12.Visible = true;                                        // THe same for 'appointments'
                    LinkButton8.Visible = true;                                         // THe same for 'appointments management'
                    LinkButton9.Visible = true;                                         // THe same for 'house management'
                    LinkButton10.Visible = true;                                        // THe same for 'member management'
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminagentmanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("appointment.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("appointmentmanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminhouseinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminhouseinventory.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true;                                         // If no user logging in LinkButton1->'user login' should be visible
            LinkButton2.Visible = true;                                         // The same for LinkedButton2->'sign up'
            LinkButton3.Visible = false;                                        // If no one logging in 'log out' should not be shown
            LinkButton7.Visible = false;                                        // THe same for 'hello user'
            LinkButton6.Visible = true;                                         // If no user logging in LinkButton7->'admin login' should be visible
            LinkButton11.Visible = false;                                       // If no one logging in 'agents' should not be shown
            LinkButton12.Visible = false;                                       // THe same for 'appointments'
            LinkButton8.Visible = false;                                        // THe same for 'appointments management'
            LinkButton9.Visible = false;                                        // THe same for 'house management'
            LinkButton10.Visible = false;                                       // THe same for 'member management'
        }
    }
}