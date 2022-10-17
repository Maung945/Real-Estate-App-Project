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
    public partial class adminagentmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();                                           // This function refreshes & update the table on Website

        }

        // Add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkAgentExists())
            {
                Response.Write("<script>alert('Agent ID already exists. Please choose different ID');</script");
            }
            else
            {               
                addNewAgent();                                              // Call the addNewAgent() function here
            }
        }

        // Update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAgentExists())                                         // If Agent exists then update
            {
                updateAgent();                                              // Call the updateAgent() function here
            }
            else
            {                                                               // Otherwise, show below message
                Response.Write("<script>alert('Agent does not exist. Re-enter Agent ID');</script>");
            }       
        }

        // Delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if(checkAgentExists())
            {
                deleteAgent();
            } else
            {
                Response.Write("<script>alert('Agent does not exist. Re-enter Agent ID');</script>");
            }
        }

        // Go Button Click
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        void deleteAgent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM agent_master_tbl WHERE agent_id='" + TextBox1.Text.Trim() + "'", con);
                
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Agent Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();                                       // This function refreshes & update the table on Website
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }
        void updateAgent()                                                  // This function updates the Existing Agent
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE agent_master_tbl SET agent_name=@agent_name WHERE agent_id='"+TextBox1.Text.Trim()+"'", con);
                    cmd.Parameters.AddWithValue("@agent_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Agent Updated Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();                                   // This function refreshes & update the table on Website
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
        }
        // User defined functions
        void addNewAgent()                                                  // This function adds New Agent to database
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO agent_master_tbl(agent_id,agent_name) values(@agent_id,@agent_name)", con);
                    cmd.Parameters.AddWithValue("@agent_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@agent_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Agent Added Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
        }
        bool checkAgentExists ()                                            // This function checks if user exists
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from agent_master_tbl where agent_id='" + TextBox1.Text.Trim() + "';", con);
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