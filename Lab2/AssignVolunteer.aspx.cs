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
        private string CB1ID = "";
        private string CB2ID = "";
        private string CB3ID = "";
        private string CB4ID = "";
        private int Temp = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT EventTitle, EventID  From Event;";
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);

            Cb1.Text = dtTable.Rows[0][0].ToString();
            CB1ID = dtTable.Rows[0][1].ToString();

            Cb2.Text = dtTable.Rows[1][0].ToString();
            CB2ID = dtTable.Rows[1][1].ToString();

            Cb3.Text = dtTable.Rows[2][0].ToString();
            CB3ID = dtTable.Rows[2][1].ToString();

            Cb4.Text = dtTable.Rows[3][0].ToString();
            CB4ID = dtTable.Rows[3][1].ToString();

            ddlVolunteerList_SelectedIndexChanged(null, null);
        }

        protected void btnAssignVolunteers_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (Cb1.Checked == true)
                count++;

            if (Cb2.Checked == true)
                count++;

            if (Cb3.Checked == true)
                count++;

            if (Cb4.Checked == true)
                count++;

            try
            {
                // Check if the volunteer can sign more events
                if (count > 1)
                {
                    //System.Windows.MessageBox.Show("Volunteer only can assign one more events! ");
                    Response.Write("<script>alert('Volunteer only can assign one more events!');</script>");
                    Temp = 0;
                    return;

                }

                if (count == 0)
                {
                    //System.Windows.MessageBox.Show("Must choose at least one event to participate!");
                    Response.Write("<script>alert('Must choose at least one event to participate!');</script>");

                    return;
                }

                DataTable DT = GetEventPresenterCount(ddlVolunteerList.SelectedValue);

                if (Cb1.Checked == true)
                {
                    Demo(CB1ID, ddlVolunteerList.SelectedValue);
                }

                if (Cb2.Checked == true)
                {
                    Demo(CB2ID, ddlVolunteerList.SelectedValue);
                }

                if (Cb3.Checked == true)
                {
                    Demo(CB3ID, ddlVolunteerList.SelectedValue);
                }

                if (Cb4.Checked == true)
                {
                    Demo(CB4ID, ddlVolunteerList.SelectedValue);
                }

                //System.Windows.MessageBox.Show("OK! Volunteer assigned to the Events successfully!");
                Response.Write("<script>alert('OK! Volunteer assigned to the Events successfully!');</script>");


                Cb1.Checked = false;
                Cb2.Checked = false;
                Cb3.Checked = false;
                Cb4.Checked = false;
            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("Error! Try again!");
                Response.Write("<script>alert('Error! Try again!');</script>");
            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            // Connect database and retrieve the data
            String sqlQuery = "SELECT EventPersonnel.FirstName + ' ' + EventPersonnel.LastName AS VolunteerName, EventPersonnel.EmailAddress, EventPersonnel.PhoneNumber, EventTitle, Event.Date, Event.Time ";
            sqlQuery += "FROM EventPersonnel, EventPresenter, Event ";
            sqlQuery += "Where Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID Order By EventPersonnel.FirstName ASC";

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            getResult.DataSource = dtForGridTable;
            getResult.DataBind();
        }

        private void Demo(string EventID, string Personne1ID)
        {

            // Connect The database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "insert into EventPresenter (EventID,PersonnelID) values (@EventID,@PersonnelID)";
            cmd.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = EventID.Trim();
            cmd.Parameters.Add("@PersonnelID", SqlDbType.NVarChar).Value = Personne1ID.Trim();



            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }

        public DataTable GetEventPresenterCount(string PersonnelID)
        {
            if (PersonnelID == null || PersonnelID == "")
            {
                PersonnelID = "0";
            }
            String sqlQuery = "select EventID,PersonnelID from EventPresenter Where PersonnelID =  @PersonnelID  ";
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand comm = new SqlCommand(sqlQuery, con);
            comm.Parameters.Add("@PersonnelID", SqlDbType.Int).Value =int.Parse(PersonnelID);
            //con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataTable dtForGridTable = new DataTable();
            da.Fill(dtForGridTable);

            con.Close();

            return dtForGridTable;
        }

        protected void ddlVolunteerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cb1.Enabled = true;
            Cb2.Enabled = true;
            Cb3.Enabled = true;
            Cb4.Enabled = true;
            btnAssignVolunteers.Enabled = true;

            DataTable DT = GetEventPresenterCount(ddlVolunteerList.SelectedValue);

            // Check if the volunteer has already choose 2 events
            if (DT.Rows.Count >= 2)
            {
                //System.Windows.MessageBox.Show("Ok! Volunteer already chose 2 events! ");
                Response.Write("<script>alert('Ok! Volunteer already chose 2 events!');</script>");
                btnAssignVolunteers.Enabled = false;
            }

            if (DT.Rows.Count == 1)
            {
                if (DT.Rows[0][0].ToString() == CB1ID)
                {
                    Cb1.Checked = false;
                    Cb1.Enabled = false;
                }

                else if (DT.Rows[0][0].ToString() == CB2ID)
                {
                    Cb2.Checked = false;
                    Cb2.Enabled = false;
                }
                else if (DT.Rows[0][0].ToString() == CB3ID)
                {
                    Cb3.Checked = false;
                    Cb3.Enabled = false;
                }
                else if (DT.Rows[0][0].ToString() == CB4ID)
                {
                    Cb4.Checked = false;
                    Cb4.Enabled = false;
                }

                Temp = 1;
                //System.Windows.MessageBox.Show("Volunteer can only sign 1 more event! ");
            }

            if (DT.Rows.Count == 0)
            {
                //System.Windows.MessageBox.Show("Volunteer can assign no more than 2 events!");
                Response.Write("<script>alert('Volunteer can assign no more than 2 events!');</script>");
            }
        }


    }
}