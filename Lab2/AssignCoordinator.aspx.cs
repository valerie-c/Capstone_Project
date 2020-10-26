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
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            
        }

        protected void btnAssignCoordinators_Click(object sender, EventArgs e)
        {

            if (ddlEventList.SelectedValue == "1")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "2")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "3")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "4")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "5")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "6")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "7")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "8")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "9")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }
            if (ddlEventList.SelectedValue == "10")
            {
                Dome(Convert.ToInt32(ddlEventList.SelectedValue), Convert.ToInt32(ddlCoordinatorList.SelectedValue));
            }





            //System.Windows.MessageBox.Show("OK! Coordinator assigned to the Events successfully!");
            Response.Write("<script>alert('OK! Coordinator assigned to the Events successfully!');</script>");


            
          
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            // Inner Join SQL Query
            String sqlQuery = "SELECT Coordinator.FirstName + ' ' + Coordinator.LastName AS CoordinatorName, Coordinator.PhoneNumber, Coordinator.Email, EventTitle, Event.Date, Event.Time ";
            sqlQuery += "FROM EventPresenter ";
            sqlQuery += "INNER JOIN Event ON EventPresenter.EventID = Event.EventID ";
            sqlQuery += "INNER JOIN Coordinator ON EventPresenter. CoordinatorID = Coordinator. CoordinatorID Order By Coordinator.FirstName ASC";


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
        private void Dome(int EventID, int CoordinatorID)
        {
            // retrieve the data from database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
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