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
    public partial class AssignCoordinator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connect with database and read the data from grid table
            String sqlQuery = "SELECT EventTitle, EventID From Event;";
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            Cb1.Text = dtForGridTable.Rows[0][0].ToString();
            Cb1.ID = dtForGridTable.Rows[0][1].ToString();

            Cb2.Text = dtForGridTable.Rows[1][0].ToString();
            Cb2.ID = dtForGridTable.Rows[1][1].ToString();

            Cb3.Text = dtForGridTable.Rows[2][0].ToString();
            Cb3.ID = dtForGridTable.Rows[2][1].ToString();

            Cb4.Text = dtForGridTable.Rows[3][0].ToString();
            Cb4.ID = dtForGridTable.Rows[3][1].ToString();
        }

        protected void btnAssignCoordinators_Click(object sender, EventArgs e)
        {
            if (Cb1.Checked == false && Cb2.Checked == false && Cb3.Checked == false && Cb4.Checked == false)
            {
                // show messagebox when user did not select event
                //System.Windows.MessageBox.Show("Please select an event!");
                Response.Write("<script>alert('Please select an event!');</script>");

                return;
            }
            try
            {
                String sqlQuery = "select EventID from EventPresenter where CoordinatorID = " + ddlCoordinatorList.SelectedValue;

                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
                DataTable DT = new DataTable();
                sqlAdapter.Fill(DT);

                if (Cb1.Checked == true)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(Cb1.ID) == (int)DT.Rows[i][0])
                        {
                            Response.Write("<script>alert('The event has already chose for the coordinator! Please select another one!');</script>");
                            return;
                        }
                    }
                    Dome(Convert.ToInt32(Cb1.ID), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
                }

                if (Cb2.Checked == true)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(Cb2.ID) == (int)DT.Rows[i][0])
                        {
                            Response.Write("<script>alert('The event has already chose for the coordinator! Please select another one!');</script>");
                            return;
                        }
                    }

                    Dome(Convert.ToInt32(Cb2.ID), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
                }

                if (Cb3.Checked == true)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(Cb3.ID) == (int)DT.Rows[i][0])
                        {
                            Response.Write("<script>alert('The event has already chose for the coordinator! Please select another one!');</script>");
                            return;
                        }
                    }

                    Dome(Convert.ToInt32(Cb3.ID), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
                }

                if (Cb4.Checked == true)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(Cb4.ID) == (int)DT.Rows[i][0])
                        {
                            Response.Write("<script>alert('The event has already chose for the coordinator! Please select another one!');</script>");
                            return;
                        }
                    }

                    Dome(Convert.ToInt32(Cb4.ID), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
                }

                //System.Windows.MessageBox.Show("OK! Coordinator assigned to the Events successfully!");
                Response.Write("<script>alert('OK! Coordinator assigned to the Events successfully!');</script>");


            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("Error! Try again!");
                Response.Write("<script>alert('Error! Try again!');</script>");

            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            // Inner Join SQL Query
            String sqlQuery = "SELECT Coordinator.FirstName + ' ' + Coordinator.LastName AS CoordinatorName, Coordinator.PhoneNumber, Coordinator.Email, EventTitle, Event.Date, Event.Time ";
            sqlQuery += "FROM EventPresenter ";
            sqlQuery += "INNER JOIN Event ON EventPresenter.EventID = Event.EventID ";
            sqlQuery += "INNER JOIN Coordinator ON EventPresenter. CoordinatorID = Coordinator. CoordinatorID Order By Coordinator.FirstName ASC";


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
        private void Dome(int EventID, int CoordinatorID)
        {
            // retrieve the data from database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "insert into EventPresenter (EventID,CoordinatorID) values (@EventID,@CoordinatorID)";
            cmd.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;
            cmd.Parameters.Add("@CoordinatorID", SqlDbType.Int).Value = CoordinatorID;

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }

    }
}