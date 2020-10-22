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
    public partial class EventInfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String sqlQuery = "Select EventTitle, EventID From Event ";
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

                String sqlQuery1 = "Select EventTitle, EventID From Event ";

                SqlDataAdapter sqlAdapter1 = new SqlDataAdapter(sqlQuery1, con);
                DataTable dtTable1 = new DataTable();
                sqlAdapter1.Fill(dtTable1);

                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("All", "0"));
                for (int i = 0; i < dtTable1.Rows.Count; i++)
                {
                    DropDownList1.Items.Add(new ListItem(dtTable1.Rows[i][0].ToString(), dtTable1.Rows[i][1].ToString()));
                }

                DropDownList1_SelectedIndexChanged(null, null);

                String sqlQuery2 = "Select EventTitle, EventID From Event ";

                SqlDataAdapter sqlAdapter2 = new SqlDataAdapter(sqlQuery2, con);
                DataTable dtTable2 = new DataTable();
                sqlAdapter2.Fill(dtTable2);

                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("All", "0"));
                for (int i = 0; i < dtTable2.Rows.Count; i++)
                {
                    DropDownList1.Items.Add(new ListItem(dtTable2.Rows[i][0].ToString(), dtTable2.Rows[i][1].ToString()));
                }

                DropDownList1_SelectedIndexChanged(null, null);
            }
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();

            if (DropDownList1.SelectedIndex == 0)
            {
                DT = EvtInfo(0);
                DT1 = volInfo(0);
                DT2 = stuInfo(0);
            }
            else
            {
                DT = EvtInfo(int.Parse(DropDownList1.SelectedValue));
                DT1= volInfo (int.Parse(DropDownList1.SelectedValue));
                DT2 = stuInfo(int.Parse(DropDownList1.SelectedValue));
            }
            GridView1.DataSource = DT;
            GridView2.DataSource = DT1;
            GridView3.DataSource = DT2;
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }

        
        private DataTable EvtInfo(int EventID)
        {
            string sqlQuery;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

            if (EventID == 0)
            {
                sqlQuery = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Coordinator.FirstName + ' ' + Coordinator.LastName as CoordinatorName ";
                sqlQuery += "FROM Event, EventPresenter, Coordinator ";
                sqlQuery += "WHERE Event.EventID = EventPresenter.EventID and Coordinator.CoordinatorID = EventPresenter.CoordinatorID ";

            }
            else
            {
                sqlQuery = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Coordinator.FirstName + ' ' + Coordinator.LastName as CoordinatorName ";
                sqlQuery += "FROM Event, EventPresenter, Coordinator ";
                sqlQuery += "WHERE Event.EventID = EventPresenter.EventID and Coordinator.CoordinatorID = EventPresenter.CoordinatorID ";
                sqlQuery += "and Event.EventID =  @EventID ";
            }

            SqlCommand comm = new SqlCommand(sqlQuery, con);

            if (EventID != 0)
                comm.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = EventID;

            con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataTable dtForGridTable = new DataTable();
            da.Fill(dtForGridTable);

            con.Close();

            return dtForGridTable;
        }

        private DataTable volInfo(int EventID)
        {
            string sqlQuery1;
            //Get connection string from web.config file  
            string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon1);

            if (EventID == 0)

            {
                sqlQuery1 = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as VolunteerName ";
                sqlQuery1 += "FROM Event, EventPersonnel, EventPresenter ";
                sqlQuery1 += "WHERE Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID ";
            }

            else
            {
                sqlQuery1 = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as VolunteerName ";
                sqlQuery1 += "FROM Event, EventPersonnel, EventPresenter ";
                sqlQuery1 += "WHERE Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID ";
                sqlQuery1 += "and Event.EventID = " + @EventID;
            }

            
            SqlCommand comm = new SqlCommand(sqlQuery1, con);
            if (EventID != 0)
                comm.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = EventID;

            con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter ds = new SqlDataAdapter();
            ds.SelectCommand = comm;
            DataTable dtTable1 = new DataTable();
            ds.Fill(dtTable1);

            con.Close();

            return dtTable1;
        }

        private DataTable stuInfo(int EventID)
        {
            string sqlQuery2;
            //Get connection string from web.config file  
            string strcon2 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon2);
            if (EventID == 0)

            {
                sqlQuery2 = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Student.FirstName + ' ' + Student.LastName as StudentName ";
                sqlQuery2 += "FROM Event, Student, EventAttendance ";
                sqlQuery2 += "WHERE EventAttendance.EventID = Event.EventID and EventAttendance.StudentID = Student.StudentID ";

            }

            else
            {
                sqlQuery2 = "SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Student.FirstName + ' ' + Student.LastName as StudentName ";
                sqlQuery2 += "FROM Event, Student, EventAttendance ";
                sqlQuery2 += "WHERE EventAttendance.EventID = Event.EventID and EventAttendance.StudentID = Student.StudentID ";
                sqlQuery2 += "and Event.EventID = " + EventID;
            }

            SqlCommand comm = new SqlCommand(sqlQuery2, con);
            if (EventID != 0)
                comm.Parameters.Add("@EventID", SqlDbType.NVarChar).Value = EventID;

            con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter dc = new SqlDataAdapter();
            dc.SelectCommand = comm;
            DataTable dtTable2 = new DataTable();
            dc.Fill(dtTable2);

            con.Close();

            return dtTable2;
        }
    }
}