using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace QuanLyDiem.View
{
    public partial class WebFormMonHoc : System.Web.UI.Page
    {
        string strCon = "server = AcerNitro5\\VANDUONG;database=QuanLyDiem; Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            txbMaMon.Enabled = false;
            MonHocLoad();
        }
        private void MonHocLoad()
        {
            string sSql = "Select * from MonHoc";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                dgvMonHoc.DataSource = dataTable;
                dgvMonHoc.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sSql = "INSERT INTO MonHoc (TenMon) VALUES(@TenMon)";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sSql, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TenMon", txbTenMon.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            MonHocLoad();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                if (string.IsNullOrWhiteSpace(txbMaMon.Text))
                    return;
                string query = "UPDATE dbo.MonHoc SET TenMon = @TenMon WHERE MaMon = @MaMon";

                using (SqlCommand sqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TenMon", txbTenMon.Text);
                    sqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            MonHocLoad();
        }

        protected void dgvMonHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if(e.CommandName == "Edit")
                {
                    txbMaMon.Text = dgvMonHoc.Rows[row].Cells[0].Text;
                    txbTenMon.Text = dgvMonHoc.Rows[row].Cells[1].Text;
                }
                else if(e.CommandName == "Delete")
                {
                    string sSql = "DELETE dbo.MonHoc WHERE MaMon = @MaMon";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaMon", dgvMonHoc.Rows[row].Cells[0].Text);
                        mySqlCommand.ExecuteNonQuery();
                        MonHocLoad();
                    }
                }
            }
        }

        protected void dgvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}