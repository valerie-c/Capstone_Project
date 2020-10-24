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
using System.Configuration;

namespace Lab2
{

    public partial class AssignStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connect with database and read the data from grid table
            String sqlQuery = "SELECT EventTitle, EventID  From Event;";
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            CheckBox1.Text = dtForGridTable.Rows[0][0].ToString();
            CheckBox1.ID = dtForGridTable.Rows[0][1].ToString();

            CheckBox2.Text = dtForGridTable.Rows[1][0].ToString();
            CheckBox2.ID = dtForGridTable.Rows[1][1].ToString();

            CheckBox3.Text = dtForGridTable.Rows[2][0].ToString();
            CheckBox3.ID = dtForGridTable.Rows[2][1].ToString();

            CheckBox4.Text = dtForGridTable.Rows[3][0].ToString();
            CheckBox4.ID = dtForGridTable.Rows[3][1].ToString();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            // Inner Join SQL Query
            String sqlQuery = "SELECT Student.FirstName + ' ' + Student.LastName AS StudentName, EventTitle, Event.Date, Event.Time ";
            sqlQuery += "FROM EventAttendance ";
            sqlQuery += "INNER JOIN Event ON EventAttendance.EventID = Event.EventID ";
            sqlQuery += "INNER JOIN Student ON EventAttendance.StudentID = Student.StudentID Order By Student.FirstName ASC";

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            getEventsResult.DataSource = dtForGridTable;
            getEventsResult.DataBind();
        }

        protected void btnAssignStudent_Click(object sender, EventArgs e)
        {

            if (CheckBox1.Checked == false && CheckBox2.Checked == false && CheckBox3.Checked == false && CheckBox4.Checked == false)
            {
                // show messagebox when user did not select event
                //System.Windows.MessageBox.Show("Please select an event!");
                Response.Write("<script>alert('Please select an event!');</script>");

                return;
            }
            try
            {
                if (CheckBox1.Checked == true)
                {
                    Dome(Convert.ToInt32(CheckBox1.ID), Convert.ToInt32(ddlUserList.SelectedValue));
                }

                if (CheckBox2.Checked == true)
                {
                    Dome(Convert.ToInt32(CheckBox2.ID), Convert.ToInt32(ddlUserList.SelectedValue));
                }

                if (CheckBox3.Checked == true)
                {
                    Dome(Convert.ToInt32(CheckBox3.ID), Convert.ToInt32(ddlUserList.SelectedValue));
                }

                if (CheckBox4.Checked == true)
                {
                    Dome(Convert.ToInt32(CheckBox4.ID), Convert.ToInt32(ddlUserList.SelectedValue));
                }

                //System.Windows.MessageBox.Show("OK! Student assigned to the Events successfully!");
                Response.Write("<script>alert('OK! Student assigned to the Events successfully!');</script>");

            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("Error! Try again!");
                Response.Write("<script>alert('Error! Try again!');</script>");

            }
        }

        private void Dome(int EventID, int StudentID)
        {
            // retrieve the data from database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "insert into EventAttendance (EventID,StudentID) values (@EventID,@StudentID)";
            cmd.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentID;

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }
    }
}