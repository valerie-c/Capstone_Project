using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Diagnostics;
using System.Configuration;

namespace Lab2
{

    public partial class AssignVolunteer : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT EventTitle, EventID  From Event;";
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);

           
        }

        protected void btnAssignVolunteers_Click(object sender, EventArgs e)
        {
            if (ddlEventList.SelectedValue == "1")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "2")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "3")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "4")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "5")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "6")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "7")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "8")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "9")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "10")
            {
                Demo(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlVolunteerList.SelectedValue));
            }

            //System.Windows.MessageBox.Show("OK! Student assigned to the Events successfully!");
            Response.Write("<script>alert('OK! Student assigned to the Events successfully!');</script>");



        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            // Connect database and retrieve the data
            String sqlQuery = "SELECT EventPersonnel.FirstName + ' ' + EventPersonnel.LastName AS VolunteerName, EventPersonnel.EmailAddress, EventPersonnel.PhoneNumber, EventTitle, Event.Date, Event.Time ";
            sqlQuery += "FROM EventPersonnel, EventPresenter, Event ";
            sqlQuery += "Where Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID Order By EventPersonnel.FirstName ASC";

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            getResult.DataSource = dtForGridTable;
            getResult.DataBind();
        }

        private void Demo(int EventID, int Personne1ID)
        {

            // Connect The database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "insert into EventPresenter (EventID,PersonnelID) values (@EventID,@PersonnelID)";
            cmd.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = EventID;
            cmd.Parameters.Add("@PersonnelID", SqlDbType.NVarChar).Value = Personne1ID;



            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }

        

        
        }


    }
