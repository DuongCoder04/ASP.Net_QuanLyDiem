using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDiem.View
{
    public partial class WebFormDiemThi : System.Web.UI.Page
    {
        string strCon = "server = AcerNitro5\\VANDUONG; database = QuanLyDiem; Trusted_Connection = true";
        protected void Page_Load(object sender, EventArgs e)
        {
            DiemThiLoad();
        }
        private void DiemThiLoad()
        {
            string sSql = "select * from DiemThi";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection);
                SqlDataReader myDataReader = mySqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(myDataReader);
                dgvMonHoc.DataSource = dataTable;
                dgvMonHoc.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sSql = "INSERT INTO DiemThi (MaMon, MaSV, DiemCC, DiemGK, DiemThi, DiemTK) VALUES(@MaMon, @MaSV, @DiemCC, @DiemGK, @DiemThi, @DiemTK)";
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sSql, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaDT", txbMaDT.Text);
                    sqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text);
                    sqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemCC", txbDiemCC.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemGK", txbDiemGK.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemThi", txbDiemThi.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemTK", txbDiemTK.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            DiemThiLoad();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                if (string.IsNullOrWhiteSpace(txbMaDT.Text))
                    return;
                string query = "UPDATE dbo.DiemThi SET MaMon = @MaMon, MaSV = @MaSV, DiemCC = @DiemCC, DiemGK = @DiemGK, DiemThi = @DiemThi, DiemTK = @DiemTK WHERE MaDT = @MaDT";

                using (SqlCommand sqlCommand = new SqlCommand(query, mySqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaDT", txbMaDT.Text);
                    sqlCommand.Parameters.AddWithValue("@MaMon", txbMaMon.Text);
                    sqlCommand.Parameters.AddWithValue("@MaSV", txbMaSV.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemCC", txbDiemCC.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemGK", txbDiemGK.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemThi", txbDiemThi.Text);
                    sqlCommand.Parameters.AddWithValue("@DiemTK", txbDiemTK.Text);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            DiemThiLoad();
        }

        protected void dgvMonHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(strCon))
            {
                mySqlConnection.Open();
                int row = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Edit")
                {
                    txbMaDT.Text = dgvMonHoc.Rows[row].Cells[0].Text;
                    txbMaMon.Text = dgvMonHoc.Rows[row].Cells[1].Text;
                    txbMaSV.Text = dgvMonHoc.Rows[row].Cells[2].Text;
                    txbDiemCC.Text = dgvMonHoc.Rows[row].Cells[3].Text;
                    txbDiemGK.Text = dgvMonHoc.Rows[row].Cells[4].Text;
                    txbDiemThi.Text = dgvMonHoc.Rows[row].Cells[5].Text;
                    txbDiemTK.Text = dgvMonHoc.Rows[row].Cells[6].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    string sSql = "DELETE dbo.DiemThi WHERE MaDT = @MaDT";
                    using (SqlCommand mySqlCommand = new SqlCommand(sSql, mySqlConnection))
                    {
                        mySqlCommand.Parameters.AddWithValue("@MaDT", dgvMonHoc.Rows[row].Cells[0].Text);
                        mySqlCommand.ExecuteNonQuery();
                        DiemThiLoad();
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