using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDiem.View
{
    public partial class WebFormSinhVien : System.Web.UI.Page
    {
        string strCon = "server = AcerNitro5\\VANDUONG;database=QuanLyDiem; Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            SinhVienLoad();
        }
        private void SinhVienLoad()
        {
            string sSql = "Select * from SinhVien";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                dgvSinhVien.DataSource = dataTable;
                dgvSinhVien.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sSql = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GhiChu) VALUES(@MaSV, @HoTen, @NgaySinh, @GhiChu)";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sSql, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                    sqlCommand.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                    sqlCommand.Parameters.AddWithValue("@NgaySinh", txbNgaySinh.Text);
                    sqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            SinhVienLoad();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                if (string.IsNullOrWhiteSpace(txbMaSV.Text))
                    return;
                string query = "UPDATE dbo.SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GhiChu = @GhiChu WHERE MaSV = @MaSV";

                using (SqlCommand sqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                    sqlCommand.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                    sqlCommand.Parameters.AddWithValue("@NgaySinh", txbNgaySinh.Text);
                    sqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            SinhVienLoad();
        }

        protected void dgvSinhVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Edit")
                {
                    txbMaSV.Text = dgvSinhVien.Rows[row].Cells[0].Text;
                    txbHoTen.Text = dgvSinhVien.Rows[row].Cells[1].Text;
                    txbNgaySinh.Text = dgvSinhVien.Rows[row].Cells[2].Text;
                    txbGhiChu.Text = dgvSinhVien.Rows[row].Cells[3].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    string sSql = "DELETE dbo.SinhVien WHERE MaSV = @MaSV";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaSV", dgvSinhVien.Rows[row].Cells[0].Text);
                        mySqlCommand.ExecuteNonQuery();
                        SinhVienLoad();
                    }
                }
            }
        }

        protected void dgvSinhVien_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvSinhVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}