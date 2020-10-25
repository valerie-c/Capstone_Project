using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Policy;
using System.Windows;
using System.Data;
using Xceed.Wpf.Toolkit;

namespace Lab2
{
    public partial class createEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            if (IsEventDuplicate(txtTitle.Text, txtLocation.Text, txtSchoolName.Text, txtRoomNbr.Text))
            {
                // Check if the student exist after user input all the information in the webpage
                //System.Windows.MessageBox.Show("The Student has already exist");
                Response.Write("<script>alert('The Event has already exist');</script>");
                return;
            }

            string EventTitle = HttpUtility.HtmlEncode(txtTitle.Text);
            DateTime Date = Convert.ToDateTime(txtDate.Text);
            DateTime Time = Convert.ToDateTime(txtTime.Text);
            string Location = HttpUtility.HtmlEncode(txtLocation.Text);
            string MiddleSchoolName = HttpUtility.HtmlEncode(txtSchoolName.Text);
            string MiddleSchoolNumber = HttpUtility.HtmlEncode(txtSchoolNumber.Text);
            string MiddleSchoolEmail = HttpUtility.HtmlEncode(txtSchoolEmail.Text);
            string RoomNumber = HttpUtility.HtmlEncode(txtRoomNbr.Text);
            string RoomCapacity = HttpUtility.HtmlEncode(txtRoomCap.Text);
            string Description = HttpUtility.HtmlEncode(txtDescription.Text);

            //int TeacherID = Convert.ToInt32(DropDownList1.SelectedValue);
            //int ShirtInfoID = Convert.ToInt32(DropDownList2.SelectedValue);

            //new Student(0, FirstName, LastName, Age, Notes, LunchTicket, TeacherID, ShirtInfoID);

            // Make sure none of the textboxes are blank before commit to the database
            if ((!string.IsNullOrEmpty(txtTitle.Text)) && (!string.IsNullOrEmpty(txtDate.Text)) && (!string.IsNullOrEmpty(txtTime.Text)) && (!string.IsNullOrEmpty(txtLocation.Text)) 
                && (!string.IsNullOrEmpty(txtSchoolName.Text)) && (!string.IsNullOrEmpty(txtSchoolNumber.Text)) && (!string.IsNullOrEmpty(txtSchoolEmail.Text)) 
                && (!string.IsNullOrEmpty(txtRoomNbr.Text)) && (!string.IsNullOrEmpty(txtRoomCap.Text)) && (!string.IsNullOrEmpty(txtDescription.Text)))
            {
                try
                {
                    // Retrieve the data and display a messagebox shows added successfully
                    Insert_Event(EventTitle, Date, Time, Location, MiddleSchoolName, MiddleSchoolNumber, MiddleSchoolEmail, RoomNumber, RoomCapacity, Description);
                    Response.Write("<script>alert('OK! Added Event Successfully!');</script>");

                }
                catch (SqlException ex)
                {
                    Response.Write("<script>alert('Warning!The Event has already exist!');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('There is textbox is empty!');</script>");

            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            // Outer Join SQL Query
            String sqlQuery = "SELECT EventTitle, Time, Date, Location, MiddleSchoolName, MiddleSchoolNumber, MiddleSchoolEmail, RoomNumber, RoomCapacity, Description ";
            sqlQuery += "FROM Event ";;

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            con.Open();
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            getEventResult.DataSource = dtForGridTable;
            getEventResult.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the textbox after each insertion data
            txtTitle.Text = "";
            txtDate.Text = "";
            txtTime.Text = "";
            txtLocation.Text = "";
            txtSchoolName.Text = "";
            txtSchoolNumber.Text = "";
            txtSchoolEmail.Text = "";
            txtRoomNbr.Text = "";
            txtRoomCap.Text = "";
            txtDescription.Text = "";
        }

        private void Insert_Event(string EventTitle, DateTime Date, DateTime Time,string Location, string MiddleSchoolName, string MiddleSchoolNumber, string MiddleSchoolEmail, string RoomNumber, string RoomCapacity, string Description)
        {
            // Read the data from the database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            cmd.Connection = con;

            cmd.CommandText = "insert into Event (EventTitle, Date, Time, Location, MiddleSchoolName, MiddleSchoolNumber, MiddleSchoolEmail, RoomNumber, RoomCapacity, Description) " +
                "values (@EventTitle,@Date,@Time,@Location,@MiddleSchoolName,@MiddleSchoolNumber,@MiddleSchoolEmail,@RoomNumber,@RoomCapacity,@Description)";

            cmd.Parameters.Add("@EventTitle", SqlDbType.NVarChar).Value = EventTitle;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@Time", SqlDbType.DateTime).Value = Time;
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            cmd.Parameters.Add("@MiddleSchoolName", SqlDbType.NVarChar).Value = MiddleSchoolName;
            cmd.Parameters.Add("@MiddleSchoolNumber", SqlDbType.NVarChar).Value = MiddleSchoolNumber;
            cmd.Parameters.Add("@MiddleSchoolEmail", SqlDbType.NVarChar).Value = MiddleSchoolEmail;
            cmd.Parameters.Add("@RoomNumber", SqlDbType.NVarChar).Value = RoomNumber;
            cmd.Parameters.Add("@RoomCapacity", SqlDbType.NVarChar).Value = RoomCapacity;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }

        private bool IsEventDuplicate(string EventTitle, string Location, string MiddleSchoolName, string RoomNumber)
        {
            // Check if the system has the duplicate student information a
            String sqlQuery = "SELECT * FROM Event WHERE EventTitle = ' + @EventTitle + ' and Location = ' + @Location + ' " +
                "and MiddleSchoolName = ' + @MiddleSchoolName + ' and RoomNumber = ' + @RoomNumber + ' ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CyberDay"].ConnectionString);

            SqlCommand comm = new SqlCommand(sqlQuery, con);
            comm.Parameters.Add("@EventTitle", SqlDbType.NVarChar).Value = EventTitle.Trim();
            comm.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location.Trim();
            comm.Parameters.Add("@MiddleSchoolName", SqlDbType.NVarChar).Value = MiddleSchoolName.Trim();
            comm.Parameters.Add("@RoomNumber", SqlDbType.NVarChar).Value = RoomNumber.Trim();
            con.Open();
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;
            DataTable dtForGridTable = new DataTable();
            da.Fill(dtForGridTable);

            con.Close();

            if (dtForGridTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}