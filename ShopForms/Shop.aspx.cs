using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopForms
{
    public partial class Shop : System.Web.UI.Page
    {
        string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        protected void buttonSpremi_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void AddProduct()
        {
            if (tb_name.Text == "" || tb_desc.Text == "")
            {
                lbl_error.Text = "Popunite sva polja!";
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("INSERT INTO Products VALUES (@Name, @Description) ", conn);
            comm.Parameters.AddWithValue("Name", tb_name.Text);
            comm.Parameters.AddWithValue("Description", tb_desc.Text);

            try
            {
                conn.Open();
                int result = comm.ExecuteNonQuery();
                if (result == 1)
                {
                    LoadProducts();
                    ClearFields();
                }
                else
                {
                    lbl_error.Text = "Došlo je do pogreške!";
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

        private void LoadProducts()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("SELECT * FROM Products", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader(); 
                gridProducts.DataSource = reader;
                gridProducts.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        private void ClearFields()
        {
            tb_name.Text = "";
            tb_desc.Text = "";
        }
    }
}