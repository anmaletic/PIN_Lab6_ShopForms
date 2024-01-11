using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopForms
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "" || tb_pass.Text == "")
            {
                lbl_error.Text = "Popunite sva polja!";
                return;
            }

            if (CheckUser())
            {
                Response.Redirect("Shop.aspx");
            }
            else
            {
                lbl_error.Text = "Korisnik ne postoji!";
            }
        }

        private bool CheckUser()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("SELECT * FROM Users WHERE username = @username AND password = @password", conn);
            comm.Parameters.AddWithValue("username", tb_username.Text);
            comm.Parameters.AddWithValue("password", tb_pass.Text);

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
                lbl_error.Text = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}