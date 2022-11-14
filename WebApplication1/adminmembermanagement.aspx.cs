using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // Go Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }
        // Active Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }
        // Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }
        // Deactive Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }
        // Delete Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        // user defined functions
        bool checkMemberExists()                                            // This function checks if user exists
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);                                                // Data is filled in the table
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    return true;                                            // True
                }
                else
                {
                    return false;                                           // Otherwise, 'False'
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
                return false;
            }
        }
        void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(8).ToString();          // member_ID
                        TextBox1.Text = dr.GetValue(10).ToString();         // Account Status
                        TextBox9.Text = dr.GetValue(0).ToString();          // Full_name
                        TextBox10.Text = dr.GetValue(1).ToString();         // Member Since
                        TextBox11.Text = dr.GetValue(2).ToString();         // Phone number
                        TextBox12.Text = dr.GetValue(3).ToString();         // Email
                        TextBox13.Text = dr.GetValue(4).ToString();         // State
                        TextBox14.Text = dr.GetValue(5).ToString();         // City
                        TextBox15.Text = dr.GetValue(6).ToString();         // Zip Code
                        TextBox7.Text = dr.GetValue(7).ToString();          // Full Address

                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Update Member status - User defined
        void updateMemberStatusByID(string status)
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id= '" + TextBox2.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invlid Member ID.');</script>");
            }
        }

        void deleteMemberByID()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();                                       // This function refreshes & update the table on Website
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID.');</script>");
            }
        }
        void clearForm()                                                   // Clear the form when the delete button is clicked
        {
            TextBox2.Text = "";                                            // member_ID
            TextBox1.Text = "";                                            // Account Status
            TextBox9.Text = "";                                            // Full_name
            TextBox10.Text = "";                                           // Member Since
            TextBox11.Text = "";                                           // Phone number
            TextBox12.Text = "";                                           // Email
            TextBox13.Text = "";                                           // State
            TextBox14.Text = "";                                           // City
            TextBox15.Text = "";                                           // Zip Code
            TextBox7.Text = "";                                            // Full Address
        }
    }
}