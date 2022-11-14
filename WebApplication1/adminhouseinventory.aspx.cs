using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//using System.IO;

namespace WebApplication1
{
    public partial class adminhouseinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAppointmentsAgentsValues();
            GridView1.DataBind();
        }
        // Go Button Click
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }
        // Add Button Click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkHouseExists())
            {
                Response.Write("<script>alert('House Already Exists.');</script>");
            }
            else
            {
                addNewHouse();
            }
        }
        // Update Button Click
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        // Delete Button Click
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        // User definded functions
        void fillAppointmentsAgentsValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT agent_id FROM agent_master_tbl;", con); // Agent ID
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "agent_id";
                DropDownList2.DataBind();

                cmd = new SqlCommand("SELECT appointment_id FROM appointment_master_tbl;", con); // Appointment ID
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "appointment_id";
                DropDownList3.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        bool checkHouseExists()                                            // This function checks if user exists
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from house_master_tbl where house_id='" + TextBox2.Text.Trim() +
                    "'OR house_address='" + TextBox9.Text.Trim() + "';", con);
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
        void addNewHouse()
        {
            try
            {
                string propertyType = "";
                foreach (int i in ListBox1.GetSelectedIndices())                        // Get multiple selections from "Property_Tpyes"
                {
                    propertyType = propertyType + ListBox1.Items[i] + ",";
                }
                propertyType = propertyType.Remove(propertyType.Length - 1);            // Remove the ',' at the end of chosen types

                string filepath = "~/house_images/House-img1.jpg";                      // File Upload
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("house_images/" + filename));         // Save the image
                filepath = "~/house_images/" + filename;                                // File path is stored,

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO house_master_tbl (house_id,house_address,property_type,price,price_persqft,agent_id,appointment_id,year_built,rooms,bathrooms,offers,owner_name,on_appointment,house_description,house_img_link) values (@house_id,@house_address,@property_type,@price,@price_persqft,@agent_id,@appointment_id,@year_built,@rooms,@bathrooms,@offers,@owner_name,@on_appointment,@house_description,@house_img_link)", con);

                cmd.Parameters.AddWithValue("@house_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@house_address", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@property_type", propertyType);            // Passing 'propertyType'
                cmd.Parameters.AddWithValue("@price", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@price_persqft", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@agent_id", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@appointment_id", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@year_built", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@rooms", TextBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@bathrooms", TextBox15.Text.Trim());
                cmd.Parameters.AddWithValue("@offers", TextBox16.Text.Trim());
                cmd.Parameters.AddWithValue("@owner_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@on_appointment", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@house_description", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@house_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Listing Created Successfully.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }

    }
}