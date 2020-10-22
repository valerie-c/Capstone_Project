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
    public partial class PersonInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String sqlQuery = "Select Coordinator.FirstName + ' ' + Coordinator.LastName as CoordinatorName, CoordinatorID From Coordinator ";
                //Get connection string from web.config file  
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
                DataTable dtTable = new DataTable();
                sqlAdapter.Fill(dtTable);

                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("All", "0"));
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    DropDownList1.Items.Add(new ListItem(dtTable.Rows[i][0].ToString(), dtTable.Rows[i][1].ToString()));
                }

                DropDownList1_SelectedIndexChanged(null, null);

                String sqlQuery1 = "Select EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as VolunteerName, PersonnelID From EventPersonnel ";
                //con.Open();
                DataTable dtTable1 = new DataTable();
                SqlDataAdapter sqlAdapter1 = new SqlDataAdapter(sqlQuery1, con);
                sqlAdapter1.Fill(dtTable1);

                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("All", "0"));
                for (int i = 0; i < dtTable1.Rows.Count; i++)
                {
                    DropDownList2.Items.Add(new ListItem(dtTable1.Rows[i][0].ToString(), dtTable1.Rows[i][1].ToString()));
                }

                DropDownList2_SelectedIndexChanged(null, null);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();

            if (DropDownList1.SelectedIndex == 0)
            {
                DT = EvtInfo(0);
            }
            else
            {
                DT = EvtInfo(int.Parse(DropDownList1.SelectedValue));
            }
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }

        private DataTable EvtInfo(int CoordinatorID)
        {
            string sqlQuery;
            if (CoordinatorID == 0)

            {
                sqlQuery = "SELECT Coordinator.CoordinatorID, Coordinator.FirstName + ' ' + Coordinator.LastName AS CoordinatorName, Coordinator.PhoneNumber, Coordinator.Email, EventTitle, Event.Date, Event.Time ";
                sqlQuery += "FROM EventPresenter ";
                sqlQuery += "INNER JOIN Coordinator ON EventPresenter.CoordinatorID = Coordinator.CoordinatorID ";
                sqlQuery += "INNER JOIN Event on Event.EventID = EventPresenter.EventID Order By Coordinator.FirstName ASC ";

            }

            else
            {
                sqlQuery = "SELECT Coordinator.CoordinatorID, Coordinator.FirstName + ' ' + Coordinator.LastName AS CoordinatorName, Coordinator.PhoneNumber, Coordinator.Email, EventTitle, Event.Date, Event.Time ";
                sqlQuery += "FROM EventPresenter ";
                sqlQuery += "INNER JOIN Coordinator ON EventPresenter.CoordinatorID = Coordinator.CoordinatorID ";
                sqlQuery += "INNER JOIN Event on Event.EventID = EventPresenter.EventID "; 
                sqlQuery += "and Coordinator.CoordinatorID = " + CoordinatorID;
            }
            
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            DataTable dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);

            return dtTable;
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();

            if (DropDownList2.SelectedIndex == 0)
            {
                DT = VolInfo(0);
            }
            else
            {
                DT = VolInfo(int.Parse(DropDownList2.SelectedValue));
            }
            GridView2.DataSource = DT;
            GridView2.DataBind();
        }

      

        private DataTable VolInfo(int PersonnelID)
        {
            string sqlQuery;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

            if (PersonnelID == 0)

            {
                sqlQuery = "SELECT EventPersonnel.PersonnelID, EventPersonnel.FirstName + ' ' + EventPersonnel.LastName AS VolunteerName, EventPersonnel.PhoneNumber, EventPersonnel.EmailAddress, EventTitle, Event.Date, Event.Time ";
                sqlQuery += "FROM EventPresenter ";
                sqlQuery += "INNER JOIN EventPersonnel ON EventPresenter. PersonnelID = EventPersonnel.PersonnelID ";
                sqlQuery += "INNER JOIN Event on Event.EventID = EventPresenter.EventID Order By EventPersonnel.FirstName ASC";
            }

            else
            {
                sqlQuery = "SELECT EventPersonnel.PersonnelID, EventPersonnel.FirstName + ' ' + EventPersonnel.LastName AS VolunteerName, EventPersonnel.PhoneNumber, EventPersonnel.EmailAddress, EventTitle, Event.Date, Event.Time ";
                sqlQuery += "FROM EventPresenter ";
                sqlQuery += "INNER JOIN EventPersonnel ON EventPresenter. PersonnelID = EventPersonnel.PersonnelID ";
                sqlQuery += "INNER JOIN Event on Event.EventID = EventPresenter.EventID ";
                sqlQuery += "and EventPersonnel.PersonnelID =  @PersonnelID ";
            }

            SqlCommand comm = new SqlCommand(sqlQuery, con);

            if (PersonnelID != 0)
           
                comm.Parameters.Add("@PersonnelID", SqlDbType.NVarChar).Value = PersonnelID;


            con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataTable dtForGridTable = new DataTable();
            da.Fill(dtForGridTable);

            con.Close();

            return dtForGridTable;
        }
    }
}