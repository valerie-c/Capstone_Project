using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Configuration;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtFirstName.Text);
            HttpUtility.HtmlEncode(txtLastName.Text);
            HttpUtility.HtmlEncode(txtGrade.Text);
            HttpUtility.HtmlEncode(txtSchool.Text);
            HttpUtility.HtmlEncode(txtUsername.Text);
            HttpUtility.HtmlEncode(txtPassword.Text);

            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtSchool.Text != "" && txtGrade.Text != "" && txtPassword.Text != "" && txtUsername.Text != "") // all fields must be filled out
            {
                // COMMIT VALUES
                try
                {                  
                    SqlCommand createUser = new SqlCommand();
                    //Get connection string from web.config file  
                    string strcon = ConfigurationManager.ConnectionStrings["dbconnection2"].ConnectionString;
                    //create new sqlconnection and connection to database by using connection string from web.config file  
                    SqlConnection con = new SqlConnection(strcon);

                    //sc.Open();

                    createUser.Connection = con;
                    lblStatus.Text = "Database Connection Successful";

                    con.Open();

                    //System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = con;
                    // INSERT USER RECORD
                    createUser.CommandText = "insert into [dbo].[Person] values(@FName, @LName, @school, @grade, @Username, @Password)";
                    createUser.Parameters.Add(new SqlParameter("@FName", txtFirstName.Text));
                    createUser.Parameters.Add(new SqlParameter("@LName", txtLastName.Text));
                    createUser.Parameters.Add(new SqlParameter("@school", txtSchool.Text));
                    createUser.Parameters.Add(new SqlParameter("@grade", txtGrade.Text));
                    createUser.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    createUser.Parameters.Add(new SqlParameter("@Password", txtPassword.Text));
                    createUser.ExecuteNonQuery();

                    System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                    setPass.Connection = con;
                    // INSERT PASSWORD RECORD AND CONNECT TO USER
                    setPass.CommandText = "insert into [dbo].[Pass] values((select max(UserID) from person), @Username, @Password)";
                    setPass.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                    setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(txtPassword.Text))); // hash entered password
                    setPass.ExecuteNonQuery();

                    con.Close();

                    lblStatus.Text = "User committed!";
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtSchool.Enabled = false;
                    txtGrade.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    btnSubmit.Enabled = false;
                    lnkAnother.Visible = true;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Database Error - User not committed.";
                }

            }
            else
                lblStatus.Text = "Fill all fields.";
        }

        protected void lnkAnother_Click(object sender, EventArgs e)
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtSchool.Enabled = true;
            txtGrade.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            btnSubmit.Enabled = true;
            lnkAnother.Visible = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSchool.Text = "";
            txtGrade.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            // Outer Join SQL Query
            String sqlQuery = "SELECT FirstName + ' ' + LastName AS Name, Role, Username, Password ";
            sqlQuery += "FROM UserAccount ";
            

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, con);
            con.Open();
            DataTable dtForGridTable = new DataTable();
            sqlAdapter.Fill(dtForGridTable);

            GridView1.DataSource = dtForGridTable;
            GridView1.DataBind();
        }
    }
}