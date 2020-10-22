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

    public partial class CreateStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            if (IsStudentDuplicate(txtStudentFN.Text, txtStudentLN.Text, txtAge.Text, txtNotes.Text, txtLunchTicket.Text))
            {
                // Check if the student exist after user input all the information in the webpage
                //System.Windows.MessageBox.Show("The Student has already exist");
                Response.Write("<script>alert('The Student has already exist');</script>");
                return;
            }

            string FirstName = HttpUtility.HtmlEncode(txtStudentFN.Text);
            string LastName = HttpUtility.HtmlEncode(txtStudentLN.Text);
            string Age = HttpUtility.HtmlEncode(txtAge.Text);
            string Notes = HttpUtility.HtmlEncode(txtNotes.Text);
            string LunchTicket = HttpUtility.HtmlEncode(txtLunchTicket.Text);
            int TeacherID = Convert.ToInt32(DropDownList1.SelectedValue);
            int ShirtInfoID = Convert.ToInt32(DropDownList2.SelectedValue);

            //new Student(0, FirstName, LastName, Age, Notes, LunchTicket, TeacherID, ShirtInfoID);

            // Make sure none of the textboxes are blank before commit to the database
            if ((!string.IsNullOrEmpty(txtStudentFN.Text)) && (!string.IsNullOrEmpty(txtStudentLN.Text))
                && (!string.IsNullOrEmpty(txtAge.Text)) && (!string.IsNullOrEmpty(txtNotes.Text)) && (!string.IsNullOrEmpty(txtLunchTicket.Text)))
            {
                try
                {
                    // Retrieve the data and display a messagebox shows added successfully
                    Insetr_Student(FirstName, LastName, Age, Notes, LunchTicket, TeacherID, ShirtInfoID);
                    //System.Windows.MessageBox.Show("OK! Added Student Successfully!");
                    Response.Write("<script>alert('OK! Added Student Successfully!');</script>");

                }
                catch (SqlException ex)
                {
                    //System.Windows.MessageBox.Show("Warning!The Student has already exist!");
                    Response.Write("<script>alert('Warning!The Student has already exist!');</script>");

                }
            }
            else
            {
                //System.Windows.MessageBox.Show("There is textbox is empty!");
                Response.Write("<script>alert('There is textbox is empty!');</script>");

            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            // Outer Join SQL Query
            String sqlQuery = "SELECT Student.FirstName + ' ' + Student.LastName AS StudentName, Teacher.FirstName+ ' ' + Teacher.LastName as TeacherName, Student.Age, Student.Notes, Student.LunchTicket ";
            sqlQuery += "FROM Student FULL OUTER JOIN Teacher ";
            sqlQuery += "ON Student.TeacherID = Teacher.TeacherID ";

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            con.Open();
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            getTeacherResult.DataSource = dtForGridTable;
            getTeacherResult.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the textbox after each insertion data
            txtStudentFN.Text = "";
            txtStudentLN.Text = "";
            txtAge.Text = "";
            txtNotes.Text = "";
            txtLunchTicket.Text = "";
        }

        private void Insetr_Student(string FirstName, string LastName, string Age, string Notes, string LunchTicket, int TeacherID, int ShirtInfoID)
        {
            // Read the data from the database
            SqlCommand cmd = new SqlCommand();

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            cmd.Connection = con;

            cmd.CommandText = "insert into Student (FirstName,LastName,Age,Notes,LunchTicket,TeacherID, ShirtInfoID) values (@FirstName,@LastName,@Age,@Notes,@LunchTicket,@TeacherID,@ShirtInfoID)";

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            cmd.Parameters.Add("@Age", SqlDbType.NVarChar).Value = Age;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Notes;
            cmd.Parameters.Add("@LunchTicket", SqlDbType.NVarChar).Value = LunchTicket;
            cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = TeacherID;
            cmd.Parameters.Add("@ShirtInfoID", SqlDbType.Int).Value = ShirtInfoID;

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            con.Close();
        }

        private bool IsStudentDuplicate(string FirstName, string LastName, string Age, string Notes, string LunchTicket)
        {
            // Check if the system has the duplicate student information a
            String sqlQuery = "select * from Student where FirstName = ' + @FirstName + ' and LastName = ' + @LastName + ' and Age = ' + Age + ' and Notes = ' + @Notes +' and LunchTicket = ' + @LunchTicket + ' ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

            SqlCommand comm = new SqlCommand(sqlQuery, con);
            comm.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName.Trim();
            comm.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName.Trim();
            comm.Parameters.Add("@Age", SqlDbType.NVarChar).Value = Age.Trim();
            comm.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Notes.Trim();
            comm.Parameters.Add("@LunchTicket", SqlDbType.NVarChar).Value = LunchTicket.Trim();
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
