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
using System.Data.Common;

namespace Lab2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrectLogin.ForeColor = Color.Red;
            if (Session["InvalidUsage"] != null)
            {
                lblIncorrectLogin.Text = Session["InvalidUsage"].ToString();
            }
            if (Session["LoggedOut"] != null)
            {
                lblIncorrectLogin.Text = Session["LoggedOut"].ToString();
            }

            if (Request.QueryString.Get("loggedout") == "true")
            {
                lblIncorrectLogin.ForeColor = Color.Green; lblIncorrectLogin.Text = "User Successfully Logged Out!";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtUsername.Text);
            HttpUtility.HtmlEncode(txtPassword.Text);

            SqlConnection myconnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTHORIZATION"].ConnectionString.ToString());

            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = myconnection;
            loginCommand.CommandType = CommandType.StoredProcedure;
            loginCommand.CommandText = "Authorize";
            loginCommand.Parameters.AddWithValue("@UserName", txtUsername.Text.ToString());
            loginCommand.Parameters.AddWithValue("@PassWord", txtPassword.Text.ToString());
            myconnection.Open();
            SqlDataReader loginResults = loginCommand.ExecuteReader();
            if (loginResults.Read())
            {
                lblStatus.Text = loginResults["Username"].ToString() + "Logged in successfully!";
            }
            else
            {
                lblStatus.Text = "Isssue with Username and/or Password!";
            }
            myconnection.Close();

            try
            {
                HttpUtility.HtmlEncode(txtUsername.Text);

                SqlCommand cmd = new SqlCommand();

                //Get connection string from web.config file  
                string strcon = ConfigurationManager.ConnectionStrings["AUTHORIZATION"].ConnectionString;
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection con = new SqlConnection(strcon);
                cmd.Connection = con;

                lblStatus.Text = "Database Connection Successful";
                con.Open();
                //System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = con;
                // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
                cmd.CommandText = "select PasswordHash from Pass where Username = @Username";
                cmd.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));

                SqlDataReader reader = cmd.ExecuteReader(); // create a reader

                if (reader.HasRows) // if the username exists, it will continue
                {
                    while (reader.Read()) // this will read the single record that matches the entered username
                    {
                        string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                        if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                        {
                            lblStatus.Text = "Success!";
                            btnLogin.Enabled = false;
                            txtUsername.Enabled = false;
                            txtPassword.Enabled = false;
                            string hi = "Welcome," + " " + HttpUtility.HtmlEncode(txtUsername.Text);
                            
                            Site1.visitor = hi;
                            Session["Username"] = txtUsername.Text;
                            Server.Transfer("HomePage.aspx");
                        }
                        else
                            lblStatus.Text = "Password is wrong.";
                    }
                }
                else // if the username doesn't exist, it will show failure
                    lblStatus.Text = "Login failed.";

                con.Close();
            }
            catch
            {
                lblStatus.Text = "Database Error.";
            }


        }

        protected void lnkcreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx", false);
        }
    }
}