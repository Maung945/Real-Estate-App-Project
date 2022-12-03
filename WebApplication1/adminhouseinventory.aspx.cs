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

namespace WebApplication1
{
    public partial class adminhouseinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; // Connection String
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAppointmentsAgentsValues();
            }
            GridView1.DataBind();
        }
        // Go Button Click
        protected void Button5_Click(object sender, EventArgs e)
        {
            getAgentByID();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            getHouseByID();
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
            updateHouseByID();
        }
        // Delete Button Click
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteHouseById();
        }

        // User definded functions
        void deleteHouseById()
        {
            if (checkHouseExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM house_master_tbl WHERE house_id='" + TextBox2.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Listing Deleted Successfully');</script>");
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
        void updateHouseByID()
        {
            if (checkHouseExists())
            {
                try
                {
                    string propertyType = "";
                    foreach (int i in ListBox1.GetSelectedIndices())                        // Get multiple selections from "Property_Tpyes"
                    {
                        propertyType = propertyType + ListBox1.Items[i] + ",";
                    }
                    propertyType = propertyType.Remove(propertyType.Length - 1);

                    string filepath = "~/house_images/House-img1.jpg";                      // File Upload
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)                                  // Check if there is no change
                    {
                        filepath = global_filepath;                                         // Keep existing file
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("house_images/" + filename));         // If there is new file, update
                        filepath = "~/house_images/" + filename;                                // File path is stored,
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE house_master_tbl set house_address=@house_address, property_type=@property_type, price=@price, price_persqft=@price_persqft, agent_id=@agent_id, appointment_id=@appointment_id, year_built=@year_built, rooms=@rooms, bathrooms=@bathrooms, offers=@offers, owner_name=@owner_name, on_appointment=@on_appointment, house_description=@house_description, house_img_link=@house_img_link where house_id='" + TextBox2.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@house_address", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@property_type", propertyType);                        // Passing 'propertyType'
                    cmd.Parameters.AddWithValue("@price", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@price_persqft", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@agent_id", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@appointment_id", TextBox19.Text.Trim());
                    cmd.Parameters.AddWithValue("@year_built", TextBox13.Text.Trim());
                    cmd.Parameters.AddWithValue("@rooms", TextBox14.Text.Trim());
                    cmd.Parameters.AddWithValue("@bathrooms", TextBox15.Text.Trim());
                    cmd.Parameters.AddWithValue("@offers", TextBox16.Text.Trim());
                    cmd.Parameters.AddWithValue("@owner_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@on_appointment", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@house_description", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@house_img_link", filepath);                           // Filepath is being passed here

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('House Listing Updated Successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invlid Book ID.');</script>");
            }
        }

        void getAgentByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM agent_master_tbl WHERE agent_id='" + DropDownList2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DropDownList2.Text = dr.GetValue(0).ToString();          // agent_ID
                        TextBox19.Text = dr.GetValue(1).ToString();              // Agent Name

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
        void getHouseByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM house_master_tbl WHERE house_id='" + TextBox2.Text.Trim() + "';", con); // Agent ID
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox9.Text = dt.Rows[0]["house_address"].ToString();
                    TextBox10.Text = dt.Rows[0]["price"].ToString();
                    TextBox11.Text = dt.Rows[0]["price_persqft"].ToString();
                    TextBox13.Text = dt.Rows[0]["year_built"].ToString().Trim();
                    TextBox14.Text = dt.Rows[0]["rooms"].ToString().Trim();
                    TextBox15.Text = dt.Rows[0]["bathrooms"].ToString().Trim();
                    TextBox16.Text = dt.Rows[0]["offers"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["owner_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["on_appointment"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["house_description"].ToString();
                    TextBox19.Text = dt.Rows[0]["appointment_id"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["agent_id"].ToString().Trim();             //DropDown Lists
                    //DropDownList3.SelectedValue = dt.Rows[0]["appointment_id"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] propertyType = dt.Rows[0]["property_type"].ToString().Trim().Split(',');
                    for (int i = 0; i < propertyType.Length; i++)                                       // For Loop to get values from Dropdown List
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == propertyType[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }

                        }
                    }
                    global_filepath = dt.Rows[0]["house_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid House ID');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
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
                /*
                cmd = new SqlCommand("SELECT RTRIM(LTRIM(appointment_id)) as appointment_id FROM appointment_master_tbl;", con); // Appointment ID
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                
                
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "appointment_id";
                DropDownList3.DataBind();
                */
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
                //cmd.Parameters.AddWithValue("@appointment_id", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@appointment_id", TextBox19.Text.Trim());
                
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