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
    public partial class adminappointmentmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        
        // Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkAppointmentExists())
            {
                Response.Write("<script>alert('Appointment ID already exists. Please choose different ID');</script");
            }
            else
            {
                addNewAppointment();
            }
        }

        // Update Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkAppointmentExists())
            {
                updateAppointment();                                              // If appointment exists, updateAppointment()
            }
            else
            {
                Response.Write("<script>alert('Appointment ID already exists. Please choose different ID');</script");
            }
        }

        // Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAppointmentExists())
            {
                deleteAppointment();
            }
            else
            {
                Response.Write("<script>alert('Appointment does not exist. Re-enter Appointment ID');</script>");
            }
        }

        // Find Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAppointmentById();
        }

        void getAppointmentById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from appointment_master_tbl where appointment_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);                                                // Data is filled in the table
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Appointment Id.Enter Appointment Id again.');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }

        void deleteAppointment()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM appointment_master_tbl WHERE appointment_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Appointment Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();                                              // This function refreshes & update the table on Website
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }

        void updateAppointment()                                                   // This function updates existing Appointment in database
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE appointment_master_tbl SET appointment_name=@appointment_name WHERE appointment_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@appointment_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Appointment Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();                                              // This function refreshes & update the table on Website
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }

        void addNewAppointment()                                                  // This function adds New Appointment to database
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO appointment_master_tbl(appointment_id,appointment_name) values(@appointment_id,@appointment_name)", con);
                    cmd.Parameters.AddWithValue("@appointment_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@appointment_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Appointment Added Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
        }
        bool checkAppointmentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from appointment_master_tbl where appointment_id='" + TextBox1.Text.Trim() + "';", con);
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

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        
    }
}
