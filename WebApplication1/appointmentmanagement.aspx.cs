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
    public partial class appointment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Member ID Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getMemberNames();
        }
        //House ID Button
        protected void Button8_Click(object sender, EventArgs e)
        {
            getHouseAddress();
        }

        // Agent ID Button
        protected void Button6_Click(object sender, EventArgs e)
        {
            getAgentNames();
        }

        // Appointment ID Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            getAppointmentNames();
        }

        // CREATE button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(!checkTimeAptExists() || !checkHouseAptExists() || !checkDateAptExits() || !checkMemberAptExists())
            {
                createAppointment();
            }
            else
            {
                Response.Write("<script>alert('Appoint for Agent or Member already exits for the house');</script>");
            }
        }

        // CANCEL button
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        // User defined functions
        void createAppointment()
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO appointment_management_master_tbl(member_id,member_name,house_id,house_address,agent_id,appointment_id,appointment_date,appointment_time) values(@member_id,@member_name,@house_id,@house_address,@agent_id,@appointment_id,@appointment_date,@appointment_time)", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@house_id", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@house_address", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@agent_id", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@appointment_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@appointment_date", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@appointment_time", TextBox6.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Appointment Created Successfully');</script>");
                    
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
        }

        bool checkMemberAptExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM appointment_management_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool checkHouseAptExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM appointment_management_master_tbl where house_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool checkDateAptExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM appointment_management_master_tbl where appointment_date='" + TextBox5.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool checkTimeAptExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM appointment_management_master_tbl where appointment_time='" + TextBox6.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void getMemberNames()                                   // Get member_name by Member ID 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    TextBox2.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member Id.Enter Member Id again.');</script>");
                }
            }
            catch(Exception ex)
            {

            }
        }

        void getHouseAddress()                                   // Get house_address by House ID 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT house_address FROM house_master_tbl where house_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    TextBox7.Text = dt.Rows[0]["house_address"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid House Id.Enter House Id again.');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        void getAgentNames()                                   // Get agent_name by Agent ID 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT agent_name FROM agent_master_tbl where agent_id='" + TextBox4.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    TextBox4.Text = dt.Rows[0]["agent_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Agent Id.Enter Agent Id again.');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        void getAppointmentNames()                                   // Get Appointment by Member ID 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT appointment_name FROM appointment_master_tbl where appointment_id='" + TextBox3.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)                                     // If there is a string in 'datatable'
                {
                    TextBox3.Text = dt.Rows[0]["appointment_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Appointment Id.Enter Appointment Id again.');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}