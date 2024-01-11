using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopForms
{
    public partial class Registracija : System.Web.UI.Page
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void buttonReg_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "" || tb_pass.Text == "" || tb_fullname.Text == "")
            {
                lbl_error.Text = "Popunite sva polja!";
                return;
            }

            if (tb_pass.Text != tb_passrepeat.Text)
            {
                lbl_error.Text = "Lozinke se ne podudaraju!";
                return;
            }

            if (!CheckUser())
            {
                AddUser();
            }
            else
            {
                lbl_error.Text = "Korisnik već postoji!";
            }

        }

        private bool CheckUser()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("SELECT * FROM Users WHERE username = @username", conn);
            comm.Parameters.AddWithValue("username", tb_username.Text);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Došlo je do pogreške!";
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void AddUser()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("INSERT INTO Users VALUES (@username, @password, @fullname ) ", conn);
            comm.Parameters.AddWithValue("username", tb_username.Text);
            comm.Parameters.AddWithValue("password", tb_pass.Text);
            comm.Parameters.AddWithValue("fullname", tb_fullname.Text);

            try
            {
                conn.Open();
                int result = comm.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Došlo je do pogreške!";
            }
            finally
            {
                conn.Close();
            }
        }
    }
}